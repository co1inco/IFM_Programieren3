using System.Text;

namespace cs;

public class LexerException : Exception
{
    public int Line { get; }
    public int Column { get; }

    public LexerException(string message, int line, int column) : base(message)
    {
        Line = line;
        Column = column;
    }

    public override string ToString() => $"{Message} at {Line}:{Column}";
}


public class Lexer(StreamReader tokenStream)
{
    private long _currentPosition = 0;
    private int _peek;

    private int _line = 1;
    private int _column = 0;
    
    public Token NextToken()
    {
        while (_peek != -1)
        {
            var peekChar = (char)_peek;

            // Skip the (first) \0
            if (_peek == 0)
            {
                Consume();
                return NextToken();
            }
            
            if (peekChar is ' ' or '\t' or '\n' or '\r' or '\f' or '\0')
            {
                Consume();
                return new Token.Space(peekChar);
            }
            if (peekChar is '(')
            {
                Consume();
                return new Token.LParen();
            }
            if (peekChar is ')')
            {
                Consume();
                return new Token.RParen();
            }

            if (peekChar is '"')
            {
                return String();
            }

            if ("!#$%&|*+-/:<=>?@^_~".Contains(peekChar))
            {
                Consume();
                return new Token.Symbol(peekChar);
            }

            if (peekChar is >= 'A' and <= 'Z' or >= 'a' and <= 'z')
            {
                Consume();
                return new Token.Letter(peekChar);
            }
            
            if (peekChar is >= '0' and <= '9')
            {
                Consume();
                return new Token.Digit(peekChar);
            }
            
            if (peekChar is '\'')
            {
                Consume();
                return new Token.Quote(peekChar);
            }

            if (peekChar is ';')
            {
                return Comment();
            }

            if (peekChar is '.')
            {
                Consume();
                return new Token.Dot();
            }
            
            throw LexerException($"Unexpected character '{peekChar}'");
        }

        return new Token.EOF();
    }

    public Token.String String()
    {
        Consume(); // Consume the opening "
        
        StringBuilder builder = new();

        bool escape = false;
        while (_peek != '"' || escape)
        {
            var peekChar = (char)_peek;
            
            if (_peek is -1)
                throw LexerException("Unexpected EOF. expected closing \"");
            
            Consume();
            
            if (peekChar is '\\' && !escape)
            {
                escape = true;
                continue;
            }

            if (escape)
            {
                builder.Append(peekChar switch
                {
                    '\\' => '\\',
                    't' => '\t',
                    'r' => '\r',
                    'n' => '\r',
                    'b' => '\b',
                    'f' => '\f',
                    'e' => '\e',
                    '"' => '"',
                    var e => throw LexerException($"Invalid escape character '{e}'")
                });
                escape = false;
                continue;
            }

            builder.Append(peekChar);
        }
        Consume(); // Consume the closing "

        return new Token.String(builder.ToString());
    }
    
    public Token.Comment Comment()
    {
        Consume();
        
        if (_peek is not ';')
            throw LexerException("Unexpected Token. Expected ';'");
        
        Consume();

        StringBuilder builder = new();
        while (_peek is not -1 or '\n' or '\r')
        {
            builder.Append((char)_peek);
            Consume();
        }

        if (_peek is '\n') // skip newline after \r  
            Consume();
        
        return new Token.Comment(builder.ToString());
    }
    
    
    void Consume()
    {
        _peek = tokenStream.Read();
        _currentPosition = tokenStream.BaseStream.Position;

        if (_peek == '\n')
        {
            _line++;
            _column = 0;
        }
        else
        {
            _column++;
        }
    }

    private Exception LexerException(string message) => new LexerException(message, _line, _column);
    
    void RollBack()
    {
        
    }
}