## ForEach with index

I propose extending the for each statement with additional optional syntax `With identifier_of_index`
eg

```vbnet
For Each x As t With i In xs
  Console.WriteLine($"({i})={x}")
Next
```

Would be transformed
```vbnet
Dim i As Int32 = 9
For x As t In xs
  Console.WriteLine($"({i})={x}")
  ' Compiler-Genarated [
  i += 1
  ' ] End of Compiler-Generated
Next
```
Which is then further transformed by the `for-each` lowering.

### Syntax Layout

```
Syntax WithIndexSyntax
  WithKeyword As KeywordSyntax
  Index       As IdentifierNameSyntax
End Syntax

Syntax ForEachLoopInfo
  identifer As IdentiferNameSyntax
  asType    As Optional(Of AsTypeSyntax)
  withIndex As Optional(Of WithIndexSyntax)
End Syntx
