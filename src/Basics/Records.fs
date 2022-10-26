module Basics.Records

type Person = { First: string; Second: string }

// this is used to demonstrate defined type order and labels
type Car1 = { NumberOfWheels: int;}
type Car2 = { NumberOfWheels: int;} 

// this is used to demonstrate that we can use modules separate types with the same name
module Module1 = type Shape = { NumberOfSides: int }
module Module2 = type Shape = { NumberOfSides: int }
