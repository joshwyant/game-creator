using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    static class Program
    {
        public static DesignerForm IDE { get; private set; }
        public static bool GameModified { get; set; }
        public static int SpriteIncremental { get; set; }
        public static int SoundIncremental { get; set; }
        public static int BackgroundIncremental { get; set; }
        public static int PathIncremental { get; set; }
        public static int ScriptIncremental { get; set; }
        public static int FontIncremental { get; set; }
        public static int DataFileIncremental { get; set; }
        public static int TimeLineIncremental { get; set; }
        public static int ObjectIncremental { get; set; }
        public static int RoomIncremental { get; set; }
        public static Dictionary<int, SpriteResourceView> Sprites { get; private set; }
        public static Dictionary<int, SoundResourceView> Sounds { get; private set; }
        public static Dictionary<int, BackgroundResourceView> Backgrounds { get; private set; }
        public static Dictionary<int, PathResourceView> Paths { get; private set; }
        public static Dictionary<int, ScriptResourceView> Scripts { get; private set; }
        public static Dictionary<int, FontResourceView> Fonts { get; private set; }
        public static Dictionary<int, DataFileResourceView> DataFiles { get; private set; }
        public static Dictionary<int, TimeLineResourceView> TimeLines { get; private set; }
        public static Dictionary<int, ObjectResourceView> Objects { get; private set; }
        public static Dictionary<int, RoomResourceView> Rooms { get; private set; }
        public static List<ActionLibrary> Library { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            // Set the Program Properties
            SpriteIncremental = 0;
            SoundIncremental = 0;
            BackgroundIncremental = 0;
            PathIncremental = 0;
            ScriptIncremental = 0;
            FontIncremental = 0;
            DataFileIncremental = 0;
            TimeLineIncremental = 0;
            ObjectIncremental = 0;
            RoomIncremental = 0;
            Sprites = new Dictionary<int, SpriteResourceView>();
            Sounds = new Dictionary<int, SoundResourceView>();
            Backgrounds = new Dictionary<int, BackgroundResourceView>();
            Paths = new Dictionary<int, PathResourceView>();
            Scripts = new Dictionary<int, ScriptResourceView>();
            Fonts = new Dictionary<int, FontResourceView>();
            DataFiles = new Dictionary<int, DataFileResourceView>();
            TimeLines = new Dictionary<int, TimeLineResourceView>();
            Objects = new Dictionary<int, ObjectResourceView>();
            Rooms = new Dictionary<int, RoomResourceView>();
            Library = new List<ActionLibrary>();
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibMove)));
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibMain1)));
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibMain2)));
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibControl)));
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibScore)));
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibExtra)));
            Library.Add(ActionLibrary.Load(new System.IO.MemoryStream(Properties.Resources.LibDraw)));
            IDE = new DesignerForm();
            // Load the settings
            if (!Properties.Settings.Default.WindowDefault)
            {
                bool maximized = Properties.Settings.Default.WindowMaximized;
                IDE.StartPosition = FormStartPosition.Manual;
                IDE.Location = new System.Drawing.Point(Math.Max(0, Properties.Settings.Default.WindowX), Math.Max(0, Properties.Settings.Default.WindowY));
                IDE.Size = new System.Drawing.Size(Properties.Settings.Default.WindowWidth, Properties.Settings.Default.WindowHeight);
                if (maximized)
                    IDE.WindowState = FormWindowState.Maximized;
            }
            // Run GameCreator
            Application.Run(IDE);
            Properties.Settings.Default.Save();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, IDE.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
