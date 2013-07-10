using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Function : BaseFunction
    {
        public FunctionDelegate Delegate;
        public Function(string n, int argc, FunctionDelegate f) : base(n, argc)
        {
            Delegate = f;
        }
        public override Value Execute(params Value[] args)
        {
            Env.Enter();
            Env.Returned = Delegate(args);
            Env.Leave();
            return Env.Returned;
        }
    }
}
