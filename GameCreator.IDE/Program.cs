using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DesignerForm mainform = new DesignerForm();
            if (!Properties.Settings.Default.WindowDefault)
            {
                bool maximized = Properties.Settings.Default.WindowMaximized;
                mainform.StartPosition = FormStartPosition.Manual;
                mainform.Location = new System.Drawing.Point(Math.Max(0, Properties.Settings.Default.WindowX), Math.Max(0, Properties.Settings.Default.WindowY));
                mainform.Size = new System.Drawing.Size(Properties.Settings.Default.WindowWidth, Properties.Settings.Default.WindowHeight);
                if (maximized)
                    mainform.WindowState = FormWindowState.Maximized;
            }
            Application.Run(mainform);
            Properties.Settings.Default.Save();
        }
    }
}
