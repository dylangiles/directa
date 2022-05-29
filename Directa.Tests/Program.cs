using System;
using System.Collections.Generic;
using Directa.Compiler;

namespace Directa.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string program = @"variable: integer = 0";
            List<Token> tokens = new List<Token>();
            Lexer lexer = new Lexer(program);
            lexer.Run();
            while (true)
            {
                try
                {
                    Token token = lexer.GetToken();
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
            Console.WriteLine();
        }
    }
}
