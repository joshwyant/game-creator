namespace GameCreator.Engine
{
    public class GameSprite : IIndexedResource
    {
        public IGameContext Context { get; }
        public int Id { get; set; } = -1;
        public ITexture[] Textures { get; internal set; }
        public IImage[] SubImages { get; }
        public int Width { get; }
        public int Height { get; }
        public int XOrigin { get; }
        public int YOrigin { get; }

        public GameSprite(IGameContext context, int w, int h, int xorigin, int yorigin, IImage[] subImages)
        {
            Context = context;
            Width = w;
            Height = h;
            XOrigin = xorigin;
            YOrigin = yorigin;
            SubImages = subImages;
        }
    }
}