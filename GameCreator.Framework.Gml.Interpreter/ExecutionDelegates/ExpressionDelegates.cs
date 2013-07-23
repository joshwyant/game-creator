using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    static class ExpressionDelegates
    {
        #region Arithmetic
        [Expression(Kind = ExpressionKind.Addition)]
        public static Value Addition(Expression node)
        { return Arithmetic(node, (v1, v2) => v1 + v2, true, true, (s1, s2) => s1.String + s2.String); }

        [Expression(Kind = ExpressionKind.Subtraction)]
        public static Value Subtraction(Expression node)
        { return Arithmetic(node, (v1, v2) => v1 - v2); }

        [Expression(Kind = ExpressionKind.Multiply)]
        public static Value Multiply(Expression node)
        {
            return Arithmetic(node, 
                (v1, v2) => v1 * v2,
                false, true, (v1, v2) =>
                {
                    var sb = new StringBuilder();
                    for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                        sb.Append(v2.String);
                    return sb.ToString();
                });
        }

        [Expression(Kind = ExpressionKind.Mod)]
        public static Value Mod(Expression node)
        { return Arithmetic(node, (v1, v2) => (double)((long)v1 % (long)v2)); }

        [Expression(Kind = ExpressionKind.Divide)]
        public static Value Divide(Expression node)
        { return Arithmetic(node, (v1, v2) => v1 / v2); }

        [Expression(Kind = ExpressionKind.Div)]
        public static Value Div(Expression node)
        { return Arithmetic(node, (v1, v2) => (double)((long)v1 / (long)v2)); }
        #endregion

        #region Bitwise
        [Expression(Kind = ExpressionKind.BitwiseAnd)]
        public static Value BitwiseAnd(Expression node)
        { return Bitwise(node, (v1, v2) => v1 & v2); }

        [Expression(Kind = ExpressionKind.BitwiseOr)]
        public static Value BitwiseOr(Expression node)
        { return Bitwise(node, (v1, v2) => v1 | v2); }

        [Expression(Kind = ExpressionKind.BitwiseXor)]
        public static Value BitwiseXor(Expression node)
        { return Bitwise(node, (v1, v2) => v1 ^ v2); }

        [Expression(Kind = ExpressionKind.ShiftLeft)]
        public static Value ShiftLeft(Expression node)
        { return Bitwise(node, (v1, v2) => v1 << (int)v2); }

        [Expression(Kind = ExpressionKind.ShiftRight)]
        public static Value ShiftRight(Expression node)
        { return Bitwise(node, (v1, v2) => v1 >> (int)v2); }
        #endregion

        #region Unary
        [Expression(Kind = ExpressionKind.Complement)]
        public static Value Complement(Expression node)
        { return Unary(node, v => (double)~Convert.ToInt64(v)); }

        [Expression(Kind = ExpressionKind.Plus)]
        public static Value Plus(Expression node)
        { return Unary(node, v => v); }

        [Expression(Kind = ExpressionKind.Minus)]
        public static Value Minus(Expression node)
        { return Unary(node, v => -v); }

        [Expression(Kind = ExpressionKind.Not)]
        public static Value Not(Expression node)
        { return Unary(node, v => v <= 0 ? 1 : 0); }
        #endregion

        #region Simple
        [Expression(Kind = ExpressionKind.Constant)]
        public static Value Constant(Expression node)
        { return (node as Constant).Value; }

        [Expression(Kind = ExpressionKind.Id)]
        public static Value Id(Expression node)
        { return default(Value); }

        [Expression(Kind = ExpressionKind.Grouping)]
        public static Value Grouping(Expression node)
        { return (node as Grouping).InnerExpression.Eval(); }
        #endregion

        #region Comparison
        [Expression(Kind = ExpressionKind.GreaterThan)]
        public static Value GreaterThan(Expression node)
        { return Compare(node, (v1, v2) => v1 > v2, s => s > 0); }

        [Expression(Kind = ExpressionKind.GreaterThanOrEqual)]
        public static Value GreaterThanOrEqual(Expression node)
        { return Compare(node, (v1, v2) => v1 >= v2, s => s >= 0); }

        [Expression(Kind = ExpressionKind.LessThan)]
        public static Value LessThan(Expression node)
        { return Compare(node, (v1, v2) => v1 < v2, s => s < 0); }

        [Expression(Kind = ExpressionKind.LessThanOrEqual)]
        public static Value LessThanOrEqual(Expression node)
        { return Compare(node, (v1, v2) => v1 <= v2, s => s <= 0); }

        [Expression(Kind = ExpressionKind.Equality)]
        public static Value Equality(Expression node)
        { return Compare(node, (v1, v2) => v1 == v2, s => s == 0); }

        [Expression(Kind = ExpressionKind.NotEqual)]
        public static Value NotEqual(Expression node)
        { return Compare(node, (v1, v2) => v1 != v2, s => s != 0); }
        #endregion

        #region Logical
        [Expression(Kind = ExpressionKind.LogicalAnd)]
        public static Value LogicalAnd(Expression node)
        { return Logical(node, (v1, v2) => v1 > 0 && v2 > 0); }

        [Expression(Kind = ExpressionKind.LogicalOr)]
        public static Value LogicalOr(Expression node)
        { return Logical(node, (v1, v2) => v1 > 0 || v2 > 0); }

        [Expression(Kind = ExpressionKind.LogicalXor)]
        public static Value LogicalXor(Expression node)
        { return Logical(node, (v1, v2) => (v1 > 0) ^ (v2 > 0)); }
        #endregion

        #region Access
        [Expression(Kind = ExpressionKind.Access)]
        public static Value Access(Expression e)
        {
            var a = (Access)e;

            Value v1 = 0, v2 = 0;
            int i1 = 0, i2 = 0;
            var name = a.Name;

            // Evaluate array indices
            if (a.Indices.Length != 0)
            {
                v1 = a.Indices[0].Eval();
                if (!v1.IsReal) throw new ProgramError(Error.WrongArrayIndexType);
                if (a.Indices.Length == 2)
                {
                    v2 = a.Indices[1].Eval();
                    if (!v2.IsReal) throw new ProgramError(Error.WrongArrayIndexType);
                }
                i1 = a.Indices.Length == 1 ? 0 : (int)v1;
                i2 = a.Indices.Length == 1 ? v1 : v2;
                if (i1 < 0 || i2 < 0) throw new ProgramError(Error.NegativeArrayIndex);
            }

            if (i1 >= 32000 || i2 >= 32000)
                throw new ProgramError(Error.ArrayBounds);

            if (a.Lefthand != null)
            {
                Value left = a.Lefthand.Eval();
                if (!left.IsReal) throw new ProgramError(Error.WrongVariableIndexType);

                if (i1 != 0 || i2 != 0)
                {
                    if (!ExecutionContext.VariableExists(left, name) || !ExecutionContext.Variable(left, name).CheckIndex(i1, i2))
                        throw new ProgramError(Error.UnknownVariable, name);
                }
                else
                    if (!ExecutionContext.VariableExists(left, name)) throw new ProgramError(Error.UnknownVariable, name);
                return ExecutionContext.GetVar(left, name, i1, i2);
            }
            else
            {
                if (i1 != 0 || i2 != 0)
                {
                    if (!ExecutionContext.VariableExists(name) || !ExecutionContext.Variable(name).CheckIndex(i1, i2))
                        throw new ProgramError(Error.UnknownArray, name);
                }
                else
                    if (!ExecutionContext.VariableExists(name)) throw new ProgramError(Error.UnknownVariable, name);
                return ExecutionContext.GetVar(name, i1, i2);
            }
        }
        #endregion

        #region Call
        [Expression(Kind = ExpressionKind.Call)]
        public static Value Call(Expression e)
        {
            var f = (Call)e;

            if (f.Function is ExecutableFunction)
                return (f.Function as ExecutableFunction).Execute(f.Expressions.Select(ex => ex.Eval()).ToArray());
            else
                return (f.Function as Script).ExecutionDelegate(f.Expressions.Select(ex => ex.Eval()).ToArray());
        }
        #endregion

        #region Helpers
        static Value BinaryReal(Expression node, Func<double, double, double> func)
        {
            var expr = (BinaryExpression)node;

            var v1 = expr.Left.Eval();
            var v2 = expr.Right.Eval();

            if (v1.IsReal && v2.IsReal)
                return func(v1, v2);
            else
                throw new ProgramError(Error.WrongArgumentTypes, expr.Operator);
        }

        static Value Logical(Expression node, Func<double, double, bool> tester)
        {
            return BinaryReal(node, (v1, v2) => tester(v1, v2) ? 1 : 0);
        }

        static Value Bitwise(Expression node, Func<long, long, long> twiddler)
        {
            return BinaryReal(node, (v1, v2) => (double)twiddler(Convert.ToInt64(v1), Convert.ToInt64(v2)));
        }

        static Value Compare(Expression node, Func<double, double, bool> realComparer, Func<int, bool> stringOrdinalComparer)
        {
            var expr = (BinaryExpression)node;

            var v1 = expr.Left.Eval();
            var v2 = expr.Right.Eval();

            if (v1.IsReal && v2.IsReal)
                return realComparer(v1.Real, v2.Real);
            else if (v1.IsString && v2.IsString)
                return stringOrdinalComparer(string.CompareOrdinal(v1.String, v2.String));
            else
                throw new ProgramError(Error.CannotCompare);
        }

        static Value Arithmetic(Expression node, Func<double, double, double> realOperator)
        {
            var expr = (BinaryExpression)node;

            var v1 = expr.Left.Eval();
            var v2 = expr.Right.Eval();

            if (v1.IsReal && v2.IsReal)
                return realOperator(v1, v2);
            else
                throw new ProgramError(Error.WrongArgumentTypes, expr.Operator);
        }

        static Value Arithmetic(Expression node, Func<double, double, double> realOperator, bool v1String, bool v2String, Func<Value, Value, Value> stringOperator)
        {
            var expr = (BinaryExpression)node;

            var v1 = expr.Left.Eval();
            var v2 = expr.Right.Eval();

            if (v1.IsReal && v2.IsReal)
                return realOperator(v1, v2);
            else if (v1.IsString == v1String && v2.IsString == v2String)
                return stringOperator(v1, v2);
            else
                throw new ProgramError(Error.WrongArgumentTypes, expr.Operator);
        }

        static Value Unary(Expression node, Func<double, double> op)
        {
            var v = (node as UnaryExpression).Operand.Eval();

            if (!v.IsReal)
                throw new ProgramError(Error.WrongUnaryTypes);

            return op(v);
        }
        #endregion
    }
}
