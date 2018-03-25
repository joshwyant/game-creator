namespace GameCreator.Engine.Library
{
    public class StandardLibrary
    {
        public GameContext Context { get; }
        public D3dFunctions D3d { get; }
        public MainFunctions Main { get; }
        public DrawingFunctions Drawing { get; }
        public CollisionFunctions Collision { get; }
        public RealFunctions Real { get; }
        public ActionLibrary Actions { get; }

        public StandardLibrary(GameContext context)
        {
            Context = context;
            D3d = new D3dFunctions(context);
            Drawing = new DrawingFunctions(context);
            Main = new MainFunctions(context);
            Collision = new CollisionFunctions(context);
            Real = new RealFunctions(context);
            Actions = new ActionLibrary(context);
        }
    }
}