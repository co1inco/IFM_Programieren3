module fs.EnvironmentBase

type EnvironmentBase<'T>(parent : Option<EnvironmentBase<'T>> ) =
    let parent =  parent
    let symbols = System.Collections.Generic.Dictionary<string, 'T>()
       
    member this.isBound(name : string) =
        if symbols.ContainsKey name
        then true
        else
            match parent with
            | Some p -> p.isBound name
            | _ -> false
    
    member this.tryGetVar(name : string) =
        match symbols.TryGetValue name with
        | true, v -> Some(v)
        | false, _ ->
            match parent with
            | Some p -> p.tryGetVar name
            | _ -> None
            
    member this.trySetVar (name: string) (value : 'T) =
        if symbols.ContainsKey name
        then
            symbols.Item(name) <- value
            true
        else
            match parent with
            | Some p -> p.trySetVar name value
            | _ -> false
            
    member this.tryBindVar (name: string) (value : 'T) =
        symbols.Item(name) <- value
        true