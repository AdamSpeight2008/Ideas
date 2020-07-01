## `For Loop` and `For Each Loop` base syntax.


Been thinking about how `For-Loop` and `ForEach-Loop` are defined, and if we could implement a common base.
This would make it easier to implement a list of `for/foreach loops`, via a comma-seperated list.


```vbnet
' AsTypeSyntax ::= "As" Type ;;
Syntax AsTypeSyntax
    [As]        AS AsKeywordSyntax
    Type        As TypeSyntax
End Syntax

' NameAsTypeSyntax ::= Name AsType? ;;
Syntax NameAsTypeSyntax
    Name        As NameSyntax
    AsType      As Optionally(Of TypeSyntax)
End Syntax

' ForBaseSyntax ::= "For" NameAsType ;;
Abstract Syntax ForBaseSyntax
    [For]       As ForKeywordSyntax
    NameAsType  As NameAsTypeSyntax
End Syntax
```


```vbnet
' ForLoopSyntax : ForLoopBaseSyntax ::= '=' Range ;;
Syntax ForLoopSyntax Inherits ForBaseSyntax
    [=]         As AssignmentPunctuationToken
    Range       As RangeSyntax
End Syntax

' ForEachLoopSyntax : ForLoopBaseSyntax  ::= .[For] "Each" .NameAsType "In" Source ;;
Syntax ForEachLoopSyntanx  Inherits ForBaseSyntax
    <After("For"), Before("NameAsType")>
    [Each]      As EachKeywordSynax
    <After("NameAsType">)
    [In]        As InKeywordSyntax
    Source      As ExpressionSyntax
End Syntax
```

'''vbnet
For x As Tx = 0 To 10 Step 1, y As Ty In From 0 To !0 Step 1
  ' Statements
Next