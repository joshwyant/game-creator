using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    // Is a STRUCT since values are passed by value.
    // Represents GM's dynamic data typing.
    public struct Value
    {
        int type; // 0 = undefined, 1 = real, 2 = string
        string s;
        double d;
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
        // The value returned by string(). string -> String, other -> Real.ToString()
        public override string ToString()
        {
            return type == 2 ? s : double.IsInfinity(d) ? "INF" : double.IsNaN(d) ? "NAN" : d.ToString(); // Make d.ToString() in GM format
        }
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
        public static Value Zero = new Value(0.0);
        public static Value One = new Value(1.0);
        public static Value EmptyString = new Value(String.Empty);
        public static Value Null = default(Value);
        // Operators
        public Value AddReal(Value b)
        {
            return Real + b.Real;
        }
        public Value AddString(Value b)
        {
            return String + b.String;
        }
        public static Value operator +(Value a, Value b)
        {
            return a.IsReal ? (Value)(a.Real + b.Real) : (Value)(a.String + b.String);
        }
        public static Value operator -(Value a, Value b)
        {
            return a.IsReal ? (Value)(a.Real - b.Real) : Zero;
        }
        public static Value operator *(Value a, Value b)
        {
            return a.IsReal ? (Value)(a.Real * b.Real) : Zero;
        }
        public static Value operator /(Value a, Value b)
        {
            return a.IsReal ? (Value)(a.Real / b.Real) : Zero;
        }
        // Conversions
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
    }
}
