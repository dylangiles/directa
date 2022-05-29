using System;
using System.Collections.Generic;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public abstract class Expression
    {
        public Expression()
        {
        }


        public abstract object? Evaluate();
        public abstract List<byte> Compile();
    }
}
