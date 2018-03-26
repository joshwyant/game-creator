using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readSprites()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Sprites.NextIndex = i;

                if (getInt() != 0)
                {
                    var sprite = project.Sprites.Create();

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

                        sprite.BoundingBoxFunction = (BoundingBoxFunction)getInt();
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
                        var subimageCount = getInt();
                        sprite.SubImages = new List<byte[]>();

                        for (var j = 0; j < subimageCount; j++)
                        {
                            if (getInt() != 0)
                            {
                                sprite.SubImages.Add(getZipped());
                            }
                        }
                    }
                }
            }
        }
    }
}
