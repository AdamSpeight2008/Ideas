## With Using Block

### Synopsis

Let the `Using Block` have the ability of the `With Block`, where we refer to members via `.` syntax.    

```vbnet
Using en = source.GetEnumerator
  With en
    If .MoveNext() Then
      Yield .Current
    Else
    End If
  End With
End Using
```

```vbner
With Using en = source.GetEnumerator
  If .MoveNext() Then
    Yield .Current
  Else
  End If
End Using
```