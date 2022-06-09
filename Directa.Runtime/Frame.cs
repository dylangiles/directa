using System;
using System.Collections.Generic;



namespace Directa.Runtime;

public class Frame
{
    public string Name { get; private set; }
    public Dictionary<string, SymbolTableEntry> SymbolTable { get; private set; }
    public EvaluationStack EvaluationStack { get; private set; }
    
    public Frame(int stackSize = 64)
    {
        // Name = mangledName;
        SymbolTable = new Dictionary<string, SymbolTableEntry>();
        EvaluationStack = new EvaluationStack();
        for(int i=0;i<stackSize;i++)
            EvaluationStack.Add(0);

        EvaluationStack.SetStackPointer(EvaluationStack.STACK_BEGIN);
    }

}
