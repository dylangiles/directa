using System;
using System.Collections.Generic;

using Directa.Runtime.Instructions;
namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Declaration : Statement
    {
        public Expression? Assignment { get; private set; }
        public string Identifier { get; private set; }

        public Declaration(string identifier, Expression? assignment)
        {
            Identifier = identifier;
            Assignment = assignment;
        }

        public void SetAssignment(Expression? assignment) => Assignment = assignment;


        public override List<byte> Compile()
        {
            List<Instruction> instructions = new List<Instruction>();

            List<byte> bytes = new List<byte>();
            foreach (Instruction instruction in instructions)
                bytes.AddRange(instruction.AsBytes());

            return bytes;
        }
    }
}
