

namespace Directa.Compiler.AbstractSyntaxTree.Constants;

public class FloatConstant: Constant
{
    public double Value { get; private set; }

    public FloatConstant(double value) :
        base(new ParserTypeDefinition("float", sizeof(double), 0, TypeFlag.IsNumeric))
    {
        Value = value;
    }

    public override object? GetValue() => Value;
}