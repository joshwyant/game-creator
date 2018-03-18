using System;
using GameCreator.Core;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public void ProcessEvents()
        {
            // ...

            DrawScreen();

            // ...
        }

        public void DrawScreen()
        {
            Graphics.Clear(
                (byte) (CurrentRoom.BackgroundColor & 0xFF),
                (byte) ((CurrentRoom.BackgroundColor & 0xFF00) >> 8),
                (byte) ((CurrentRoom.BackgroundColor & 0xFF0000) >> 16));

            var aspectRatio = (double) CurrentRoom.Width / CurrentRoom.Height;

            Graphics.SetProjection(
                CurrentRoom.Width / 2,
                CurrentRoom.Height / 2,
                -CurrentRoom.Width,
                CurrentRoom.Width / 2,
                CurrentRoom.Height / 2,
                0f,
                0f, -1f, 0f,
                2f * (float) Math.Atan(0.5 / aspectRatio), (float) aspectRatio, 1.0f, 32000f);

            var roomInstances = GetRoomInstances();

            // Process draw events
            foreach (var instance in roomInstances)
            {
                if (!instance.AssignedObject.PerformEvent(instance, EventType.Draw))
                {
                    if (Sprites.ContainsKey(instance.SpriteIndex))
                    {
                        Graphics.DrawSprite(
                            instance.Sprite.Textures[instance.ImageIndex],
                            (float) instance.X,
                            (float) instance.Y,
                            (float) instance.Depth,
                            instance.Sprite.Width,
                            instance.Sprite.Height,
                            instance.Sprite.XOrigin,
                            instance.Sprite.YOrigin,
                            (float) instance.ImageXScale,
                            (float) instance.ImageYScale,
                            (float) instance.ImageAngle,
                            (int) (instance.ImageBlend & 0xFF),
                            (int) (instance.ImageBlend & 0xFF00) >> 8,
                            (int) (instance.ImageBlend & 0xFF0000) >> 16,
                            instance.ImageAlpha);
                    }
                }
            }
        }
    }
}