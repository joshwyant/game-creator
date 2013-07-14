using System.Drawing;
using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class Sprite : NamedIndexedResource
    {
        internal Bitmap[] SubImages { get; set; }
        internal int[] Textures { get; set; }
        internal int subImagesCount;
        internal Sprite(ResourceContext context, string name, int index, int subimages)
            : base(context, name)
        {
            context.Sprites.Install(this, index);
            Initialize(subimages);
        }

        internal Sprite(ResourceContext context, string name, int subimages)
            : base(context, name)
        {
            context.Sprites.Install(this);
            Initialize(subimages);
        }

        private void Initialize(int subimages)
        {
            subImagesCount = subimages;
            SubImages = new Bitmap[subImagesCount];
            Textures = new int[subImagesCount];
            for (int i = 0; i < subImagesCount; i++)
                Textures[i] = -1;
        }
    }
}
