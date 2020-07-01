## Zip Query Syntax

[Documentation on ZIP method.](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.zip?view=netframework-4.8)
Prior Art: [Roslyn-8221](https://github.com/dotnet/roslyn/issues/8221)
[Roslyn-100](https://github.com/dotnet/roslyn/issues/100)

From #525, separating out the discussion around a Zip operator

```vbnet
Dim  xs = {0, 1, 2, 4}
Dim  ys = {"A"c, "B"c, "C"c, "D"c, "E"c}
Dim  zs = From x In xs Zip y In ys
          Select New With {.x = x, .y = y)
```
Output
```
{ x = 0, y = A }
{ x = 1, y = B }
{ x = 2, y = C }
{ x = 4, y = D }
```



This would be lowered in to a call to `Enumerable.Zip` function. eg.
```vbnet
Dim zs = Enumerable.Zip(xs,ys, Function(x,y) (x,y) )
```
--------
## Implementation

### Definition of `ZipKeyword`
This will be contextual keyword, expressible within a LINQ Query Clause. 
```xml
<node-kind name="ZipKeyword" token-text="Zip" />
```


### Definition of  `ZipClauseSyntax`
```xml
<node-structure name="ZipClauseSyntax" parent="QueryClauseSyntax">
    <node-kind name ="ZipClause" />
    <child name="ZipKeyword" kind="ZipKeyword" />
    <child name="ZipWith" kind="CollectionRangeVariable" />
</node-structure>
```

Refactor out the parsing `CollectionRangeVariable` from `ParseFromControlVar`, so it can also be utilised by the `ParseZipClause" function,
```vbnet
Private Function ParseZipClause(zipKw As KeywordSyntax) As QueryClauseSyntax
    Debug.Assert(zipKw IsNot Nothing, "Expected ZIP keyword.")
    Dim rangeVar = ParseCollectionRangeVariable()
    Dim zipOp = InternalSyntaxFactory.ZipClause(zipKw, rangeVar)
     zipOp = CheckFeatureAvailability(Feature.ZipQueryExpression, zipOp)
    Return zipOp
End Function
```