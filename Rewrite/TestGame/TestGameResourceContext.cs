using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using GameCreator.Core;
using GameCreator.Engine;

namespace TestGame
{
    public class TestGameResourceContext : IResourceContext
    {
        private static GameSprite PacmanSprite;
        private static GameObject PacmanObject;
        private static GameRoom MainRoom;
        
        private class TestObject : GameObject
        {
            internal TestObject(GameContext context) : base(context)
            {
            }

            public override GameSprite Sprite => PacmanSprite;

            protected override void OnCreate(GameInstance instance, ref bool handled)
            {
                Context.Start3dMode();
                
                instance.X = 64;
                instance.Y = 64;
                instance.ImageAlpha = 0.5;
                instance.ImageSpeed = 0;
            }

            protected override void OnDraw(GameInstance instance, ref bool handled)
            {
                // How GM SHOULD project by default (default is yup 1, from -room_height, and corresponding angle).
                // I think GM does it this way in order to use depth as z
                Context.Graphics.SetProjection(
                        Context.CurrentRoom.Width * 0.5f,
                        Context.CurrentRoom.Height * 0.5f,
                        Context.CurrentRoom.Height,
                        Context.CurrentRoom.Width * 0.5f,
                        Context.CurrentRoom.Height * 0.5f,
                        0,
                        0,
                        -1,
                        0,
                        (float) (2*Math.Atan(0.5)),
                        (float) Context.CurrentRoom.Width / Context.CurrentRoom.Height,
                        1,
                        32000
                    );
                
                instance.DrawSprite();
            }

            protected override void OnKeyboard(GameInstance instance, VirtualKeyCode keyCode, ref bool handled)
            {
                switch (keyCode)
                {
                    case VirtualKeyCode.Left:
                        instance.Speed = 5;
                        instance.Direction = 180;
                        instance.ImageAngle = 0;
                        instance.ImageSpeed = 0.5;
                        break;
                    case VirtualKeyCode.Right:
                        instance.Speed = 5;
                        instance.Direction = 0;
                        instance.ImageAngle = 180;
                        instance.ImageSpeed = 0.5;
                        break;
                    case VirtualKeyCode.Up:
                        instance.Speed = 5;
                        instance.Direction = 90;
                        instance.ImageAngle = 270;
                        instance.ImageSpeed = 0.5;
                        break;
                    case VirtualKeyCode.Down:
                        instance.Speed = 5;
                        instance.Direction = 270;
                        instance.ImageAngle = 90;
                        instance.ImageSpeed = 0.5;
                        break;
                }
            }

            protected override void OnKeyRelease(GameInstance instance, VirtualKeyCode keyCode, ref bool handled)
            {
                switch (keyCode)
                {
                    case VirtualKeyCode.AnyKey:
                        instance.Speed = 0;
                        instance.ImageSpeed = 0;
                        break;
                }
            }
        }

        private class TestRoom : GameRoom
        {
            public TestRoom(GameContext context) : base(context)
            {
                BackgroundColor = 0x303030;// 0xED9564; // Cornflower Blue
                Width = 800;
                Height = 600;
                
                PredefinedInstances = new[]
                {
                    new PredefinedInstance(context.Instances.GenerateId(), 64, 64, PacmanObject)
                };
            }

            public override IList<PredefinedInstance> PredefinedInstances { get; }
        }
        
        public int NextRoomId => -1;
        public int NextObjectId => -1;
        public int NextInstanceId => -1;
        public int NextSpriteId => -1;
        
        public IList<GameSprite> GetPredefinedSprites(GameContext context)
        {
            var loader = new ImageLoader();
            
            return new[]
            {
                PacmanSprite = new GameSprite(context, 32, 32, 16, 16, loader.LoadImages(
                    "../TestGame/sprites/pacman/pacman1.png",
                    "../TestGame/sprites/pacman/pacman2.png",
                    "../TestGame/sprites/pacman/pacman3.png",
                    "../TestGame/sprites/pacman/pacman2.png"))
            };
        }

        public IList<GameObject> GetPredefinedObjects(GameContext context)
        {
            return new[]
            {
                PacmanObject = new TestObject(context)
            };
        }
        
        public IList<GameRoom> GetPredefinedRooms(GameContext context)
        {
            return new []
            {
                MainRoom = new TestRoom(context) 
            };
        }

        public IList<ITrigger> GetPredefinedTriggers(GameContext gameContext)
        {
            return new ITrigger[0];
        }
    }
}