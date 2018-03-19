using System;
using GameCreator.Core;

namespace GameCreator.Engine
{
    public sealed class GameInstance : IInstanceVars, IIndexedResource
    {
        private double _direction, _speed, _hspeed, _vspeed;
        
        public GameContext Context { get; }
        public int Id { get; set; } = -1;
        public int InstanceId => Id;
        public int ObjectIndex => AssignedObject.Id;
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
        public uint ImageBlend { get; set; } = 0xFFFFFF;
        public double ImageAlpha { get; set; } = 1;
        public double ImageXScale { get; set; } = 1.0;
        public double ImageYScale { get; set; } = 1.0;
        public int[] Alarm { get; } = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        public bool Destroyed { get; set; }

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
        /// Used after setting vspeed or hspeed to set speed and direction variables.
        /// </summary>
        /// <param name="resetdir">whether direction should be set to 0 by default if speed is 0.</param>
        private void UpdateSpeedDirection(bool resetdir)
        {
            _speed = Math.Sqrt(_hspeed * _hspeed + _vspeed * _vspeed);
            
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
                _direction = Math.Atan2(-_vspeed / _speed, _hspeed / _speed) / Math.PI * 180.0;
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
            _hspeed = Math.Cos(_direction * Math.PI / 180.0) * Speed;
            _vspeed = -Math.Sin(_direction * Math.PI / 180.0) * Speed;
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

        public void DrawSprite()
        {
            if (Context.Sprites.ContainsKey(SpriteIndex))
            {
                var subImage = (int) Math.Floor(ImageIndex) % Sprite.SubImages.Length;
                
                Context.Library.DrawingFunctions.DrawSprite(
                    Sprite,
                    subImage,
                    (float) X,
                    (float) Y,
                    (float) ImageXScale,
                    (float) ImageYScale,
                    (float) ImageAngle,
                    ImageBlend,
                    (float) ImageAlpha);
            }
        }
    }
}