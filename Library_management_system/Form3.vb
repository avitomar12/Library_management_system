Imports MySql.Data.MySqlClient
Public Class Form3
    Dim conn As New MySqlConnection
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            Label11.Text = "Please enter correct data!"
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
            Label11.Text = "connected to " + DatabaseName
        Catch ex As Exception

            Label11.Text = ex.Message
        End Try
        Dim cmd As New MySqlCommand(String.Format("INSERT INTO `studentinfo` (`Name`, `Department` ,`Enrolment_ID` , `Email_id`, `Address`,`Course`,`Number_of_book`,`Phone_No`, `Fine`) VALUES ('{0}' , '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}')", TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, "0"), conn)
        cmd.ExecuteNonQuery()
        Label11.Text = "data inserted!"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

        conn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs)

    End Sub
End Class