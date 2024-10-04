Public Class invoice_master
    Dim flag As Integer = 0
    Dim c_year As String = Date.Now.Year

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox7.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        RichTextBox1.Text = ""
        RichTextBox2.Text = ""
        flag = 0
        Button4.Enabled = False
        TextBox2.Focus()

        Dim d As New DAOclass
        Dim flag2 As Integer = d.validate("select invoice_id from invoice where invoice_id='" & TextBox1.Text & "'")
        If flag2 = 1 Then
            'invoice is already created update invoice no and get new invoice no
            Dim invno As Integer = 0
            Dim obj As SqlClient.SqlDataReader
            obj = d.getdata("select s_id from configure_master")
            While obj.Read
                invno = obj.Item(0)
            End While
            d.closeconnection()
            invno += 1
            d.modifydata("update configure_master set s_id=" & invno)
            load_invoice()
        End If
    End Sub
    Private Sub load_invoice()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select * from configure_master")
            If ds.Tables(0).Rows.Count > 0 Then
                TextBox1.Text = "ATC" & c_year & "" & set_zero(ds.Tables(0).Rows(0).Item(0))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function set_zero(v As String) As String
        Dim d As Integer = v.Length
        Dim s As String = ""
        For i = d To 3
            s &= "0"
        Next
        s &= v
        Return s
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao As New DAOclass
        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then
                    If TextBox4.Text <> "" Then
                        If ComboBox7.Text <> "" Then
                            If TextBox6.Text <> "" Then
                                If ComboBox1.Text <> "" Then
                                    If ComboBox2.Text <> "" Then
                                        If ComboBox3.Text <> "" Then
                                            If ComboBox4.Text <> "" Then
                                                If ComboBox5.Text <> "" Then
                                                    If ComboBox6.Text <> "" Then
                                                        If RichTextBox1.Text <> "" Then
                                                            If RichTextBox2.Text <> "" Then
                                                                If flag = 0 Then
                                                                    Dim f As Integer = 0

                                                                    f = dao.validate("select invoice_id from invoice where invoice_id='" & TextBox1.Text & "'")
                                                                    If f = 1 Then
                                                                        MessageBox.Show("Unable to create Record (Already in the list)")
                                                                        TextBox1.Focus()
                                                                    Else
                                                                        dao.modifydata("insert into invoice (invoice_id,dealer_name,gst_no,commodity_name,capacity,dealing_price,gross_weight,net_weight,cgst,sgst,igst,shipper_add,warehouse_no,consignee_add,total) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & ComboBox7.Text & "','" & ComboBox4.Text & "','" & TextBox3.Text & "','" & TextBox6.Text & "','" & ComboBox5.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & RichTextBox1.Text & "','" & ComboBox6.Text & "','" & RichTextBox2.Text & "','" & TextBox5.Text & "') ")
                                                                        MessageBox.Show("Record Inserted!")
                                                                        Button1_Click(sender, e)
                                                                        load_invoice()
                                                                    End If
                                                                Else
                                                                    Dim c As Integer = MessageBox.Show("Do you want to update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                                    If c = 6 Then
                                                                        Dim d As New DAOclass
                                                                        dao.modifydata("update invoice set dealer_name='" & TextBox2.Text & "',dealing_price='" & TextBox3.Text & "',gst_no='" & TextBox4.Text & "',commodity_name='" & ComboBox7.Text & "',cgst='" & ComboBox1.Text & "',sgst='" & ComboBox2.Text & "',igst='" & ComboBox3.Text & "',shipper_add='" & RichTextBox1.Text & "',consignee_add='" & RichTextBox2.Text & "',total='" & TextBox5.Text & "' where invoice_id='" & TextBox1.Text & "'")
                                                                        loaddata()
                                                                        MessageBox.Show("Record updated")
                                                                        Button1_Click(sender, e)
                                                                        load_invoice()
                                                                    End If

                                                                End If
                                                            Else
                                                                MessageBox.Show("Enter valid Consignee address")
                                                                RichTextBox2.Focus()
                                                            End If
                                                        Else
                                                            MessageBox.Show("Enter valid Shipper address")
                                                            RichTextBox1.Focus()
                                                        End If
                                                    Else
                                                        MessageBox.Show("Enter valid Warehouse number")
                                                        ComboBox6.Focus()
                                                    End If
                                                Else
                                                    MessageBox.Show("Enter valid Net weight")
                                                    ComboBox5.Focus()
                                                End If
                                            Else
                                                MessageBox.Show("Enter valid Capacity")
                                                ComboBox4.Focus()
                                            End If
                                        Else
                                            MessageBox.Show("Enter valid IGST")
                                            ComboBox3.Focus()
                                        End If
                                    Else
                                        MessageBox.Show("Enter valid SGST")
                                        ComboBox2.Focus()
                                    End If
                                Else
                                    MessageBox.Show("Enter valid CGST")
                                    ComboBox1.Focus()
                                End If
                            Else
                                MessageBox.Show("Enter valid gross weight")
                                TextBox6.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter valid Commodity_name")
                            ComboBox7.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter valid GST number")
                        TextBox4.Focus()
                    End If
                Else
                    MessageBox.Show("Enter valid dealing price")
                    TextBox3.Focus()
                End If
            Else
                MessageBox.Show("Enter valid dealer name")
                TextBox2.Focus()
            End If
        Else
            MessageBox.Show("Enter valid invoice id")
            TextBox1.Focus()
        End If
        loaddata()
    End Sub

    Private Sub invoice_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        loadbox4()
        loadbox5()
        loadbox6()
        loadbox7()
        TextBox2.Focus()
        load_invoice()
        Button1_Click(sender, e)

    End Sub


    Public Sub loaddata()
        Dim ds As New Data.DataSet
        Dim d As New DAOclass
        ds = d.loaddata("select * from invoice")
        DataGridView1.DataSource = ds.Tables(0)
        If ds.Tables(0).Rows.Count > 0 Then
            TextBox1.Text = ds.Tables(0).Rows(0).Item(0)
        End If
        load_invoice()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("invoice_id", DataGridView1.CurrentCell.RowIndex).Value
            TextBox2.Text = DataGridView1.Item("dealer_name", DataGridView1.CurrentCell.RowIndex).Value
            TextBox3.Text = DataGridView1.Item("dealing_price", DataGridView1.CurrentCell.RowIndex).Value
            TextBox4.Text = DataGridView1.Item("gst_no", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox7.Text = DataGridView1.Item("commodity_name", DataGridView1.CurrentCell.RowIndex).Value
            TextBox6.Text = DataGridView1.Item("gross_weight", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox1.Text = DataGridView1.Item("cgst", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox2.Text = DataGridView1.Item("sgst", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox3.Text = DataGridView1.Item("igst", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox4.Text = DataGridView1.Item("capacity", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox5.Text = DataGridView1.Item("net_weight", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox6.Text = DataGridView1.Item("warehouse_no", DataGridView1.CurrentCell.RowIndex).Value
            RichTextBox1.Text = DataGridView1.Item("shipper_add", DataGridView1.CurrentCell.RowIndex).Value
            RichTextBox2.Text = DataGridView1.Item("consignee_add", DataGridView1.CurrentCell.RowIndex).Value
            flag = 1
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As Integer = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If c = 6 Then
            Dim d As New DAOclass
            d.modifydata("Delete from invoice where invoice_id='" & TextBox1.Text & "'")
            loaddata()
            MessageBox.Show("Record deleted!")
            Button1_Click(sender, e)
            load_invoice()
        End If
    End Sub
    Private Sub textbox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown, TextBox4.KeyDown, TextBox5.KeyDown, Button3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.name = TextBox4.Name Then
                TextBox2.Focus()
            ElseIf sender.name = TextBox2.Name Then
                RichTextBox2.Focus()
            ElseIf sender.name = richTextBox2.Name Then
                RichTextBox1.Focus()
            ElseIf sender.name = richTextBox1.Name Then
                ComboBox7.Focus()
            ElseIf sender.name = comboBox7.Name Then
                ComboBox6.Focus()
            ElseIf sender.name = ComboBox6.Name Then
                ComboBox4.Focus()
            ElseIf sender.name = ComboBox4.Name Then
                ComboBox5.Focus()
            ElseIf sender.name = ComboBox5.Name Then
                TextBox3.Focus()
            ElseIf sender.name = textBox3.Name Then
                ComboBox1.Focus()
            ElseIf sender.name = ComboBox1.Name Then
                ComboBox2.Focus()
            ElseIf sender.name = ComboBox2.Name Then
                ComboBox3.Focus()
            ElseIf sender.name = ComboBox3.Name Then
                Button3_Click(sender, e)
            End If
        End If
    End Sub



    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
    '    If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox1.KeyPress
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or (e.KeyChar > "0" OrElse e.KeyChar < "9") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub RichTextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox2.KeyPress
        If (e.KeyChar >= "a" And e.KeyChar <= "z") Or (e.KeyChar >= "A" And e.KeyChar <= "Z") Or (e.KeyChar > "0" OrElse e.KeyChar < "9") Or e.KeyChar = ControlChars.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub loadbox4()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select distinct(ship_capacity) from ship")
            ComboBox4.DisplayMember = "ship_capacity"
            ComboBox4.ValueMember = "ship_capacity"
            ComboBox4.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadbox5()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select weight from commodity")
            ComboBox5.DisplayMember = "weight"
            ComboBox5.ValueMember = "weight"
            ComboBox5.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadbox6()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select warehouse_no from warehouse")
            ComboBox6.DisplayMember = "warehouse_no"
            ComboBox6.ValueMember = "warehouse_no"
            ComboBox6.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadbox7()
        Try
            Dim d As New DAOclass
            Dim ds As New Data.DataSet
            ds = d.loaddata("select commodity_name from warehouse")
            ComboBox7.DisplayMember = "commodity_name"
            ComboBox7.ValueMember = "commodity_name"
            ComboBox7.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged, ComboBox5.SelectedIndexChanged
        If sender.text <> "" And IsNumeric(sender.text) Then
            TextBox6.Text = Val(ComboBox4.Text) + Val(ComboBox5.Text)
        Else
            sender.text = 0
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, TextBox3.TextChanged
        If sender.text <> "" And IsNumeric(sender.text) Then
            TextBox8.Text = (Val(ComboBox1.Text) / 100) * Val(TextBox3.Text)
        Else
            sender.text = 0
        End If
        TextBox7.Text = TextBox3.Text
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged, TextBox3.TextChanged
        If sender.text <> "" And IsNumeric(sender.text) Then
            TextBox9.Text = (Val(TextBox3.Text) * Val(ComboBox2.SelectedItem) / 100)
        Else
            sender.text = 0
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged, TextBox3.TextChanged
        If sender.text <> "" And IsNumeric(sender.text) Then
            If ComboBox3.SelectedItem = 0 Then
                TextBox10.Text = 0
            Else
                TextBox10.Text = (Val(TextBox3.Text) * Val(ComboBox3.SelectedItem) / 100)
            End If

        Else
            sender.text = 0
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged, TextBox8.TextChanged, TextBox10.TextChanged
        TextBox5.Text = Val(TextBox10.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox7.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged, TextBox6.TextChanged
        TextBox11.Text = Val(TextBox5.Text) * Val(TextBox6.Text)

    End Sub
End Class