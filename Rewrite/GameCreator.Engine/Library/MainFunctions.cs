namespace GameCreator.Engine.Library
{
    public class MainFunctions
    {
        public GameContext Context { get; }
        
        public MainFunctions(GameContext context)
        {
            Context = context;
        }

        public void GoToRoom(GameRoom room)
        {
            Context.CurrentRoom = room;
        }

        public GameInstance CreateInstance(double x, double y, GameObject assignedObject)
        {
            return Context.CreateInstance(x, y, assignedObject);
        }
    }
}