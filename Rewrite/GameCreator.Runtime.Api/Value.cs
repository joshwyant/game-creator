using System;
using System.Globalization;

namespace GameCreator.Runtime.Api
{
    public struct Value
    {
        private readonly string _string;
        private readonly double _real;
        
        #region Constructors

        public Value(string val)
        {
            ValueType = ValueType.String;
            _string = val;
            _real = 0.0;
        }

        public Value(double val)
        {
            ValueType = ValueType.Real;
            _real = val;
            _string = null;
        }

        public Value(int val)
            : this((double) val)
        {
        }

        public Value(bool val)
            : this(val ? 1.0 : 0.0)
        {
        }

        public Value(Value other)
        {
            ValueType = other.ValueType;
            _real = other._real;
            _string = other._string;
        }

        public Value(object obj)
        {
            switch (obj)
            {
                case string str:
                    ValueType = ValueType.String;
                    _string = str;
                    _real = 0.0;
                    break;
                case Value val:
                    ValueType = val.ValueType;
                    _real = val._real;
                    _string = val._string;
                    break;
                case null:
                    ValueType = ValueType.Undefined;
                    _real = 0.0;
                    _string = null;
                    break;
                default:
                    ValueType = ValueType.Real;
                    _string = null;
                    switch (obj)
                    {
                        case IIndexedResource res:
                            _real = res.Id;
                            break;
                        case int i:
                            _real = i;
                            break;
                        case double d:
                            _real = d;
                            break;
                        case bool b:
                            _real = b ? 1.0 : 0.0;
                            break;
                        default:
                            try
                            {
                                _real = Convert.ToDouble(obj);
                            }
                            catch
                            {
                                _real = 0.0;
                                ValueType = ValueType.Undefined;
                            }
                            break;
                    }
                    break;
            }
        }
        #endregion

        public override string ToString()
        {
            return ValueType == ValueType.String
                ? _string
                : double.IsInfinity(_real)
                    ? "INF"
                    : double.IsNaN(_real)
                        ? "NAN"
                        : _real.ToString(CultureInfo.InvariantCulture);
        }

        #region Properties
        public string String => ValueType == ValueType.String ? _string : string.Empty;

        public double Real => ValueType == ValueType.Real ? _real : 0.0;

        public int Int => Convert.ToInt32(Real);

        public bool Bool => ValueType == ValueType.Real && _real >= 0.5;

        public bool IsReal => ValueType == ValueType.Real;
        public bool IsString => ValueType == ValueType.String;
        public bool IsNull => ValueType == ValueType.Undefined;
        public ValueType ValueType { get; }

        #endregion
        
        #region Static Properties
        public static Value Zero = new Value(0.0);
        public static Value One = new Value(1.0);
        public static Value EmptyString = new Value(string.Empty);
        public static Value Null = default(Value);
        #endregion
        
        #region Equality
        public static Value operator ==(Value a, Value b)
        {
            return a.ValueType == b.ValueType
                   && (a.ValueType == ValueType.Real && a._real == b._real
                       || a.ValueType == ValueType.String && a._string == b._string);
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
            return v.Bool;
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
            if (obj is Value v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ValueType == ValueType.Real
                ? _real.GetHashCode()
                : ValueType == ValueType.String
                    ? _string?.GetHashCode() ?? 0
                    : 0;
        }

        #endregion
    }
}