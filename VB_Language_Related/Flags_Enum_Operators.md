## Flags Enum Operators

### Synopsis
Implement as set of immutable operations the operator over `<Flags>Enum`.

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