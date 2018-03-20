namespace GameCreator.Engine.Api
{
    public interface IImage
    {
        int Width { get; }
        int Height { get; }
        uint[] ImageData { get; }
    }
}