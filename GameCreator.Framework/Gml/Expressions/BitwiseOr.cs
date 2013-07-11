using System;

namespace GameCreator.Framework.Gml
{
    public class BitwiseOr : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public BitwiseOr(Expression e1, Expression e2, int l, int c):base(l,c) { Left = e1; Right = e2; }
        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (!(v1.IsReal && v2.IsReal)) Error("Wrong type of arguments for |.");
            return (double)(Convert.ToInt64(v1.Real) | Convert.ToInt64(v2.Real));
        }


        public override ExpressionKind Kind
        {
            get { return ExpressionKind.BitwiseOr; }
        }

        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => (double)(Convert.ToInt64(v1) | Convert.ToInt64(v2)));
        }
    }
}