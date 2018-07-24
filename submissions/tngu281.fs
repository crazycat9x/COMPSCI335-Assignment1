open System
open System.IO
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv =
    try
        if argv.Length <> 2 then failwith "wrong number of arguments"
        if not (Regex.IsMatch(argv.[1], @"^\+?(0|[1-9]\d*)$")) then failwith "k is not a valid number"
        if not (Regex.IsMatch(argv.[0], @".txt$")) then failwith (argv.[0] + " is not a valid txt file") 
        File.ReadAllText(argv.[0]).ToUpper()
        |> (fun(x:String)-> Regex.Matches(x,@"[A-Z]+"))
        |> Seq.cast
        |> Seq.map(fun(x:Match)->x.Value)
        |> Seq.countBy id
        |> Seq.sortBy(fun(x,y)->(-y,x))
        |> Seq.take(int(argv.[1]))
        |> Seq.iter(fun(x:String,y:int)->printfn "%s %i" x y)
    with
        |  ex -> printfn "*** Error: %s" ex.Message
    0 // return an integer exit code