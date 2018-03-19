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

        void DrawSprite(GameSprite s, int subimg, float left, float top, float w, float h, float x, float y,
            float xscale, float yscale, float angle, uint c1, uint c2, uint c3, uint c4, float a)
        {
            Context.Graphics.DrawSprite(s, subimg, left, top, w, h, x, y, xscale, yscale, angle, c1, c2, c3, c4, a);
        }

        public void DrawSprite(GameSprite s, int subimage, float x, float y, float xscale, float yscale, 
            float angle, uint color, float a)
        {
            Context.Graphics.DrawSprite(s, subimage, 0, 0, s.Width, s.Height, x, y, xscale, yscale, angle, color, 
                color, color, color, a);
        }

        public void EnableDepthStencil(bool enable)
        {
            Context.Graphics.DepthStencilEnable = enable;
        }
    }
}