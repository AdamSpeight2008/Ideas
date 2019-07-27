# TypeOf Modifications

Considering rewritting typeof expression to be a prefix expression. Then when binding and Is/IsNot expression check the type of the left
hand expression, to see if it is a TypeOf prefix expression. So the output of the bind in a typeof comparison.

**TypeOf Prefix Expression**

```
              IsExpression
             /		  \
 TypeOfPrefix              InToExpression
             \            /              \
              expr    type                variable
             
```

**InTo Expression**

**IsExpression**
