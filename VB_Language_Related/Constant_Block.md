## Unchecked / Checked Blocks

### Synopsis

To have the ability to express that the following section, should be consided as declaring constants.    
Akin to defining a set of enum values.

```vbnet
Friend Const String
  A = "Apple"
  B = "Banana"
  C = "Coconut"
End Const
```

All constants defined within the `Const Block`
  * have the same type (in the example `String`).
  * have the same scope of visibilty. (in the examle `Friend`)