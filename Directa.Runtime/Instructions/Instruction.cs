using System;
namespace Directa.Runtime.Instructions
{
    public abstract class Instruction : IInstruction
    {
        public Opcode Opcode { get; protected set; }
        public Instruction(Opcode opcode)
        {
            Opcode = opcode;
        }

        public abstract byte[] AsBytes();
    }
}
