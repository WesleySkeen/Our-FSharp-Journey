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