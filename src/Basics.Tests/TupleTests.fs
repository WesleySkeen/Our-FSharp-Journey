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
    
[<Theory>]
[<InlineData("test", 1, 4)>]
[<InlineData("test test", 2, 8)>]
let ``'wordAndLetterCount' should return expected letter and word count`` (sentence, wordCount, letterCount) =    
    let result = wordAndLetterCount sentence
    let first = fst result // word count
    let second = snd result // letter count
    first |> should equal wordCount
    second|> should equal letterCount