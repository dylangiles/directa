using System;
namespace Directa.Compiler.Exceptions
{
    public class InvalidExpressionException : CompilerException
    {
        public InvalidExpressionException(Token token) :
            base(token.Line, token.Column, String.Format("Invalid expression '{0}", token.Value))
        {
        }
    }
}
