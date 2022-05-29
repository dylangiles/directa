using System;
namespace Directa.Compiler.Exceptions
{
    public class MissingTypeException : CompilerException
    {
        public MissingTypeException(int line, int column) : base(line, column, "Missing type on identifier")
        {
        }
    }
}
