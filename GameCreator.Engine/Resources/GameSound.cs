using GameCreator.Api.Engine;
using GameCreator.Api.Resources;

namespace GameCreator.Engine
{
    public class GameSound : IIndexedResource
    {
        public GameContext Context { get; }
        public int Id { get; set; }
        public ISoundEffect Effect { get; }
        
        public GameSound(GameContext context, ISoundEffect effect)
        {
            Context = context;
            Effect = effect;
        }
    }
}