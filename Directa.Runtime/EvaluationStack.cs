using System;
using System.Collections.Generic;
using Directa.Runtime.Types;

namespace Directa.Runtime
{
    public class EvaluationStack : List<DirectaValueType>
    {
        public const int STACK_BEGIN = -1;
        public int StackPointer { get; private set; }

        // The stack structure grows upwards, the value types themselves are little-endian however.
        // This is an implementation detail, and does not affect much (the debugger displays the stack
        // better in upwards-stack)
        public void Push(DirectaValueType value)
        {
            IncrementStackPointer();   
            this[StackPointer] = value;
        }

        public DirectaValueType Pop()
        {
            DirectaValueType result = this[StackPointer];
            DecrementStackPointer();

            return result;
        }

        public void IncrementStackPointer() => StackPointer += 1;
        public void DecrementStackPointer() => StackPointer -= 1;
        public void SetStackPointer(int value) => StackPointer = value;

    }

}
