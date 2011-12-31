using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.IDE
{
    class ActionDefinition
    {
        public ActionDefinition(ActionLibrary parent, string name, int id)
        {
            Library = parent;
            GameMakerVersion = 520;
            Name = name;
            ActionID = id;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Properties.Resources.DefaultAction.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            OriginalImage = ms.ToArray();
            ms.Close();
            Image = new System.Drawing.Bitmap(24, 24, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.Graphics.FromImage(Image).DrawImage(Properties.Resources.DefaultAction, new System.Drawing.Rectangle(0, 0, 24, 24), new System.Drawing.Rectangle(0, 0, 24, 24), System.Drawing.GraphicsUnit.Pixel);
            (Image as System.Drawing.Bitmap).MakeTransparent(Properties.Resources.DefaultAction.GetPixel(0, Properties.Resources.DefaultAction.Height - 1));
            Hidden = false;
            Advanced = false;
            RegisteredOnly = false;
            Description = string.Empty;
            ListText = string.Empty;
            HintText = string.Empty;
            Kind = ActionKind.Normal;
            InterfaceKind = ActionInferfaceKind.Normal;
            IsQuestion = false;
            ShowApplyTo = true;
            ShowRelative = true;
            ArgumentCount = 0;
            Arguments = new ActionArgument[8];
            for (int i = 0; i < 8; i++) Arguments[i] = new ActionArgument();
            ExecutionType = ActionExecutionType.None;
            FunctionName = string.Empty;
            Code = string.Empty;
        }
        public ActionDefinition(ActionLibrary reference) :
            this(reference, string.Format("Action {0}", ++reference.ActionNumberIncremental), reference.ActionNumberIncremental) { }
        public ActionLibrary Library { get; set; }
        public int GameMakerVersion { get; set; }
        public string Name { get; set; }
        public int ActionID { get; set; }
        public byte[] OriginalImage { get; set; }
        public System.Drawing.Image Image { get; set; }
        public bool Hidden { get; set; }
        public bool Advanced { get; set; }
        public bool RegisteredOnly { get; set; }
        public string Description { get; set; }
        public string ListText { get; set; }
        public string HintText { get; set; }
        public ActionKind Kind { get; set; }
        public ActionInferfaceKind InterfaceKind { get; set; }
        public bool IsQuestion { get; set; }
        public bool ShowApplyTo { get; set; }
        public bool ShowRelative { get; set; }
        public int ArgumentCount { get; set; }
        public ActionArgument[] Arguments { get; set; }
        public ActionExecutionType ExecutionType { get; set; }
        public string FunctionName { get; set; }
        public string Code { get; set; }
    }
}
