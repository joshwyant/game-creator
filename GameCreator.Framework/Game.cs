using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework
{
    public class Game
    {
        public static string Name { get { return ExecutionContext.Title; } set { ExecutionContext.Title = value; } }
        public static System.Resources.ResourceManager ResourceManager { get; set; }
        //internal static GameForm roomform;
        internal static RuntimeWindow roomwindow;
        public static void Init()
        {
            System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        /* Call GameCreator.Framework.Game.Run after all of the reasources are created using the GameCreator.Framework namespace */
        public static void Run()
        {
            //System.Windows.Forms.Application
            try
            {
                /* Define all of the built-in functions included in the runtime */
                Type[] lib = new Type[] { 
                    typeof(Library.Actions.LibraryFunctions),
                    typeof(Library.GMLFunctions), 
                    typeof(Library.FormsFunctions), // experimental
                };
                foreach (Type t in lib)
                    ExecutionContext.DefineFunctionsFromType(t);
                /* Load all the sprites */

                foreach (int ind in Sprite.Manager.Resources.Keys)
                {
                    Sprite s = Sprite.Manager.Resources[ind] as Sprite;
                    for (int i = 0; i < s.subImagesCount; i++)
                        s.SubImages[i] = ResourceManager.GetObject(string.Format("spr_{0}_{1}", s.Index, i), null) as System.Drawing.Bitmap;
                }

                /* Define all of the scripts */
                foreach (Script s in Script.Manager.Resources.Values)
                    s.CompiledScript = ExecutionContext.DefineScript(s.Name, s.Index, s.Code);

                /* Compile the scripts */
                ExecutionContext.CompileScripts();

                // Check if there are any rooms
                if (Room.Manager.Resources.Count == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Error loading: Game has no rooms?");
                    System.Environment.Exit(1);
                }

                /* Create & show the main game form and enter the main program loop */
                System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                IEnumerator<KeyValuePair<int, IndexedResource>> e = Room.Manager.Resources.GetEnumerator();
                e.MoveNext();
                roomwindow = new RuntimeWindow((Room)e.Current.Value);
                roomwindow.Run(30.0, 30.0);
                //roomform = new GameForm((Room)e.Current.Value); // gets the first room available
                //roomform.Show();
                //while (roomform.Created) System.Windows.Forms.Application.DoEvents();
            }
            catch (ProgramError err)
            {
                string msg = string.Format("ERROR in code at line {0} pos {1}:\n{2}", err.Line, err.Column, err.Message);
                switch (err.Location)
                {
                    case CodeLocation.Script:
                        msg = string.Format("COMPILAION ERROR in Script:\nError in code at line {0}:\n\n\nat position {1}: {2}", err.Line, err.Column, err.Message);
                        break;
                }
                System.Windows.Forms.MessageBox.Show(msg, Name, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
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
            if (e.Exception.GetType() == typeof(ProgramError))
            {
                ProgramError err = (ProgramError)e.Exception;
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
