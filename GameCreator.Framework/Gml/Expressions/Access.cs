using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    class Access : Expression
    {
        public Expression Lefthand;
        public string Name;
        public Expression[] Indices;
        public Access(Expression left, string n, Expression[] ind, int l, int c) : base(l, c) { Lefthand = left; Name = n; Indices = ind; }
        private int info(out int i1, out int i2)
        {
            Value left = 0, v1 = 0, v2 = 0;
            if (Lefthand != null)
            {
                left = Lefthand.Eval();
                if (!left.IsReal) Error("Wrong type of variable index");
            }
            if (Indices.Length != 0)
            {
                v1 = Indices[0].Eval();
                if (!v1.IsReal) Error("Wrong type of array index");
                if (Indices.Length == 2)
                {
                    v2 = Indices[1].Eval();
                    if (!v2.IsReal) Error("Wrong type of array index");
                }
                i1 = Indices.Length == 1 ? 0 : (int)v1;
                i2 = Indices.Length == 1 ? v1 : v2;
                if (i1 < 0 || i2 < 0) Error("Negative array index");
            }
            else { i1 = 0; i2 = 0; }
            if (i1 >= 32000 || i2 >= 32000) Error("Array index >= 32000");
            return left; // implicit conversion from Value to int
        }
        public void Set(Value v)
        {
            int i1, i2;
            int left = info(out i1, out i2);
            if (Lefthand == null)
                ExecutionContext.SetVar(Name, i1, i2, v);
            else
                ExecutionContext.SetVar(left, Name, i1, i2, v);
        }
        public override Value Eval()
        {
            int i1, i2;
            int left = info(out i1, out i2);
            if (Lefthand == null)
            {
                if (i1 != 0 || i2 != 0)
                {
                    if (!ExecutionContext.VariableExists(Name) || !ExecutionContext.Variable(Name).CheckIndex(i1, i2))
                        Error("Unknown variable " + Name + " or array index out of bounds");
                }
                else
                    if (!ExecutionContext.VariableExists(Name)) Error("Unknown variable " + Name);
                return ExecutionContext.GetVar(Name, i1, i2);
            }
            else
            {
                if (i1 != 0 || i2 != 0)
                {
                    if (!ExecutionContext.VariableExists(left, Name) || !ExecutionContext.Variable(left, Name).CheckIndex(i1, i2))
                        Error("Unknown variable " + Name + " or array index out of bounds");
                }
                else
                    if (!ExecutionContext.VariableExists(left, Name)) Error("Unknown variable " + Name);
                return ExecutionContext.GetVar(left, Name, i1, i2);
            }
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Access; }
        }
    }
}
