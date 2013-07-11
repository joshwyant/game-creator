using System;
namespace GameCreator.Framework.Gml
{
    public class Subtraction : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public Subtraction(Expression e1, Expression e2, int l, int c) : base(l, c) { Left = e1; Right = e2; }
        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (!(v1.IsReal && v2.IsReal)) Error("Wrong type of arguments to -.");
            return new Value(v1.Real - v2.Real);
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Subtraction; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 - v2);
        }
    }
}