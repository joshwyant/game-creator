using GameCreator.Engine.Api;

namespace GameCreator.Plugins.OpenTK
{
    internal class TextureInfo : ITexture
    {
        public readonly int Id;

        public TextureInfo(int id)
        {
            Id = id;
        }
    }
}