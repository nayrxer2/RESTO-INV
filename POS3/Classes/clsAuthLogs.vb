Imports System.Data.SqlClient
Public Class clsAuthLogs
    Public FLDStoreID As Integer
    Public FLDDateID As Integer
    Public FLDShiftID As Integer
    Public FLDTerminal As Integer
    Public FLDInvoiceNumber As Integer
    Public FLDALDateTime As DateTime
    Public FLDUsername As String
    Public FLDALAction As String
    Public FLDALReason As String
    Public FLDALCMeal As Byte

    '----3/24/2021
    Public Function authLog()
        Dim list As List(Of clsAuthLogs) = New List(Of clsAuthLogs)
        Dim sQuery As String = "INSERT INTO TBLAuthorizationLog(FLDStoreID, FLDDateID, FLDShiftID, 
                                        FLDTerminal, FLDInvoiceNumber, FLDUsername, FLDALAction, FLDALReason, FLDALDateTime, FLDALCMeal)                                       
                                VALUES(@FLDStoreID, @FLDDateID, @FLDShiftID, @FLDTerminal, @FLDInvoiceNumber, 
                                        @FLDUsername, @FLDALAction, @FLDALCMeal, 
                                        GETDATE(), @FLDALCMeal)"

        Using oConnection As New SqlConnection(DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    With oCommand
                        .Parameters.AddWithValue("@FLDStoreID", FLDStoreID)
                        .Parameters.AddWithValue("@FLDDateID", FLDDateID)
                        .Parameters.AddWithValue("@FLDShiftID", FLDShiftID)
                        .Parameters.AddWithValue("@FLDTerminal", FLDTerminal)
                        .Parameters.AddWithValue("@FLDInvoiceNumber", FLDInvoiceNumber)
                        '.Parameters.AddWithValue("@FLDALDateTime", FLDALDateTime)
                        .Parameters.AddWithValue("@FLDUsername", FLDUsername)
                        .Parameters.AddWithValue("@FLDALAction", FLDALAction)
                        .Parameters.AddWithValue("@FLDALReason", FLDALReason)
                        .Parameters.AddWithValue("@FLDALCMeal", FLDALCMeal)
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
End Class
