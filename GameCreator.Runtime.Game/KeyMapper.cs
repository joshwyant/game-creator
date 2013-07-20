using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Input;
using GameCreator.Framework;

namespace GameCreator.Runtime.Game
{
    public class KeyMapper
    {
        static Dictionary<VirtualKeyCode, OpenTK.Input.Key> reverse;
        static Dictionary<OpenTK.Input.Key, VirtualKeyCode> lookup;
        static KeyMapper()
        {
            reverse = new Dictionary<VirtualKeyCode, OpenTK.Input.Key>();
            lookup = new Dictionary<OpenTK.Input.Key, VirtualKeyCode>();
            Map(VirtualKeyCode.Escape, Key.Escape);
            // F1-F12
            for (int i = 0; i < 24; i++)
                Map((VirtualKeyCode)(112 + i), (Key)(10 + i));
            // Digits
            for (int j = 0; j <= 9; j++)
                Map((VirtualKeyCode)(48 + j), (Key)(109 + j));
            // Letters
            for (int k = 0; k < 26; k++)
                Map((VirtualKeyCode)(65 + k), (Key)(83 + k));
            Map(VirtualKeyCode.Tab, Key.Tab);
            //Map(VirtualKeyCode.CapsLock, Key.CapsLock);
            Map(VirtualKeyCode.LControl, Key.ControlLeft);
            Map(VirtualKeyCode.LShift, Key.ShiftLeft);
            //Map(VirtualKeyCode.LWin, Key.WinLeft);
            //Map(VirtualKeyCode.LMenu, Key.AltLeft);
            Map(VirtualKeyCode.Space, Key.Space);
            //Map(VirtualKeyCode.RMenu, Key.AltRight);
            //Map(VirtualKeyCode.RWin, Key.WinRight);
            //Map(VirtualKeyCode.Apps, Key.Menu);
            Map(VirtualKeyCode.RControl, Key.ControlRight);
            Map(VirtualKeyCode.RShift, Key.ShiftRight);
            Map(VirtualKeyCode.Enter, Key.Enter);
            Map(VirtualKeyCode.Backspace, Key.BackSpace);
            //Map(VirtualKeyCode.OEM_1, Key.Semicolon);
            //Map(VirtualKeyCode.OEM_2, Key.Slash);
            //Map(VirtualKeyCode.OEM_3, Key.Tilde);
            //Map(VirtualKeyCode.OEM_4, Key.BracketLeft);
            //Map(VirtualKeyCode.OEM_5, Key.BackSlash);
            //Map(VirtualKeyCode.OEM_6, Key.BracketRight);
            //Map(VirtualKeyCode.OEM_7, Key.Quote);
            //Map(VirtualKeyCode.OEM_PLUS, Key.Plus);
            //Map(VirtualKeyCode.OEM_COMMA, Key.Comma);
            //Map(VirtualKeyCode.OEM_MINUS, Key.Minus);
            //Map(VirtualKeyCode.OEM_PERIOD, Key.Period);
            Map(VirtualKeyCode.Home, Key.Home);
            Map(VirtualKeyCode.End, Key.End);
            Map(VirtualKeyCode.Delete, Key.Delete);
            Map(VirtualKeyCode.PageUp, Key.PageUp);
            Map(VirtualKeyCode.PageDown, Key.PageDown);
            Map(VirtualKeyCode.PrintScreen, Key.PrintScreen);
            Map(VirtualKeyCode.Pause, Key.Pause);
            //Map(VirtualKeyCode.NumLock, Key.NumLock);
            //Map(VirtualKeyCode.ScrollLock, Key.ScrollLock);
            //Map(VirtualKeyCode.SNAPSHOT, Key.PrintScreen);
            //Map(VirtualKeyCode.Clear, Key.Clear);
            Map(VirtualKeyCode.Insert, Key.Insert);
            //Map(VirtualKeyCode.Sleep, Key.Sleep);
            // Keypad
            for (int m = 0; m <= 9; m++)
                Map((VirtualKeyCode)(96 + m), (Key)(67 + m));
            Map(VirtualKeyCode.Decimal, Key.KeypadDecimal);
            Map(VirtualKeyCode.Add, Key.KeypadAdd);
            Map(VirtualKeyCode.Subtract, Key.KeypadSubtract);
            Map(VirtualKeyCode.Divide, Key.KeypadDivide);
            Map(VirtualKeyCode.Multiply, Key.KeypadMultiply);
            Map(VirtualKeyCode.Up, Key.Up);
            Map(VirtualKeyCode.Down, Key.Down);
            Map(VirtualKeyCode.Left, Key.Left);
            Map(VirtualKeyCode.Right, Key.Right);
        }
        static void Map(VirtualKeyCode a, OpenTK.Input.Key b)
        {
            reverse.Add(a, b);
            lookup.Add(b, a);
        }
        public static VirtualKeyCode GetMap(Key key)
        {
            return lookup.ContainsKey(key) ? lookup[key] : VirtualKeyCode.NoKey;
        }
        public static Key GetMap(VirtualKeyCode key)
        {
            return reverse.ContainsKey(key) ? reverse[key] : (Key)0;
        }
    }
}
