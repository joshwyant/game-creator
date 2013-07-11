using System;
namespace GameCreator.Framework.Gml
{
    public class ShiftLeft : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public ShiftLeft(Expression e1, Expression e2, int line, int col) : base(line, col) { Left = e1; Right = e2; }
        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (!(v1.IsReal && v2.IsReal)) Error("Wrong type of arguments for <<.");
            return (double)(Convert.ToInt64(v1.Real) << (int)Convert.ToInt64(v2.Real));
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.ShiftLeft; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => (double)(Convert.ToInt64(v1) << (int)Convert.ToInt64(v2)));
        }
    }
}