using System;
using GameCreator.Engine.Api;

namespace GameCreator.Engine
{
    public struct BoundingBox
    {
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }

        public BoundingBox(int l, int t, int r, int b)
        {
            Left = l;
            Top = t;
            Right = r;
            Bottom = b;
        }

        public static BoundingBox Intersection(ref BoundingBox bb1, ref BoundingBox bb2)
        {
            return new BoundingBox(Math.Max(bb1.Left, bb2.Left),
                Math.Max(bb1.Top, bb2.Top),
                Math.Min(bb1.Right, bb2.Right),
                Math.Min(bb1.Bottom, bb2.Bottom));
        }

        public static bool Overlap(ref BoundingBox bb1, ref BoundingBox bb2)
        {
            var i = Intersection(ref bb1, ref bb2);

            return i.Right >= i.Left && i.Bottom >= i.Top;
        }

        public static BoundingBox Detect(IImage[] images, int alphaTolerance = 0)
        {
            var leftMost = images[0].Width - 1;
            var topMost = images[0].Height - 1;
            var rightMost = 0;
            var bottomMost = 0;

            foreach (var image in images)
            {
                for (var i = 0; i < image.Width * image.Height; i++)
                {
                    var x = i % image.Width;
                    var y = i / image.Width;
    
                    if ((image.ImageData[i] & 0xFF000000) >> 24 > alphaTolerance)
                    {
                        if (x < leftMost) leftMost = x;
                        if (x > rightMost) rightMost = x;
                        if (y < topMost) topMost = y;
                        if (y > bottomMost) bottomMost = y;
                    }
                }
            }
            
            return new BoundingBox(leftMost, topMost, rightMost, bottomMost);
        }

        public static BoundingBox Detect(IImage image,
            int alphaTolerance = 0)
        {
            return Detect(new[] { image }, alphaTolerance);
        }
    }
}