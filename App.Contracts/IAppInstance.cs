namespace App.Contracts
{
    /// <summary>
    /// Interface for keeping track of object instances as indexed resources.
    /// </summary>
    public interface IAppInstance : IIndexedResource
    {
        /// <summary>
        /// Gets the object that this is an instance of.
        /// </summary>
        IAppObject Object { get; set; }
    }
}
