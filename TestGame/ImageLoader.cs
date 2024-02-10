using System.IO;
using System.Linq;
using GameCreator.Api.Resources;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

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
                var pixels = new Rgba32[image.Width * image.Height];
                (image.Frames[0] as ImageFrame<Rgba32>).CopyPixelDataTo(pixels);

                var colors = pixels
                    .Select(pixel => (uint)(((pixel.A) << 24) | ((pixel.B) << 16) | ((pixel.G) << 8) | pixel.R))
                    .ToArray();
                return new LoadedImage(image.Width, image.Height, colors);
            }
        }
    }
}