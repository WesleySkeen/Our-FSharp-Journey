// Find the most recent valid date from this set of date/time strings.
[
    "Jan 3 2021"
    "2022-05-03T08:32:20.7139433Z"
    "Wednesday, December 19, 2001"
    "June 15"
    "10/22/2022 10:12:34 PM"
    "99/99/9999" // Bad date
    "2018-02-28T13:45:30.0000000-07:00"
    "Wed, 15 Apr 2015 20:45:30 GMT"
    "Wed, 03 Mar 2013 20:45:30 GMT" // Wed is wrong
]
|> List.map (fun dstr -> System.DateTime.TryParse(dstr)) // Change each date string to a (bool, DateTime) tuple
|> List.filter (fun (isValid, _) -> isValid) // Keep the valid dates only
|> List.map (fun (_, dt) -> dt) // Change (bool, DateTime) tuple to DateTime
|> List.sortDescending
|> List.head // Take only the first item in the list


// Convert list of words into a space separated string.
// The lambda for reduce takes a accumulator value and the next item
[
    "One"
    "small"
    "step"
    "for"
    "man."
    "One"
    "giant"
    "leap"
    "for"
    "mankind."
]
|> List.reduce (fun accum item -> $"{accum} {item}")

// Get the user with most hits...
[
    { UserName = "Sam"; Hits = 11 }
    { UserName = "John"; Hits = 10 }
    { UserName = "Rebecca"; Hits = 9 }
    { UserName = "Sam"; Hits = 3 }
    { UserName = "John"; Hits = 5 }
]
|> List.groupBy (fun hit -> hit.UserName)
//[("John", [{ UserName = "John"; Hits = 10 }; { UserName = "John"; Hits = 5 }]);
// ("Sam", [{ UserName = "Sam"; Hits = 3 }; { UserName = "Sam"; Hits = 11 }])
// ("Rebecca", [{ UserName = "Rebecca"; Hits = 9 }])]
  
|> List.map(fun (grp, hits) -> (grp, hits |> List.sumBy (fun hit -> hit.Hits)))
// [("Sam", 14); ("John", 15); ("Rebecca", 9)]

|> List.sortByDescending (fun (_, hits) ->  hits)
//[("John", 15); ("Sam", 14); ("Rebecca", 9)]

|> List.head
// ("John", 15)