using System.Collections;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Reflection;
using Antlr4.Runtime.Tree;
using Language;
using OneOf;

namespace _4;

public interface IAstNode
{
    IEnumerable<string> BuildSource();
}


[GenerateOneOf]
public partial class Statement : OneOfBase<Assignment, If, While>, IAstNode
{
    // protected Statement(OneOf<Assignment, If, While> input, string? comment) : this(input)
    // {
    //     Comment = comment;
    // }
    
    public string? Comment { get; init; }

    public override string ToString() => $"Statement: {Value}";

    private string WithComment(string b) => Comment is null ? b : $"{b} {Comment}";
    public IEnumerable<string> BuildSource()
    {
        return Match(a => a.BuildSource(), i => i.BuildSource(), w => w.BuildSource()).ToArray() switch
        {
            [var f, .. var rem] => [WithComment(f), .. rem],
            _ => [WithComment("")]
        };
    }
}

[GenerateOneOf]
public partial class Expression : OneOfBase<
    Expression.Comparison,
    Expression.BinaryOperation,
    Literal, 
    Identifier>
    , IAstNode
{
    public record Comparison(ComparisonOperand Operator, Expression Left, Expression Right) : IAstNode
    {
        public IEnumerable<string> BuildSource() => Merge(Operator.GetDescription(), Left, Right);
    }

    public record BinaryOperation(BinaryOperand Operation, Expression Left, Expression Right) : IAstNode
    {
        public IEnumerable<string> BuildSource() => Merge(Operation.GetDescription(), Left, Right);
    }

    private static IEnumerable<string> Merge(string between, Expression left, Expression right)
    {
        var leftText = left.BuildSource().ToArray();
        var rightText = right.BuildSource().ToArray();

        return
        [
            ..leftText[..^1],
            $"{leftText.Last()} {between} {rightText.First()}",
            ..rightText[1..]
        ];

    } 
    
    public override string ToString() =>  $"Expression: {Value}";

    public IEnumerable<string> BuildSource() => Match(
        c => c.BuildSource(),
        b => b.BuildSource(),
        l => l.BuildSource(),
        id => id.BuildSource());
};

[GenerateOneOf]
public partial class Literal : OneOfBase<
    Literal.Integer,
    Literal.String,
    Literal.Char>, IAstNode
{
    public record struct Integer(string Value);
    public record struct String(string Value);
    public record struct Char(string Value);

    public override string ToString() =>  $"Literal: {Value}";

    public IEnumerable<string> BuildSource() => 
    [
        Match(
            i => i.Value,
            s => s.Value,
            c => c.Value
        )
    ];
}

public record Assignment(Identifier Identifier, Expression Expression) : IAstNode
{
    public IEnumerable<string> BuildSource()
    {
        var start = $"{Identifier.BuildSource().First()} := ";

        var exp = Expression.BuildSource().ToArray();
        if (exp is [var a, .. var b])
            return [$"{start}{a}", ..b];
        if (exp is [var c])
            return [$"{start}{c}"];
        return [start];
    }
}

public record Condition(Expression Expression) : IAstNode
{
    public IEnumerable<string> BuildSource() => Expression.BuildSource();
}

public record If(Condition Condition, Statement[] Statements, Statement[]? ElseStatements) : IAstNode
{
    private string ElseString() => ElseStatements is not null ? $"else do\n{string.Join("\n", Statements)}" : "";
    public override string ToString() => $"if {Condition} do\n{string.Join("\n", Statements)}{ElseString()}\nend";
    
    public IEnumerable<string> BuildSource()
    {
        return
        [
            ..BuildIfCondition(),
            ..Statements.SelectMany(x => x?.BuildSource() ?? []).Select(x => $"    {x}"),
            ..(ElseStatements is null 
                ? Array.Empty<string>() 
                : [
                    "else do",
                    ..ElseStatements.SelectMany(x => x?.BuildSource() ?? []).Select(x => $"    {x}")
                ]),
            $"end"
        ];
    }

    private IEnumerable<string> BuildIfCondition()
    {
        return Condition.BuildSource().ToArray() switch
        {
            [var single] => [$"if {single} do"],
            var multiple =>
            [
                $"if",
                ..multiple.Select(x => $"  {x}"),
                "do"
            ]
        };
    }
}

public record While(Condition Condition, Statement[] Statements) : IAstNode
{
    public override string ToString() => $"while {Condition} do\n{string.Join("\n", Statements)}\nend";

    public IEnumerable<string> BuildSource() =>
    [
        ..BuildWhileCondition(),
        ..Statements.SelectMany(x => x.BuildSource()).Select(x => $"    {x}"),
        $"end"
    ];
    
    private IEnumerable<string> BuildWhileCondition()
    {
        return Condition.BuildSource().ToArray() switch
        {
            [var single] => [$"while {single} do"],
            var multiple =>
            [
                $"while",
                ..multiple.Select(x => $"  {x}"),
                "do"
            ]
        };
    }
}

public record struct Identifier(string Text) : IAstNode
{
    public override string ToString() => Text;

    public IEnumerable<string> BuildSource() => [Text];
}

public enum ComparisonOperand
{
    [Description("==")]
    Equals,
    [Description("!=")]
    NotEquals,
    [Description("<")]
    LessThan,
    [Description("<=")]
    LessThanOrEquals,
    [Description(">")]
    GreaterThan,
    [Description(">=")]
    GreaterThanOrEquals
}

public enum BinaryOperand
{
    [Description("+")]
    Add,
    [Description("-")]
    Subtract,
    [Description("*")]
    Multiply,
    [Description("/")]
    Divide,
    [Description("%")]
    Modulo
}

public static class EnumHelper 
{
    public static string GetDescription<T>(this T value) where T : Enum
    {
        
        //Tries to find a DescriptionAttribute for a potential friendly name
        //for the enum
        MemberInfo[] memberInfo = value.GetType().GetMember(value.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                //Pull out the description value
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        //If we have no description attribute, just return the ToString of the enum
        return value.ToString();
    }
}

public record Ast(Statement[] Statements) : IAstNode
{
    public override string ToString() => string.Join("\n", Statements);


    public IEnumerable<string> BuildSource() => Statements.SelectMany(x => x.BuildSource());
}

public class AstVisitor : LanguageBaseVisitor<object>
{
    public override object VisitStart(LanguageParser.StartContext context)
    {
        return new Ast(EnsureCollection(VisitChildren(context))
            .Cast<Statement>()
            .ToArray());
    }
    

    public override object VisitStatement(LanguageParser.StatementContext context)
    {
        var (statement, comment) = EnsureCollection(VisitChildren(context)) switch
        {
            [var sta] => (sta, null),
            [var sta, string c] => (sta, c),
            _ => throw new Exception($"Invalid statement: {context.GetText()}")
        };
        
        return statement switch
        {
            Assignment a => new Statement(a) { Comment = comment},
            If i => new Statement(i) { Comment = comment},
            While w => new Statement(w) { Comment = comment},
            
            var unsupportedStatement => throw new Exception($"Unsupported expression type: {unsupportedStatement}")
        };
    }

    public override object VisitComment(LanguageParser.CommentContext context)
    {
        return context.GetText();
    }

    public override object VisitAssignment(LanguageParser.AssignmentContext context)
    {
        if (VisitChildren(context) is IList and [Identifier id, Expression expr])
            return new Assignment(id, expr);
        
        // Not putting a Token in between parsers makes the Visitor printer easier
        if (VisitChildren(context) is Expression expr1)
            return new Assignment(new Identifier(context.IDENTIFIER().GetText()), expr1);
        
        throw new Exception($"Unsupported assignment: {context.GetText()}");
    }

    public override object VisitExpression(LanguageParser.ExpressionContext context)
    {
        return VisitChildren(context) switch
        {
            IList and [Expression left, ComparisonOperand c, Expression right] => 
                new Expression(new Expression.Comparison(c, left, right)),
            IList and [Expression left, BinaryOperand op, Expression right] =>
                new Expression(new Expression.BinaryOperation(op, left, right)),
            Literal l => new Expression(l),
            Identifier id => new Expression(id),
            var unsupportedExp => throw new Exception($"Unsupported expression type: {unsupportedExp}")
        };
    }
    
    public override object VisitIf(LanguageParser.IfContext context)
    {
        return context.children switch
        {
            [_, LanguageParser.ConditionContext cond, LanguageParser.DoBlockContext d, LanguageParser.EndContext] =>
                new If(
                    new Condition((Expression)VisitCondition(cond)),
                    EnsureCollection(VisitChildren(d)).Cast<Statement>().ToArray(),
                    []),
            [
                    _, LanguageParser.ConditionContext cond, LanguageParser.DoBlockContext d,
                    LanguageParser.ElseBlockContext el, LanguageParser.EndContext
                ] =>
                
                new If(
                    new Condition((Expression)VisitCondition(cond)),
                    EnsureCollection(VisitChildren(d)).Cast<Statement>().ToArray(),
                    EnsureCollection(VisitChildren(el)).Cast<Statement>().ToArray()),
            _ => throw new Exception($"Unsupported if: {context.GetText()}")
        };
    }

    public override object VisitWhile(LanguageParser.WhileContext context)
    {
        return context.children switch
        {
            [_, LanguageParser.ConditionContext cond, LanguageParser.DoBlockContext d, LanguageParser.EndContext] =>
                new While(
                    new Condition((Expression)VisitCondition(cond)),
                    EnsureCollection(VisitChildren(d)).Cast<Statement>().ToArray()),
            _ => throw new Exception($"Unsupported if: {context.GetText()}")
        };
    }

    public override object VisitLiteral(LanguageParser.LiteralContext context)
    {
        if (context.INT() is { } i)
            return new Literal(new Literal.Integer(i.GetText()));
        if (context.STRING() is { } s)
            return new Literal(new Literal.String(s.GetText()));
        if (context.CHAR() is { } c)
            return new Literal(new Literal.Char(c.GetText()));
        throw new Exception($"Invalid literal: {context}");
    }

    public override object VisitIdentifier(LanguageParser.IdentifierContext context)
    {
        return  new Identifier(context.GetText());    
    }

    public override object VisitComparison(LanguageParser.ComparisonContext context)
    {
        if (context.EQUALS() is not null) return ComparisonOperand.Equals;
        if (context.NOT_EQUALS() is not null) return ComparisonOperand.NotEquals;
        if (context.LESS_THAN() is not null) return ComparisonOperand.LessThan;
        if (context.GREATER_THAN() is not null) return ComparisonOperand.GreaterThan;
        if (context.LESS_THAN_OR_EQ() is not null) return ComparisonOperand.LessThanOrEquals;
        if (context.GREATER_THAN_OR_EQ() is not null) return ComparisonOperand.GreaterThanOrEquals;
        throw new Exception($"Invalid comparison operator: {context.GetText()}");
    }

    public override object VisitBinaryOperation(LanguageParser.BinaryOperationContext context)
    {
        if (context.ADD() is not null) return BinaryOperand.Add;
        if (context.SUBTRACT() is not null) return BinaryOperand.Subtract;
        if (context.MULTIPLY() is not null) return BinaryOperand.Multiply;
        if (context.DIVIDE() is not null) return BinaryOperand.Divide;
        if (context.MODULO() is not null) return BinaryOperand.Modulo;
        throw new Exception($"Invalid binary operator: {context.GetText()}");
    }

    protected override object AggregateResult(object? aggregate, object? nextResult)
    {
        if (nextResult is null)
            return aggregate!;

        if (aggregate is null)
            return nextResult;
        
        if (aggregate is ImmutableArray<object> ia)
            return ia.Add(nextResult);

        if (aggregate is IEnumerable ie)
            return ImmutableArray.Create<object>(ie).Add(nextResult);
        
        return ImmutableArray.Create(aggregate, nextResult);
    }

    private IList EnsureCollection(object content)
    {
        if (content is IList l)
            return l;
        if (content is IEnumerable ie)
            return ie.Cast<object>().ToList();
        return new object[] { content };
    }
}
