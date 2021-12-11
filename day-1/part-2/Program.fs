﻿open System.IO

[<EntryPoint>]
let main args =
    let increasingWindowCountSum =
        File.ReadLines args.[1]
        |> Seq.map (fun line -> line |> int)
        |> Seq.windowed 3
        |> Seq.map (fun arr -> arr |> Array.sum)
        |> Seq.pairwise
        |> Seq.filter (fun (a, b) -> b > a)
        |> Seq.length
    
    printfn "%d" increasingWindowCountSum

    0