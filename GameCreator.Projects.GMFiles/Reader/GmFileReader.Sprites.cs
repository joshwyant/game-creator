using System.Collections.Generic;
using GameCreator.Api.Resources;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadSprites()
        {
            var spritesVersion = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Sprites.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var sprite = Project.Sprites.Create();

                    if (spritesVersion >= 800)
                    {
                        sprite.LastModified = ReadDate();
                    }

                    sprite.Name = ReadString();

                    var version = sprite.Version = ReadInt();

                    if (version >= 400 && version <= 542)
                    {
                        sprite.Width = ReadInt();
                        sprite.Height = ReadInt();
                        sprite.BoundingBoxLeft = ReadInt();
                        sprite.BoundingBoxRight = ReadInt();
                        sprite.BoundingBoxBottom = ReadInt();
                        sprite.BoundingBoxTop = ReadInt();
                        sprite.IsTransparent = ReadBool();

                        if (version == 542)
                        {
                            sprite.SmoothEdges = ReadBool();
                            sprite.PreloadTexture = ReadBool();
                        }

                        sprite.BoundingBoxFunction = (BoundingBoxFunction)ReadInt();
                        sprite.PreciseCollisionChecking = ReadBool();

                        if (version == 400)
                        {
                            sprite.UseVideoMemory = ReadBool();
                            sprite.LoadOnlyOnUse = ReadBool();
                        }
                    }

                    sprite.XOrigin = ReadInt();
                    sprite.YOrigin = ReadInt();

                    if (version >= 400 && version <= 542)
                    {
                        var subimageCount = ReadInt();
                        sprite.SubImages = new List<SubImage>();

                        for (var j = 0; j < subimageCount; j++)
                        {
                            if (ReadInt() != 0)
                            {
                                sprite.SubImages.Add(new SubImage
                                {
                                    Version = version,
                                    Data = ReadZipped()
                                });
                            }
                        }
                    }
                    else if (version >= 800)
                    {
                        var subimageCount = ReadInt();
                        sprite.SubImages = new List<SubImage>();

                        for (var j = 0; j < subimageCount; j++)
                        {
                            version = ReadInt();
                            var width = ReadInt();
                            var height = ReadInt();
                            if (width != 0 && height != 0)
                            {
                                sprite.SubImages.Add(new SubImage
                                {
                                    Version = version,
                                    IsRawFormat = true,
                                    Width = width,
                                    Height = height,
                                    Data = ReadZipped()
                                });
                            }
                        }

                        sprite.Shape = (CollisionMaskFunction) ReadInt();
                        sprite.AlphaTolerance = ReadInt();
                        sprite.SeparateCollisionMasks = ReadBool();
                        sprite.BoundingBoxFunction = (BoundingBoxFunction) ReadInt();
                        sprite.BoundingBoxLeft = ReadInt();
                        sprite.BoundingBoxRight = ReadInt();
                        sprite.BoundingBoxBottom = ReadInt();
                        sprite.BoundingBoxTop = ReadInt();
                    }
                }
            }
        }
    }
}
