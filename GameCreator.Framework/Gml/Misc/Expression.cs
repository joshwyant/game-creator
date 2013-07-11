using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public abstract class Expression : AstNode
    {
        public Expression(int line, int col) : base(line, col) { }
        public virtual Value Eval()
        {
            return new Value();
        }
        public Value Error(string str)
        {
            throw new ProgramError(str, ErrorSeverity.Error, Line, Column);
        }

        public abstract ExpressionKind Kind { get; }
    }
}
