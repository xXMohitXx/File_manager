Public Class loading_screen
    Private Sub loading_screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 5
        ProgressBar1.Hide()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        'Label1.Text += 1
        If (ProgressBar1.Value = 100) Then
            Timer1.Stop()
            login.Show()
            Me.Hide()

        End If
    End Sub

End Class