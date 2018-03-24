using System;
using System.Collections.Generic;
using System.Drawing;
using GameCreator.Engine;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class GameCreatorOpenTKGameWindow : GameWindow
    {
        private readonly double _scale;
        
        public GameCreatorOpenTKGameWindow() 
            : base(640, 480) // Hack
        {
            // Workaround for DPI issue https://github.com/opentk/opentk/issues/47
            // This would be cleaner if we could get the width/height from a room in IResourceContext
            _scale = (double)Width / 640; 
            WindowBorder = WindowBorder.Fixed;
        }

        public void SetWindowSize(int w, int h)
        {
            ClientSize = new Size((int)(w * _scale), (int)(h * _scale));
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            
            GameCreatorLoad?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> GameCreatorLoad;
        public event EventHandler<EventArgs> GameCreatorDraw;

        public double SleepTime = 0.0;
        
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            SleepTime = Math.Max(0.0, SleepTime - e.Time);

            if (SleepTime == 0.0)
            {
                GameCreatorDraw?.Invoke(this, EventArgs.Empty);
                SwapBuffers();
            }
        }

        readonly List<int> _loadedTextures = new List<int>();
        public int GenTexture()
        {
            var texId = GL.GenTexture();
            
            _loadedTextures.Add(texId);
            
            return texId;
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.DeleteTextures(_loadedTextures.Count, _loadedTextures.ToArray());
        }
    }
}