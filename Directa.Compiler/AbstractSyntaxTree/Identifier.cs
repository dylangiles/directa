using System;
namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Identifier
    {
        public string Name { get; private set; }
        public Identifier(string name)
        {
            Name = name;
        }
    }
}
