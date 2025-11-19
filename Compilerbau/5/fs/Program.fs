// For more information see https://aka.ms/fsharp-console-apps
open System.IO
open fs
open fs.Lexer
open fs.LexerTokens

printfn "Hello from F#"

// let stream = StreamReader argv


let tokenStream file= Lexer.createTokenStream (StreamReader(File.OpenRead(file))) 


let lexAll ts next =
    let rec lexAll' ts acc =
        let (ts', token) = next ts
        match token with
        | LEof -> acc
        | x -> lexAll' ts' (x::acc)
       
    lexAll' ts [] |> List.rev

let runLexer (argv : string[]) =
    try
        $"{lexAll (tokenStream argv.[0]) next}"
    with
    | error -> showLexerError error

[<EntryPoint>]
let main argv =
    match Array.length argv with
    | 0 -> printfn "Expecting 1 argument"
    | 1 -> printfn $"Lexer: {runLexer argv}" 
    | _ -> printfn "Expecting 0 or 1 argument"
    
    0