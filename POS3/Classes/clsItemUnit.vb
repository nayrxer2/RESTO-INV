Imports System.Data.SqlClient
Public Class clsItemUnit
    Public FLDItemCode As Integer
    Public FLDItemName As String
    Public FLDUnitCode As String
    Public FLDUnitName As String
    Public FLDUnitRatio As Byte
    Public FLDUnitAssign As String
    ' Public FLDStoreID As Integer



    Public Function getItemRatio(FLDItemCode)
        Dim sQuery As String = "SELECT * FROM TBLItemUnit where FLDItemCode =" & FLDItemCode
        Dim list As List(Of clsItemUnit) = New List(Of clsItemUnit)
        Using oConnection As New SqlConnection(modGeneral.DBconnection)
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand()
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    Dim _cls = New clsItemUnit
                    While oReader.Read
                        With _cls
                            '.FLDItemCode = oReader("FLDItemCode")
                            '.FLDItemName = oReader("FLDItemName")
                            '.FLDUnitCode = oReader("FLDUnitCode")
                            '.FLDUnitName = oReader("FLDUnitName")
                            .FLDUnitRatio = oReader("FLDUnitRatio")
                            '.FLDUnitAssign = oReader("FLDUnitAssign")
                            list.Add(_cls)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + ":" + "Fetching unit ratio")
            End Try
        End Using
        Return list
    End Function
End Class
