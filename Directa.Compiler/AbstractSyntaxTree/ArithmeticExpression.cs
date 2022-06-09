using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class ArithmeticExpression : Expression
    {
        public Expression Left { get; private set; }
        public Expression Right { get; private set; }
        public Operator Operator { get; private set; }
        
        public ArithmeticExpression(ParserTypeDefinition typeDef, Expression left, Expression right, Operator operatorObject) : 
            base(typeDef)
        {
            Left = left;
            Right = right;
            Operator = operatorObject;
        }
    }
}
