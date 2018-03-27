using System;
using System.Globalization;
using GameCreator.Resources.Api;

namespace GameCreator.Runtime.Api
{
    public struct Variant
    {
        private readonly string _string;
        private readonly double _real;
        
        #region Constructors

        public Variant(string val)
        {
            ValueType = ValueType.String;
            _string = val;
            _real = 0.0;
        }

        public Variant(double val)
        {
            ValueType = ValueType.Real;
            _real = val;
            _string = null;
        }

        public Variant(int val)
            : this((double) val)
        {
        }

        public Variant(bool val)
            : this(val ? 1.0 : 0.0)
        {
        }

        public Variant(Variant other)
        {
            ValueType = other.ValueType;
            _real = other._real;
            _string = other._string;
        }

        public Variant(object obj)
        {
            switch (obj)
            {
                case string str:
                    ValueType = ValueType.String;
                    _string = str;
                    _real = 0.0;
                    break;
                case Variant val:
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
        public static Variant Zero = new Variant(0.0);
        public static Variant One = new Variant(1.0);
        public static Variant EmptyString = new Variant(string.Empty);
        public static Variant Null = default(Variant);
        #endregion
        
        #region Equality
        public static Variant operator ==(Variant a, Variant b)
        {
            return a.ValueType == b.ValueType
                   && (a.ValueType == ValueType.Real && a._real == b._real
                       || a.ValueType == ValueType.String && a._string == b._string);
        }

        public static Variant operator !=(Variant a, Variant b)
        {
            return !(a == b);
        }
        #endregion
        
        #region Implicit Conversions
        public static implicit operator int(Variant v)
        {
            return v.Int;
        }
        public static implicit operator double(Variant v)
        {
            return v.Real;
        }
        public static implicit operator bool(Variant v)
        {
            return v.Bool;
        }
        public static implicit operator string(Variant v)
        {
            return v.String;
        }
        public static implicit operator Variant(double d)
        {
            return new Variant(d);
        }
        public static implicit operator Variant(string s)
        {
            return new Variant(s);
        }
        public static implicit operator Variant(bool b)
        {
            return new Variant(b);
        }
        public static implicit operator Variant(int i)
        {
            return new Variant(i);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (obj is Variant v)
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