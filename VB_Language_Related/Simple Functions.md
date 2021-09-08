## Use `:=` 

What about using `:=`
```vbnet
 Public Shared Operator <>(l As Source, r As source) As Boolean := l.ID <> r.ID
```
VB function have an implicitly defined variable that can use for the return value of function, that of it's method's name.
Named Parameter Syntax utilises `:=` to indicate what you are setting this explicitly named parameter to.
So why not reuse that convention and allow simpler definition of "short" function / methods.
