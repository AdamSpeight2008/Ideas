## Clause Syntax

#### Synopsis

A `clause` represents a conditional pattern that must be true, for the following statements to be executed.



##### Case Clause Forms
* Case Clause forms
  * `CaseClauseSyntax : ClauseSyntax ::= "Case" ;;
  * **Relational**    
    * `Relational_CaseClauseSyntax : CaseClauseSyntax ::= ( isOrIsNot : KeywordSyntax ) ( cmpOp : ComparisionOperatorToken ) ;; `     
      * `Case Is     ( cmpOP : ComparisionOperationToken ) ( expr : Expression )`    
        * `Is_CaseClauseSyntax : Relational_CaseCklauseSyntax ::= (expr : Expression)` ;; `
      * `Case IsNot  ( cmpOP : ComparisionOperationToken ) ( expr : Expression )`
        * `IsNot_CaseClauseSyntax : RelationalCaseClauseSyntax ::= (expr : Expression)` ;;`    
    * **Type Relational**    
      * `Case Is      ( type : TypeSyntax ) (Into ( expr : Expression ))?`
        * `Type_Is_ClauseSyntax : Relational_ClauseSyntax ::= ( type : TypeSyntax ) ;;    
          * See Also;- [Into Syntax]()    
        * `Case IsNot   (type : TypeSyntax)`   
          * `Type_IsNot_ClauseSyntax : Relational_ClauseSyntax ::= ( type : TypeSyntax ) ;;`    

    * **Constant**
      * `Case "A"`
      * `Constant_ClauseSyntax : ClauseSyntax ::= ( constExpr : Expression(Of Const) )  ;; `    

    * **Range**
      * `Case  "A"c To "F"c`    
        * `Range_ClauseSyntax : ClauseSyntax ::= ( range : RangeSyntax ) ;; `
      * `Case  0 To 100 Step 2`    
        * `StepRange_ClauseSyntax : Range_ClauseSyntax ::= "Step" ( step : ExpressionSyntax ) ;; `
        * Note: [RangeSyntax](RangeExpression.md)   
        
    * **List of Clauses**
      * `Case    clause (","c clause)*`    
      * `Clauses : CommaSeperatedList(Of ClauseSyntax) ;;`    

    * **Guarded Clause**    
      * This is an suffix clause, that inicates the left-side only applies in the condition is also true.
      * ` GuardedClause  : ClauseSyntax ::= ( thisClause : ClauseSyntax ) ( whenCondition : WhenExpressionSyntax ) ;;'
      * See Also;- [Guarded Statements](GuardedStatements.md)