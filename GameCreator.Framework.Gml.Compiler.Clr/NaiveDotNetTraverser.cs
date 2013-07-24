using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

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
        Label wrongTypeError;
        Label wrongTypeErrorLogical;
        LocalBuilder offendingOperator;
        #endregion

        #region Constructor
        public NaiveDotNetTraverser(DotNetCompiler compiler, ILGenerator generator)
        {
            Compiler = compiler;
            IL = generator;
            wrongTypeError = IL.DefineLabel();
        }
        #endregion

        public void Finalize()
        {
            IL.MarkLabel(wrongTypeError);
            IL.Emit(OpCodes.Ldc_I4, (int)Error.WrongArgumentTypes);
            IL.Emit(OpCodes.Ldloc, offendingOperator);
            IL.Emit(OpCodes.Newobj, error_t.GetConstructor(new[] { typeof(Error), typeof(object) }));
            IL.Emit(OpCodes.Throw);
            IL.MarkLabel(wrongTypeErrorLogical);
            IL.Emit(OpCodes.Ldc_I4, (int)Error.WrongArgumentTypesLogical);
            IL.Emit(OpCodes.Ldloc, offendingOperator);
            IL.Emit(OpCodes.Newobj, error_t.GetConstructor(new[] { typeof(Error), typeof(object) }));
            IL.Emit(OpCodes.Throw);
        }

        #region Helpers
        void EmitReals(BinaryExpression expr, string op, TypeCode typecode, bool bitwise)
        {
            var label = IL.DefineLabel();

            var isreal = value_t.GetProperty("IsReal").GetGetMethod();
            var real = value_t.GetProperty("Real").GetGetMethod();

            IL.BeginScope();
            var val1 = IL.DeclareLocal(typeof(Value));
            var val2 = IL.DeclareLocal(typeof(Value));

            // Compute the operands
            VisitExpression(expr.Left);
            IL.Emit(OpCodes.Stloc, val1);
            VisitExpression(expr.Right);
            IL.Emit(OpCodes.Stloc, val2);

            // Make sure they are reals
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, isreal);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, isreal);
            IL.Emit(OpCodes.And);
            IL.Emit(OpCodes.Ldstr, op);
            IL.Emit(OpCodes.Stloc, offendingOperator);
            IL.Emit(OpCodes.Brfalse, bitwise ? wrongTypeErrorLogical : wrongTypeError);

            // Get the values
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, real);
            switch (typecode)
            {
                case TypeCode.Int64:
                    IL.Emit(OpCodes.Conv_I8);
                    break;
                case TypeCode.Boolean:
                    IL.Emit(OpCodes.Ldc_R8, 0.0);
                    IL.Emit(OpCodes.Cgt);
                    break;
            }
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, real);
            switch (typecode)
            {
                case TypeCode.Int64:
                    IL.Emit(OpCodes.Conv_I8);
                    break;
                case TypeCode.Boolean:
                    IL.Emit(OpCodes.Ldc_R8, 0.0);
                    IL.Emit(OpCodes.Cgt);
                    break;
            }

            IL.EndScope();
        }
        void EmitCompare(BinaryExpression expr, string op, OpCode opcode, bool invert)
        {
            var reallabel = IL.DefineLabel();
            var stringlabel = IL.DefineLabel();
            var endlabel = IL.DefineLabel();

            var isreal = value_t.GetProperty("IsReal").GetGetMethod();
            var isstring = value_t.GetProperty("IsString").GetGetMethod();
            var real = value_t.GetProperty("Real").GetGetMethod();
            var str = value_t.GetProperty("String").GetGetMethod();

            IL.BeginScope();
            var val1 = IL.DeclareLocal(typeof(Value));
            var val2 = IL.DeclareLocal(typeof(Value));

            // Compute the operands
            VisitExpression(expr.Left);
            IL.Emit(OpCodes.Stloc, val1);
            VisitExpression(expr.Right);
            IL.Emit(OpCodes.Stloc, val2);

            // Check if they are reals
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, isreal);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, isreal);
            IL.Emit(OpCodes.And);
            IL.Emit(OpCodes.Brtrue, reallabel);

            // Check if they are strings
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, isstring);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, isstring);
            IL.Emit(OpCodes.And);
            IL.Emit(OpCodes.Brtrue, stringlabel);

            // Error message
            IL.Emit(OpCodes.Ldstr, op);
            IL.Emit(OpCodes.Stloc, offendingOperator);
            IL.Emit(OpCodes.Br, wrongTypeErrorLogical);

            IL.MarkLabel(reallabel);

            // Compare real values
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, real);
            IL.Emit(OpCodes.Ldc_R8, 0.0);
            IL.Emit(OpCodes.Cgt);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, real);
            IL.Emit(OpCodes.Ldc_R8, 0.0);
            IL.Emit(OpCodes.Cgt);
            IL.Emit(OpCodes.Br, endlabel);

            // Compare string values
            var compareordinal =
                typeof(string).GetMethod("CompareOrdinal",
                    BindingFlags.Public | BindingFlags.Static,
                    null, new[] { typeof(string), typeof(string) }, null);

            IL.MarkLabel(stringlabel);

            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, str);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, str);
            IL.Emit(OpCodes.Call, compareordinal);
            IL.Emit(OpCodes.Ldc_I4_0);

            IL.MarkLabel(endlabel);

            // Compare them with they opcode in the arguments
            IL.Emit(opcode);
            if (invert)
                IL.Emit(OpCodes.Not);

            // Convert it back into a value
            IL.Emit(OpCodes.Conv_R8);
            IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));

            IL.EndScope();
        }
        void EmitArithmetic(BinaryExpression expr, string op, bool firstIsString, OpCode forreal, System.Action forstring)
        {
            var reallabel = IL.DefineLabel();
            var stringlabel = IL.DefineLabel();
            var endlabel = IL.DefineLabel();

            var isreal = value_t.GetProperty("IsReal").GetGetMethod();
            var isstring = value_t.GetProperty("IsString").GetGetMethod();
            var real = value_t.GetProperty("Real").GetGetMethod();
            var str = value_t.GetProperty("String").GetGetMethod();

            IL.BeginScope();
            var val1 = IL.DeclareLocal(typeof(Value));
            var val2 = IL.DeclareLocal(typeof(Value));

            // Compute the operands
            VisitExpression(expr.Left);
            IL.Emit(OpCodes.Stloc, val1);
            VisitExpression(expr.Right);
            IL.Emit(OpCodes.Stloc, val2);

            // Check if they are reals
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, isreal);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, isreal);
            IL.Emit(OpCodes.And);
            IL.Emit(OpCodes.Brtrue, reallabel);

            // Check if they are strings
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, firstIsString ? isstring : isreal);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, isstring);
            IL.Emit(OpCodes.And);
            IL.Emit(OpCodes.Brtrue, stringlabel);

            // Error message
            IL.Emit(OpCodes.Ldstr, op);
            IL.Emit(OpCodes.Stloc, offendingOperator);
            IL.Emit(OpCodes.Br, wrongTypeError);

            IL.MarkLabel(reallabel);

            // Arithmetic on real values
            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, real);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, real);
            IL.Emit(forreal);
            IL.Emit(OpCodes.Conv_R8);
            IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));
            IL.Emit(OpCodes.Br, endlabel);

            // Arithmetic on string values
            IL.MarkLabel(stringlabel);

            IL.Emit(OpCodes.Ldloc, val1);
            IL.Emit(OpCodes.Call, firstIsString ? str : real);
            IL.Emit(OpCodes.Ldloc, val2);
            IL.Emit(OpCodes.Call, str);
            forstring();

            IL.MarkLabel(endlabel);

            IL.EndScope();
        }
        void EmitBinary(BinaryExpression expr, string op, OpCode[] opcodes, TypeCode typecode, bool convertBack, bool logical)
        {
            EmitReals(expr, op, typecode, logical);
            foreach (var opcode in opcodes)
                IL.Emit(opcode);
            if (convertBack) IL.Emit(OpCodes.Conv_R8);
            IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));
        }
        void EmitBinary(BinaryExpression expr, string op, OpCode opcode, TypeCode typecode, bool convertBack, bool logical)
        {
            EmitBinary(expr, op, new[] { opcode }, typecode, convertBack, logical);
        }
        void EmitShift(BinaryExpression expr, string op, OpCode OpCode)
        {
            EmitReals(expr, op, TypeCode.Int64, true);
            IL.Emit(OpCodes.Conv_I4);
            IL.Emit(OpCode);
            IL.Emit(OpCodes.Conv_R8);
            IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));
        }
        #endregion

        #region Expressions
        public override void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            VisitExpression(binaryExpression.Left);
            VisitExpression(binaryExpression.Right);

            switch (binaryExpression.Kind)
            {
                case ExpressionKind.Addition:
                    EmitArithmetic(binaryExpression, "+", true, OpCodes.Add, () =>
                        {
                            IL.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string) }, null));
                            IL.Emit(OpCodes.Call, typeof(Value).GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static, null, new [] { typeof(string) }, null));
                        });
                    break;
                case ExpressionKind.BitwiseAnd:
                    EmitBinary(binaryExpression, "&", OpCodes.And, TypeCode.Int64, true, true);
                    break;
                case ExpressionKind.BitwiseOr:
                    EmitBinary(binaryExpression, "|", OpCodes.Or, TypeCode.Int64, true, true);
                    break;
                case ExpressionKind.BitwiseXor:
                    EmitBinary(binaryExpression, "^", OpCodes.Xor, TypeCode.Int64, true, true);
                    break;
                case ExpressionKind.Div:
                    EmitBinary(binaryExpression, "div", OpCodes.Div, TypeCode.Int64, true, false);
                    break;
                case ExpressionKind.Divide:
                    EmitBinary(binaryExpression, "/", OpCodes.Div, TypeCode.Double, false, false);
                    break;
                case ExpressionKind.Equality:
                    EmitCompare(binaryExpression, "==", OpCodes.Ceq, false);
                    break;
                case ExpressionKind.GreaterThan:
                    EmitCompare(binaryExpression, ">", OpCodes.Cgt, false);
                    break;
                case ExpressionKind.GreaterThanOrEqual:
                    EmitCompare(binaryExpression, ">=", OpCodes.Clt, true);
                    break;
                case ExpressionKind.LessThan:
                    EmitCompare(binaryExpression, "<", OpCodes.Clt, false);
                    break;
                case ExpressionKind.LessThanOrEqual:
                    EmitCompare(binaryExpression, "<=", OpCodes.Cgt, true);
                    break;
                case ExpressionKind.LogicalAnd:
                    EmitBinary(binaryExpression, "&&", OpCodes.And, TypeCode.Boolean, true, true);
                    break;
                case ExpressionKind.LogicalOr:
                    EmitBinary(binaryExpression, "||", OpCodes.Or, TypeCode.Boolean, true, true);
                    break;
                case ExpressionKind.LogicalXor:
                    EmitBinary(binaryExpression, "^^", OpCodes.Xor, TypeCode.Boolean, true, true);
                    break;
                case ExpressionKind.Mod:
                    EmitBinary(binaryExpression, "mod", OpCodes.Rem, TypeCode.Int64, true, false);
                    break;
                case ExpressionKind.Multiply:
                    EmitArithmetic(binaryExpression, "*", false, OpCodes.Mul, () =>
                    {
                        IL.Emit(OpCodes.Newobj, typeof(Value).GetConstructor(new[] { typeof(double), typeof(string) }));
                        IL.Emit(OpCodes.Unbox);
                    });
                    break;
                case ExpressionKind.NotEqual:
                    EmitCompare(binaryExpression, "!=", OpCodes.Ceq, true);
                    break;
                case ExpressionKind.ShiftLeft:
                    EmitShift(binaryExpression, "<<", OpCodes.Shl);
                    break;
                case ExpressionKind.ShiftRight:
                    EmitShift(binaryExpression, ">>", OpCodes.Shr);
                    break;
                case ExpressionKind.Subtraction:
                    EmitBinary(binaryExpression, "-", OpCodes.Sub, TypeCode.Double, false, false);
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
            var label = IL.DefineLabel();

            VisitExpression(unaryExpression.Operand);
            IL.Emit(OpCodes.Dup);
            IL.Emit(OpCodes.Call, typeof(Value).GetProperty("IsReal").GetGetMethod());
            IL.Emit(OpCodes.Brtrue, label);
            IL.Emit(OpCodes.Pop);
            IL.Emit(OpCodes.Ldc_I4, (int)Error.WrongUnaryTypes);
            IL.Emit(OpCodes.Newobj, error_t.GetConstructor(new[] { typeof(Error) }));
            IL.Emit(OpCodes.Throw);
            IL.MarkLabel(label);

            if (unaryExpression.Kind == ExpressionKind.Plus)
                return;

            IL.Emit(OpCodes.Call, value_t.GetProperty("Real").GetGetMethod());
            switch (unaryExpression.Kind)
            {
                case ExpressionKind.Not:
                    IL.Emit(OpCodes.Ldc_R8, 0.0);
                    IL.Emit(OpCodes.Cgt);
                    IL.Emit(OpCodes.Not);
                    IL.Emit(OpCodes.Conv_R8);
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));
                    break;
                case ExpressionKind.Minus:
                    IL.Emit(OpCodes.Neg);
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));
                    break;
                case ExpressionKind.Complement:
                    IL.Emit(OpCodes.Conv_I8);
                    IL.Emit(OpCodes.Not);
                    IL.Emit(OpCodes.Conv_R8);
                    IL.Emit(OpCodes.Call, value_t.GetMethod("op_Implicit", new[] { typeof(double) }));
                    break;
            }

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
        #endregion

        #region Statements
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
        #endregion
    }
}
