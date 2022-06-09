using System;
using Directa.Compiler.AbstractSyntaxTree.Constants;

namespace Directa.Compiler.Parser;

public class ConstantVisitor: DirectaBaseVisitor<Constant>
{
    public override Constant VisitConstant(DirectaParser.ConstantContext context)
    {
        
        if (context.INTEGER() is { } i)
        {
            int intResult = 0;    
            if (!int.TryParse(i.GetText(), out intResult))
                throw new Exception(String.Format("Cannot parse expression: {0}", i.GetText()));

            return new IntegerConstant(intResult);
        }
        
        else if (context.BOOLEAN() is { } b)
        {
            bool boolResult = false;
            if (!bool.TryParse(b.GetText(), out boolResult))
                throw new Exception(String.Format("Cannot parse expression: {0}", b.GetText()));

            return new BooleanConstant(boolResult);
        }
        
        // else if (context.STRING() is { } s)
        // {
        //     return new StringConstant(s.GetText());
        // }
        
        else if (context.FLOAT() is { } f)
        {
            double floatResult = default(double);
            if (!double.TryParse(f.GetText(), out floatResult))
                throw new Exception(String.Format("Cannot parse expression: {0}", f.GetText()));

            return new FloatConstant(floatResult);
        }

        else
        {
            throw new NotImplementedException();
        }
        
    }
}