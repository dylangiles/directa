using System.Net.Mime;
using Antlr4.Runtime;
using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.Errors;
using Directa.Compiler.Exceptions;

namespace Directa.Compiler.Parser;

public class ArithmeticExpressionVisitor : DirectaBaseVisitor<ArithmeticExpression>
{
    private ParserProgram _program;
    private ParserTypeDefinition _targetType;

    public ArithmeticExpressionVisitor(ParserTypeDefinition targetType, ParserProgram program)
    {
        _program = program;
        _targetType = targetType;
    }
    public override ArithmeticExpression VisitAdditiveExpression(DirectaParser.AdditiveExpressionContext context)
    {
        OperatorVisitor operatorVisitor = new OperatorVisitor();
        Operator op = operatorVisitor.VisitAddOp(context.addOp());

        ExpressionVisitor expressionVisitor = new ExpressionVisitor(_program, _targetType);
        Expression? leftExpression = expressionVisitor.Visit(context.expression()[0]);
        Expression? rightExpression = expressionVisitor.Visit(context.expression()[1]);

        
        
        if (leftExpression is null)
        {
            throw new ParserException($"Could not parse left side of expression: {context.GetText()}");
        }

        if (rightExpression is null)
        {
            throw new ParserException($"Could not parse right side of expression: {context.GetText()}");
        }
        
        if(!CompileTimeTypeChecker.IsAdditionLegal(leftExpression.TypeDefinition, rightExpression.TypeDefinition))
            _program.AddError(ErrorCodes.ERROR_TYPE_CONFLICT, 
                $"Type conflict error: Operation {context.addOp().GetText()} cannot be applied to types " +
                $"'{leftExpression.TypeDefinition.TypeName}' and '{rightExpression.TypeDefinition.TypeName}'");

        if(!CompileTimeTypeChecker.IsAssignmentLegal(_targetType, leftExpression.TypeDefinition))
            _program.AddError(ErrorCodes.ERROR_TYPE_CONFLICT, 
                $"Type conflict error: Operation {context.addOp().GetText()} cannot be applied to types " +
                $"'{_targetType.TypeName}' and '{leftExpression.TypeDefinition.TypeName}'");
        
        if(!CompileTimeTypeChecker.IsAssignmentLegal(_targetType, rightExpression.TypeDefinition))
            _program.AddError(ErrorCodes.ERROR_TYPE_CONFLICT, 
                $"Type conflict error: Operation {context.addOp().GetText()} cannot be applied to types " +
                $"'{_targetType.TypeName}' and '{rightExpression.TypeDefinition.TypeName}'");
        
        
        return new ArithmeticExpression(_targetType, leftExpression, rightExpression, op);
    }

    public override ArithmeticExpression VisitAddOp(DirectaParser.AddOpContext context)
    {
        return base.VisitAddOp(context);
    }
}