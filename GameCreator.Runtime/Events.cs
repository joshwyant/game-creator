using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Input;

namespace GameCreator.Framework
{
    public class MouseEvents
    {
        public static string[] Names { get { return names; } }
        static string[] names = new string[] {
            #region Values
            "Left Button",
            "Right Button",
            "Middle Button",
            "No Button",
            "Left Pressed",
            "Right Pressed",
            "Middle Pressed",
            "Left Released",
            "Right Released",
            "Middle Released",
            "Mouse Enter",
            "Mouse Leave",
            null,
            null,
            null,
            null,
            "Joystick 1 Left",
            "Joystick 1 Right",
            "Joystick 1 Up",
            "Joystick 1 Down",
            null,
            "Joystick 1 Button 1",
            "Joystick 1 Button 2",
            "Joystick 1 Button 3",
            "Joystick 1 Button 4",
            "Joystick 1 Button 5",
            "Joystick 1 Button 6",
            "Joystick 1 Button 7",
            "Joystick 1 Button 8",
            null,
            null,
            "Joystick 2 Left",
            "Joystick 2 Right",
            "Joystick 2 Up",
            "Joystick 2 Down",
            null,
            "Joystick 2 Button 1",
            "Joystick 2 Button 2",
            "Joystick 2 Button 3",
            "Joystick 2 Button 4",
            "Joystick 2 Button 5",
            "Joystick 2 Button 6",
            "Joystick 2 Button 7",
            "Joystick 2 Button 8",
            null,
            null,
            null,
            null,
            null,
            null,
            "Global Left Button",
            "Global Right Button",
            "Global Middle Button",
            "Global Left Pressed",
            "Global Right Pressed",
            "Global Middle Pressed",
            "Global Left Released",
            "Global Right Released",
            "Global Middle Released",
            null,
            "Mouse Wheel Up",
            "Mouse Wheel Down",
            #endregion
        };
    }
    public class StepEvents
    {
        public static string[] Names { get { return names; } }
        static string[] names = new string[] {
            "Step",
            "Begin Step",
            "End Step",
        };
    }
    public class OtherEvents
    {
        public static string[] Names { get { return names; } }
        static string[] names = new string[] {
                    #region Values
                    "Outside Room",
                    "Intersect Boundary",
                    "Game Start",
                    "Game End",
                    "Room Start",
                    "Room End",
                    "No More Lives",
                    "Animation End",
                    "End of Path",
                    "No More Health",
                    "User Defined 0",
                    "User Defined 1",
                    "User Defined 2",
                    "User Defined 3",
                    "User Defined 4",
                    "User Defined 5",
                    "User Defined 6",
                    "User Defined 7",
                    "User Defined 8",
                    "User Defined 9",
                    "User Defined 10",
                    "User Defined 11",
                    "User Defined 12",
                    "User Defined 13",
                    "User Defined 14",
                    "User Defined 15",
                    null,
                    null,
                    null,
                    null,
                    "Close Button",
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    "Outside View 0",
                    "Outside View 1",
                    "Outside View 2",
                    "Outside View 3",
                    "Outside View 4",
                    "Outside View 5",
                    "Outside View 6",
                    "Outside View 7",
                    null,
                    null,
                    "Boundary View 0",
                    "Boundary View 1",
                    "Boundary View 2",
                    "Boundary View 3",
                    "Boundary View 4",
                    "Boundary View 5",
                    "Boundary View 6",
                    "Boundary View 7",
                    #endregion
        };
    }
    public enum EventType : int
    {
        Create = 0,
        Destroy = 1,
        Step = 3,
        Alarm = 2,
        Keyboard = 5,
        Mouse = 6,
        Collision = 4,
        Other = 7,
        Draw = 8,
        KeyPress = 9,
        KeyRelease = 10,
        Trigger = 11,
    }
    public enum MouseEventNumber : int
    {
        LeftButton = 0,
        RightButton = 1,
        MiddleButton = 2,
        NoButton = 3,
        LeftPress = 4,
        RightPress = 5,
        MiddlePress = 6,
        LeftRelease = 7,
        RightRelease = 8,
        MiddleRelease = 9,
        MouseEnter = 10,
        MouseLeave = 11,
        MouseWheelUp = 60,
        MouseWheelDown = 61,
        GlobalLeftButton = 50,
        GlobalRightButton = 51,
        GlobalMiddleButton = 52,
        GlobalLeftPress = 53,
        GlobalRightPress = 54,
        GlobalMiddlePress = 55,
        GlobalLeftRelease = 56,
        GlobalRightRelease = 57,
        GlobalMiddleRelease = 58,
        Joystick1Left = 16,
        Joystick1Right = 17,
        Joystick1Up = 18,
        Joystick1Down = 19,
        Joystick1Button1 = 21,
        Joystick1Button2 = 22,
        Joystick1Button3 = 23,
        Joystick1Button4 = 24,
        Joystick1Button5 = 25,
        Joystick1Button6 = 26,
        Joystick1Button7 = 27,
        Joystick1Button8 = 28,
        Joystick2Left = 31,
        Joystick2Right = 32,
        Joystick2Up = 33,
        Joystick2Down = 34,
        Joystick2Button1 = 36,
        Joystick2Button2 = 37,
        Joystick2Button3 = 38,
        Joystick2Button4 = 39,
        Joystick2Button5 = 40,
        Joystick2Button6 = 41,
        Joystick2Button7 = 42,
        Joystick2Button8 = 43,
    }
    public enum OtherEventNumber : int
    {
        Outside = 0,
        Boundary = 1,
        GameStart = 2,
        GameEnd = 3,
        RoomStart = 4,
        RoomEnd = 5,
        NoMoreLives = 6,
        NoMoreHealth = 9,
        AnimationEnd = 7,
        EndOfPath = 8,
        CloseButton = 30,
        User0 = 10,
        User1 = 11,
        User2 = 12,
        User3 = 13,
        User4 = 14,
        User5 = 15,
        User6 = 16,
        User7 = 17,
        User8 = 18,
        User9 = 19,
        User10 = 20,
        User11 = 21,
        User12 = 22,
        User13 = 23,
        User14 = 24,
        User15 = 25,
        OutsideView0 = 40,
        OutsideView1 = 41,
        OutsideView2 = 42,
        OutsideView3 = 43,
        OutsideView4 = 44,
        OutsideView5 = 45,
        OutsideView6 = 46,
        OutsideView7 = 47,
        BoundaryView0 = 50,
        BoundaryView1 = 51,
        BoundaryView2 = 52,
        BoundaryView3 = 53,
        BoundaryView4 = 54,
        BoundaryView5 = 55,
        BoundaryView6 = 56,
        BoundaryView7 = 57,
    }
    public enum StepEventNumber : int
    {
        Normal,
        BeginStep,
        EndStep,
    }
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
    public enum VirtualKeyCode : int
    {
        NoKey = 0,
        AnyKey = 1,
        Left = 37,
        Right = 39,
        Up = 38,
        Down = 40,
        Enter = 13,
        Escape = 27,
        Space = 32,
        Shift = 16,
        Control = 17,
        Alt = 18,
        Backspace = 8,
        Tab = 9,
        Home = 36,
        End = 35,
        Delete = 46,
        Insert = 45,
        PageUp = 33,
        PageDown = 34,
        Pause = 19,
        PrintScreen = 44,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Divide = 111,
        Add = 107,
        Subtract = 109,
        Decimal = 110,
        LShift = 160,
        LControl = 162,
        LAlt = 164,
        RShift = 161,
        RControl = 163,
        RAlt = 165,
        Number0 = 0x30,
        Number1 = 0x31,
        Number2 = 0x32,
        Number3 = 0x33,
        Number4 = 0x34,
        Number5 = 0x35,
        Number6 = 0x36,
        Number7 = 0x37,
        Number8 = 0x38,
        Number9 = 0x39,
        LetterA = 0x41,
        LetterB = 0x42,
        LetterC = 0x43,
        LetterD = 0x44,
        LetterE = 0x45,
        LetterF = 0x46,
        LetterG = 0x47,
        LetterH = 0x48,
        LetterI = 0x49,
        LetterJ = 0x4A,
        LetterK = 0x4B,
        LetterL = 0x4C,
        LetterM = 0x4D,
        LetterN = 0x4E,
        LetterO = 0x4F,
        LetterP = 0x50,
        LetterQ = 0x51,
        LetterR = 0x52,
        LetterS = 0x53,
        LetterT = 0x54,
        LetterU = 0x55,
        LetterV = 0x56,
        LetterW = 0x57,
        LetterX = 0x58,
        LetterY = 0x59,
        LetterZ = 0x5A,
    }

}
