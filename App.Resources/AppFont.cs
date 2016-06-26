using App.Contracts;

namespace App.Resources
{
    public class AppFont : NamedResource, IAppFont
    {
        public override string DefaultPrefix { get { return "font"; } }

        public int CharacterRangeBegin { get; set; }
        public int CharacterRangeEnd { get; set; }
        public string FontName { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public int Size { get; set; }
    }
}
