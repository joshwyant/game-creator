namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readFonts()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Fonts.NextIndex = i;

                if (getInt() != 0)
                {
                    var font = project.Fonts.Create();

                    font.Name = getString();

                    version = getInt();

                    font.FontName = getString();
                    font.Size = getInt();
                    font.IsBold = getBool();
                    font.IsItalic = getBool();
                    font.CharacterRangeBegin = getInt();
                    font.CharacterRangeEnd = getInt();
                }
            }
        }
    }
}
