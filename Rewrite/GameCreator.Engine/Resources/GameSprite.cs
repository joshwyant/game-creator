using System.Linq;
using GameCreator.Engine.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine
{
    public class GameSprite : IGameSprite
    {
        public GameContext Context { get; }
        public int Id { get; set; } = -1;
        public ITexture[] Textures { get; internal set; }
        public IImage[] SubImages { get; }
        public int Width { get; }
        public int Height { get; }
        public int XOrigin { get; }
        public int YOrigin { get; }
        public BoundingBox BoundingBox { get; }
        public CollisionMaskFunction CollisionMaskFunction { get; }
        public bool SeparateCollisionMasks { get; }
        public BoundingBoxFunction BoundingBoxFunction { get; }
        public CollisionMask[] CollisionMasks { get; }

        /// <summary>
        /// Creates a sprite with a manual bounding box.
        /// </summary>
        public GameSprite(GameContext context, int w, int h, int xorigin, int yorigin, IImage[] subImages, 
            CollisionMaskFunction collisionMaskFunction, BoundingBox boundingBox, bool separateCollisionMasks)
        {
            Context = context;
            Width = w;
            Height = h;
            XOrigin = xorigin;
            YOrigin = yorigin;
            SubImages = subImages;
            CollisionMaskFunction = collisionMaskFunction;
            BoundingBox = boundingBox;
            SeparateCollisionMasks = separateCollisionMasks;
            BoundingBoxFunction = BoundingBoxFunction.Manual;
            CollisionMasks = GenerateCollisionMasks();
        }

        private CollisionMask[] GenerateCollisionMasks(int alphaTolerance = 0)
        {
            if (SeparateCollisionMasks)
            {
                return SubImages.Select(s => GenerateCollisionMask(new[] { s }, alphaTolerance)).ToArray();
            }
            else
            {
                return new[] { GenerateCollisionMask(SubImages, alphaTolerance) };
            }
        }

        /// <summary>
        /// This is called in 2 cases:
        /// 1) with one subimage - to generate individual masks per subimage, and
        /// 2) with multiple subimages - to generate a collision mask that is a composite of subimages.
        /// </summary>
        /// <param name="subImages"></param>
        /// <param name="alphaTolerance"></param>
        /// <returns></returns>
        private CollisionMask GenerateCollisionMask(IImage[] subImages, int alphaTolerance = 0)
        {
            var maskbb = BoundingBox;

            // Detect bounding boxes based on the individual subimages
            // In case one, each subimage gets its own bounding box.
            // In case two, the bounding box takes into account all subimages.
            if (BoundingBoxFunction == BoundingBoxFunction.Automatic)
            {
                maskbb = BoundingBox.Detect(subImages, alphaTolerance);
            }
            
            if (CollisionMaskFunction == CollisionMaskFunction.Precise)
            {
                // Here as well, if multiple subimages are passed,
                // the mask will contain the pixels of all subimages.
                return new CollisionMask(subImages, maskbb, alphaTolerance);
            }
            else
            {
                return new CollisionMask(CollisionMaskFunction, maskbb);
            }
        }

        /// <summary>
        /// Creates a sprite with an auto or full-image bounding box.
        /// </summary>
        public GameSprite(GameContext context, int width, int height, int xorigin, int yorigin, IImage[] subImages,
            CollisionMaskFunction collisionMaskFunction, bool autoBoundingBox, int alphaTolerance, 
            bool separateCollisionMasks)
        {   
            Context = context;
            Width = width;
            Height = height;
            XOrigin = xorigin;
            YOrigin = yorigin;
            SubImages = subImages;
            CollisionMaskFunction = collisionMaskFunction;
            SeparateCollisionMasks = separateCollisionMasks;
            
            if (autoBoundingBox)
            {
                BoundingBox = BoundingBox.Detect(subImages, alphaTolerance);
            }
            else
            {
                BoundingBox = new BoundingBox(0, 0, width - 1, height - 1);
            }

            CollisionMasks = GenerateCollisionMasks();
        }
    }
}