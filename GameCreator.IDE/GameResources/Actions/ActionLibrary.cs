using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.IDE
{
    class ActionLibrary
    {
        public static ActionLibrary Load(System.IO.Stream s)
        {
            ActionLibrary lib = new ActionLibrary();
            System.IO.BinaryReader br = new System.IO.BinaryReader(s, Encoding.ASCII);
            lib.GameMakerVersion = br.ReadInt32();
            bool gm5 = lib.GameMakerVersion == 500;
            lib.TabCaption = new string(br.ReadChars(br.ReadInt32()));
            lib.LibraryID = br.ReadInt32();
            lib.Author = new string(br.ReadChars(br.ReadInt32()));
            lib.Version = br.ReadInt32();
            lib.LastChanged = new DateTime(1899, 12, 30).AddDays(br.ReadDouble());
            lib.Info = new string(br.ReadChars(br.ReadInt32()));
            lib.InitializationCode = new string(br.ReadChars(br.ReadInt32()));
            lib.AdvancedModeOnly = br.ReadInt32() == 0 ? false : true;
            lib.ActionNumberIncremental = br.ReadInt32();
            for (int i = br.ReadInt32(); i > 0; i--)
            {
                int ver = br.ReadInt32();
                ActionDefinition a = new ActionDefinition(lib, new string(br.ReadChars(br.ReadInt32())), br.ReadInt32());
                a.GameMakerVersion = ver;
                int size = br.ReadInt32();
                a.OriginalImage = new byte[size];
                br.Read(a.OriginalImage, 0, size);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(a.OriginalImage);
                System.Drawing.Bitmap b = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms);
                a.Image = new System.Drawing.Bitmap(24, 24, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                System.Drawing.Graphics.FromImage(a.Image).DrawImage(b, 0, 0);
                if (b.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    ((System.Drawing.Bitmap)a.Image).MakeTransparent(b.GetPixel(0, b.Height - 1));
                ms.Close();
                b.Dispose();
                a.Hidden = br.ReadInt32() == 0 ? false : true;
                a.Advanced = br.ReadInt32() == 0 ? false : true;
                a.RegisteredOnly = ver == 500 || (br.ReadInt32() == 0) ? false : true;
                a.Description = new string(br.ReadChars(br.ReadInt32()));
                a.ListText = new string(br.ReadChars(br.ReadInt32()));
                a.HintText = new string(br.ReadChars(br.ReadInt32()));
                a.Kind = (ActionKind)br.ReadInt32();
                a.InterfaceKind = (ActionInferfaceKind)br.ReadInt32();
                a.IsQuestion = br.ReadInt32() == 0 ? false : true;
                a.ShowApplyTo = br.ReadInt32() == 0 ? false : true;
                a.ShowRelative = br.ReadInt32() == 0 ? false : true;
                a.ArgumentCount = br.ReadInt32();
                int count = br.ReadInt32();
                if (a.Arguments.Length != count)
                    a.Arguments = new ActionArgument[count];
                for (int j = 0; j < count; j++)
                {
                    a.Arguments[j] = new ActionArgument();
                    a.Arguments[j].Caption = new string(br.ReadChars(br.ReadInt32()));
                    a.Arguments[j].Type = (ActionArgumentType)br.ReadInt32();
                    a.Arguments[j].DefaultValue = new string(br.ReadChars(br.ReadInt32()));
                    a.Arguments[j].Menu = new string(br.ReadChars(br.ReadInt32()));
                }
                a.ExecutionType = (ActionExecutionType)br.ReadInt32();
                a.FunctionName = new string(br.ReadChars(br.ReadInt32()));
                a.Code = new string(br.ReadChars(br.ReadInt32()));
                lib.Actions.Add(a);
            }
            //Hmm...
            //ActionDefinition d = new ActionDefinition(lib);
            //d.Description = "Font...";
            //d.ArgumentCount = 1;
            //d.Arguments[0] = new ActionArgument();
            //d.Arguments[0].Type = ActionArgumentType.FontString;
            //d.ListText = "@0";
            //lib.Actions.Add(d);
            //d.Arguments[0].DefaultValue = "\"Times New Roman\",10,0,0,0,0,0";
            return lib;
        }
        public void Save(System.IO.Stream s)
        {
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(s, Encoding.ASCII);
            bw.Write(GameMakerVersion);
            bw.Write(TabCaption.Length); bw.Write(TabCaption.ToCharArray());
            bw.Write(1000);//LibraryID);
            bw.Write(Author.Length); bw.Write(Author.ToCharArray());
            bw.Write(Version);
            bw.Write(LastChanged.Subtract(new DateTime(1899, 12, 30)).TotalDays);
            bw.Write(Info.Length); bw.Write(Info.ToCharArray());
            bw.Write(InitializationCode.Length); bw.Write(InitializationCode.ToCharArray());
            bw.Write(AdvancedModeOnly ? 1 : 0);
            bw.Write(ActionNumberIncremental);
            bw.Write(Actions.Count);
            foreach (ActionDefinition a in Actions)
            {
                bw.Write(a.GameMakerVersion);
                bw.Write(a.Name.Length); bw.Write(a.Name.ToCharArray());
                bw.Write(a.ActionID);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.Drawing.Bitmap b = new System.Drawing.Bitmap(a.Image.Width, a.Image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Graphics.FromImage(b).DrawImage(a.Image, 0, 0);
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                bw.Write((int)ms.Length);
                bw.Write(ms.ToArray());
                ms.Close();
                bw.Write(a.Hidden ? 1 : 0);
                bw.Write(a.Advanced ? 1 : 0);
                if (a.GameMakerVersion != 500)
                    bw.Write(a.RegisteredOnly ? 1 : 0);
                bw.Write(a.Description.Length); bw.Write(a.Description.ToCharArray());
                bw.Write(a.ListText.Length); bw.Write(a.ListText.ToCharArray());
                bw.Write(a.HintText.Length); bw.Write(a.HintText.ToCharArray());
                bw.Write((int)a.Kind);
                bw.Write((int)a.InterfaceKind);
                bw.Write(a.IsQuestion ? 1 : 0);
                bw.Write(a.ShowApplyTo ? 1 : 0);
                bw.Write(a.ShowRelative ? 1 : 0);
                bw.Write(a.ArgumentCount);
                bw.Write(8);
                for (int i = 0; i < 8; i++)
                {
                    ActionArgument arg = i < a.ArgumentCount ? a.Arguments[i] : new ActionArgument();
                    bw.Write(arg.Caption.Length); bw.Write(arg.Caption.ToCharArray());
                    bw.Write((int)arg.Type);
                    bw.Write(arg.DefaultValue.Length); bw.Write(arg.DefaultValue.ToCharArray());
                    bw.Write(arg.Menu.Length); bw.Write(arg.Menu.ToCharArray());
                }
                bw.Write((int)a.ExecutionType);
                bw.Write(a.FunctionName.Length); bw.Write(a.FunctionName.ToCharArray());
                bw.Write(a.Code.Length); bw.Write(a.Code.ToCharArray());
            }
            s.Flush();
        }
        public ActionLibrary()
        {
            GameMakerVersion = 520;
            TabCaption = string.Empty;
            LibraryID = new Random(Environment.TickCount).Next(1000, 1000000000);
            Author = string.Empty;
            Version = 100;
            LastChanged = DateTime.Now;
            Info = string.Empty;
            InitializationCode = string.Empty;
            AdvancedModeOnly = false;
            ActionNumberIncremental = 0;
            Actions = new List<ActionDefinition>();
        }
        public int GameMakerVersion { get; set; }
        public string TabCaption { get; set; }
        public int LibraryID { get; set; }
        public bool IsOfficialLibrary { get { return LibraryID < 1000; } }
        public string Author { get; set; }
        public int Version { get; set; }
        public DateTime LastChanged { get; set; }
        public string Info { get; set; }
        public string InitializationCode { get; set; }
        public bool AdvancedModeOnly { get; set; }
        public int ActionNumberIncremental { get; set; }
        public List<ActionDefinition> Actions { get; private set; }
    }
}
