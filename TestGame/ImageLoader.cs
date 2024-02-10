using System.IO;
using System.Linq;
using GameCreator.Resources.Api;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
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
            using (var image = SixLabors.ImageSharp.Image.Load(s))
            {
                var pixels = new Rgba32[image.Width * image.Height];
                (image.Frames[0] as ImageFrame<Rgba32>).CopyPixelDataTo(pixels);

                // //fixed (uint* data = &image.Frames[0].DangerousGetPinnableReferenceToPixelBuffer())
                // {
                //     //&image.Frames[0].CopyPixelsTo(data);
                //     for (var i = 0; i < pixels.Length; i++)
                //     {
                //         var pixel = pixelSpan[i];
                //         // Pack the RGBA channels into a single uint
                //         pixels[i] = (uint)((pixel.R << 24) | (pixel.G << 16) | (pixel.B << 8) | pixel.A);
                //     }
                // }

                var bytes = pixels
                    .Select(pixel => (uint)(((pixel.A) << 24) | ((pixel.B) << 16) | ((pixel.G) << 8) | pixel.R))
                    .ToArray();
                return new LoadedImage(image.Width, image.Height, bytes);
            }
        }
    }
}