using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Runtime.Types
{
    public class DirectaType
    {
        public string Name { get; private set; }
        public DirectaType(string name)
        {
            Name = name;
        }

        public override string ToString() => $"Type<{Name}>";
    }
}
