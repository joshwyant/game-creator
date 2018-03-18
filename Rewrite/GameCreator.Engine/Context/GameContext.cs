using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameCreator.Core;

namespace GameCreator.Engine
{
    public abstract class GameContext : IGameContext
    {
        public GameInstance OtherInstance { get; private set; }
        private GameRoom _currentRoom;
        public GameRoom CurrentRoom
        {
            get => _currentRoom;
            set => SetCurrentRoom(value);
        }
        public IResourceContext PredefinedResources { get; }
        public IndexedResourceManager<GameInstance> Instances { get; }
        public IndexedResourceManager<GameObject> Objects { get; }
        public IndexedResourceManager<GameRoom> Rooms { get; }
        public IndexedResourceManager<ITrigger> Triggers { get; }
        public IGraphicsPlugin Graphics { get; }
        public IInputPlugin Input { get; }
        public IAudioPlugin Audio { get; }
        public ITimerPlugin Timer { get; }
        
        public abstract int GameId { get; }
        
        private List<int> RoomOrder { get; }

        protected GameContext(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio,
            ITimerPlugin timer, IResourceContext predefinedResources)
        {
            PredefinedResources = predefinedResources;
            Timer = timer;
            Graphics = graphics;
            Input = input;
            Audio = audio;

            var rooms = PredefinedResources.GetPredefinedRooms(this);
            var objects = PredefinedResources.GetPredefinedObjects(this);
            var triggers = PredefinedResources.GetPredefinedTriggers(this);

            RoomOrder = rooms.Select(r => r.Id).ToList();

            var nextInstanceId =
                Math.Max(PredefinedResources.NextInstanceId,
                    rooms.SelectMany(r => r.PredefinedInstances).DefaultIfEmpty().Max(i => i?.Id ?? 100000) + 1);
            
            Instances = new IndexedResourceManager<GameInstance>(nextInstanceId);
            Objects = new IndexedResourceManager<GameObject>(objects);
            Rooms = new IndexedResourceManager<GameRoom>(rooms);
            Triggers = new IndexedResourceManager<ITrigger>(triggers);

            Init();
        }

        private void Init()
        {
            if (!Rooms.Any())
                return;
            
            SetCurrentRoom(Rooms[RoomOrder.First()], true);
        }

        private void SetCurrentRoom(GameRoom room, bool gameStart = false)
        {
            // Doc: Advanced Use > More about rooms > Advanced settings
            // TODO: Unit tests
            
            var prevRoomInstances = GetRoomInstances();
            
            // First, in the current room (if any) all instances get a room-end event.
            foreach (var instance in prevRoomInstances)
            {
                instance.PerformEvent(EventType.Other, (int)OtherEventKind.RoomEnd);
            }
            
            // Next the non-persistent instances are removed (no destroy event is generated!).
            var nonPersistentInstances = new HashSet<int>(prevRoomInstances.Where(i => !i.Persistent).Select(i => i.Id));
            foreach (var instance in nonPersistentInstances)
            {
                Instances.Remove(instance);
            }
            _currentRoom.CreatedInstances.ExceptWith(nonPersistentInstances);
            var prevPersistedInstances = _currentRoom.CreatedInstances;

            // Next, for the new room the persistent instances from the previous room are added. 
            _currentRoom = room;
            _currentRoom.CreatedInstances.UnionWith(prevPersistedInstances);

            var predefinedInstances = room.GetSortedPredefinedInstances();
            
            // All new instances are created and their creation events are executed 
            // (if the room is not persistent or has not been visited before). 
            foreach (var instInfo in predefinedInstances)
            {
                if (Instances.ContainsKey(instInfo.Id)) continue;
                var instance =
                    new GameInstance(this, instInfo.X, instInfo.Y, instInfo.GameObject)
                    {
                        Depth = instInfo.GameObject.Depth
                    };
                Instances[instInfo.Id] = instance;
                _currentRoom.CreatedInstances.Add(instInfo.Id);
                instance.PerformEvent(EventType.Create);
            }

            var roomInstances = GetRoomInstances();

            // When this is the first room, for all instances the game-start event is generated.
            if (gameStart)
            { 
                foreach (var instance in roomInstances)
                {
                    instance.PerformEvent(EventType.Other, (int) OtherEventKind.GameStart);
                }
            }
            
            // Now the room creation code is executed. 
            room.Creation();
            
            // Finally, all instances get a room-start event.
            foreach (var instance in roomInstances)
            {
                instance.PerformEvent(EventType.Other, (int) OtherEventKind.RoomStart);
            }
        }

        public void ProcessEvents()
        {
            
        }

        public GameInstance CreateInstance(double x, double y, GameObject assignedObject)
        {
            // TODO: Unit tests
            var inst = new GameInstance(this, x, y, assignedObject);
            Instances.Add(inst);
            CurrentRoom?.CreatedInstances?.Add(inst.Id);
            return inst;
        }

        private IList<GameInstance> GetRoomInstances()
        {
            if (CurrentRoom == null)
                return new GameInstance[0];
            
            return Instances
                .Where(i => CurrentRoom.CreatedInstances.Contains(i.Id))
                .OrderBy(i => i.Depth)
                .ThenBy(i => i.Id)
                .ToList();
        }

        public void Run()
        {
            Graphics.Run();
        }
    }
}