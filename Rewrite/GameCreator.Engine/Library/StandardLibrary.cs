namespace GameCreator.Engine.Library
{
    public class StandardLibrary
    {
        public GameContext Context { get; }
        public D3dFunctions D3dFunctions { get; }
        public MainFunctions MainFunctions { get; }
        public DrawingFunctions DrawingFunctions { get; }
        public CollisionFunctions CollisionFunctions { get; }

        public StandardLibrary(GameContext context)
        {
            Context = context;
            D3dFunctions = new D3dFunctions(context);
            DrawingFunctions = new DrawingFunctions(context);
            MainFunctions = new MainFunctions(context);
            CollisionFunctions = new CollisionFunctions(context);
        }
    }
}