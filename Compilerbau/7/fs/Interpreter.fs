module fs.Interpreter

open System
open fs.Ast


exception InterpreterException of string * AstValue
exception InvalidValue of string * AstValue


// let rec fold1 op = function
//     | x::[] -> x
//     | x::xs -> op x (fold1 op xs)
//     | [] -> failwith "No data"

// Accumulate a list with the given function. The first element is used as the default element
let fold1 op =
    let rec fold1' acc = function
        | x::[] -> op acc x
        | x::xs -> fold1' (op acc x) xs
        | [] -> acc
    function
    | x::[] -> x
    | x::xs -> fold1' x xs
    | [] -> failwith "No data"


type Binop = Add | Sub | Mul | Div | Mod | Quotient | Remainder
let numericBinop op params' =
    let asInt = List.map unpackInt params'
    
    if List.length params' < 2 then raise <| NumArgs (2, params')
    
    match op with 
    | Add -> AInt ( fold1 (+) asInt )
    | Sub -> AInt ( fold1 (-) asInt )
    | Mul -> AInt ( fold1 (*) asInt )
    | Div -> AInt ( fold1  (/) asInt )
    | Mod -> AInt ( fold1 (%) asInt )
    | Quotient -> failwith "Quotient not implemented"
    | Remainder -> failwith "Remainder not implemented"
        

type BoolBinop = Eq | Neq | Lt | LtEq | Gt | GtEq
let boolBinop op args =
    match args with
    | AInt a::AInt b::[] ->
        match op with
        | Eq -> a = b
        | Neq -> a <> b
        | Lt -> a < b
        | LtEq -> a <= b
        | Gt -> a > b
        | GtEq -> a >= b
        |> ABool
    | AString a:: AString b::[] ->
        match op with
        | Eq -> a = b
        | Neq -> a <> b
        | Lt -> a < b
        | LtEq -> a <= b
        | Gt -> a > b
        | GtEq -> a >= b
        |> ABool
    | _ -> raise <| TypeMismatch ("Both arguments must be of type string or int", AList args) 

let strOp args =
    args
    |> List.map unpackString
    |> String.Concat
    |> AString


let primitives = [
    ("+", numericBinop Add)    
    ("-", numericBinop Sub)    
    ("*", numericBinop Mul)    
    ("/", numericBinop Div)    
    ("mod", numericBinop Mod)
    ("=", boolBinop Eq)
    ("/=", boolBinop Neq)
    (">", boolBinop Gt)
    (">=", boolBinop GtEq)
    ("<", boolBinop Lt)
    ("<=", boolBinop LtEq)
    ("str", strOp)
]

let primitiveBindings =
    let makePrimitiveFunc (var, func) =
        (var, APrimitiveFunc func)
    
    let primitives = List.map makePrimitiveFunc primitives
    primitives
    |> Variables.bindVars Variables.nullEnv



let rec eval env value =
    
    let makeFunc varargs env params' body = AFunc {
        Params=params' |> List.map showValue
        Vararg=varargs
        Body=body
        Closure=env
    }
    let makeNormalFunc = makeFunc None
    
    match value with
    | AInt _ -> value
    | AString _ -> value
    | ABool _ -> value
    | Atom a -> Variables.getVar env a
    | AList (Atom "list"::values) -> AList values
    | AList(Atom "def"::Atom name::value::[]) ->
        eval env value
        |> function
            | AFunc _ -> raise <| InvalidValue ("Can not define function with 'def'", value)
            | v -> Variables.defineVar env name v
    | AList(Atom "defn"::Atom name::AList params'::AList body::[]) ->
        makeNormalFunc env params' body
        |> Variables.defineVar env name
    | AList (Atom "print":: [ value ]) ->
        unpackString value 
        |> printfn "%s"
        value
    | AList(Atom "if"::condition::trueBody::[]) ->
        match eval env condition with
        | ABool true -> eval env trueBody
        | ABool false -> ABool false
        | _ -> raise <| TypeMismatch ("bool", condition)
    | AList(Atom "if"::condition::trueBody::falseBody::[]) ->
        match eval env condition with
        | ABool true -> eval env trueBody
        | ABool false -> eval env falseBody
        | _ -> raise <| TypeMismatch ("bool", condition)
    | AList(Atom "do"::body) ->
        List.map (eval env) body
        |> List.last
    | AList(Atom "let":: AList bindings::body::[]) ->
        let varValue = eval env 
        let rec vars acc = function
            | [] -> acc
            | Atom a::v::[] -> (a, varValue v)::acc
            | Atom a::v::xs -> vars ((a, varValue v)::acc) xs
            | x -> raise <| NumArgs (2, x)
        let letEnv = Variables.bindVars env (vars [] bindings)
        eval letEnv body 
            
    | AList (Atom func::args) ->
        let func = eval env (Atom func)
        let argsVals = List.map (eval env) args
        apply func argsVals
    | _ -> raise <| BadSpecialForm ("Unrecognised special form", value)
    
and apply func args =   
    match func with
    | APrimitiveFunc func -> func args
    | AFunc { Params = params'; Vararg = vargs; Body = body; Closure=closure } ->
        let evalBody env =
            List.map (eval env) body
            |> List.last
        
        if List.length params' <> List.length args && vargs = None
        then
            raise <| NumArgs (List.length params', args)
        else
            List.zip params' args // Note: for varargs support, zip must support unequal lengthen lists
            |> Variables.bindVars closure
            // |> bindVarArgs
            |> evalBody
        
        
    | _ -> raise <| InterpreterException ("Can not apply on", func)
    
    
    
let baseEnv = primitiveBindings