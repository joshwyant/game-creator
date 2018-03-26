namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readGameInformation()
        {
            var version = getInt();

            project.Information.BackgroundColor = getInt();

            if (version >= 430 && version <= 620)
                project.Information.MimicMainForm = getBool();

            if (version >= 600)
            {
                project.Information.FormCaption = getString();
                project.Information.X = getInt();
                project.Information.Y = getInt();
                project.Information.Width = getInt();
                project.Information.Height = getInt();
                project.Information.ShowBorderAndCaption = getBool();
                project.Information.FormResizable = getBool();
                project.Information.AlwaysOnTop = getBool();
                project.Information.PauseGame = getBool();
            }

            project.Information.Rtf = getString();
        }
    }
}
