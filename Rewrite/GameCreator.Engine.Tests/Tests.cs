using GameCreator.Engine.Api;
using GameCreator.Engine.Common;
using GameCreator.Resources.Api;
using Moq;
using NUnit.Framework;

namespace GameCreator.Engine.Tests
{
    public class UnitTest1
    {
        private Mock<IResourceContext> resources;
        private Mock<IGraphicsPlugin> graphics;
        private Mock<IAudioPlugin> audio;
        private Mock<IInputPlugin> input;
        private FakeTimerPlugin _timerPlugin;
        private FakeGameContext c;
        
        [SetUp]
        public void SetUp()
        {
            graphics = new Mock<IGraphicsPlugin>();
            audio = new Mock<IAudioPlugin>();
            input = new Mock<IInputPlugin>();
            resources = new Mock<IResourceContext>();
            resources.Setup(r => r.GetPredefinedObjects(It.IsAny<GameContext>()))
                .Returns<GameContext>(ctx =>
                    new[] { new pacman(ctx) }
                );
            resources.Setup(r => r.GetPredefinedRooms(It.IsAny<GameContext>())).Returns(new GameRoom[0]);
            resources.Setup(r => r.GetPredefinedSprites(It.IsAny<GameContext>())).Returns(new GameSprite[0]);
            resources.Setup(r => r.GetPredefinedTriggers(It.IsAny<GameContext>())).Returns(new ITrigger[0]);
            
            
            c = new FakeGameContext(graphics.Object, input.Object, audio.Object, _timerPlugin, resources.Object);
        }
        
        class pacman : GameObject
        {
            public pacman(GameContext context) : base(context)
            {
                RegisterEvent(EventType.Create, instance =>
                {
                    instance.X += 3;
                });
            }

            public override GameSprite Sprite => null;
        }
        
        [Test]
        public void Test1()
        {
            c.CreateInstance(0, 0, c.Objects[0]);
        }

        public void NextResourceId_Defaults()
        {
            // TODO: Instance IDs > 100001, -1 for predefined IDs, etc.
        }

        public void NextResourceId_SetProperly()
        {
            // TODO
        }
    }
}