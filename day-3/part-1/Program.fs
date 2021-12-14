open System.IO
open System

[<EntryPoint>]
let main args =
    let input =
        File.ReadAllLines args.[1]
        |> Array.map (fun line -> (line.Trim ()).ToCharArray ())
        |> Array.transpose
    
    let gammaRate =
        input
        |> Array.map (fun arr ->
            arr
            |> Array.countBy id
            |> Array.maxBy (fun tup -> snd tup) 
            |> fst)
        |> String 
        |> (fun str -> Convert.ToInt32 (str, 2))
    
    let epsilonRate =
        input
        |> Array.map (fun arr ->
            arr
            |> Array.countBy id
            |> Array.minBy (fun tup -> snd tup)
            |> fst)
        |> String 
        |> (fun str -> Convert.ToInt32 (str, 2))
    
    printfn
        "gamma rate %d x epsilon rate %d = power consumption %d"
        gammaRate
        epsilonRate
        (gammaRate * epsilonRate)

    0