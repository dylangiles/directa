using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.AbstractSyntaxTree.Constants;
using Directa.Compiler.Errors;
using Directa.Compiler.Exceptions;

namespace Directa.Compiler.Parser;

public class ExpressionVisitor : DirectaBaseVisitor<Expression?>
{
    private ParserProgram _program;
    private ParserTypeDefinition _targetType;
    public ExpressionVisitor(ParserProgram program, ParserTypeDefinition targetType)
    {
        _program = program;
        _targetType = targetType;
    }
    public override ArithmeticExpression? VisitAdditiveExpression(DirectaParser.AdditiveExpressionContext context)
    {
        ArithmeticExpressionVisitor arithmeticExpressionVisitor = new ArithmeticExpressionVisitor(_targetType, 
            _program);
        return arithmeticExpressionVisitor.VisitAdditiveExpression(context);
    }
    
    public override Variable? VisitIdentifierExpression(DirectaParser.IdentifierExpressionContext context)
    {
        string identifierName = context.GetText();
        string? typeName = null;
        if (_program.CurrentBlock is null)
        {
            _program.AddError(new CompilerError(new UnknownBlockException(context.IDENTIFIER())));
            return null;
        }

        if (!_program.CurrentBlock.Symbols.TryGetValue(identifierName, out typeName))
        {
            _program.AddError(new CompilerError(new UnknownIdentifierException(context.IDENTIFIER())));
            return null;
        }

        ParserTypeDefinition? typeDefinition = null;
        if (!_program.BuiltinTypeDefs.TryGetValue(typeName, out typeDefinition))
        {
            _program.AddError(ErrorCodes.ERROR_UNKNOWN_IDENTIFIER, 
                $"Unknown type '{typeName}");
            return null;
        }

        return new Variable(context.IDENTIFIER().GetText(), typeDefinition);
    }

    public override Constant VisitConstant(DirectaParser.ConstantContext context)
    {
        ConstantVisitor constantVisitor = new ConstantVisitor();
        return constantVisitor.VisitConstant(context);
    }
}