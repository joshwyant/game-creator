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
        void readBackgrounds()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Repository.Backgrounds.NextIndex = i;

                if (getInt() != 0)
                {
                    var background = project.Repository.Backgrounds.Add();

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
