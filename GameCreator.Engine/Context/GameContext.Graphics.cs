using System;
using GameCreator.Engine.Api;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IGraphicsPlugin Graphics { get; }
        private bool _3dMode;
        public bool Enable3dMode => _3dMode;

        private void Graphics_Update(object sender, EventArgs eventArgs)
        {
            ProcessEvents();
        }

        private void Graphics_Load(object sender, EventArgs eventArgs)
        {
            LoadContent();
        }

        public void Start3dMode()
        {
            _3dMode = true;
            Graphics.DepthStencilEnable = true;
        }

        public void End3dMode()
        {
            _3dMode = false;
            Graphics.DepthStencilEnable = false;
        }
    }
}