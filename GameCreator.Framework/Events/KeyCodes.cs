using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Input;

namespace GameCreator.Framework
{
    public class KeyCodes
    {
        static Dictionary<VirtualKeyCode, OpenTK.Input.Key> reverse;
        static Dictionary<OpenTK.Input.Key, VirtualKeyCode> lookup;
        static KeyCodes()
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
        public static string[] Names { get { return names; } }
        static string[] names = new string[] {
        #region Values
            "<no key>",
            "<any key>",
            null,
            null,
            null,
            null,
            null,
            null,
            "<Backspace>",
            "<Tab>",
            null,
            null,
            null,
            "<Enter>",
            null,
            null,
            "<Shift>",
            "<Ctrl>",
            "<Alt>",
            "<Pause>",
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            "<Escape>",
            null,
            null,
            null,
            null,
            "<Space>",
            "<Page Up>",
            "<Page Down>",
            "<End>",
            "<Home>",
            "<Left>",
            "<Up>",
            "<Right>",
            "<Down>",
            null,
            null,
            null,
            "<Print Screen>",
            "<Insert>",
            "<Delete>",
            null,
            "0-key",
            "1-key",
            "2-key",
            "3-key",
            "4-key",
            "5-key",
            "6-key",
            "7-key",
            "8-key",
            "9-key",
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            "A-key",
            "B-key",
            "C-key",
            "D-key",
            "E-key",
            "F-key",
            "G-key",
            "H-key",
            "I-key",
            "J-key",
            "K-key",
            "L-key",
            "M-key",
            "N-key",
            "O-key",
            "P-key",
            "Q-key",
            "R-key",
            "S-key",
            "T-key",
            "U-key",
            "V-key",
            "W-key",
            "X-key",
            "Y-key",
            "Z-key",
            null,
            null,
            null,
            null,
            null,
            "Keypad 0",
            "Keypad 1",
            "Keypad 2",
            "Keypad 3",
            "Keypad 4",
            "Keypad 5",
            "Keypad 6",
            "Keypad 7",
            "Keypad 8",
            "Keypad 9",
            "Keypad *",
            "Keypad +",
            null,
            "Keypad -",
            "Keypad .",
            "Keypad /",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            "<Left Shift>",
            "<Right Shift>",
            "<Left Ctrl>",
            "<Right Ctrl>",
            "<Left Alt>",
            "<Right Alt>",
        #endregion
        };
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
