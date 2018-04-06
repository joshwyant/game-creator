using System;

namespace GameCreator.Runtime.Api
{
    public class InstanceScope : IDisposable
    {
        public IGameContext Context { get; }
        public IInstance Current { get; }
        public IInstance Other { get; }
        private readonly IInstance _otherPrev;

        public InstanceScope(IGameContext context, IInstance current)
        {
            _otherPrev = context.OtherInstance;
            context.OtherInstance = Other = context.CurrentInstance;
            context.CurrentInstance = Current = current;
            Context = context;
        }

        public void Dispose()
        {
            Context.CurrentInstance = Other;
            Context.OtherInstance = _otherPrev;
        }
    }
}