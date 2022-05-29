using System;
namespace Directa.Compiler.Exceptions
{
    public class UnknownIdentifierExpression : CompilerException
    {
        public UnknownIdentifierExpression(Token token) :
            base(token.Line, token.Column, String.Format("Unknown identifier '{0}'", token.Value))
        {
        }
    }
}
