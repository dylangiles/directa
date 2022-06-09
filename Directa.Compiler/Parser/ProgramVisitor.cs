using Antlr4.Runtime;
using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Compiler.Parser;

public class ProgramVisitor : DirectaBaseVisitor<ParserProgram>
{
    public override ParserProgram VisitProgram(DirectaParser.ProgramContext context)
    {
        ParserProgram program = new ParserProgram();

        program.AddBlock(new Block());

        if (program.CurrentBlock is not null)
        {
            foreach (DirectaParser.LineContext lineContext in context.line())
            {
                DirectaParser.StatementContext statementContext = lineContext.statement();
                if (statementContext != null)
                {
                    StatementVisitor statementVisitor = new StatementVisitor(program);
                    program.CurrentBlock.Statements.Add(statementVisitor.VisitStatement(lineContext.statement()));
                }
            }
        }
        
        return program;
    }
}