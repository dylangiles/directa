using System;
using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Compiler.Parser;

public class OperatorVisitor : DirectaBaseVisitor<Operator>
{
    public override Operator VisitAddOp(DirectaParser.AddOpContext context)
    {
        string operatorString = context.GetText();
        switch (operatorString)
        {
            case Operator.ADDITIVE_OPERATOR:
                return new Operator(OperatorType.Addition);
            case Operator.SUBTRACTIVE_OPERATOR:
                return new Operator(OperatorType.Subtraction);
        }

        throw new NotImplementedException("Unimplemented operator");
    }
}