## `Using` Clause Extension

Currently is not possible _(to my knowledge)_ to chose an overload that accepts some form of comparitor to use, during functions like grouping and ordering.
We have to use directly the method syntax instead.

### Proposal

Extend the linq query clauses for `OrderBy` and `GroupBy` to have an optional argument that supplies the comparitor.

Comparitor would have satisfy one of the following.
  - `EqualityComparer`
  - `IComparable`

If it does not then it is an error, along the lines of no suitable overload found. Though tailored to be in relation to Query syntax.

```vbnet
From x In xs
Order By x Ascending Using this_IEqualityComparer
Group By x.y Into gs Using thisOther_IComparabl
```

`Order By` tree
```
		     Using
                    /     \
               Order       this_IEqualityComparer
		    \ 
                     By
                    /
           Ascending
          /
         x      
```

`Group By` tree
```
		Using
               /     \
           Into       thisOther_IComparable
          /    \
     Group      group_name
          \
           By
          /
         x.y
```

### Example
```vbnet
    Dim xs = {"A2","A10","a1","B10","b2"}
    Dim r = From x In xs
            Order By x Ascending Using StringComparer.OrdinalIgnoreCase
            Select x
    ' r is expected to be { "a1", "A2", "A10", "b2", "B10")
    ' not { "a1", "A10", "A2", "B10", "B2" }
```
