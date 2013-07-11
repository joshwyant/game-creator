using System;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    static class Expressions
    {
        #region Arithmetic
        [Expression(Kind = ExpressionKind.Addition)]
        public static Value Addition(Expression node)
        { return Arithmetic(node, "+", (v1, v2) => v1 + v2, true, true, (s1, s2) => s1.String + s2.String); }

        [Expression(Kind = ExpressionKind.Subtraction)]
        public static Value Subtraction(Expression node)
        { return Arithmetic(node, "-", (v1, v2) => v1 - v2); }

        [Expression(Kind = ExpressionKind.Multiply)]
        public static Value Multiply(Expression node)
        {
            return Arithmetic(node, "*",
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
        { return Arithmetic(node, "mod", (v1, v2) => (double)((long)v1 % (long)v2)); }

        [Expression(Kind = ExpressionKind.Divide)]
        public static Value Divide(Expression node)
        { return Arithmetic(node, "/", (v1, v2) => v1 / v2); }

        [Expression(Kind = ExpressionKind.Div)]
        public static Value Div(Expression node)
        { return Arithmetic(node, "div", (v1, v2) => (double)((long)v1 / (long)v2)); }
        #endregion

        #region Bitwise
        [Expression(Kind = ExpressionKind.BitwiseAnd)]
        public static Value BitwiseAnd(Expression node)
        { return Bitwise(node, "&", (v1, v2) => v1 & v2); }

        [Expression(Kind = ExpressionKind.BitwiseOr)]
        public static Value BitwiseOr(Expression node)
        { return Bitwise(node, "|", (v1, v2) => v1 | v2); }

        [Expression(Kind = ExpressionKind.BitwiseXor)]
        public static Value BitwiseXor(Expression node)
        { return Bitwise(node, "^", (v1, v2) => v1 ^ v2); }

        [Expression(Kind = ExpressionKind.ShiftLeft)]
        public static Value ShiftLeft(Expression node)
        { return Bitwise(node, "<<", (v1, v2) => v1 << (int)v2); }

        [Expression(Kind = ExpressionKind.ShiftRight)]
        public static Value ShiftRight(Expression node)
        { return Bitwise(node, ">>", (v1, v2) => v1 >> (int)v2); }
        #endregion

        #region Unary
        [Expression(Kind = ExpressionKind.Complement)]
        public static Value Complement(Expression node)
        {
            var expr = (Complement)node;

            var v = Delegator.Eval(expr.Operand);

            if (v.IsReal)
                return (double)~Convert.ToInt64(v.Real);
            else
                return Error("Wrong type of arguments to unary operator.", node);
        }

        [Expression(Kind = ExpressionKind.Plus)]
        public static Value Plus(Expression node)
        {
            var expr = (Plus)node;

            var v = Delegator.Eval(expr.Operand);

            if (v.IsReal)
                return v.Real;
            else
                return Error("Wrong type of arguments to unary operator.", node);
        }

        [Expression(Kind = ExpressionKind.Minus)]
        public static Value Minus(Expression node)
        {
            var expr = (Minus)node;

            var v = Delegator.Eval(expr.Operand);

            if (v.IsReal)
                return -v.Real;
            else
                return Error("Wrong type of arguments to unary operator.", node);
        }

        [Expression(Kind = ExpressionKind.Not)]
        public static Value Not(Expression node)
        {
            var expr = (Not)node;

            var v = Delegator.Eval(expr.Operand);

            if (v.IsReal)
                return v.Real <= 0 ? 1 : 0;
            else
                return Error("Wrong type of arguments to unary operator.", node);
        }
        #endregion

        #region Control
        // Call
        // Access
        // Grouping
        // Constant
        // Id
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
        { return Logical(node, "&&", (v1, v2) => v1 > 0 && v2 > 0); }

        [Expression(Kind = ExpressionKind.LogicalOr)]
        public static Value LogicalOr(Expression node)
        { return Logical(node, "||", (v1, v2) => v1 > 0 || v2 > 0); }

        [Expression(Kind = ExpressionKind.LogicalXor)]
        public static Value LogicalXor(Expression node)
        { return Logical(node, "^^", (v1, v2) => (v1 > 0) ^ (v2 > 0)); }
        #endregion

        #region Helpers
        static Value Error(string str, AstNode node) // Wow, this is wrong.
        {
            throw new ProgramError(str, ErrorSeverity.Error, node.Line, node.Column);
        }

        static Value Logical(Expression node, string op, Func<double, double, bool> tester)
        {
            var expr = (BinaryExpression)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return tester(v1, v2) ? 1 : 0;
            else
                return Error(string.Format("Wrong type of arguments for {0}.", op), node);
        }

        static Value Bitwise(Expression node, string op, Func<long, long, long> twiddler)
        {
            var expr = (BinaryExpression)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return (double)twiddler(Convert.ToInt64(v1.Real), Convert.ToInt64(v2.Real));
            else
                return Error(string.Format("Wrong type of arguments for {0}.", op), node);
        }

        static Value Compare(Expression node, Func<double, double, bool> realComparer, Func<int, bool> stringOrdinalComparer)
        {
            var expr = (Addition)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return realComparer(v1.Real, v2.Real);
            else if (v1.IsString && v2.IsString)
                return stringOrdinalComparer(string.CompareOrdinal(v1.String, v2.String));
            else
                return Error("Cannot compare arguments.", node);
        }

        static Value Arithmetic(Expression node, string op, Func<double, double, double> realOperator)
        {
            var expr = (Addition)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return realOperator(v1, v2);
            else
                return Error(string.Format("Wrong type of arguments to {0}.", op), node);
        }

        static Value Arithmetic(Expression node, string op, Func<double, double, double> realOperator, bool v1String, bool v2String, Func<Value, Value, Value> stringOperator)
        {
            var expr = (Addition)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return realOperator(v1, v2);
            else if (v1.IsString == v1String && v2.IsString == v2String)
                return stringOperator(v1, v2);
            else
                return Error(string.Format("Wrong type of arguments to {0}.", op), node);
        }
        #endregion
    }
}
