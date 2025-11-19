module fs.Lexer

open System
open System.IO
open fs.LexerTokens

    type TokenStream = { Stream : StreamReader; Line : int; Column : int; Token : int; }
    
    let tokenStream sr =
        { TokenStream.Stream = sr; Line = 1; Column = 1; Token = sr.Read() }
    
    let consume (ts : TokenStream) : TokenStream =
        let token = ts.Stream.Read()
        let line c = if ((char)c) = '\n' then ts.Line + 1 else ts.Line
        let column c = if ((char)c) = '\n' then 0 else ts.Column + 1
        let build c = { TokenStream.Stream = ts.Stream; Token = c; Line = line c; Column = column c; }
        build token
    
    let nextString (ts : TokenStream) =
        let rec stringList ts (acc : list<char>) : (TokenStream * list<char>) =
            if ts.Token = -1
            then raise <| Exception "Unexpected EOF. Expected closing \""
            else
                match (char)ts.Token with
                | '"' -> (consume ts, [])
                | c -> stringList (consume ts) (c::acc)
        
        let makeString (ts', l : list<char>) : (TokenStream * LexerToken) =
            List.rev l
            |> List.map string
            |> String.concat ""
            |> (fun s -> (ts', LString(s)))
            
        stringList (consume ts) [] |> makeString
        
        
    let rec next (ts : TokenStream) acc : seq<LexerToken> =        
        if ts.Token = -1
        then [LEof]
        else
            match ((char)ts.Token) with
            | '\000' -> next (consume ts) acc
            | ' ' -> next (consume ts)(LSpace::acc)
            | '\n' -> next (consume ts) (LSpace::acc)
            | '\r' -> next (consume ts) (LSpace::acc)
            | '\t' -> next (consume ts) (LSpace::acc)
            | '\f' -> next (consume ts) (LSpace::acc)
            | '(' -> next (consume ts) (LLParen::acc)
            | ')' -> next (consume ts) (LRParen::acc)
            // | '"' -> nextString ts |> (fun (ts', token) -> next ts' (token::acc)) 
            | '"' ->
                let (ts', token) = nextString ts
                next ts' (token::acc) 
            | c -> raise <| Exception($"Unexpected token: {c}")
            // | c -> nextChar ((char)c) 
           
