using System;
namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Assignment
    {
        public Expression Expression { get; private set; }

        public Assignment(Expression expression)
        {
            Expression = expression;
        }
    }
}
