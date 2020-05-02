# Proposal `(Of ... ..., ... )` to define a "set of these objects"

## Abstract
An additional alternative meaning to the syntax `(Of ... ..., ...)`, to indicate a set of objects, where the set of *these* *"objects"* could be actual `objects` `types` or `expressions`.
General definition of the syntan `OneOf these`

------
## Background

Often when writting vbnet code we need to check if an object is (or is not) one of a set of objects.
This often involves combining a sequence of comparision sub-expressions, into a single expression, which fundementally 
consist of two forms;=

  * **Includes**</br> Form: <il style="background-color:WhiteSmoke;">*object* **Is** (**Of** *these types / objects*)</il>
    * Is any on of these types / objects / expressions.
    * Combining operator `OrElse` or `Or`
      * example 

```vbnet
' statements
Dim Result_Includes_True = (x = 0) OrElse (x = 1) OrElse (x = 2) )
If Result_Includes_True Then
  ' statements
Else
  ' statementss
End If
' statements
```

  * **Excludes**</br>
  Form: <il style="background-color:WhiteSmoke;">*object* **IsNot** (**Of** *these types / objects*)</il>
    * Is Not one of these types / objects / expressions.
    * Combining operator `AndAlso` or `And`
      * example;-

```vbnet
' statements
Dim Result_Excludes_True = (x <> 0) AndAlso (x <> 1) AndAlso (x <> 2)  )
If Result_Excludes_True Then
  ' statements
Else
  ' statementss
End If
' statements
```

------

#### Designing `(Of expression ..., expression )` 

When the rightside of a binary expression is of the syntax `(Of expression ..., expression)`.
During lowering stage `(Of expression (, expression)* ) )`, is rewritten as sequence of sub-expressions of the  
following form :- `  combiningOperation ( leftsize op rightside ) `

The combining operation for **Includes** and **Excludes** will be `OrElse` and `AndAlso` respectivily.


**Includes**
```vbnet
' statements
Dim Result_Includes_True = (x = (Of 0, 1, 2 ) )
If Result_Includes_True Then
  ' statements
Else
  ' statementss
End If
' statements
```
Lowering
```vbnet
' statements
Dim Result_Includes_True = (x = 0) OrElse (x = 1) OrElse (x = 2) )
If Result_Includes_True Then
  ' statements
Else
  ' statementss
End If
' statements
```

**Excludes**
```vbnet
' statements
Dim Result_Excludes_True = (x <> (Of 0, 1, 2 ) )
If Result_Excludes_True Then
  ' statements
Else
  ' statementss
End If
' statements
```

Lowering
```vbnet
' statements
Dim Result_Excludes_True = (x <> 0) AndAlso (x <> 1) AndAlso (x <> 2)  )
If Result_Excludes_True Then
  ' statements
Else
  ' statementss
End If
' statements
```

#### Function Calls

```VB
Dim listOfNames As String() = {"Alice", "Bob", "Charles"}
Dim thisName As String = "Charlie"
If Not listOfNames.Contains( (Of "Alice", "Bob", "Charlie") ) Then
  Console.WriteLIne("Not On Guest List")
Else
  Console.WriteLine("On Guest List")
End If
```
rewritten to:=
```vbnet
Dim listOfNames As String() = {"Alice", "Bob", "Charles"}
Dim thisName = "Charlie"
If Not ( (listOfNames.Contains(thisName)) OrElse (listOfNames.Contains(thisName)) OrElse (listOfNames.Contains(thisNamearlie")) ) Then
  Console.WriteLIne("Not On Guest List")
Else
  Console.WriteLine("On Guest List")
End If
```


-----

#### Errors

Equalivalant errors (as if produced by the rewritten code) will be reported at the corrisponding argument of the `(Of ... ..., ...)`


```vbnet
Dim q = ( x = (Of 0, "Bar", 2) )
'                    ~~~~~
' 
' BC30512 Option Strinc disallows implicit conversion from 'String' to 'Double`.
' BC0000 No overload of operator = between 'Integer' and 'String' found.
```

