using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Declaration : Statement
    {
        public string Identifier { get; private set; }
        public ParserTypeDefinition TypeDefinition { get; private set; }
        public Expression? Assignment{ get; private set; }
        
        public Declaration(string identifier, ParserTypeDefinition typeDefinition, Expression? assignment)
        {
            Identifier = identifier;
            TypeDefinition = typeDefinition;
            Assignment = assignment;
        }
    }
}
