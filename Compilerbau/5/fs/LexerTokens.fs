module fs.LexerTokens

    type LexerToken =
        | LEof
        | LSpace
        | LLParen
        | LRParen
        | LString of string
        | LAtom of string
        | LNumber of int
        // | LSymbol of char
        // | LDigit of char
        // | LLetter of char
        | LQuote
        | LComment of string
    
    