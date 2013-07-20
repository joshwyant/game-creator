using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using GameCreator.Runtime.Library;
using GameCreator.Framework;

namespace GameCreator.Runtime.Game
{
    public class GameWindow : OpenTK.GameWindow
    {
        Room current;
        public GameWindow(Room r)
            : base(640, 480, GraphicsMode.Default, string.Empty)
        {
            current = r;
        }

        Queue<byte> keysdown = new Queue<byte>();
        List<byte> keyspressed = new List<byte>();
        static List<int> SortedInstanceIds;

        void Keyboard_KeyDown(object sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (KeyMapper.GetMap(e.Key) == VirtualKeyCode.NoKey)
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
            foreach (IndexedResource r in LibraryContext.Current.Resources.Sprites.Values)
            {
                Sprite s = r as Sprite;
                for (int i = 0; i < s.SubImagesCount; i++)
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

            Game.CallInitRoom(current);

            OnRenderFrame(new FrameEventArgs());
        }
        protected override void OnUnload(EventArgs e)
        {
            foreach (var s in Sprite.Manager.Values)
            {
                for (int i = 0; i < s.SubImagesCount; i++)
                    GL.DeleteTextures(1, ref s.Textures[i]);
            }
        }
        class InstanceDepthComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int result = Game.GetInstance(y).depth.CompareTo(Game.GetInstance(x).depth);
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
            SortedInstanceIds = ExecutionContext.Instances.Select(i => i.id).ToList();
            SortedInstanceIds.Sort(new InstanceDepthComparer());
            // Loop through sorted instances
            for (var i = 0; i < SortedInstanceIds.Count; i++)
            {
                var inst = Game.GetInstance(SortedInstanceIds[i]);
                if (inst.Destroyed) continue; // Don't bother.
                var o = Framework.Object.Manager[inst.object_index];
                if (o.EventDefined(EventType.Draw, 0))
                {
                    LibraryContext.Current.PerformEvent(inst, EventType.Draw, 0);
                }
                else
                {
                    if (!Sprite.Manager.Resources.ContainsKey(inst.sprite_index)) continue;
                    Sprite s = Sprite.Manager.Resources[inst.sprite_index] as Sprite;
                    int subimage = (int)Math.Floor(inst.image_index) % s.SubImages.Count();
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, s.Textures[subimage]);
                    GL.Begin(BeginMode.Quads);
                    double width = (double)s.SubImages[subimage].Width * inst.image_xscale;
                    double height = (double)s.SubImages[subimage].Height * inst.image_yscale;
                    GL.TexCoord2(0.0, 0.0); GL.Vertex2(inst.x, inst.y);
                    GL.TexCoord2(1.0, 0.0); GL.Vertex2(inst.x + width, inst.y);
                    GL.TexCoord2(1.0, 1.0); GL.Vertex2(inst.x + width, inst.y + height);
                    GL.TexCoord2(0.0, 1.0); GL.Vertex2(inst.x, inst.y + height);
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
            for (var i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                LibraryContext.Current.PerformEvent(env, EventType.Step, (int)StepEventNumber.BeginStep);
            }
            // Alarm 0-12
            for (var i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                if (env.Destroyed) continue; // don't bother.
                var o = Framework.Object.Manager[env.object_index];
                for (int j = 0; j < 12; j++)
                {
                    if (o.EventDefined(EventType.Alarm, i))
                    {
                        if (env.alarm[j] >= 0 && --env.alarm[j] == 0)
                            LibraryContext.Current.PerformEvent(env, EventType.Alarm, j);
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
                for (int i = 0; i < SortedInstanceIds.Count; i++)
                {
                    var env = Game.GetInstance(SortedInstanceIds[i]);
                    LibraryContext.Current.PerformEvent(env, EventType.Keyboard, (int)KeyMapper.GetMap((OpenTK.Input.Key)key));
                }
            }
            // vk_any/vk_none
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                LibraryContext.Current.PerformEvent(env, EventType.Keyboard, (int)(found ? VirtualKeyCode.AnyKey : VirtualKeyCode.NoKey));
            }
            found = keysdown.Count != 0;
            // Key press events
            while (keysdown.Count != 0)
            {
                int key = keysdown.Dequeue();
                for (int i = 0; i < SortedInstanceIds.Count; i++)
                {
                    var env = Game.GetInstance(SortedInstanceIds[i]);
                    LibraryContext.Current.PerformEvent(env, EventType.KeyPress, (int)KeyMapper.GetMap((OpenTK.Input.Key)key));
                }
            }
            // vk_any/vk_none
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                LibraryContext.Current.PerformEvent(env, EventType.KeyPress, (int)(found ? VirtualKeyCode.AnyKey : VirtualKeyCode.NoKey));
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
                    for (int j = 0; j < SortedInstanceIds.Count; j++)
                    {
                        var env = Game.GetInstance(SortedInstanceIds[j]);
                        LibraryContext.Current.PerformEvent(env, EventType.KeyRelease, (int)KeyMapper.GetMap((OpenTK.Input.Key)key));
                    }
                }
            }
            if (released > 0)
                keyspressed.RemoveRange(keyspressed.Count - released, released);
            // vk_any/vk_none
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                LibraryContext.Current.PerformEvent(env, EventType.KeyRelease, (int)(found ? VirtualKeyCode.AnyKey : VirtualKeyCode.NoKey));
            }
            // Step
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                LibraryContext.Current.PerformEvent(env, EventType.Step, (int)StepEventNumber.Normal);
            }
            // Set instances to their new positions
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                if (env.Destroyed) continue; // don't bother.
                env.xprevious = env.x;
                env.yprevious = env.y;
                // friction first
                env.speed = env.friction > 0 && Math.Abs(env.speed) <= env.friction ? 0.0 : env.speed - env.friction * Math.Sign(env.speed);
                // then gravity
                env.AddSpeedVector(
                    GmlFunctions.lengthdir_x(env.gravity, env.gravity_direction),
                    GmlFunctions.lengthdir_y(env.gravity, env.gravity_direction)
                    );
                // move the object
                env.x += env.hspeed;
                env.y += env.vspeed;
            }
            // End Step
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                LibraryContext.Current.PerformEvent(env, EventType.Step, (int)StepEventNumber.EndStep);
            }
            /* After-step duty */
            // Purge destroyed instances, in O(N) time.
            // This is done by first compacting the array, then shortening it.
            // Also update image_index in this loop.
            int purged = 0; // the number of purged instances.
            for (int i = 0; i < SortedInstanceIds.Count; i++)
            {
                var env = Game.GetInstance(SortedInstanceIds[i]);
                if (env.Destroyed)
                {
                    purged++; // increment the number of purged instances
                    SortedInstanceIds.Remove(SortedInstanceIds[i]); // remove the instance from the instance lookup dictionary
                    continue;
                }
                // if (image_single < 0) image_index += image_speed
                if (env.image_single < 0.0)
                    env.image_index += env.image_speed;
                if (purged != 0)
                    SortedInstanceIds[i - purged] = SortedInstanceIds[i]; // move the instance to compact the array
            }
            if (purged != 0)
                SortedInstanceIds.RemoveRange(SortedInstanceIds.Count - purged, purged); // Shorten the list
        }
    }
}
