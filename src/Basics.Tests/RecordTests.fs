module Tests.RecordTests

open FsUnit
open Xunit
open Basics.Records

[<Fact>]
let ``Test that the compiler can infer the type of record`` () =
    let person = { First="Wes"; Second="Skeen" }
    person.GetType().Name |> should equal "Person"
    
[<Fact>]
let ``Test that the compiler uses the most recently defined type if label names are the same`` () =
    let car = { NumberOfWheels=4 }    
    car.GetType().Name |> should equal "Car2"
    
[<Fact>]
let ``Test that we can separate defined types by using modules`` () =
    let square = { Module1.NumberOfSides=4 }
    let pentagon = { Module2.NumberOfSides=5 }
    square.GetType().Name |> should equal "Shape"
    pentagon.GetType().Name |> should equal "Shape"
    
[<Fact>]
let ``'tryParseRecordWithIntValueFromString' should return a valid result`` () =    
    let result = tryParseStringToInt32WithRecords "99"    
    result.Success |> should equal true
    result.Value |> should equal 99
    
[<Fact>]
let ``'tryParseRecordWithIntValueFromString' should return an in-valid result`` () =    
    let result = tryParseStringToInt32WithRecords "abc"    
    result.Success |> should equal false
    result.Value |> should equal 0 // this is the default int returned if validation fails
    
[<Theory>]
[<InlineData("test", 1, 4)>]
[<InlineData("test test", 2, 8)>]
let ``'wordAndLetterCountWithRecords' should return expected letter and word count`` (sentence, wordCount, letterCount) =    
    let result = wordAndLetterCountWithRecords sentence
    result.WordCount |> should equal wordCount
    result.LetterCount |> should equal letterCount    