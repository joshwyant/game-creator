using GameCreator.Api.Engine;
using Microsoft.Xna.Framework.Audio;

namespace GameCreator.Plugins.MonoGame
{
    public class SoundInfo : ISoundEffect
    {
        public SoundEffect SoundEffect { get; }
        
        public SoundInfo(SoundEffect soundEffect)
        {
            SoundEffect = soundEffect;
        }
    }
}