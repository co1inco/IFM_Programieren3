module fs.Variables

open System.Linq
open fs.Ast

let nullEnv = new Environment(None)

let isBound (envRef : Environment) (var : string) =
    envRef.isBound

let getVar (envRef : Environment) var =
    match envRef.tryGetVar var with
    | Some v -> v
    | _ -> raise <| UnboundVar ("Getting an unbound variable", var)

let setVar (envRef : Environment) (var : string) (value : AstValue) =
    match envRef.trySetVar var value with
    | true -> value
    | _ -> raise <| UnboundVar ("Setting an unbound variable", var)
    
let defineVar (envRef : Environment) var (value : AstValue) =
    envRef.tryBindVar var value |> ignore
    value

let bindVars (envRef : Environment) (bindings : List<(string * AstValue)>) : Environment =
    let rec adder binding env =
        match binding with
        | (var, value)::xs ->
            defineVar env var value |> ignore
            adder xs env
        | [] -> env

    new Environment(Some(envRef))
    |> adder bindings
    //envRef |> adder bindings