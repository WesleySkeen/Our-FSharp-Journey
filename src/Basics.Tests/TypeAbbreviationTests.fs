module Tests.TypeAbbreviationTests

open FsUnit
open Xunit
open Basics.TypeAbbreviations

[<Fact>]
let ``Test TypeAbbreviation as a function`` () =    
    let typeAbbreviationFunction:TypeAbbreviationFunction = fun a b -> a + b
    let result = typeAbbreviationFunction 10 20
    result |> should equal 30
    
[<Fact>]
let ``Test TypeAbbreviationTuple as a tuple`` () =    
    let typeAbbreviationTuple = TypeAbbreviationTuple(1, 2)
    let first = fst(typeAbbreviationTuple)
    let second = snd(typeAbbreviationTuple)
    first |> should equal 1
    second|> should equal 2