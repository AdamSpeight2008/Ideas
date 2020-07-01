Imports System

Class C
  Shared  Public Sub Main()
     'scending_ForRange(SByte.MinValue, SByte.MaxValue, 32)
      Descending_ForRange(SByte.MaxValue, SByte.MinValue, -32)
 End Sub
        
    Private Shared Function Modus _ 
            ( StartValue As Long,
                EndValue As Long,
            StepValue As Long) As Long
        Dim Delta = Math.Abs( CLng(EndValue) - CLng(StartValue))+1
        Return	(Delta Mod StepValue) +
        		(StartValue Mod StepValue) +
        		(EndValue Mod StepValue)
    End Function
    
    shared Sub Ascending_ForRange _ 
            ( StartValue As Long,
                EndValue As Long,
            StepValue As Long)
                    Console.WriteLine(NameOf(Ascending_ForRange))
        Dim LastValue = CSByte( EndValue - Modus(StartValue,EndValue,StepValue))
        Console.WriteLine(LastValue)
        
        Dim IndexValue = StartValue
        StartOf_Loop:
        Dim cmp = IndexValue.CompareTo(LastValue)
        If cmp <= 0 Then
            Console.Write($"{IndexValue}, ")
            If cmp >= 0 Then GoTo Exit_Loop
            IndexValue += StepValue
            GoTo StartOf_Loop
        End If
        Exit_Loop:
            Console.WriteLine()
    End Sub
        shared Sub Descending_ForRange _ 
            ( StartValue As Long,
                EndValue As Long,
               StepValue As Long)
            Console.WriteLine(NameOf(Descending_ForRange))
       Dim LastValue = EndValue + Modus(StartValue,EndValue,StepValue)
        Console.WriteLine(LastValue)
          Dim IndexValue = StartValue
        StartOf_Loop:
        Dim cmp = IndexValue.CompareTo(LastValue)
        If cmp >= 0 Then
            Console.Write($"{IndexValue}, ")
            If cmp <= 0 Then GoTo Exit_Loop
            IndexValue += StepValue
            GoTo StartOf_Loop
        End If
        Exit_Loop:
                Console.WriteLine()
    End Sub
End Class
