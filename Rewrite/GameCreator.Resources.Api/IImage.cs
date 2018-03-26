namespace GameCreator.Resources.Api
{
    public interface IImage
    {
        int Width { get; }
        int Height { get; }
        uint[] ImageData { get; }
    }
}