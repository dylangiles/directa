using System;
using System.Collections.Generic;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Constant : Expression
    {

        public AbstractSyntaxTree.Type Type { get; private set; }
        public DirectaObject? Value;
        public Constant(AbstractSyntaxTree.Type type, DirectaObject? value)
        {
            Type = type;
            Value = value;
        }

        public override object? Evaluate() => Value;

        public override List<byte> Compile()
        {
            throw new NotImplementedException();
        }
    }
}
