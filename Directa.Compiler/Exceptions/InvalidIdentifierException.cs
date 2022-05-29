using System;
namespace Directa.Compiler.Exceptions
{
    public class InvalidIdentifierException : CompilerException
    {
        public InvalidIdentifierException(int line, int column) : base(line, column, "Invalid identifier")
        {
        }
    }
}
