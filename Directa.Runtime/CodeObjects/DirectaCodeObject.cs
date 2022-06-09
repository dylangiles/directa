using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Runtime.CodeObjects
{
    public class DirectaCodeObject
    {
        public List<SymbolTableEntry> Locals { get; private set; }
        public List<SymbolTableEntry> Globals { get; private set; }
        public EvaluationStack EvaluationStack { get; private set; }
    }
}
