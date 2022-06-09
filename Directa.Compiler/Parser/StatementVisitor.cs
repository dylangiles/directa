using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Compiler.Parser;

public class StatementVisitor : DirectaBaseVisitor<Statement>
{
    private ParserProgram _program;

    public StatementVisitor(ParserProgram program)
    {
        _program = program;
    }
    public override Statement VisitStatement(DirectaParser.StatementContext context)
    {
        DirectaParser.DeclarationContext declarationContext = context.declaration();
        DirectaParser.ReturnStatementContext returnStatementContext = context.returnStatement();
        
        if (declarationContext != null)
        {
            DeclarationVisitor declarationVisitor = new DeclarationVisitor(_program);
            Declaration? declaration = declarationVisitor.VisitDeclaration(context.declaration());

            if (declaration is null)
                return base.VisitStatement(context);
                
            if(_program.CurrentBlock is not null)
                _program.CurrentBlock.Symbols.Add(declaration.Identifier, declaration.TypeDefinition.TypeName);

            return declaration;
        }
        
        else if (returnStatementContext != null)
        {
            // Expression? expression = Visit(context.returnStatement().expression());
            ReturnStatementVisitor returnStatementVisitor = new ReturnStatementVisitor(_program);
            return returnStatementVisitor.VisitReturnStatement(context.returnStatement());
        }
        
        return base.VisitStatement(context);
    }
}