Public Class shipreport2
    Private Sub shipreport2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d As New DAOclass
        Dim ds As New Data.DataSet
        Try

            ds = d.loaddata("select ship_name from warehouse")
            ComboBox1.DisplayMember = "ship_name"
            ComboBox1.ValueMember = "ship_name"
            ComboBox1.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim d As New DAOclass
        Dim ds As New Data.DataSet
        Try

            ds = d.loaddata("select commodity_name from warehouse")
            ComboBox3.DisplayMember = "commodity_name"
            ComboBox3.ValueMember = "commodity_name"
            ComboBox3.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim v As New DAOclass
        Dim ds As DataSet
        If ComboBox1.Text = "" And ComboBox3.Text = "" Then
            ds = v.loaddata("select ship_name,commodity_name,dock_date from warehouse where dock_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'")
        ElseIf ComboBox1.Text <> "" And ComboBox3.Text = "" Then
            ds = v.loaddata("select ship_name,dock_date from warehouse where dock_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and ship_name='" & ComboBox1.Text & "'")
        ElseIf ComboBox1.Text = "" And ComboBox3.Text <> "" Then
            ds = v.loaddata("select commodity_name,dock_date from warehouse where dock_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'and commodity_name='" & ComboBox3.Text & "'")
        Else
            ds = v.loaddata("select ship_name,commodity_name,dock_date from warehouse where dock_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and ship_name ='" & ComboBox1.Text & "' and commodity_name='" & ComboBox3.Text & "'")
        End If
        Try
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        dk = ds
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            r_type = "shipreport2"
            Dim d As New viewrptship
            d.MdiParent = Me.MdiParent
            d.Show()
        End If
    End Sub
End Class