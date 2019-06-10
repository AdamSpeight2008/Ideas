Ascending For-Range lowering (rough)
```vbnet
Dim IndexValue = StartValue
Dim delta = EndValue - StartValue
Dim modus = delta Mod StepValue
Dim LastValue = EndValue - modus

InitialiseForLoopControlVariables:

StartOfForLoop_{identifier}:
  Dim cmp = IndexValue.ComparedTo(LastValue)
  ' Note: That > 0 isn't being used so, in the case
  '   StartValue = .MaxValue
  ' at least one iteration of the body will occur.
  If cmp <= 0 Then
    {Body}
    ContinueForLoop_{identifier}:
      If cmp >= 0 Then GoTo ExitOfForLoop_{identifier{
      IndexValue += StepValue
      GoTo StartOfForLoop_{identifier}:
  End If
ExitOfForLoop_{identifier}:

```

Descending For-Range Lowering (rough)
```vbnet
StepValue = Abs(StepValue)

Dim IndexValue = StartValue
Dim delta = EndValue - StartValue
Dim modus = delta Mod StepValue
Dim LastValue = EndValue + modus

InitialiseForLoopControlVariables:

StartOfForLoop_{identifier}:
  Dim cmp = IndexValue.ComparedTo(LastValue)
  ' Note: That < 0 isn't being used so, in the case
  '   StartValue = .MinValue
  ' at least one iteration of the body will occur.
  If cmp >= 0 Then
    {Body}
    ContinueForLoop_{identifier}:
      If cmp <= 0 Then GoTo ExitOfForLoop_{identifier{
      IndexValue -= StepValue
      GoTo StartOfForLoop_{identifier}:
  End If
ExitOfForLoop_{identifier}:
```
