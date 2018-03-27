namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadGameInformation()
        {
            var version = ReadInt();

            Project.Information.BackgroundColor = ReadInt();

            if (version >= 430 && version <= 620)
            {
                Project.Information.MimicMainForm = ReadBool();
            }

            if (version >= 600)
            {
                Project.Information.FormCaption = ReadString();
                Project.Information.X = ReadInt();
                Project.Information.Y = ReadInt();
                Project.Information.Width = ReadInt();
                Project.Information.Height = ReadInt();
                Project.Information.ShowBorderAndCaption = ReadBool();
                Project.Information.FormResizable = ReadBool();
                Project.Information.AlwaysOnTop = ReadBool();
                Project.Information.PauseGame = ReadBool();
            }

            Project.Information.Rtf = ReadString();
        }
    }
}
