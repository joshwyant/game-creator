using System;
using OpenTK.Audio.OpenAL;

namespace GameCreator.Plugins.OpenTK
{
    public class Source : IDisposable
    {
        public Source(int id)
        {
            Id = id;
        }

        private bool disposed = false;
        public bool IsPlaying()
        {
            if (disposed) return false;
            AL.GetSource(Id, ALGetSourcei.SourceState, out var state);
            return (ALSourceState) state == ALSourceState.Playing;
        }

        public int Id { get; }

        private void ReleaseUnmanagedResources()
        {
            if (disposed) return;
            disposed = true;
            AL.SourceStop(Id);
            AL.DeleteSource(Id);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~Source()
        {
            ReleaseUnmanagedResources();
        }
    }
}