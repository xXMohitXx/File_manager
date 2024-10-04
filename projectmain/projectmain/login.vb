Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d As New DAOclass
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim d As New DAOclass
        Dim obj As SqlClient.SqlDataReader
        Dim flag As Boolean = False
        obj = d.getdata("select * from login where u_name ='" & TextBox1.Text & "' and u_pass ='" & TextBox2.Text & "'")
        While obj.Read
            flag = True
        End While
        d.closeconnection()

        If flag Then
            Dim mainpage As New Form1
            Me.Hide()
            mainpage.Show()
        Else
            MessageBox.Show("Enter valid Username and Password. ")
            TextBox2.Text = ""
            TextBox1.Focus()
        End If
        Button2_Click(sender, e)
        TextBox1.Focus()
    End Sub

    Private Sub textbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, Button1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.name = TextBox1.Name Then
                TextBox2.Focus()
            ElseIf sender.name = TextBox2.Name Then
                Button1_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub
End Class