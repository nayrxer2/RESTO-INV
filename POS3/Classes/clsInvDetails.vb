Imports System.Data.SqlClient
Public Class clsInvDetails
    'Public FLDInvDetailID As Integer
    'Public FLDCategory As String
    'Public FLDGroupCode As String
    Public FLDGroupName As String
    Public FLDItemCode As String
    Public FLDItemName As String
    Public FLDStart As Single
    Public FLDDeliver As Single
    Public FLDTransfer As Single
    Public FLDReturn As Single
    Public FLDProdUsed As Single
    Public FLDProdMade As Single
    'Public FLDAdjustment As Single
    Public FLDInvEndW As Single
    Public FLDInvEndF As Single
    Public FLDInvEndE As Single
    Public FLDInvEndT As Single
    Public FLDInvUsage As Single
    Public FLDPOSUsage As Single
    Public FLDMealUsage As Single
    Public FLDVariance As Single
    Public FLDUnitPrice As Decimal
    'Public FLDTotalVariance As Decimal
    Public FLDRemarks As String
    Public FLDInvID As Integer
    Public FLDInventoryNum As Integer
    Public FLDStoreID As Integer

    Public Function updateInvDetails() As Boolean
        'Dim list As List(Of clsInvDetails) = New List(Of clsInvDetails)
        'Dim squery As String = "UPDATE TBLInvDetail SET FLDInvEndW = @FLDInvEndW, FLDInvEndF = @FLDInvEndF, FLDInvEndE = @FLDInvEndE, FLDInvEndT = @FLDInvEndT WHERE FLDInvID =" &
        'Using oConnection As New SqlConnection(modGeneral.DBconnection)
        '    Try
        '        oConnection.Open()
        '        Using oCommand As New SqlCommand
        '            With oCommand
        '                .Parameters.AddWithValue("@FLDInvEndW", FLDInvEndW)
        '                .Parameters.AddWithValue("@FLDInvEndF", FLDInvEndF)
        '                .Parameters.AddWithValue("@FLDInvEndE", FLDInvEndE)
        '                .Parameters.AddWithValue("@FLDInvEndT", FLDInvEndT)
        '                .ExecuteNonQuery()
        '                Return True
        '            End With
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try
        '    Return True
        'End Using
    End Function
End Class
