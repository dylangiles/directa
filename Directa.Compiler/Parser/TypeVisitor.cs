using System.Reflection.Metadata;
using Directa.Compiler.AbstractSyntaxTree;

namespace Directa.Compiler.Parser;

public class TypeVisitor : DirectaBaseVisitor<ParserTypeDefinition?>
{
    private ParserProgram _program;
    public TypeVisitor(ParserProgram parserProgram)
    {
        _program = parserProgram;
    }
    public override ParserTypeDefinition? VisitType(DirectaParser.TypeContext context)
    {
        ParserTypeDefinition? result = null;
        if (!_program.BuiltinTypeDefs.TryGetValue(context.GetText(), out result))
            return null;

        return result;
    }
}