using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Runtime.CodeObjects
{
    public class DirectaModule : DirectaCodeObject
    {
        public string ModuleName { get; private set; }

        public DirectaModule(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}
