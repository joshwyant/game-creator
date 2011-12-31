using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace GameCreator.IDE
{
    enum FramePlacement
    {
        TopLeft,
        Center,
        Stretch
    }

    enum FrameSizing
    {
        OriginalSize,
        NewSize,
        MaximumSize
    }

    enum BoundingBoxMode
    {
        Automatic,
        FullImage,
        Manual
    }

    enum BoundingBoxShape
    {
        Precise,
        Disk,
        Diamond,
        Rectangle
    }

    struct BoundingBox
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public BoundingBox(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
        public void Normalize()
        {
            int t;
            if (Left > Right)
            {
                t = Left;
                Left = Right;
                Right = t;
            }
            if (Top > Bottom)
            {
                t = Top;
                Top = Bottom;
                Bottom = t;
            }
        }
    }

    delegate void SizingCallback(out FramePlacement placement, out FrameSizing sizing);

    class FrameBasedAnimation : IDisposable
    {
        int bbleft, bbtop, bbright, bbbottom;
        BoundingBoxMode bbmode = BoundingBoxMode.Automatic;
        BoundingBoxShape bbshape = BoundingBoxShape.Precise;
        public int BoundingBoxLeft { get { return bbmode == BoundingBoxMode.FullImage ? 0 : bbleft; } set { bbleft = value; } }
        public int BoundingBoxTop { get { return bbmode == BoundingBoxMode.FullImage ? 0 : bbtop; } set { bbtop = value; } }
        public int BoundingBoxRight { get { return bbmode == BoundingBoxMode.FullImage ? width - 1 : bbright; } set { bbright = value; } }
        public int BoundingBoxBottom { get { return bbmode == BoundingBoxMode.FullImage ? height - 1 : bbbottom; } set { bbbottom = value; } }
        public BoundingBoxMode BoundingBoxMode { get { return bbmode; } set { bbmode = value; } }
        bool separatemasks = true;
        public bool SeparateMasks { get { return separatemasks; } set { separatemasks = value; } }
        bool disposed = false;
        public FrameBasedAnimation() { }
        List<BoundingBox> bboxes = new List<BoundingBox>();
        int tol;
        public int AlphaTolerance { get { return tol; } set { tol = value; } }
        public FrameBasedAnimation(FrameBasedAnimation original)
        {
            foreach (Bitmap bmp in original.frames)
                frames.Add(new Bitmap(bmp));
            bboxes = new List<BoundingBox>(original.bboxes);
            width = original.Width;
            height = original.Height;
            bbmode = original.bbmode;
            // TODO CRITICAL: copy the other variables
        }
        public FrameBasedAnimation(Bitmap original, bool opacify, bool transparent, bool smooth)
        {
            frames.AddRange(CreateFrames(original, opacify, transparent, smooth, null));
            for (int i = 0; i < frames.Count; i++)
                ComputeBoundingBox(i);
        }
        // TODO: fix up to load true color gif images
        public FrameBasedAnimation(string filename, bool opacify, bool transparent, bool smooth) : this(new Bitmap(filename), opacify, transparent, smooth) { }
        public void AddImage(Bitmap bmp, bool opacify, bool transparent, bool smooth, SizingCallback resolve)
        {
            EnsureUndisposed();
            int i = frames.Count;
            frames.AddRange(CreateFrames(bmp, opacify, transparent, smooth, resolve));
            for (; i < frames.Count; i++)
                ComputeBoundingBox(i);
        }
        // TODO: make a class that only resolves the sizing once, also use in InsertImages
        public void AddImages(IEnumerable<Bitmap> bmp, bool opacify, bool transparent, bool smooth, SizingCallback resolve)
        {
            EnsureUndisposed();
            int i = frames.Count;
            foreach (Bitmap b in bmp)
                frames.AddRange(CreateFrames(b, opacify, transparent, smooth, resolve));
            for (; i < frames.Count; i++)
                ComputeBoundingBox(i);
        }
        public void InsertImage(Bitmap bmp, int pos, bool opacify, bool transparent, bool smooth, SizingCallback resolve)
        {
            EnsureUndisposed();
            int i = frames.Count;
            frames.InsertRange(pos, CreateFrames(bmp, opacify, transparent, smooth, resolve));
            for (; i < frames.Count; i++)
                ComputeBoundingBox(i);
        }
        // TODO: (above)
        public void InsertImages(IEnumerable<Bitmap> bmp, int pos, bool opacify, bool transparent, bool smooth, SizingCallback resolve)
        {
            EnsureUndisposed();
            int count = frames.Count;
            int i = pos;
            foreach (Bitmap b in bmp)
            {
                frames.InsertRange(pos, CreateFrames(b, opacify, transparent, smooth, resolve));
                pos += frames.Count - count;
                count = frames.Count;
            }
            for (; i < pos; i++)
                ComputeBoundingBox(i);
        }
        public void RemoveFrame(int index)
        {
            EnsureUndisposed();
            frames[index].Dispose();
            frames.RemoveAt(index);
            bboxes.RemoveAt(index);
        }
        public void RemoveRange(int index, int count)
        {
            EnsureUndisposed();
            for (int i = index; i < index + count; i++)
                frames[i].Dispose();
            frames.RemoveRange(index, count);
            bboxes.RemoveRange(index, count);
        }
        public BoundingBox GetBoundingBox(int index)
        {
            EnsureUndisposed();
            return bboxes[index];
        }
        public void SetBoundingBox(BoundingBox bbox)
        {
            EnsureUndisposed();
            bbmode = BoundingBoxMode.Manual;
            bboxes[0] = bbox;
        }
        void ComputeBoundingBox(int index)
        {
            EnsureUndisposed();
            if (bbmode != BoundingBoxMode.Automatic)
                return;
            BoundingBox bb = new BoundingBox(width - 1, height - 1, 0, 0);
            Bitmap b = frames[index];
            BitmapData bd = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int pixel = System.Runtime.InteropServices.Marshal.ReadInt32(bd.Scan0, bd.Stride * j + i * 4);
                    int alpha = (int)((uint)pixel >> 24);
                    if (alpha > tol)
                    {
                        if (bb.Left > i) bb.Left = i;
                        if (bb.Right < i) bb.Right = i;
                        if (bb.Top > j) bb.Top = j;
                        if (bb.Bottom < j) bb.Bottom = j;
                    }
                }
            }
            b.UnlockBits(bd);
            if (index >= bboxes.Count)
            {
                while (index >= bboxes.Count)
                    bboxes.Add(index == bboxes.Count ? bb : new BoundingBox());
            }
            else
                bboxes[index] = bb;
        }
        // Create a new bitmap that is a resized version of the original's current frame using argb
        static Bitmap Resize(Bitmap original, int width, int height, FramePlacement placement)
        {
            Bitmap b = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                Rectangle r = new Rectangle(
                    placement == FramePlacement.TopLeft || placement == FramePlacement.Stretch ?
                    0 : (width-original.Width)/2,
                    placement == FramePlacement.TopLeft || placement == FramePlacement.Stretch ?
                    0 : (height-original.Height)/2,
                    placement == FramePlacement.Stretch ? width : original.Width,
                    placement == FramePlacement.Stretch ? height : original.Height
                    );
                g.DrawImage(original, r, new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
            }
            return b;
        }
        IEnumerable<Bitmap> CreateFrames(Bitmap original, bool opacify, bool transparent, bool smooth, SizingCallback resolve)
        {
            EnsureUndisposed();
            FramePlacement placement = FramePlacement.TopLeft;
            FrameSizing sizing = FrameSizing.OriginalSize;
            if (frames.Count == 0)
                sizing = FrameSizing.NewSize;
            else if (original.Width != width || original.Height != height)
                if (resolve != null) resolve(out placement, out sizing);
            bool newsize = false;
            if (sizing == FrameSizing.NewSize)
            {
                width = original.Width;
                height = original.Height;
                newsize = true;
            }
            else if (sizing == FrameSizing.MaximumSize)
            {
                if (original.Width*original.Height > width*height)
                {
                    width = original.Width;
                    height = original.Height;
                    newsize = true;
                }
            }
            if (newsize)
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    Bitmap b = frames[i];
                    frames[i] = Resize(b, width, height, placement);
                    b.Dispose();
                }
            }
            FrameDimension fd = new FrameDimension(original.FrameDimensionsList[0]);
            int c = original.GetFrameCount(fd);
            for (int f = 0; f < c; f++)
            {
                original.SelectActiveFrame(fd, f);
                Bitmap temp = Resize(original, original.Width, original.Height, FramePlacement.TopLeft); // Don't modify the bitmap, just make a new one from the frame with format32bppargb;
                BitmapData bd = temp.LockBits(new Rectangle(0, 0, temp.Width, temp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                if (opacify)
                {
                    for (int i = 0; i < bd.Height; i++)
                        for (int j = 0; j < bd.Width; j++)
                        {
                            int ofs = bd.Stride * i + j * 4;
                            System.Runtime.InteropServices.Marshal.WriteInt32(bd.Scan0, ofs, unchecked(System.Runtime.InteropServices.Marshal.ReadInt32(bd.Scan0, ofs) & (int)0xFF000000));
                        }
                }
                if (transparent)
                {
                    int col = System.Runtime.InteropServices.Marshal.ReadInt32(bd.Scan0, bd.Stride * (bd.Height - 1)) & 0xFFFFFF;
                    for (int i = 0; i < bd.Height; i++)
                        for (int j = 0; j < bd.Width; j++)
                        {
                            int ofs = bd.Stride * i + j * 4;
                            if ((System.Runtime.InteropServices.Marshal.ReadInt32(bd.Scan0, ofs) & 0xFFFFFF) == col)
                                System.Runtime.InteropServices.Marshal.WriteInt32(bd.Scan0, ofs, col);
                        }
                }
                temp.UnlockBits(bd);
                Bitmap bmp = temp;
                if (original.Width != width || original.Height != height)
                {
                    bmp = Resize(temp, width, height, placement);
                    temp.Dispose();
                }
                if (smooth)
                {
                    temp = bmp;
                    bmp = SmoothEdges(temp);
                    temp.Dispose();
                }
                yield return bmp; // me likes ;D
            }
        }
        // TODO: if any edge smoothing bugs show up, it may be because we are using the same offset in both the bitmaps. may want to take care of that later.
        static Bitmap SmoothEdges(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp);
            BitmapData bdold = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bdnew = newbmp.LockBits(new Rectangle(0, 0, newbmp.Width, newbmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            for (int i = 0; i < bdnew.Height; i++)
                for (int j = 0; j < bdnew.Width; j++)
                {
                    int ofs = bdnew.Stride * i + j * 4; // offset assumed to be the same in both bitmaps
                    double num = 0;
                    int col = System.Runtime.InteropServices.Marshal.ReadInt32(bdold.Scan0, ofs);
                    int alpha = (int)((uint)unchecked(col & (int)0xFF000000) >> 24);
                    col &= 0xFFFFFF;
                    if (alpha != 0)
                    {
                        for (int k = -1; k < 2; k++)
                            for (int l = -1; l < 2; l++)
                            {
                                int ofs2 = bdnew.Stride * Math.Max(0, Math.Min(i + k, bdnew.Height - 1)) + Math.Max(0, Math.Min(j + l, bdnew.Width - 1)) * 4;
                                if (unchecked(System.Runtime.InteropServices.Marshal.ReadInt32(bdold.Scan0, ofs2) & 0xFF000000) == 0)
                                    num++;
                            }
                        if (num > 0)
                        {
                            alpha -= (int)((double)alpha * 0.11 * num);
                            System.Runtime.InteropServices.Marshal.WriteInt32(bdnew.Scan0, ofs, col | (alpha << 24));
                        }
                    }
                }
            newbmp.UnlockBits(bdnew);
            bmp.UnlockBits(bdold);
            return newbmp;
        }
        public Bitmap SmoothFrame(int framenum)
        {
            EnsureUndisposed();
            return SmoothEdges(frames[framenum]);
        }
        public Bitmap MakeTransparent(int framenum)
        {
            EnsureUndisposed();
            Bitmap bmp = new Bitmap(frames[framenum]);
            bmp.MakeTransparent(bmp.GetPixel(0, bmp.Height - 1));
            return bmp;
        }
        public System.Collections.BitArray CollisionMask(int framenum)
        {
            EnsureUndisposed();
            if (framenum >= frames.Count)
                return null;
            if (!separatemasks)
                framenum = 0;
            BoundingBox bb = GetBoundingBox(framenum);
            if (bb.Left > bb.Right || bb.Top > bb.Bottom)
                return null;
            bb.Normalize();
            int w = bb.Right - bb.Left + 1;
            int h = bb.Bottom - bb.Top + 1;
            System.Collections.BitArray mask = new System.Collections.BitArray(w * h);
            switch (bbshape)
            {
                case BoundingBoxShape.Rectangle:
                    // The mask is a rectangle.
                    mask.SetAll(true);
                    break;
                case BoundingBoxShape.Diamond:
                case BoundingBoxShape.Disk:
                    // Use a lambda function for the shape: a disk or a diamond.
                    Func<double, double, bool> ftn =
                        bbshape == BoundingBoxShape.Disk ?
                        (Func<double, double, bool>)((double x, double y) => (x * x + y * y < 1.0)) :
                        (Func<double, double, bool>)((double x, double y) => (Math.Abs(x) + Math.Abs(y) < 1.0));
                    
                    // Fill in the mask fitting the coordinates into the lambda function for the shape.
                    //GM8 BETA1/2/RC1 incorrect version (off-by-one and excessive rounding):
                    //int scalex = (bb.Right - bb.Left) >> 1;
                    //int scaley = (bb.Bottom - bb.Top) >> 1;
                    //for (int j = 0; j < h; j++)
                    //    for (int i = 0; i < w; i++)
                    //        mask[j * w + i] = ftn((double)(i - scalex) / (double)scalex, (double)(j - scaley) / (double)scaley);
                    // correct code:
                    double scalex = (double)(bb.Right - bb.Left + 1) * 0.5;
                    double scaley = (double)(bb.Bottom - bb.Top + 1) * 0.5;
                    for (int j = 0; j < h; j++)
                        for (int i = 0; i < w; i++)
                            mask[j * w + i] = ftn((double)(i - scalex) / scalex, (double)(j - scaley) / scaley);
                    break;
                default:
                    // Generate a mask based on alpha tolerance on each pixel.
                    Bitmap b = frames[framenum];
                    BitmapData bd = b.LockBits(new Rectangle(bb.Left, bb.Top, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    for (int j = 0; j < h; j++)
                        for (int i = 0; i < w; i++)
                            mask[j * w + i] = (int)((uint)System.Runtime.InteropServices.Marshal.ReadInt32(bd.Scan0, (j + bb.Top) * bd.Stride + (i + bb.Left) * 4) >> 24) > tol;
                    b.UnlockBits(bd);
                    break;
            }
            return mask;
        }
        public void Clear()
        {
            EnsureUndisposed();
            foreach (Bitmap bmp in frames)
                bmp.Dispose();
            frames.Clear();
            width = 0;
            height = 0;
        }
        List<Bitmap> frames = new List<Bitmap>();
        public List<Bitmap> Frames
        {
            get
            {
                EnsureUndisposed();
                return frames;
            }
        }
        public int FrameCount
        {
            get
            {
                EnsureUndisposed();
                return frames.Count;
            }
        }
        int width = 0;
        int height = 0;
        public int Width
        {
            get
            {
                EnsureUndisposed();
                return width;
            }
        }
        public int Height
        {
            get
            {
                EnsureUndisposed();
                return height;
            }
        }
        protected void EnsureUndisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        public bool IsDisposed
        {
            get
            {
                return disposed;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (!disposed)
            {
                foreach (Bitmap b in frames)
                    b.Dispose();
                frames.Clear();
                disposed = true;
            }
        }

        #endregion
    }
}
