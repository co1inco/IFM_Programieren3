using OneOf;

namespace cs;


public record PrimType(string Name)
{
    public static readonly PrimType INT = new("int");
    public static readonly  PrimType STRING = new("string");
    public static readonly PrimType BOOL = new("bool");
};

public record VarDecl(PrimType Type, string Name, Expr Initializer);

public record Assign(string Name, Expr Value);

public record FnDecl(PrimType ReturnType, string Name, Param[] Params, Block Body);

public record ReturnStmt(Expr Value);

public record Block(Stmt[] Statements);

public record WhileStmt(Expr Condition, Block Body);

public record IfStmt(Expr Condition, Block Then, Block Else);

public record Param(PrimType Type, string Name);

[GenerateOneOf]
public partial class Stmt : OneOfBase<
    VarDecl,
    Assign,
    FnDecl,
    ReturnStmt, 
    Expr,
    Block,
    WhileStmt,
    IfStmt
>
{
    
}

[GenerateOneOf]
public partial class Expr : OneOfBase<
    Expr.Literal<int>,
    Expr.Literal<string>,
    Expr.Literal<bool>,
    Expr.Variable,
    Expr.Binop,
    Expr.Call
>
{
    public record struct Literal<T>(T Value);
    
    public record struct Variable(string Name);
    
    public record Binop(Operator Operation, Expr Left, Expr Right);

    public record Call(string Name, Expr[] Arguments);
}


[GenerateOneOf]
public sealed partial class Operator : OneOfBase<
    Operator.Equal,
    Operator.NotEqual,
    Operator.Plus,
    Operator.Minus,
    Operator.Multiply,
    Operator.Divide,
    Operator.LessThan,
    Operator.LessThanEqual,
    Operator.GreaterThan,
    Operator.GreaterThanEqual
>
{
    public record struct Equal();
    public record struct NotEqual();
    public record struct Plus();
    public record struct Minus();
    public record struct Multiply();
    public record struct Divide();
    public record struct LessThan();
    public record struct LessThanEqual();
    public record struct GreaterThan();
    public record struct GreaterThanEqual();
}


public class Ast
{
    
}