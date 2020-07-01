# When Blocks

`When Blocks` will extend the capabilities of a `Select Case ... End Select` block, to also allow guard clauses (`When expression`). 
```vbnet
' statements_0
Select Case expression_0 When expression_1
       Case clauses_0
            When expression_2
                 ' statements_1
            When expression_3
                 ' statements_2
            Else
                 ' statements_3
       Case clauses_1
            ' statements_4
       Case Else
            When expression_4
                 ' statements_5
            Else
                 ' statements_6
       Else
           ' statements_7
End Select
' statements_8
```

### Example
```vbnet
Function TryParseDigit(base As Base, here As Int32, diagnostics As DiagnosticBag, ByRef d As Digit) As Boolean 
  d = Nothing
  Dim ch As Char = Nothing
  Select Case ch When TryGet(here, ch)
         Case "0"c To "1"c When base <= Bases.BIN : d = New Digit(base, here, AscW(ch)-AscW("0"c) )
         Case "2"c To "7"c When base <= Bases.OCT : d = New Digit(base, here, AscW(ch)-AscW("0"c) )
         Case "8"c To "9"c When base <= Bases.DEC : d = New Digit(base, here, AscW(ch)-AscW("0"c) )
         Case "A"c To "F"c When base <= Bases.HEX : d = New Digit(base, here, AscW(ch)-AscW("A"c)+10 )
         Case "a"c To "f"c When base <= Bases.HEX : d = New Digit(base, here, AscW(ch)-AscW("a"c)+10 )
         Case Else
              diagnostics.AddError( ErrID.ERR_UnexpectedCharacter )
         Else
              diagnostics.AddError( ErrID.ERR_UnexpectedEndOfSource )
  End Select
  Return d IsNot Nothing
End Function
```
The above snippet of code would be lowered into the following code.
```vbnet
Function TryParseDigit(base As Base, here As Int32, diagnostics As DiagnosticBag, ByRef d As Digit) As Boolean 
  d = Nothing
  Dim ch As Char = Nothing
  If TryGet(here, ch) AndAlso ch Then
     If (ch >= "0"c AndAlso ch <= "1"c) AndAlso (base <= Bases.BIN) Then
        d = New Digit(base, here, AscW(ch)-AscW("0"c) )
     Else If (ch>="2"c AndAlso ch <= "7"c) AndAlso (base <= Bases.OCT) Then
        d = New Digit(base, here, AscW(ch)-AscW("0"c) )
     Else If (ch >= "8"c AndAlso ch <= "9"c) AndAlso (base <= Bases.DEC) Then
        d = New Digit(base, here, AscW(ch)-AscW("0"c) )
     Else If (ch >= "A"c AndAlso ch <= "F"c) AndAlso (base <= Bases.HEX) Then
        d = New Digit(base, here, AscW(ch)-AscW("A"c) + 10 )
     Else If (ch >= "a"c AndAlso ch <= "f"c) AndAlso (base <= Bases.HEX) Then
        d = New Digit(base, here, AscW(ch)-AscW("a"c) + 10 )
     Else
        diagnostics.AddError( ErrID.ERR_UnexpectedCharacter )
     End If
  Else
     diagnostics.AddError( ErrID.ERR_UnexpectedEndOfSource )
  End If
  Return d IsNot Nothing
End Function
```

### Lowering step 1
Rewrite to `Select Case True ... End Select` form
```vbnet
Select Case True
       Case TryGet(here, ch)
            Select Case True
                   Case (ch>="0"c AndAlso ch<="1"c) AndAlso (base <= Bases.BIN)
                        d = New Digit(base, here, AscW(ch)-AscW("0"c) )
                   Case (ch>="2"c AndAlso ch<="7"c) AndAlso (base <= Bases.OCT)
		        d = New Digit(base, here, AscW(ch)-AscW("0"c) )
                   Case (ch>="8"c AndAlso ch<="9"c) AndAlso (base <= Bases.DEC)
        		d = New Digit(base, here, AscW(ch)-AscW("0"c) )
                   Case (ch>="A"c AndAlso ch<="F"c) AndAlso (base <= Bases.HEX)
        		d = New Digit(base, here, AscW(ch)-AscW("A"c) + 10)
                   Case (ch>="a"c AndAlso ch<="f"c) AndAlso (base <= Bases.HEX)
        		d = New Digit(base, here, AscW(ch)-AscW("a"c) + 10)
                   Case Else
                        diagnostics.AddError( ErrID.ERR_UnexpectedCharacter )
            End Select
       Case Else
            diagnostics.AddError( ErrID.ERR_UnexpectedEndOfSource )
End Select
```
### Lowering step 2
Rewrite without using `Select Case ... End Select`
```vbnet
If True Then
   If TryGet(here, ch) Then
      If (ch>="0"c AndAlso ch<="1"c) AndAlso (base <= Bases.BIN) Then
         d = New Digit(base, here, AscW(ch)-AscW("0"c) )
      Else If Case (ch>="2"c AndAlso ch<="7"c) AndAlso (base <= Bases.OCT) Then
	 d = New Digit(base, here, AscW(ch)-AscW("0"c) )
      Else If (ch>="8"c AndAlso ch<="9"c) AndAlso (base <= Bases.DEC) Then
         d = New Digit(base, here, AscW(ch)-AscW("0"c) )
      Else If (ch>="A"c AndAlso ch<="F"c) AndAlso (base <= Bases.HEX) Then
         d = New Digit(base, here, AscW(ch)-AscW("A"c) + 10)
      Else If (ch>="a"c AndAlso ch<="f"c) AndAlso (base <= Bases.HEX) Then
         d = New Digit(base, here, AscW(ch)-AscW("a"c) + 10)
      Else
         diagnostics.AddError( ErrID.ERR_UnexpectedCharacter )
      End If
   Else 
       diagnostics.AddError( ErrID.ERR_UnexpectedEndOfSource )
   End If
End If
```
### Lowering step 3
Rewrite without using `ElseIf`

```vbnet
If True Then
   If TryGet(here, ch) Then
      If (ch>="0"c AndAlso ch<="1"c) AndAlso (base <= Bases.BIN) Then
         d = New Digit(base, here, AscW(ch)-AscW("0"c) )
      Else
         If Case (ch>="2"c AndAlso ch<="7"c) AndAlso (base <= Bases.OCT) Then
	    d = New Digit(base, here, AscW(ch)-AscW("0"c) )
         Else
            If (ch>="8"c AndAlso ch<="9"c) AndAlso (base <= Bases.DEC) Then
               d = New Digit(base, here, AscW(ch)-AscW("0"c) )
            Else
               If (ch>="A"c AndAlso ch<="F"c) AndAlso (base <= Bases.HEX) Then
                  d = New Digit(base, here, AscW(ch)-AscW("A"c) + 10)
               Else
                  If (ch>="a"c AndAlso ch<="f"c) AndAlso (base <= Bases.HEX) Then
                     d = New Digit(base, here, AscW(ch)-AscW("a"c) + 10)
                  Else
                     diagnostics.AddError( ErrID.ERR_UnexpectedCharacter )
                  End If
               End If
            End If
        End If
   Else 
       diagnostics.AddError( ErrID.ERR_UnexpectedEndOfSource )
   End If
End If
```
