Imports System.Data.SqlClient
Public Class Login
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yuvas\Documents\CarRentalProjectDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UnameTb.Text = "" Then
            MsgBox("Enter the Username")
        ElseIf PasswordTb.Text = "" Then
            MsgBox("Enter the Password")
        Else
            Con.Open()
            Dim query = "select * from EmployeeTbl where EmpName='" & UnameTb.Text & "' and EmpPass='" & PasswordTb.Text & "' "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Wrong Username Or Password")
            Else
                Dim cr = New Cars
                cr.Uname = UnameTb.Text
                cr.Show()
                Me.Hide()
            End If
            Con.Close()
        End If
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim Adm = New AdminLogin
        Adm.Show()
        Me.Hide()
    End Sub
End Class