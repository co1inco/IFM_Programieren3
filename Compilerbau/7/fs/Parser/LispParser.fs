module Scheme.Parser.CustomParser

open System.IO
open fs.Ast
open fs
open fs.Lexer
open fs.LexerTokens


type CustomParser = {
    Stream : TokenStream
    Token : LexerToken
    Function: TokenStream -> TokenStream * LexerToken
}

let next parser =
    let (stream, token) = parser.Function parser.Stream
    { parser with Stream = stream; Token = token }


exception ParserException of CustomParser * string

let rec parseExpr ts =
    // let ts = next ts
       
    let parseToken =
        match ts.Token with
        // | LQuote ->
        //     let (ts', token) = next ts |> parseExpr
        //     (ts', AstValue.AList [LispVal.Atom("quote"); token])
        | LNumber n -> (next ts, AInt n)
        | LString s -> (next ts, AString s)
        | LAtom a ->
            match a with
            | "true" -> ABool true
            | "false" -> ABool false
            | s -> Atom s
            |> (fun a -> (next ts, a))
        | LLParen ->
            let (ts', token) = parseList ts
            (ts', token)
        | _ -> raise <| ParserException (ts, "Unexpected token. Expected expression")
        
    parseToken
        
and parseList ts =
    let rec parseList' ts acc =
        // let ts' = next ts
        let ts' = ts
        match ts'.Token with
        | LRParen -> (ts', acc)
        | _ ->
            let (ts, expr) = parseExpr ts'
            parseList' ts (expr::acc) 

    let (ts', list) = parseList' (next ts) []
    list
    |> Seq.rev
    |> Seq.toList
    |> AList
    |> (fun x -> (next ts', x))
    
    
let stringStream (input : string) =
    let ms = new MemoryStream()
    let sw = new StreamWriter(ms)
        
    sw.Write input
    sw.Flush()
    ms.Position <- 0
    new StreamReader(ms)
    

let readInput parser input =
    let lexer =
        stringStream input
        |> Lexer.createTokenStream
    let parserState =
        let (ts, token) = Lexer.next lexer
        { CustomParser.Stream = ts
          Function = Lexer.next
          Token = token }
    let (_, output) = parser parserState
    output

let readExpr' ts=
    let (ts, token) = parseExpr ts
    match ts.Token with
    | LEof -> (ts, token)
    | _ -> raise <| ParserException (ts, "Expected EOF")

let readExprList' ts =
    let rec lexAll' ts acc =
        let ts' = next ts
        match ts'.Token with
        | LEof -> acc
        | x -> lexAll' ts' (x::acc)
       
    lexAll' ts []
    |> List.rev
    |> (fun x -> (ts, x)) // does not return the advanced tokenStream
    

let rec readExpr input = readInput readExpr' input

let rec readExprList input = readInput readExprList' input 


    