using System;
using System.Collections.Generic;

namespace Directa.Compiler
{
    public class TokenStack
    {
        public IList<Token> Tokens { get; private set; }
        public int Position { get; private set; }
        public Token? PreviousToken
        {
            get
            {
                Token? result = null;
                try
                {
                    result = Tokens[Position - 1];
                }
                catch (Exception) { }

                return result;
            }
        }

        public Token? NextToken
        {
            get
            {
                Token? result = null;
                try
                {
                    result = Tokens[Position + 1];
                }
                catch (Exception) { }

                return result;
            }
        }

        public TokenStack(IList<Token> tokens)
        {
            Tokens = tokens;
        }

        public Token Pop()
        {
            Token retVal = Tokens[Position];
            Position += 1;
            return retVal;
        }

        public Token Peek() => Tokens[Position];

        public void SeekForwards() => Position += 1;
        public void SeekBackwards() => Position -= 1;

    }
}
