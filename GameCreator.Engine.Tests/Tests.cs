using System.Collections.Generic;
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
        private TestRoom room;
        private FakeTimerPlugin _timerPlugin;
        private FakeGameContext c;
        private class TestRoom : GameRoom
        {
            public override IList<PredefinedInstance> PredefinedInstances { get; } = [];
        }
        
        [SetUp]
        public void SetUp()
        {
            graphics = new Mock<IGraphicsPlugin>();
            audio = new Mock<IAudioPlugin>();
            input = new Mock<IInputPlugin>();
            room = new TestRoom();
            resources = new Mock<IResourceContext>();
            resources.Setup(r => r.GetPredefinedObjects(It.IsAny<GameContext>()))
                .Returns<GameContext>(ctx =>
                    new[] { new pacman(ctx) }
                );
            resources.Setup(r => r.GetPredefinedRooms(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedSounds(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedBackgrounds(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedFonts(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedPaths(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedScripts(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedTimelines(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedObjects(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedTimelines(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedTriggers(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedSprites(It.IsAny<GameContext>())).Returns([]);
            resources.Setup(r => r.GetPredefinedTriggers(It.IsAny<GameContext>())).Returns([]);
            
            c = new FakeGameContext(graphics.Object, input.Object, audio.Object, _timerPlugin, resources.Object);
            c.Rooms.Add(room);
            c.CurrentRoom = room;
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
            c.Objects.Add(new pacman(c));

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