using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace GameCreator.Framework
{
    public static class C
    {
        /// <summary>
        /// If compiled with .NET 4.5, this will have the same value as System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining.
        /// </summary>
        public const MethodImplOptions MethodImplOptions_AggressiveInlining = (MethodImplOptions)0x00000100;
    }
}
