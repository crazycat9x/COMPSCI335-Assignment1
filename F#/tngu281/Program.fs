// Learn more about F# at http://fsharp.org

open System
open System.IO
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv =
    File.ReadAllText(argv.[0]).ToUpper()
    |> (fun(x:String)-> Regex.Matches(x,@"[A-Z]+"))
    |> Seq.map(fun(x:Match)->x.Value)
    |> Seq.countBy id
    |> Seq.sortByDescending(fun(_,y)->y)
    |> Seq.take(int(argv.[1]))
    |> Seq.iter(fun(x:String,y:int)->printfn "%s %i" x y)
    0 // return an integer exit code
