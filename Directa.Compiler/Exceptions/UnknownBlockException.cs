using Antlr4.Runtime.Tree;

namespace Directa.Compiler.Exceptions;

public class UnknownBlockException : ParserException
{
    public override string ErrorCode { get => Errors.ErrorCodes.ERROR_UNKNOWN_BLOCK; }

    public UnknownBlockException(ITerminalNode node) : base(node, $"Cannot infer current block")
    {
    }
}