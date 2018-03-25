using GameCreator.Engine;

namespace TestGame.OpenTK
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var runner = new GameRunner())
            {
                runner.Run();
            }
        }
    }
}