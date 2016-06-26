using App.Contracts;
using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    partial class GmFileProjectReader
    {
        void readGameInformation()
        {
            int version = getInt();
            
            project.GameInformation = new GameInformation();

            var gameInfo = project.GameInformation;

            gameInfo.BackgroundColor = getInt();

            if (version >= 430 && version <= 620)
                gameInfo.MimicMainForm = getBool();

            if (version >= 600)
            {
                gameInfo.FormCaption = getString();
                gameInfo.X = getInt();
                gameInfo.Y = getInt();
                gameInfo.Width = getInt();
                gameInfo.Height = getInt();
                gameInfo.ShowBorderAndCaption = getBool();
                gameInfo.FormResizable = getBool();
                gameInfo.AlwaysOnTop = getBool();
                gameInfo.PauseGame = getBool();
            }

            gameInfo.Rtf = getString();
        }
    }
}
