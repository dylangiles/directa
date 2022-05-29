using System;
using System.Collections.Generic;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public abstract class Statement
    {
        public Statement()
        {
        }

        public abstract List<byte> Compile();
    }
}
