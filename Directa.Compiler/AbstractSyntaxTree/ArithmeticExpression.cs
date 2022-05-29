using System;
using System.Collections.Generic;
using Directa.Runtime.Instructions;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class ArithmeticExpression : Expression
    {
        public Expression Left { get; private set; }
        public Operator Operator { get; private set; }
        public Expression Right { get; private set; }

        public ArithmeticExpression(Expression left, Operator op, Expression right)
        {
            Left = left;
            Operator = op;
            Right = right;
        }

        public override object? Evaluate() => null;

        //public object Evaluate()
        //{
        //    if (Left is Constant)
        //}

        public override List<byte> Compile()
        {
            List<byte> result = new List<byte>();
            switch (Operator)
            {
                case Operator.Addition:

                    result.AddRange(CompileOperand(Left));
                    result.AddRange(CompileOperand(Right));
                    result.AddRange(new StackAdd().AsBytes());
                    break;

                default: throw new NotImplementedException();
            }

            return result;
        }

        private List<byte> CompileOperand(Expression expression)
        {
            List<byte> result = new List<byte>();
            if (expression is ArithmeticExpression)
            {
                result.AddRange(((ArithmeticExpression)expression).Compile());
            }
            else
            {
                if (expression is Literals.Integer)
                {
                    PushInteger instruction = new PushInteger(0);
                    result.AddRange(instruction.AsBytes());
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return result;
        }
    }
}
