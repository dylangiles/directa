
namespace Directa.Compiler.AbstractSyntaxTree.Constants
{
    public abstract class Constant : Expression
    {
        protected Constant(ParserTypeDefinition typeDefinition) : base(typeDefinition)
        {}
        public abstract object? GetValue();
    }
}
