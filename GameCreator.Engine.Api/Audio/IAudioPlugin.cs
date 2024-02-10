using System.IO;

namespace GameCreator.Api.Engine
{
    public interface IAudioPlugin
    {
        ISoundEffect LoadSound(Stream stream);
        void PlaySound(ISoundEffect sound);
    }
}