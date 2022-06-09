using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Directa.Compiler.Errors;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class ParserProgram
    {

        public Dictionary<string, ParserTypeDefinition> BuiltinTypeDefs = new() 
        {
            { "integer", new("integer", sizeof(long), 0, TypeFlag.IsNumeric) },
            { "float", new("float", sizeof(double), 0, TypeFlag.IsNumeric) },
            { "boolean", new("boolean", 1, 0, 0) }
        };
        public List<Block> Blocks { get; private set; }
        public Block? CurrentBlock { get; private set; }
        public List<CompilerError> Errors { get; private set; }
        public ParserProgram()
        {
            Blocks = new List<Block>();
            Errors = new List<CompilerError>();
        }

        public void AddBlock(Block block)
        {
            Blocks.Add(block);
            CurrentBlock = block;
        }

        public void AddError(CompilerError error)
        {
            Errors.Add(error);
        }

        public void AddError(string errorCode, string errorMessage) =>
            Errors.Add(new CompilerError(errorCode, errorMessage));

    }
}
