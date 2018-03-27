namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadBackgrounds()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Backgrounds.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var background = Project.Backgrounds.Create();

                    background.Name = ReadString();

                    version = ReadInt();

                    if (version >= 400 && version <= 543)
                    {
                        background.Width = ReadInt();
                        background.Height = ReadInt();
                        background.IsTransparent = ReadInt();

                        if (version == 400)
                        {
                            background.UseVideoMemory = ReadBool();
                            background.LoadOnlyOnUse = ReadBool();
                        }

                        if (version == 543)
                        {
                            background.SmoothEdges = ReadBool();
                            background.PreloadTexture = ReadBool();
                        }

                        if (version >= 543)
                        {
                            background.UseAsTileset = ReadBool();
                            background.TileWidth = ReadInt();
                            background.TileHeight = ReadInt();
                            background.HorizontalOffset = ReadInt();
                            background.VerticalOffset = ReadInt();
                            background.HorizontalSeparation = ReadInt();
                            background.VerticalSeparation = ReadInt();
                        }

                        if (ReadBool())
                        {
                            if (ReadInt() != -1)
                            {
                                background.Data = ReadZipped();
                            }
                        }
                    }
                }
            }
        }
    }
}
