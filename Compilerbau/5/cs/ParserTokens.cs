using OneOf;

namespace cs;

public record PProgram(PExpr[] Expressions)
{
    public override string ToString() => $"Program: {string.Join("\n", Expressions)}";
};

public record PString(string Value);
public record PNumber(int Value);
public record PBool(bool Value);

public record PComment(string Value);

public record PAtom(string Name);

public record PList(PExpr[] Expressions)
{
    public override string ToString() => $"{nameof(PList)} {{{string.Join(", ", Expressions)}}}";
};


public record PDottedList(PExpr[] Expressions, PExpr Expression)
{
    public override string ToString() => $"{nameof(PDottedList)} {{{string.Join(", ", Expressions)}; {Expression}}}";
}


[GenerateOneOf]
public partial class PExpr : OneOfBase<PNumber, PBool, PString, PAtom, PList, PDottedList>
{
    public PComment? Comment { get; set; }

    public override string ToString() => 
        $"Expression: {Value}{(Comment is not null ? $", Comment: '{Comment.Value}'" : "")}";
}