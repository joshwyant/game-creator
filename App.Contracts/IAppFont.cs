namespace App.Contracts
{
    /// <summary>
    /// Interface for a font resource.
    /// </summary>
    public interface IAppFont : INamedIndexedResource
    {
        int CharacterRangeBegin { get; set; }
        int CharacterRangeEnd { get; set; }
        string FontName { get; set; }
        bool IsBold { get; set; }
        bool IsItalic { get; set; }
        int Size { get; set; }
    }
}
