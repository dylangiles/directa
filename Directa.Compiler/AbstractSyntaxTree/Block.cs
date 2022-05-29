using System;
using System.Collections.Generic;

namespace Directa.Compiler.AbstractSyntaxTree
{
    public class Block : Statement
    {
        public List<Statement> Statements { get; private set; }
        public List<Declaration> Declarations { get; private set; }

        public Block()
        {
            Statements = new List<Statement>();
            Declarations = new List<Declaration>();
        }

        public void AddStatement(Statement statement) => Statements.Add(statement);

        public override List<byte> Compile()
        {
            List<byte> result = new List<byte>();
            foreach (Statement statement in Statements)
                result.AddRange(statement.Compile());

            return result;
        }
    }
}
