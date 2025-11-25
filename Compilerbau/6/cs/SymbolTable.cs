using System.Security.Cryptography;
using OneOf;

namespace cs;

public record SymbolTable<T>(
    Scope<T> Current, 
    T Ast,
    SymbolTable<T>[] ChildScopes
);

public class SymbolException : Exception
{
    public SymbolException(object ast, string message) : base(message) { }
}

[GenerateOneOf]
public partial class Symbol : OneOfBase<
    Stmt[],
    VarDecl,
    FnDecl,
    // Expr,
    PrimType,
    Expr.Call
> {}


public static class SymbolTable
{
    public static Scope<T> CreateScope<T>(Scope<T>? parent) =>
        parent is not null ? new(parent) : new();
    
    public static SymbolTable<Symbol> GenerateScope(Stmt[] statements, Scope<Symbol>? parent) => 
        GenerateScopeWith(statements, CreateScope(parent));
    
    public static SymbolTable<Symbol> GenerateScopeWith(Stmt[] statements, Scope<Symbol> scope)
    {
        // This function does not generate its own scope
        List<SymbolTable<Symbol>> childScopes = [];

        foreach (var statement in statements)
        {
            statement.Switch(
                varDecl =>
                {
                    if (!scope.TryAddSymbol(varDecl.Name, varDecl))
                        throw new SymbolException(varDecl, $"Variable '{varDecl.Name}' already exists");
                },
                assign =>
                {
                    if (!scope.HasSymbolLocal(assign.Name))
                        throw new SymbolException(assign, $"Variable '{assign.Name}' does not exist");
                },
                fnDecl =>
                {
                    if (!scope.TryAddSymbol(fnDecl.Name, fnDecl))
                        throw new SymbolException(fnDecl, $"Function '{fnDecl.Name}' already exists");
                    
                    childScopes.Add(GenerateFnScope(fnDecl, scope));
                },
                ret =>
                {
                    if (CheckExpression(ret.Value, scope) is { } s)
                        childScopes.Add(s);
                },
                expr =>
                {
                    if (CheckExpression(expr, scope) is { } s)
                        childScopes.Add(s);
                },
                block =>
                {
                    childScopes.Add(GenerateScope(block.Statements, scope));
                },
                @while =>
                {
                    if (CheckExpression(@while.Condition, scope) is { } s)
                        childScopes.Add(s);
                    childScopes.Add(GenerateScope(@while.Body.Statements, scope));
                },
                @if =>
                {
                    if (CheckExpression(@if.Condition, scope) is { } s)
                        childScopes.Add(s);
                    childScopes.Add(GenerateScope(@if.Then.Statements, scope));
                    childScopes.Add(GenerateScope(@if.Else.Statements, scope));
                }
            );
        }
        
        return new SymbolTable<Symbol>(scope, new Symbol(statements), childScopes.ToArray());
    }

    public static SymbolTable<Symbol> GenerateFnScope(FnDecl fnDecl, Scope<Symbol> parent)
    {
        var scope = CreateScope(parent);

        foreach (var param in fnDecl.Params)
        {
            scope.TryAddSymbol(param.Name, param.Type);
        }
        
        return GenerateScopeWith(fnDecl.Body.Statements, scope) with { Ast = fnDecl};
    }
    
    public static SymbolTable<Symbol>? CheckExpression(Expr expr, Scope<Symbol> parent)
    {
        if (expr.TryPickT5(out var call, out var rem))
        {
            // TODO: This should be checked in a second pass
            // if (!parent.HasSymbol(call.Name))
            //     throw new SymbolException(call, $"Function '{call.Name}' does not exist");
            // foreach (var arguments in call.Arguments)
            // {
            //     CheckExpression(arguments, parent);
            // }   
            return new SymbolTable<Symbol>(parent, call, []);
        }
        
        rem.Switch(
            i => {},
            s => {},
            b => {},
            var =>
            {
                if (!parent.HasSymbol(var.Name))
                    throw new SymbolException(var, $"Variable '{var.Name}' does not exist");  
            },
            binop =>
            {
                CheckExpression(binop.Left, parent);
                CheckExpression(binop.Right, parent);
            });

        return null;
    }
}