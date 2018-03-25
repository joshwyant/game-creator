namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Main2

        public void SetAlarm(GameInstance self, int steps, int alarmNo, bool relative = false)
        {
        }

        public void Sleep(int milliseconds, bool redraw)
        {
        }

        public void SetTimeline(GameInstance self, GameTimeline timeline, int position)
        {
        }

        public void SetTimeline(GameInstance self, GameTimeline timeline, int position, bool dontStartImmediately,
            bool loop)
        {
        }

        public void SetTimelinePosition(GameInstance self, int position, bool relative = false)
        {
        }

        public void SetTimelineSpeed(GameInstance self, double speed, bool relative = false)
        {
        }

        public void StartTimeline(GameInstance self)
        {
        }

        public void PauseTimeline(GameInstance self)
        {
        }

        public void StopTimeline(GameInstance self)
        {
        }

        public void ShowMessage(string message)
        {
        }

        public void ShowInfo()
        {
        }

        public void ShowVideo(string filename, bool fullScreen, bool loop)
        {
        }

        public void ShowSplashText(string filename)
        {
        }

        public void ShowSplashImage(string filename)
        {
        }

        public void ShowSplashWeb(string url, bool showInBrowser)
        {
        }

        public void ShowSplashVideo(string filename, bool loop)
        {
        }

        /// <param name="openIn">
        /// 0 = game window,
        /// 1 = normal window,
        /// 2 = full screen
        /// </param>
        public void SplashSettings(string caption, int openIn, bool dontShowCloseButton, bool dontCloseOnEscape,
            bool dontCloseOnClick)
        {
        }

        public void RestartGame()
        {
        }

        public void EndGame()
        {
        }

        public void SaveGame(string filename)
        {
        }

        public void LoadGame(string filename)
        {
        }

        public void ReplaceSprite(GameSprite sprite, string filename, int images)
        {
        }

        public void ReplaceSound(GameSound sound, string filename)
        {
        }

        public void ReplaceBackground(GameBackground background, string filename)
        {
        }

        #endregion
    }
}