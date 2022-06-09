using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Directa.Compiler.Exceptions;
using Directa.Compiler.Parser;

using Directa.Runtime.Types;

namespace Directa.Compiler.AbstractSyntaxTree;

public class CompileTimeTypeChecker
{
    public static bool IsAssignmentLegal(ParserTypeDefinition targetTypeDef, ParserTypeDefinition assignTypeDef)
    {
        if (targetTypeDef.TypeName == assignTypeDef.TypeName)
            return true;

        return false;
    }
    public static bool IsAdditionLegal(ParserTypeDefinition leftTypeDef, ParserTypeDefinition rightTypeDef)
    {
        if (leftTypeDef.TypeName == rightTypeDef.TypeName)
            return true;

        return false;
    }
}