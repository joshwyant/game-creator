using System;
namespace GameCreator.Framework.Gml
{
    public class Multiply : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public Multiply(Expression e1, Expression e2, int l, int c) : base(l, c) { Left = e1; Right = e2; }
        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (v1.IsReal && v2.IsReal)
                return new Value(v1.Real * v2.Real);
            else if (v1.IsReal && v2.IsString)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                    sb.Append(v2.String);
                return new Value(sb.ToString());
            }
            else
                return Error("Wrong type of arguments to *.");
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Multiply; }
        }
        public override Expression Reduce()
        {
            var e1 = Left.Reduce();
            var e2 = Right.Reduce();

            if (e1.Kind == ExpressionKind.Constant && e2.Kind == ExpressionKind.Constant)
            {
                var v1 = ((Constant)e1).Value;
                var v2 = ((Constant)e2).Value;

                if (v1.IsReal && v2.IsReal)
                    return new Constant(v1.Real * v2.Real, Line, Column);

                if (v1.IsReal && v2.IsString)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                        sb.Append(v2.String);
                    return new Constant(sb.ToString(), Line, Column);
                }
            }

            return this;
            // One way to optimize could be returning a Shift operator
        }
    }
}