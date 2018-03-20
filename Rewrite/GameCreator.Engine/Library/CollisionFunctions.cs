using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GameCreator.Engine.Library
{
    public class CollisionFunctions
    {
        public static Matrix3x2 GetSpriteTransform(GameSprite sprite, float angle, float xscale, float yscale, float x, 
            float y)
        {
            var m = Matrix3x2.CreateTranslation(-sprite.XOrigin, -sprite.YOrigin);
            if (xscale != 1f || yscale != 1f)
                m *= Matrix3x2.CreateScale(xscale, yscale);
            if (angle != 0f)
                m *= Matrix3x2.CreateRotation((float) (angle * Math.PI / 180));
            m *= Matrix3x2.CreateTranslation(x, y);
            return m;
        }

        public static BoundingBox GetSpriteTransformedBoundingBox(GameSprite s, Matrix3x2 transform)
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

        public static bool CheckSpriteCollision(GameSprite s1, int subImage1, Matrix3x2 t1,
            GameSprite s2, int subImage2, Matrix3x2 t2)
        {
            return !GetSpriteCollisions(s1, subImage1, t1, s2, subImage2, t2).Any();
        }

        /// <summary>
        /// Gets the individual pixel coordinates of a collision between two sprites.
        /// </summary>
        /// <param name="s1">The first sprite.</param>
        /// <param name="subImage1">The subimage of the first sprite.</param>
        /// <param name="t1">The transformation matrix of the first sprite.</param>
        /// <param name="s2">The second sprite.</param>
        /// <param name="subImage2">The subimage of the second sprite.</param>
        /// <param name="t2">The transformation matrix of the second sprite.</param>
        /// <returns>An enumerable of (x, y) tuple values representing the pixels in the collision.</returns>
        public static IEnumerable<(int x, int y)> GetSpriteCollisions(GameSprite s1, int subImage1, Matrix3x2 t1, 
            GameSprite s2, int subImage2, Matrix3x2 t2)
        {
            // First, transform the bounding boxes to account for sprite origin, rotations, scaling, and position.
            var bb1 = GetSpriteTransformedBoundingBox(s1, t1);
            var bb2 = GetSpriteTransformedBoundingBox(s2, t2);
            
            // Invert the transformation matrixes so we can map world coordinates into sprite coordinates.
            Matrix3x2.Invert(t1, out var inv1);
            Matrix3x2.Invert(t2, out var inv2);

            // If the bounding boxes don't overlap, there is no collision.
            if (!BoundingBox.Overlap(ref bb1, ref bb2))
                yield break;

            // Get the intersection of both bounding boxes.
            var bb = BoundingBox.Intersection(ref bb1, ref bb2);

            // Get the collision mask for each sprite.
            var mask1 = s1.SeparateCollisionMasks ? s1.CollisionMasks[subImage1] : s1.CollisionMasks[0];
            var mask2 = s2.SeparateCollisionMasks ? s2.CollisionMasks[subImage2] : s2.CollisionMasks[0];
            
            // Look at each pixel in the bounding box intersection.
            for (var x = bb.Left; x <= bb.Right; x++)
            {
                for (var y = bb.Top; y <= bb.Bottom; y++)
                {
                    // Invert the pixel to sprite coordinates for both sprites.
                    var v1 = Vector2.Transform(new Vector2(x, y), inv1);
                    var v2 = Vector2.Transform(new Vector2(x, y), inv2);

                    // Check if the sprite coordinates overlap solid pixels in both sprites.
                    if (mask1.HitTest((int) v1.X, (int) v1.Y) && mask2.HitTest((int) v2.X, (int) v2.Y))
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}