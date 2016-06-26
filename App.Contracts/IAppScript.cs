namespace App.Contracts
{
    /// <summary>
    /// Interface for a script resource.
    /// </summary>
    public interface IAppScript : INamedIndexedResource
    {
        string Code { get; set; }
    }
}
