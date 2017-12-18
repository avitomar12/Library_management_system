Imports MySql.Data.MySqlClient
Public Class Form5
    Dim conn As New MySqlConnection
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim da As MySqlDataAdapter
        Dim nob As Integer
        Dim quan As Integer
        Dim ds As New DataSet

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
        Dim cmd3 As New MySqlCommand(String.Format("Select `Number_of_book` from `studentinfo` where `Enrolment_ID` = '{0}' ", TextBox2.Text), conn)
        cmd3.ExecuteNonQuery()
        da = New MySqlDataAdapter(cmd3)

        da.Fill(ds, "studentinfo")

        nob = CInt(ds.Tables(0).Rows(0).Item(0))


        Dim cmd4 As New MySqlCommand(String.Format("Select `Quantity` from `tblbook` where `BookID` = '{0}' ", TextBox1.Text), conn)
        cmd4.ExecuteNonQuery()
        da = New MySqlDataAdapter(cmd3)

        da.Fill(ds, "studentinfo")
        quan = CInt(ds.Tables(0).Rows(0).Item(0))

        If quan <= 0 Then
            MsgBox("Not Enough no. of book")
        ElseIf nob <= 0 Then
            MsgBox("You Can't issue book! already issued book 4 books")
        Else
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO `Issuebook` (`Enrollment_ID` ,`BookID`) VALUES ('{0}' , '{1}')", TextBox2.Text, TextBox1.Text), conn)
            Dim cmd1 As New MySqlCommand(String.Format("Update `tblbook` set `Quantity`=`Quantity`-1 where `BookID`= '{0}' ", TextBox1.Text), conn)
            Dim cmd2 As New MySqlCommand(String.Format("update `studentinfo` set `Number_of_book`=`Number_of_book`-1 where `Enrolment_ID`= '{0}' ", TextBox2.Text), conn)
            cmd.ExecuteNonQuery()
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()

        End If



        Label5.Text = "Book Issued"
        conn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class