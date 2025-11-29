module fs.Lexer

open System
open System.IO
open fs.LexerTokens

    type TokenStreamState = { Stream : StreamReader; Line : int; Column : int; Token : int; }
    
    type TokenStream = { State: TokenStreamState; Function : TokenStreamState -> TokenStreamState }
    
    let consumeToken (ts : TokenStreamState) : TokenStreamState =
        let token = ts.Stream.Read()
        let line c = if ((char)c) = '\n' then ts.Line + 1 else ts.Line
        let column c = if ((char)c) = '\n' then 0 else ts.Column + 1
        let build c = { TokenStreamState.Stream = ts.Stream; Token = c; Line = line c; Column = column c; }
        build token
    
    let consume (ts : TokenStream) : TokenStream =
        { ts with State = ts.Function ts.State }
    
    let createTokenStream sr =
        { TokenStream.State = { TokenStreamState.Stream = sr; Line = 1; Column = 1; Token = sr.Read() }
        ; TokenStream.Function = consumeToken
        }
    
    
    exception LexerException of TokenStreamState * string
    
    let showLexerError =
        function
        | LexerException (ts, msg) -> sprintf "%s at %i:%i" msg ts.Line ts.Column
        | error -> raise error
             
    
    let nextTokens (ts : TokenStream) validChar =    
        let rec atomList ts acc =
            if validChar ((char)ts.State.Token)
            then atomList (consume ts) (((char)ts.State.Token)::acc)
            else (ts, acc)
        
        let (ts', rawAtom) = atomList ts []
        rawAtom
        |> Seq.rev
        |> (fun s -> (ts', s))
    
    
    let separators = System.Collections.Generic.HashSet<char>(" \t\r\n()")
    let isSeparator c = c = -1 || separators.Contains ((char)c)  
    
    let followedBySeparator (ts : TokenStream * LexerToken) : TokenStream * LexerToken =
           let token = (fst ts).State.Token
           if isSeparator token
           then ts
           else raise <| LexerException ((fst ts).State, $"Expected separator but got '{token |> char}'")
    
    
    let nextString (ts : TokenStream) =
        let rec stringList (ts : TokenStream) (acc : list<char>) : (TokenStream * list<char>) =
            if ts.State.Token = -1
            then raise <| LexerException (ts.State, "Unexpected EOF. Expected closing \"")
            else
                match (char)ts.State.Token with
                | '"' -> (consume ts, acc)
                | c -> stringList (consume ts) (c::acc)
        
        let makeString (ts', l) =
            List.rev l
            |> List.map string
            |> String.concat ""
            |> (fun s -> (ts', LString(s)))
            
        stringList (consume ts) [] |> makeString
       
    let nextAtom (ts : TokenStream) : (TokenStream * LexerToken) =
        let symbols = System.Collections.Generic.HashSet<char>("!#$%&|*+-/:<=>?@^_~")
        let validAtomChar c = (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || symbols.Contains(c)
        
        let (ts', rawAtom) = nextTokens ts validAtomChar
        rawAtom
        |> Seq.map string
        |> String.concat ""
        |> (fun s -> (ts', LAtom(s)))
        
       
    let nextNumber (ts : TokenStream) : (TokenStream * LexerToken) =
        let validAtomChar c = (c >= '0' && c <= '9')
        
        let (ts', rawAtom) = nextTokens ts validAtomChar
        rawAtom
        |> Seq.map string
        |> String.concat ""
        |> Int32.Parse
        |> (fun i -> (ts', LNumber(i)))
    
            
        
    let rec next (ts : TokenStream) =        
        if ts.State.Token = -1
        then (ts, LEof)
        else
            match ((char)ts.State.Token) with
            | '\000' -> next (consume ts)
            | ' ' | '\n' | '\r' | '\t' | '\f' -> next (consume ts)
            | '(' -> (consume ts, LLParen)
            | ')' -> (consume ts, LRParen)
            | ''' -> (consume ts, LQuote) 
            // | '"' -> nextString ts |> (fun (ts', token) -> next ts' (token::acc)) 
            | '"' -> nextString ts |> followedBySeparator
            | c when c >= 'a' && c <= 'z' -> nextAtom ts |> followedBySeparator
            | c when c >= 'A' && c <= 'Z' -> nextAtom ts |> followedBySeparator
            | '!' | '#' | '$' | '%' | '&' | '|' | '*'
            | '+' | '-' | '/' | ':' | '<' | '=' | '>'
            | '?' | '@' | '^' | '_' | '~' -> nextAtom ts |> followedBySeparator
            | c when c >= '0' && c <= '9' -> nextNumber ts |> followedBySeparator
            | c -> raise <| LexerException (ts.State, $"Unexpected token: {c}")
            // | c -> nextChar ((char)c) 
           
