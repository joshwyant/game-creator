using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Contracts.Services
{
    public class GameInformation
    {
        public bool AlwaysOnTop { get; set; }
        public int BackgroundColor { get; set; }
        public string FormCaption { get; set; }
        public bool FormResizable { get; set; }
        public int Height { get; set; }
        public bool MimicMainForm { get; set; }
        public bool PauseGame { get; set; }
        public string Rtf { get; set; }
        public bool ShowBorderAndCaption { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
