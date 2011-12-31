using System.Drawing;
using System.Collections.Generic;

namespace GameCreator.Runtime
{
    public class Sprite : IndexedResource
    {
        public static IndexedResourceManager Manager = new IndexedResourceManager();
        public string Code { get; private set; }
        internal Bitmap[] SubImages { get; set; }
        internal int[] Textures { get; set; }
        internal int subImagesCount;
        Sprite(string name, int index, int subimages) : base(name) 
        { 
            Manager.Install(this, index); 
            subImagesCount = subimages;
            SubImages = new Bitmap[subImagesCount];
            Textures = new int[subImagesCount];
            for (int i = 0; i < subImagesCount; i++)
                Textures[i] = -1;
        }
        public static Sprite Define(string name, int index, int subimages)
        {
            return new Sprite(name, index, subimages);
        }
    }
}
