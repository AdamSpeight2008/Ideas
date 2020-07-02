## Flags Enum Operators

### Synopsis
Implement a set of immutable operations that operator over `<Flags>Enum`s.

```vbnet
Dim newFlags = theseFlags!Black   ' Is all the flags set of (theseFlags) that corrispond to the set flags in (named flag: Black) set to true?
Dim newFlags = theseFlags!+Black  ' Set the flags of (theseFlags) that corrispond to the set flags in (named flag: Black) to true. 
Dim newFlags = theseFlafs!-Black  ' Clear the flag of (theseFlag) that corrispond to the set flags in (named flag: Black) to false.
Dim newFlags = theseFlags!?Black  ' Is any of the flags set in (named flag: Black) set to true.
```
The above set of operator also have an overload the that takes an expression.
```vb
Dim newFlags = theseFlags! (expression)
Dim newFlags = theseFlags!+(epxression)
Dim newFlags = theseFlafs!-(expression)
Dim newFlags = theseFlags!?(expression)
```

----------

### Using the flagname `expr op flagname`
This allow the compiler to perform addition checks at compile-time.
  * are they the same enum type.
  * does the named flag exist?
  * Constant-Folding for better 

### Using expression `expr op (expr)`
Using this form only permits checking that they are of the same type of enum.

### Implementation
  
The operators would corrispond the as using the method body of the following method. (Note: not calling, to allow the compiler on constant-fold)
```vbnet
Function IsAllSet(Of T As <Flags>Enum)( sourceFlags As T, theseFlags As T) as Boolean
  Return (sourceFlags And theseFlags) = theseFlags
End Function
Function IsAnySet(Of T As <Flags>Enum)( sourceFlags As T, theseFlags As T) As Boolean
  Return (sourceFlags And theseFlags) <> 0
End Function
Function SetFlags(Of T As <Flags>Enum)( sourceFlags As T, theseFlags As T) As T
  Return (sourcFlags Or theseFlags)
End Function
Functon ClearFlags(Of T As <Flags>Enum)( sourceFlags As T, theseFlags As T) As T
  Return (sourceFlags And (Not theseFlags))
End Function
```
