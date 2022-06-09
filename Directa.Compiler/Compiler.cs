using System;
using System.IO;
using Antlr4.Runtime;
using Directa.Compiler.AbstractSyntaxTree;
using Directa.Compiler.Exceptions;
using Directa.Compiler.Parser;

namespace Directa.Compiler;

public class Compiler
{
    public ParserProgram GetProgram(string filename) 
    {
        string fileName = "Parser" + Path.DirectorySeparatorChar + "test.dta";
        string fileContents = File.ReadAllText(fileName);

        AntlrInputStream inputStream = new AntlrInputStream(fileContents);

        DirectaLexer lexer = new DirectaLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        DirectaParser parser = new DirectaParser(commonTokenStream);

        DirectaParser.ProgramContext programContext = parser.program();
        ProgramVisitor visitor = new ProgramVisitor();
        ParserProgram? program = visitor.VisitProgram(programContext);

        if (program.Errors.Count > 0)
        {
            foreach(Errors.CompilerError error in program.Errors)
            {
                Console.WriteLine(error);                
            }

            Environment.Exit(-1);
        }

        return program ?? new ParserProgram();
    }
}