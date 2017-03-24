The current coding guidelines are C-centric, with no or very little guideline for VB.net contributions, for projects within the .NET Foundation that use the language within their project. Thus lack of clear guidelines has and will cause friction between different opinions on stylistic aspects of the code / contribution, rather that the functional / semantic behavior of the code.

----------
### 80 character line limit
Recommendation that the maximum length of single line of code.
*(as seen in a text editor, not in the context of the actual language specification)*

### Indentations
4 spaces characters. not tabs

### Method Parameters
Single Line *(if within 80c recommendation)*
```vbnet
ExampleMethod( arg0 As Integer ) As Integer
```
```vbnet
ExampleMethod(
	       arg0 As Integer,
               arg1 As Integer,
      Optional arg2 As String = Nothing,
    ParamArray args As String() 
	     ) As ...
```
--------
### `If ... Then`
Single Line `If ... Then `, for example: Parameter validation aka Guards
```vbnet
If someArgument Is Nothing Then Throw New NullArgumentException(NameOf(someArgument))
```
Is permissible usage provided the total length of the statement is 80 characters or less, otherwise it is recommend to use the block form.
```vbnet
If someArgument Is Nothing Then
    Throw New NullArgumentException(NameOf(someArgument))
End If
``` 
