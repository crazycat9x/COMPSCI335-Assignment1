// Learn more about F# at http://fsharp.org

open System
open System.IO

[<EntryPoint>]
let main argv =
    let results = File.ReadAllText("test.txt").Split(" ") |> Seq.countBy id |> Seq.toList 
    printfn "%A" results
        
    0 // return an integer exit code
