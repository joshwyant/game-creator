using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using GameCreator.Runtime.Interpreter;
using GameCreator.Runtime.Library;

namespace GameCreator.Runtime
{
    class RuntimeWindow : GameWindow
    {
        Room current;
        public RuntimeWindow(Room r)
            : base(640, 480, GraphicsMode.Default, string.Empty)
        {
            current = r;
        }

        Queue<byte> keysdown = new Queue<byte>();
        List<byte> keyspressed = new List<byte>();

        void Keyboard_KeyDown(object sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (KeyCodes.GetMap(e.Key) == VirtualKeyCode.NoKey)
                return; // If there is no corresponding key mapping, we can't do anything about it.
            keysdown.Enqueue((byte)e.Key);
            keyspressed.Add((byte)e.Key);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            foreach (IndexedResource r in Sprite.Manager.Resources.Values)
            {
                Sprite s = r as Sprite;
                for (int i = 0; i < s.subImagesCount; i++)
                {
                    GL.GenTextures(1, out s.Textures[i]);
                    GL.BindTexture(TextureTarget.Texture2D, s.Textures[i]);
                    System.Drawing.Imaging.BitmapData bd = s.SubImages[i].LockBits(new Rectangle(0, 0, s.SubImages[i].Width, s.SubImages[i].Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bd.Width, bd.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, bd.Scan0);
                    s.SubImages[i].UnlockBits(bd);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                }
            }
            Keyboard.KeyDown += new EventHandler<OpenTK.Input.KeyboardKeyEventArgs>(Keyboard_KeyDown);
            current.Init();
            OnRenderFrame(new FrameEventArgs());
        }
        protected override void OnUnload(EventArgs e)
        {
            foreach (int ind in Sprite.Manager.Resources.Keys)
            {
                Sprite s = Sprite.Manager.Resources[ind] as Sprite;
                for (int i = 0; i < s.subImagesCount; i++)
                    GL.DeleteTextures(1, ref s.Textures[i]);
            }
        }
        class InstanceDepthComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int result = Env.Instances[y].depth.value.CompareTo(Env.Instances[x].depth.value);
                return result == 0 ? x.CompareTo(y) : result;
            }
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(0f, 0f, 0.5f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0.0, 640.0, 480.0, 0.0, 0.0, 4.0);
            // Sort all instances by depth.
            // This is the place this happens in GM. However, if any instances are created afterward, they are not sorted.
            Env.InstanceIds.Sort(new InstanceDepthComparer());
            // Loop through sorted instances
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                if (env.Destroyed) continue; // Don't bother.
                Object o = Object.Manager.Resources[env.object_index.value] as Object;
                if (o.EventDefined(EventType.Draw, 0))
                {
                    o.PerformEvent(env, EventType.Draw, 0);
                }
                else
                {
                    if (!Sprite.Manager.Resources.ContainsKey(env.sprite_index.value)) continue;
                    Sprite s = Sprite.Manager.Resources[env.sprite_index.value] as Sprite;
                    int subimage = (int)Math.Floor(env.image_index.value) % s.SubImages.Count();
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, s.Textures[subimage]);
                    GL.Begin(BeginMode.Quads);
                    double width = (double)s.SubImages[subimage].Width * env.image_xscale.value;
                    double height = (double)s.SubImages[subimage].Height * env.image_yscale.value;
                    GL.TexCoord2(0.0, 0.0); GL.Vertex2(env.x.value, env.y.value);
                    GL.TexCoord2(1.0, 0.0); GL.Vertex2(env.x.value + width, env.y.value);
                    GL.TexCoord2(1.0, 1.0); GL.Vertex2(env.x.value + width, env.y.value + height);
                    GL.TexCoord2(0.0, 1.0); GL.Vertex2(env.x.value, env.y.value + height);
                    GL.End();
                }
            }
            SwapBuffers();
            drawn = true;
        }
        bool drawn = false;
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            // don't update until the screen is drawn
            if (!drawn)
                return;
            drawn = false;
            // Begin step
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.Step, (int)StepEventNumber.BeginStep);
            }
            // Alarm 0-12
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                if (env.Destroyed) continue; // don't bother.
                Object o = Object.Manager.Resources[env.object_index.value] as Object;
                for (int j = 0; j < 12; j++)
                {
                    if (o.EventDefined(EventType.Alarm, i))
                    {
                        if (env.alarm[j] >= 0 && --env.alarm[j] == 0)
                            o.PerformEvent(env, EventType.Alarm, j);
                    }
                }
            }
            bool found = false;
            // Keyboard events
            foreach (byte key in keyspressed)
            {
                if (!Keyboard[(OpenTK.Input.Key)key])
                    continue;
                found = true;
                for (int i = 0; i < Env.InstanceIds.Count; i++)
                {
                    Instance env = Env.Instances[Env.InstanceIds[i]];
                    (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.Keyboard, (int)KeyCodes.GetMap((OpenTK.Input.Key)key));
                }
            }
            // vk_any/vk_none
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.Keyboard, (int)(found ? VirtualKeyCode.AnyKey : VirtualKeyCode.NoKey));
            }
            found = keysdown.Count != 0;
            // Key press events
            while (keysdown.Count != 0)
            {
                int key = keysdown.Dequeue();
                for (int i = 0; i < Env.InstanceIds.Count; i++)
                {
                    Instance env = Env.Instances[Env.InstanceIds[i]];
                    (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.KeyPress, (int)KeyCodes.GetMap((OpenTK.Input.Key)key));
                }
            }
            // vk_any/vk_none
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.KeyPress, (int)(found ? VirtualKeyCode.AnyKey : VirtualKeyCode.NoKey));
            }
            // Key release events
            found = false;
            int released = 0;
            for (int i = 0; i < keyspressed.Count; i++)
            {
                byte key = keyspressed[i];
                keyspressed[i - released] = key;
                if (!Keyboard[(OpenTK.Input.Key)key])
                {
                    found = true;
                    released++;
                    for (int j = 0; j < Env.InstanceIds.Count; j++)
                    {
                        Instance env = Env.Instances[Env.InstanceIds[j]];
                        (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.KeyRelease, (int)KeyCodes.GetMap((OpenTK.Input.Key)key));
                    }
                }
            }
            if (released > 0)
                keyspressed.RemoveRange(keyspressed.Count - released, released);
            // vk_any/vk_none
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                (Object.Manager.Resources[env.object_index.value] as Object).PerformEvent(env, EventType.KeyRelease, (int)(found ? VirtualKeyCode.AnyKey : VirtualKeyCode.NoKey));
            }
            // Step
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                (Object.Manager.Resources[env.object_index.Value] as Object).PerformEvent(env, EventType.Step, (int)StepEventNumber.Normal);
            }
            // Set instances to their new positions
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                if (env.Destroyed) continue; // don't bother.
                env.xprevious.value = env.x.value;
                env.yprevious.value = env.y.value;
                // friction first
                env.speed.Value = env.friction.value > 0 && Math.Abs(env.speed.Value) <= env.friction.value ? 0.0 : env.speed.Value.Real - env.friction.value * Math.Sign(env.speed.Value.Real);
                // then gravity
                env.AddSpeedVector(
                    GMLFunctions.lengthdir_x(env.gravity.value, env.gravity_direction.value),
                    GMLFunctions.lengthdir_y(env.gravity.value, env.gravity_direction.value)
                    );
                // move the object
                env.x.value += env.hspeed.Value;
                env.y.value += env.vspeed.Value;
            }
            // End Step
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                (Object.Manager.Resources[env.object_index.Value] as Object).PerformEvent(env, EventType.Step, (int)StepEventNumber.EndStep);
            }
            /* After-step duty */
            // Purge destroyed instances, in O(N) time.
            // This is done by first compacting the array, then shortening it.
            // Also update image_index in this loop.
            int purged = 0; // the number of purged instances.
            for (int i = 0; i < Env.InstanceIds.Count; i++)
            {
                Instance env = Env.Instances[Env.InstanceIds[i]];
                if (env.Destroyed)
                {
                    purged++; // increment the number of purged instances
                    Env.Instances.Remove(Env.InstanceIds[i]); // remove the instance from the instance lookup dictionary
                    continue;
                }
                // if (image_single < 0) image_index += image_speed
                if (env.image_single.value < 0.0)
                    env.image_index.value += env.image_speed.value;
                if (purged != 0)
                    Env.InstanceIds[i - purged] = Env.InstanceIds[i]; // move the instance to compact the array
            }
            if (purged != 0)
                Env.InstanceIds.RemoveRange(Env.InstanceIds.Count - purged, purged); // Shorten the list
        }
    }
}
