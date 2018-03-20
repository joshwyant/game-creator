using System;
using GameCreator.Engine;
using GameCreator.Engine.Api;
using Ninject.Activation;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKPluginProvider : IDisposable
    {
        private readonly OpenTKPlugins _plugins;

        public Provider<IGraphicsPlugin> Graphics { get; }

        public Provider<IAudioPlugin> Audio { get; }
        
        public Provider<IInputPlugin> Input { get; }
        
        public Provider<ITimerPlugin> Timer { get; }

        public OpenTKPluginProvider()
        {
            _plugins = new OpenTKPlugins();
            Graphics = new GraphicsProvider(this);
            Audio = new AudioProvider(this);
            Input = new InputProvider(this);
            Timer = new TimerProvider(this);
        }

        public void Dispose()
        {
            _plugins?.Dispose();
        }

        private class GraphicsProvider : Provider<IGraphicsPlugin>
        {
            private readonly OpenTKPluginProvider _parent;

            public GraphicsProvider(OpenTKPluginProvider parent)
            {
                _parent = parent;
            }
            
            protected override IGraphicsPlugin CreateInstance(IContext context)
            {
                return _parent._plugins.Graphics;
            }
        }

        private class InputProvider : Provider<IInputPlugin>
        {
            private readonly OpenTKPluginProvider _parent;

            public InputProvider(OpenTKPluginProvider parent)
            {
                _parent = parent;
            }
            
            protected override IInputPlugin CreateInstance(IContext context)
            {
                return _parent._plugins.Input;
            }
        }

        private class AudioProvider : Provider<IAudioPlugin>
        {
            private readonly OpenTKPluginProvider _parent;

            public AudioProvider(OpenTKPluginProvider parent)
            {
                _parent = parent;
            }
            
            protected override IAudioPlugin CreateInstance(IContext context)
            {
                return _parent._plugins.Audio;
            }
        }

        private class TimerProvider : Provider<ITimerPlugin>
        {
            private readonly OpenTKPluginProvider _parent;

            public TimerProvider(OpenTKPluginProvider parent)
            {
                _parent = parent;
            }
            
            protected override ITimerPlugin CreateInstance(IContext context)
            {
                return _parent._plugins.Timer;
            }
        }
    }
}