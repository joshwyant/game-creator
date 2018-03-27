namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadFonts()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Fonts.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var font = Project.Fonts.Create();

                    font.Name = ReadString();

                    version = ReadInt();

                    font.FontName = ReadString();
                    font.Size = ReadInt();
                    font.IsBold = ReadBool();
                    font.IsItalic = ReadBool();
                    font.CharacterRangeBegin = ReadInt();
                    font.CharacterRangeEnd = ReadInt();
                }
            }
        }
    }
}
