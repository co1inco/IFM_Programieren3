module TryParser
    // convenient, functional TryParse wrappers returning option<'a>
    let tryParseWith (tryParseFunc: string -> bool * _) = tryParseFunc >> function
        | true, v    -> Some v
        | false, _   -> None

    let parseInt    = tryParseWith System.Int32.TryParse
    let parseFloat  = tryParseWith System.Double.TryParse
    let parseDouble  = tryParseWith System.Double.TryParse


    let (|Int|_|)    = parseInt
    let (|Double|_|)    = parseFloat