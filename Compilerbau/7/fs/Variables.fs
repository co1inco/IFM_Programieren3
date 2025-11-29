module fs.Variables

open System.Linq
open fs.Ast

let nullEnv = new Environment()

let isBound (envRef : Environment) (var : string) =
    envRef.Keys
    |> Seq.exists (fun x -> x = var)

let getVar (envRef : Environment) var =
    if isBound envRef var 
    then
        // envRef.Item(var)
        envRef.Item(var).V
    else
        raise <| UnboundVar ("Getting an unbound variable", var)

let setVar (envRef : Environment) (var : string) (value : AstValue) =
    if isBound envRef var then
        // envRef.Item(var) <- value 
        envRef.Item(var).V <- value 
        value
    else
        raise <| UnboundVar ("Setting an unbound variable", var)

let defineVar (envRef : Environment) var (value : AstValue) =
    envRef.Item(var) <- new LispValClass(value)
    value
    // if isBound envRef var 
    // then 
    //     setVar envRef var value
    // else
    //     // envRef.Item(var) <- value
    //     envRef.Item(var) <- new LispValClass(value)
    //     value

let bindVars (envRef : Environment) (bindings : List<(string * AstValue)>) : Environment =
    let rec adder binding env =
        match binding with
        | (var, value)::xs ->
            defineVar env var value |> ignore
            adder xs env
        | [] -> env

    new Environment(envRef)
    |> adder bindings
    //envRef |> adder bindings