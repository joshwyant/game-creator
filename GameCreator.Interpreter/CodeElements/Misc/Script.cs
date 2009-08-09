using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    public class Script : BaseFunction
    {
        public string mCode;
        internal Stmt ParseTree;
        public Script(string name, string code) : base(name, -1)
        {
            mCode = code;
        }
        public void Compile()
        {
            if (Compiled) return;
            Parser p = new Parser(mCode);
            ParseTree = p.Parse();
        }
        public override Value Execute(params Value[] parameters)
        {
            if (!Compiled) Compile();
            Env.Returned = new Value();
            Env.Enter();
            Env.SetArguments(parameters);
            ParseTree.Exec();
            Env.Leave();
            return Env.Returned;
        }
        public string Code
        {
            get
            {
                return mCode;
            }
        }
        public bool Compiled
        {
            get
            {
                return ParseTree != null;
            }
        }
    }
}
