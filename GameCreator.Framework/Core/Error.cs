using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public enum Error
    {
        Case,
        RepeatExpression,
        ExpectedBooleanExpression,
        GlobalWith,
        ExpectedObjectId,
        ExpectedExpression,
        Default,
        CannotAssign,
        WrongArgumentTypes,
        CannotCompare,
        UnexpectedSymbol,
        SymbolExpected,
        ProgramEnds,
        ExpectedVariableName,
        ArraySymbol,
        ArrayDegree,
        UnknownFunction,
        WrongArgumentNumber,
        UnexpectedSymbolInExpression,
        ExpectedAssignmentOperator,
        ExpectedUntil,
        BuiltinVariable,
        WrongUnaryTypes,
        UnknownVariable,
        UnknownArray,
        WrongVariableIndexType,
        ArrayBounds,
        WrongArrayIndexType,
        NegativeArrayIndex,
        RuntimeReal
    }
}
