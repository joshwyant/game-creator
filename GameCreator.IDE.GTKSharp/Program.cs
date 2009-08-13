using System;
using System.Collections.Generic;
using Gtk;

namespace GameCreator.IDE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Init();
            Window MainForm = new Window("Game Creator");
            MainForm.Destroyed += new EventHandler(MainForm_Destroyed);
            MainForm.ShowAll();
            Application.Run();
        }

        static void MainForm_Destroyed(object sender, EventArgs e)
        {
            Application.Quit();
        }
    }
}
