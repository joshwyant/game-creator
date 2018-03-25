using System;
using System.Collections.Generic;
using GameCreator.Engine.Common;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine
{
    public abstract class GameObject : IIndexedResource
    {
        public GameContext Context { get; }
        public int Id { get; set; } = -1;
        public double Depth { get; set; }
        public abstract GameSprite Sprite { get; }
        public bool Solid { get; protected set; }
        public bool Persistent { get; protected set; }
        
        protected internal GameObject(GameContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Used when an instance is created, or changed to another object.
        /// </summary>
        public void InitializeInstance(GameInstance instance)
        {
            if (Sprite != null)
            {
                instance.SpriteIndex = Sprite.Id;
            }

            instance.Solid = Solid;
            instance.Depth = Depth;
            instance.Persistent = Persistent || instance.Persistent;
            instance.ImageIndex = 0;
            instance.ImageSingle = -1;
            instance.ImageAlpha = 1.0;
            instance.ImageAngle = 0;
            instance.ImageBlend = 0xFFFFFF;
        }

        private readonly Dictionary<(EventType, int), Action<GameInstance>> RegisteredEvents
            = new Dictionary<(EventType, int), Action<GameInstance>>();

        #region IsEventRegistered
        public bool IsEventRegistered(EventType eventType, int eventNumber)
        {
            return RegisteredEvents.ContainsKey((eventType, eventNumber));
        }

        public bool IsEventRegistered(EventType eventType)
        {
            return RegisteredEvents.ContainsKey((eventType, 0));
        }

        public bool IsEventRegistered(StepKind stepKind)
        {
            return RegisteredEvents.ContainsKey((EventType.Step, (int) stepKind));
        }

        public bool IsEventRegistered(EventType eventType, VirtualKeyCode keyCode)
        {
            return RegisteredEvents.ContainsKey((eventType, (int) keyCode));
        }

        public bool IsEventRegistered(EventType eventType, MouseEventKind mouseKind)
        {
            return RegisteredEvents.ContainsKey((eventType, (int) mouseKind));
        }

        public bool IsEventRegistered(GameObject otherCollisionObject)
        {
            return RegisteredEvents.ContainsKey((EventType.Collision, otherCollisionObject.Id));
        }

        public bool IsEventRegistered(OtherEventKind otherKind)
        {
            return RegisteredEvents.ContainsKey((EventType.Other, (int) otherKind));
        }

        public bool IsEventRegistered(ITrigger trigger)
        {
            return RegisteredEvents.ContainsKey((EventType.Trigger, trigger.Id));
        }
        #endregion

        #region RegisterEvent
        
        protected void RegisterEvent(EventType eventType, int eventNumber, Action<GameInstance> handler)
        {
            RegisteredEvents.Add((eventType, eventNumber), handler);
        }

        protected void RegisterEvent(EventType eventType, Action<GameInstance> handler)
        {
            RegisterEvent(eventType, 0, handler);
        }

        protected void RegisterEvent(StepKind stepKind, Action<GameInstance> handler)
        {
            RegisterEvent(EventType.Step, (int) stepKind, handler);
        }

        protected void RegisterEvent(EventType eventType, VirtualKeyCode keyCode, Action<GameInstance> handler)
        {
            RegisterEvent(eventType, (int) keyCode, handler);
        }
        
        protected void RegisterEvent(EventType eventType, MouseEventKind mouseKind, Action<GameInstance> handler)
        {
            RegisterEvent(eventType, (int) mouseKind, handler);
        }
        
        protected void RegisterEvent(GameObject otherCollisionObject, Action<GameInstance> handler)
        {
            RegisterEvent(EventType.Collision, otherCollisionObject.Id, handler);
        }
        
        protected void RegisterEvent(OtherEventKind otherKind, Action<GameInstance> handler)
        {
            RegisterEvent(EventType.Other, (int) otherKind, handler);
        }
        
        protected void RegisterEvent(ITrigger trigger, Action<GameInstance> handler)
        {
            RegisterEvent(EventType.Trigger, trigger.Id, handler);
        }
        #endregion

        public void PerformEvent(GameInstance instance, EventType eventType, int eventNumber = 0)
        {
            if (!instance.Destroyed || eventType == EventType.Destroy)
            {
                if (IsEventRegistered(eventType, eventNumber))
                {
                    RegisteredEvents[(eventType, eventNumber)](instance);
                }
            }
        }

        protected internal virtual void OnRegisterEvents()
        {
        }
    }
}