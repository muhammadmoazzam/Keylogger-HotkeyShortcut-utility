Public Class splash
    Dim str As String
    Dim count As Integer
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub splash_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Programs + "\startup\Keyboard Mapping.lnk") Then
            Me.Opacity = 0 'Set Opacity 0 to the current form
            Timer3.Interval = 15 'How often timer will repeat the code (in miliseconds)
            Timer3.Enabled = True
        Else
            Me.BringToFront()
            Me.Opacity = 0 'Set Opacity 0 to the current form
            Timer1.Interval = 15 'How often timer will repeat the code (in miliseconds)
            Timer1.Enabled = True
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Opacity = 1 Then
            System.Threading.Thread.Sleep("1000")
            Timer2.Interval = 15
            Timer2.Enabled = True
            Timer1.Stop() 'if Opacity = 1, Timer1 will stop
        Else
            Me.Opacity += 0.01 'Opacity value will be increased with 0.02
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Me.Opacity = 0 Then
            Timer2.Stop()
            Timer1.Stop() 'if Opacity = 1, Timer1 will stop
            Form1.Show()
            Me.Hide()
        Else
            Me.Opacity -= 0.01 'Opacity value will be increased with 0.02
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Me.Opacity = 1 Then
            System.Threading.Thread.Sleep("1000")
            Timer4.Interval = 15
            Timer4.Enabled = True
            Timer3.Stop() 'if Opacity = 1, Timer1 will stop
        Else
            Me.Opacity += 0.01 'Opacity value will be increased with 0.02
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If Me.Opacity = 0 Then
            Timer4.Stop()
            Timer3.Stop() 'if Opacity = 1, Timer1 will stop
            Form1.Show()
            Form1.Visible = False

            Me.Hide()
        Else

            Me.Opacity -= 0.01 'Opacity value will be increased with 0.02
        End If
        
    End Sub
End Class