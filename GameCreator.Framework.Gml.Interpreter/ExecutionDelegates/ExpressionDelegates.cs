using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Runtime;
using System.Runtime.CompilerServices;

namespace GameCreator.Framework.Gml.Interpreter
{
    static class ExpressionDelegates
    {
        #region Arithmetic
        [Expression(Kind = ExpressionKind.Addition)]
        public static Value Addition(Expression node)
        { return Binary(node, (a, b) => a + b); }

        [Expression(Kind = ExpressionKind.Subtraction)]
        public static Value Subtraction(Expression node)
        { return Binary(node, (a, b) => a - b); }

        [Expression(Kind = ExpressionKind.Multiply)]
        public static Value Multiply(Expression node)
        { return Binary(node, (a, b) => a * b); }

        [Expression(Kind = ExpressionKind.Mod)]
        public static Value Mod(Expression node)
        { return Binary(node, (a, b) => a % b); }

        [Expression(Kind = ExpressionKind.Divide)]
        public static Value Divide(Expression node)
        { return Binary(node, (a, b) => a / b); }

        [Expression(Kind = ExpressionKind.Div)]
        public static Value Div(Expression node)
        { return Binary(node, (a, b) => Value.IntegerDivision(a, b)); }
        #endregion

        #region Bitwise
        [Expression(Kind = ExpressionKind.BitwiseAnd)]
        public static Value BitwiseAnd(Expression node)
        { return Binary(node, (a, b) => a & b); }

        [Expression(Kind = ExpressionKind.BitwiseOr)]
        public static Value BitwiseOr(Expression node)
        { return Binary(node, (a, b) => a | b); }

        [Expression(Kind = ExpressionKind.BitwiseXor)]
        public static Value BitwiseXor(Expression node)
        { return Binary(node, (a, b) => a ^ b); }

        [Expression(Kind = ExpressionKind.ShiftLeft)]
        public static Value ShiftLeft(Expression node)
        { return Binary(node, (a, b) => Value.ShiftLeft(a, b)); }

        [Expression(Kind = ExpressionKind.ShiftRight)]
        public static Value ShiftRight(Expression node)
        { return Binary(node, (a, b) => Value.ShiftRight(a, b)); }
        #endregion

        #region Unary
        [Expression(Kind = ExpressionKind.Complement)]
        public static Value Complement(Expression node)
        { return ~Unary(node); }

        [Expression(Kind = ExpressionKind.Plus)]
        public static Value Plus(Expression node)
        { return +Unary(node); }

        [Expression(Kind = ExpressionKind.Minus)]
        public static Value Minus(Expression node)
        { return -Unary(node); }

        [Expression(Kind = ExpressionKind.Not)]
        public static Value Not(Expression node)
        { return !Unary(node); }
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
        { return Binary(node, (a, b) => a > b); }

        [Expression(Kind = ExpressionKind.GreaterThanOrEqual)]
        public static Value GreaterThanOrEqual(Expression node)
        { return Binary(node, (a, b) => a >= b); }

        [Expression(Kind = ExpressionKind.LessThan)]
        public static Value LessThan(Expression node)
        { return Binary(node, (a, b) => a < b); }

        [Expression(Kind = ExpressionKind.LessThanOrEqual)]
        public static Value LessThanOrEqual(Expression node)
        { return Binary(node, (a, b) => a <= b); }

        [Expression(Kind = ExpressionKind.Equality)]
        public static Value Equality(Expression node)
        { return Binary(node, (a, b) => a == b); }

        [Expression(Kind = ExpressionKind.NotEqual)]
        public static Value NotEqual(Expression node)
        { return Binary(node, (a, b) => a != b); }
        #endregion

        #region Logical
        [Expression(Kind = ExpressionKind.LogicalAnd)]
        public static Value LogicalAnd(Expression node)
        { return Binary(node, (a, b) => Value.LogicalAnd(a, b)); }

        [Expression(Kind = ExpressionKind.LogicalOr)]
        public static Value LogicalOr(Expression node)
        { return Binary(node, (a, b) => Value.LogicalOr(a, b)); }

        [Expression(Kind = ExpressionKind.LogicalXor)]
        public static Value LogicalXor(Expression node)
        { return Binary(node, (a, b) => Value.LogicalXor(a, b)); }
        #endregion

        #region Access
        [Expression(Kind = ExpressionKind.Access)]
        public static Value Access(Expression e)
        {
            var a = e as Access;

            Value v1 = 0, v2 = 0;

            // Evaluate array indices
            if (a.Indices.Length >= 1)
                v2 = a.Indices[0].Eval();
            if (a.Indices.Length >= 2)
                v1 = a.Indices[1].Eval();

            return ExecutionContext.Dereference(a.Lefthand == null ? Value.Null : a.Lefthand.Eval(), a.Name, v1, v2);

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
        [MethodImpl(C.MethodImplOptions_AggressiveInlining)]
        static Value Binary(Expression node, Func<Value, Value, Value> func)
        {
            var expr = node as BinaryExpression;

            var a = expr.Left.Eval();
            var b = expr.Right.Eval();

            return func(a, b);
        }

        [MethodImpl(C.MethodImplOptions_AggressiveInlining)]
        static Value Unary(Expression node)
        {
            return (node as UnaryExpression).Operand.Eval();
        }
        #endregion
    }
}
