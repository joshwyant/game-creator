namespace GameCreator.Api.Engine
{
    public interface ITimerPlugin
    {
        double Fps { get; }
        double TargetFps { get; set; }
        void Sleep(int ms);
    }
}