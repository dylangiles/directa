using System;
using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Compiler.Compiler compiler = new Compiler.Compiler();
            ParserProgram program = compiler.GetProgram("Parser");
            Interpreter interpreter = new Interpreter(program);
            interpreter.Interpret();
            Console.WriteLine(interpreter.ReturnCode);
        }
    }
}
