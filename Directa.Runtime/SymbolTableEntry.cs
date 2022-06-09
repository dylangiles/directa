using System.ComponentModel.DataAnnotations;

namespace Directa.Runtime;

public class SymbolTableEntry
{
    public string Name { get; private set; }
    public string TypeName { get; private set; }
    public Types.DirectaValueType CurrentValue { get; private set; }

    public SymbolTableEntry(string name, string typeName, Types.DirectaValueType initialValue)
    {
        Name = name;
        TypeName = typeName;
        CurrentValue = initialValue;
    }
}