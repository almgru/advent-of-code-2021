open System.IO

type Command = {
    Name: string
    Value: int
}

type Position = {
    HorizontalPosition : int
    Depth : int
    Aim : int
}

[<EntryPoint>]
let main args =
    let finalPosition =
        File.ReadLines args.[1]
        |> Seq.map (fun line -> (line.Trim ()).Split " ")
        |> Seq.map (fun line -> {
            Name = line |> Seq.head
            Value = line |> Seq.last |> int})
        |> Seq.fold
            (fun pos command ->
                match command.Name.ToLower () with
                | "forward" -> {
                    HorizontalPosition = pos.HorizontalPosition + command.Value
                    Depth = pos.Depth + (pos.Aim * command.Value)
                    Aim = pos.Aim }
                | "up" -> {
                    HorizontalPosition = pos.HorizontalPosition
                    Depth = pos.Depth
                    Aim = pos.Aim - command.Value }
                | "down" -> {
                    HorizontalPosition = pos.HorizontalPosition
                    Depth = pos.Depth
                    Aim = pos.Aim + command.Value }
                | _ -> raise (System.ArgumentException ()))
            { HorizontalPosition = 0; Depth = 0; Aim = 0 }

    printfn
        "Horizontal position %d multiplied by depth %d = %d"
        finalPosition.HorizontalPosition
        finalPosition.Depth
        (finalPosition.HorizontalPosition * finalPosition.Depth)

    0
