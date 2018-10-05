## AbstractInnerStructureProvider
This abstract class provides the common functionality for supplying the internal structures of a block.
Allowing the block specific functions to providing by the implementing classes.

### FullBlock
The `fullblock` describes the entire span of the block.
Eg
```vbnet
If expr Then
  ...
End If
```
```vbnet
Try
  ...
End Try
```
```
Select Case expr
  ...
End Select
```

#### FullBlockHeader
A full block header is the first statement of the block, which categories the block's functionality.
eg.
```vbnet
If expr Then
```
```vbnet
Try
```
```
Select Case expr
```

#### EndBlockStatement
The end block statement is part of the block, the delimits the end of the block structure.
eg.
```vbnet
End If
```
```vbnet
End Try
```
```vbnet
End Select
```
--------

### Internal Structures
The abstraction of providing the internal structure of the block, is broken into three distinct sections.
 * Inner Blocks
 * Preamble
 * Epilogue

This is due to the blocks not conforming to a common pattern or interface.

--------

#### The Inner Blocks
* An inner block is the section of the block that has potentially multiple sections.
  * eg `Case ... `'s in a `Select Case` block.
  * eg `ElseIf expr Then` in a `If ... Then` block   
  * Generally will appear in a block structure.
```vbnet
Select Case value
  Case 0
  Case 1
  Case 2
End Select
```

##### Inner Block
    
```vbnet
 Case 0
   ' comment
   code
   ' commment
```
###### Inner Block Header
This is the first statement of the inner block.
Eg `ElseIf expr Then`, `Case 0`, `Catch ex As Exception`.

--------

#### The Epilogue 
  * Some blocks don't encompass of the structure of the block within the inner blocks.
    In those cases, it usual as some form of preamble. 
    * This is an internal section of the block, which is before first occurrance of
      * inner block
      * prologue block
      * end of block statement 
    * May not appear in all block structures.
```vbnet
If expr Then
  ' comment
  code
  ' comment
```
##### Preamble Header
This is the first statement of the preamble.
Eg `If expr Then`

--------

#### The Epilogue 

Along the same lines as the preamble, thhis is an internal section of the block which is before the end of block statement and after the ...
  * the last inner block.
  * the preamble, if no inner blocks are present.
    * eg
    ```vb
    If expr Then
      ' preamble
    Else
      ' prologue
    End If
    ```   
    * Other examples or `Case Else` and `Finally` sections.
  * This section may not appear in all form of block structures. 

##### Epilogue Header
This is the first statement of the Epilogue, typically describing an optional last section of the block.
Eg `Else`, `Case Else`,`Finally`
