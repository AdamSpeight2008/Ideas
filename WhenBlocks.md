# When Blocks

`When Blocks` will extend the capabilities of a `Select Case ... End Select` block, to also allow guard clauses (`When expression`). 
```vbnet
' statements_0
Select Case expression_0 When expression_1
       Case clauses_0
            When expression_2
                 ' statements_1
            When expression_3
                 ' statements_2
            Else
                 ' statements_3
       Case clauses_1
            ' statements_4
       Case Else
            When expression_4
                 ' statements_5
            Else
                 ' statements_6
       Else
           ' statements_7
End Select
' statements_8
```
