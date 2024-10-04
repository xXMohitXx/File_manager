Public Class Commodity_master
    Dim flag As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        flag = 0
        Button4.Enabled = False
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao As New DAOclass
        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then
                    If TextBox4.Text <> "" Then
                        If ComboBox1.Text <> "" Then
                            If ComboBox2.Text <> "" Then




                                If flag = 0 Then
                                    Dim f As Integer = 0

                                    f = dao.validate("select HSN_code from commodity where HSN_code='" & TextBox2.Text & "'")
                                    If f = 1 Then
                                        MessageBox.Show("Unable to create Record (Already in the list)")
                                        TextBox1.Focus()
                                    Else
                                        dao.modifydata("insert into commodity (commodity_name,HSN_code,weight,country_oforigin,ship_name,warehouse_no) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "') ")
                                        MessageBox.Show("Record Inserted!")
                                    End If
                                Else
                                    'update
                                    Dim c As Integer = MessageBox.Show("Do you want to update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    If c = 6 Then
                                        Dim d As New DAOclass
                                        dao.modifydata("update commodity set commodity_name='" & TextBox1.Text & "',weight='" & TextBox3.Text & "',country_oforigin='" & TextBox4.Text & "',ship_name='" & ComboBox1.Text & "',warehouse_no='" & ComboBox2.Text & "' where HSN_code='" & TextBox2.Text & "'")
                                        loaddata()
                                        MessageBox.Show("Record updated")
                                        Button1_Click(sender, e)
                                    End If

                                End If
                            Else
                                MessageBox.Show("Enter valid Warehouse No.")
                                ComboBox2.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter valid Ship Name")
                            ComboBox1.Focus()
                        End If

                    Else
                        MessageBox.Show("Enter valid Country")
                        TextBox4.Focus()
                    End If
                Else
                    MessageBox.Show("Enter valid Weight")
                    TextBox3.Focus()
                End If
            Else
                MessageBox.Show("Enter valid HSN Code")
                TextBox2.Focus()
            End If
        Else
            MessageBox.Show("Enter valid Commodity Name")
            TextBox1.Focus()
        End If
        loaddata()
    End Sub

    Public Sub loaddata()
        Dim ds As New Data.DataSet
        Dim d As New DAOclass
        ds = d.loaddata("select * from commodity")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Commodity_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        loadbox1()
        loadbox2()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As Integer = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If c = 6 Then
            Dim d As New DAOclass
            d.modifydata("Delete from commodity where HSN_code='" & TextBox2.Text & "'")
            loaddata()
            MessageBox.Show("Record deleted!")
            Button1_Click(sender, e)
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("commodity_name", DataGridView1.CurrentCell.RowIndex).Value
            TextBox2.Text = DataGridView1.Item("HSN_code", DataGridView1.CurrentCell.RowIndex).Value
            TextBox3.Text = DataGridView1.Item("weight", DataGridView1.CurrentCell.RowIndex).Value
            TextBox4.Text = DataGridView1.Item("country_oforigin", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox1.Text = DataGridView1.Item("ship_name", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox2.Text = DataGridView1.Item("warehouse_no", DataGridView1.CurrentCell.RowIndex).Value
            flag = 1
            Button4.Enabled = True
        End If
    End Sub
    Private Sub textbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown, TextBox4.KeyDown, Button3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.name = TextBox1.Name Then
                TextBox2.Focus()
            ElseIf sender.name = TextBox2.Name Then
                TextBox3.Focus()
            ElseIf sender.name = TextBox3.Name Then
                TextBox4.Focus()
            ElseIf sender.name = TextBox4.Name Then
                ComboBox1.Focus()
            ElseIf sender.name = ComboBox1.Name Then
                ComboBox2.Focus()
            ElseIf sender.name = ComboBox2.Name Then
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
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


End Class