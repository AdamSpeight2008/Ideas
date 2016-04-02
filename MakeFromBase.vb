imports System.Enumerable

abstract class Pile(of T)

  friend readonly property Tx as T()

  inherits private sub new( optional Tx as IEnumerable(Of T) )
    if( Tx Is Nothing ) ehen 
      Me.Tx = Array.Empty(Of T)
    else
      Me.Tx = Tx.ToArray
    end if
  end sub

  make public shared readonly property Empty() as new @Pile(of T)

  public function AsEnumerable() as IEnumerable(of T)
    return Tx.AsEnumerable
  end function

  make public shared operator + ( T0 as T , Tx as @Pile(Of T) ) as @Pile(oF T)
    return new @Pile<T>( Repeat( T0 , 1 ).Concat( Tx.AsEnumerable ) )
  end operator 

  make public shared operator + ( Tx as @Pile(Of T) , T0 as T ) as @Pile(oF T)
    return new @Pile<T>( Tx.AsEnumerable.Concat( Repeat( T0 , 1 ) )
  end operator 

  make public shared operator + ( Tx0 as T , Tx1 as @Pile(Of T) ) as @Pile(oF T)
    return new @Pile<T>( Tx.AsEnumerable.Concat( Tx1.AsEnumerable ) )
  end operator 

end class

class Tokens
  inheirts Pile(of Token)

end class

class Issues
  inherits Pile(of Issue)

end class
