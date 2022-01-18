Imports System.Data.SqlClient
Public Class Customers
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yuvas\Documents\CarRentalProjectDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CustPhoneTb.Text = "" Or CustAddressTb.Text = "" Or CustNameTb.Text = "" Then
            MsgBox("Missing Data")
        Else
            Try
                Con.Open()
                Dim query = "insert into CustomerTbl values('" & CustNameTb.Text & "','" & CustAddressTb.Text & "','" & CustPhoneTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Customer Successfully Saved")
                Con.Close()
                Clear()
                populate()
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub populate()
        Con.Open()
        Dim sql = "select * from CustomerTbl"
        Dim cmd = New SqlCommand(sql, Con)
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        CustomerDgv.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Clear()
        CustNameTb.Text = ""
        CustAddressTb.Text = ""
        CustPhoneTb.Text = ""
    End Sub

    Private Sub Customers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Clear()
    End Sub
    Dim key = 0
    Private Sub CustomerDgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles CustomerDgv.CellMouseClick
        Dim row As DataGridViewRow = CustomerDgv.Rows(e.RowIndex)
        CustNameTb.Text = row.Cells(1).Value.ToString
        CustAddressTb.Text = row.Cells(2).Value.ToString
        CustPhoneTb.Text = row.Cells(3).Value.ToString
        If CustNameTb.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Select The Customer")
        Else
            Try
                Con.Open()
                Dim query = "delete from CustomerTbl where CustId= " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Customer Successfully Deleted")
                Con.Close()
                Clear()
                populate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CustNameTb.Text = "" Or CustAddressTb.Text = "" Or CustPhoneTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                Con.Open()
                Dim query = "update CustomerTbl set CustName= '" & CustNameTb.Text & "' , CustAdd='" & CustAddressTb.Text & "',CustPhone='" & CustPhoneTb.Text & "' where CustId=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Customer Successfully Updated")
                Con.Close()
                Clear()
                populate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim Obj = New Cars
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Rent
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim Obj = New Returns
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim Obj = New Login
        Obj.Show()
        Me.Hide()
    End Sub
End Class