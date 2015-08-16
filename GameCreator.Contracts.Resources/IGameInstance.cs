namespace GameCreator.Contracts.Resources
{
    /// <summary>
    /// Interface for keeping track of object instances as indexed resources.
    /// </summary>
    public interface IGameInstance : IIndexedResource
    {
        /// <summary>
        /// Gets the object that this is an instance of.
        /// </summary>
        IGameObject Object { get; set; }
    }
}
