# VB Language Ideas

This repo is a collection of ideas and concepts, related to the Visual Basic programming language.

+------ + :------------------------------- + :-------------------------------------------------------------------------------- +
|  No.  | **Title**                        | **Synopsis**                                                                      
+-----: + -------------------------------- + :-------------------------------------------------------------------------------- +
|   1   | Default Optional Parameters      | `Optional arg As String` <br />[Default Optional Parameters](/Default_Optional_Parameters.md)                    
+------ + -------------------------------- + --------------------------------------------------------------------------------- +
|   2   | Deresticted Operators            | Removes the restriction on compliementy-pair of operators. Such `<` and `>`. <br />  [Derestricted Operators]("Derestricted_Operators.md")      
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   3   | TypeOf Many                      | `TypeOf expr Is (Of T0 .., Tn)` <br /> Extend `TypeOf` to cover multiple types.                      
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   4   | Range Syntax                     | `fromExpr To uptoExpr` <br /> `fromExpr To uptoExpr Step stepExpr` <br /> [Range Expression](RangeExpressions.md)                      
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   5   | ZIP Query Syntax                 | `From x In xs Zip y In ys` <br /> [Linq Zip Clause]("Linq_Zip_Clause.md")
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   6   | For Each With Index              | `For Each x As Tx With idx In xs` <br /> For-Each block that also includes the sequence index of the item.                      
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   7   | Guarded Statements               | `statement When expr`                                          
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   8   | With Clause                      | `With { ... }` <br /> recursive clause.
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|   9   | Immutable                        | [Immutable](Immutable.md).
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  10   | Structural Inheritance           | [Structure Inheritance](StructureInheritance.md)
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  11   | Const Blocks                     | ```Const type ... End Const ``` <br />[Constant Blocks](Constant_Block.md)
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  12   | Un/Checked Expressions           | `Unchecked expr` <br /> don't use overflow checks. <br /> [UnChecked Expressions](UnChecked_Expression.md)
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  13   | Un/Cheked Blocks                 | `Unchecked ... End Unchecked` { ... }` <br /> don't use overflow checks within this block. <br /> [UnChecked Blocks](UnChecked_Blocks.md)
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  14   | Type Clause                      | `Case Is type` <br /> `Case Is type Into expr` <br /> `Case IsNot type` <br /> Extend Case clauses to cover type selection. <br /> [Type Clause](Type_Clauses.md)
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  15   | Into Declarations                | `(TypeOf expr Is Example Into thisExample` <br /> Put some aspect of expression (on the left side) into the declaration / expression on the right side.
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  16   | Out Declarations                 | `Integer.TryParse( text, Out value )` <br /> Declare a variable whilst calling a method.
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  17   | Flags Enum Operators             | Operators that make it easier to make use of `<flags> Enum`. <br /> IsFlagsSet / SetFlag / ClearFlag / AnyFlagSet <br /> [Flags Enum Operators](Flags_Enum_Operators.md)
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +
|  18   | ???                              | ???
+ ----- + -------------------------------- + --------------------------------------------------------------------------------- +