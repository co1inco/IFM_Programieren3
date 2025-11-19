// For more information see https://aka.ms/fsharp-console-apps
open System.IO
open fs

printfn "Hello from F#"

// let stream = StreamReader argv


let ts file= Lexer.tokenStream (StreamReader(File.OpenRead(file))) 

[<EntryPoint>]
let main argv =
    match Array.length argv with
    | 0 -> printfn "Expecting 1 argument"
    | 1 -> printfn $"Lexer: {(Lexer.next (ts argv.[0]) [])}" 
    | _ -> printfn "Expecting 0 or 1 argument"
    
    0