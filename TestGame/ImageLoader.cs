using System.IO;
using System.Linq;
using GameCreator.Resources.Api;
using SixLabors.ImageSharp.Advanced;
using Image = SixLabors.ImageSharp.Image;

namespace TestGame
{
    public class ImageLoader
    {
        private class LoadedImage : IImage
        {
            public int Width { get; }
            public int Height { get; }
            public uint[] ImageData { get; }

            public LoadedImage(int width, int height, uint[] imageData)
            {
                Width = width;
                Height = height;
                ImageData = imageData;
            }
        }

        public IImage[] LoadImages(params string[] fileNames)
        {
            return fileNames.Select(fileName =>
            {
                using (var fs = File.Open(fileName, FileMode.Open))
                {
                    return FromStream(fs);
                }
            }).ToArray();
        }

        public unsafe IImage FromStream(Stream s)
        {
            using (var image = Image.Load(s))
            {
                var pixels = new uint[image.Width * image.Height];

                fixed (void* data = &image.Frames[0].DangerousGetPinnableReferenceToPixelBuffer())
                {
                    for (var i = 0; i < pixels.Length; i++)
                    {
                        pixels[i] = ((uint*) data)[i];
                    }
                }

                return new LoadedImage(image.Width, image.Height, pixels);
            }
        }
    }
}