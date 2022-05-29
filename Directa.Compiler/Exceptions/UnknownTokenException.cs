using System;
namespace Directa.Compiler.Exceptions
{
    public class UnknownTokenException : CompilerException
    {
        public UnknownTokenException(int line, int column, string tokenString) :
            base(line, column, "Unknown token todo")
        {
        }
    }
}
