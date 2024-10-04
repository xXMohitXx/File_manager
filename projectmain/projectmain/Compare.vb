Public Class Compare
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = True
        Panel2.Visible = True
        If ComboBox1.SelectedItem = "Jetty Master" Then
            Dim d As New Jetty_master
            Jetty_master.TopLevel = False
            Jetty_master.Visible = True
            Panel1.Controls.Add(Jetty_master)
            Jetty_master.BringToFront()
        ElseIf ComboBox1.SelectedItem = "Commodity Master" Then
            Dim d As New Commodity_master
            Commodity_master.TopLevel = False
            Commodity_master.Visible = True
            Panel1.Controls.Add(Commodity_master)
            Commodity_master.BringToFront()
        ElseIf ComboBox1.SelectedItem = "Ship Master" Then
            Dim d As New ship_master
            ship_master.TopLevel = False
            ship_master.Visible = True
            Panel1.Controls.Add(ship_master)
            ship_master.BringToFront()
        ElseIf ComboBox1.SelectedItem = "Invoice Master" Then
            Dim d As New invoice_master
            invoice_master.TopLevel = False
            invoice_master.Visible = True
            Panel1.Controls.Add(invoice_master)
            invoice_master.BringToFront()
        ElseIf ComboBox1.SelectedItem = "Warehouse Master" Then
            Dim d As New Warehouse_master
            Warehouse_master.TopLevel = False
            Warehouse_master.Visible = True
            Panel1.Controls.Add(Warehouse_master)
            Warehouse_master.BringToFront()
        End If

        If ComboBox2.SelectedItem = "Jetty Master" Then
            Dim d As New Jetty_master
            Jetty_master.TopLevel = False
            Jetty_master.Visible = True
            Panel2.Controls.Add(Jetty_master)
            Jetty_master.BringToFront()
        ElseIf ComboBox2.SelectedItem = "Commodity Master" Then
            Dim d As New Commodity_master
            Commodity_master.TopLevel = False
            Commodity_master.Visible = True
            Panel2.Controls.Add(Commodity_master)
            Commodity_master.BringToFront()
        ElseIf ComboBox2.SelectedItem = "Ship Master" Then
            Dim d As New ship_master
            ship_master.TopLevel = False
            ship_master.Visible = True
            Panel2.Controls.Add(ship_master)
            ship_master.BringToFront()
        ElseIf ComboBox2.SelectedItem = "Invoice Master" Then
            Dim d As New invoice_master
            invoice_master.TopLevel = False
            invoice_master.Visible = True
            Panel2.Controls.Add(invoice_master)
            invoice_master.BringToFront()
        ElseIf ComboBox2.SelectedItem = "Warehouse Master" Then
            Dim d As New Warehouse_master
            Warehouse_master.TopLevel = False
            Warehouse_master.Visible = True
            Panel2.Controls.Add(Warehouse_master)
            Warehouse_master.BringToFront()
        End If



    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Controls.Remove(invoice_master)
        Panel1.Controls.Remove(ship_master)
        Panel1.Controls.Remove(Commodity_master)
        Panel1.Controls.Remove(Jetty_master)
        Panel1.Controls.Remove(Warehouse_master)

        Panel2.Controls.Remove(invoice_master)
        Panel2.Controls.Remove(ship_master)
        Panel2.Controls.Remove(Commodity_master)
        Panel2.Controls.Remove(Jetty_master)
        Panel2.Controls.Remove(Warehouse_master)
    End Sub
End Class