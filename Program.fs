module Program
open FSharp.Text.Lexing
open JsonParsing

[<EntryPoint>]
let main argv =
    let parse json = 
        let lexbuf = LexBuffer<char>.FromString json
        let res = Parser.start Lexer.read lexbuf
        res
    let simpleJson = @"{
              ""title"": ""Cities"",
              ""cities"": [
                { ""name"": ""Chicago"",  ""zips"": [60601,60600] },
                { ""name"": ""New York"", ""zips"": [10001] } 
              ]
            }"
    match simpleJson |> parse with
    | Some parseResult -> 
        printfn "Parsing succeeded: %A" parseResult
        printfn "%s" (JsonValue.print parseResult)
    | None -> 
        printfn "Parsing failed"

    0