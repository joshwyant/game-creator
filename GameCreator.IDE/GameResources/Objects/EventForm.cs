using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameCreator.Framework;

namespace GameCreator.IDE
{
    partial class EventForm : Form
    {
        public EventType EventType { get; set; }
        public int EventNumber { get; set; }
        void Accept(EventType type, int num)
        {
            EventType = type;
            EventNumber = num;
            this.DialogResult = DialogResult.OK;
            Close();
        }
        public EventForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            DialogResult = DialogResult.Cancel;
        }
        private void button1_Click(object sender, EventArgs e) { Accept(EventType.Create, 0); }
        private void button3_Click(object sender, EventArgs e) { Accept(EventType.Destroy, 0); }
        private void button5_Click(object sender, EventArgs e) { contextMenuStripAlarm.Show(MousePosition); }
        private void button7_Click(object sender, EventArgs e) { contextMenuStripStep.Show(MousePosition); }
        private void button9_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ContextMenuStrip menu = new ContextMenuStrip();
            foreach (ObjectResourceView res in Program.Objects.Values)
            {
                ToolStripMenuItem collisionObjectMenuItem = new ToolStripMenuItem(res.Name);
                collisionObjectMenuItem.Tag = res;
                collisionObjectMenuItem.Click += new EventHandler(collisionObjectMenuItem_Click);
                menu.Items.Add(collisionObjectMenuItem);
            }
            menu.Show(MousePosition);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            EventType = EventType.Keyboard;
            contextMenuStripKeyboard.Show(MousePosition);
        }
        private void button2_Click(object sender, EventArgs e) { contextMenuStripMouse.Show(MousePosition); }
        private void button4_Click(object sender, EventArgs e) { contextMenuStripOther.Show(MousePosition); }
        private void button6_Click(object sender, EventArgs e) { Accept(EventType.Draw, 0); }
        private void button8_Click(object sender, EventArgs e)
        {
            EventType = EventType.KeyPress;
            contextMenuStripKeyboard.Show(MousePosition);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            EventType = EventType.KeyRelease;
            contextMenuStripKeyboard.Show(MousePosition);
        }
        private void alarm0ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 0); }
        private void alarm1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 1); }
        private void alarm2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 2); }
        private void alarm3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 3); }
        private void alarm4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 4); }
        private void alarm5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 5); }
        private void alarm6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 6); }
        private void alarm7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 7); }
        private void alarm8ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 8); }
        private void alarm9ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 9); }
        private void alarm10ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 10); }
        private void alarm11ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Alarm, 11); }
        private void stepToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Step, (int)StepEventNumber.Normal); }
        private void beginStepToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Step, (int)StepEventNumber.BeginStep); }
        private void endStepToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Step, (int)StepEventNumber.EndStep); }
        private void collisionObjectMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Collision, (int)((sender as ToolStripMenuItem).Tag as ObjectResourceView).ResourceID); }
        private void leftToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Left); }
        private void rightToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Right); }
        private void upToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Up); }
        private void downToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Down); }
        private void controlToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Control); }
        private void altToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Alt); }
        private void shiftToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Shift); }
        private void spaceToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Space); }
        private void enterToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Enter); }
        private void keypad0ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad0); }
        private void keypad1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad1); }
        private void keypad2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad2); }
        private void keypad3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad3); }
        private void keypad4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad4); }
        private void keypad5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad5); }
        private void keypad6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad6); }
        private void keypad7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad7); }
        private void keypad8ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad8); }
        private void keypad9ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NumPad9); }
        private void keypadToolStripMenuItem2_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Divide); }
        private void keypadToolStripMenuItem3_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Multiply); }
        private void keypadToolStripMenuItem4_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Subtract); }
        private void keypadToolStripMenuItem5_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Add); }
        private void keypadToolStripMenuItem6_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Decimal); }
        private void toolStripMenuItem2_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number0); }
        private void toolStripMenuItem3_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number1); }
        private void toolStripMenuItem4_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number2); }
        private void toolStripMenuItem5_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number3); }
        private void toolStripMenuItem6_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number4); }
        private void toolStripMenuItem7_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number5); }
        private void toolStripMenuItem8_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number6); }
        private void toolStripMenuItem9_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number7); }
        private void toolStripMenuItem10_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number8); }
        private void toolStripMenuItem11_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Number9); }
        private void aToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterA); }
        private void bToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterB); }
        private void cToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterC); }
        private void dToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterD); }
        private void eToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterE); }
        private void fToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterF); }
        private void gToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterG); }
        private void hToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterH); }
        private void iToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterI); }
        private void jToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterJ); }
        private void kToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterK); }
        private void lToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterL); }
        private void mToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterM); }
        private void nToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterN); }
        private void oToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterO); }
        private void pToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterP); }
        private void qToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterQ); }
        private void rToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterR); }
        private void sToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterS); }
        private void tToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterT); }
        private void uToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterU); }
        private void vToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterV); }
        private void wToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterW); }
        private void xToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterX); }
        private void yToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterY); }
        private void zToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.LetterZ); }
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F1); }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F2); }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F3); }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F4); }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F5); }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F6); }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F7); }
        private void f8ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F8); }
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F9); }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F10); }
        private void f11ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F11); }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.F12); }
        private void backspaceToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Backspace); }
        private void escapeToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Escape); }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Home); }
        private void endToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.End); }
        private void pageUpToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.PageUp); }
        private void pageDownToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.PageDown); }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Delete); }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.Insert); }
        private void anyKeyToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.AnyKey); }
        private void noKeyToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType, (int)VirtualKeyCode.NoKey); }
        private void leftButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.LeftButton); }
        private void rightButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.RightButton); }
        private void middleButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MiddleButton); }
        private void noButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.NoButton); }
        private void leftPressedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.LeftPress); }
        private void rightPressedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.RightPress); }
        private void middlePressedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MiddlePress); }
        private void leftReleasedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.LeftRelease); }
        private void rightReleasedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.RightRelease); }
        private void middleReleasedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MiddleRelease); }
        private void mouseEnterToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MouseEnter); }
        private void mouseLeaveToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MouseLeave); }
        private void mouseWheelUpToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MouseWheelUp); }
        private void mouseWheelDownToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.MouseWheelDown); }
        private void globalLeftButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalLeftButton); }
        private void globalRightButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalRightButton); }
        private void globalMiddleButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalMiddleButton); }
        private void globalLeftPressedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalLeftPress); }
        private void globalRightPressedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalRightPress); }
        private void globalMiddlePressedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalMiddlePress); }
        private void globalLeftReleasedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalLeftRelease); }
        private void globalRightReleasedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalRightRelease); }
        private void globalMiddleReleasedToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.GlobalMiddleRelease); }
        private void joystick1LeftToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Left); }
        private void joystick1RightToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Right); }
        private void joystick1UpToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Up); }
        private void joystick1DownToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Down); }
        private void joystick1Button1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button1); }
        private void joystick1Button2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button2); }
        private void joystick1Button3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button3); }
        private void joystick1Button4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button4); }
        private void joystick1Button5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button5); }
        private void joystick1Button6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button6); }
        private void joystick1Button7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button7); }
        private void joystick1Button8ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick1Button8); }
        private void joystick2LeftToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Left); }
        private void joystick2RightToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Right); }
        private void joystick2UpToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Up); }
        private void joystick2DownToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Down); }
        private void joystick2Button1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button1); }
        private void joystick2Button2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button2); }
        private void joystick2Button3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button3); }
        private void joystick2Button4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button4); }
        private void joystick2Button5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button5); }
        private void joystick2Button6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button6); }
        private void joystick2Button7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button7); }
        private void joystick2Button8ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Mouse, (int)MouseEventNumber.Joystick2Button8); }
        private void outsideRoomToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.Outside); }
        private void intersectBoundaryRoomToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.Boundary); }
        private void outsideView0ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView0); }
        private void outsideView1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView1); }
        private void outsideView2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView2); }
        private void outsideView3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView3); }
        private void outsideView4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView4); }
        private void outsideView5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView5); }
        private void outsideView6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView6); }
        private void outsideView7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.OutsideView7); }
        private void boundaryView0ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView0); }
        private void boundaryView1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView1); }
        private void boundaryView2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView2); }
        private void boundaryView3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView3); }
        private void boundaryView4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView4); }
        private void boundaryView5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView5); }
        private void boundaryView6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView6); }
        private void boundaryView7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.BoundaryView7); }
        private void gameStartToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.GameStart); }
        private void gameEndToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.GameEnd); }
        private void roomStartToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.RoomStart); }
        private void roomEndToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.RoomEnd); }
        private void noMoreLivesToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.NoMoreLives); }
        private void noMoreHealthToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.NoMoreHealth); }
        private void animationEndToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.AnimationEnd); }
        private void endOfPathToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.EndOfPath); }
        private void closeButtonToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.CloseButton); }
        private void user0ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User0); }
        private void user1ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User1); }
        private void user2ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User2); }
        private void user3ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User3); }
        private void user4ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User4); }
        private void user5ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User5); }
        private void user6ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User6); }
        private void user7ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User7); }
        private void user8ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User8); }
        private void user9ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User9); }
        private void user10ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User10); }
        private void user11ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User11); }
        private void user12ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User12); }
        private void user13ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User13); }
        private void user14ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User14); }
        private void user15ToolStripMenuItem_Click(object sender, EventArgs e) { Accept(EventType.Other, (int)OtherEventNumber.User15); }
    }
}
