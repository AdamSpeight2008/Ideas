## For Each with Index
I propose that we extend the definition of [LoopControlVariable ](https://github.com/dotnet/vblang/blob/master/spec/statements.md#fornext-statements) to allow the loop to also include the index of each item.

### Syntax
```
LoopControlVariable
    : Identifier ( IdentifierModifiers 'As' TypeName )?
    | Expression
    ;

Syntax WithIndexSyntax
  WithKeyword As Keyword
  Index       As Identifier
End Syntax

Syntax LoopControlWithIndexVariable Inherits LoopControlVariable 
  WithIndex As WithIndexSyntax   
End Syntax
```
### Example
```vbnet
For Each x As t With index In xs
  Console.WriteLine( $"({index}) = {x}")
Next
```

### Lowering
The example will be lowered into the following code.
```vbnet
' compiler-generated {
Dim index = 0
' } end of compiler-generated
For Each x As t In xs
  Console.WriteLine($"({index}) = {x}")
  ' Compiler-generated {
  index += 1
  ' } end of compiler-generated
Next
```

### Caveats
The `WithIndex` is to considered as declaring an implied `Dim index As Integer` definition, just before the for each statement.  We makes it subject the restrictions and errors around already declared variables.
