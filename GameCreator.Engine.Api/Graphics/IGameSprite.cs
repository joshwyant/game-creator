using GameCreator.Resources.Api;

namespace GameCreator.Engine.Api
{
    public interface IGameSprite : INamedResource
    {
        ITexture[] Textures { get; }
        IImage[] SubImages { get; }
        int Width { get; }
        int Height { get; }
        int XOrigin { get; }
        int YOrigin { get; }
    }
}