using System.Collections.Generic;
using GameCreator.Engine.Common;
using OpenTK.Input;

namespace GameCreator.Plugins.OpenTK
{
    public static class KeyMapper
    {
        private static readonly Dictionary<VirtualKeyCode, Key> Reverse;
        private static readonly Dictionary<Key, VirtualKeyCode> Lookup;

        static KeyMapper()
        {
            Reverse = new Dictionary<VirtualKeyCode, Key>();
            Lookup = new Dictionary<Key, VirtualKeyCode>();
            
            Map(VirtualKeyCode.Left, Key.Left);
            Map(VirtualKeyCode.Right, Key.Right);
            Map(VirtualKeyCode.Up, Key.Up);
            Map(VirtualKeyCode.Down, Key.Down);
            Map(VirtualKeyCode.Enter, Key.Enter);
            Map(VirtualKeyCode.Escape, Key.Escape);
            Map(VirtualKeyCode.Space, Key.Space);
            Map(VirtualKeyCode.LShift, Key.LShift);
            Map(VirtualKeyCode.RShift, Key.RShift);
            Map(VirtualKeyCode.LControl, Key.LControl);
            Map(VirtualKeyCode.RControl, Key.RControl);
            Map(VirtualKeyCode.LAlt, Key.LAlt);
            Map(VirtualKeyCode.RAlt, Key.RAlt);
            Map(VirtualKeyCode.Backspace, Key.Back);
            Map(VirtualKeyCode.Tab, Key.Tab);
            Map(VirtualKeyCode.Home, Key.Home);
            Map(VirtualKeyCode.End, Key.End);
            Map(VirtualKeyCode.Delete, Key.Delete);
            Map(VirtualKeyCode.Insert, Key.Insert);
            Map(VirtualKeyCode.PageUp, Key.PageUp);
            Map(VirtualKeyCode.PageDown, Key.PageDown);
            Map(VirtualKeyCode.Pause, Key.Pause);
            Map(VirtualKeyCode.PrintScreen, Key.PrintScreen);
            // F1-F24
            for (var i = 0; i < 24; i++)
            {
                Map((VirtualKeyCode) (112 + i), Key.F1 + i);
            }
            // Keypad
            for (var m = 0; m <= 9; m++)
            {
                Map((VirtualKeyCode) (96 + m), Key.Keypad0 + m);
            }
            Map(VirtualKeyCode.Multiply, Key.KeypadMultiply);
            Map(VirtualKeyCode.Divide, Key.KeypadDivide);
            Map(VirtualKeyCode.Add, Key.KeypadAdd);
            Map(VirtualKeyCode.Subtract, Key.KeypadSubtract);
            Map(VirtualKeyCode.Decimal, Key.KeypadDecimal);
            // Letters
            for (var k = 0; k < 26; k++)
            {
                Map((VirtualKeyCode) (65 + k), Key.A + k);
            }
            // Digits
            for (var j = 0; j <= 9; j++)
            {
                Map((VirtualKeyCode) (48 + j), Key.Number0 + j);
            }
        }

        static void Map(VirtualKeyCode a, Key b)
        {
            Reverse.Add(a, b);
            Lookup.Add(b, a);
        }

        public static VirtualKeyCode GetMap(Key key)
        {
            return Lookup.ContainsKey(key) ? Lookup[key] : VirtualKeyCode.NoKey;
        }

        public static Key GetMap(VirtualKeyCode key)
        {
            return Reverse.ContainsKey(key) ? Reverse[key] : 0;
        }
    }
}