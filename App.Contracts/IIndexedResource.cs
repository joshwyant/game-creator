namespace App.Contracts
{
    /// <summary>
    /// Interface for indexed resources. For named resources, use <see cref="INamedIndexedResource"/>.
    /// </summary>
    public interface IIndexedResource
    {
        /// <summary>
        /// Gets the zero-based index of the resource.
        /// </summary>
        int Index { get; }
    }
}
