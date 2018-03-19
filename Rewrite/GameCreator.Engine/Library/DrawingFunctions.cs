namespace GameCreator.Engine.Library
{
    public class DrawingFunctions
    {
        public GameContext Context { get; }
        
        public DrawingFunctions(GameContext context)
        {
            Context = context;
        }

        public void ClearScreen(byte r, byte g, byte b)
        {
            Context.Graphics.Clear(r, g, b);
        }

        public void DrawSprite(ITexture t, float x, float y, float z, float w, float h, float originx, float originy,
            float xscale, float yscale, float angle, int r, int g, int b, float a)
        {
            Context.Graphics.DrawSprite(t, x, y, z, w, h, originx, originy, xscale, yscale, angle, r, g, b, a);
        }

        public void EnableDepthStencil(bool enable)
        {
            Context.Graphics.DepthStencilEnable = enable;
        }
    }
}