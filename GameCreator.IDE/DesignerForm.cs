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
using GameCreator.Framework;

namespace GameCreator.IDE
{
    partial class DesignerForm : Form
    {
        public SpritesResourceView Sprites;
        public SoundsResourceView Sounds;
        public BackgroundsResourceView Backgrounds;
        public PathsResourceView Paths;
        public ScriptsResourceView Scripts;
        public FontsResourceView Fonts;
        public DataFilesResourceView DataFiles;
        public TimeLinesResourceView TimeLines;
        public RoomsResourceView Rooms;
        public ObjectsResourceView Objects;
        public DesignerForm()
        {
            InitializeComponent();
            PopulateNewResourceTree();
            //
            //ScriptResourceView res = new ScriptResourceView(Program.ScriptIncremental);
            //Program.Scripts.Add(Program.ScriptIncremental++, res);
            //res.Code = Properties.Resources.scr_main;
            //AddResource(Scripts.Node, res, "scr_main", -1, false, false, false);
            //
            SpriteResourceView spr = new SpriteResourceView(Program.SpriteIncremental);
            Program.Sprites.Add(Program.SpriteIncremental++, spr);
            //spr.SubImages = new Bitmap[] { new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb) };
            //Graphics.FromImage(spr.SubImages.First()).Clear(Color.Red);
            using (Bitmap temp = Properties.Resources.Earth) // make temp a temporary copy 
            {
                spr.Animation = new FrameBasedAnimation(temp, false, false, false);
            }
            AddResource(Sprites.Node, spr, "spr_earth", -1, false, false, false);
            //
            ObjectResourceView obj = new ObjectResourceView(Program.ObjectIncremental);
            Program.Objects.Add(Program.ObjectIncremental++, obj);
            obj.Sprite = 0;
            obj.events.Add(new ObjectEvent(EventType.Create, 0));
            // I'm likin' linq! First time using it ^^
            ActionDefinition setVariable = 
                (from lib in Program.Library
                where lib.TabCaption == "control"
                select lib.Actions into actions
                from action in actions
                where action.Name == "Variable"
                select action).First();
            // yea let's use our setVariable action we found with linq :)
            obj.events[0].Actions.Add(new ActionDeclaration(setVariable));
            obj.events[0].Actions[0].Arguments[0] = "image_speed";
            obj.events[0].Actions[0].Arguments[1] = ".5";
            obj.events[0].Actions.Add(new ActionDeclaration(setVariable));
            obj.events[0].Actions[1].Arguments[0] = "image_xscale";
            obj.events[0].Actions[1].Arguments[1] = "3.2";
            obj.events[0].Actions.Add(new ActionDeclaration(setVariable));
            obj.events[0].Actions[2].Arguments[0] = "image_yscale";
            obj.events[0].Actions[2].Arguments[1] = "2.4";
            //obj.events[0].Actions.Add(new ActionDeclaration(Program.Library[3].Actions[20])); // 'Execute Code' action in 'Control' lib, by index
            //obj.events[0].Actions[1].Arguments[0] = "show_message(\r\n \"hspeed: \" +	string(hspeed) +  \r\n \"#vspeed: \" +	string(vspeed) + \r\n \"#speed: \" +	string(speed) + \r\n \"#dir: \" +	string(direction) \r\n);";
            AddResource(Objects.Node, obj, "object0", -1, false, false, false);
            //
            TreeNode RoomsNode = treeView1.Nodes["Rooms"];
            RoomResourceView res1 = new RoomResourceView(Program.RoomIncremental);
            res1.CreationCode = "instance_create(0, 0, object0)";//\r\nscr_main();";
            Program.Rooms.Add(Program.RoomIncremental, res1);
            AddResource(Rooms.Node, res1, "room" + Program.RoomIncremental++, -1, false, false, false);
        }

        private void PopulateNewResourceTree()
        {
            Objects = new ObjectsResourceView();
            Sounds = new SoundsResourceView();
            Backgrounds = new BackgroundsResourceView();
            Paths = new PathsResourceView();
            Scripts = new ScriptsResourceView();
            Fonts = new FontsResourceView();
            DataFiles = new DataFilesResourceView();
            TimeLines = new TimeLinesResourceView();
            Sprites = new SpritesResourceView();
            Rooms = new RoomsResourceView();
            AddResource(null, Sprites, null, -1, false, false, false);
            AddResource(null, Sounds, null, -1, false, false, false);
            AddResource(null, Backgrounds, null, -1, false, false, false);
            AddResource(null, Paths, null, -1, false, false, false);
            AddResource(null, Scripts, null, -1, false, false, false);
            AddResource(null, Fonts, null, -1, false, false, false);
            AddResource(null, DataFiles, null, -1, false, false, false);
            AddResource(null, TimeLines, null, -1, false, false, false);
            AddResource(null, Objects, null, -1, false, false, false);
            AddResource(null, Rooms, null, -1, false, false, false);
            treeView1.SelectedNode = null;
        }
        void NewGame()
        {
            if (Program.GameModified)
            {
                switch (MessageBox.Show("Game has been changed. Save changes?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        /* Save the game */
                        break;
                    case DialogResult.Cancel:
                        // don't start a new project, return
                        return;
                }
            }
            Program.SpriteIncremental = 0;
            Program.SoundIncremental = 0;
            Program.BackgroundIncremental = 0;
            Program.PathIncremental = 0;
            Program.ScriptIncremental = 0;
            Program.FontIncremental = 0;
            Program.DataFileIncremental = 0;
            Program.TimeLineIncremental = 0;
            Program.ObjectIncremental = 0;
            Program.RoomIncremental = 0;
            IResourceView[] reslist = new IResourceView[] { Sprites, Sounds, Backgrounds, Paths, Scripts, Fonts, DataFiles, TimeLines, Rooms, Objects };
            foreach (IResourceView res in reslist)
                foreach (TreeNode tn in res.Node.Nodes)
                    (tn.Tag as IDeletable).DoDelete(false);
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            PopulateNewResourceTree();
            treeView1.EndUpdate();
            Program.GameModified = false;
        }
        private void createScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScript();
        }
        private void CreateSprite()
        {
            SpriteResourceView res = new SpriteResourceView(Program.SpriteIncremental);
            Program.Sprites.Add(Program.SpriteIncremental, res);
            AddResource(Sprites.Node, res, "sprite" + Program.SpriteIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateSound()
        {
            SoundResourceView res = new SoundResourceView(Program.SoundIncremental);
            Program.Sounds.Add(Program.SoundIncremental, res);
            AddResource(Sounds.Node, res, "sound" + Program.SoundIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateBackground()
        {
            BackgroundResourceView res = new BackgroundResourceView(Program.BackgroundIncremental);
            Program.Backgrounds.Add(Program.BackgroundIncremental, res);
            AddResource(Backgrounds.Node, res, "background" + Program.BackgroundIncremental++.ToString(), -1, true, false, true);
        }
        private void CreatePath()
        {
            PathResourceView res = new PathResourceView(Program.PathIncremental);
            Program.Paths.Add(Program.PathIncremental, res);
            AddResource(Paths.Node, res, "path" + Program.PathIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateScript()
        {
            ScriptResourceView res = new ScriptResourceView(Program.ScriptIncremental);
            Program.Scripts.Add(Program.ScriptIncremental, res);
            AddResource(Scripts.Node, res, "script" + Program.ScriptIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateFont()
        {
            FontResourceView res = new FontResourceView(Program.FontIncremental);
            Program.Fonts.Add(Program.FontIncremental, res);
            AddResource(Fonts.Node, res, "font" + Program.FontIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateDataFile()
        {
            DataFileResourceView res = new DataFileResourceView(Program.DataFileIncremental);
            Program.DataFiles.Add(Program.DataFileIncremental, res);
            AddResource(DataFiles.Node, res, "data" + Program.DataFileIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateTimeLine()
        {
            TimeLineResourceView res = new TimeLineResourceView(Program.TimeLineIncremental);
            Program.TimeLines.Add(Program.TimeLineIncremental, res);
            AddResource(TimeLines.Node, res, "timeline" + Program.TimeLineIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateObject()
        {
            ObjectResourceView res = new ObjectResourceView(Program.ObjectIncremental);
            Program.Objects.Add(Program.ObjectIncremental, res);
            AddResource(Objects.Node, res, "object" + Program.ObjectIncremental++.ToString(), -1, true, false, true);
        }
        private void CreateRoom()
        {
            RoomResourceView res = new RoomResourceView(Program.RoomIncremental);
            Program.Rooms.Add(Program.RoomIncremental, res);
            AddResource(Rooms.Node, res, "room" + Program.RoomIncremental++.ToString(), -1, true, false, true);
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
                tn.NodeFont = new Font(treeView1.Font, FontStyle.Regular);
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
        internal void MoveResource(TreeNode newparent, IResourceView res, int treeIndex)
        {
            res.Node.Remove();
            res.Node.Collapse();
            if (treeIndex == -1)
                newparent.Nodes.Add(res.Node);
            else
                newparent.Nodes.Insert(treeIndex, res.Node);
            res.Node.EnsureVisible();
            treeView1.SelectedNode = res.Node;
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
#if DEBUG
            AppDomain domain = AppDomain.CreateDomain("Game Creator Game");
            CreateExecutable("game.exe");
#else
            CreateExecutable("game.exe");
#endif
#if !DEBUG
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("game.exe");
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false; // So we can redirect StandardError
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
#endif
            FormWindowState ws = WindowState;
            WindowState = FormWindowState.Minimized;
#if DEBUG
            domain.ExecuteAssembly("game.exe");
            AppDomain.Unload(domain);
#else
            p.WaitForExit();
#endif
            WindowState = ws;
#if !DEBUG
            string err = p.StandardError.ReadToEnd();
            if (!string.IsNullOrEmpty(err))
                MessageBox.Show(string.Format("The game exited with errors:\n{0}", err), "Game Creator IDE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
        }

        private AssemblyBuilder CreateExecutable(string name)
        {
            ILGenerator il;
            name = name.Replace('\\', '/');
            string exename = name.Contains('/') ? name.Substring(name.LastIndexOf('/') + 1) : name;
            string pathname = name.Contains('/') ? name.Remove(name.LastIndexOf('/')) : null;
            string asmname = exename.Contains('.') ? exename.Remove(exename.LastIndexOf('.')) : exename;
            //
            // We are generating a dynamic assembly here.
            //
            // Get type information from the runtime assembly
            Assembly asm_runtime = Assembly.Load("GameCreator.Framework");
            Type t_game = asm_runtime.GetType("GameCreator.Framework.Game");
            Type t_script = asm_runtime.GetType("GameCreator.Framework.Script");
            Type t_sprite = asm_runtime.GetType("GameCreator.Framework.Sprite");
            Type t_room = asm_runtime.GetType("GameCreator.Framework.Room");
            Type t_object = asm_runtime.GetType("GameCreator.Framework.Object");
            Type t_event = asm_runtime.GetType("GameCreator.Framework.Event");
            Type t_lib = asm_runtime.GetType("GameCreator.Framework.ActionLibrary");
            // Define our dynamic assembly
            System.Reflection.Emit.AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(asmname), AssemblyBuilderAccess.RunAndSave, pathname);
            ModuleBuilder mod = asm.DefineDynamicModule(exename, exename);
            // Define our Program type
            TypeBuilder program = mod.DefineType(string.Format("{0}.Program", asmname));
            System.Resources.IResourceWriter resw = mod.DefineResource(string.Format("{0}.Program.resources", asmname), string.Empty);
            FieldBuilder resourceManager = program.DefineField("resourceManager", typeof(System.Resources.ResourceManager), FieldAttributes.Static);
            MethodBuilder GetResourceManager = program.DefineMethod("GetResourceManager", MethodAttributes.Static, typeof(System.Resources.ResourceManager), Type.EmptyTypes);
            il = GetResourceManager.GetILGenerator();
            System.Reflection.Emit.Label grm_l_1 = il.DefineLabel();
            il.Emit(OpCodes.Ldsfld, resourceManager);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, grm_l_1);
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ldstr, string.Format("{0}.Program", asmname));
            il.Emit(OpCodes.Ldtoken, program);
            il.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle", BindingFlags.Static | BindingFlags.Public));
            il.Emit(OpCodes.Callvirt, typeof(Type).GetProperty("Assembly").GetGetMethod());
            il.Emit(OpCodes.Newobj, typeof(System.Resources.ResourceManager).GetConstructor(new Type[] { typeof(string), typeof(Assembly) }));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Stsfld, resourceManager);
            il.MarkLabel(grm_l_1);
            il.Emit(OpCodes.Ret);
            //program.SetCustomAttribute(new CustomAttributeBuilder(typeof(STAThreadAttribute).GetConstructor(new Type[] { }), new object[] { }));
            // our static Main() function
            // {
            //   GameCreator.Runtime.Object obj;
            //   GameCreator.Runtime.Event ev;
            //   GameCreator.Runtime.ActionLibrary lib;
            //   GameCreator.Runtime.Game.Init();
            //   ...
            //   lib = GameCreator.ActionLibrary.Define(id);
            //   lib.DefineAction(actionid, kind, execution, question, func, code, args);
            //   ...
            //   GameCreator.Runtime.Script.Define("name", index, "code");
            //   ...
            //   obj = GameCreator.Runtime.Object.Define("name", index);
            //   ev = obj.DefineEvent(event, num);
            //   ev.DefineAction(libid, actionid, args, appliesto, relative, not);
            //   ...
            //   GameCreator.Runtime.Room.Define("name", index).CreationCode = "code";
            //   ...
            //   GameCreator.Runtime.Game.Name = "name";
            //   GameCreator.Runtime.Game.Run();
            //   (return)
            // }
            // GameCreator.Runtime.Object obj;
            // GameCreator.Runtime.Event ev;
            // GameCreator.Runtime.ActionLibrary lib;
            MethodBuilder initLibraries = program.DefineMethod("InitLibraries", MethodAttributes.Static);
            il = initLibraries.GetILGenerator();
            foreach (ActionLibrary lib in Program.Library)
            {
                // lib = GameCreator.ActionLibrary.Define(id);
                il.Emit(OpCodes.Ldc_I4, lib.LibraryID);
                il.EmitCall(OpCodes.Call, t_lib.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(int) }, null), null);
                foreach (ActionDefinition ad in lib.Actions)
                {
                    // lib.DefineAction(actionid, kind, execution, question, func, code, args);
                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Ldc_I4, ad.ActionID);
                    il.Emit(OpCodes.Ldc_I4, (int)ad.Kind);
                    il.Emit(OpCodes.Ldc_I4, (int)ad.ExecutionType);
                    il.Emit(ad.IsQuestion ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
                    il.Emit(OpCodes.Ldstr, ad.FunctionName);
                    il.Emit(OpCodes.Ldstr, ad.Code);
                    // ... , new ActionArgumentType[] { x, y, z }, 
                    il.Emit(OpCodes.Ldc_I4, ad.ArgumentCount);
                    il.Emit(OpCodes.Newarr, typeof(ActionArgumentType));
                    for (int i = 0; i < ad.ArgumentCount; i++)
                    {
                        il.Emit(OpCodes.Dup);
                        il.Emit(OpCodes.Ldc_I4, i);
                        il.Emit(OpCodes.Ldc_I4, (int)ad.Arguments[i].Type);
                        il.Emit(OpCodes.Stelem_I4);
                    }
                    //
                    il.EmitCall(OpCodes.Call, t_lib.GetMethod("DefineAction", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(ActionKind), typeof(ActionExecutionType), typeof(bool), typeof(string), typeof(string), typeof(ActionArgumentType[]) }, null), null);
                }
                il.Emit(OpCodes.Pop);
            }
            il.Emit(OpCodes.Ret);
            MethodBuilder defineSprites = program.DefineMethod("DefineSprites", MethodAttributes.Static);
            il = defineSprites.GetILGenerator();
            foreach (SpriteResourceView res in Program.Sprites.Values)
            {
                // Define the resource
                int i = 0;
                foreach (Bitmap b in res.Animation.Frames)
                    resw.AddResource(string.Format("spr_{0}_{1}", res.ResourceID, i++), b);
                // GameCreator.Runtime.Sprite.Define("name", index, subimages);
                il.Emit(OpCodes.Ldstr, res.Name);
                il.Emit(OpCodes.Ldc_I4, res.ResourceID);
                il.Emit(OpCodes.Ldc_I4, res.Animation.FrameCount);
                il.EmitCall(OpCodes.Call, t_sprite.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), typeof(int), typeof(int) }, null), null);
                il.Emit(OpCodes.Pop);
            }
            il.Emit(OpCodes.Ret);
            MethodBuilder defineScripts = program.DefineMethod("DefineScripts", MethodAttributes.Static);
            il = defineScripts.GetILGenerator();
            foreach (ScriptResourceView res in Program.Scripts.Values)
            {
                // GameCreator.Runtime.Script.Define("name", index, "code");
                il.Emit(OpCodes.Ldstr, res.Name);
                il.Emit(OpCodes.Ldc_I4, res.ResourceID);
                il.Emit(OpCodes.Ldstr, res.Code);
                il.EmitCall(OpCodes.Call, t_script.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), typeof(int), typeof(string) }, null), null);
                il.Emit(OpCodes.Pop);
            }
            il.Emit(OpCodes.Ret);
            MethodBuilder defineObjects = program.DefineMethod("DefineObjects", MethodAttributes.Static);
            il = defineObjects.GetILGenerator();
            foreach (ObjectResourceView res in Program.Objects.Values)
            {
                // obj = GameCreator.Runtime.Object.Define("name", index);
                il.Emit(OpCodes.Ldstr, res.Name);
                il.Emit(OpCodes.Ldc_I4, res.ResourceID);
                il.EmitCall(OpCodes.Call, t_object.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), typeof(int) }, null), null);
                foreach (ObjectEvent ev in res.Events)
                {
                    // ev = obj.DefineEvent(event, num);
                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Ldc_I4, (int)ev.EventType);
                    il.Emit(OpCodes.Ldc_I4, (int)ev.EventNumber);
                    il.EmitCall(OpCodes.Call, t_object.GetMethod("DefineEvent", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(int) }, null), null);
                    foreach (ActionDeclaration ad in ev.Actions)
                    {
                        // ev.DefineAction(libid, actionid, args, appliesto, relative, not);
                        il.Emit(OpCodes.Dup);
                        il.Emit(OpCodes.Ldc_I4, ad.Kind.Library.LibraryID);
                        il.Emit(OpCodes.Ldc_I4, ad.Kind.ActionID);
                        // ... , new string[] { "arg", "arg", "arg" }, 
                        il.Emit(OpCodes.Ldc_I4, ad.Kind.ArgumentCount);
                        il.Emit(OpCodes.Newarr, typeof(string));
                        for (int i = 0; i < ad.Kind.ArgumentCount; i++)
                        {
                            il.Emit(OpCodes.Dup);
                            il.Emit(OpCodes.Ldc_I4, i);
                            il.Emit(OpCodes.Ldstr, ad.Arguments[i]);
                            il.Emit(OpCodes.Stelem_Ref);
                        }
                        //
                        il.Emit(OpCodes.Ldc_I4, ad.AppliesTo);
                        il.Emit(ad.Relative ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
                        il.Emit(ad.Not ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
                        il.EmitCall(OpCodes.Call, t_event.GetMethod("DefineAction", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(int), typeof(string[]), typeof(int), typeof(bool), typeof(bool) }, null), null);
                    }
                    il.Emit(OpCodes.Pop);
                }
                il.Emit(OpCodes.Dup);
                // obj.SpriteIndex = ind;
                il.Emit(OpCodes.Ldc_I4, res.Sprite);
                il.EmitCall(OpCodes.Call, t_object.GetProperty("SpriteIndex").GetSetMethod(), null);
                //obj.Depth = d;
                il.Emit(OpCodes.Ldc_R8, res.Depth);
                il.EmitCall(OpCodes.Call, t_object.GetProperty("Depth").GetSetMethod(), null);
            }
            il.Emit(OpCodes.Ret);
            MethodBuilder defineRooms = program.DefineMethod("DefineRooms", MethodAttributes.Static);
            il = defineRooms.GetILGenerator();
            // Start defining rooms.
            // We perform a 'preorder iterative traversal' of the 'Rooms' TreeNode to ensure the rooms are defined in the correct order.
            // We can probably eliminate the stack by using the 'Parent' property of the nodes instead.
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(Rooms.Node);
            while (nodes.Count != 0)
            {
                TreeNode tn = nodes.Pop();
                if (tn.Tag.GetType() == typeof(RoomResourceView))
                {
                    RoomResourceView res = (RoomResourceView)(tn.Tag);
                    // GameCreator.Runtime.Room.Define("name", index).CreationCode = "code";
                    il.Emit(OpCodes.Ldstr, res.Name);
                    il.Emit(OpCodes.Ldc_I4, res.ResourceID);
                    il.EmitCall(OpCodes.Call, t_room.GetMethod("Define", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), typeof(int) }, null), null);
                    il.Emit(OpCodes.Ldstr, res.CreationCode);
                    il.EmitCall(OpCodes.Call, t_room.GetProperty("CreationCode").GetSetMethod(), null);
                }
                tn = tn.LastNode;
                while (tn != null)
                {
                    nodes.Push(tn);
                    tn = tn.PrevNode;
                }
            }
            il.Emit(OpCodes.Ret);
            MethodBuilder main = program.DefineMethod("Main", MethodAttributes.Static);
            main.SetCustomAttribute(new CustomAttributeBuilder(typeof(STAThreadAttribute).GetConstructor(System.Type.EmptyTypes), new object[] { }));
            il = main.GetILGenerator();
            // GameCreator.Runtime.Game.Init();
            il.EmitCall(OpCodes.Call, t_game.GetMethod("Init"), null);
            // InitLibraries();
            il.EmitCall(OpCodes.Call, initLibraries, null);
            // DefineScripts();
            il.EmitCall(OpCodes.Call, defineScripts, null);
            // DefineSprites();
            il.EmitCall(OpCodes.Call, defineSprites, null);
            // DefineObjects();
            il.EmitCall(OpCodes.Call, defineObjects, null);
            // DefineRooms();
            il.EmitCall(OpCodes.Call, defineRooms, null);
            // GameCreator.Runtime.Game.Name = "name";
            il.Emit(OpCodes.Ldstr, asmname);
            il.EmitCall(OpCodes.Call, t_game.GetProperty("Name").GetSetMethod(), null);
            // GameCreator.Runtime.Game.ResourceManager = GetResourceManager();
            il.EmitCall(OpCodes.Call, GetResourceManager, null);
            il.EmitCall(OpCodes.Call, t_game.GetProperty("ResourceManager").GetSetMethod(), null);
            // GameCreator.Runtime.Game.Run();
            il.EmitCall(OpCodes.Call, t_game.GetMethod("Run"), null);
            // return statement, required
            il.Emit(OpCodes.Ret);
            program.CreateType();
            asm.SetEntryPoint(main, PEFileKinds.WindowApplication);
            // Use 32 bit (i386) since GTK# requires it and we plan on using it later
            asm.Save(exename, PortableExecutableKinds.ILOnly, ImageFileMachine.I386);
            return asm;
        }

        private void createExecutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Executable files (*.exe)|*.exe|All Files|*.*";
            sfd.FileName = "game";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName.Remove(sfd.FileName.LastIndexOfAny(new char[] { '\\', '/' }) + 1).Replace('\\', '/');
				if (!System.IO.File.Exists(path + "GameCreator.Runtime.dll"))
                	System.IO.File.Copy("GameCreator.Runtime.dll", path + "GameCreator.Runtime.dll");
                if (!System.IO.File.Exists(path + "OpenTK.dll"))
                    System.IO.File.Copy("OpenTK.dll", path + "OpenTK.dll");
                if (!System.IO.File.Exists(path + "OpenTK.dll.config"))
                    System.IO.File.Copy("OpenTK.dll.config", path + "OpenTK.dll.config");
                CreateExecutable(sfd.FileName);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CreateObject();
        }

        private void createObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateObject();
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            IResourceView res = (IResourceView)((TreeNode)e.Item).Tag;
            if (!string.IsNullOrEmpty(res.DragDropFormat))
                DoDragDrop(new ResourceViewDataObject(res.DragDropFormat, res), DragDropEffects.All);
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            TreeNode tn = treeView1.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
            if (tn != null)
            {
                IResourceView res = (IResourceView)tn.Tag;
                if (res.AcceptsResource(e.Data))
                {
                    treeView1.SelectedNode = res.Node;
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode tn = treeView1.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
            ((IResourceView)tn.Tag).DropResource(e.Data);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
                form.Close();
        }

        private void createSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSprite();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CreateSprite();
        }

        private void createSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSound();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CreateSound();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CreateBackground();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            CreatePath();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            CreateFont();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            CreateDataFile();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            CreateTimeLine();
        }

        private void createBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBackground();
        }

        private void createPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePath();
        }

        private void createFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFont();
        }

        private void createDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDataFile();
        }

        private void createTimeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTimeLine();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
