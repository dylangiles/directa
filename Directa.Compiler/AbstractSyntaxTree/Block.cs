using System.Collections.Generic;

namespace Directa.Compiler.AbstractSyntaxTree;

public class Block
{
    public List<Statement> Statements { get; private set; }
    
    public Dictionary<string, string> Symbols { get; private set; }

    public Block()
    {
        Statements = new List<Statement>();
        Symbols = new Dictionary<string, string>();
    }
}