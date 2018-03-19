using System.Collections.Generic;
using GameCreator.Core;
using Microsoft.Xna.Framework.Input;

namespace GameCreator.Plugins.MonoGame
{
    public static class KeyMapper
    {
        private static readonly Dictionary<VirtualKeyCode, Keys> Reverse;
        private static readonly Dictionary<Keys, VirtualKeyCode> Lookup;

        static KeyMapper()
        {
            Reverse = new Dictionary<VirtualKeyCode, Keys>();
            Lookup = new Dictionary<Keys, VirtualKeyCode>();
            
            Map(VirtualKeyCode.Left, Keys.Left);
            Map(VirtualKeyCode.Right, Keys.Right);
            Map(VirtualKeyCode.Up, Keys.Up);
            Map(VirtualKeyCode.Down, Keys.Down);
            Map(VirtualKeyCode.Enter, Keys.Enter);
            Map(VirtualKeyCode.Escape, Keys.Escape);
            Map(VirtualKeyCode.Space, Keys.Space);
            Map(VirtualKeyCode.LShift, Keys.LeftShift);
            Map(VirtualKeyCode.RShift, Keys.RightShift);
            Map(VirtualKeyCode.LControl, Keys.LeftControl);
            Map(VirtualKeyCode.RControl, Keys.RightControl);
            Map(VirtualKeyCode.LAlt, Keys.LeftAlt);
            Map(VirtualKeyCode.RAlt, Keys.RightAlt);
            Map(VirtualKeyCode.Backspace, Keys.Back);
            Map(VirtualKeyCode.Tab, Keys.Tab);
            Map(VirtualKeyCode.Home, Keys.Home);
            Map(VirtualKeyCode.End, Keys.End);
            Map(VirtualKeyCode.Delete, Keys.Delete);
            Map(VirtualKeyCode.Insert, Keys.Insert);
            Map(VirtualKeyCode.PageUp, Keys.PageUp);
            Map(VirtualKeyCode.PageDown, Keys.PageDown);
            Map(VirtualKeyCode.Pause, Keys.Pause);
            Map(VirtualKeyCode.PrintScreen, Keys.PrintScreen);
            // F1-F24
            for (var i = 0; i < 24; i++)
            {
                Map((VirtualKeyCode) (112 + i), Keys.F1 + i);
            }
            // Keypad
            for (int m = 0; m <= 9; m++)
            {
                Map((VirtualKeyCode) (96 + m), Keys.NumPad0 + m);
            }
            Map(VirtualKeyCode.Multiply, Keys.Multiply);
            Map(VirtualKeyCode.Divide, Keys.Divide);
            Map(VirtualKeyCode.Add, Keys.Add);
            Map(VirtualKeyCode.Subtract, Keys.Subtract);
            Map(VirtualKeyCode.Decimal, Keys.Decimal);
            // Letters
            for (var k = 0; k < 26; k++)
            {
                Map((VirtualKeyCode) (65 + k), Keys.A + k);
            }
            // Digits
            for (var j = 0; j <= 9; j++)
            {
                Map((VirtualKeyCode) (48 + j), Keys.D0 + j);
            }
        }

        static void Map(VirtualKeyCode a, Keys b)
        {
            Reverse.Add(a, b);
            Lookup.Add(b, a);
        }

        public static VirtualKeyCode GetMap(Keys key)
        {
            return Lookup.ContainsKey(key) ? Lookup[key] : VirtualKeyCode.NoKey;
        }

        public static Keys GetMap(VirtualKeyCode key)
        {
            return Reverse.ContainsKey(key) ? Reverse[key] : 0;
        }
    }
}