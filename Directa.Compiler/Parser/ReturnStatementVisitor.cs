using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Compiler.Parser;

public class ReturnStatementVisitor : DirectaBaseVisitor<ReturnStatment>
{
    private ParserProgram _program;
    public ReturnStatementVisitor(ParserProgram program)
    {
        _program = program;
    }
    public override ReturnStatment VisitReturnStatement(DirectaParser.ReturnStatementContext context)
    {
        ExpressionVisitor expressionVisitor = new ExpressionVisitor(_program,
            new ParserTypeDefinition("unknown", 0, 0, 0));
        return new ReturnStatment(expressionVisitor.Visit(context.expression()));
    }
}