namespace GameCreator.Engine
{
    public interface IIndexedResource
    {
        GameContext Context { get; }
        int Id { get; set; }
    }
}