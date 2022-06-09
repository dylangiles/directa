using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public enum OperatorType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
    
    

    public class Operator : Node
    {
        public const string ADDITIVE_OPERATOR = "+";
        public const string SUBTRACTIVE_OPERATOR = "-";
        
        public OperatorType OperatorType { get; set; }

        public Operator(OperatorType operatorType)
        {
            OperatorType = operatorType;    
        }
    }
}
