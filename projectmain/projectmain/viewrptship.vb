Imports CrystalDecisions.CrystalReports.Engine
Public Class viewrptship
    Private Sub viewrptship_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        If r_type = "shipreport2" Then
            Dim dx As New shiprpt1

            dx.Load()
            Dim orpt As New ReportDocument
            orpt.Load(dx.FileName)
            orpt.SetDataSource(dk.Tables(0))
            CrystalReportViewer1.ReportSource = orpt
            dx.Dispose()

        End If

    End Sub
End Class