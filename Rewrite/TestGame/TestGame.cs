using System;
using System.IO;
using GameCreator.Engine;

namespace TestGame
{
    public class TestGame : GameContext
    {
        public TestGame(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio, 
            ITimerPlugin timer, IResourceContext resourceContext)
            : base(graphics, input, audio, timer, resourceContext)
        {
            graphics.Load += Graphics_Load;
            graphics.Draw += Graphics_Draw;
            
            graphics.SetWindowSize(800, 600);
            timer.TargetFps = 30;
        }

        public override int GameId => 54321;

        private ITexture tex;

        void Graphics_Load(object sender, EventArgs args)
        {
            var imageLoader = new ImageLoader();
            
            using (var fs = new FileStream("/Users/josh/Desktop/pacman.png",
                FileMode.Open))
            {
                tex = Graphics.LoadTexture(imageLoader.FromStream(fs));
            }
        }

        void Graphics_Draw(object sender, EventArgs args)
        {
            Graphics.Clear(100, 149, 237);
            
            Graphics.SetProjection(320f, 240f, -640f, 320f, 240f, 0f, 0f, -1f, 0f, 
                2f*(float)Math.Atan(0.5/(640.0/480.0)), 640f/480f, 1.0f, 32000f);
            
            Graphics.DrawSprite(tex, 320, 240, 0, 32, 32, 16, 16, 1f, 1f, 45, 255, 255, 255);
        }
    }
}