using GameCreator.Engine.Api;
using Microsoft.Xna.Framework.Graphics;

namespace GameCreator.Plugins.MonoGame
{
    internal class TextureWrapper : Texture2D, ITexture
    {
        public TextureWrapper(GraphicsDevice device, IImage image) 
            : base(device, image.Width, image.Height, false, SurfaceFormat.Color)
        {
            SetData(image.ImageData);
        }
    }
}