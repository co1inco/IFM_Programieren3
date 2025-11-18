namespace cs;

public class PrettyPrint
{
    private readonly TextWriter _sw;
    private int depth = 0;
    
    private PrettyPrint(TextWriter sw)
    {
        _sw = sw;
    }
    
    public static void Write(TextWriter sw, PProgram program)
    {
        new PrettyPrint(sw).Write(program);
    }


    public void Write(PProgram program)
    {
        foreach (var expr in program.Expressions)
        {
            Write(expr);
            _sw.WriteLine();
        }
    }

    public void Write(PExpr expr)
    {
        expr.Switch(
            Write,
            Write,
            Write,
            Write,
            Write,
            Write
        );
    }

    public void Write(PNumber n)
    {
        _sw.Write(n.Value);
    }

    public void Write(PBool b)
    {
        _sw.Write(b.Value ? "true" : "false");
    }

    public void Write(PString s)
    {
        // TODO: add escape characters
        _sw.Write($"\"{s.Value}\"");
    }

    public void Write(PAtom a)
    {
        _sw.Write(a.Name);
    }

    public void Write(PDottedList d)
    {
        _sw.Write("(");

        var first = true;
        foreach (var expr in d.Expressions)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                _sw.Write(" ");
            }
            
            Write(expr);
        }
        _sw.Write(" . ");
        
        Write(d.Expression);
        
        _sw.Write(")");
    }

    public void Write(PList l)
    {
        _sw.Write("(");

        var first = true;
        foreach (var expr in l.Expressions)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                _sw.Write(" ");
            }
            
            Write(expr);
        }
        _sw.Write(")");
    }
}