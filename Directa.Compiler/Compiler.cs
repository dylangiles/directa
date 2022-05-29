using System;
using System.Collections.Generic;
using System.IO;
using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Compiler
{
    public class Compiler
    {
        private string _inFile;
        private string _outFile;
        private string? _buffer;

        public Compiler(string inFile, string outFile)
        {
            _inFile = inFile;
            _outFile = outFile;
        }

        public void Compile()
        {
            using (FileStream fs = new FileStream(_inFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                    _buffer = sr.ReadToEnd();
            }

            List<Token> tokens = new List<Token>();
            Lexer lexer = new Lexer(_buffer);
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

            if (File.Exists(_outFile))
                File.Delete(_outFile);

            List<byte> compiledProgram = new List<byte>();
            foreach (Block block in parser.Blocks)
            {
                foreach (Statement statement in block.Statements)
                    compiledProgram.AddRange(statement.Compile().ToArray());
            }

            using (FileStream fs = new FileStream(_outFile, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                fs.Write(compiledProgram.ToArray(), 0, compiledProgram.Count);
            }
        }
    }
}
