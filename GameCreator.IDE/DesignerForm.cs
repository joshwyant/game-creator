using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Reflection.Emit;

namespace GameCreator.IDE
{
    public partial class DesignerForm : Form
    {
        internal ScriptsResourceView Scripts;
        internal RoomsResourceView Rooms;
        public DesignerForm()
        {
            InitializeComponent();
            Scripts = new ScriptsResourceView(this);
            Rooms = new RoomsResourceView(this);
            AddResource(null, Scripts, null, -1, false, false, false);
            AddResource(null, Rooms, null, -1, false, false, false);
            treeView1.SelectedNode = null;
            //
            ScriptResourceView res = new ScriptResourceView(this, ScriptsResourceView.ids);
            ScriptsResourceView.scripts.Add(ScriptsResourceView.ids++, res);
            res.Code = Properties.Resources.scr_main;
            AddResource(Scripts.Node, res, "scr_main", -1, false, false, false);
            //
            TreeNode RoomsNode = treeView1.Nodes["Rooms"];
            RoomResourceView res1 = new RoomResourceView(this, RoomsResourceView.ids);
            res1.CreationCode = "{\r\n    scr_main();\r\n}";
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res1);
            AddResource(Rooms.Node, res1, "room" + RoomsResourceView.ids++.ToString(), -1, false, false, false);

        }

        private void createScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScript();
        }

        private void CreateScript()
        {
            ScriptResourceView res = new ScriptResourceView(this, ScriptsResourceView.ids);
            ScriptsResourceView.scripts.Add(ScriptsResourceView.ids, res);
            AddResource(Scripts.Node, res, "script" + ScriptsResourceView.ids++.ToString(), -1, true, false, true);
        }
        private void CreateRoom()
        {
            RoomResourceView res = new RoomResourceView(this, RoomsResourceView.ids);
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res);
            AddResource(Rooms.Node, res, "room" + RoomsResourceView.ids++.ToString(), -1, true, false, true);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string key = ((IResourceView)e.Node.Tag).ExpandedImageKey;
            e.Node.ImageKey = key;
            e.Node.SelectedImageKey = key;
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            string key = ((IResourceView)e.Node.Tag).ImageKey;
            e.Node.ImageKey = key;
            e.Node.SelectedImageKey = key;
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string t = e.Label;
            // apparently the label can be null.
            if (e.Label == null)
            {
                if (e.Node.Text != null)
                    t = e.Node.Text;
                else
                    return;
            }
            ((IResourceView)e.Node.Tag).Name = t;
            e.Node.Name = t;
            e.Node.Text = t;
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!((IResourceView)e.Node.Tag).CanRename)
                e.CancelEdit = true;
        }

        private void createRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRoom();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IResourceView irv = (IResourceView)e.Node.Tag;
            if (irv.CanEdit)
                irv.Edit();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IResourceView irv = (IResourceView)e.Node.Tag;
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                ResourceContextMenuStrip rc = new ResourceContextMenuStrip(irv);
                rc.Show(treeView1, e.Location, ToolStripDropDownDirection.Default);
            }
        }

        private void DesignerForm_Load(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                Properties.Settings.Default.WindowX = Location.X;
                Properties.Settings.Default.WindowY = Location.Y;
                Properties.Settings.Default.WindowWidth = Width;
                Properties.Settings.Default.WindowHeight = Height;
                Properties.Settings.Default.WindowDefault = false;
            }
        }


        private void DesignerForm_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowX = Location.X;
                Properties.Settings.Default.WindowY = Location.Y;
                Properties.Settings.Default.WindowDefault = false;
            }
        }

        private void DesignerForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowWidth = Width;
                Properties.Settings.Default.WindowHeight = Height;
                Properties.Settings.Default.WindowDefault = false;
            }
        }

        private void DesignerForm_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowMaximized = (WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.WindowDefault = false;
        }
        internal void AddResource(TreeNode parent, IResourceView res, string name, int treeIndex, bool ensureVisible, bool rename, bool edit)
        {
            if (!string.IsNullOrEmpty(name))
                res.Name = name;
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            if (parent == null)
                tn.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
            TreeNodeCollection tnc = parent == null ? treeView1.Nodes : parent.Nodes;
            if (treeIndex == -1)
                tnc.Add(tn);
            else
                tnc.Insert(treeIndex, tn);
            if (ensureVisible)
            {
                tn.EnsureVisible();
                treeView1.SelectedNode = tn;
            }
            if (edit)
                res.Edit();
            if (rename)
                tn.BeginEdit();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CreateScript();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CreateRoom();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CreateExecutable("game.exe");
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("game.exe");
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false; // So we can redirect StandardError
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
            FormWindowState ws = WindowState;
            WindowState = FormWindowState.Minimized;
            p.WaitForExit();
            WindowState = ws;
            string err = p.StandardError.ReadToEnd();
            if (!string.IsNullOrEmpty(err))
                MessageBox.Show(string.Format("The game exited with errors:\n{0}", err), "Game Creator IDE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void CreateExecutable(string name)
        {
            name = name.Replace('\\', '/');
            string exename = name.Contains('/') ? name.Substring(name.LastIndexOf('/') + 1) : name;
            string pathname = name.Contains('/') ? name.Remove(name.LastIndexOf('/')) : null;
            string asmname = exename.Contains('.') ? exename.Remove(exename.LastIndexOf('.')) : exename;
            //
            // We are creating a dynamic assembly here.
            //
            // Get type information from the runtime assembly
            Assembly runtime = Assembly.Load("GameCreator.Runtime");
            Type game = runtime.GetType("GameCreator.Runtime.Game");
            Type script = runtime.GetType("GameCreator.Runtime.Script");
            Type room = runtime.GetType("GameCreator.Runtime.Room");
            // Define our dynamic assembly
            System.Reflection.Emit.AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(asmname), AssemblyBuilderAccess.RunAndSave, pathname);
            ModuleBuilder mod = asm.DefineDynamicModule(exename);
            TypeBuilder program = mod.DefineType("Program");
            //program.SetCustomAttribute(new CustomAttributeBuilder(typeof(STAThreadAttribute).GetConstructor(new Type[] { }), new object[] { }));
            // our static Main() function
            // {
            //   GameCreator.Runtime.Script.Define("name", index, "code");
            //   ...
            //   GameCreator.Runtime.Room.Define("name").CreationCode = "code";
            //   ...
            //   GameCreator.Runtime.Game.Name = "name";
            //   GameCreator.Runtime.Game.Run();
            //   (return)
            // }
            MethodBuilder main = program.DefineMethod("Main", MethodAttributes.Static);
            ILGenerator il = main.GetILGenerator();
            foreach (KeyValuePair<long, ScriptResourceView> res in ScriptsResourceView.scripts)
            {
                // GameCreator.Runtime.Script.Define("name", index, "code");
                il.Emit(OpCodes.Ldstr, res.Value.Name);
                il.Emit(OpCodes.Ldc_I8, res.Key);
                il.Emit(OpCodes.Ldstr, res.Value.Code);
                il.EmitCall(OpCodes.Call, script.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), typeof(long), typeof(string) }, null), null);
                il.Emit(OpCodes.Pop);
            }
            foreach (KeyValuePair<long, RoomResourceView> res in RoomsResourceView.rooms)
            {
                // GameCreator.Runtime.Room.Define("name").CreationCode = "code";
                il.Emit(OpCodes.Ldstr, res.Value.Name);
                il.EmitCall(OpCodes.Call, room.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string) }, null), null);
                il.Emit(OpCodes.Ldstr, res.Value.CreationCode);
                il.EmitCall(OpCodes.Call, room.GetProperty("CreationCode").GetSetMethod(), null);
            }
            // GameCreator.Runtime.Game.Name = "name";
            il.Emit(OpCodes.Ldstr, asmname);
            il.EmitCall(OpCodes.Call, game.GetProperty("Name").GetSetMethod(), null);
            // GameCreator.Runtime.Game.Run();
            il.EmitCall(OpCodes.Call, game.GetMethod("Run"), null);
            // return statement, required
            il.Emit(OpCodes.Ret);
            program.CreateType();
            asm.SetEntryPoint(main, PEFileKinds.WindowApplication);
            // Use 386 bit since GTK# requires it and we plan on using it later
            asm.Save(exename, PortableExecutableKinds.ILOnly, ImageFileMachine.I386);
        }

        private void createExecutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Executable files (*.exe)|*.exe|All Files|*.*";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName.Remove(sfd.FileName.LastIndexOfAny(new char[] { '\\', '/' }) + 1).Replace('\\', '/');
				if (!System.IO.File.Exists(path + "GameCreator.Interpreter.dll"))
                	System.IO.File.Copy("GameCreator.Interpreter.dll", path + "GameCreator.Interpreter.dll");
				if (!System.IO.File.Exists(path + "GameCreator.Runtime.dll"))
                	System.IO.File.Copy("GameCreator.Runtime.dll", path + "GameCreator.Runtime.dll");
                CreateExecutable(sfd.FileName);
            }
        }
    }
}
