Public Class Jetty_master
    Dim flag As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.Text = ""
        TextBox4.Text = ""
        flag = 0
        Button4.Enabled = False
        TextBox1.Focus()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao As New DAOclass
        If TextBox1.Text <> "" Then
            If ComboBox1.Text <> "" Then
                If DateTimePicker1.Text <> "" Then
                    If TextBox4.Text <> "" Then

                        If flag = 0 Then
                            Dim f As Integer = 0

                            f = dao.validate("select jetty_no from jetty where jetty_no='" & TextBox1.Text & "'")
                            If f = 1 Then
                                MessageBox.Show("Unable to create Record (Already in the list)")
                                TextBox1.Focus()
                            Else
                                dao.modifydata("insert into jetty (jetty_no,ship_name,dock_date,warehouse_no) values ('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & DateTimePicker1.Text & "','" & TextBox4.Text & "') ")
                                MessageBox.Show("Record Inserted!")
                            End If
                        Else
                            'update
                            Dim c As Integer = MessageBox.Show("Do you want to update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If c = 6 Then
                                Dim d As New DAOclass
                                dao.modifydata("update jetty set ship_name='" & ComboBox1.Text & "',dock_date='" & DateTimePicker1.Text & "',warehouse_no='" & TextBox4.Text & "' where jetty_no='" & TextBox1.Text & "'")
                                loaddata()
                                MessageBox.Show("Record updated")
                                Button1_Click(sender, e)
                            End If


                        End If

                    Else
                        MessageBox.Show("Enter valid Warehouse No.")
                        TextBox4.Focus()
                    End If
                Else
                    MessageBox.Show("Enter valid Dock Date")
                    DateTimePicker1.Focus()
                End If
            Else
                MessageBox.Show("Enter valid Ship Name")
                ComboBox1.Focus()
            End If
        Else
            MessageBox.Show("Enter valid Jetty No.")
            TextBox1.Focus()
        End If
        loaddata()
    End Sub
    Public Sub loaddata()
        Dim ds As New Data.DataSet
        Dim d As New DAOclass
        ds = d.loaddata("select * from jetty")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Jetty_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        loadbox1()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As Integer = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If c = 6 Then
            Dim d As New DAOclass
            d.modifydata("Delete from jetty where jetty_no='" & TextBox1.Text & "'")
            loaddata()
            MessageBox.Show("Record deleted!")
            Button1_Click(sender, e)
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("jetty_no", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox1.Text = DataGridView1.Item("ship_name", DataGridView1.CurrentCell.RowIndex).Value
            DateTimePicker1.Text = DataGridView1.Item("dock_date", DataGridView1.CurrentCell.RowIndex).Value
            TextBox4.Text = DataGridView1.Item("warehouse_no", DataGridView1.CurrentCell.RowIndex).Value

            flag = 1
            Button4.Enabled = True
        End If
    End Sub
    Private Sub textbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, DateTimePicker1.KeyDown, TextBox4.KeyDown, Button3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.name = TextBox1.Name Then
                ComboBox1.Focus()
            ElseIf sender.name = ComboBox1.Name Then
                DateTimePicker1.Focus()
            ElseIf sender.name = DateTimePicker1.Name Then
                TextBox4.Focus()
            ElseIf sender.name = TextBox4.Name Then
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" Then
            Dim ds As New Data.DataSet
            Dim d As New DAOclass
            ds = d.loaddata("select ship_name from ship where ship_number=" & ComboBox1.SelectedValue)
            If ds.Tables(0).Rows.Count > 0 Then
                ComboBox1.Text = ds.Tables(0).Rows(0).Item(0)
            End If
        End If
    End Sub
    Private Sub loadbox1()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select distinct(ship_name),ship_number from ship")
            ComboBox1.DisplayMember = "ship_name"
            ComboBox1.ValueMember = "ship_number"
            ComboBox1.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
End Class