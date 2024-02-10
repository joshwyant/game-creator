using System;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Api.Engine;
using GameCreator.Engine.Common;
using GameCreator.Api.Resources;

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
            void PerformEventForInstances(EventType eventType, int eventNumber = 0)
            {
                ForInstances(i => i.PerformEvent(eventType, eventNumber));
            }
            
            // Process begin step events
            ForInstances(i =>
            {
                i.XPrevious = i.X;
                i.YPrevious = i.Y;
                
                i.PerformEvent(EventType.Step, (int) StepKind.BeginStep);
            });

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

                    PerformEventForInstances(EventType.Keyboard, (int) keyCode);
                }
                
                // vk_any/vk_none
                PerformEventForInstances(EventType.KeyPress, 
                    anyKey ? (int) VirtualKeyCode.AnyKey : (int) VirtualKeyCode.NoKey);
            }

            // Process key press events
            if (KeysPressed.Count > 0)
            {
                while (KeysPressed.Count > 0)
                {
                    var keyCode = KeysPressed.Dequeue();
                    PerformEventForInstances(EventType.KeyPress, (int) keyCode);
                }
                
                // vk_any
                PerformEventForInstances(EventType.KeyPress, (int) VirtualKeyCode.AnyKey);
            }
            else
            {
                // vk_none
                PerformEventForInstances(EventType.KeyPress, (int) VirtualKeyCode.NoKey);
            }
            
            // Process key release events
            {
                var released = new HashSet<VirtualKeyCode>();
                foreach (var key in KeysDown)
                {
                    if (!Input.CheckKeyPressed(key))
                    {
                        released.Add(key);
                        PerformEventForInstances(EventType.KeyRelease, (int) key);
                    }
                }
                
                // vk_any/vk_none
                PerformEventForInstances(EventType.KeyRelease,
                        released.Any() ? (int) VirtualKeyCode.AnyKey : (int) VirtualKeyCode.NoKey);
                
                // update KeysDown
                KeysDown.ExceptWith(released);
            }
            
            // Process step events and set instances to their new positions
            ForInstances(i => i.FullStep());
            
            // Process collision events
            ProcessCollisionEvents();
            
            // Process end step events
            PerformEventForInstances(EventType.Step, (int) StepKind.EndStep);
            
            // Draw the screen and process draw events
            DrawScreen();
        }

        private void ProcessCollisionEvents()
        {
            var collisionTree = Library.Move.GenerateCollisionTree(PresortedInstances);

            ForInstances(i =>
            {
                Library.Move.RemoveFromRTree(i, collisionTree);

                if (i.Sprite == null) return;

                var overlapping = Library.Move
                    .InstancesInBoundingBox(i, collisionTree)
                    .Select(o => (GameInstance) Instances[o]);

                var collisions = Library.Move.GetCollisions(i, overlapping, false);

                foreach (var other in collisions)
                {
                    // Generate collision events in both instances
                    CollideInstances(i, other);
                    CollideInstances(other, i);
                    OtherInstance = null;
                }
            });

            void CollideInstances(GameInstance i, GameInstance other)
            {
                if (!i.AssignedObject.IsEventRegistered(other.AssignedObject)) return;

                if (other.Solid)
                {
                    i.X = i.XPrevious;
                    i.Y = i.YPrevious;
                }

                OtherInstance = other;
                i.PerformEvent(EventType.Collision, other.ObjectIndex);

                if (other.Solid)
                {
                    var destx = i.X + i.HSpeed; // Direction may have changed in collision event
                    var desty = i.Y + i.VSpeed;
                    if (Library.Move.PlaceFree(i, destx, desty, true))
                    {
                        i.X = destx;
                        i.Y = desty;
                    }
                }
            }
        }

        public void DrawScreen()
        {
            Graphics.Clear(CurrentRoom.BackgroundColor);

            if (Enable3dMode)
            {
                // Set the default perspective projection. 
                // Y-axis is flipped, and instances with more depth appear farther away.
                Library.D3d.SetProjectionPerspective(0, 0, CurrentRoom.Width, CurrentRoom.Height, 0);
            }
            else
            {
                // Set a normal, flat (2-dimensional) projection for the room.
                Graphics.SetOrthographicProjection(0, 0, CurrentRoom.Width, CurrentRoom.Height, 0);
            }

            // Re-sort all the instances by depth now.
            PresortedInstances = GetRoomInstances();

            // Process draw events
            ForInstances(i =>
            {
                // Compute the new subimage
                if (i.ImageSingle < 0)
                {
                    var prevSubImage = i.ComputeSubimage();
                    i.ImageIndex += i.ImageSpeed;
                    
                    // Perform AnimationEnd event
                    i.PerformEventIf(EventType.Other, (int) OtherEventKind.AnimationEnd,
                        () => prevSubImage != 0 && i.ComputeSubimage() == 0);
                }
                
                // Used for simple drawing functions in 3D
                Graphics.DrawDepth3d = i.Depth;
                
                // Perform the draw event if there are actions present,
                // or else draw the sprite.
                if (!i.PerformEventIfRegistered(EventType.Draw))
                {
                    i.DrawSprite();
                }
            });
        }
    }
}