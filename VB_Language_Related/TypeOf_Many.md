## TypeOf Many Expressons
### Synopsis

Allow the programmer to express and set of types to check against, with in `TypeOf expr Is` and `TypeOf expr IsNot` expresssions.

### Examples
The following lines of code are semantically equivalent.    
`TypeOf expr Is T0 OrElse TypeOf expr Is T1 OrElse TypeOf expr Is T2 OrElse TypeOf expr Is T3`    
`TypeOf expr Is (Of T0, T1, T2, T3)`    
This is the following lines of code as semantically equivalent.    
`TypeOf expr IsNot T0 AndAlso TypeOf expr IsNot T1 AndAlso TypeOf expr IsNot T2 AndAlso TypeOf expr IsNot T3`    
`TypeOf expr IsNot (Of T0, T1, T2, T3)`    

