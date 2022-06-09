using System;
using Antlr4.Runtime.Tree;

namespace Directa.Compiler.Exceptions;

public class ParserException : Exception
{
    
    public virtual string ErrorCode
    {
        get => Errors.ErrorCodes.ERROR_UNKNOWN_ERROR;
    }
    public ParserException(ITerminalNode node, string message) : 
        base($"{message} at line {node.Symbol.Line}, position {node.Symbol.Column}") {}
    
    public ParserException(string message) : base($"Parsing error: {message}") {}
}