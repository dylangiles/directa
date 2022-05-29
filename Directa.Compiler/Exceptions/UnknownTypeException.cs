using System;
namespace Directa.Compiler.Exceptions
{
    public class UnknownTypeException : CompilerException
    {
        public UnknownTypeException(Token token) :
            base(token.Line, token.Column, String.Format("Unknown type '{0}'", token.Value))
        {
        }
    }
}
