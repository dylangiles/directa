using System;
namespace Directa.Compiler.Exceptions
{
    public class CompilerException : Exception
    {
        public CompilerException(int line, int column) :
            base(String.Format("Unknown error at line {0}, position {1}", line, column))
        { }

        public CompilerException(int line, int column, string error) :
            base(String.Format("{0} at line {1}, position {2}", error, line, column))
        { }
    }
}
