using OneOf;

namespace cs;

public record Token
{
    private Token() { }
    
    public record EOF() : Token();

    public record Space(char Value) : Token();

    public record LParen() : Token();

    public record RParen() : Token();

    public record String(string Value) : Token();

    public record Symbol(char Value) : Token();

    public record Letter(char Value) : Token();

    public record Digit(char Value) : Token();

    public record Quote(char Value) : Token();

    public record Comment(string Value) : Token();

    public record Dot() : Token();
}