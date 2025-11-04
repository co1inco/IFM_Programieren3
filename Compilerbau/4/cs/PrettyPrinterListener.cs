using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Language;

namespace _4;


class PrettyPrinterListener(TextWriter writer) : IParseTreeListener
{
    public string Indent { get; set; } = "    ";
    public int IndentCount { get; private set; } = 0;
    
    public void VisitTerminal(ITerminalNode node)
    {
        
    }

    public void VisitErrorNode(IErrorNode node)
    {
        
    }

    public void EnterEveryRule(ParserRuleContext ctx)
    {
        switch (ctx)
        {
            case (LanguageParser.StatementContext):
                writer.Write(string.Repeat(IndentCount, Indent));
                break;
            case (LanguageParser.ExpressionContext expression):
                if (expression.children is [_, LanguageParser.BinaryOperationContext, ..])
                    writer.Write("(");
                break;
            case (LanguageParser.AssignmentContext assignment):
                writer.Write($"{assignment.IDENTIFIER()} {assignment.ASSIGNMENT()} ");
                break;
            case (LanguageParser.LiteralContext literal):
                writer.Write(literal.GetText());
                break;
            case (LanguageParser.IdentifierContext identifier):
                writer.Write(identifier.IDENTIFIER());
                break;
            case LanguageParser.ComparisonContext comparison:
                writer.Write($" {comparison.children[0].GetText()} ");
                break;
            case LanguageParser.BinaryOperationContext binop:
                writer.Write($" {binop.children[0].GetText()} ");
                break;
            case LanguageParser.CommentContext comment:
                writer.Write($" {comment.GetText()}");
                break;
            
            case LanguageParser.IfContext ifContext:
                if (ifContext.children is [var ifToken, ..])
                    writer.Write($"{ifToken.GetText()} ");
                break;
            
            case LanguageParser.WhileContext whileContext:
                if (whileContext.children is [var whileToken, ..])
                    writer.Write($"{whileToken.GetText()} ");
                break;
            
            case LanguageParser.DoBlockContext doContext:
                if (doContext.children is [var doToken, ..])
                    writer.WriteLine($" {doToken.GetText()}");
                
                IndentCount++;
                break;
            
            case LanguageParser.ElseBlockContext elseContext:
                if (IndentCount > 0) IndentCount--;
                
                writer.Write(string.Repeat(IndentCount, Indent));
                if (elseContext.children is [var elseToken, ..])
                    writer.Write(elseToken.GetText());
                break;
            
            case LanguageParser.EndContext end:
                if (IndentCount > 0) IndentCount--;
                
                writer.Write(string.Repeat(IndentCount, Indent));
                if (end.children is [var endToken, ..])
                    writer.WriteLine(endToken.GetText());
                break;
            
            case LanguageParser.ConditionContext:
                break;
        }
        // Console.WriteLine(ctx);
    }

    public void ExitEveryRule(ParserRuleContext ctx)
    {
        switch (ctx)
        {
            case LanguageParser.StatementContext:
                writer.WriteLine();
                break;
            case (LanguageParser.ExpressionContext expression):
                if (expression.children is [_, LanguageParser.BinaryOperationContext, ..])
                    writer.Write(")");
                break;
            default:
                break;        
        }
    }
}
