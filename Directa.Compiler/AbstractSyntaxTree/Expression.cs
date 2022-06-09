using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Expression : Node
    {
        public ParserTypeDefinition TypeDefinition { get; private set; }

        public Expression(ParserTypeDefinition typeDefinition)
        {
            TypeDefinition = typeDefinition;
        }
    }
}
