using System.Collections.Generic;
using GameCreator.Core;
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
            Map(VirtualKeyCode.Escape, Key.Escape);
            // F1-F24
            for (var i = 0; i < 24; i++)
            {
                Map((VirtualKeyCode) (112 + i), (Key) (10 + i));
            }
            // Digits
            for (var j = 0; j <= 9; j++)
            {
                Map((VirtualKeyCode) (48 + j), (Key) (109 + j));
            }
            // Letters
            for (var k = 0; k < 26; k++)
            {
                Map((VirtualKeyCode) (65 + k), (Key) (83 + k));
            }
            Map(VirtualKeyCode.Tab, Key.Tab);
            Map(VirtualKeyCode.LControl, Key.ControlLeft);
            Map(VirtualKeyCode.LShift, Key.ShiftLeft);
            Map(VirtualKeyCode.LAlt, Key.AltLeft);
            Map(VirtualKeyCode.Space, Key.Space);
            Map(VirtualKeyCode.RControl, Key.ControlRight);
            Map(VirtualKeyCode.RShift, Key.ShiftRight);
            Map(VirtualKeyCode.RAlt, Key.AltRight);
            Map(VirtualKeyCode.Enter, Key.Enter);
            Map(VirtualKeyCode.Backspace, Key.BackSpace);
            Map(VirtualKeyCode.Home, Key.Home);
            Map(VirtualKeyCode.End, Key.End);
            Map(VirtualKeyCode.Delete, Key.Delete);
            Map(VirtualKeyCode.PageUp, Key.PageUp);
            Map(VirtualKeyCode.PageDown, Key.PageDown);
            Map(VirtualKeyCode.PrintScreen, Key.PrintScreen);
            Map(VirtualKeyCode.Pause, Key.Pause);
            Map(VirtualKeyCode.Insert, Key.Insert);
            // Keypad
            for (var m = 0; m <= 9; m++)
            {
                Map((VirtualKeyCode) (96 + m), (Key) (67 + m));
            }
            Map(VirtualKeyCode.Decimal, Key.KeypadDecimal);
            Map(VirtualKeyCode.Add, Key.KeypadAdd);
            Map(VirtualKeyCode.Subtract, Key.KeypadSubtract);
            Map(VirtualKeyCode.Divide, Key.KeypadDivide);
            Map(VirtualKeyCode.Multiply, Key.KeypadMultiply);
            Map(VirtualKeyCode.Up, Key.Up);
            Map(VirtualKeyCode.Down, Key.Down);
            Map(VirtualKeyCode.Left, Key.Left);
            Map(VirtualKeyCode.Right, Key.Right);
            // TODO: More keycodes
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