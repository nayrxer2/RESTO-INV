Imports System.Data.SqlClient
Public Class clsInvInfo
    Public FLDInvID As Integer
    Public FLDInventoryNum As Integer
    Public FLDInvRef As String
    Public FLDDelRef As String
    Public FLDTransRef As String
    Public FLDRetRef As String
    Public FLDDtTmStart As DateTime
    Public FLDDtTmEnd As DateTime
    Public FLDDateIDStart As Integer
    Public FLDDateIDEnd As Integer
    Public FLDStoreID As Integer

    '----> table TBLInvStatus
    Public FLDStatus As String
    'Public invSheetID As Integer

    Public Function createInventory() As Boolean
        Dim list As List(Of clsInvInfo) = New List(Of clsInvInfo)
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
                        .Parameters.AddWithValue("@FLDDtTmStart", Date.Now)
                        .Parameters.AddWithValue("@FLDDtTmEnd", "")
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

    Public Function updateInvStatus()
        Dim listUpdate As List(Of clsInvInfo) = New List(Of clsInvInfo)
        Dim sQuery As String = "INSERT INTO TBLInvStatus (FLDStatus, FLDInvID) VALUES (@FLDStatus, @FLDInvID)"
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    With oCommand
                        .Parameters.AddWithValue("@FLDStatus", FLDStatus)
                        .Parameters.AddWithValue("@FLDInvID", FLDInvID)
                        .ExecuteNonQuery()
                        Return True
                    End With
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message + " " + "updateInvStatus")
            End Try
        End Using
        Return False
    End Function

    Public Function checkStatus() As List(Of clsInvInfo)
        Dim listUpdate As List(Of clsInvInfo) = New List(Of clsInvInfo)
        Dim squery As String = "SELECT * FROM TBLInvStatus"
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(squery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    Dim lu As clsInvInfo
                    While oReader.Read
                        lu = New clsInvInfo
                        With lu
                            .FLDStatus = oReader("FLDStatus")
                            .FLDInvID = oReader("FLDInvID")
                            listUpdate.Add(lu)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message + " " + "checkStatus")
            End Try
            Return listUpdate
        End Using
    End Function
End Class
