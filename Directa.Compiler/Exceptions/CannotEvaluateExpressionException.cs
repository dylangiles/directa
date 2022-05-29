using System;
namespace Directa.Compiler.Exceptions
{
    public class CannotEvaluateExpressionException : CompilerException
    {
        public CannotEvaluateExpressionException(Token token) :
            base(token.Line, token.Column, String.Format("Failed to evaluate expression '{0}'", token.Value))
        {
        }
    }
}
