using System;
using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.AbstractSyntaxTree.Constants;

using Directa.Compiler.Errors;
using Directa.Compiler.Exceptions;

namespace Directa.Compiler.Parser;

public class DeclarationVisitor : DirectaBaseVisitor<Node?>
{
    private readonly ParserProgram _program;

    public DeclarationVisitor(ParserProgram program)
    {
        _program = program;
    }
    
    public override Declaration? VisitDeclaration(DirectaParser.DeclarationContext context)
    {
        string declarationName = context.IDENTIFIER().GetText();

        TypeVisitor typeVisitor = new TypeVisitor(_program);
        ParserTypeDefinition? typeDefinition = typeVisitor.VisitType(context.type());
        if (typeDefinition is null)
        {
            _program.AddError(ErrorCodes.ERROR_UNKNOWN_IDENTIFIER, 
                $"Unknown type '{context.type().GetText()}");
        }
        
        else
        {
            Expression? expression = null;
            ExpressionVisitor expressionVisitor = new ExpressionVisitor(_program, typeDefinition);
            expression = expressionVisitor.Visit(context.expression());
            return new Declaration(declarationName, typeDefinition, expression);
        }
        
        return null;
    }

    // public override Constant VisitConstant(DirectaParser.ConstantContext context)
    // {
    //     ConstantVisitor constantVisitor = new ConstantVisitor();
    //     return constantVisitor.VisitConstant(context);
    // }
    
    // public override Node? VisitAdditiveExpression(DirectaParser.AdditiveExpressionContext context)
    // {
    //     ExpressionVisitor expressionVisitor = new ExpressionVisitor(_program);
    //     return expressionVisitor.VisitAdditiveExpression(context);
    // }
}