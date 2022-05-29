using System;
namespace Directa.Runtime.Instructions
{
    public class PopInteger : Instruction
    {
        public PopInteger() : base(Opcode.PopInteger)
        {
        }

        public override byte[] AsBytes() => new byte[] { (byte)Opcode };
    }
}
