## Guarded Statements

Allow some statments to be conditional base on if some condition is true.

At the moment the feature is only target the following statement kinds.
  * Select Case Statement    
Eg    
```vbnet
Select Case expression When condition
  ' section to use when condition is true
Else
  ' section to use when condition is false
End Select
```

  * Case Clause Statements

```vbnet
Select Case ch
  Case "0"c To "1"c When base >= Bases.BIN
  Case "2"c To "7"c When base >= Bases.OCT
  Case "8"c To "9"c When base >= Bases.DEC
  Case "A"c To "F"c When base >= Bases.HEX
  Case "a"c To "f"c When base >= Bases.HEX
  Case Else When some_condition_is_true
  Case Else
    ' the default case, when none of the aboves cases are true
End Select
```
    
  * The **Guard Condition** is associated to clauses in the clause list, and not only associated to clause on it left side.     
    * eg.
```vbnet
Case "0", "1" When base >= Bases.BIN
```
Is considered to be doing the following
```vbnet
  Case "0", "1"
    If base >= Base.BIN Then
      ' do this
    Else
      Goto next_clause_statement      
    End If
```
and not
```vbnet
Case "0", ("1" When base >= Bases.BIN)
```