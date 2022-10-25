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

### Run tests
```shell
> dotnet test src/Basics.Tests
```

### References

- [F# for Fun and Profit](https://fsharpforfunandprofit.com/posts/type-abbreviations/)