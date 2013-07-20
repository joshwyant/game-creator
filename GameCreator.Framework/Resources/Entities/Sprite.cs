using System.Drawing;
using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class Sprite : NamedIndexedResource
    {
        public static IndexedResourceManager<Sprite> Manager
        {
            get
            {
                return LibraryContext.Current.Resources.Sprites;
            }
        }

        public Bitmap[] SubImages { get; set; }
        public int[] Textures { get; set; }
        public int SubImagesCount;
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
            SubImagesCount = subimages;
            SubImages = new Bitmap[SubImagesCount];
            Textures = new int[SubImagesCount];
            for (int i = 0; i < SubImagesCount; i++)
                Textures[i] = -1;
        }
    }
}
