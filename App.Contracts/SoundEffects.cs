using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Contracts
{
    [Flags]
    public enum SoundEffects
    {
        None = 0x0,
        Chorus = 0x1,
        Echo = 0x2,
        Flange = 0x4,
        Gargle = 0x8,
        Reverb = 0x10
    }
}
