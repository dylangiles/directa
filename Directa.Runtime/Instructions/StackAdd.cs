using System;
namespace Directa.Runtime.Instructions
{
    public class StackAdd : Instruction
    {
        public StackAdd() : base(Opcode.StackAdd)
        {
        }

        public override byte[] AsBytes() => new byte[] { (byte)Opcode };
    }
}
