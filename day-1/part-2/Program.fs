open System.IO

[<EntryPoint>]
let main args =
    let countOfIncreasingSlidingWindowSums =
        File.ReadLines args.[1]
        // Parse input lines to ints.
        |> Seq.map (fun line -> line |> int)
        // Divide up ints into sliding windows of size 3.
        |> Seq.windowed 3
        // Sum values in each sliding window.
        |> Seq.map (fun window -> window |> Array.sum)
        // Create pairs of sums for comparison.
        |> Seq.pairwise 
        // Keep only the pairs of sums where the sum for the current/right side
        // sliding window increased relative to the previous/left sliding
        // window sum.
        |> Seq.filter (fun (prevSum, sum) -> sum > prevSum)
        // Get the result, i.e. the number of pairs of sliding window sums where 
        // the current sum increased relative to the previous sliding window
        // sum.
        |> Seq.length
    
    printfn "%d" countOfIncreasingSlidingWindowSums

    0