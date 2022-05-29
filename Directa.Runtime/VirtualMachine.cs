using System;
using System.Collections.Generic;
using System.IO;
using Directa.Runtime.Instructions;

namespace Directa.Runtime
{
    public class VirtualMachine
    {
        public Stack<int> Stack { get; private set; }
        public List<object> Heap { get; private set; }

        private byte[] _program;
        private int _returnCode { get; set; }


        public VirtualMachine(byte[] program)
        {
            //_program = program;
            _program = new byte[]
            {
                (byte)Opcode.PushDoubleWord, 0, 0, 0, 123,
                (byte)Opcode.PushDoubleWord, 0, 0, 0, 246,
                (byte)Opcode.StackAdd,
                (byte)Opcode.Return
            };
            Stack = new Stack<int>();
            Heap = new List<object>();
        }

        public int Run()
        {
            MemoryStream ms = new MemoryStream(_program);
            List<byte> operands = new List<byte>();

            for (int msIndex = 0; msIndex < ms.Length; msIndex++)
            {
                switch ((Opcode)ms.ReadByte())
                {
                    case Opcode.Nop: break;

                    case Opcode.PushDoubleWord:
                        Stack.Push(ByteConverter.IntegerFromBytes(ReadInstructionBytes(ms, sizeof(int))));

                        break;

                    case Opcode.StackAdd:
                        StackAdd();

                        break;

                    case Opcode.Return:
                        _returnCode = Stack.Pop();
                        break;
                }
            }

            ms.Dispose();
            return _returnCode;
        }

        private void StackAdd()
        {
            int leftSide = Stack.Pop();
            int rightSide = Stack.Pop();
            int result = leftSide + rightSide;
            //PushInteger(rightSide);
            //PushInteger(leftSide);
            Stack.Push(result);
        }

        private byte[] ReadInstructionBytes(MemoryStream ms, int numberOfBytes)
        {
            List<byte> result = new List<byte>();
            for (int i = 0; i < numberOfBytes; i++)
                result.Add((byte)ms.ReadByte());

            return result.ToArray();
        }
    }
}
