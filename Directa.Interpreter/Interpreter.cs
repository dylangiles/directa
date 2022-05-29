using System;
using System.Collections.Generic;
using Directa.Compiler;
using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Interpreter
{
    public class Interpreter
    {
        private string _program;
        private Stack<int> _stack;
        private List<DirectaObject> _heap;

        public Interpreter(string program)
        {
            _program = program;
            _stack = new Stack<int>();
            _heap = new List<DirectaObject>();
        }

        public void Interpret()
        {
            List<Token> tokens = new List<Token>();
            Lexer lexer = new Lexer(_program);
            lexer.Run();
            while (true)
            {
                try
                {
                    Token? token = lexer.GetToken();
                    if (token is null)
                        break;

                    if (token.TokenType != Lexer.TokenType.Whitespace && token.TokenType != Lexer.TokenType.NewLine)
                        tokens.Add(token);
                }
                catch (Exception)
                {
                    break;
                }

            }

            TokenStack tokenList = new TokenStack(tokens);
            Parser parser = new Parser(tokenList);
            parser.Parse();
            foreach (Block block in parser.Blocks)
            {
                foreach (Statement statement in block.Statements)
                {
                    if (statement is Declaration)
                    {
                        _heap.Add(new DirectaObject(((Declaration)statement).Identifier, ((Declaration)statement).Assignment.Evaluate()));
                        _stack.Push(_heap.Count - 1);
                    }
                }

            }
        }

    }
}
