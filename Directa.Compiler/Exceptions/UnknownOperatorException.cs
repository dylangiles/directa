using System;
namespace Directa.Compiler.Exceptions
{
    public class UnknownOperatorException : CompilerException
    {
        public UnknownOperatorException(Token token) :
            base(token.Line, token.Column, String.Format("Unknown operator '{0}'", token.Value))
        {
        }
    }
}
