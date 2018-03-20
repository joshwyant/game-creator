using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GameCreator.Engine.Library
{
    public class CollisionFunctions
    {
        public GameContext Context { get; }

        public CollisionFunctions(GameContext context)
        {
            Context = context;
        }
        
        public Matrix3x2 GetSpriteTransform(GameInstance i)
        {
            if (i.Sprite == null) return Matrix3x2.Identity;;
            
            var m = Matrix3x2.CreateTranslation(-i.Sprite.XOrigin, -i.Sprite.YOrigin);
            if (i.ImageXScale != 1f || i.ImageYScale != 1f)
                m *= Matrix3x2.CreateScale((float) i.ImageXScale, (float) i.ImageYScale);
            if (i.ImageAngle != 0f)
                m *= Matrix3x2.CreateRotation((float) (-i.ImageAngle * Math.PI / 180));
            m *= Matrix3x2.CreateTranslation((float) i.X, (float) i.Y);
            // Todo: Transform by a world matrix in the graphics context
            return m;
        }

        public BoundingBox GetSpriteTransformedBoundingBox(GameSprite s, Matrix3x2 transform)
        {
            if (s.BoundingBox.Right < s.BoundingBox.Left || s.BoundingBox.Bottom < s.BoundingBox.Top)
                return s.BoundingBox;
            
            var corners = new[]
            {
                new Vector2(s.BoundingBox.Left, s.BoundingBox.Top),
                new Vector2(s.BoundingBox.Right + 1, s.BoundingBox.Top),
                new Vector2(s.BoundingBox.Right + 1, s.BoundingBox.Bottom + 1),
                new Vector2(s.BoundingBox.Left, s.BoundingBox.Bottom + 1)
            };
            
            var transformedVectors = corners
                .Select(v => Vector2.Transform(v, transform))
                .ToArray();
            
            return new BoundingBox((int)transformedVectors.Min(v => v.X),
                (int)transformedVectors.Min(v => v.Y),
                (int)transformedVectors.Max(v => v.X - 1),
                (int)transformedVectors.Max(v => v.Y - 1));
        }

        public bool CheckSpriteCollision(GameSprite sprite1, int subImage1, Matrix3x2 modelWorldTransform1,
            GameSprite sprite2, int subImage2, Matrix3x2 modelWorldTransform2)
        {
            return GetSpriteCollisions(sprite1, subImage1, modelWorldTransform1, sprite2, subImage2, modelWorldTransform2).Any();
        }

        /// <summary>
        /// Gets the individual pixel coordinates of a collision between two sprites.
        /// </summary>
        /// <param name="sprite1">The first sprite.</param>
        /// <param name="subImage1">The subimage of the first sprite.</param>
        /// <param name="modelWorldTransform1">The transformation matrix of the first sprite.</param>
        /// <param name="sprite2">The second sprite.</param>
        /// <param name="subImage2">The subimage of the second sprite.</param>
        /// <param name="modelWorldTransform2">The transformation matrix of the second sprite.</param>
        /// <returns>An enumerable of (x, y) tuple values representing the pixels in the collision.</returns>
        public IEnumerable<(int x, int y)> GetSpriteCollisions(GameSprite sprite1, int subImage1, 
            Matrix3x2 modelWorldTransform1, GameSprite sprite2, int subImage2, Matrix3x2 modelWorldTransform2)
        {
            // First, transform the bounding boxes to account for sprite origin, rotations, scaling, and position.
            var bb1 = GetSpriteTransformedBoundingBox(sprite1, modelWorldTransform1);
            var bb2 = GetSpriteTransformedBoundingBox(sprite2, modelWorldTransform2);
            
            // Invert the transformation matrixes so we can map world coordinates into sprite coordinates.
            Matrix3x2.Invert(modelWorldTransform1, out var spriteLocalTransform1);
            Matrix3x2.Invert(modelWorldTransform2, out var spriteLocalTransform2);

            // Get the intersection of both bounding boxes.
            var bbIntersection = bb1.Intersection(ref bb2);

            // If the bounding boxes don't overlap, there is no collision.
            if (!bbIntersection.IsValid)
                yield break;

            // Get the collision mask for each sprite.
            var mask1 = sprite1.SeparateCollisionMasks ? sprite1.CollisionMasks[subImage1] : sprite1.CollisionMasks[0];
            var mask2 = sprite2.SeparateCollisionMasks ? sprite2.CollisionMasks[subImage2] : sprite2.CollisionMasks[0];
            
            // Look at each pixel in the bounding box intersection.
            for (var x = bbIntersection.Left; x <= bbIntersection.Right; x++)
            {
                for (var y = bbIntersection.Top; y <= bbIntersection.Bottom; y++)
                {
                    // Transform the pixel coordinate to sprite coordinates for both sprites
                    // using the inverted world matrix.
                    var localV1 = Vector2.Transform(new Vector2(x, y), spriteLocalTransform1);
                    var localV2 = Vector2.Transform(new Vector2(x, y), spriteLocalTransform2);

                    // Check if the respective sprite coordinates overlap solid pixels in both sprites.
                    if (mask1.HitTest((int) localV1.X, (int) localV1.Y) 
                        && mask2.HitTest((int) localV2.X, (int) localV2.Y))
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}