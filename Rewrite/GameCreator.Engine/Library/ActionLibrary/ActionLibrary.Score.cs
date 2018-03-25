namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Score

        public void SetScore(double score, bool relative = false)
        {
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        public bool IfScore(double value, int operation)
        {
            return false;
        }

        public void DrawScore(GameInstance self, double x, double y, string caption, bool relative = false)
        {
        }

        public void ShowHighscore(GameBackground background, bool showBorder, int newColor, int otherColor,
            string fontString)
        {
        }

        public void ClearHighscore()
        {
        }

        public void SetLives(double lives, bool relative = false)
        {
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        public bool IfLives(double value, int operation)
        {
            return false;
        }

        public void DrawLives(GameInstance self, double x, double y, string caption, bool relative = false)
        {
        }

        public void DrawLifeImages(GameInstance self, double x, double y, GameSprite sprite, bool relative = false)
        {
        }

        public void SetHealth(double health, bool relative = false)
        {
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        public bool IfHealth(double value, int operation)
        {
            return false;
        }

        /// <param name="backColor">
        /// One of:
        /// none|black|gray|silver|white|maroon|green|olive|navy|purple|teal|red|lime|yellow|blue|fuchsia|aqua
        /// </param>
        /// <param name="barColor">
        /// One of:
        /// green to red|white to black|black|gray|silver|white|maroon|green|olive|navy|purple|teal|red|lime|yellow|blue|fuchsia|aqua
        /// </param>
        public void DrawHealth(GameInstance self, double x1, double y1, double x2, double y2, int backColor,
            int barColor, bool relative = false)
        {
        }

        public void SetCaption(bool showScore, string scoreCaption, bool showLives, string livesCaption,
            bool showHealth, string healthCaption)
        {
        }

        #endregion
    }
}