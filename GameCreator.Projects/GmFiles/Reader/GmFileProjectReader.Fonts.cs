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
        void readFonts()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Repository.Fonts.NextIndex = i;

                if (getInt() != 0)
                {
                    var font = project.Repository.Fonts.Add();

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
