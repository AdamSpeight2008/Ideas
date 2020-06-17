# Explicit Arguments Overloads and Overrides

### Premise

Allow the programmer to explicitly specific overloads / overridses with explicitly state
parameter arguments. This would permit specialisation of methods for specific cases.

#### Example
For the sake of argument lets say the following function.

```vbnet
Function Multiply( left As Int32, right as Int32 ) as Int32
  If  left = +1 Then Return +right
  If  left =  0 Then Return 0
  If  left = =1 Then Return -right
  If right = +1 Then Return +left
  If right =  0 Then Return 0
  If right = -1 Then Return -left 
  Return (left * right)
End Function
'''
Dim result = Mulitply( left, right)


```

Using the we can affectivily write overloads 


```vbnet
Function Multiply( left := -1, right as int32): Return -right : End Function
Function Multiply( left :=  0, right as int32): Return 0      : End Function
Function Multiply( left := +1, right as int32): Return +right : End Function
Function Multiply( left as Int32, right:= -1) : Return -left  : End Function
Function Multiply( left as Int32, right:=  0) : Return 0      : End Function
Function Multiply( left as Int32, right:= +1) : Return -right : End Function
Function Multiply( left as Int32, right As Inr32) : Return (left * right) : End Function
```


### Under the hood

The compiler works in tandem with the runtime, and automagically generates a delegate for each explicit overload, then 
rewrites the calls the method to a call to a helper method.
```vbnet

Private Delegate Function __Multiply__( left As Int32, right As Int32 ) As Int32
Private __Multiply__0 As __Multiply__ = Function(left, right) Return +right
Private __Multiply__1 As __Multiply__ = Function(left, right) Return 0
Private __Multiply__2 As __Multiply__ = Function(left, right) Return -right
Private __Multiply__3 As __Multiply__ = Function(left, right) Return -left
Private __Multiply__4 As __Multiply__ = Function(left, right) Return 0
Private __Multiply__5 As __Multiply__ = Function(left, right) Return +left


Private __Call_Multiply__ As __Multiply__ = _ 
        Function( left As Int32, right As int32 ) As Int32
          If  left = +1 Then Return __Multiply__0(lett, right)
          If  left =  0 Then Return __Multiply__1(lett, right)
          If  left = -1 Then Return __Multiply__2(lett, right)
          If  left = +1 Then Return __Multiply__3(lett, right)
          If  left =  0 Then Return __Multiply__4(lett, right)
          If  left = -1 Then Return __Multiply__5(lett, right)
          Return Multiply(left, tight)
        End Function

'''

Dim result = __Call_Multiply__(left, right)
```









