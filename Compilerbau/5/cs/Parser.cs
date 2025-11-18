using System.Linq.Expressions;
using System.Text;

namespace cs;

public class ParserException : Exception
{
    public Token Token { get; }

    public ParserException(string message, Token token) : base(message)
    {
        Token = token;
    }

    public override string ToString() => $"{Message}, Token: {Token}";
}

public class Parser
{
    private readonly Lexer _lexer;
    private Token? _previous;
    private Token _lookahead;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _lookahead = lexer.NextToken();
    }
    
    public PProgram Program()
    {
        Spaces();
        
        if (_lookahead is Token.EOF) // empty program
            return new PProgram([]);
        
        List<PExpr> expressions = [];
        
        expressions.Add(Expression());

        while (_lookahead is not Token.EOF)
        {
            Spaces1();

            if (_lookahead is Token.EOF)
                break;
            
            expressions.Add(Expression());
        }
        
        Spaces();
        
        return new PProgram(expressions.ToArray());
    }

    public PString String()
    {
        if (_lookahead is not Token.String s)
            throw ParserException("Expected string token");

        Next();
        return new PString(s.Value);
    }

    public PNumber Number()
    {
        if (_lookahead is not Token.Digit)
            throw ParserException("Expected digit");

        StringBuilder builder = new();
        while (_lookahead is Token.Digit d)
        {
            builder.Append(d.Value);
            Next();
        }
        
        return new PNumber(int.Parse(builder.ToString()));
    }

    // public PBool Bool()
    // {
    //     throw new NotImplementedException();
    //     
    // }

    public PComment Comment()
    {
        if (_lookahead is not Token.Comment c)
            throw ParserException("Expected comment token");
        
        Next();
        return new PComment(c.Value);
    }

    public PAtom Atom()
    {
        StringBuilder builder = new();

        builder.Append(_lookahead switch
        {
            Token.Letter l => l.Value,
            Token.Symbol s => s.Value,
            _ => throw ParserException("Expected letter or symbol")
        });
        
        Next();
        
        while (_lookahead is Token.Letter or Token.Symbol or Token.Digit)
        {
            builder.Append(_lookahead switch
            {
                Token.Letter l => l.Value,
                Token.Symbol s => s.Value,
                Token.Digit d => d.Value,
                _ => throw ParserException("Expected letter, symbol or digit")
            });
            
            Next();
        } 
        
        return new PAtom(builder.ToString());
        
    }

    public PList List()
    {
        if (_lookahead is not Token.LParen)
            throw ParserException("Expected parenthesis");
        Next();
        
        Spaces();

        // Empty list
        if (_lookahead is Token.RParen)
        {
            Next();
            return new PList([]);
        }

        List<PExpr> expressions = [];

        expressions.Add(Expression());

        while (_lookahead is not Token.RParen)
        {
            Spaces1();

            if (_lookahead is Token.RParen)
                break;
            
            expressions.Add(Expression());
        }
        
        Next(); // Consume RParen
        
        return new PList(expressions.ToArray());
    }

    public PExpr ListOrDottedList()
    {
        if (_lookahead is not Token.LParen)
            throw ParserException("Expected parenthesis");
        Next();
        
        Spaces();

        // Empty list
        if (_lookahead is Token.RParen)
        {
            Next();
            return new PList([]);
        }

        List<PExpr> expressions = [];

        expressions.Add(Expression());

        while (_lookahead is not Token.RParen)
        {
            Spaces1();

            // A dotted list is expected to have on expression after the .
            if (_lookahead is Token.Dot)
            {
                Next();
                Spaces1();

                var expr = Expression();

                if (_lookahead is not Token.RParen)
                    throw ParserException("Expected closing )");
                Next();
                return new PDottedList(expressions.ToArray(), expr);
            }
            
            if (_lookahead is Token.RParen)
                break;
            
            expressions.Add(Expression());
        }
        
        Next(); // Consume RParen
        
        return new PList(expressions.ToArray());
    }
    
    public PList Quote()
    {
        if (_lookahead is not Token.Quote)
            throw ParserException("Expected quote token");
        Next();

        return new PList([
            new PAtom("quote"),
            Expression()
        ]);
    }

    public PExpr Expression()
    {
        PExpr p = _lookahead switch
        {
            Token.Digit => Number(),
            Token.String => String(),
            Token.Letter or Token.Symbol => Atom() switch
            {
                // Instead of doing some actual lookahead, just parse an atom and check if it has a special value  
                { Name: "true"} => new PBool(true),
                { Name: "false"} => new PBool(false),
                var a => a
            },
            Token.Quote => Quote(),
            Token.LParen => ListOrDottedList(),
            _ => throw ParserException("Expected expression")
        };
        
        Spaces();

        if (_lookahead is Token.Comment)
            p.Comment = Comment();

        return p;
    }

    
    public void Spaces()
    {
        while (_lookahead is Token.Space space)
        {
            Next();
        }
    }

    public void Spaces1(bool acceptPrevious = true)
    {
        if (acceptPrevious && _previous is Token.Space)
        {
            
        }
        else
        {
            if (_lookahead is not Token.Space s)
                throw ParserException("Expected at least 1 space");    
        }
        

        while (_lookahead is Token.Space space)
        {
            Next();
        }
    }
    
    
    private Exception ParserException(string message)
    {
        return new ParserException(message, _lookahead);
    }
    
    private void Next()
    {
        _previous = _lookahead;
        _lookahead = _lexer.NextToken();
    }
}
