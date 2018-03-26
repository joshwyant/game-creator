namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readBackgrounds()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Backgrounds.NextIndex = i;

                if (getInt() != 0)
                {
                    var background = project.Backgrounds.Create();

                    background.Name = getString();

                    version = getInt();

                    if (version >= 400 && version <= 543)
                    {
                        background.Width = getInt();
                        background.Height = getInt();
                        background.IsTransparent = getInt();

                        if (version == 400)
                        {
                            background.UseVideoMemory = getBool();
                            background.LoadOnlyOnUse = getBool();
                        }

                        if (version == 543)
                        {
                            background.SmoothEdges = getBool();
                            background.PreloadTexture = getBool();
                        }

                        if (version >= 543)
                        {
                            background.UseAsTileset = getBool();
                            background.TileWidth = getInt();
                            background.TileHeight = getInt();
                            background.HorizontalOffset = getInt();
                            background.VerticalOffset = getInt();
                            background.HorizontalSeparation = getInt();
                            background.VerticalSeparation = getInt();
                        }

                        if (getBool())
                        {
                            if (getInt() != -1)
                            {
                                background.Data = getZipped();
                            }
                        }
                    }
                }
            }
        }
    }
}
