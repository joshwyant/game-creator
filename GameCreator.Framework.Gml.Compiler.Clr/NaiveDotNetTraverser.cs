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
        static readonly MethodInfo isReal = typeof(Value).GetProperty("IsReal").GetGetMethod();
        static readonly MethodInfo isString = typeof(Value).GetProperty("IsString").GetGetMethod();
        static readonly MethodInfo isNull = typeof(Value).GetProperty("IsNull").GetGetMethod();
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
        public void BeginMethod()
        {
            ExitLabel = IL.DefineLabel();
            ContinueLabels.Push(ExitLabel);
            BreakLabels.Push(ExitLabel);
        }
        public void EndMethod(bool returnNull)
        {
            ContinueLabels.Pop();
            BreakLabels.Pop();

            IL.MarkLabel(ExitLabel);
            if (returnNull)
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Null"));

            IL.Emit(OpCodes.Ret);
        }
        public void LoadArguments()
        {
            IL.Emit(OpCodes.Ldarg_0);
            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("SetArguments"));
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
        void EmitLoopSkeleton(Label? continueLabel, System.Action<Label> body)
        {
            Label breakLabel;

            if (continueLabel.HasValue)
                ContinueLabels.Push(continueLabel.Value);
            BreakLabels.Push(breakLabel = IL.DefineLabel());

            body(breakLabel);

            IL.MarkLabel(breakLabel);

            if (continueLabel.HasValue)
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
                case ExpressionKind.Subtraction:
                    method = value_t.GetMethod("op_Subtraction");
                    break;
                case ExpressionKind.Multiply:
                    method = value_t.GetMethod("op_Multiply");
                    break;
                case ExpressionKind.Divide:
                    method = value_t.GetMethod("op_Division");
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
                case ExpressionKind.NotEqual:
                    method = value_t.GetMethod("op_Inequality");
                    break;
                case ExpressionKind.ShiftLeft:
                    method = value_t.GetMethod("ShiftLeft");
                    break;
                case ExpressionKind.ShiftRight:
                    method = value_t.GetMethod("ShiftRight");
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
            IL.BeginScope();
            EmitLoopSkeleton(null, (breakLabel) => {

                // Evaluate the test expression
                var e = IL.DeclareLocal(typeof(Value));
                VisitExpression(p.Expression);
                IL.Emit(OpCodes.Stloc, e);

                // Build an array of cases
                var cases = p.Statements
                    .Where(s => s.Kind == StatementKind.Case || s.Kind == StatementKind.Default)
                    .Select(s => new { s, l = IL.DefineLabel() })
                    .ToArray();

                // Emit the case tests
                foreach (var c in cases)
                {
                    if (c.s.Kind == StatementKind.Default)
                        IL.Emit(OpCodes.Br, c.l);
                    else
                    {
                        VisitExpression((c.s as Case).Expression);
                        IL.Emit(OpCodes.Ldloc, e);
                        IL.Emit(OpCodes.Call, value_t.GetMethod("op_Equality"));
                        IL.Emit(OpCodes.Brtrue, c.l);
                    }
                }

                // Break if none of the cases were met.
                IL.Emit(OpCodes.Br, breakLabel);

                int icases = 0;

                // Emit all the case statements
                foreach (var stmt in p.Statements)
                {
                    switch (stmt.Kind)
                    {
                        case StatementKind.Case:
                        case StatementKind.Default:
                            // Mark case labels
                            IL.MarkLabel(cases[icases++].l);
                            break;
                        default:
                            // Emit case statement
                            VisitStatement(stmt);
                            break;
                    }
                }
            });
            IL.EndScope();
        }

        public override void VisitSequence(Sequence sequence)
        {
            VisitStatement(sequence.First);
            VisitStatement(sequence.Second);
        }

        public override void VisitReturn(Return p)
        {
            VisitExpression(p.Expression);

            IL.Emit(OpCodes.Ret);
        }

        public override void VisitRepeat(Repeat repeat)
        {
            VisitExpression(repeat.Expression);

            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("Repeat"));

            EmitForEach(typeof(int), () =>
            {
                IL.Emit(OpCodes.Pop);

                VisitStatement(repeat.Body);
            });
        }

        public override void VisitNop(Nop nop)
        {
            IL.Emit(OpCodes.Nop);
        }

        public override void VisitIf(If p)
        {
            var end = IL.DefineLabel();
            var elseLabel = IL.DefineLabel();

            VisitExpression(p.Expression);
            EmitImplicitConversion(typeof(bool));
            IL.Emit(OpCodes.Br, elseLabel);

            VisitStatement(p.Body);

            IL.MarkLabel(elseLabel);

            VisitStatement(p.Else);

            IL.MarkLabel(end);
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
            var continueLabel = IL.DefineLabel();

            VisitStatement(p.Initializer);

            EmitLoopSkeleton(continueLabel, (breakLabel) =>
            {
                IL.MarkLabel(continueLabel);
                VisitExpression(p.Test);
                EmitImplicitConversion(typeof(bool));
                IL.Emit(OpCodes.Brfalse, breakLabel);

                VisitStatement(p.Body);
                VisitStatement(p.Iterator);

                IL.Emit(OpCodes.Br, continueLabel);
            });
        }

        public override void VisitExit(Exit exit)
        {
            IL.Emit(OpCodes.Br, ExitLabel);
        }

        public override void VisitDo(Do p)
        {
            var continueLabel = IL.DefineLabel();
            var loop = IL.DefineLabel();

            EmitLoopSkeleton(continueLabel, (breakLabel) =>
            {
                IL.MarkLabel(loop);
                VisitStatement(p.Body);

                IL.MarkLabel(continueLabel);
                VisitExpression(p.Expression);
                EmitImplicitConversion(typeof(bool));
                IL.Emit(OpCodes.Brfalse, loop);
            });
        }

        public override void VisitDefaultCaseLabel(Default p)
        {
            throw new InvalidOperationException();
        }

        public override void VisitContinue(Continue p)
        {
            IL.Emit(OpCodes.Br, ContinueLabels.Peek());
        }

        public override void VisitCaseLabel(Case p)
        {
            throw new InvalidOperationException();
        }

        public override void VisitCallStatement(CallStatement callStatement)
        {
            VisitCall(callStatement.Call);

            IL.Emit(OpCodes.Pop);
        }

        public override void VisitBreak(Break p)
        {
            IL.Emit(OpCodes.Br, BreakLabels.Peek());
        }

        public override void VisitAssignment(Assignment assignment)
        {
            IL.BeginScope();
            var a = IL.DeclareLocal(value_t);
            var b = IL.DeclareLocal(value_t);
            var i1 = IL.DeclareLocal(value_t);
            var i2 = IL.DeclareLocal(value_t);

            // Do we want to evaluate the lefthand side of the access?
            if (assignment.Lefthand.Lefthand != null)
            {
                VisitExpression(assignment.Lefthand.Lefthand);
                IL.Emit(OpCodes.Stloc, a);
                IL.Emit(OpCodes.Ldloc, a);
                EmitImplicitConversion(typeof(int));
            }

            // Name argument
            IL.Emit(OpCodes.Ldstr, assignment.Lefthand.Name);

            // Array indices

            if (assignment.Lefthand.Indices.Length != 2)
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Zero"));
            else
                VisitExpression(assignment.Lefthand.Indices[0]);
            IL.Emit(OpCodes.Stloc, i1);

            if (assignment.Lefthand.Indices.Length == 0)
                IL.Emit(OpCodes.Ldsfld, value_t.GetField("Zero"));
            else
                VisitExpression(assignment.Lefthand.Indices[assignment.Lefthand.Indices.Length - 1]);
            IL.Emit(OpCodes.Stloc, i2);

            // Check indices
            IL.Emit(OpCodes.Ldloc, i1);
            IL.Emit(OpCodes.Ldloc, i2);
            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("ValidateArray"));

            // Convert indices to int
            IL.Emit(OpCodes.Ldloc, i1);
            EmitImplicitConversion(typeof(int));
            IL.Emit(OpCodes.Ldloc, i2);
            EmitImplicitConversion(typeof(int));

            // First argument to an operator assignment is the current value.
            if (assignment.Kind != StatementKind.Assignment)
                IL.Emit(OpCodes.Ldloc, a);
            
            // Right operand to the assignment operator
            VisitExpression(assignment.Expression);
            IL.Emit(OpCodes.Stloc, b);
            IL.Emit(OpCodes.Ldloc, b);

            // Type checks
            #region
            var dontAssign = IL.DefineLabel();

            switch (assignment.Kind)
            {
                case StatementKind.AndAssignment:
                case StatementKind.OrAssignment:
                case StatementKind.SubtractionAssignment:
                case StatementKind.XorAssignment:
                    #region A and B are reals
                    IL.Emit(OpCodes.Ldloc, a);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.Ldloc, b);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.And);
                    break;
                    #endregion
                case StatementKind.AdditionAssignment:
                    #region A and B are reals or strings
                    IL.Emit(OpCodes.Ldloc, a);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.Ldloc, b);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.And);
                    IL.Emit(OpCodes.Ldloc, a);
                    IL.Emit(OpCodes.Call, isString);
                    IL.Emit(OpCodes.Ldloc, b);
                    IL.Emit(OpCodes.Call, isString);
                    IL.Emit(OpCodes.And);
                    IL.Emit(OpCodes.Or);
                    break;
                    #endregion
                case StatementKind.MultiplyAssignment:
                    #region A is real
                    IL.Emit(OpCodes.Ldloc, a);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.Ldloc, b);
                    IL.Emit(OpCodes.Call, isNull);
                    IL.Emit(OpCodes.Not);
                    IL.Emit(OpCodes.And);
                    break;
                    #endregion
                case StatementKind.DivideAssignment:
                    #region Reals and B != 0
                    IL.Emit(OpCodes.Ldloc, a);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.Ldloc, b);
                    IL.Emit(OpCodes.Call, isReal);
                    IL.Emit(OpCodes.And);
                    IL.Emit(OpCodes.Call, value_t.GetProperty("Real").GetGetMethod());
                    IL.Emit(OpCodes.Ldc_R8, 0.0);
                    IL.Emit(OpCodes.Ceq);
                    IL.Emit(OpCodes.And);
                    break;
                    #endregion
            }
            if (assignment.Kind != StatementKind.Assignment)
                IL.Emit(OpCodes.Brfalse, dontAssign);
            #endregion

            // Assignment
            switch (assignment.Kind)
            {
                case StatementKind.AdditionAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Addition"));
                    break;
                case StatementKind.SubtractionAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Subtraction"));
                    break;
                case StatementKind.MultiplyAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Multiply"));
                    break;
                case StatementKind.DivideAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Division"));
                    break;
                case StatementKind.AndAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_BitwiseAnd"));
                    break;
                case StatementKind.OrAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_BitwiseOr"));
                    break;
                case StatementKind.XorAssignment:
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_ExclusiveOr"));
                    break;
            }

            // Choose method
            var instanceTypes = new[] { typeof(int), typeof(string), typeof(int), typeof(int), value_t };
            var localTypes = new[] { typeof(string), typeof(int), typeof(int), value_t };

            IL.Emit(OpCodes.Call, typeof(ExecutionContext).GetMethod("SetVar", assignment.Lefthand == null ? localTypes : instanceTypes));

            IL.MarkLabel(dontAssign);
            IL.EndScope();
        }
        #endregion
    }
}
