module Basics.TypeAbbreviations

// The '*' here is a pairing in a tuple. Not to be confused with multiply
type TypeAbbreviationTuple = int * int
// This specifies that the first 2 integers are parameters and the last int is what is returned
type TypeAbbreviationFunction = int->int->int