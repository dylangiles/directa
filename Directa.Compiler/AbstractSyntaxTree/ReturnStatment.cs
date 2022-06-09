namespace Directa.Compiler.AbstractSyntaxTree;

public class ReturnStatment : Statement
{
    public Expression? ReturnExpression { get; private set; }

    public ReturnStatment(Expression? returnExpression)
    {
        ReturnExpression = returnExpression;
    }
}