module Tests.FunctionTests

open FsUnit
open Xunit
open Basics.Functions

[<Fact>]
let ``Test function 'convertMilesToYards' should convert miles to yards`` () =
    let result = 1.0 |> convertMilesToYards    
    result |> should equal 1760