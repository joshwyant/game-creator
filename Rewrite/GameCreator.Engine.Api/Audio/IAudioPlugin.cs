using System.IO;

namespace GameCreator.Engine.Api
{
    public interface IAudioPlugin
    {
        ISoundEffect LoadSound(Stream stream);
        void PlaySound(ISoundEffect sound);
    }
}