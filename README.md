# Our-FSharp-Journey
Recently we were tasked with migrating a c# project code to f#. The code in question is some ms Orleans grains. The idea of this repo is to document findings and useful things we learn along the way.

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
let first = fst typeAbbreviationTuple // 1
let second = snd typeAbbreviationTuple // 2    
```

Some less obvious things with inputs / outputs
```f#
// This specifies that the first 2 integers are parameters and the last int is what is returned
type TypeAbbreviationFunction = int->int->int


// example
let typeAbbreviationFunction:TypeAbbreviationFunction = fun a b -> a + b
let result = typeAbbreviationFunction 10 20 // 30
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
let typeName1 = square.GetType().Name // "Shape"
let typeName2 = pentagon.GetType().Name // "Shape"
```

keep in mind that a function return type can also be inferred
```f#
type TryParseResult = {Success:bool; Value:int}
let tryParseStringToInt32WithRecords intStr =
  try
    let i = System.Int32.Parse intStr
    {Success=true;Value=i}
  with _ -> {Success=false;Value=0}
  
let result = tryParseStringToInt32WithRecords "99"
let typeName = result.GetType().Name // "TryParseResult"
```

### Dynamic
To accept a dynamic object as a parameter you can use `'`
```f#
let functionWithDynamicProperty 
    (dynamicProperty: 'a) : string 
    JsonConvert.SerializeObject dynamicProperty
```

### Run tests
```shell
> dotnet test src/Basics.Tests
```

### References

- [F# for Fun and Profit](https://fsharpforfunandprofit.com/posts/type-abbreviations/)

### Contributors
- [WesleySkeen](https://github.com/WesleySkeen)
- [macfma01](https://www.github.com/macfma01)
