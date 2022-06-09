using System;
using System.Reflection.PortableExecutable;

namespace Directa.Runtime.Types;

public enum ValueTypeFlag
{
    None,
    SingleByteIsBoolean,
    SingleByteIsByte,
    EightBytesIsLong,
    EightBytesIsFloat,
    EightBytesIsPointer,
}

public static class TypeNames
{
    public const string VALUE_TYPENAME_BOOLEAN = "boolean";
    public const string VALUE_TYPENAME_BYTE = "byte";
    public const string VALUE_TYPENAME_SHORT = "short";
    public const string VALUE_TYPENAME_INTEGER = "integer";
    public const string VALUE_TYPENAME_LONG = "long";
    public const string VALUE_TYPENAME_FLOAT = "float";
    public const string VALUE_TYPENAME_POINTER = "Pointer";
}
public struct DirectaValueType
{
    private readonly ValueTypeFlag _flags;
    private readonly byte[] _bytes;

    public static implicit operator bool(DirectaValueType valueType) => valueType._bytes[0] != 0;
    public static implicit operator byte(DirectaValueType valueType) => valueType._bytes[0];
    public static implicit operator short(DirectaValueType valueType) => BitConverter.ToInt16(valueType._bytes);
    public static implicit operator int(DirectaValueType valueType) => BitConverter.ToInt32(valueType._bytes);
    public static implicit operator long(DirectaValueType valueType) => BitConverter.ToInt64(valueType._bytes);
    public static implicit operator double(DirectaValueType valueType) => BitConverter.ToDouble(valueType._bytes);

    public static implicit operator DirectaValueType(bool value) => new(value ? 1 : 0);
    public static implicit operator DirectaValueType(byte value) => new(value);
    public static implicit operator DirectaValueType(short value) => new(value);
    public static implicit operator DirectaValueType(int value) => new(value);
    public static implicit operator DirectaValueType(long value) => new(value);
    public static implicit operator DirectaValueType(double value) => new(value);


    public DirectaValueType(bool value)
    {
        _flags = ValueTypeFlag.SingleByteIsBoolean;
        _bytes = new[] { value ? (byte)1 : (byte)0 };
    }
    
    public DirectaValueType(byte value)
    {
        _flags = ValueTypeFlag.SingleByteIsByte;
        _bytes = new [] { value };
    }

    public DirectaValueType(short value)
    {
        _flags = 0;
        _bytes = BitConverter.GetBytes(value);  
    }

    public DirectaValueType(int value)
    {
        _flags = 0;
        _bytes = BitConverter.GetBytes(value);  
    }

    public DirectaValueType(long value)
    {
        _flags = 0;
        _bytes = BitConverter.GetBytes(value);  
    }

    public DirectaValueType(double value)
    {
        _flags = ValueTypeFlag.EightBytesIsFloat;
        _bytes = BitConverter.GetBytes(value);   
    }

    public override string ToString()
    {
        switch (_bytes.Length)
        {
            case sizeof(byte):
                if (_flags == ValueTypeFlag.SingleByteIsByte)
                {
                    return $"ValueType<{TypeNames.VALUE_TYPENAME_BYTE}> = {(byte)this}";
                }

                else if (_flags == ValueTypeFlag.SingleByteIsBoolean)
                {
                    return $"ValueType<{TypeNames.VALUE_TYPENAME_BYTE}> = " + (this ? "true" : "false");
                }

                break;
            
            case sizeof(short):
                return $"ValueType<{TypeNames.VALUE_TYPENAME_SHORT}> = {(short)this}";
            
            case sizeof(int):
                return $"ValueType<{TypeNames.VALUE_TYPENAME_INTEGER}> = {(int)this}";
            
            case sizeof(long):
                switch (_flags)
                {
                    case ValueTypeFlag.EightBytesIsLong:
                        return $"ValueType<{TypeNames.VALUE_TYPENAME_INTEGER}> = {(long)this}";
                    case ValueTypeFlag.EightBytesIsFloat:
                        return $"ValueType<{TypeNames.VALUE_TYPENAME_FLOAT}> = {(double)this}";
                    case ValueTypeFlag.EightBytesIsPointer:
                        return $"{TypeNames.VALUE_TYPENAME_POINTER} = {(long)this}";
                }

                break;
            
            default: return "Unknown value type!";
        }
        
        return "Unknown value type!";
    }
}