## Default Optional Parameters

When defining a optional parameter, specifying the default value is optional when the default value of the type is used. Eg ` = Nothing`


```vbnet
Function M(Optional arg0 As String = Nothing,
           Optional arg1 As Int32  = Nothing,
           Optional arg2 As Int32? = Nothing
          )
```
```vbnet
Function M(Optional arg0 As String,
           Optional arg1 As Int32 ,
           Optional arg2 As Int32?
          )
```
