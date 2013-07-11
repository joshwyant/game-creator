using System;

namespace GameCreator.Framework.Gml.Interpreter
{
    static class Expressions
    {
        #region Error
        public static Value Error(string str, AstNode node) // Wow, this is wrong.
        {
            throw new ProgramError(str, ErrorSeverity.Error, node.Line, node.Column);
        }
        #endregion

        #region Additive
        [Expression(Kind = ExpressionKind.Addition)]
        public static Value Addition(Expression node)
        {
            var expr = (Addition)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return new Value(v1.Real + v2.Real);
            else if (v1.IsString && v2.IsString)
                return new Value(v1.String + v2.String);
            else
                return Error("Wrong type of arguments to +.", node);
        }
        #endregion

        #region Bitwise
        [Expression(Kind = ExpressionKind.BitwiseAnd)]
        public static Value BitwiseAnd(Expression node)
        {
            var expr = (BitwiseAnd)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return (double)(Convert.ToInt64(v1.Real) & Convert.ToInt64(v2.Real));
            else
                return Error("Wrong type of arguments for &.", node);
        }

        [Expression(Kind = ExpressionKind.BitwiseOr)]
        public static Value BitwiseOr(Expression node)
        {
            var expr = (BitwiseOr)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return (double)(Convert.ToInt64(v1.Real) | Convert.ToInt64(v2.Real));
            else
                return Error("Wrong type of arguments for |.", node);
        }

        [Expression(Kind = ExpressionKind.BitwiseXor)]
        public static Value BitwiseXor(Expression node)
        {
            var expr = (BitwiseXor)node;

            var v1 = Delegator.Eval(expr.Left);
            var v2 = Delegator.Eval(expr.Right);

            if (v1.IsReal && v2.IsReal)
                return (double)(Convert.ToInt64(v1.Real) ^ Convert.ToInt64(v2.Real));
            else
                return Error("Wrong type of arguments for ^.", node);
        }
        #endregion
    }
}
