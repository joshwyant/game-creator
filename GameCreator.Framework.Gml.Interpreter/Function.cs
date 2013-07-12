using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class Function : ExecutableFunction
    {
        public FunctionDelegate Delegate;
        public Function(string n, int argc, FunctionDelegate f) : base(n, argc)
        {
            Delegate = f;
        }
        public override Value Execute(params Value[] args)
        {
            ExecutionContext.Enter();
            ExecutionContext.Returned = Delegate(args);
            ExecutionContext.Leave();
            return ExecutionContext.Returned;
        }
    }
}
