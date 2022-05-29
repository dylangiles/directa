using System;
namespace Directa.Runtime.Instructions
{
    public class PushInteger : Instruction
    {
        public int Data { get; private set; }
        public PushInteger(int data) : base(Opcode.PushDoubleWord)
        {
            Data = data;
        }

        public override byte[] AsBytes()
        {
            byte[] dataBytes = new byte[5];
            dataBytes[0] = (byte)Opcode;
            dataBytes[1] = (byte)((Data & 0xFF000000) >> 24);
            dataBytes[2] = (byte)((Data & 0x00FF0000) >> 16);
            dataBytes[3] = (byte)((Data & 0x0000FF00) >> 8);
            dataBytes[4] = (byte)(Data & 0x000000FF);
            return dataBytes;
        }
    }
}
