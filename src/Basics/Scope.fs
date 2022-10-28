module Basics.Scope

// No scope, these can all be seen within this module
let fnameNs = "Frank"
let snameNs = "Schmidt"
let fullNameNs = $"{fnameNs} {snameNs}"
let greetingTextNs = $"Greetings, {fullNameNs}"

$"{greetingTextNs}"

// Can see fullNameNs here
$"{fullNameNs}"
 
 // With scoped levels, values are only visible within the nested scopes
 // Column position where the value is declared defines the scope boundary.
let greetingTextS =
    let fullNameS =
        let fnameS = "Frank"
        let snameS = "Schmidt"
        $"{fnameS} {snameS}"
    $"Greetings, {fullNameS}"

// greetingTextS is visible here because it's on used from the same column as its declaration
$"{greetingTextS}"

// Can't see fullNameS here because it's in the nested scope of greetingTextS
// Uncomment this print statement to verify it won't compile.
//$"{fullNameS}"