namespace GameCreator.Projects
{
    public class FontResource : BaseResource
    {
        public string FontName { get; set; }
        public int Size { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public int CharacterRangeBegin { get; set; }
        public int CharacterRangeEnd { get; set; }
    }
}