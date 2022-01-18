Public Class AdminLogin
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If PasswordTb.Text = "" Then
            MsgBox("Enter Password")
        ElseIf PasswordTb.Text = "Admin" Then
            Dim Emp = New Employees
            Emp.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Password. Contact the Admin")
        End If
    End Sub
End Class