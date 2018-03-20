using System;
using System.Collections;
using System.Linq;
using GameCreator.Engine.Api;

namespace GameCreator.Engine
{
    public class CollisionMask
    {
        public BitArray[] Mask { get; }
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }
        public CollisionMaskFunction CollisionMaskFunction { get; }
        private readonly Func<int, int, bool> _hitTestFunc;

        public CollisionMask(IImage[] images, BoundingBox bbox, int alphaTolerance)
        {
            _hitTestFunc = HitTestPrecise;
            CollisionMaskFunction = CollisionMaskFunction.Precise;
            
            Left = bbox.Left;
            Top = bbox.Top;
            Right = bbox.Right;
            Bottom = bbox.Bottom;
            
            var w = Right - Left + 1;
            var h = Bottom - Top + 1;

            Mask = Enumerable.Range(0, h)
                .Select(i => new BitArray(w))
                .ToArray();
            
            foreach (var image in images)
            {
                for (var i = 0; i < w * h; i++)
                {
                    var x = Left + i % w;
                    var y = Top + i / w;
                    var ptr = y * image.Width + x;

                    var alpha = (image.ImageData[ptr] & 0xFF000000) >> 24;

                    if (alpha > alphaTolerance)
                    {
                        Mask[y][x] = true;
                    }
                }
            }
        }

        public CollisionMask(IImage image, BoundingBox bbox, int alphaTolerance)
            : this(new[] { image }, bbox, alphaTolerance)
        {
        }
        
        public CollisionMask(CollisionMaskFunction collisionMaskFunction, BoundingBox bbox)
        {
            if (collisionMaskFunction == CollisionMaskFunction.Precise)
                throw new ArgumentOutOfRangeException(nameof(collisionMaskFunction));
            
            CollisionMaskFunction = collisionMaskFunction;

            switch (collisionMaskFunction)
            {
                case CollisionMaskFunction.Disk:
                    _hitTestFunc = HitTestDisk;
                    break;
                case CollisionMaskFunction.Diamond:
                    _hitTestFunc = HitTestDiamond;
                    break;
                case CollisionMaskFunction.Rectangle:
                    _hitTestFunc = HitTestRectangle;
                    break;
            }

            Left = bbox.Left;
            Right = bbox.Right;
            Top = bbox.Top;
            Bottom = bbox.Bottom;
        }

        public bool HitTest(int x, int y)
        {
            return _hitTestFunc(x, y);
        }
        
        private bool HitTestPrecise(int x, int y)
        {
            return x >= Left && y >= Top && x <= Right && y <= Bottom && Mask[y-Top][x-Left];
        }

        private bool HitTestDisk(int x, int y)
        {
            var halfw = (Right - Left + 1) * 0.5;
            var halfh = (Bottom - Top + 1) * 0.5;
            var centerx = Left + halfw;
            var centery = Top + halfh;
            var newx = (x - centerx) / halfw;
            var newy = (y - centery) / halfh;
            return newx * newx + newy * newy < 1f;
        }

        private bool HitTestDiamond(int x, int y)
        {
            var halfw = (Right - Left + 1) * 0.5;
            var halfh = (Bottom - Top + 1) * 0.5;
            var centerx = Left + halfw;
            var centery = Top + halfh;
            var newx = (x - centerx) / halfw;
            var newy = (y - centery) / halfh;
            return Math.Abs(newx+newy) < 1.0;
        }

        private bool HitTestRectangle(int x, int y)
        {
            return x >= Left && y >= Top && x <= Right && y <= Bottom;
        }
    }
}