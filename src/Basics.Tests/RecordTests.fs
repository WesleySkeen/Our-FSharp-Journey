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
    car.GetType().Name |> should equal "CarCopy" 