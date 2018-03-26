using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class Project
    {
        public ProjectResourceManager<SpriteResource> Sprites { get; }
        public ProjectResourceManager<SoundResource> Sounds { get; }
        public ProjectResourceManager<BackgroundResource> Backgrounds { get; }
        public ProjectResourceManager<PathResource> Paths { get; }
        public ProjectResourceManager<ScriptResource> Scripts { get; }
        public ProjectResourceManager<FontResource> Fonts { get; }
        public ProjectResourceManager<DataFileResource> DataFiles { get; }
        public ProjectResourceManager<TimelineResource> Timelines { get; }
        public ProjectResourceManager<ObjectResource> Objects { get; }
        public ProjectResourceManager<RoomResource> Rooms { get; }
        public IndexedResourceManager<InstanceResource> Instances { get; }

        public Project()
        {
            Sprites = new ProjectResourceManager<SpriteResource>("sprite");
            Sounds = new ProjectResourceManager<SoundResource>("sound");
            Backgrounds = new ProjectResourceManager<BackgroundResource>("background");
            Paths = new ProjectResourceManager<PathResource>("path");
            Scripts = new ProjectResourceManager<ScriptResource>("script");
            Fonts = new ProjectResourceManager<FontResource>("font");
            DataFiles = new ProjectResourceManager<DataFileResource>("data");
            Timelines = new ProjectResourceManager<TimelineResource>("timeline");
            Objects = new ProjectResourceManager<ObjectResource>("object");
            Rooms = new ProjectResourceManager<RoomResource>("room");
            Instances = new IndexedResourceManager<InstanceResource>(100001);
        }
    }
}