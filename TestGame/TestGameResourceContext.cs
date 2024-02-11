using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameCreator.Engine;
using GameCreator.Engine.Common;
using GameCreator.Api.Resources;

namespace TestGame
{
    public class TestGameResourceContext : IResourceContext
    {
        private static GameSprite PacmanSprite;
        private static GameSprite WallSprite;
        private static GameSprite CircleSprite;
        private static GameSprite DiamondSprite;
        private static GameObject PacmanObject;
        private static GameObject WallObject;
        private static GameObject CircleObject;
        private static GameObject DiamondObject;
        private static GameSound ClickSound;
        private static GameRoom MainRoom;

        private class WallImage : IImage
        {
            public int Width { get; } = 32;
            public int Height { get; } = 32;
            // Generate a black square
            public uint[] ImageData { get; } = GenerateSquare();

            private static uint[] GenerateSquare()
            {
                return Enumerable.Repeat(0xFF800000, 32 * 32).ToArray();
            }
        }
        private class CircleImage : IImage
        {
            public int Width { get; } = 128;
            public int Height { get; } = 128;
            // Generate a black square
            public uint[] ImageData { get; } = GenerateCircle();

            private static uint[] GenerateCircle()
            {
                var data = new uint[128*128];
                
                for (var i = 0; i < 128*128; i++)
                {
                    var x = (i % 128 - 64) / 64.0;
                    var y = (i / 128 - 64) / 64.0;

                    data[i] = x * x + y * y < 1 ? 0x0000A0U + ((uint)(255-(x*x+y*y)*255)<<24) : 0;
                }

                return data;
            }
        }
        private class DiamondImage : IImage
        {
            public int Width { get; } = 128;
            public int Height { get; } = 128;
            // Generate a black square
            public uint[] ImageData { get; } = GenerateDiamond();

            private static uint[] GenerateDiamond()
            {
                var data = new uint[128*128];
                
                for (var i = 0; i < 128*128; i++)
                {
                    var x = (i % 128 - 64) / 64.0;
                    var y = (i / 128 - 64) / 64.0;

                    data[i] = Math.Abs(x) + Math.Abs(y) < 1 ? 0x008000U+((uint)(255-(Math.Abs(x)+Math.Abs(y))*255)<<24) : 0;
                }

                return data;
            }
        }
        
        private class PacmanObjectClass : GameObject
        {
            public override GameSprite Sprite => PacmanSprite;

            internal PacmanObjectClass(GameContext context) : base(context)
            {
            }

            protected override void OnRegisterEvents()
            {
                var r = new Random();
            
                RegisterEvent(EventType.Create, self =>
                {
                    //Context.Start3dMode();
                    
                    self.X = 128;
                    self.Y = 128;
                    self.ImageXScale = self.ImageYScale = 3;
                    self.ImageAlpha = 0.5;
                    self.ImageSpeed = 0;
                });

                void Collision(GameInstance self)
                {
                    if (!Context.Input.CheckKeyPressed(VirtualKeyCode.LShift))
                    {
                        Context.Library.Move.MoveContactPosition(self, self.Direction, self.Speed, true);
                    }
                    
                    Context.Library.Main.PlaySound(ClickSound);

                    self.Speed = 0;
                    self.ImageSpeed = 0;
                }

                RegisterEvent(WallObject, Collision);
                RegisterEvent(CircleObject, Collision);
                RegisterEvent(DiamondObject, Collision);
                
                RegisterEvent(EventType.Draw, self =>
                {
                    // How GM SHOULD project by default (default is yup 1, from -room_height, and corresponding angle).
                    // I think GM does it this way in order to use depth as z
                    Context.Graphics.SetProjection(
                        Context.CurrentRoom.Width * 0.5,
                        Context.CurrentRoom.Height * 0.5,
                        Context.CurrentRoom.Height,
                        Context.CurrentRoom.Width * 0.5,
                        Context.CurrentRoom.Height * 0.5,
                        0,
                        0,
                        -1,
                        0,
                        2*Math.Atan(0.5),
                        (double) Context.CurrentRoom.Width / Context.CurrentRoom.Height,
                        1,
                        32000
                    );
                
                    self.DrawSprite();
                });
                
                RegisterEvent(EventType.Keyboard, VirtualKeyCode.Left, self =>
                {
                    if (Context.Library.Move.PlaceFree(self, self.X - 5, self.Y, true))
                    {
                        self.HSpeed = -32;
                        self.VSpeed = 0;
                        self.ImageAngle = 0;
                        self.ImageSpeed = 0.5;
                    }
                });
                
                RegisterEvent(EventType.Keyboard, VirtualKeyCode.Right, self =>
                {
                    if (Context.Library.Move.PlaceFree(self, self.X + 5, self.Y, true))
                    {
                        self.HSpeed = 32;
                        self.VSpeed = 0;
                        self.ImageAngle = 180;
                        self.ImageSpeed = 0.5;
                    }
                });
                
                RegisterEvent(EventType.Keyboard, VirtualKeyCode.Up, self =>
                {
                    if (Context.Library.Move.PlaceFree(self, self.X, self.Y - 5, true))
                    {
                        self.HSpeed = 0;
                        self.VSpeed = -32;
                        self.ImageAngle = 270;
                        self.ImageSpeed = 0.5;
                    }
                });
                
                RegisterEvent(EventType.Keyboard, VirtualKeyCode.Down, self =>
                {
                    if (Context.Library.Move.PlaceFree(self, self.X, self.Y + 5, true))
                    {
                        self.HSpeed = 0;
                        self.VSpeed = 32;
                        self.ImageAngle = 90;
                        self.ImageSpeed = 0.5;
                    }
                });
                
                RegisterEvent(EventType.KeyRelease, VirtualKeyCode.AnyKey, self =>
                {
                    self.Speed = 0;
                    self.ImageSpeed = 0;
                });
            }
        }

        private class WallObjectClass : GameObject
        {
            internal WallObjectClass(GameContext context) : base(context)
            {
                Solid = true;
            }

            public override GameSprite Sprite => WallSprite;
        }

        private class CircleObjectClass : GameObject
        {
            internal CircleObjectClass(GameContext context) : base(context)
            {
                Solid = true;
            }

            public override GameSprite Sprite => CircleSprite;

            protected override void OnRegisterEvents()
            {
                RegisterEvent(EventType.Create, self =>
                {
                    self.ImageXScale = 1;
                    self.ImageYScale = 1;
                });
            }
        }

        private class DiamondObjectClass : GameObject
        {
            internal DiamondObjectClass(GameContext context) : base(context)
            {
                Solid = true;
            }

            public override GameSprite Sprite => DiamondSprite;

            protected override void OnRegisterEvents()
            {
                RegisterEvent(EventType.Create, self =>
                {
                    self.ImageXScale = 1;
                    self.ImageYScale = 1;
                });
            }
        }

        private class TestRoom : GameRoom
        {
            public TestRoom(GameContext context) : base(context)
            {
                BackgroundColor = 0xED9564; // Cornflower Blue
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
                
                // Add random objects
                instances.Add(new PredefinedInstance(context.Instances.GenerateId(), 224, 240, DiamondObject));
                instances.Add(new PredefinedInstance(context.Instances.GenerateId(), 416, 240, CircleObject));
                
                // Add pacman
                instances.Add(new PredefinedInstance(context.Instances.GenerateId(), 64, 64, PacmanObject));

                PredefinedInstances = instances.ToArray();
            }

            public override IList<PredefinedInstance> PredefinedInstances { get; } = [];
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
                    CollisionMaskFunction.Precise, true, 0, true),
                
                CircleSprite = new GameSprite(context, 128, 128, 64, 64, new[] { new CircleImage() }, 
                    CollisionMaskFunction.Precise, true, 0, true),
                
                DiamondSprite = new GameSprite(context, 128, 128, 64, 64, new[] { new DiamondImage() }, 
                    CollisionMaskFunction.Precise, true, 0, true)
            };
        }

        public IList<GameSound> GetPredefinedSounds(GameContext context)
        {
            var sounds = new List<GameSound>();

            using (var fs = File.Open("../TestGame/sounds/click.wav", FileMode.Open))
            {
                var effect = context.Audio.LoadSound(fs);
                sounds.Add(ClickSound = new GameSound(context, effect));
            }

            return sounds;
        }

        public IList<GameBackground> GetPredefinedBackgrounds(GameContext context)
        {
            return new GameBackground[0];
        }

        public IList<GameFont> GetPredefinedFonts(GameContext context)
        {
            return new GameFont[0];
        }

        public IList<GamePath> GetPredefinedPaths(GameContext context)
        {
            return new GamePath[0];
        }

        public IList<GameScript> GetPredefinedScripts(GameContext context)
        {
            return new GameScript[0];
        }

        public IList<GameTimeline> GetPredefinedTimelines(GameContext context)
        {
            return new GameTimeline[0];
        }

        public IList<GameObject> GetPredefinedObjects(GameContext context)
        {
            return new[]
            {
                PacmanObject = new PacmanObjectClass(context),
                WallObject = new WallObjectClass(context),
                CircleObject = new CircleObjectClass(context),
                DiamondObject = new DiamondObjectClass(context)
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