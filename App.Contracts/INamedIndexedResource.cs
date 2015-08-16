namespace App.Contracts
{
    /// <summary>
    /// Interface for named indexed resources.
    /// </summary>
    public interface INamedIndexedResource : IIndexedResource
    {
        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        string Name { get; set; }
    }
}
