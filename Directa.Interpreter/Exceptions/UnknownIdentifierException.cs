using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Interpreter.Exceptions
{
    public class UnknownIdentifierException : Exception
    {
        public UnknownIdentifierException(string identifier) : 
            base(String.Format("Identifier '{0}' does not exist in this frame's symbol table", identifier))
        { }
    }
}
