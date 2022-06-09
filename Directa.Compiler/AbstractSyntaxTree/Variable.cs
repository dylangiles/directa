
using Directa.Compiler.Parser;

namespace Directa.Compiler.AbstractSyntaxTree;

public class Variable : Expression
{
    public string Name { get; private set; }

    public Variable(string name, ParserTypeDefinition typeDefinition) : base(typeDefinition)
    {
        Name = name;
    }
}