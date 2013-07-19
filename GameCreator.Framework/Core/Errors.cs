using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public static class Errors
    {
        internal static Dictionary<Error, ErrorDefinition> ErrorDefinitions { get; private set; }

        static Errors()
        {
            ErrorDefinitions = new Dictionary<Error, ErrorDefinition>();

            #region Errors
            Define(Error.Case, ErrorSeverity.Error, 
                "Case statement only allowed inside switch statement.");

            Define(Error.RepeatExpression, ErrorSeverity.Error, 
                "Repeat count must be a number");

            Define(Error.ExpectedBooleanExpression, ErrorSeverity.Error, 
                "Boolean expression expected");

            Define(Error.GlobalWith, ErrorSeverity.Error, 
                "Cannot use global in a with statement.");

            Define(Error.ExpectedObjectId, ErrorSeverity.Error, 
                "Object id expected");

            Define(Error.ExpectedExpression, ErrorSeverity.Error, 
                "Expression expected");

            Define(Error.Default, ErrorSeverity.Error, 
                "Default statement only allowed inside switch statement.");

            Define(Error.CannotAssign, ErrorSeverity.Error, 
                "Cannot assign to the variable");

            Define(Error.WrongArgumentTypes, ErrorSeverity.Error, 
                "Wrong type of arguments for {0}.");

            Define(Error.CannotCompare, ErrorSeverity.Error, 
                "Cannot compare arguments.");

            Define(Error.WrongUnaryTypes, ErrorSeverity.Error,
                "Wrong type of arguments unary operator.");

            Define(Error.UnknownVariable, ErrorSeverity.Error,
                "Unknown variable {0}");

            Define(Error.UnknownArray, ErrorSeverity.Error,
                "Unknown variable {0} or array index out of bounds");

            Define(Error.WrongVariableIndexType, ErrorSeverity.Error,
                "Wrong type of variable index");

            Define(Error.ArrayBounds, ErrorSeverity.Error,
                "Array index >= 32000");

            Define(Error.WrongArrayIndexType, ErrorSeverity.Error,
                "Wrong type of array index");

            Define(Error.NegativeArrayIndex, ErrorSeverity.Error,
                "Negative array index");
            #endregion

            #region Compilation Errors
            Define(Error.UnexpectedSymbol, ErrorSeverity.CompilationError,
                "Unexpected symbol.");

            Define(Error.SymbolExpected, ErrorSeverity.CompilationError,
                "Symbol {0} expected.");

            Define(Error.ProgramEnds, ErrorSeverity.CompilationError,
                "Program ends before end of the code.");

            Define(Error.ExpectedVariableName, ErrorSeverity.CompilationError,
                "Variable name expected.");

            Define(Error.ArraySymbol, ErrorSeverity.CompilationError,
                "Symbol , or ] expected.");

            Define(Error.ArrayDegree, ErrorSeverity.CompilationError,
                "Only 1- and 2-dimensional arrays are supported.");

            Define(Error.UnknownFunction, ErrorSeverity.CompilationError,
                "Unknown function or script: {0}");

            Define(Error.WrongArgumentNumber, ErrorSeverity.CompilationError,
                "Wrong number of arguments to function or script.");

            Define(Error.UnexpectedSymbolInExpression, ErrorSeverity.CompilationError,
                "Unexpected symbol in expression.");

            Define(Error.ExpectedAssignmentOperator, ErrorSeverity.CompilationError,
                "Assignment operator expected.");

            Define(Error.ExpectedUntil, ErrorSeverity.CompilationError,
                "Keyword until expected.");

            Define(Error.BuiltinVariable, ErrorSeverity.CompilationError,
                "Cannot redeclare a builtin variable.");
            #endregion

            #region Runtime Errors
            Define(Error.RuntimeReal, ErrorSeverity.Error,
                "Error in function real().");


            #endregion
        }

        public static void Throw(Error error)
        {
            var err = ErrorDefinitions[error];

            throw new ProgramError(err.Message, err.Severity);
        }

        public static void Throw(Error error, int line, int col)
        {
            var err = ErrorDefinitions[error];

            throw new ProgramError(err.Message, err.Severity, line, col);
        }

        public static void Throw(Error error, object obj, int line, int col)
        {
            var err = ErrorDefinitions[error];

            throw new ProgramError(string.Format(err.Message, obj), err.Severity, line, col);
        }

        public static void Define(Error error, ErrorSeverity severity, string message)
        {
            ErrorDefinitions[error] = new ErrorDefinition() { Type = error, Severity = severity, Message = message };
        }
    }
}
