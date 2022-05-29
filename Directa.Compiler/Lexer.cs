using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Directa.Compiler
{
    public class Lexer
    {
        public enum TokenType
        {
            Undefined,
            Uses,
            Function,
            If,
            Then,
            ElseIf,
            Else,
            End,
            While,
            Do,
            IntegerLiteral,
            StringLiteral,
            FloatLiteral,
            BooleanLiteral,
            Identifier,
            Whitespace,
            NewLine,
            IntegerType,
            StringType,
            FloatType,
            BooleanType,
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Assignment,
            Equality,
            Inequality,
            LeftBracket,
            RightBracket,
            LeftSquareBracket,
            RightSquareBracket,
            Comma,
            Colon,
            Dot,
            Return,
            EndOfFile
        }

        private Dictionary<TokenType, string> _tokenMatchers;
        private Dictionary<TokenType, MatchCollection> _tokenMatchCollection;
        private string _input;
        private int _position;
        private int _lineCount;
        private int _thisLinePosition;

        public Lexer(string input)
        {
            _tokenMatchers = new Dictionary<TokenType, string>();
            _tokenMatchCollection = new Dictionary<TokenType, MatchCollection>();

            _tokenMatchers.Add(TokenType.Uses, "uses");
            _tokenMatchers.Add(TokenType.Function, "function");
            _tokenMatchers.Add(TokenType.If, "if");
            _tokenMatchers.Add(TokenType.ElseIf, "else if");
            _tokenMatchers.Add(TokenType.Else, "else");
            _tokenMatchers.Add(TokenType.Then, "then");
            _tokenMatchers.Add(TokenType.While, "while");
            _tokenMatchers.Add(TokenType.Do, "do");
            _tokenMatchers.Add(TokenType.Return, "return");

            _tokenMatchers.Add(TokenType.IntegerLiteral, "[+-]?[0-9][0-9]*");
            _tokenMatchers.Add(TokenType.StringLiteral, "\".*?\"");
            _tokenMatchers.Add(TokenType.FloatLiteral, "[+-]?(\\d+)(\\.)?(\\d+)F");
            _tokenMatchers.Add(TokenType.BooleanLiteral, "(true|false)");

            _tokenMatchers.Add(TokenType.IntegerType, "integer");
            _tokenMatchers.Add(TokenType.StringType, "string");
            _tokenMatchers.Add(TokenType.FloatType, "float");
            _tokenMatchers.Add(TokenType.BooleanType, "boolean");

            _tokenMatchers.Add(TokenType.Identifier, "[a-zA-Z_][a-zA-Z0-9_]*");
            _tokenMatchers.Add(TokenType.Whitespace, "[ \\t]+");
            _tokenMatchers.Add(TokenType.NewLine, "\\n");
            _tokenMatchers.Add(TokenType.Addition, "\\+");
            _tokenMatchers.Add(TokenType.Subtraction, "\\-");
            _tokenMatchers.Add(TokenType.Multiplication, "\\*");
            _tokenMatchers.Add(TokenType.Division, "\\/");
            _tokenMatchers.Add(TokenType.Equality, "\\==");
            _tokenMatchers.Add(TokenType.Inequality, "\\!=");
            _tokenMatchers.Add(TokenType.Assignment, "\\=");
            _tokenMatchers.Add(TokenType.LeftBracket, "\\(");
            _tokenMatchers.Add(TokenType.RightBracket, "\\)");
            _tokenMatchers.Add(TokenType.LeftSquareBracket, "\\[");
            _tokenMatchers.Add(TokenType.RightSquareBracket, "\\]");
            _tokenMatchers.Add(TokenType.Comma, "\\,");
            _tokenMatchers.Add(TokenType.Dot, "\\.");
            _tokenMatchers.Add(TokenType.Colon, "\\:");

            _input = input;
            _lineCount = 1;
        }

        public void Run()
        {
            _tokenMatchCollection.Clear();
            foreach (KeyValuePair<TokenType, string> pair in _tokenMatchers)
            {
                _tokenMatchCollection.Add(pair.Key, Regex.Matches(_input, pair.Value));
            }
        }

        public Token? GetToken()
        {
            if (_position >= _input.Length)
                return null;

            foreach (KeyValuePair<TokenType, MatchCollection> pair in _tokenMatchCollection)
            {
                foreach (Match match in pair.Value)
                {
                    if (pair.Key == TokenType.NewLine)
                    {
                        _lineCount += 1;
                        _thisLinePosition = 0;
                        break;
                    }
                }

                foreach (Match match in pair.Value)
                {
                    if (match.Index == _position)
                    {
                        _position += match.Length;
                        _thisLinePosition += match.Length;
                        return new Token(pair.Key, match.Value, _lineCount, _thisLinePosition);
                    }

                    if (match.Index > _position)
                        break;
                }


                //_thisLinePosition += match.Length;
            }

            _position += 1;
            return new Token(TokenType.Undefined, null, 0, 0);
        }
    }
}
