using System.Collections.Generic;

namespace Directa.Runtime;

public class DirectaObject
{
    public string TypeName { get; private set; }
    public Dictionary<string, DirectaObject?> Properties { get; private set; }

    public DirectaObject(string typeName = "Builtins.Object")
    {
        TypeName = typeName;
        Properties = new Dictionary<string, DirectaObject?>();
    }

    protected void AddProperty(string name, DirectaObject? value = null)
    {
        Properties.Add(name, value);
    }
}