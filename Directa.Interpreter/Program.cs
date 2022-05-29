using System;

namespace Directa.Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string program = @"
a: integer = 123
b: integer = 246
c: integer = a + b
return c";
            Interpreter interpreter = new Interpreter(program);
            interpreter.Interpret();
        }
    }
}
