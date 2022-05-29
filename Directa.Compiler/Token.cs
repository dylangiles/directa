using System;
namespace Directa.Compiler
{
    public class Token
    {
        public Lexer.TokenType TokenType { get; private set; }
        public string? Value { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }
        public Token(Lexer.TokenType type, string? value, int line, int column)
        {
            TokenType = type;
            Value = value;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return String.Format("{0} \"{1}\", @{2}:{3}", TokenType, Value, Line, Column);
        }
    }
}
