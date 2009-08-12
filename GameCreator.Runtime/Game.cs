using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Interpreter;

namespace GameCreator.Runtime
{
    public class Game
    {
        public static string Name { get { return Env.Title; } set { Env.Title = value; } }
        /* Call GameCreator.Runtime.Game.Run after all of the reasources are created using the GameCreator.Runtime namespace */
        public static void Run()
        {
            try
            {
                /* Define all of the built-in functions included in the runtime */
                Type[] lib = new Type[] { 
                    typeof(MiscFunctions), 
                    typeof(RealFunctions), 
                    typeof(StringFunctions),
                    typeof(DateTimeFunctions),
                    typeof(FormsFunctions), // experimental
                };
                foreach (Type t in lib)
                    Env.DefineFunctionsFromType(t);

                /* Define all of the scripts */
                foreach (Script s in Script.Manager.Resources.Values)
                    Env.DefineScript(s.Name, s.Index, s.Code);

                /* Compile the scripts */
                Env.CompileScripts();

                // Check if there are any rooms
                if (Room.Manager.Resources.Count == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Error loading: Game has no rooms?");
                    System.Environment.Exit(1);
                }

                /* Create & show the main game form and enter the main program loop */
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                IEnumerator<KeyValuePair<long, IndexedResource>> e = Room.Manager.Resources.GetEnumerator();
                e.MoveNext();
                GameForm gameform = new GameForm((Room)e.Current.Value); // gets the first room available
                gameform.Show();
                while (gameform.Created) System.Windows.Forms.Application.DoEvents();
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
            catch
            {
                System.Windows.Forms.MessageBox.Show("Unexpected error occurred while running the game.");
            }
        }
    }
}
