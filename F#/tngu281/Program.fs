open System
open System.IO
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv = 
    try 
        let mutable k : int = 3
        if argv.Length = 2 then 
            if not(Regex.IsMatch(argv.[1], @"^\+?([0-9]\d*)$")) then 
                failwith(sprintf "%s is not a valid number" argv.[1])
            k <- int argv.[1]
        else 
            if argv.Length <> 1 then failwith "wrong number of arguments"
        File.ReadAllText(argv.[0]).ToUpper()
        |> (fun (x : String) -> Regex.Matches(x, @"[A-Z]+"))
        |> Seq.cast
        |> Seq.map(fun (x : Match) -> x.Value)
        |> Seq.countBy id
        |> Seq.sortBy(fun (x, y) -> (-y, x))
        |> Seq.truncate(k)
        |> Seq.iter(fun (x : String, y : int) -> printfn "%s %i" x y)
    with ex -> printfn "*** Error: %s" ex.Message
    0