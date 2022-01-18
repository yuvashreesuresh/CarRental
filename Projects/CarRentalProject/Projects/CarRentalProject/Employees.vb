Imports System.Data.SqlClient
Public Class Employees
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yuvas\Documents\CarRentalProjectDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub populate()
        Con.Open()
        Dim sql = "select * from EmployeeTbl"
        Dim cmd = New SqlCommand(sql, Con)
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        EmployeeDgv.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Clear()
        EmpName.Text = ""
        EmpPassTb.Text = ""
        Key = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If EmpName.Text = "" Or EmpPassTb.Text = "" Then
            MsgBox("Missing Data")
        Else
            Try
                Con.Open()
                Dim query = "insert into EmployeeTbl values('" & EmpName.Text & "','" & EmpPassTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Employee Successfully Saved")
                Con.Close()
                Clear()
                populate()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Clear()
    End Sub
    Dim Key = 0
    Private Sub EmployeeDgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles EmployeeDgv.CellMouseClick
        Dim row As DataGridViewRow = EmployeeDgv.Rows(e.RowIndex)
        EmpName.Text = row.Cells(1).Value.ToString
        EmpPassTb.Text = row.Cells(2).Value.ToString
        If EmpName.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Key = 0 Then
            MsgBox("Select The Employee")
        Else
            Try
                Con.Open()
                Dim query = "delete from EmployeeTbl where EmpId= " & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Employee Successfully Deleted")
                Con.Close()
                Clear()
                populate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If EmpName.Text = "" Or EmpPassTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                Con.Open()
                Dim query = "update EmployeeTbl set EmpName= '" & EmpName.Text & "' , EmpPass='" & EmpPassTb.Text & "' where EmpId=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Employee Successfully Updated")
                Con.Close()
                Clear()
                populate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub
End Class