using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework
{
    // Is a STRUCT since values are passed by value.
    // Represents GM's dynamic data typing.
    public struct Value
    {
        #region Fields
        int type; // 0 = undefined, 1 = real, 2 = string
        string s;
        double d;
        #endregion

        #region Constructors
        public Value(string val)
        {
            type = 2;
            s = val;
            d = 0;
        }
        public Value(double val)
        {
            type = 1;
            d = val;
            s = null;
        }
        public Value(int val)
        {
            type = 1;
            d = (double)val;
            s = null;
        }
        public Value(bool val)
        {
            type = 1;
            d = val ? 1.0 : 0.0;
            s = null;
        }
        public Value(object obj)
        {
            if (obj is string)
            {
                type = 2;
                s = (string)obj;
                d = 0;
            }
            else if (obj == null)
            {
                type = 0;
                d = 0;
                s = null;
            }
            else
            {
                type = 1;
                s = null;
                if (obj is int)
                    d = (double)(int)obj;
                else if (obj is double)
                    d = (double)obj;
                else if (obj is bool)
                    d = (bool)obj ? 1.0 : 0.0;
                else
                {
                    type = 0;
                    d = 0.0;
                }
            }
        }
        #endregion

        #region ToString
        // The value returned by string(). string -> String, other -> Real.ToString()
        public override string ToString()
        {
            return type == 2 ? s : double.IsInfinity(d) ? "INF" : double.IsNaN(d) ? "NAN" : d.ToString(); // Make d.ToString() in GM format
        }
        #endregion

        #region Properties
        // The string value for a function expecting a string: string = val, other -> ""
        public string String
        {
            get
            {
                return type == 2 ? s : String.Empty;
            }
            set
            {
                type = 2;
                s = value;
            }
        }

        // The real value for a function expecting a real: real -> value, other = 0
        public double Real
        {
            get
            {
                return type == 1 ? d : 0.0d;
            }
            set
            {
                type = 1;
                d = value;
                s = null; // Get rid of reference so GC can collect
            }
        }

        public int Int
        {
            get
            {
                return Convert.ToInt32(Real); // Round to nearest integer, rounding to even number midway
            }
            set
            {
                type = 1;
                d = (double)value;
                s = null;
            }
        }

        public bool Bool
        {
            get
            {
                return type == 1 && d >= 0.5;
            }
            set
            {
                type = 1;
                d = value ? 1.0 : 0.0;
                s = null;
            }
        }

        // is_real(val)
        public bool IsReal
        {
            get
            {
                return type == 1;
            }
        }

        // is_string(val)
        public bool IsString
        {
            get
            {
                return type == 2;
            }
        }

        public bool IsNull
        {
            get
            {
                return type == 0;
            }
        }
        #endregion

        #region Static Properties
        public static Value Zero = new Value(0.0);
        public static Value One = new Value(1.0);
        public static Value EmptyString = new Value(String.Empty);
        public static Value Null = default(Value);
        #endregion

        #region Operator Helpers
        static Value BinaryReal(Value v1, Value v2, string op, Func<double, double, double> func)
        {
            if (v1.IsReal && v2.IsReal)
                return func(v1, v2);
            else
                throw new ProgramError(Error.WrongArgumentTypesLogical, op);
        }

        static Value Logical(Value v1, Value v2, string op, Func<bool, bool, bool> tester)
        {
            if (!(v1.IsReal && v2.IsReal))
                throw new ProgramError(Error.WrongArgumentTypesLogical, op);

            return tester(v1.Bool, v2.Bool);
        }

        static Value Bitwise(Value v1, Value v2, string op, Func<long, long, long> twiddler)
        {
            return BinaryReal(v1, v2, op, (a, b) => (double)twiddler(Convert.ToInt64(a), Convert.ToInt64(b)));
        }

        static Value Compare(Value v1, Value v2, Func<double, double, bool> realComparer, Func<int, bool> stringOrdinalComparer)
        {
            if (v1.IsReal && v2.IsReal)
                return realComparer(v1.Real, v2.Real);
            else if (v1.IsString && v2.IsString)
                return stringOrdinalComparer(string.CompareOrdinal(v1.String, v2.String));
            else
                throw new ProgramError(Error.CannotCompare);
        }

        static Value Arithmetic(Value v1, Value v2, string op, Func<double, double, double> realOperator)
        {
            if (v1.IsReal && v2.IsReal)
                return realOperator(v1, v2);
            else
                throw new ProgramError(Error.WrongArgumentTypes, op);
        }

        static Value Arithmetic(Value v1, Value v2, string op, Func<double, double, double> realOperator, bool v1String, bool v2String, Func<Value, Value, Value> stringOperator)
        {
            if (v1.IsReal && v2.IsReal)
                return realOperator(v1, v2);
            else if (v1.IsString == v1String && v2.IsString == v2String)
                return stringOperator(v1, v2);
            else
                throw new ProgramError(Error.WrongArgumentTypes, op);
        }

        static Value Unary(Value v, Func<double, double> op)
        {
            if (!v.IsReal)
                throw new ProgramError(Error.WrongUnaryTypes);

            return op(v);
        }
        #endregion

        #region Operators
        public static Value operator +(Value a, Value b)
        { return Arithmetic(a, b, "+", (v1, v2) => v1 + v2, true, true, (s1, s2) => s1.String + s2.String); }

        public static Value operator -(Value a, Value b)
        { return Arithmetic(a, b, "-", (v1, v2) => v1 - v2); }

        public static Value operator *(Value a, Value b)
        {
            return Arithmetic(a, b, "*",
                (v1, v2) => v1 * v2,
                false, true, (v1, v2) =>
                {
                    var sb = new StringBuilder();
                    for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                        sb.Append(v2.String);
                    return sb.ToString();
                });
        }

        public static Value operator %(Value a, Value b)
        { return Arithmetic(a, b, "mod", (v1, v2) => (double)((long)v1 % (long)v2)); }

        public static Value operator /(Value a, Value b)
        { return Arithmetic(a, b, "/", (v1, v2) => v1 / v2); }

        public static Value IntegerDivision(Value a, Value b)
        { return Arithmetic(a, b, "div", (v1, v2) => (double)((long)v1 / (long)v2)); }

        public static Value operator &(Value a, Value b)
        { return Bitwise(a, b, "&", (v1, v2) => v1 & v2); }

        public static Value operator |(Value a, Value b)
        { return Bitwise(a, b, "|", (v1, v2) => v1 | v2); }

        public static Value operator ^(Value a, Value b)
        { return Bitwise(a, b, "^", (v1, v2) => v1 ^ v2); }

        public static Value operator <<(Value a, int b)
        {
            return ShiftLeft(a, (Value)b);
        }

        public static Value operator >>(Value a, int b)
        {
            return ShiftRight(a, (Value)b);
        }

        public static Value ShiftLeft(Value a, Value b)
        { return Bitwise(a, b, "<<", (v1, v2) => v1 << (int)v2); }

        public static Value ShiftRight(Value a, Value b)
        { return Bitwise(a, b, ">>", (v1, v2) => v1 >> (int)v2); }

        public static Value operator ~(Value val)
        { return Unary(val, v => (double)~Convert.ToInt64(v)); }

        public static Value operator +(Value val)
        { return Unary(val, v => v); }

        public static Value operator -(Value val)
        { return Unary(val, v => -v); }

        public static Value operator !(Value val)
        { return Unary(val, v => ((Value)v).Bool ? 1 : 0); }

        public static Value operator >(Value a, Value b)
        { return Compare(a, b, (v1, v2) => v1 > v2, s => s > 0); }

        public static Value operator >=(Value a, Value b)
        { return Compare(a, b, (v1, v2) => v1 >= v2, s => s >= 0); }

        public static Value operator <(Value a, Value b)
        { return Compare(a, b, (v1, v2) => v1 < v2, s => s < 0); }

        public static Value operator <=(Value a, Value b)
        { return Compare(a, b, (v1, v2) => v1 <= v2, s => s <= 0); }

        public static Value LogicalAnd(Value a, Value b)
        { return Logical(a, b, "&&", (v1, v2) => v1 && v2); }

        public static Value LogicalOr(Value a, Value b)
        { return Logical(a, b, "||", (v1, v2) => v1 || v2); }

        public static Value LogicalXor(Value a, Value b)
        { return Logical(a, b, "^^", (v1, v2) => v1 ^ v2); }

        public static bool operator true(Value v)
        {
            return v.Bool;
        }

        public static bool operator false(Value v)
        {
            return !v.Bool;
        }
        #endregion

        #region Equality
        public static Value operator ==(Value a, Value b)
        {
            return a.type == b.type &&
                    ((a.type == 1 && a.d == b.d) ||
                    (a.type == 2 && a.s == b.s) ||
                    (a.type <= 0 || a.type >= 3)
                    );
        }

        public static Value operator !=(Value a, Value b)
        {
            return !(a == b);
        }
        #endregion

        #region Implicit Conversions
        public static implicit operator int(Value v)
        {
            return v.Int;
        }
        public static implicit operator double(Value v)
        {
            return v.Real;
        }
        public static implicit operator bool(Value v)
        {
            return v.Bool; // isreal && real >= 0.5
        }
        public static implicit operator string(Value v)
        {
            return v.String;
        }
        public static implicit operator Value(double d)
        {
            return new Value(d);
        }
        public static implicit operator Value(string s)
        {
            return new Value(s);
        }
        public static implicit operator Value(bool b)
        {
            return new Value(b);
        }
        public static implicit operator Value(int i)
        {
            return new Value(i);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (obj is Value)
            {
                var val = (Value)obj;
                return this == val;
            }
            return false;
        }
        #endregion
    }
}
