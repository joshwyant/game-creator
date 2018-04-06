using System;
using System.Linq.Expressions;
using GameCreator.Runtime.Api;

namespace GameCreator.Runtime.Binder
{
    public class InstanceTypeBinder<TInstance>
        where TInstance : IInstance
    {
        public GmlBinder GmlBinder { get; }

        public InstanceTypeBinder(GmlBinder gmlBinder)
        {
            GmlBinder = gmlBinder;
        }
        
        public void Bind<TProperty>(Expression<Func<TInstance, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}