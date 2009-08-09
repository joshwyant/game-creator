using GameCreator.Runtime;

namespace GameCreatorTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            Game.Name = "mygame";
            Script.Define("scr_main", 0L, Properties.Resources.scr_main);
            Room.Define("room0", 0L).CreationCode = "scr_main()";
            Game.Run();
        }
    }
}
