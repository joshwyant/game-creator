using System;
using System.Linq;
using GameCreator.Engine.Api;
using GameCreator.Engine.Library;
using GameCreator.Resources.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine
{
    public abstract partial class GameContext : IGameContext
    {
        public StandardLibrary Library { get; }

        public IVariableList Globals { get; }

        [Gml("argument_relative")]
        public bool ArgumentRelative { get; set; }

        protected GameContext(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio,
            ITimerPlugin timer, IResourceContext predefinedResources)
        {
            Timer = timer;
            Graphics = graphics;
            Input = input;
            Audio = audio;

            var sprites = predefinedResources.GetPredefinedSprites(this);
            Sprites = new IndexedResourceManager<GameSprite>(sprites);
            
            var sounds = predefinedResources.GetPredefinedSounds(this);
            Sounds = new IndexedResourceManager<GameSound>(sounds);
            
            var backgrounds = predefinedResources.GetPredefinedBackgrounds(this);
            Backgrounds = new IndexedResourceManager<GameBackground>(backgrounds);
            
            var fonts = predefinedResources.GetPredefinedFonts(this);
            Fonts = new IndexedResourceManager<GameFont>(fonts);
            
            var paths = predefinedResources.GetPredefinedPaths(this);
            Paths = new IndexedResourceManager<GamePath>(paths);
            
            var scripts = predefinedResources.GetPredefinedScripts(this);
            Scripts = new IndexedResourceManager<GameScript>(scripts);
            
            var timelines = predefinedResources.GetPredefinedTimelines(this);
            Timelines = new IndexedResourceManager<GameTimeline>(timelines);
            
            var objects = predefinedResources.GetPredefinedObjects(this);
            Objects = new IndexedResourceManager<GameObject>(objects);
            foreach (var gameObject in Objects)
            {
                gameObject.OnRegisterEvents();
            }
            
            AllInstances = new IndexedResourceManager<IInstance>(100001);
            
            var rooms = predefinedResources.GetPredefinedRooms(this);
            Rooms = new IndexedResourceManager<GameRoom>(rooms);
            RoomOrder = rooms.Select(r => r.Id).ToList();

            var triggers = predefinedResources.GetPredefinedTriggers(this);
            Triggers = new IndexedResourceManager<ITrigger>(triggers);

            Instances.TrySetNextIndex(predefinedResources.NextInstanceId);
            Sprites.TrySetNextIndex(predefinedResources.NextSpriteId);
            Objects.TrySetNextIndex(predefinedResources.NextObjectId);
            Rooms.TrySetNextIndex(predefinedResources.NextRoomId);

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

        public virtual void ReportError(string msg)
        {
            throw new Exception(msg);
        }

        public InstanceScope CreateInstanceScope(IInstance instance)
        {
            return new InstanceScope(this, instance);
        }

        public void With(IInstance self, Action<IInstance> action)
        {
            using (CreateInstanceScope(self))
            {
                action(self);
            }
        }

        public void With(int objectOrInstanceId, Action<IInstance> action)
        {
            switch (objectOrInstanceId)
            {
                case -1: // self
                    With(CurrentInstance, action);
                    break;
                case -2: // other
                    With(OtherInstance, action);
                    break;
                case -3: // all
                    foreach (var instance in Instances)
                    {
                        With(instance, action);
                    }
                    break;
                case -4: // noone
                    break;
                case -5: // global
                    ReportError("Cannot use global in a with statement.");
                    break;
                default:
                    if (objectOrInstanceId <= 100000)
                    {
                        foreach (var instance in Instances.Where(i => i.ObjectIndex == objectOrInstanceId))
                        {
                            With(instance, action);
                        }
                    }
                    else
                    {
                        if (Instances.ContainsKey(objectOrInstanceId))
                        {
                            With(Instances[objectOrInstanceId], action);
                        }
                    }
                    break;
            }
        }

        public IIndexedResource GetResourceByName(string name)
        {
            throw new NotImplementedException();
        }

        public Variant ExecuteFunction(string name, params Variant[] args)
        {
            throw new NotImplementedException();
        }

        public Func<Variant, Variant[]> GetFunctionByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}