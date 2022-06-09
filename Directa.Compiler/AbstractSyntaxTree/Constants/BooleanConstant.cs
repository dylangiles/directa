using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Compiler.AbstractSyntaxTree.Constants
{
    public class BooleanConstant : Constant
    {
        public bool Value { get; private set; }

        public BooleanConstant(bool value) :
            base(new ParserTypeDefinition("boolean", 1, 0, 0))
        {
            Value = value;
        } 
            

        public override object? GetValue() => Value;
    }
}
