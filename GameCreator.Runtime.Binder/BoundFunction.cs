using System;
using System.Collections.Generic;
using System.Reflection;
using GameCreator.Runtime.Api;

namespace GameCreator.Runtime.Binder
{
    public class BoundFunction
    {
        private readonly Dictionary<int, GmlBindingOption> _specialParameters = new Dictionary<int, GmlBindingOption>();
        public Type ExecutingType { get; }
        public PropertyInfo ContextProperty { get; }
        public PropertyInfo InstanceProperty { get; }
        public bool IsInstanceMethod { get; }
        
        
        public BoundFunction(MethodInfo method, )
    }
}