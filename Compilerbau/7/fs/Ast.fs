module fs.Ast

type AstValue =
    | Atom of string
    | AString of string
    | AInt of int
    | ABool of bool
    | AList of List<AstValue>
    | AFunc of Func
    | APrimitiveFunc of (List<AstValue> -> AstValue)
and Func = {Params : List<string>; Vararg: Option<string>; Body: List<AstValue>; Closure: Environment }
// and Environment = System.Collections.Generic.Dictionary<string, AstValue>
and Environment = System.Collections.Generic.Dictionary<string, LispValClass>
// class (reference type) this way, a value in an outer scope can be overwritten from an inner scope
// this should also be possible by simply using nested scopes / environments
and LispValClass(value: AstValue) = 
    let mutable v = value
    member this.V 
        with get () = v
        and set (value) = v <- value


exception UnboundVar of string * string
exception NumArgs of int * List<AstValue>
exception IndexOutOfBounds of int
exception TypeMissmatch of string * AstValue
exception BadSpecialForm of string * AstValue
exception NotFunction of string * string
exception DefaultException of string
exception ParserException' of string
exception ValueIsNotFunction of AstValue


let unpackString = function
    | AString s -> s
    | AInt i -> $"{i}"
    | ABool b -> $"{b}"
    | notString -> raise <| TypeMissmatch ("string", notString)

let rec unpackInt = function 
    | AInt i -> i
    | AString s ->
        match TryParser.parseInt s with
        | Some n -> n
        | None -> 1
    | ABool b ->
        match b with
        | true -> 1
        | false -> 0
    | AList [v] -> unpackInt v
    | x -> raise <| TypeMissmatch ("number", x)

let rec showValue = function
    | AString s -> $"\"{s}\""
    | AInt i -> $"{i}"
    | ABool b -> $"{b}"
    | Atom a -> a
    | AList l -> l |> List.map showValue |> String.concat " " |> sprintf "(%s)"
    | APrimitiveFunc _ -> "<primitive>"
    | AFunc {Params=args; Vararg=varargs; Body=body; Closure=env} ->
        let argsString = String.concat " " args
        let varargString = 
            match varargs with
            | Some arg -> " . " + arg
            | _ -> ""
        sprintf "(lambda (%s) %s) ...)" argsString varargString


