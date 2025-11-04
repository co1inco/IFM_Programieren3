// See https://aka.ms/new-console-template for more information

using _4;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Language;

Console.WriteLine("Hello, World!");

var testInput = 
"""
abc := 123                
bcd := 456          # hello world      
ttt := abc    == 123
        ttt := abc != 123
ttt :=    abc >= 123
ttt := abc >    123
   ttt := abc < 123
a := 1  +   2
a := 3 + 4 * 5
""";


var lexer = new LanguageLexer(CharStreams.fromString(testInput));
var parser = new LanguageParser(new CommonTokenStream(lexer));

var tree = parser.start();

Console.WriteLine(tree.ToStringTree());

var writer = new StringWriter();
// var printer = new Parser.TraceListener(writer, parser);
// ParseTreeWalker.Default.Walk(printer, tree);
Console.WriteLine(writer.ToString());

var printer = new PrettyPrinter(Console.Out);
ParseTreeWalker.Default.Walk(printer, tree);


class PrettyPrinter(TextWriter writer) : IParseTreeListener
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


