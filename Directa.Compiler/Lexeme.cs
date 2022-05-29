using System;
using System.Text.RegularExpressions;

namespace Directa.Compiler
{
    public class Lexeme
    {
        public MatchCollection MatchCollection { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }

        public Lexeme(MatchCollection matchCollection, int line, int column)
        {
            MatchCollection = matchCollection;
            Line = line;
            Column = column;
        }
    }
}
