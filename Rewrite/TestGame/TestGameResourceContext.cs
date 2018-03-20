using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using GameCreator.Engine;
using GameCreator.Engine.Api;
using GameCreator.Engine.Common;

namespace TestGame
{
    public class TestGameResourceContext : IResourceContext
    {
        private static GameSprite PacmanSprite;
        private static GameSprite WallSprite;
        private static GameObject PacmanObject;
        private static GameObject WallObject;
        private static GameRoom MainRoom;

        private class WallImage : IImage
        {
            public int Width { get; } = 32;
            public int Height { get; } = 32;
            // Generate a black square
            public uint[] ImageData { get; } = GenerateDiamond();

            private static uint[] GenerateSquare()
            {
                return Enumerable.Repeat(0xFF000000, 32 * 32).ToArray();
            }

            private static uint[] GenerateCircle()
            {
                var data = new uint[32*32];
                
                for (var i = 0; i < 32 * 32; i++)
                {
                    var x = (i % 32 - 16) / 16f;
                    var y = (i / 32 - 16) / 16f;

                    data[i] = x * x + y * y < 1f ? 0xFF000000 : 0;
                }

                return data;
            }

            private static uint[] GenerateDiamond()
            {
                var data = new uint[32*32];
                
                for (var i = 0; i < 32 * 32; i++)
                {
                    var x = (i % 32 - 16) / 16f;
                    var y = (i / 32 - 16) / 16f;

                    data[i] = Math.Abs(x) + Math.Abs(y) < 1f ? 0xFF000000 : 0;
                }

                return data;
            }
        }
        
        private class PacmanObjectClass : GameObject
        {
            internal PacmanObjectClass(GameContext context) : base(context)
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
                instance.ImageXScale = 2;
                instance.ImageAngle = 15;
            }

            private Random r = new Random();
            protected override void OnCollision(GameInstance instance, GameObject other, ref bool handled)
            {
                if (other.Id == WallObject.Id)
                {
                    instance.ImageBlend = (uint) r.Next(0xFFFFFF);
                }
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
                        instance.HSpeed = -5;
                        instance.VSpeed = 0;
                        instance.ImageAngle = 0+15;
                        instance.ImageSpeed = 0.5;
                        break;
                    case VirtualKeyCode.Right:
                        instance.HSpeed = 5;
                        instance.VSpeed = 0;
                        instance.ImageAngle = 180+15;
                        instance.ImageSpeed = 0.5;
                        break;
                    case VirtualKeyCode.Up:
                        instance.HSpeed = 0;
                        instance.VSpeed = -5;
                        instance.ImageAngle = 270+15;
                        instance.ImageSpeed = 0.5;
                        break;
                    case VirtualKeyCode.Down:
                        instance.HSpeed = 0;
                        instance.VSpeed = 5;
                        instance.ImageAngle = 90+15;
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

        private class WallObjectClass : GameObject
        {
            internal WallObjectClass(GameContext context) : base(context)
            {
            }

            public override GameSprite Sprite => WallSprite;
        }

        private class TestRoom : GameRoom
        {
            public TestRoom(GameContext context) : base(context)
            {
                BackgroundColor = 0x303030;// 0xED9564; // Cornflower Blue
                Width = 640;
                Height = 480;

                var instances = new List<PredefinedInstance>();

                // Add horizontal walls
                for (var i = 0; i < 20; i++)
                {
                    instances.Add(new PredefinedInstance(context.Instances.GenerateId(), i*32, 0, WallObject));
                    instances.Add(new PredefinedInstance(context.Instances.GenerateId(), i*32, 448, WallObject));
                }

                // Add vertical walls
                for (var i = 0; i < 13; i++)
                {   
                    instances.Add(new PredefinedInstance(context.Instances.GenerateId(), 0, 32 + i*32, WallObject));
                    instances.Add(new PredefinedInstance(context.Instances.GenerateId(), 608, 32 + i*32, WallObject));
                }
                
                // Add pacman
                instances.Add(new PredefinedInstance(context.Instances.GenerateId(), 64, 64, PacmanObject));

                PredefinedInstances = instances.ToArray();
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
                    "../TestGame/sprites/pacman/pacman2.png"),
                    CollisionMaskFunction.Precise, true, 0, false),
                
                WallSprite = new GameSprite(context, 32, 32, 0, 0, new[] { new WallImage() }, 
                    CollisionMaskFunction.Precise, true, 0, true)
            };
        }

        public IList<GameObject> GetPredefinedObjects(GameContext context)
        {
            return new[]
            {
                PacmanObject = new PacmanObjectClass(context),
                WallObject = new WallObjectClass(context)
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