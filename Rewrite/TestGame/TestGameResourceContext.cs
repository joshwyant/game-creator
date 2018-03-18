using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using GameCreator.Engine;

namespace TestGame
{
    public class TestGameResourceContext : IResourceContext
    {
        class TestObject : GameObject
        {
            internal TestObject(IGameContext context) : base(context)
            {
            }

            public override GameSprite Sprite => Context.Sprites[0];

            protected override void OnCreate(GameInstance instance, ref bool handled)
            {
                instance.X = 400;
                instance.Y = 300;
                instance.ImageAlpha = 128;
                instance.ImageBlend = 0x808080;
                instance.ImageXScale = 1.5;
                instance.ImageAngle = 45;
                instance.Depth = -400;
            }
        }

        class TestRoom : GameRoom
        {
            public TestRoom(IGameContext context) : base(context)
            {
                BackgroundColor = 0xED9564;
                Width = 800;
                Height = 600;
                
                PredefinedInstances = new[]
                {
                    new PredefinedInstance(context.Instances.GenerateId(), 64, 64, context.Objects[0])
                };
            }

            public override IList<PredefinedInstance> PredefinedInstances { get; }
        }
        
        public int NextRoomId => -1;
        public int NextObjectId => -1;
        public int NextInstanceId => -1;
        public int NextSpriteId => -1;

        public IList<GameSprite> GetPredefinedSprites(IGameContext context)
        {
            var loader = new ImageLoader();
            using (var fs = new FileStream("pacman.png", FileMode.Open))
            {
                return new[]
                {
                    new GameSprite(context, 32, 32, 0, 0, new[] { loader.FromStream(fs) })
                };
                
            }
        }

        public IList<GameObject> GetPredefinedObjects(IGameContext context)
        {
            return new[]
            {
                new TestObject(context)
            };
        }
        
        public IList<GameRoom> GetPredefinedRooms(IGameContext context)
        {
            return new []
            {
                new TestRoom(context) 
            };
        }

        public IList<ITrigger> GetPredefinedTriggers(IGameContext gameContext)
        {
            return new ITrigger[0];
        }
    }
}