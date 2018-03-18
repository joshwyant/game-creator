using System;
using GameCreator.Core;

namespace GameCreator.Engine
{
    public abstract class GameObject : IIndexedResource
    {
        public IGameContext Context { get; }
        public int Id { get; set; } = -1;
        public double Depth { get; set; }
        public abstract GameSprite Sprite { get; }
        
        protected internal GameObject(IGameContext context)
        {
            Context = context;
        }

        public void InitializeInstance(GameInstance instance)
        {
            if (Sprite != null)
            {
                instance.SpriteIndex = Sprite.Id;
            }
            instance.Depth = Depth;
        }

        protected virtual void OnCreate(GameInstance instance, ref bool handled)
        {
            handled = false;
        }
        protected virtual void OnDestroy(GameInstance instance, ref bool handled)
        {
            handled = false;
        }
        protected virtual void OnStep(GameInstance instance, StepKind stepKind, ref bool handled) 
        { 
            handled = false;
        }
        protected virtual void OnAlarm(GameInstance instance, int alarmNumber, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnKeyboard(GameInstance intstance, VirtualKeyCode keyCode, ref bool handled) 
        { 
            handled = false;
        }
        protected virtual void OnMouse(GameInstance instance, MouseEventKind eventKind, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnCollision(GameInstance instance, GameObject other, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnOtherEvent(GameInstance instance, OtherEventKind eventKind, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnDraw(GameInstance instance, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnKeyPress(GameInstance instance, VirtualKeyCode keyCode, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnKeyRelease(GameInstance instance, VirtualKeyCode keyCode, ref bool handled)
        { 
            handled = false;
        }
        protected virtual void OnTrigger(GameInstance instance, ITrigger trigger, ref bool handled)
        { 
            handled = false;
        }

        public bool PerformEvent(GameInstance instance, EventType eventType, int eventNumber = 0)
        {
            var handled = true;
            switch (eventType)
            {
                case EventType.Create:
                    OnCreate(instance, ref handled);
                    break;
                case EventType.Destroy:
                    OnDestroy(instance, ref handled);
                    break;
                case EventType.Step:
                    OnStep(instance, (StepKind)eventNumber, ref handled);
                    break;
                case EventType.Alarm:
                    OnAlarm(instance, eventNumber, ref handled);
                    break;
                case EventType.Keyboard:
                    OnKeyboard(instance, (VirtualKeyCode)eventNumber, ref handled);
                    break;
                case EventType.Mouse:
                    OnMouse(instance, (MouseEventKind)eventNumber, ref handled);
                    break;
                case EventType.Collision:
                    OnCollision(instance, Context.Objects[eventNumber], ref handled);
                    break;
                case EventType.Other:
                    OnOtherEvent(instance, (OtherEventKind)eventNumber, ref handled);
                    break;
                case EventType.Draw:
                    OnDraw(instance, ref handled);
                    break;
                case EventType.KeyPress:
                    OnKeyPress(instance, (VirtualKeyCode)eventNumber, ref handled);
                    break;
                case EventType.KeyRelease:
                    OnKeyRelease(instance, (VirtualKeyCode)eventNumber, ref handled);
                    break;
                case EventType.Trigger:
                    OnTrigger(instance, Context.Triggers[eventNumber], ref handled);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
            }
            return handled;
        }
    }
}