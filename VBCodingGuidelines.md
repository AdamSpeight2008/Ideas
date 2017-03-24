## VB.net Coding Guidelines
 
 Coding Conventions
 
 * 80 character line limit
Recommendation that the maximum length of single line of code.    
*As seen in a text editor, not in the context of the actual language specification*

 * Use 4 space indentation, not tabs.
 
 * Use plain code to validation parameters at public boundaries.    
   * Do not use Contracts or magic helpers.
   
 * Method Parameters
   * Prefer single Line *(if within 80c recommendation)*    
```vbnet
ExampleMethod( arg0 As Integer ) As Integer
```
Otherwise use a single parameter per a line. eg
```vbnet
ExampleMethod(
	       arg0 As Integer,
               arg1 As Integer,
      Optional arg2 As String = Nothing,
    ParamArray args As String() 
	     ) As ...
```
  * `If ... Then`
Single Line `If ... Then `, is permissable usage for example: Parameter validation aka Guards
```vbnet
If someArgument Is Nothing Then Throw New NullArgumentException(NameOf(someArgument))
```
Provided that the total length the line is smaller or equal to the recommended line length, otherwise it is recommend to use the block form.
```vbnet
If someArgument Is Nothing Then
    Throw New NullArgumentException(NameOf(someArgument))
End If
``` 
