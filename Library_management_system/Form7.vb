﻿Imports MySql.Data.MySqlClient
Public Class Form7
    Dim conn As New MySqlConnection
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim conn As New MySqlConnection

        Dim DatabaseName As String = "library_db"
        Dim server As String = "127.0.0.1"
        Dim userName As String = "root"
        Dim password As String = "mysql"
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = $"server={server }; user id={userName }; password={password }; database={DatabaseName }; pooling=false"
        Try
            conn.Open()
            Label4.Text = "Connected to " + DatabaseName
        Catch ex As Exception

            Label4.Text = ex.Message
        End Try
        If TextBox1.Text <> "" Then
            Dim cmd As New MySqlCommand(String.Format("Select * from `tblbook` where `BookID` = '{0}' ", TextBox1.Text), conn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(ds, "Users")

            DataGridView1.DataSource = ds.Tables(0)

            conn.Close()
        Else
            Dim cmd As New MySqlCommand(String.Format("Select * from `tblbook` "), conn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(ds, "Users")

            DataGridView1.DataSource = ds.Tables(0)

            conn.Close()
        End If


    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class