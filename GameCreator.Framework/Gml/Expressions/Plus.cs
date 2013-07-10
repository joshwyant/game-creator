using System;
namespace GameCreator.Framework.Gml
{
    class Plus : Expression
    {
        Expression expr;
        public Plus(Expression e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return new Value(v.Real);
        }

        public override void Emit(Intermediate.FunctionBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}