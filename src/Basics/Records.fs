module Basics.Records

type Person = { First: string; Second: string }

// this is used to demonstrate defined type order and labels
type Car1 = { NumberOfWheels: int;}
type Car2 = { NumberOfWheels: int;} 

// this is used to demonstrate that we can use modules separate types with the same name
module Module1 = type Shape = { NumberOfSides: int }
module Module2 = type Shape = { NumberOfSides: int }

type TryParseResult = {Success:bool; Value:int}

let tryParseStringToInt32WithRecords intStr =
  try
    let i = System.Int32.Parse intStr
    {Success=true;Value=i}
  with _ -> {Success=false;Value=0}
  
type WordAndLetterCountResult = {WordCount:int; LetterCount:int}
let wordAndLetterCountWithRecords (sentence:string) =  
   let words = sentence.Split [|' '|]
   let letterCount = words |> // pass the words array into the below function
                     Array.sumBy // sum all the values of the below function
                        (fun word -> word.Length ) // for each word in the array, get the length 
   {WordCount=words.Length; LetterCount=letterCount}

