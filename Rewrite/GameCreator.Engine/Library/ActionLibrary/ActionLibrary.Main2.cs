using System;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Main2

        public void SetAlarm(GameInstance self, int steps, int alarmNo, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void Sleep(int milliseconds, bool redraw)
        {
            throw new NotImplementedException();
        }

        public void SetTimeline(GameInstance self, GameTimeline timeline, int position)
        {
            throw new NotImplementedException();
        }

        public void SetTimeline(GameInstance self, GameTimeline timeline, int position, bool dontStartImmediately,
            bool loop)
        {
            throw new NotImplementedException();
        }

        public void SetTimelinePosition(GameInstance self, int position, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void SetTimelineSpeed(GameInstance self, double speed, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void StartTimeline(GameInstance self)
        {
            throw new NotImplementedException();
        }

        public void PauseTimeline(GameInstance self)
        {
            throw new NotImplementedException();
        }

        public void StopTimeline(GameInstance self)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public void ShowVideo(string filename, bool fullScreen, bool loop)
        {
            throw new NotImplementedException();
        }

        public void ShowSplashText(string filename)
        {
            throw new NotImplementedException();
        }

        public void ShowSplashImage(string filename)
        {
            throw new NotImplementedException();
        }

        public void ShowSplashWeb(string url, bool showInBrowser)
        {
            throw new NotImplementedException();
        }

        public void ShowSplashVideo(string filename, bool loop)
        {
            throw new NotImplementedException();
        }

        /// <param name="openIn">
        /// 0 = game window,
        /// 1 = normal window,
        /// 2 = full screen
        /// </param>
        public void SplashSettings(string caption, int openIn, bool dontShowCloseButton, bool dontCloseOnEscape,
            bool dontCloseOnClick)
        {
            throw new NotImplementedException();
        }

        public void RestartGame()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void SaveGame(string filename)
        {
            throw new NotImplementedException();
        }

        public void LoadGame(string filename)
        {
            throw new NotImplementedException();
        }

        public void ReplaceSprite(GameSprite sprite, string filename, int images)
        {
            throw new NotImplementedException();
        }

        public void ReplaceSound(GameSound sound, string filename)
        {
            throw new NotImplementedException();
        }

        public void ReplaceBackground(GameBackground background, string filename)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}