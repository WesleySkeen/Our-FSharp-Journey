module Tests.TupleTests

open FsUnit
open Xunit
open Basics.Tuples


[<Fact>]
let ``'tryParse' should return a valid result`` () =    
    let result = tryParseStringToInt32 "99"
    let first = fst result
    let second = snd result
    first |> should equal true
    second|> should equal 99
    
[<Fact>]
let ``'tryParse' should return an in-valid result`` () =    
    let result = tryParseStringToInt32 "abc"
    let first = fst result
    let second = snd result
    first |> should equal false
    second|> should equal 0 // this is the default int returned if validation fails