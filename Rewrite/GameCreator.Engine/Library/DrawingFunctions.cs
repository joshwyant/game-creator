namespace GameCreator.Engine.Library
{
    public class DrawingFunctions
    {
        public GameContext Context { get; }
        
        public DrawingFunctions(GameContext context)
        {
            Context = context;
        }

        public void ClearScreen(int color)
        {
            Context.Graphics.Clear(color);
        }

        void DrawSprite(GameSprite s, int subimg, double left, double top, double w, double h, double x, double y,
            double xscale, double yscale, double angle, int c1, int c2, int c3, int c4, double a)
        {
            Context.Graphics.DrawSprite(s, subimg, left, top, w, h, x, y, xscale, yscale, angle, c1, c2, c3, c4, a);
        }

        public void DrawSprite(GameSprite s, int subimage, double x, double y, double xscale, double yscale, 
            double angle, int color, double a)
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