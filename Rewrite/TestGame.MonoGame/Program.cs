using GameCreator.Engine;
using GameCreator.Plugins.MonoGame;

namespace TestGame.MonoGame
{
    public static class Program
    {
        public static void Main()
        {
            using (var runner = new GameRunner())
            {
                runner.Run();
            }
        }
    }
}