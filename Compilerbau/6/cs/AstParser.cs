using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Language;

namespace cs;

public class AstParserException : Exception
{
    public AstParserException(ParserRuleContext ctx, string message) : this(
            ctx.Start.Line, 
            ctx.Start.Column, 
            message, 
            ctx.Start.InputStream.GetText(new Interval(ctx.Start.StartIndex, ctx.Start.StopIndex)))
    {
    }
    
    public AstParserException(IToken token, string message) : this(token.Line, token.Column, message, token.Text)
    {
    }

    private AstParserException(int line, int column, string message, string text) 
        : base(BuildMessage(line, column, message, text))
    {
        Line = line;
        Column = column;
        Text = text;
    }
    
    public int Line { get; }
    public int Column { get; }
    
    public string Text { get; }

    private static string BuildMessage(int line, int column, string message, string text)
    {
        return $"file:{line}:{column} {message}\n\t'{text}'";
    }
}

public static class AstParser
{

    public static Stmt[] ParseProgram(this MiniCParser.ProgramContext ctx) => 
        ctx.stmt().Select(ParseStatement).ToArray();

    public static Block ParseBlock(this MiniCParser.BlockContext ctx) =>
        // ctx.stmt() |> Select ParseStatement |> toArray |> Block
        new Block(ctx.stmt().Select(ParseStatement).ToArray());
    
    public static Stmt ParseStatement(this MiniCParser.StmtContext ctx)
    {
        if (ctx.vardecl() is { } vardecl)
            return new VarDecl(vardecl.type().ParseType(), vardecl.ID().GetText(), vardecl.expr().ParseExpression());
        
        if (ctx.assign() is { } assign)
            return new Assign(assign.ID().GetText(), assign.expr().ParseExpression());

        if (ctx.fndecl() is { } fndecl)
            return new FnDecl(
                fndecl.type().ParseType(),
                fndecl.ID().GetText(),
                fndecl.@params().ParseParams(),
                fndecl.block().ParseBlock()
            );

        if (ctx.expr() is { } expr)
            return expr.ParseExpression();

        if (ctx.block() is { } block)
            return block.ParseBlock();

        if (ctx.@while() is { } w)
            return new WhileStmt(w.expr().ParseExpression(), w.block().ParseBlock());

        if (ctx.cond() is { } i)
            return i.ParseIf();

        if (ctx.@return() is { } r)
            return r.expr().ParseExpression();

        throw new AstParserException(ctx, "Unknown statement");
    }
    
    
    public static Param[] ParseParams(this MiniCParser.ParamsContext? ctx) => ctx is null ? [] :
        ctx.type().Zip(ctx.ID())
            .Select((t => new Param(t.Item1.ParseType(), t.Item2.GetText())))
            .ToArray();

    public static PrimType ParseType(this MiniCParser.TypeContext ctx) => ctx.GetText() switch
    {
        "int" => PrimType.INT,
        "string" => PrimType.STRING,
        "bool" => PrimType.BOOL,
        "void" => PrimType.VOID,
        _ => throw new AstParserException(ctx, "Unsupported type")
    };

    public static Expr.Call ParseFunctionCall(this MiniCParser.FncallContext ctx) => new(
        ctx.ID().GetText(),
        ctx.args().ParseArgs()
    );
    
    public static Expr[] ParseArgs(this MiniCParser.ArgsContext? ctx) => ctx is null ? [] : 
        ctx.expr().Select(ParseExpression).ToArray();
    
    public static Expr ParseExpression(this MiniCParser.ExprContext ctx)
    {
        if (ctx.fncall() is { } fncall)
            return fncall.ParseFunctionCall();

        if (ctx is { left: { } left, right: { } right, binop: { } binop })
            return new Expr.Binop(
                ParseOperator(binop),
                left.ParseExpression(),
                right.ParseExpression()
                );
        
        if (ctx.ID() is { } id)
            return new Expr.Variable(id.GetText());
        
        if (ctx.NUMBER() is { } n)
            return new Expr.Literal<int>(int.Parse(n.GetText()));
        
        if (ctx.STRING() is { } s)
            return new Expr.Literal<string>(s.GetText());

        if (ctx.@true is { } t)
            return new Expr.Literal<bool>(true);
        
        if (ctx.@false is { } f)
            return new Expr.Literal<bool>(false);
        
        throw new AstParserException(ctx, "Unknown expression");

    }

    public static Operator ParseOperator(IToken token) => token.Text switch
    {
        "+" => new Operator.Plus(),
        "-" => new Operator.Minus(),
        "*" => new Operator.Multiply(),
        "/" => new Operator.Divide(),
        "==" => new Operator.Equal(),
        "!=" => new Operator.NotEqual(),
        "<" => new Operator.LessThan(),
        "<=" => new Operator.LessThanEqual(),
        ">" => new Operator.GreaterThan(),
        ">=" => new Operator.GreaterThanEqual(),
        _ => throw new AstParserException(token, $"Unsupported operator '{token.Text}'")
    };
    
    public static IfStmt ParseIf(this MiniCParser.CondContext ctx) => new(
        ctx.c.ParseExpression(),
        ctx.@if is { } i ? i.ParseBlock() : new Block([]),
        ctx.@else is { } e ? e.ParseBlock() : new Block([])
    );
}