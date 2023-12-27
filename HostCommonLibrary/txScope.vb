Imports System.Transactions

Public Class TxScope
    Private ReadOnly txscope As TransactionScope
    Private isComplete As Boolean

    Public Sub New()
        isComplete = True
    End Sub
    Public Sub New(ByVal tx As TransactionScope)
        txscope = tx
        isComplete = True
    End Sub
    Protected Sub Abort()
        isComplete = False
    End Sub
    Protected Sub Rollback()
        isComplete = False
        If (Not txscope Is Nothing) Then
            txscope.Dispose()
        End If
    End Sub
    Protected Sub Complete()
        isComplete = isComplete And True
        If (isComplete And (Not txscope Is Nothing)) Then
            Try
                txscope.Complete()
            Catch ex As Exception
            Finally
                txscope.Dispose()
            End Try
        End If
    End Sub
End Class
