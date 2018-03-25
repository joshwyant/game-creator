namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Draw

        public void DrawSprite(GameInstance self, GameSprite sprite, double x, double y, int subimage,
            bool relative = false)
        {
        }

        public void DrawBackground(GameInstance self, GameBackground background, double x, double y, bool tiled,
            bool relative = false)
        {
        }

        public void DrawText(GameInstance self, string text, double x, double y, bool relative = false)
        {
        }

        public void DrawTextScaled(GameInstance self, string text, double x, double y, double xscale, double yscale,
            double angle, bool relative = false)
        {
        }

        public void DrawRectangle(GameInstance self, double x1, double y1, double x2, double y2, bool outlineOnly,
            bool relative = false)
        {
        }

        public void DrawGradientHorizontal(GameInstance self, double x1, double y1, double x2, double y2, int color1,
            int color2, bool relative = false)
        {
        }

        public void DrawGradientVertical(GameInstance self, double x1, double y1, double x2, double y2, int color1,
            int color2, bool relative = false)
        {
        }

        public void DrawEllipse(GameInstance self, double x1, double y1, double x2, double y2, bool outlineOnly,
            bool relative = false)
        {
        }

        public void DrawEllipseGradient(GameInstance self, double x1, double y1, double x2, double y2, int color1,
            int color2, bool relative = false)
        {
        }

        public void DrawLine(GameInstance self, double x1, double y1, double x2, double y2, bool relative = false)
        {
        }

        public void DrawArrow(GameInstance self, double x1, double y1, double x2, double y2, double tipSize,
            bool relative = false)
        {
        }

        public void SetColor(int color)
        {
        }

        /// <param name="align">
        /// 0 = left,
        /// 1 = center,
        /// 2 = right
        /// </param>
        public void SetFont(GameFont font, int align)
        {
        }

        /// <param name="action">
        /// 0 = switch,
        /// 1 = window,
        /// 2 = fullscreen
        /// </param>
        public void SetFullscreen(int action)
        {
        }

        public void Snapshot(string filename)
        {
        }

        /// <param name="type">
        /// One of:
        /// explosion|ring|ellipse|firework|smoke|smoke up|star|spark|flare|cloud|rain|snow
        /// </param>
        /// <param name="size">
        /// One of:
        /// small|medium|large
        /// </param>
        /// <param name="location">
        /// One of:
        /// below objects|above objects
        /// </param>
        public void CreateEffect(GameInstance self, int type, double x, double y, int size, int color, int location,
            bool relative = false)
        {
        }

        #endregion
    }
}