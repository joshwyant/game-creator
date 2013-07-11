using System;
namespace GameCreator.Framework.Gml
{
    class Not : Expression
    {
        Expression expr;
        public Not(Expression e, int l, int c) : base(l, c) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return v.Real >= 0 ? Value.Zero : Value.One;
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Not; }
        }
    }
}