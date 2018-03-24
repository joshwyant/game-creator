using System;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Engine.Api;
using GameCreator.Engine.Common;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IndexedResourceManager<ITrigger> Triggers { get; }
        public ITimerPlugin Timer { get; }
        public GameInstance OtherInstance { get; set; }
        
        /// <summary>
        /// This can be accessed in a loop, but don't use foreach if you are creating new instances!
        /// </summary>
        internal List<GameInstance> PresortedInstances { get; set; }
        
        /// <summary>
        /// Loop through non-destroyed instances, including those created during the loop.
        /// Instances are only sorted immediately before drawing.
        /// </summary>
        private void ForInstances(Action<GameInstance> handler)
        {
            // Don't use a foreach in case the collection changes during the loop.
            for (var i = 0; i < PresortedInstances.Count; i++)
            {
                var instance = PresortedInstances[i];
                if (instance.Destroyed) continue;
                handler(instance);
            }
        }
        
        public void ProcessEvents()
        {
            // Process begin step events
            ForInstances(i => i.PerformEvent(EventType.Step, (int) StepKind.BeginStep));

            // Process alarm events
            ForInstances(i =>
            {
                for (var j = 0; j < 12; j++)
                {
                    if (i.Alarm[j] >= 0 && --i.Alarm[j] == 0)
                    {
                        i.PerformEvent(EventType.Alarm, j);
                    }
                }
            });

            // Process keyboard events
            {
                var anyKey = false;
                foreach (var keyCode in KeysDown)
                {
                    if (!Input.CheckKeyPressed(keyCode))
                        continue;
                    anyKey = true;

                    ForInstances(i => i.PerformEvent(EventType.Keyboard, (int) keyCode));
                }
                
                // vk_any/vk_none
                ForInstances(i =>
                    i.PerformEvent(EventType.KeyPress,
                        anyKey ? (int) VirtualKeyCode.AnyKey : (int) VirtualKeyCode.NoKey));
            }

            // Process key press events
            if (KeysPressed.Count > 0)
            {
                while (KeysPressed.Count > 0)
                {
                    var keyCode = KeysPressed.Dequeue();
                    ForInstances(i => i.PerformEvent(EventType.KeyPress, (int) keyCode));
                }
                
                // vk_any
                ForInstances(i => i.PerformEvent(EventType.KeyPress, (int) VirtualKeyCode.AnyKey));
            }
            else
            {
                // vk_none
                ForInstances(i => i.PerformEvent(EventType.KeyPress, (int) VirtualKeyCode.NoKey));
            }
            
            // Process key release events
            {
                var released = new HashSet<VirtualKeyCode>();
                foreach (var key in KeysDown)
                {
                    if (!Input.CheckKeyPressed(key))
                    {
                        released.Add(key);
                        ForInstances(i => i.PerformEvent(EventType.KeyRelease, (int) key));
                    }
                }
                
                // vk_any/vk_none
                ForInstances(i =>
                    i.PerformEvent(EventType.KeyRelease,
                        released.Any() ? (int) VirtualKeyCode.AnyKey : (int) VirtualKeyCode.NoKey));
                
                // update KeysDown
                KeysDown.ExceptWith(released);
            }
            
            // Process step events
            ForInstances(i => i.PerformEvent(EventType.Step, (int) StepKind.Normal));

            // Set instances to their new positions
            ForInstances(i =>
            {
                i.XPrevious = i.X;
                i.YPrevious = i.Y;
                
                // friction first
                i.Speed = i.Friction > 0 && Math.Abs(i.Speed) < i.Friction
                    ? 0
                    : i.Speed - i.Friction * Math.Sign(i.Speed);
                
                // then gravity
                i.AddSpeedVector(
                    i.Gravity * Math.Cos(i.GravityDirection * Math.PI / 180),
                    -i.Gravity * Math.Sin(i.GravityDirection * Math.PI / 180));
                
                // move the object
                i.X += i.HSpeed;
                i.Y += i.VSpeed;
            });
            
            // Process collision events
            // TODO: Reorder and refine based on actual logic
            //    (if instances are created during the loop, are they checked for collisions?)
            {
                var collisionTree = Library.CollisionFunctions.GenerateCollisionTree(PresortedInstances);
                
                ForInstances(i =>
                {
                    Library.CollisionFunctions.RemoveFromRTree(i, collisionTree);
                    
                    if (i.Sprite == null) return;

                    var overlapping = Library.CollisionFunctions
                        .InstancesInBoundingBox(i, collisionTree)
                        .Select(o => (GameInstance) Instances[o]);
                    
                    var collisions = Library.CollisionFunctions.GetCollisions(i, overlapping, false);
                    
                    foreach (var other in collisions)
                    {
                        // Generate collision events in both instances
                        OtherInstance = other;
                        i.PerformEvent(EventType.Collision, other.ObjectIndex);
                        OtherInstance = i;
                        other.PerformEvent(EventType.Collision, i.ObjectIndex);
                        OtherInstance = null;
                    }
                });
            }
            
            // Process end step events
            ForInstances(i => i.PerformEvent(EventType.Step, (int) StepKind.EndStep));
            
            // Draw the screen and process draw events
            DrawScreen();
        }

        public void DrawScreen()
        {
            Graphics.Clear(CurrentRoom.BackgroundColor);

            if (Enable3dMode)
            {
                Library.D3dFunctions.SetProjectionPerspective(0, 0, CurrentRoom.Width, CurrentRoom.Height, 0);
            }
            else
            {
                Graphics.SetOrthographicProjection(0, 0, CurrentRoom.Width, CurrentRoom.Height, 0);
            }

            // Re-sort all the instances by depth now.
            PresortedInstances = GetRoomInstances();

            // Process draw events
            ForInstances(i =>
            {
                if (i.ImageSingle < 0)
                {
                    i.ImageIndex += i.ImageSpeed;
                }
                
                Graphics.DrawDepth3d = i.Depth;
                if (i.AssignedObject.IsEventRegistered(EventType.Draw))
                {
                    i.PerformEvent(EventType.Draw);
                }
                else
                {
                    i.DrawSprite();
                }
            });
        }
    }
}