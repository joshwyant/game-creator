using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameCreator.Core;
using Ninject.Activation;

namespace GameCreator.Engine
{
    public abstract partial class GameContext : IGameContext
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
        public IndexedResourceManager<GameSprite> Sprites { get; }
        public IndexedResourceManager<ITrigger> Triggers { get; }
        public IGraphicsPlugin Graphics { get; }
        public IInputPlugin Input { get; }
        public IAudioPlugin Audio { get; }
        public ITimerPlugin Timer { get; }

        private bool _3dMode;
        public bool Enable3dMode => _3dMode;
        public double DrawDepth3d { get; set; }

        public abstract int GameId { get; }
        
        private Queue<VirtualKeyCode> KeysPressed = new Queue<VirtualKeyCode>();
        private HashSet<VirtualKeyCode> KeysDown = new HashSet<VirtualKeyCode>();
        
        private List<int> RoomOrder { get; }
        /// <summary>
        /// This can be accessed in a loop, but don't use foreach if you are creating new instances!
        /// </summary>
        private List<GameInstance> PresortedInstances { get; set; }

        protected GameContext(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio,
            ITimerPlugin timer, IResourceContext predefinedResources)
        {
            PredefinedResources = predefinedResources;
            Timer = timer;
            Graphics = graphics;
            Input = input;
            Audio = audio;

            var sprites = PredefinedResources.GetPredefinedSprites(this);
            Sprites = new IndexedResourceManager<GameSprite>(sprites);
            
            var objects = PredefinedResources.GetPredefinedObjects(this);
            Objects = new IndexedResourceManager<GameObject>(objects);
            
            Instances = new IndexedResourceManager<GameInstance>(100001);
            
            var rooms = PredefinedResources.GetPredefinedRooms(this);
            Rooms = new IndexedResourceManager<GameRoom>(rooms);
            RoomOrder = rooms.Select(r => r.Id).ToList();

            var triggers = PredefinedResources.GetPredefinedTriggers(this);
            Triggers = new IndexedResourceManager<ITrigger>(triggers);

            Instances.SetNextIndex(PredefinedResources.NextInstanceId);
            Sprites.SetNextIndex(PredefinedResources.NextSpriteId);
            Objects.SetNextIndex(PredefinedResources.NextObjectId);
            Rooms.SetNextIndex(PredefinedResources.NextRoomId);

            Graphics.Load += Graphics_Load;
            Graphics.Draw += Graphics_Update;
            Input.KeyPress += Input_KeyPress;

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

        private void Graphics_Update(object sender, EventArgs eventArgs)
        {
            ProcessEvents();
        }

        private void Graphics_Load(object sender, EventArgs eventArgs)
        {
            LoadContent();
        }

        private void Input_KeyPress(object sender, KeyboardEventArgs e)
        {
            KeysDown.Add(e.KeyCode);
            KeysPressed.Enqueue(e.KeyCode);
        }

        private void LoadContent()
        {
            // Load all the sprite textures
            foreach (var sprite in Sprites)
            {
                sprite.Textures = sprite.SubImages.Select(si => Graphics.LoadTexture(si)).ToArray();
            }
            
            // ...
        }

        public GameInstance CreateInstance(double x, double y, GameObject assignedObject)
        {
            // TODO: Unit tests
            var inst = new GameInstance(this, x, y, assignedObject);
            assignedObject.InitializeInstance(inst);
            Instances.Add(inst);
            CurrentRoom?.CreatedInstances?.Add(inst.Id);
            PresortedInstances.Add(inst);
            return inst;
        }

        private List<GameInstance> GetRoomInstances()
        {
            if (CurrentRoom == null)
                return new List<GameInstance>();
            
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

        public void Start3dMode()
        {
            _3dMode = true;
            Graphics.DepthStencilEnable = true;
        }

        public void End3dMode()
        {
            _3dMode = false;
            Graphics.DepthStencilEnable = false;
        }

        public void SetProjectionPerspective(float x, float y, float w, float h, float angle)
        {
            var aspectRatio = w / h;
            var xcenter = x + w * 0.5f;
            var ycenter = y + h * 0.5f;
            var c = (float)Math.Cos(angle * Math.PI / 180.0);
            var s = (float)Math.Sin(angle * Math.PI / 180.0);
            
            Graphics.SetProjection(
                xcenter, 
                ycenter, 
                -w, 
                xcenter, 
                ycenter, 
                0, 
                -s, // xup = 0, rotated by angle
                c, // yup = 1, rotated by angle
                0, 
                (float)(2*Math.Atan(0.5 / aspectRatio)), 
                aspectRatio, 
                1, 
                32000);
        }
    }
}