using GameCreator.Api.Resources;

namespace GameCreator.Api.Engine
{
    public interface IGameSprite : IIndexedResource
    {
        int Id { get; set; }
        ITexture[] Textures { get; }
        IImage[] SubImages { get; }
        int Width { get; }
        int Height { get; }
        int XOrigin { get; }
        int YOrigin { get; }
    }
}