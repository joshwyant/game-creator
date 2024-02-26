using System;
using System.Runtime.InteropServices;

namespace GameCreator.Api.Runtime;

/// <summary>
/// A compact variant type that can store either a string or a real.
/// This utilizes unmanaged memory, so it's important to call Free()
/// when you're done with it. Don't use unchecked boxing with new().
/// If you're copying by value, that's fine, but make sure the last
/// copy calls Free() when it's done with the value (and no other
/// copies are in use). Freeing the string in one copy leaves a
/// dangling pointer in the other copies, which can cause bad things
/// like page faults and crashes.
/// Best to encapsulate this in a collection member which always
/// explicitly clears (`Free()`s) every value. Ideally, this would
/// be a collection of instance, local, or global variables,
/// or an array variable.
/// </summary>
public struct CompactVariant
{
    // So we don't have to pin entire string objects
    // into unmanaged memory
    private class StringProxy
    {
        public string Value;
        override public string ToString() => Value;
    }

    // Strings and reals can go in here, we're
    // using some unmanaged tricks
    // By default, the interface is a double
    // value for performance. Only when you need
    // a string are the memory tricks employed.
    private double value;
    private ValueType valueType;

    public CompactVariant(double val)
    {
        valueType = ValueType.Real;
        value = val;
    }

    public CompactVariant(string val)
    {
        valueType = ValueType.String;

        // Pin a pointer to the proxy
        var proxy = new StringProxy { Value = val };
        var handle = GCHandle.Alloc(proxy, GCHandleType.Pinned);
        var ptr = handle.AddrOfPinnedObject();

        // Reinterpret the bits as a double
        value = BitConverter.Int64BitsToDouble(ptr);
    }

    public void Free()
    {
        if (valueType == ValueType.String)
        {
            // Reinterpret the double bits as a pointer
            var ptr = BitConverter.DoubleToInt64Bits(value);
            GCHandle.FromIntPtr((IntPtr)ptr).Free();
        }
        valueType = ValueType.Undefined;
        value = 0.0;
    }

    public readonly bool IsReal => valueType == ValueType.Real;
    public readonly bool IsString => valueType == ValueType.String;
    public readonly string String
    {
        get
        {
            if (valueType != ValueType.String) return string.Empty;

            // Reinterpret the double bits as a pointer
            var ptr = (nint)BitConverter.DoubleToInt64Bits(value);
            return GCHandle.FromIntPtr(ptr).Target.ToString();
        }
    }

    public readonly double Real => valueType == ValueType.Real ? value : 0.0;
}