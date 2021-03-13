# TypeOfAs

```vbnet
Dim o As Object = "123.45"
Dim ok As Boolean = TypeOf o Is x As String
' if type check is valid then
'    x = TryCast(o, String)
' else
'    x = Default(OF String)
' end if
```
