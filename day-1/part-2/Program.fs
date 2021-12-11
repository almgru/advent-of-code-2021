open System.IO

[<EntryPoint>]
let main args =
    let slidingWindowSumIncreaseCount =
        File.ReadLines args.[1]
        |> Seq.map (fun line -> line |> int) // parse input lines to ints
        |> Seq.windowed 3 // divide up ints into sliding windows of size 3
        |> Seq.map (fun arr -> arr |> Array.sum) // sum values in each sliding window
        |> Seq.pairwise // create pairs of sums for comparison
        |> Seq.filter (fun (a, b) -> b > a) // keep only increasing pairs of sums 
        |> Seq.length
    
    printfn "%d" slidingWindowSumIncreaseCount

    0