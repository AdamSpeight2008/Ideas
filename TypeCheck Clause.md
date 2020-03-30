## Type Check Clause
Initial idea of having a type check clause for `Select Case ... End Select`

```vbnet
Select Case expr
       Case Is t
       Case Is t Into variable
       Case Is (Of t0..., tn)
       Case IsNot t
       Case IsNot (Of t0..., tn)
       Case Else
End Select
```

Node Structure
```
Abstract Syntax AbstractTypeClauseSyntax Inherits ClauseSyntax
  .IsOrIsNotKeyword As KeywordSyntax
End Syntax

Syntax TypeSingleClauseSyntax Inherits AbstractTypeClauseSyntax
  .Type As TypeSyntax
End Syntax

Syntax TypeOfManyClauseSyntax Inheris AbstractTypeClauseSyntax
  .Types As ArgumentTypeListSyntax
End Syntax
```
