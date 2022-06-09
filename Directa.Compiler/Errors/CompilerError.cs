using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.Exceptions;

namespace Directa.Compiler.Errors;

public class CompilerError
{
    public string ErrorCode { get; private set; }
    public string ErrorMessage { get; private set; }

    public CompilerError(ParserException exception)
    {
        ErrorCode = exception.ErrorCode;
        ErrorMessage = exception.Message;
    }

    public CompilerError(string errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public override string ToString() => $"{ErrorCode}: {ErrorMessage}";
}