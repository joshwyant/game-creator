using System;
using static System.Math;
using GameCreator.Engine.Common;
using GameCreator.Api.Resources;
using GameCreator.Api.Runtime;

namespace GameCreator.Engine
{
    public sealed class GameInstance : IInstanceVars, IInstance
    {
        private double _direction, _speed, _hspeed, _vspeed;

        public GameContext Context { get; }
        public int Id { get; set; } = -1;
        public int InstanceId => Id;
        public int ObjectIndex => AssignedObject?.Id ?? 0;
        public double X { get; set; }
        public double Y { get; set; }
        public double XStart { get; set; }
        public double YStart { get; set; }
        public double XPrevious { get; set; }
        public double YPrevious { get; set; }
        public bool Visible { get; set; } = true;
        public bool Solid { get; set; }
        public bool Persistent { get; set; }
        public double Depth { get; set; }
        public int SpriteIndex { get; set; } = -1;
        public double ImageSpeed { get; set; } = 1.0;
        public double ImageSingle { get; set; } = -1;
        public double ImageIndex { get; set; }
        public double ImageAngle { get; set; }
        public int ImageBlend { get; set; } = 0xFFFFFF;
        public double ImageAlpha { get; set; } = 1;
        public double ImageXScale { get; set; } = 1.0;
        public double ImageYScale { get; set; } = 1.0;
        public int[] Alarm { get; } = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        public bool Destroyed { get; set; }
        public int SpriteWidth => AssignedObject?.Sprite?.Width ?? 0;
        public int SpriteHeight => AssignedObject?.Sprite?.Height ?? 0;
        public int SpriteXOffset => AssignedObject?.Sprite?.XOrigin ?? 0;
        public int SpriteYOffset => AssignedObject?.Sprite?.YOrigin ?? 0;
        public int PathIndex { get; internal set; }
        public double PathPosition { get; set; }
        public double PathPositionPrevious { get; set; }
        public double PathSpeed { get; set; }
        public double PathOrientation { get; set; }
        public double PathScale { get; set; }
        public PathEndAction PathEndAction { get; set; }

        public double Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                UpdateHSpeedVSpeed();
            }
        }
        public double Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                UpdateHSpeedVSpeed();
            }
        }
        public double HSpeed
        {
            get => _hspeed;
            set
            {
                _hspeed = value;
                UpdateSpeedDirection(true);
            } 
        }
        public double VSpeed
        {
            get => _vspeed;
            set
            {
                _vspeed = value;
                UpdateSpeedDirection(true);
            } 
        }
        public double Gravity { get; set; }
        public double GravityDirection { get; set; } = 270.0;
        public double Friction { get; set; }
        public GameSprite Sprite => Context.Sprites[SpriteIndex];
        public GameObject AssignedObject { get; private set; }

        internal GameInstance(GameContext context, double x, double y, GameObject assignedObject)
        {
            Context = context;
            X = XPrevious = XStart = x;
            Y = YPrevious = YStart = y;
            AssignedObject = assignedObject;
        }

        public void Change(GameObject assignedObject, bool performEvents)
        {
            if (performEvents)
            {
                PerformEvent(EventType.Destroy);
            }
            AssignedObject = assignedObject;
            assignedObject.InitializeInstance(this);
            if (performEvents)
            {
                PerformEvent(EventType.Create);
            }
        }

        public void PerformEvent(EventType eventType, int eventNumber = 0)
        {
            AssignedObject.PerformEvent(this, eventType, eventNumber);
        }

        /// <summary>
        /// Performs the event if the condition is met.
        /// The condition is not evaluated if the event is not registered.
        /// </summary>
        public void PerformEventIf(EventType eventType, int eventNumber, Func<bool> condition)
        {
            if (AssignedObject.IsEventRegistered(eventType, eventNumber)
                && condition())
            {
                PerformEvent(eventType, eventNumber);
            }
        }

        /// <summary>
        /// Performs the event. Returns whether the event was registered.
        /// </summary>
        public bool PerformEventIfRegistered(EventType eventType, int eventNumber = 0)
        {
            if (AssignedObject.IsEventRegistered(eventType, eventNumber))
            {
                PerformEvent(eventType, eventNumber);
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Used after setting vspeed or hspeed to set speed and direction variables.
        /// </summary>
        /// <param name="resetdir">whether direction should be set to 0 by default if speed is 0.</param>
        private void UpdateSpeedDirection(bool resetdir)
        {
            _speed = Sqrt(_hspeed * _hspeed + _vspeed * _vspeed);
            
            if (_speed <= 0.00001)
            {
                _speed = 0.0;
                if (resetdir)
                {
                    _direction = 0.0;
                }
            }
            else
            {
                _direction = Atan2(-_vspeed / _speed, _hspeed / _speed) / PI * 180.0;
                if (_direction < 0.0)
                {
                    _direction += 360.0;
                }
            }
        }
        
        /// <summary>
        /// Used after setting speed or direction to set vspeed and hspeed variables.
        /// </summary>
        private void UpdateHSpeedVSpeed()
        {
            _hspeed = Cos(_direction * PI / 180.0) * Speed;
            _vspeed = -Sin(_direction * PI / 180.0) * Speed;
        }
        
        public void SetSpeedVector(double hspeed, double vspeed)
        {
            _hspeed = hspeed;
            _vspeed = vspeed;
            UpdateSpeedDirection(false);
        }
        
        public void AddSpeedVector(double hspeed, double vspeed)
        {
            _hspeed += hspeed;
            _vspeed += vspeed;
            UpdateSpeedDirection(false);
        }
        
        public void SetMotion(double direction, double speed)
        {
            _direction = direction;
            _speed = speed;
            UpdateHSpeedVSpeed();
        }

        public int ComputeSubimage() => (int) Floor(ImageIndex) % Sprite?.SubImages.Length ?? 1;
        
        public void DrawSprite()
        {
            if (Context.Sprites.ContainsKey(SpriteIndex))
            {
                Context.Library.Drawing.DrawSprite(
                    Sprite,
                    ComputeSubimage(),
                    X,
                    Y,
                    ImageXScale,
                    ImageYScale,
                    ImageAngle,
                    ImageBlend,
                    ImageAlpha);
            }
        }

        public void FullStep()
        {
            PerformEvent(EventType.Step, (int) StepKind.Normal);
                
            // friction first
            Speed = Friction > 0 && Abs(Speed) < Friction
                ? 0
                : Speed - Friction * Sign(Speed);
                
            // then gravity
            AddSpeedVector(
                Gravity * Cos(GravityDirection * PI / 180),
                -Gravity * Sin(GravityDirection * PI / 180));
                
            // move the instance
            X += HSpeed;
            Y += VSpeed;

            // Process Outside event
            PerformEventIf(EventType.Other, (int) OtherEventKind.Outside, 
                () =>
                {
                    if (Sprite == null) return false;
                    var m = Context.Library.Move.GetSpriteTransform(this);
                    var bb = Context.Library.Move.GetSpriteTransformedBoundingBox(Sprite, m);

                    if (!bb.IsValid) return false;

                    return bb.Right < 0 
                           || bb.Left >= Context.CurrentRoom.Width
                           || bb.Bottom < 0 
                           || bb.Top >= Context.CurrentRoom.Height;
                });

            // Process Intersect Boundary event
            PerformEventIf(EventType.Other, (int) OtherEventKind.Boundary, 
                () =>
                {
                    if (Sprite == null) return false;
                    var m = Context.Library.Move.GetSpriteTransform(this);
                    var bb = Context.Library.Move.GetSpriteTransformedBoundingBox(Sprite, m);

                    if (!bb.IsValid) return false;

                    return bb.Left < 0 && bb.Right > 0
                            || bb.Left < Context.CurrentRoom.Width && bb.Right > Context.CurrentRoom.Width
                            || bb.Top < 0 && bb.Bottom > 0
                            || bb.Top < Context.CurrentRoom.Height && bb.Bottom > Context.CurrentRoom.Height;
                });
        }
    }
}