Public Class ucTitle
    Private Sub ucTitle_Load(sender As Object, e As EventArgs) Handles Me.Load
        'frmName = Form.ActiveForm.Name
        Me.Dock = DockStyle.Top
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim frmName = Form.ActiveForm.Name
        Dim ParentForm = Me.Parent

        If ParentForm.Name = frmName Then
            End
        End If
    End Sub

    Public Function getform(ByVal Formname As String) As Form
        Dim t As Type = Type.GetType(Formname) ', True, True)
        If t Is Nothing Then
            Dim Fullname As String = Application.ProductName & "." & Formname
            t = Type.GetType(Fullname, True, True)
        End If
        Return CType(Activator.CreateInstance(t), Form)
    End Function
End Class
