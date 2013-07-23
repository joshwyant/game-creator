using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Misc
{
    public abstract class NodeVisitor
    {
        #region Main Traversal
        public void VisitExpression(Expression e)
        {
            switch (e.Kind)
            {
                case ExpressionKind.Addition:
                case ExpressionKind.BitwiseAnd:
                case ExpressionKind.BitwiseOr:
                case ExpressionKind.BitwiseXor:
                case ExpressionKind.Div:
                case ExpressionKind.Divide:
                case ExpressionKind.Equality:
                case ExpressionKind.GreaterThan:
                case ExpressionKind.GreaterThanOrEqual:
                case ExpressionKind.LessThan:
                case ExpressionKind.LessThanOrEqual:
                case ExpressionKind.LogicalAnd:
                case ExpressionKind.LogicalOr:
                case ExpressionKind.LogicalXor:
                case ExpressionKind.Mod:
                case ExpressionKind.Multiply:
                case ExpressionKind.NotEqual:
                case ExpressionKind.ShiftLeft:
                case ExpressionKind.ShiftRight:
                case ExpressionKind.Subtraction:
                    VisitBinaryExpression(e as BinaryExpression);
                    break;
                case ExpressionKind.Access:
                    VisitAccess(e as Access);
                    break;
                case ExpressionKind.Call:
                    VisitCall(e as Call);
                    break;
                case ExpressionKind.Complement:
                case ExpressionKind.Minus:
                case ExpressionKind.Not:
                case ExpressionKind.Plus:
                    VisitUnary(e as UnaryExpression);
                    break;
                case ExpressionKind.Constant:
                    VisitConstant(e as Constant);
                    break;
                case ExpressionKind.Grouping:
                    VisitExpression((e as Grouping).InnerExpression);
                    break;
                case ExpressionKind.None:
                    VisitEmptyExpression(e as Expression);
                    break;
                case ExpressionKind.Id:
                    throw new InvalidOperationException();
            }
        }

        public void VisitStatement(Statement s)
        {
            switch (s.Kind)
            {
                case StatementKind.AdditionAssignment:
                case StatementKind.AndAssignment:
                case StatementKind.Assignment:
                case StatementKind.DivideAssignment:
                case StatementKind.MultiplyAssignment:
                case StatementKind.OrAssignment:
                case StatementKind.SubtractionAssignment:
                case StatementKind.XorAssignment:
                    VisitAssignment(s as Assignment);
                    break;
                case StatementKind.Break:
                    VisitBreak(s as Break);
                    break;
                case StatementKind.Call:
                    VisitCallStatement(s as CallStatement);
                    break;
                case StatementKind.Case:
                    VisitCaseLabel(s as Case);
                    break;
                case StatementKind.Continue:
                    VisitContinue(s as Continue);
                    break;
                case StatementKind.Default:
                    VisitDefaultCaseLabel(s as Default);
                    break;
                case StatementKind.Do:
                    VisitDo(s as Do);
                    break;
                case StatementKind.Exit:
                    VisitExit(s as Exit);
                    break;
                case StatementKind.For:
                    VisitFor(s as For);
                    break;
                case StatementKind.Globalvar:
                    VisitGlobalvar(s as Globalvar);
                    break;
                case StatementKind.If:
                    VisitIf(s as If);
                    break;
                case StatementKind.Nop:
                    VisitNop(s as Nop);
                    break;
                case StatementKind.Repeat:
                    VisitRepeat(s as Repeat);
                    break;
                case StatementKind.Return:
                    VisitReturn(s as Return);
                    break;
                case StatementKind.Sequence:
                    VisitSequence(s as Sequence);
                    break;
                case StatementKind.Switch:
                    VisitSwitch(s as Switch);
                    break;
                case StatementKind.Var:
                    VisitVar(s as Var);
                    break;
                case StatementKind.While:
                    VisitWhile(s as While);
                    break;
                case StatementKind.With:
                    VisitWith(s as With);
                    break;
            }
        }
        #endregion

        #region Abstract Expression Visitors
        public abstract void VisitBinaryExpression(BinaryExpression binaryExpression);

        public abstract void VisitConstant(Constant constant);

        public abstract void VisitUnary(UnaryExpression unaryExpression);

        public abstract void VisitCall(Call call);

        public abstract void VisitAccess(Access access);

        public abstract void VisitEmptyExpression(Expression expression);
        #endregion

        #region Abstract Statement Visitors
        public abstract void VisitWith(With with);

        public abstract void VisitWhile(While p);

        public abstract void VisitVar(Var var);

        public abstract void VisitSwitch(Switch p);

        public abstract void VisitSequence(Sequence sequence);

        public abstract void VisitReturn(Return p);

        public abstract void VisitRepeat(Repeat repeat);

        public abstract void VisitNop(Nop nop);

        public abstract void VisitIf(If p);

        public abstract void VisitGlobalvar(Globalvar globalvar);

        public abstract void VisitFor(For p);

        public abstract void VisitExit(Exit exit);

        public abstract void VisitDo(Do p);

        public abstract void VisitDefaultCaseLabel(Default p);

        public abstract void VisitContinue(Continue p);

        public abstract void VisitCaseLabel(Case p);

        public abstract void VisitCallStatement(CallStatement callStatement);

        public abstract void VisitBreak(Break p);

        public abstract void VisitAssignment(Assignment assignment);
        #endregion
    }
}
