using System;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class SoundResource : BaseResource
    {
        [Obsolete] public SoundFileType Type { get; set; }
        public SoundKind Kind { get; set; }
        public string Extension { get; set; }
        public string Filename { get; set; }
        public byte[] MusicData { get; set; }
        public bool AllowSoundEffects { get; set; }
        public int Buffers { get; set; }
        public int LoadOnlyOnUse { get; set; }
        public SoundEffects Effects { get; set; }
        public double Volume { get; set; }
        public double Pan { get; set; }
        public bool Preload { get; set; }
    }
}