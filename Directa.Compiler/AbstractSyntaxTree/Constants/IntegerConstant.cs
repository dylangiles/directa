using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Directa.Compiler.AbstractSyntaxTree.Constants
{
    public class IntegerConstant : Constant
    {
        public int Value { get; private set; }

        public IntegerConstant(int value) :
            base(new ParserTypeDefinition("integer", sizeof(long), 0, TypeFlag.IsNumeric))
        {
            Value = value;
        }

        public override object? GetValue() => Value;
    }
}
