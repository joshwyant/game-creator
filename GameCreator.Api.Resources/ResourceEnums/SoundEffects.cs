using System;

namespace GameCreator.Api.Resources
{
    [Flags]
    public enum SoundEffects
    {
        None = 0,
        Chorus = 1,
        Echo = 1 << 1,
        Flange = 1 << 2,
        Gargle = 1 << 3,
        Reverb = 1 << 4
    }
}