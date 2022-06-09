using Antlr4.Runtime.Tree;

namespace Directa.Compiler.Exceptions;

public class UnknownIdentifierException : ParserException
{
    public override string ErrorCode { get => Errors.ErrorCodes.ERROR_UNKNOWN_IDENTIFIER; }

    public UnknownIdentifierException(ITerminalNode node) :
        base(node, $"Unknown identifier '{node.GetText()}'") {}
}