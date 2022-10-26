module Basics.Tuples

let tryParseStringToInt32 intStr =
   try
      let i = System.Int32.Parse intStr
      true,i
   with _ -> false,0 // this catches the exception and returns these values
   
let wordAndLetterCount (sentence:string) =  
   let words = sentence.Split [|' '|]
   let letterCount = words |> // pass the words array into the below function
                     Array.sumBy // sum all the values of the below function
                        (fun word -> word.Length ) // for each word in the array, get the length 
   (words.Length, letterCount)
