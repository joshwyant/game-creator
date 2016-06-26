using App.Contracts;

namespace App.Resources
{
    public class AppSound : NamedResource, IAppSound
    {
        public override string DefaultPrefix { get { return "sound"; } }

        public bool AllowSoundEffects { get; set; }
        public int Buffers { get; set; }
        public SoundEffects Effects { get; set; }
        public string Extension { get; set; }
        public string Filename { get; set; }
        public SoundKind Kind { get; set; }
        public int LoadOnlyOnUse { get; set; }
        public byte[] MusicData { get; set; }
        public double Pan { get; set; }
        public bool Preload { get; set; }
        public SoundFileType Type { get; set; }
        public double Volume { get; set; }
    }
}
