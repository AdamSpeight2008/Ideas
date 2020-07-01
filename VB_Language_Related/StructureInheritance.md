# Structure Inheritance and Refines

This extends the concept of inheritance to structure types.

```vbnet
Structure Range(Of Tx)

  Public ReadOnly X As Tx
  Public ReadOnly Y As Tx

  Sub New(X As Tx, Y As Tx)
    Me.X = X
    Me.Y = Y
  End Sub

End Structure
```
If the Range could also have a stepping. Eg `{1,4,7,10} ' 1 To 10 Step 3`  
It still a range, so it makes sense that it should inherit from `Range`
```vbnet
Structure StepRange(Of Tx, Sy) : Inherits Range(Of Tx)
  Public ReadOnly S As Sy

  Sub New( X As Tx, Y As Tx, S As Sy)
    MyBase.New(X, Y)
    Me.S = S
  End Sub

End Structure
```

------------------------------

This overloads the Structure Type `Range(Of Tx)` so it is used when the generic parameter argument `Tx` is `IComparable(Of Tx)`.
ie;- It is a more refined implementation of `Range(Of Tx)`
```vbnet
Structure Range(Of Tx As IComparable(Of Tx)) : Refines Range(Of Tx)
  Function Contains(Value As Tx) As Boolean
   Return (Me.X.ComparedTo(Value) <= 0) AndAlso (Value.ComparedTo(Me.Y) <= 0)
  End Function
End Structure
```
-----------------------
It is likely `Range(Of Tx)` will be used mostly over the core types like Int32.
So let's have Type overload that can be treated as specific typed implementation of `Range(Of Tx)` `Range(Of Int)`
```vbnet
Structure Range : Refines Range(Of Int)
  Function Contains(Value As Int) As Boolean
    Return (X <= Value) AndAlso (Value <= Y)
  End Function
End Structure
```
It can also be extended cover the inheritance.
```vbnet
Structure StepRange : Refines StepRange(Of Int, Int)
  Function Contains(Value As Int) As Boolean
    Return MyBase.Contains(Value) AndAlso (( Value Mod Me.S ) = (Me.X Mod Me.S))
  End Function
End Structure
```
