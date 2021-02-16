Public Class ucTitle
    Private Sub ucTitle_Load(sender As Object, e As EventArgs) Handles Me.Load
        'frmName = Form.ActiveForm.Name
        Me.Dock = DockStyle.Top
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmName = Form.ActiveForm.Name
        'Dim frm As Form

        'If frm.Name = frmName Then
        '    frm.Close()
        'End If

        'frm.Close()
        'Dim frmControl As Control = DirectCast(Controls(frmName), Form)
        'frm.Close()
        'MessageBox.Show(frmName)


        'MessageBox.Show(Form.ActiveForm.Name)
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
