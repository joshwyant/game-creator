using System;
using System.Windows.Forms;
using GameCreator.Interpreter;

namespace GameCreatorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            System.IO.Stream programStream =
                new System.IO.MemoryStream(Properties.Resources.program);
            try
            {
                try
                {
					Env.DefineFunctionsFromType(typeof(GameCreator.Functions));
                    Env.ImportScripts(programStream);
                    if (!Env.FunctionExists("main")) throw new ProgramError("Entry point not found.");
                    Env.CompileScripts();
                    Env t = Env.Current;
                    Env.Current = Env.CreatePrivateInstance(); // The current instance executing the code
                    Env.Enter();
                    try
                    {
                        Env.Functions["main"].Execute();
                    }
                    catch (System.OutOfMemoryException)
                    {
                        throw;
                    }
                    finally
                    {
                        Env.Leave();
                        Env.Current = t;
                    }
                }
                catch (ProgramError p)
                {
                    System.Windows.Forms.MessageBox.Show(p.Message, Env.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (System.OutOfMemoryException)
            {
                System.Windows.Forms.MessageBox.Show("Unexpected error occurred when running the game.");
                System.Environment.Exit(1);
            }
        }
    }
}
