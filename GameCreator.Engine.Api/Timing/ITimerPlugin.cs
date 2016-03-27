namespace GameCreator.Engine.Api
{
    public interface ITimerPlugin
    {
        double Fps { get; }
        double TargetFps { get; set; }
        void Sleep(int ms);
    }
}