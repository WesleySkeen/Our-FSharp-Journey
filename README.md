# My-FSharp-Journey
Playing with F# to get to grips with it

*This doc will be a WIP and will expand as my journey goes on*

## Findings
### Type Abbreviations
> _Type abbreviations are useful to provide documentation and avoid writing a signature repeatedly._

**Symbols mean different things depending on the context**

```f#
// The '*' here is a pairing in a tuple. Not to be confused with multiply
type TypeAbbreviationTuple = int * int

// example
let typeAbbreviationTuple = TypeAbbreviationTuple(1, 2)
    let first = fst typeAbbreviationTuple
    let second = snd typeAbbreviationTuple
    first |> should equal 1
    second|> should equal 2
```

Some less obvious things with inputs / outputs
```f#
// This specifies that the first 2 integers are parameters and the last int is what is returned
type TypeAbbreviationFunction = int->int->int


// example
let typeAbbreviationFunction:TypeAbbreviationFunction = fun a b -> a + b
    let result = typeAbbreviationFunction 10 20
    result |> should equal 30
```
### Tuples
If you want to catch all exceptions from a parsing. **Maybe this works in other contexts??**

```f#
let tryParseStringToInt32 intStr =
   try
      let i = System.Int32.Parse intStr
      true,i
   with _ -> false,0 // this catches the exception and returns these values
       
let result = tryParseStringToInt32 "abc"
let first = fst result // this will be false
let second = snd result // this will be 0

```
### Records
We can instantiate a `Record` without having to include its type
```f#
type Person = { First: string; Second: string }

let person = { First="Wes"; Second="Skeen" }
let typeName = person.GetType().Name // "Person"
```
With this approach we need to be aware that we can run into an issue 
if we have the same labels in multiple types. The compiler will use the last type defined

```f#
type Car1 = { NumberOfWheels: int;}
type Car2 = { NumberOfWheels: int;}

let car = { NumberOfWheels=4 }
let typeName = car.GetType().Name // "Car2"
```

If we want to get around this we could separate our objects using modules

```f#
module Module1 = type Shape = { NumberOfSides: int }
module Module2 = type Shape = { NumberOfSides: int }

let square = { Module1.NumberOfSides=4 }
let pentagon = { Module2.NumberOfSides=5 }
let typeName = square.GetType().Name // "Shape"
let typeName = pentagon.GetType().Name // "Shape"
```

### Run tests
```shell
> dotnet test src/Basics.Tests
```

### References

- [F# for Fun and Profit](https://fsharpforfunandprofit.com/posts/type-abbreviations/)