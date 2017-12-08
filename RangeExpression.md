# Range Expression
```vbnet
  x To y Step z
```
A `Range Expression` allows us to express the concept of a Range of Values. eg; 0 To 9. Think of this a starting at 0 and ending at 9.
The clusivity of the `start` and `end` values are always inclusive (and can not be altered), as this allow the full ranges of values in a type to be expressed. eg
`Byte.MinValue To ByteMaxValue` 
The inclusion of an optional `Step Size` allows you express that the range is non-contiguous, it is skipping some value do the stepping. eg
`0 To 10 Step 2` expresses only the odd values between 0 and 10.

**Enumerable**    
A `Range Expression` as an enumerable source, that can be enumerated over.
```
Dim odds = From x In 0 To 100
           Where (x Mod 2) = 0
```

**Within Range**
Validating if a value is within could be 
  * Simple if checks. ` (thisRange.X <= value) AndAlso (thisRange.Y <= value)`
    * Which suggests that the types used are compatible and also comparable 
      * compatible
      * comparable
      * implement operator `<=`, which operates on those types and returns bool.
    * If the types are _"numeric types"_, then `stepping` can also be accounted for with relativily simply.

```vbnet
Public Function IsInRange(value As Int32, x As Int32, y As Int32) As Boolean
  Return (x <= value) And (value<=y)
End Function

Public Function IsInRange(value As Int32, x As Int32, y As Int32, s As Int32) As Boolean
  Return IsInRange(value,x,y) AndAlso ((value Mod s) = (x Mod s))
End Function
```

  * Enumerate the values and check if value is in that sequence.
