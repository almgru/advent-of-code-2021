// Usage: dotnet run Program.fs ../input.txt
open System.IO

[<EntryPoint>]
let main args =
    let increaseCount =
        File.ReadLines args.[1]
        |> Seq.map (fun str -> str |> int)
        |> Seq.pairwise
        |> Seq.filter (fun (a, b) -> b > a)
        |> Seq.length

    printfn "Number of increases: %d" increaseCount

    0
