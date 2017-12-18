Imports MySql.Data.MySqlClient
Public Class Form9
    Dim conn As New MySqlConnection
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            Label5.Text = "Please enter correct data!"
            Exit Sub
        End If
        Dim DatabaseName As String = "library_db"
        Dim server As String = "127.0.0.1"
        Dim userName As String = "root"
        Dim password As String = "mysql"
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = $"server={server }; user id={userName }; password={password }; database={DatabaseName }; pooling=false"
        Try
            conn.Open()
            Label5.Text = "connected to " + DatabaseName
        Catch ex As Exception

            Label5.Text = ex.Message
        End Try
        Dim cmd As New MySqlCommand($"Delete from `issuebook` where `Enrollment_ID` = '{TextBox2.Text}' and `BookID`='{TextBox1.Text}' ", conn)

        Dim cmd1 As New MySqlCommand(String.Format("Update `tblbook` set `Quantity`=`Quantity`-1 where `BookID`= '{0}' ", TextBox1.Text), conn)
        Dim cmd2 As New MySqlCommand(String.Format("update `studentinfo` set `Number_of_book`=`Number_of_book`-1 where `Enrolment_ID`= '{0}' ", TextBox2.Text), conn)

        cmd.ExecuteNonQuery()
        cmd1.ExecuteNonQuery()
        cmd2.ExecuteNonQuery()
        Label5.Text = "Book Returned"
        conn.Close()
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class