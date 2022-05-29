using System;
using System.Collections.Generic;
using System.IO;
namespace Directa.Runtime
{
    class Program
    {
        static int Main(string[] args)
        {
            string inFile = args[0];
            List<byte> bytes = new List<byte>();
            using (FileStream fs = new FileStream(inFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                for (long i = 0; i < fs.Length; i++)
                    bytes.Add((byte)fs.ReadByte());
            }

            VirtualMachine vm = new VirtualMachine(bytes.ToArray());
            int returnCode = vm.Run();
            return returnCode;
        }
    }
}
