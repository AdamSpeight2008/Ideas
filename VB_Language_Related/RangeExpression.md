# Range Syntax

### Synopisis

Have a syntactic representation for expressing "a range".  
In VB the exist form that sort of means "range" it the form usesd in the `For Loop Declaration` or in declaring array dimensions'    
The syntax should independent of usage, and not tied to one cononical definitions.    
 Eg `0 To 10` doesn't neccessarily indicate that it is an `Enumerable.Range(Of Integer)`, context will also reflect its meaning.

**Example**
```vbnet
Dim xs(0 To 4) As String = {"A", "B", "C", "D", "E"}

For idx = 0 To 4 Step 2
  Console.Write(xs(idx))
Next
```

-----
```vbnet
For x As Int32 = 0 To 10 ' 0 To 10 considered to be a "loop-range", and treats as such. (Not an enumerable.)
Next x

For Each x In 0 To 10 ' 0 To 10 is treated as an IEnumerable Source, and produces a sequence of Int32.
Next

' Could be used to if a value is within a partical range (inclusive, inclusive)
Function Does_Character_Represent_A_Decimal_Digit(thisCharacter As Char) As Boolean
  Return thisCharacter In "0"c To "9"c
End Function
```
-----


### Syntactic Representation
The main parts of the representation consists for two parts, the range (which has as clusivities of;= inclusive lower and inclusive upper).

#### `(fromExpr : Expression) [To] (uptoExpr : Expression)`
The main parts for the representation appears to be `To` and `Step`
`To`    for declaring an range (inclusive lower, inclusive upper). Plus an optional part that indicates the stepping to be used within that range.

#### `(range : Range) [Step] (stepExpr : Expression)`
`Step`  for declaring the size of the stepping to be use within that range. `Step` is also used to indication the direction of the stepping

##### Baisc Ggrammar
```
RangeSyntax                         ::= (fromExpr : ExpressionSyntax) [To] (uptoExpr : ExpressionSyntax)    ;;
SteppedRangeSyntax : RangeSyntax    ::= (base : RangeSyntax) [Step] (stepExpr : ExpressionSyntax)           ;;
```


  * Example
```vb
  Dim rangeExpression =  expression [To] expression [Step] expression
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

-------------

### Syntax Representation

```vbnet
Syntax RangeSyntax
    FromExpr    As  ExpressionSyntax
    [To]        As  ToKeywordSyntax
    UpToExpr    As  ExpressionSyntax
End Syntax

Syntax SteppedRangeSyntax   Inherits    RangeSyntax
    [Step]      As  StepKeywordSyntax
    StepExpr    As  ExpressionSyntax
End Syntax
```