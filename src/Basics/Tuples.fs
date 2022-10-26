module Basics.Tuples

let tryParseStringToInt32 intStr =
   try
      let i = System.Int32.Parse intStr
      true,i
   with _ -> false,0 // this catches the exception and returns these values