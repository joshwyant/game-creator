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
        void readSprites()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                if (getInt() != 0)
                {
                    var sprite = project.Repository.Sprites.Add();

                    sprite.Name = getString();

                    version = getInt();

                    if (version >= 400 && version <= 542)
                    {
                        sprite.Width = getInt();
                        sprite.Height = getInt();
                        sprite.BoundingBoxLeft = getInt();
                        sprite.BoundingBoxRight = getInt();
                        sprite.BoundingBoxBottom = getInt();
                        sprite.BoundingBoxTop = getInt();
                        sprite.IsTransparent = getBool();

                        if (version == 542)
                        {
                            sprite.SmoothEdges = getBool();
                            sprite.PreloadTexture = getBool();
                        }

                        sprite.BoundingBoxMode = (BoundingBoxMode)getInt();
                        sprite.PreciseCollisionChecking = getBool();

                        if (version == 400)
                        {
                            sprite.UseVideoMemory = getBool();
                            sprite.LoadOnlyOnUse = getBool();
                        }
                    }

                    sprite.XOrigin = getInt();
                    sprite.YOrigin = getInt();

                    if (version >= 400 && version <= 542)
                    {
                        sprite.NextSubImage = getInt();
                        sprite.SubImages = new Dictionary<int, byte[]>();

                        for (var j = 0; j < sprite.NextSubImage; j++)
                        {
                            if (getInt() != 0)
                            {
                                sprite.SubImages.Add(j, getZipped());
                            }
                        }
                    }
                }
            }

            project.Repository.Sprites.NextIndex = count;
        }
    }
}
