using System;
using System.Linq.Expressions;
using GameCreator.Runtime.Api;

namespace GameCreator.Runtime.Binder
{
    public class ContextTypeBinder<TContext>
        where TContext : IGameContext
    {
        public GmlBinder GmlBinder { get; }

        public ContextTypeBinder(GmlBinder gmlBinder)
        {
            GmlBinder = gmlBinder;
        }
        
        public void Bind<TProperty>(Expression<Func<TContext, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}