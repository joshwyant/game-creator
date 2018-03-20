using System.Collections.Generic;
using System.Linq;
using GameCreator.Engine.Common;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        private GameRoom _currentRoom;

        public GameRoom CurrentRoom
        {
            get => _currentRoom;
            set => SetCurrentRoom(value);
        }

        public IndexedResourceManager<GameRoom> Rooms { get; }
        private List<int> RoomOrder { get; }

        private List<GameInstance> GetRoomInstances()
        {
            if (CurrentRoom == null)
                return new List<GameInstance>();

            return Instances
                .Cast<GameInstance>()
                .Where(i => CurrentRoom.CreatedInstances.Contains(i.Id))
                .OrderBy(i => i.Depth)
                .ThenBy(i => i.Id)
                .ToList();
        }

        private void SetCurrentRoom(GameRoom room, bool gameStart = false)
        {
            Graphics.SetWindowSize(room.Width, room.Height);
            
            // Doc: Advanced Use > More about rooms > Advanced settings
            // TODO: Unit tests

            if (_currentRoom == null)
            {
                _currentRoom = room;
            }
            else
            {
                var prevRoomInstances = GetRoomInstances();

                // First, in the current room (if any) all instances get a room-end event.
                foreach (var instance in prevRoomInstances)
                {
                    instance.PerformEvent(EventType.Other, (int) OtherEventKind.RoomEnd);
                }

                // Next the non-persistent instances are removed (no destroy event is generated!).
                var nonPersistentInstances =
                    new HashSet<int>(prevRoomInstances.Where(i => !i.Persistent).Select(i => i.Id));
                foreach (var instance in nonPersistentInstances)
                {
                    Instances.Remove(instance);
                }
                _currentRoom.CreatedInstances.ExceptWith(nonPersistentInstances);
                var prevPersistedInstances = _currentRoom.CreatedInstances;

                // Next, for the new room the persistent instances from the previous room are added. 
                _currentRoom = room;
                _currentRoom.CreatedInstances.UnionWith(prevPersistedInstances);
            }

            var predefinedInstances = room.GetSortedPredefinedInstances();
            
            // All new instances are created and their creation events are executed 
            // (if the room is not persistent or has not been visited before). 
            foreach (var instInfo in predefinedInstances)
            {
                if (Instances.ContainsKey(instInfo.Id)) continue;
                var instance = new GameInstance(this, instInfo.X, instInfo.Y, instInfo.GameObject)
                {
                    Id = instInfo.Id
                };
                instInfo.GameObject.InitializeInstance(instance);
                Instances[instInfo.Id] = instance;
                _currentRoom.CreatedInstances.Add(instInfo.Id);
            }

            PresortedInstances = GetRoomInstances();
            
            for (var i = 0; i < PresortedInstances.Count; i++)
            {
                PresortedInstances[i].PerformEvent(EventType.Create);
            }

            // When this is the first room, for all instances the game-start event is generated.
            if (gameStart)
            { 
                for (var i = 0; i < PresortedInstances.Count; i++)
                {
                    PresortedInstances[i].PerformEvent(EventType.Other, (int) OtherEventKind.GameStart);
                }
            }
            
            // Now the room creation code is executed. 
            room.Creation();
            
            // Finally, all instances get a room-start event.
            for (var i = 0; i < PresortedInstances.Count; i++)
            {
                PresortedInstances[i].PerformEvent(EventType.Other, (int) OtherEventKind.RoomStart);
            }
        }
    }
}