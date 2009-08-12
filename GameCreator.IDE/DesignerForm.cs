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
        public DesignerForm()
        {
            InitializeComponent();
            AddResource(null, new ScriptsResourceView(this));
            AddResource(null, new RoomsResourceView(this));
            treeView1.SelectedNode = null;
            //
            TreeNode ScriptsNode = treeView1.Nodes["Scripts"];
            ScriptResourceView res = new ScriptResourceView(this);
            ScriptsResourceView.scripts.Add(ScriptsResourceView.ids, res);
            res.Name = "scr_main";
            res.Code = Properties.Resources.scr_main;
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            ScriptsNode.Nodes.Add(tn);
            //
            TreeNode RoomsNode = treeView1.Nodes["Rooms"];
            RoomResourceView res1 = new RoomResourceView(this);
            res1.CreationCode = "{\r\n    scr_main();\r\n}";
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res1);
            res1.Name = "room" + RoomsResourceView.ids++.ToString();
            TreeNode tn1 = new TreeNode(res1.Name);
            res1.Node = tn1;
            tn1.Name = tn1.Text;
            tn1.ImageKey = res1.ImageKey;
            tn1.SelectedImageKey = res1.ImageKey;
            tn1.Tag = res1;
            RoomsNode.Nodes.Add(tn1);
        }

        private void createScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScript();
        }

        private void CreateScript()
        {
            TreeNode ScriptsNode = treeView1.Nodes["Scripts"];
            ScriptResourceView res = new ScriptResourceView(this);
            ScriptsResourceView.scripts.Add(ScriptsResourceView.ids, res);
            res.Name = "script" + ScriptsResourceView.ids++.ToString();
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            ScriptsNode.Nodes.Add(tn);
            tn.EnsureVisible();
            treeView1.SelectedNode = tn;
            res.Edit();
        }
        private void CreateRoom()
        {
            TreeNode RoomsNode = treeView1.Nodes["Rooms"];
            RoomResourceView res = new RoomResourceView(this);
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res);
            res.Name = "room" + RoomsResourceView.ids++.ToString();
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            RoomsNode.Nodes.Add(tn);
            tn.EnsureVisible();
            treeView1.SelectedNode = tn;
            res.Edit();
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
            ((IResourceView)e.Node.Tag).Name = e.Label;
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
        void AddResource(TreeNode parent, IResourceView res)
        {
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            if (parent == null)
                tn.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
            TreeNodeCollection tnc = parent == null ? treeView1.Nodes : parent.Nodes;
            tnc.Add(tn);
            tn.EnsureVisible();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CreateScript();
        }

        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            treeView1.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CreateRoom();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CreateExecutable("game.exe");
            System.Diagnostics.Process.Start("game.exe");
        }

        private static void CreateExecutable(string name)
        {
            name = name.Replace('/', '\\');
            string exename = name.Contains('\\') ? name.Substring(name.LastIndexOf('\\') + 1) : name;
            string pathname = name.Contains('\\') ? name.Remove(name.LastIndexOf('\\')) : null;
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
            program.SetCustomAttribute(new CustomAttributeBuilder(typeof(STAThreadAttribute).GetConstructor(new Type[] { }), new object[] { }));
            // our static Main() function
            // {
            //   GameCreator.Runtime.Script.Define("name", index, "code");
            //   ...
            //   GameCreator.Runtime.Room.Define("name").CreationCode = "code";
            //   ...
            //   GameCreator.Runtime.Game.Name = "name";
            //   GameCreator.Runtime.Game.Run();
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
            program.CreateType();
            asm.SetEntryPoint(main, PEFileKinds.WindowApplication);
            // Use 386 bit since GTK# requires it and we plan on using it later
            asm.Save(exename, PortableExecutableKinds.ILOnly, ImageFileMachine.I386);
        }

        private void createExecutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Executable files (*.exe)|*.exe";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName.Remove(sfd.FileName.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
                System.IO.File.Copy("GameCreator.Interpreter.dll", path + "GameCreator.Interpreter.dll", true);
                System.IO.File.Copy("GameCreator.Runtime.dll", path + "GameCreator.Runtime.dll", true);
                CreateExecutable(sfd.FileName);
            }
        }
    }
}
