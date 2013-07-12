using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public enum ExpressionKind
    {
        None = 0,
        Access,
        Addition,
        BitwiseAnd,
        BitwiseOr,
        BitwiseXor,
        Call,
        Complement,
        Constant,
        Div,
        Divide,
        Equality,
        GreaterThan,
        GreaterThanOrEqual,
        Grouping,
        Id,
        LessThan,
        LessThanOrEqual,
        LogicalAnd,
        LogicalOr,
        LogicalXor,
        Minus,
        Mod,
        Multiply,
        Not,
        NotEqual,
        Plus,
        ShiftLeft,
        ShiftRight,
        Subtraction,
    }
}
