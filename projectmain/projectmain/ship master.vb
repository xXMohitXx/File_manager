Public Class ship_master
    Dim flag As Integer = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao As New DAOclass
        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then


                    If flag = 0 Then
                        Dim f As Integer = 0

                        f = dao.validate("select ship_number from ship where ship_number='" & TextBox1.Text & "'")
                        If f = 1 Then
                            MessageBox.Show("Unable to create Record (Already in the list)")
                            TextBox1.Focus()
                        Else
                            dao.modifydata("insert into ship(ship_number,ship_name,ship_capacity) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "') ")
                            MessageBox.Show("Record Inserted!")
                        End If
                    Else
                        Dim c As Integer = MessageBox.Show("Do you want to update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If c = 6 Then
                            Dim d As New DAOclass
                            dao.modifydata("update ship set ship_name='" & TextBox2.Text & "',ship_capacity='" & TextBox3.Text & "' where ship_number='" & TextBox1.Text & "'")
                            loaddata()
                            MessageBox.Show("Record updated")
                            Button1_Click(sender, e)
                        End If


                    End If


                Else
                    MessageBox.Show("Enter valid Ship capacity")
                    TextBox3.Focus()
                End If
            Else
                MessageBox.Show("Enter valid Ship Name")
                TextBox2.Focus()
            End If
        Else
            MessageBox.Show("Enter valid Ship No.")
            TextBox1.Focus()
        End If
        loaddata()
    End Sub
    Public Sub loaddata()
        Dim ds As New Data.DataSet
        Dim d As New DAOclass
        ds = d.loaddata("select * from ship")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub ship_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("ship_number", DataGridView1.CurrentCell.RowIndex).Value
            TextBox2.Text = DataGridView1.Item("ship_name", DataGridView1.CurrentCell.RowIndex).Value
            TextBox3.Text = DataGridView1.Item("ship_capacity", DataGridView1.CurrentCell.RowIndex).Value
            flag = 1
            Button4.Enabled = True
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As Integer = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If c = 6 Then
            Dim d As New DAOclass
            d.modifydata("Delete from ship where ship_number=" & TextBox1.Text)
            loaddata()
            MessageBox.Show("Record deleted!")
            Button1_Click(sender, e)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        flag = 0
        Button4.Enabled = False
        TextBox1.Focus()
    End Sub
    Private Sub textbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown, Button3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.name = TextBox1.Name Then
                TextBox2.Focus()
            ElseIf sender.name = TextBox2.Name Then
                TextBox3.Focus()
            ElseIf sender.name = TextBox3.Name Then
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

End Class