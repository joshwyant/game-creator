using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameCreator.Core;
using GameCreator.Engine.Library;
using Ninject.Activation;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public StandardLibrary Library { get; }

        protected GameContext(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio,
            ITimerPlugin timer, IResourceContext predefinedResources)
        {
            Timer = timer;
            Graphics = graphics;
            Input = input;
            Audio = audio;

            var sprites = predefinedResources.GetPredefinedSprites(this);
            Sprites = new IndexedResourceManager<GameSprite>(sprites);
            
            var objects = predefinedResources.GetPredefinedObjects(this);
            Objects = new IndexedResourceManager<GameObject>(objects);
            
            Instances = new IndexedResourceManager<GameInstance>(100001);
            
            var rooms = predefinedResources.GetPredefinedRooms(this);
            Rooms = new IndexedResourceManager<GameRoom>(rooms);
            RoomOrder = rooms.Select(r => r.Id).ToList();

            var triggers = predefinedResources.GetPredefinedTriggers(this);
            Triggers = new IndexedResourceManager<ITrigger>(triggers);

            Instances.SetNextIndex(predefinedResources.NextInstanceId);
            Sprites.SetNextIndex(predefinedResources.NextSpriteId);
            Objects.SetNextIndex(predefinedResources.NextObjectId);
            Rooms.SetNextIndex(predefinedResources.NextRoomId);

            Graphics.Load += Graphics_Load;
            Graphics.Draw += Graphics_Update;
            Input.KeyPress += Input_KeyPress;
            
            Library = new StandardLibrary(this);

            Init();
        }

        private void Init()
        {
            // Start the game by going to the first room
            if (Rooms.Any())
            {
                SetCurrentRoom(Rooms[RoomOrder.First()], true);
            }
        }
    }
}