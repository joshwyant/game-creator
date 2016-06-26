namespace App.Contracts
{
    /// <summary>
    /// Interface for a sound resource.
    /// </summary>
    public interface IAppSound : INamedIndexedResource
    {
        bool AllowSoundEffects { get; set; }
        int Buffers { get; set; }
        SoundEffects Effects { get; set; }
        string Extension { get; set; }
        string Filename { get; set; }
        SoundKind Kind { get; set; }
        int LoadOnlyOnUse { get; set; }
        byte[] MusicData { get; set; }
        double Pan { get; set; }
        bool Preload { get; set; }
        SoundFileType Type { get; set; }
        double Volume { get; set; }
    }
}
