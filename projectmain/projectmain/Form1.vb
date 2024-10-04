Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub
    Private Sub closeall()
        For Each childform As Form In Me.MdiChildren
            childform.Close()
        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        closeall()
        Dim d As New ship_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        closeall()
        Dim d As New Jetty_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        closeall()
        Dim d As New invoice_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        closeall()
        Dim d As New Commodity_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        closeall()
        Dim d As New Warehouse_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        closeall()
        Dim d As New Compare
        d.MdiParent = Me
        d.Show()
    End Sub
    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
        Dim c As Integer = MessageBox.Show("Do you want to logout?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If c = 6 Then
            Me.Hide()
            login.Show()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        closeall()
        Dim d As New shipreport2
        d.MdiParent = Me
        d.Show()
    End Sub
End Class
