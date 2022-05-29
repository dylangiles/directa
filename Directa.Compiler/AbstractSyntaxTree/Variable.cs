using System;
using System.Collections.Generic;
using Directa.Runtime.Instructions;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Variable : Expression
    {
        public int Pointer { get; private set; }
        public Variable(int pointer)
        {
            Pointer = pointer;
        }

        public override List<byte> Compile()
        {
            List<byte> result = new List<byte>();

            return result;
        }

        public override object? Evaluate() => null;
    }
}
