using System;
namespace Directa.Compiler.AbstractSyntaxTree
{
    public class DirectaObject
    {
        public string Identifier { get; private set; }
        public object? Value { get; private set; }
        public DirectaObject(string identifier, object? value)
        {
            Identifier = identifier;
            Value = value;
        }

        public virtual string GetDirectaType() => "DirectaObject";
        public virtual object Evaluate() => this;
        public override string ToString() => String.Format("{0}: {1}", Identifier, GetDirectaType());
    }
}
