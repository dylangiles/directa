using System;
using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.Exceptions;

using System.Collections.Generic;
using System.Linq;

namespace Directa.Compiler
{
    public class Parser
    {
        private TokenStack _tokenStack;
        public List<Block> Blocks { get; private set; }

        private List<Statement> _statements { get; set; }
        private Token _currentToken;
        private bool _running = false;
        private Block _currentBlock;

        public Parser(TokenStack tokenStack)
        {
            _tokenStack = tokenStack;
            _statements = new List<Statement>();
            Blocks = new List<Block>();
            _currentBlock = new Block();
        }

        public void Parse()
        {
            _running = true;
            Assignment? assignment = null;

            while (_running)
            {

                try
                {
                    _currentToken = _tokenStack.Pop();
                }
                catch (Exception)
                {
                    break;  //TODO
                }


                try
                {
                    switch (_currentToken.TokenType)
                    {
                        case Lexer.TokenType.Identifier:
                            if (_tokenStack.Peek().TokenType == Lexer.TokenType.Colon)
                            {
                                Declaration declaration = ParseDeclaration();
                                _statements.Add(declaration);
                                _currentBlock.Declarations.Add(declaration);
                            }




                            else
                            {
                                throw new MissingTypeException(_currentToken.Line, _currentToken.Column);
                            }

                            break;
                        case Lexer.TokenType.Return:
                            _statements.Add(ParseReturn());
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
                catch (Exception)
                {
                    throw;
                }
            }


            _currentBlock.Statements.AddRange(_statements);
            Blocks.Add(_currentBlock);
        }

        private Statement ParseReturn()
        {
            Token token = _tokenStack.Peek();
            Expression? expression = ParseExpression(token);
            return new ReturnStatement(expression);
        }

        public Declaration ParseDeclaration()
        {
            _tokenStack.SeekBackwards();
            Token token = _tokenStack.Pop();

            if (token.Value is null)
                throw new InvalidIdentifierException(token.Line, token.Column);

            string identifier = token.Value;

            // Skip the colon
            _tokenStack.SeekForwards();

            token = _tokenStack.Pop();
            if (token.Value is null)
                throw new UnknownTypeException(token);

            Declaration declaration = new Declaration(identifier, ParseExpression(token));

            _tokenStack.SeekForwards();
            token = _tokenStack.Pop();
            Expression? assignment = ParseExpression(identifier, token); ;



            declaration.SetAssignment(assignment);
            return declaration;
        }

        public Assignment? ParseAssignment(Identifier identifer)
        {
            Assignment? assignment;

            Token assignmentToken = _tokenStack.Pop();
            Expression? expression = null;


            return new Assignment(expression);
        }

        public Expression ParseExpression(string identifier, Token token)
        {
            Expression? expression = null;
            switch (token.TokenType)
            {
                case Lexer.TokenType.IntegerLiteral:
                    expression = new Constant(AbstractSyntaxTree.Type.Integer,
                        new DirectaObject(identifier, Convert.ToInt32(token.Value)));
                    break;

                case Lexer.TokenType.Identifier:

                    Declaration? leftDeclaration = _currentBlock.Declarations
                        .Where(x => x.Identifier == token.Value)
                        .FirstOrDefault();

                    if (leftDeclaration is null)
                    {
                        throw new UnknownIdentifierExpression(token);
                    }

                    if (leftDeclaration.Assignment is null)
                    {
                        throw new CannotEvaluateExpressionException(token);
                    }


                    int stackOffset = 0;
                    for (int i = _currentBlock.Declarations.Count - 1; i > 0; i--)
                    {
                        if (_currentBlock.Declarations[i] == leftDeclaration)
                        {
                            break;

                        }

                        if (_currentBlock.Declarations[i].DeclarationType is Integer)
                        {
                            stackOffset += sizeof(int);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }

                    Expression leftExpression = new Variable(leftDeclaration.DeclarationType, stackOffset);


                    if (NextTokenIsOperator(_tokenStack.Peek()))
                    {
                        Token operatorToken = _tokenStack.Pop();
                        Token rightToken = _tokenStack.Pop();
                        expression = new ArithmeticExpression(
                            leftExpression,
                            ParseOperator(operatorToken),
                            ParseExpression(rightToken)
                        );
                    }
                    else
                    {
                        return leftExpression;
                    }

                    break;


                default:
                    throw new InvalidExpressionException(token);

            }


            return expression;
        }

        public static bool NextTokenIsOperator(Token token)
        {
            return token.TokenType == Lexer.TokenType.Addition ||
                token.TokenType == Lexer.TokenType.Subtraction ||
                token.TokenType == Lexer.TokenType.Multiplication ||
                token.TokenType == Lexer.TokenType.Division;
        }

        public static Operator ParseOperator(Token token)
        {
            switch (token.TokenType)
            {
                case Lexer.TokenType.Addition:
                    return Operator.Addition;
                default: throw new UnknownOperatorException(token);
            }
        }
    }
}
