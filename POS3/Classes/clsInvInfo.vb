Imports System.Data.SqlClient
Public Class clsInvInfo
    Public FLDInvID As Integer
    Public FLDInventoryNum As Integer
    Public FLDInvRef As Integer
    Public FLDDelRef As Integer
    Public FLDTransRef As Integer
    Public FLDRetRef As Integer
    Public FLDDtTmStart As String
    Public FLDDtTmEnd As String
    Public FLDDateIDStart As Integer
    Public FLDDateIDEnd As Integer
    Public FLDStoreID As Integer

    Public invStatus As String
    Public invSheetID As Integer
    Public Function createInventory() As Boolean
        Dim list As List(Of clsInvInfo) = New List(Of clsInvInfo)
        'Dim sQuery As String = "INSERT INTO TBLInvInfo
        '                                    (FLDInvID, FLDInventoryNum, FLDInvRef, FLDDelRef, FLDTransRef, 
        '                                    FLDRetRef, FLDDtTmStart, FLDDtTmEnd, FLDDateIDStart, FLDDateIDEnd, FLDStoreID)
        '                        VALUES (((SELECT COUNT(*) FROM [TBLInvInfo])+1), @FLDInventoryNum, @FLDInvRef, @FLDDelRef,
        '                                    @FLDTransRef, @FLDRetRef, @FLDDtTmStart, @FLDDtTmEnd, @FLDDateIDStart, 
        '                                    @FLDDateIDEnd, @FLDStoreID)"
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand
                    With oCommand
                        .Connection = oConnection
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Inventory_Create"
                        .Parameters.AddWithValue("@FLDInventoryNum", FLDInventoryNum)
                        .Parameters.AddWithValue("@FLDInvRef", FLDInvRef)
                        .Parameters.AddWithValue("@FLDDelRef", FLDDelRef)
                        .Parameters.AddWithValue("@FLDTransRef", FLDTransRef)
                        .Parameters.AddWithValue("@FLDRetRef", FLDRetRef)
                        .Parameters.AddWithValue("@FLDDtTmStart", FLDDtTmStart)
                        .Parameters.AddWithValue("@FLDDtTmEnd", FLDDtTmEnd)
                        .Parameters.AddWithValue("@FLDDateIDStart", FLDDateIDStart)
                        .Parameters.AddWithValue("@FLDDateIDEnd", FLDDateIDEnd)
                        .Parameters.AddWithValue("@FLDStoreID", FLDStoreID)
                        .ExecuteNonQuery()
                        Return True
                    End With
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Return False
        End Using
    End Function

    Public Function updateInvStatus(invSheetID As String, invStatus As Integer)
        Dim listUpdate As List(Of clsInvInfo) = New List(Of clsInvInfo)
        Dim sQuery As String = "INSERT INTO TBLInvStatus (FLDStatus, FLDInvID) VALUES (@FLDStatus, @FLDInvID)"
        If MessageBox.Show("Are you sure you want to proceed to POST?") Then

            Using oConnection As New SqlConnection(modGeneral.DBconnection())
                Try
                    oConnection.Open()
                    Using oCommand As New SqlCommand(sQuery, oConnection)
                        With oCommand
                            .Parameters.AddWithValue("@FLDStatus", invStatus)
                            .Parameters.AddWithValue("@invStatus", invSheetID)
                            .ExecuteNonQuery()
                            Return True
                        End With
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Using
            Return False
        End If
    End Function
End Class
