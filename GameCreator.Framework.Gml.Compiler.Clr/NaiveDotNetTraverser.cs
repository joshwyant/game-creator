using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Compiler.Clr
{
    class NaiveDotNetTraverser : NodeVisitor
    {
        #region Properties
        public DotNetCompiler Compiler { get; set; }
        public ILGenerator IL { get; set; }
        #endregion

        #region Private
        static readonly Type value_t = typeof(Value);
        static readonly Type error_t = typeof(ProgramError);
        readonly Stack<Label> ContinueLabels = new Stack<Label>();
        readonly Stack<Label> BreakLabels = new Stack<Label>();
        Label ExitLabel;
        #endregion

        #region Constructor
        public NaiveDotNetTraverser(DotNetCompiler compiler, ILGenerator generator)
        {
            Compiler = compiler;
            IL = generator;
        }
        #endregion

        #region Helpers
        void EmitBinaryExpression(BinaryExpression expr, MethodInfo method)
        {
            // Compute the operands
            VisitExpression(expr.Left);
            VisitExpression(expr.Right);

            // Call the operator method
            IL.Emit(OpCodes.Call, method);
        }
        void EmitUnaryExpression(UnaryExpression expr, MethodInfo method)
        {
            // Compute the operands
            VisitExpression(expr.Operand);

            // Call the operator method
            IL.Emit(OpCodes.Call, method);
        }
        void EmitImplicitConversion(Type t)
        {
            if (t != typeof(Value))
                IL.Emit(OpCodes.Call, value_t.GetMethods().Single(m => m.Name == "op_Implicit" && m.ReturnType == t));
        }
        void BeginMethod()
        {
            ExitLabel = IL.DefineLabel();
            ContinueLabels.Push(ExitLabel);
            BreakLabels.Push(ExitLabel);
        }
        void EndMethod(bool returnNull)
        {
            ContinueLabels.Pop();
            BreakLabels.Pop();

            IL.MarkLabel(ExitLabel);
            if (returnNull)
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Null"));

            IL.Emit(OpCodes.Ret);
        }
        void EmitUsing(LocalBuilder local, System.Action body)
        {
            var endFinally = IL.DefineLabel();

            IL.BeginExceptionBlock();

            body();

            IL.BeginFinallyBlock();

            IL.Emit(OpCodes.Ldloc, local);
            IL.Emit(OpCodes.Ldnull);
            IL.Emit(OpCodes.Beq, endFinally);

            IL.Emit(OpCodes.Ldloc, local);
            IL.Emit(OpCodes.Callvirt, typeof(IDisposable).GetMethod("Dispose"));

            IL.MarkLabel(endFinally);
            IL.EndExceptionBlock();
        }
        void EmitLoopSkeleton(Label continueLabel, System.Action<Label> body)
        {
            Label breakLabel;

            if (continueLabel != null)
                ContinueLabels.Push(continueLabel);
            BreakLabels.Push(breakLabel = IL.DefineLabel());

            body(breakLabel);

            IL.MarkLabel(breakLabel);

            if (continueLabel != null)
                ContinueLabels.Pop();
            BreakLabels.Pop();
        }
        void EmitForEach(Type elementType, System.Action body)
        {
            var enumerable_t = typeof(IEnumerable<>).MakeGenericType(new[] { elementType });
            var enumerator_t = typeof(IEnumerator<>).MakeGenericType(new[] { elementType });

            var local = IL.DeclareLocal(elementType);
            var enumerator = IL.DeclareLocal(enumerator_t);
            var tmp = IL.DeclareLocal(typeof(bool));

            var continueLabel = IL.DefineLabel();
            var loop = IL.DefineLabel();

            IL.Emit(OpCodes.Callvirt, enumerable_t.GetMethod("GetEnumerator"));
            IL.Emit(OpCodes.Stloc, enumerator);

            EmitLoopSkeleton(continueLabel, (breakLabel) =>
            {
                EmitUsing(enumerator, () =>
                {
                    IL.Emit(OpCodes.Br, continueLabel);

                    IL.MarkLabel(loop);

                    IL.Emit(OpCodes.Ldloc, enumerator);
                    IL.Emit(OpCodes.Callvirt, enumerator_t.GetProperty("Current").GetGetMethod());

                    body();

                    IL.MarkLabel(continueLabel);
                    IL.Emit(OpCodes.Ldloc, enumerator);
                    IL.Emit(OpCodes.Callvirt, enumerator_t.GetMethod("MoveNext"));
                    IL.Emit(OpCodes.Brtrue, loop);
                });
            });
        }
        #endregion

        #region Expressions
        public override void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            MethodInfo method = null;

            switch (binaryExpression.Kind)
            {
                case ExpressionKind.Addition:
                    method = value_t.GetMethod("op_Addition");
                    break;
                case ExpressionKind.BitwiseAnd:
                    method = value_t.GetMethod("op_BitwiseAnd");
                    break;
                case ExpressionKind.BitwiseOr:
                    method = value_t.GetMethod("op_BitwiseOr");
                    break;
                case ExpressionKind.BitwiseXor:
                    method = value_t.GetMethod("op_ExclusiveOr");
                    break;
                case ExpressionKind.Div:
                    method = value_t.GetMethod("IntegerDivision");
                    break;
                case ExpressionKind.Divide:
                    method = value_t.GetMethod("op_Division");
                    break;
                case ExpressionKind.Equality:
                    method = value_t.GetMethod("op_Equality");
                    break;
                case ExpressionKind.GreaterThan:
                    method = value_t.GetMethod("op_GreaterThan");
                    break;
                case ExpressionKind.GreaterThanOrEqual:
                    method = value_t.GetMethod("op_GreaterThanOrEqual");
                    break;
                case ExpressionKind.LessThan:
                    method = value_t.GetMethod("op_LessThan");
                    break;
                case ExpressionKind.LessThanOrEqual:
                    method = value_t.GetMethod("op_LessThanOrEqual");
                    break;
                case ExpressionKind.LogicalAnd:
                    method = value_t.GetMethod("LogicalAnd");
                    break;
                case ExpressionKind.LogicalOr:
                    method = value_t.GetMethod("LogicalOr");
                    break;
                case ExpressionKind.LogicalXor:
                    method = value_t.GetMethod("LogicalXor");
                    break;
                case ExpressionKind.Mod:
                    method = value_t.GetMethod("op_Modulus");
                    break;
                case ExpressionKind.Multiply:
                    method = value_t.GetMethod("op_Multiply");
                    break;
                case ExpressionKind.NotEqual:
                    method = value_t.GetMethod("op_Inequality");
                    break;
                case ExpressionKind.ShiftLeft:
                    method = value_t.GetMethod("ShiftLeft");
                    break;
                case ExpressionKind.ShiftRight:
                    method = value_t.GetMethod("ShiftRight");
                    break;
                case ExpressionKind.Subtraction:
                    method = value_t.GetMethod("op_Subtraction");
                    break;
            }

            EmitBinaryExpression(binaryExpression, method);
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
            MethodInfo method = null;

            switch (unaryExpression.Kind)
            {
                case ExpressionKind.Not:
                    method = value_t.GetMethod("op_LogicalNot");
                    break;
                case ExpressionKind.Minus:
                    method = value_t.GetMethod("op_UnaryNegation");
                    break;
                case ExpressionKind.Plus:
                    method = value_t.GetMethod("op_UnaryPlus");
                    break;
                case ExpressionKind.Complement:
                    method = value_t.GetMethod("op_OnesComplement");
                    break;
            }

            EmitUnaryExpression(unaryExpression, method);
        }

        public override void VisitCall(Call call)
        {
            MethodInfo method;

            if (call.Function is Script)
                method = Compiler.Scripts[call.Function.Name];
            else
                method = (call.Function as BaseFunction).MethodInfo;

            var isArray = false;
            var parms = method.GetParameters();
            var argc = parms.Length;
            Type elemType = null;
            if (parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any()))
            {
                if (argc != 1)
                    throw new InvalidOperationException("Method signature not supported.");

                isArray = true;
                argc = call.Expressions.Length;
                elemType = method.GetParameters().Single().ParameterType.GetElementType();
            }

            if (argc != call.Expressions.Length)
                throw new InvalidOperationException();

            if (isArray)
            {
                IL.Emit(OpCodes.Ldc_I4_S, argc);
                IL.Emit(OpCodes.Newarr, elemType);
            }

            for (int i = 0; i < call.Expressions.Length; i++)
            {
                if (isArray)
                {
                    IL.Emit(OpCodes.Dup);
                    IL.Emit(OpCodes.Ldc_I4_S, i);
                }

                VisitExpression(call.Expressions[i]);
                EmitImplicitConversion(isArray ? elemType : parms[i].ParameterType);

                if (isArray)
                    IL.Emit(OpCodes.Stelem, elemType);
            }

            IL.Emit(OpCodes.Call, method);

            if (method.ReturnType == typeof(void))
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Null"));
        }

        public override void VisitAccess(Access access)
        {
            if (access.Lefthand == null)
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Null"));
            else
                VisitExpression(access.Lefthand);

            IL.Emit(OpCodes.Ldstr, access.Name);

            int secondIndex = (access.Indices.Length >= 2) ? 1 : 0;

            // Evaluate array indices
            if (access.Indices.Length >= 2)
                VisitExpression(access.Indices[0]);
            else
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Zero"));

            if (access.Indices.Length >= 1)
                VisitExpression(access.Indices[secondIndex]);
            else
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Zero"));

            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("Dereference"));
        }

        public override void VisitGrouping(Grouping grouping)
        {
            VisitExpression(grouping.InnerExpression);
        }
        #endregion

        #region Statements
        public override void VisitWith(With with)
        {
            var inst = IL.DeclareLocal(typeof(RuntimeInstance));

            VisitExpression(with.Instance);

            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("WithInstance"));

            EmitForEach(typeof(RuntimeInstance), () =>
            {
                IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetProperty("Current").GetSetMethod());

                VisitStatement(with.Body);
            });
        }

        public override void VisitWhile(While p)
        {
            var continueLabel = IL.DefineLabel();

            EmitLoopSkeleton(continueLabel, (breakLabel) =>
            {
                IL.MarkLabel(continueLabel);
                VisitExpression(p.Expression);
                EmitImplicitConversion(typeof(bool));
                IL.Emit(OpCodes.Brfalse, breakLabel);

                VisitStatement(p.Body);

                IL.Emit(OpCodes.Br, continueLabel);
            });
        }

        public override void VisitVar(Var var)
        {
            // Create the array
            IL.Emit(OpCodes.Ldc_I4, var.Variables.Length);
            IL.Emit(OpCodes.Newarr, typeof(string));

            // Set each index of the array to a string
            // arr[i] = var[i]
            for (int i = 0; i < var.Variables.Length; i++)
            {
                IL.Emit(OpCodes.Dup);
                IL.Emit(OpCodes.Ldc_I4, i);
                IL.Emit(OpCodes.Ldstr, var.Variables[i]);
                IL.Emit(OpCodes.Stelem, typeof(string));
            }

            // Call ExecutionContext.LocalVars(string[] vars)
            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("LocalVars"));
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
            // Create the array
            IL.Emit(OpCodes.Ldc_I4, globalvar.Variables.Length);
            IL.Emit(OpCodes.Newarr, typeof(string));

            // Set each index of the array to a string
            // arr[i] = var[i]
            for (int i = 0; i < globalvar.Variables.Length; i++)
            {
                IL.Emit(OpCodes.Dup);
                IL.Emit(OpCodes.Ldc_I4, i);
                IL.Emit(OpCodes.Ldstr, globalvar.Variables[i]);
                IL.Emit(OpCodes.Stelem, typeof(string));
            }

            // Call ExecutionContext.GlobalVars(string[] vars)
            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("GlobalVars"));
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
        #endregion
    }
}
