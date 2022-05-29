using System;
using System.Collections.Generic;
using Directa.Runtime.Instructions;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class ReturnStatement : Statement
    {
        private Expression _returnCode;
        public ReturnStatement(Expression returnCode)
        {
            _returnCode = returnCode;
        }

        public override List<byte> Compile()
        {
            List<byte> result = new List<byte>();
            result.AddRange(_returnCode.Compile());
            result.Add((byte)Opcode.Return);
            //result.AddRange(_returnCode.);
            return result;
        }
    }
}
