using System;
namespace Directa.Runtime.Instructions
{
    public class Return : Instruction
    {
        public Return() : base(Opcode.Return)
        {

        }

        public override byte[] AsBytes() => new byte[] { (byte)Opcode };
    }
}
