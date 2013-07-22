using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;
using System.Linq;

namespace GameCreator.Runtime.Game
{
    public static class Game
    {
        public static string Name { get; set; }
        public static System.Resources.ResourceManager ResourceManager { get; set; }
        //internal static GameForm roomform;
        internal static GameWindow roomwindow;

        public static event Action<Room> InitRoom;

        internal static void CallInitRoom(Room room)
        {
            if (InitRoom != null)
                InitRoom(room);
        }

        public static void Init()
        {
            System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            InitializeContext(LibraryContext.Current);
        }

        public static GameInstance GetInstance(int id)
        {
            return LibraryContext.Current.InstanceFactory.Instances[id] as GameInstance;
        }

        public static GameInstance Current
        { get { return ExecutionContext.Current as GameInstance; } }

        private static void InitializeContext(LibraryContext context)
        {
            ExecutionContext.InitializeContext(context);

            //context.DefineGlobalVariables(new [] { "...." });

            // Declare additional variable names specific to games
            context.DefineInstanceVariables(new[] {
                "alarm", "direction", "speed", "hspeed", "vspeed", "sprite_index", "image_blend",
                "x", "y", "gravity", "gravity_direction", "friction", "depth", "image_speed", "image_single", "image_index",
                "image_xscale", "image_yscale", "image_angle", "image_alpha", "xstart", "ystart", "xprevious", "yprevious",
                 "visible", "solid", "persistent"
            });
        }

        /* Call GameCreator.Framework.Game.Run after all of the reasources are created using the GameCreator.Framework namespace */
        public static void Run()
        {
            /* Load all the sprites */

            foreach (int ind in Sprite.Manager.Resources.Keys)
            {
                Sprite s = Sprite.Manager.Resources[ind] as Sprite;
                for (int i = 0; i < s.SubImagesCount; i++)
                    s.SubImages[i] = ResourceManager.GetObject(string.Format("spr_{0}_{1}", s.Id, i), null) as System.Drawing.Bitmap;
            }

            // Check if there are any rooms
            if (Room.Manager.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Error loading: Game has no rooms?");
                System.Environment.Exit(1);
            }

            /* Create & show the main game form and enter the main program loop */
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            roomwindow = new GameWindow(LibraryContext.Current.Resources.Rooms.Values.First());
            roomwindow.Run(30.0, 30.0);
            //roomform = new GameForm((Room)e.Current.Value); // gets the first room available
            //roomform.Show();
            //while (roomform.Created) System.Windows.Forms.Application.DoEvents();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Unexpected error occurred while running the game.");
            System.Console.Error.WriteLine((e.ExceptionObject as Exception).Message);
            System.Console.Error.WriteLine((e.ExceptionObject as Exception).StackTrace);
            //System.Environment.ExitCode = 1;
            System.Windows.Forms.Application.Exit();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is ProgramError)
            {
                var err = e.Exception as ProgramError;
                string msg = string.Format("ERROR in code at line {0} pos {1}:\n{2}", err.Line, err.Column, err.Message);
                switch (err.Location)
                {
                    case CodeLocation.Script:
                        msg = string.Format("COMPILAION ERROR in Script:\nError in code at line {0}:\n\n\nat position {1}: {2}", err.Line, err.Column, err.Message);
                        break;
                }
                System.Windows.Forms.MessageBox.Show(msg, Name, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show(roomform, "Unexpected error occurred while running the game.");
                System.Console.Error.WriteLine(e.Exception.Message);
                System.Console.Error.WriteLine(e.Exception.StackTrace);
            }
            //roomform.Close();
            //System.Environment.Exit(1);
            System.Windows.Forms.Application.Exit();
        }
    }
}
