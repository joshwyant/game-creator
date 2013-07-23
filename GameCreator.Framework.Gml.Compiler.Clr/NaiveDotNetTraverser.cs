using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace GameCreator.Framework.Gml.Compiler.Clr
{
    class NaiveDotNetTraverser : NodeVisitor
    {
        public DotNetCompiler Compiler { get; set; }
        public ILGenerator IL { get; set; }

        Type value_t = typeof(Value);

        public NaiveDotNetTraverser(DotNetCompiler compiler, ILGenerator generator)
        {
            Compiler = compiler;
            IL = generator;
        }

        public override void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            VisitExpression(binaryExpression.Left);
            VisitExpression(binaryExpression.Right);

            switch (binaryExpression.Kind)
            {
                case ExpressionKind.Addition:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Addition"));
                    break;
                case ExpressionKind.BitwiseAnd:
                case ExpressionKind.BitwiseOr:
                case ExpressionKind.BitwiseXor:
                case ExpressionKind.Div:
                case ExpressionKind.Divide:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Division"));
                    break;
                case ExpressionKind.Equality:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Equality"));
                    break;
                case ExpressionKind.GreaterThan:
                case ExpressionKind.GreaterThanOrEqual:
                case ExpressionKind.LessThan:
                case ExpressionKind.LessThanOrEqual:
                case ExpressionKind.LogicalAnd:
                case ExpressionKind.LogicalOr:
                case ExpressionKind.LogicalXor:
                case ExpressionKind.Mod:
                case ExpressionKind.Multiply:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Multiplication"));
                    break;
                case ExpressionKind.NotEqual:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Inequality"));
                    break;
                case ExpressionKind.ShiftLeft:
                case ExpressionKind.ShiftRight:
                case ExpressionKind.Subtraction:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Subtraction"));
                    break;
            }
        }

        public override void VisitConstant(Constant constant)
        {
            if (constant.Value.IsReal)
                IL.Emit(OpCodes.Ldc_R8, constant.Value.Real);
            else
                IL.Emit(OpCodes.Ldstr, constant.Value.String);

            IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { constant.Value.IsReal ? typeof(double) : typeof(string) }));
        }

        public override void VisitUnary(UnaryExpression unaryExpression)
        {
            throw new NotImplementedException();
        }

        public override void VisitCall(Call call)
        {
            throw new NotImplementedException();
        }

        public override void VisitAccess(Access access)
        {
            throw new NotImplementedException();
        }

        public override void VisitEmptyExpression(Expression expression)
        {
            throw new NotImplementedException();
        }

        public override void VisitWith(With with)
        {
            throw new NotImplementedException();
        }

        public override void VisitWhile(While p)
        {
            throw new NotImplementedException();
        }

        public override void VisitVar(Var var)
        {
            throw new NotImplementedException();
        }

        public override void VisitSwitch(Switch p)
        {
            throw new NotImplementedException();
        }

        public override void VisitSequence(Sequence sequence)
        {
            throw new NotImplementedException();
        }

        public override void VisitReturn(Return p)
        {
            throw new NotImplementedException();
        }

        public override void VisitRepeat(Repeat repeat)
        {
            throw new NotImplementedException();
        }

        public override void VisitNop(Nop nop)
        {
            throw new NotImplementedException();
        }

        public override void VisitIf(If p)
        {
            throw new NotImplementedException();
        }

        public override void VisitGlobalvar(Globalvar globalvar)
        {
            throw new NotImplementedException();
        }

        public override void VisitFor(For p)
        {
            throw new NotImplementedException();
        }

        public override void VisitExit(Exit exit)
        {
            throw new NotImplementedException();
        }

        public override void VisitDo(Do p)
        {
            throw new NotImplementedException();
        }

        public override void VisitDefaultCaseLabel(Default p)
        {
            throw new NotImplementedException();
        }

        public override void VisitContinue(Continue p)
        {
            throw new NotImplementedException();
        }

        public override void VisitCaseLabel(Case p)
        {
            throw new NotImplementedException();
        }

        public override void VisitCallStatement(CallStatement callStatement)
        {
            throw new NotImplementedException();
        }

        public override void VisitBreak(Break p)
        {
            throw new NotImplementedException();
        }

        public override void VisitAssignment(Assignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}
