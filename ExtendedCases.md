
## Extended Cases

**Introduce Variable**    
Example: ` As variableIdentifier `

**Guard Condition**    
Example: ` When boolExpr `

**TypeCheck**    
Example: ` TypeIs typeIdentifier  `


```vb
Select Case obj

  Case TypeIs Int64 As i64 When ( i64 >= 0 )
  
  Case TypeIs Int64 As i64 When ( I64 <  0 )
  
  Case TypeIs Int32 As i32 When ( i32 <> 0 )
  
  Case Else When cond_is_true

  Case Else

End Select
```
