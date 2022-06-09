using System;
using System.Collections.Generic;
using Directa.Compiler;
using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.AbstractSyntaxTree.Constants;
using Directa.Compiler.Parser;
using Directa.Runtime;
using Directa.Runtime.Instructions;
using Directa.Runtime.Types;


namespace Directa.Interpreter
{
    public class Interpreter
    {
        private ParserProgram _program;
        private Runtime.EvaluationStack _currentEvaluationStack;
        private Stack<Runtime.Frame> _callStack;
        private Runtime.Frame _currentFrame;
        private Dictionary<string, Runtime.SymbolTableEntry> _currentSymbolTable;
        
        public int ReturnCode { get; private set; }

        public Interpreter(ParserProgram program)
        {
            _program = program;
            _callStack = new Stack<Runtime.Frame>();
            
        }

        public void Interpret()
        {
            foreach (Block block in _program.Blocks)
            {
                EnterFrame(block);
                foreach (Statement statement in block.Statements)
                {
                    if (statement is Declaration declaration)
                    {
                        ExecuteDeclaration(declaration);   
                    }
                    
                    else if (statement is ReturnStatment returnStatment)
                    {
                        ExecuteReturnStatement(returnStatment);
                    }
                    
                }
            }
        }

        private void ExecuteReturnStatement(ReturnStatment returnStatment)
        {
            if (returnStatment.ReturnExpression is null)
            {
                ReturnCode = 0;
                LeaveFrame();
            }
            else
            {
                EvaluateExpression(returnStatment.ReturnExpression);
                ReturnCode = _currentEvaluationStack.Pop();
                LeaveFrame();
            }
                
        }

        private void EnterFrame(Block block)
        {
            int stackSize = 0;
            foreach(Statement statement in block.Statements)
                if (statement is Declaration)
                    stackSize += 1;
            
            Runtime.Frame newFrame = new Frame(stackSize);
            _currentSymbolTable = newFrame.SymbolTable;
            _currentEvaluationStack = newFrame.EvaluationStack;
            _currentFrame = newFrame;
            
            _callStack.Push(newFrame);
        }

        private void LeaveFrame()
        {
            //TODO
        }

        private void ExecuteDeclaration(Declaration declaration)
        {
            if (declaration.Assignment is not null)
            {
                EvaluateExpression(declaration.Assignment);
                PopStackToSymbolTable(declaration.Identifier, declaration.TypeDefinition.TypeName);
            }
            else
            {
                StoreToSymbolTable(declaration.Identifier, declaration.TypeDefinition.TypeName, 0);
            }
            // if (declaration.Assignment is Constant)
            // {
            //     
            // }
            //
            // else if (declaration.Assignment is Variable)
            // {
            //     SymbolTableEntry? entry = GetSymbolTableEntry(((Variable)declaration.Assignment).Name);
            //     PushSymbolToStack(entry.Name);
            //     PopStackToSymbolTable(declaration.Identifier);
            // }
            //
            // else if (declaration.Assignment is ArithmeticExpression)
            // {
            //     EvaluateExpression(declaration.Assignment);
            // }
        }

        private void PushConstant(DirectaValueType value)
        {
            _currentEvaluationStack.Push(value);
        }

        private void PopStackToSymbolTable(string name, string typeName)
        {
            DirectaValueType value = _currentEvaluationStack.Pop();
            StoreToSymbolTable(name, typeName, value);
        }
        private void StoreToSymbolTable(string name, string typeName, DirectaValueType value)
        {
            _currentSymbolTable.Add(name, new SymbolTableEntry(name, typeName, value));   
        }

        private SymbolTableEntry GetSymbolTableEntry(string name)
        {
            SymbolTableEntry? entry = null;
            if (!_currentSymbolTable.TryGetValue(name, out entry))
                throw new Exception($"Unable to locate symbol: {name}");

            return entry;
        }
        private void PushSymbolToStack(string name)
        {
            SymbolTableEntry? entry = null;
            if (!_currentSymbolTable.TryGetValue(name, out entry))
                throw new Exception($"Unable to locate symbol: {name}");
            
            _currentEvaluationStack.Push(entry.CurrentValue);
        }

        private void EvaluateArithmeticExpression(ArithmeticExpression? expression)
        {
            if (expression is null)
                return;
            
            switch (expression.Operator.OperatorType)
            {
                case OperatorType.Addition:
                    EvaluateExpression(expression.Left);
                    EvaluateExpression(expression.Right);
                    StackAdd();
                    break;
                
                default: throw new NotImplementedException();
            }
        }
        
        private void EvaluateExpression(Expression? expression)
        {
            if (expression is Constant)
            {
                EvaluateConstant(expression as Constant);       
            }
            else if (expression is ArithmeticExpression)
            {
                EvaluateArithmeticExpression(expression as ArithmeticExpression);
            }
            else if (expression is Variable)
            {
                EvaluateVariable(expression as Variable);   
            }
        }

        private void EvaluateConstant(Constant? expression)
        {
            if (expression is IntegerConstant)
            {
                IntegerConstant? integerConstant = expression as IntegerConstant;
                if (integerConstant is null)
                    _currentEvaluationStack.Push(0);
                else
                    _currentEvaluationStack.Push(integerConstant.Value);
            }
            else if (expression is FloatConstant)
            {
                FloatConstant? floatConstant = expression as FloatConstant;
                if (floatConstant is null)
                    _currentEvaluationStack.Push(0);
                else
                    _currentEvaluationStack.Push(floatConstant.Value);
            }
                
            else if (expression is BooleanConstant)
            {
                BooleanConstant? booleanConstant = expression as BooleanConstant;
                if(booleanConstant is null)
                    _currentEvaluationStack.Push(false);
                else
                    _currentEvaluationStack.Push(booleanConstant.Value);
            }

            // else if (expression is StringConstant)
            // {
            //     // TODO
            // }
        }

        private void EvaluateVariable(Variable? expression)
        {
            if (expression is null)
                return;
            SymbolTableEntry? entry = null;
            if (!_currentSymbolTable.TryGetValue(expression.Name, out entry))
                throw new Exception($"Cannot locate symbol '{expression.Name}");
            
            _currentEvaluationStack.Push(entry.CurrentValue);
        }

        public void StackAdd()
        {
            DirectaValueType rightValue = _currentEvaluationStack.Pop();
            DirectaValueType leftValue = _currentEvaluationStack.Pop();
            _currentEvaluationStack.Push(leftValue + rightValue);
        }
        
        

    }
}
