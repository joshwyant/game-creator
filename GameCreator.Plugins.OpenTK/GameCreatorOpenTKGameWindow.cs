using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using static OpenTK.Graphics.OpenGL.GL;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class GameCreatorOpenTKGameWindow : GameWindow
    {
        private readonly double _scale;
        
        public GameCreatorOpenTKGameWindow() 
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = new Vector2i(640, 480) }) // Hack
        {
            // Workaround for DPI issue https://github.com/opentk/opentk/issues/47
            // This would be cleaner if we could get the width/height from a room in IResourceContext
            _scale = (double)ClientSize.X / 640; 
            WindowBorder = WindowBorder.Fixed;
            Load += GameCreatorOpenTKGameWindow_Load;
            Unload += GameCreatorOpenTKGameWindow_Unload;
        }

        public void SetWindowSize(int w, int h)
        {
            ClientSize = new Vector2i((int)(w * _scale), (int)(h * _scale));
        }

        void GameCreatorOpenTKGameWindow_Load()
        {
            Enable(EnableCap.Texture2D);
            Enable(EnableCap.Blend);
            BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            
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

        void GameCreatorOpenTKGameWindow_Unload()
        {
            DeleteTextures(_loadedTextures.Count, _loadedTextures.ToArray());
        }
    }
}