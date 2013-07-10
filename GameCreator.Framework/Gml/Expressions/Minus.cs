using System;
namespace GameCreator.Framework.Gml
{
    class Minus : Expression
    {
        Expression expr;
        public Minus(Expression e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return new Value(-v.Real);
        }

        public override void Emit(Intermediate.FunctionBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}