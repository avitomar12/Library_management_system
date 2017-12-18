Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ussr = "admin"
        Dim pass = "admin123"
        Dim us_r = TextBox1.Text()
        Dim pa_ss = TextBox2.Text()
        If (Ussr = us_r And pass = pa_ss) Then
            Form2.Show()
            Me.Hide()

        Else
            Me.Close()
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
