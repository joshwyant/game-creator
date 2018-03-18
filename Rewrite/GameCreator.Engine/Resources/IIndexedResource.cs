namespace GameCreator.Engine
{
    public interface IIndexedResource
    {
        IGameContext Context { get; }
        int Id { get; set; }
    }
}