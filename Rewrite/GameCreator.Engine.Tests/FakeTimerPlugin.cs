using GameCreator.Engine.Api;

namespace GameCreator.Engine.Tests
{
    public class FakeTimerPlugin : ITimerPlugin
    {
        public double Fps { get; }
        public double TargetFps { get; set; }
        public void Sleep(int ms)
        {
        }
    }
}