using System;

namespace GameCreator.Framework.Gml
{
    public class Addition : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public Addition(Expression e1, Expression e2, int l, int c) : base(l, c) { Left = e1; Right = e2; }
        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (v1.IsReal && v2.IsReal)
                return new Value(v1.Real + v2.Real);
            else if (v1.IsString && v2.IsString)
                return new Value(v1.String + v2.String);
            else
                return Error("Wrong type of arguments to +.");
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Addition; }
        }

        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 + v2, (s1, s2) => s1 + s2);
        }
    }
}