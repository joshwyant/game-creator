using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class SyntaxTreeScope : IDisposable
    {
        AstNode prev;

        public SyntaxTreeScope(AstNode node)
        {
            prev = Interpreter.ExecutingNode;
            Interpreter.ExecutingNode = node;
        }

        public void Dispose()
        {
            Interpreter.ExecutingNode = prev;
        }
    }
}
