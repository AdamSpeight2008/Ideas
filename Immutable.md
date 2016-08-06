## Immutable

The `Immutable` modifier on a class or structure declaration, will enforce immutablity with that definition. 
Raising errors, should immutablity be broken.

```vb
Immutable Class Foo
  Public Readonly Property Value As Integer
  
  Private Sub new(Value As Integer)
    Me.Value = Value
  End Sub
  
  Public Function Increment() As Foo
     Return New Foo(Me.Value + 1)
  End Function
  
  Public Function Decrement() As Foo
    Return New Foo(Me.Value - 1)
  End Function
  
  Public Shared Function CreateNew() As Foo
    Return New Foo(0)
  End Function

End Class
```
