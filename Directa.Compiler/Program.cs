using System;
namespace Directa.Compiler
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string inFile = args[0];
            string outFile = args[1];
            Compiler compiler = new Compiler(inFile, outFile);
            compiler.Compile();
        }
    }
}
