using System;
namespace Directa.Runtime.Instructions
{
    public enum Opcode
    {
        Nop,
        PushByte,
        PushWord,
        PushDoubleWord,
        PopInteger,
        StackAdd,
        Return
    }
}
