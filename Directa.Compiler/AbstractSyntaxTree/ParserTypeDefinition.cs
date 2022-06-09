using System;
using System.Dynamic;

namespace Directa.Compiler.AbstractSyntaxTree;

[Flags]
public enum TypeFlag
{
    IsNumeric = 0b1,
}
public class ParserTypeDefinition
{
    public string TypeName { get; private set; }
    public int ByteSize { get; private set; }
    public byte Priority { get; private set; }
    public TypeFlag Flags { get; private set; }

    public ParserTypeDefinition(string typeName, int byteSize, byte priority, TypeFlag flags)
    {
        TypeName = typeName;
        ByteSize = byteSize;
        Priority = priority;
        Flags = flags;
    }
}