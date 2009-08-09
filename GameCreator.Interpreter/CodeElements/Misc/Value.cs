using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    // Is a STRUCT since values are passed by value.
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
        public bool Bool
        {
            get
            {
                return type == 1 && d > 0 ? true : false;
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
    }
}
