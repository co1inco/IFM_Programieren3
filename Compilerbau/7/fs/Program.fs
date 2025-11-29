// For more information see https://aka.ms/fsharp-console-apps
open System
open System.Collections.Generic
open Scheme.Parser
open fs
open fs.Ast

printfn "Hello from F#"

let evalString env input =
    try 
        CustomParser.readExpr input
        |> Interpreter.eval env
        |> showValue
        |> sprintf "%s"
    with
    | error -> error |> sprintf "%A"

let evalAndPrint env input =
    printfn "%s" <| evalString env input

let rec mainloop() env=
    Console.Write "Lisp>> "
    let line = Console.ReadLine()
    
    if line <> "quit"
    then
        evalAndPrint env line
        mainloop() env

mainloop() Interpreter.baseEnv
