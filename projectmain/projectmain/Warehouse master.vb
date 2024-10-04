Public Class Warehouse_master
    Dim flag As Integer = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao As New DAOclass
        If ComboBox2.Text <> "" Then
            If ComboBox3.Text <> "" Then
                If ComboBox1.Text <> "" Then
                    If DateTimePicker1.Text <> "" Then

                        If flag = 0 Then
                            Dim f As Integer = 0

                            f = dao.validate("select warehouse_no from warehouse where warehouse_no='" & ComboBox2.Text & "'")
                            If f = 1 Then
                                MessageBox.Show("Unable to create Record (Already in the list)")
                                ComboBox2.Focus()
                            Else
                                dao.modifydata("insert into warehouse (warehouse_no,commodity_name,ship_name,dock_date) values ('" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox1.Text & "','" & DateTimePicker1.Text & "') ")
                                MessageBox.Show("Record Inserted!")
                            End If
                        Else
                            'update
                            Dim c As Integer = MessageBox.Show("Do you want to update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If c = 6 Then
                                Dim d As New DAOclass
                                dao.modifydata("update warehouse set commodity_name='" & ComboBox3.Text & "',ship_name='" & ComboBox1.Text & "',dock_date='" & DateTimePicker1.Text & "' where warehouse_no='" & ComboBox2.Text & "'")
                                loaddata()
                                MessageBox.Show("Record updated")
                                Button1_Click(sender, e)
                            End If


                        End If

                    Else
                        MessageBox.Show("Enter valid Dock date")
                        DateTimePicker1.Focus()
                    End If
                Else
                    MessageBox.Show("Enter valid Ship Name")
                    ComboBox1.Focus()
                End If
            Else
                MessageBox.Show("Enter valid Commodity Name")
                ComboBox3.Focus()
            End If
        Else
            MessageBox.Show("Enter valid Warehouse No.")
            ComboBox2.Focus()
        End If
        loaddata()
    End Sub
    Public Sub loaddata()
        Dim ds As New Data.DataSet
        Dim d As New DAOclass
        ds = d.loaddata("select * from warehouse")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Warehouse_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        loadbox2()
        loadbox1()
        loadbox3()
        Button1_Click(sender, e)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As Integer = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If c = 6 Then
            Dim d As New DAOclass
            d.modifydata("Delete from warehouse where warehouse_no='" & ComboBox2.Text & "'")
            loaddata()
            MessageBox.Show("Record deleted!")
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.Text = ""
        flag = 0
        Button4.Enabled = False
        ComboBox2.Focus()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            ComboBox2.Text = DataGridView1.Item("warehouse_no", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox3.Text = DataGridView1.Item("commodity_name", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox1.Text = DataGridView1.Item("ship_name", DataGridView1.CurrentCell.RowIndex).Value
            DateTimePicker1.Text = DataGridView1.Item("dock_date", DataGridView1.CurrentCell.RowIndex).Value
            flag = 1
            Button4.Enabled = True
        End If
    End Sub
    Private Sub textbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown, Button3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.name = ComboBox2.Name Then
                ComboBox3.Focus()
            ElseIf sender.name = ComboBox3.Name Then
                ComboBox1.Focus()
            ElseIf sender.name = ComboBox1.Name Then
                DateTimePicker1.Focus()
            ElseIf sender.name = DateTimePicker1.Name Then
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub loadbox2()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select distinct(warehouse_no) from jetty")
            ComboBox2.DisplayMember = "warehouse_no"
            ComboBox2.ValueMember = "warehouse_no"
            ComboBox2.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
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
    Private Sub loadbox3()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select distinct(commodity_name),HSN_code from commodity")
            ComboBox3.DisplayMember = "commodity_name"
            ComboBox3.ValueMember = "HSN_code"
            ComboBox3.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    'Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    '    If TextBox4.Text <> "" Then
    '        loaddata()
    '    Else
    '        Dim ds As New Data.DataSet
    '        Dim d As New DAOclass
    '        ds = d.loaddata("select * from warehouse where ship_name like '%" & TextBox4.Text & "%'")
    '        DataGridView1.DataSource = ds.Tables(0)
    '    End If
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    TextBox4.Enabled = True
    'End Sub
End Class