## Method Body Placement

Alter some the restriction about where the first statement of method body, can placed.

Example   

```vbnet
Public Property Value() As T
  Get
    Return _Value
  End Get
  Set(value As T)
    Me._Value = value
  End Set
End Property
```
is equivalent to
```vbnet
Public Property Value() As T
  Get             : Return _Value       : End Get
  Set(value As T) : Me._Value = value   : End Set
End Property
```

--------

### Implementation

This can be achieve by making the production of the diagnostic conditional, on wether the feature is enabled or not.

[Method Block Context](https://github.com/dotnet/roslyn/blob/master/src/Compilers/VisualBasic/Portable/Parser/BlockContexts/MethodBlockContext.vb#L34)
