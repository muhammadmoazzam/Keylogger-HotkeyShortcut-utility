Imports IWshRuntimeLibrary
Imports System.Runtime.InteropServices

Public Class Form1
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Int32) As Int16
    Public WM_SYSCOMMAND As Integer = &H112
    Public SC_MONITORPOWER As Integer = &HF170
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    <Flags()> _
    Enum ShutdownReason As UInteger
        MajorApplication = &H40000
        MajorHardware = &H10000
        MajorLegacyApi = &H70000
        MajorOperatingSystem = &H20000
        MajorOther = &H0
        MajorPower = &H60000
        MajorSoftware = &H30000
        MajorSystem = &H50000

        MinorBlueScreen = &HF
        MinorCordUnplugged = &HB
        MinorDisk = &H7
        MinorEnvironment = &HC
        MinorHardwareDriver = &HD
        MinorHotfix = &H11
        MinorHung = &H5
        MinorInstallation = &H2
        MinorMaintenance = &H1
        MinorMMC = &H19
        MinorNetworkConnectivity = &H14
        MinorNetworkCard = &H9
        MinorOther = &H0
        MinorOtherDriver = &HE
        MinorPowerSupply = &HA
        MinorProcessor = &H8
        MinorReconfig = &H4
        MinorSecurity = &H13
        MinorSecurityFix = &H12
        MinorSecurityFixUninstall = &H18
        MinorServicePack = &H10
        MinorServicePackUninstall = &H16
        MinorTermSrv = &H20
        MinorUnstable = &H6
        MinorUpgrade = &H3
        MinorWMI = &H15

        FlagUserDefined = &H40000000
        FlagPlanned = &H80000000&
    End Enum

    <Flags()> _
    Enum ExitWindows As UInteger
        LogOff = &H0
        ShutDown = &H1
        Reboot = &H2
        PowerOff = &H8
        RestartApps = &H40
        ' plus AT MOST ONE of the following two:
        Force = &H4
        ForceIfHung = &H10
    End Enum

    Declare Function ExitWindowsEx Lib "user32" (ByVal exitWin As ExitWindows, ByVal shutdownReason As ShutdownReason) As Int32



    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(hWnd As Integer, hMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Programs + "\startup\Keyboard Mapping.lnk") Then
            Me.Hide()
            Me.Visible = False
            Label6.Text = "ON"
            Label6.ForeColor = Color.Red
            IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Programs + "\startup\Keyboard Mapping.lnk")
            CreateShortcutInStartUp("keyboard shortcut utility tool")
        Else
            IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Programs + "\startup\Keyboard Mapping.lnk")
            CreateShortcutInStartUp("keyboard shortcut utility tool")
            NotifyIcon1.BalloonTipText = "Running"
            NotifyIcon1.ShowBalloonTip(10)
        End If
        If My.Settings.p = "" Then
            Button1.Enabled = False
        Else
            ComboBox1.Text = My.Settings.p
        End If
       
    End Sub
    Public Sub CreateShortcutInStartUp(ByVal Descrip As String)
        Dim WshShell As WshShell = New WshShell()
        Dim ShortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim Shortcut As IWshShortcut = CType(WshShell.CreateShortcut(System.IO.Path.Combine(ShortcutPath, Application.ProductName) & ".lnk"), IWshShortcut)
        Shortcut.TargetPath = Application.ExecutablePath
        Shortcut.WorkingDirectory = Application.StartupPath
        Shortcut.Description = Descrip
        Shortcut.Save()
    End Sub
    Private Sub NavigateWebURL(ByVal URL As String, Optional browser As String = "default")

        If Not (browser = "default") Then
            Try
                '// try set browser if there was an error (browser not installed)
                Process.Start(browser, URL)
            Catch ex As Exception
                '// use default browser
                Process.Start(URL)
            End Try

        Else
            '// use default browser
            Process.Start(URL)

        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hotkey111 As Boolean
        hotkey111 = GetAsyncKeyState(Keys.ShiftKey)
        If hotkey111 = True Then
            RichTextBox1.SelectedText = "(Shift)"
        End If
        Dim hotkey121 As Boolean
        hotkey121 = GetAsyncKeyState(Keys.CapsLock)
        If hotkey121 = True Then
            RichTextBox1.SelectedText = "(CapsLock)"
        End If
        Dim hotkey1 As Boolean
        hotkey1 = GetAsyncKeyState(Keys.A)
        If hotkey1 = True Then
            RichTextBox1.SelectedText = "A"
        End If
        Dim hotkey2 As Boolean
        hotkey2 = GetAsyncKeyState(Keys.B)
        If hotkey2 = True Then
            RichTextBox1.SelectedText = "B"
        End If

        Dim hotkey3 As Boolean
        hotkey3 = GetAsyncKeyState(Keys.C)
        If hotkey3 = True Then
            RichTextBox1.SelectedText = "C"
        End If

        Dim hotkey4 As Boolean
        hotkey4 = GetAsyncKeyState(Keys.D)
        If hotkey4 = True Then
            RichTextBox1.SelectedText = "D"
        End If

        Dim hotkey5 As Boolean
        hotkey5 = GetAsyncKeyState(Keys.E)
        If hotkey5 = True Then
            RichTextBox1.SelectedText = "E"
        End If

        Dim hotkey6 As Boolean
        hotkey6 = GetAsyncKeyState(Keys.F)
        If hotkey6 = True Then
            RichTextBox1.SelectedText = "F"
        End If

        Dim hotkey7 As Boolean
        hotkey7 = GetAsyncKeyState(Keys.G)
        If hotkey7 = True Then
            RichTextBox1.SelectedText = "G"
        End If

        Dim hotkey8 As Boolean
        hotkey8 = GetAsyncKeyState(Keys.H)
        If hotkey8 = True Then
            RichTextBox1.SelectedText = "H"
        End If

        Dim hotkey9 As Boolean
        hotkey9 = GetAsyncKeyState(Keys.I)
        If hotkey9 = True Then
            RichTextBox1.SelectedText = "I"
        End If

        Dim hotkey10 As Boolean
        hotkey10 = GetAsyncKeyState(Keys.J)
        If hotkey10 = True Then
            RichTextBox1.SelectedText = "J"
        End If

        Dim hotkey11 As Boolean
        hotkey11 = GetAsyncKeyState(Keys.K)
        If hotkey11 = True Then
            RichTextBox1.SelectedText = "K"
        End If

        Dim hotkey12 As Boolean
        hotkey12 = GetAsyncKeyState(Keys.L)
        If hotkey12 = True Then
            RichTextBox1.SelectedText = "L"
        End If

        Dim hotkey13 As Boolean
        hotkey13 = GetAsyncKeyState(Keys.M)
        If hotkey13 = True Then
            RichTextBox1.SelectedText = "M"
        End If

        Dim hotkey14 As Boolean
        hotkey14 = GetAsyncKeyState(Keys.N)
        If hotkey14 = True Then
            RichTextBox1.SelectedText = "N"
        End If

        Dim hotkey15 As Boolean
        hotkey15 = GetAsyncKeyState(Keys.O)
        If hotkey15 = True Then
            RichTextBox1.SelectedText = "O"
        End If

        Dim hotkey16 As Boolean
        hotkey16 = GetAsyncKeyState(Keys.P)
        If hotkey16 = True Then
            RichTextBox1.SelectedText = "P"
        End If

        Dim hotkey17 As Boolean
        hotkey17 = GetAsyncKeyState(Keys.Q)
        If hotkey17 = True Then
            RichTextBox1.SelectedText = "Q"
        End If

        Dim hotkey18 As Boolean
        hotkey18 = GetAsyncKeyState(Keys.R)
        If hotkey18 = True Then
            RichTextBox1.SelectedText = "R"
        End If

        Dim hotkey19 As Boolean
        hotkey19 = GetAsyncKeyState(Keys.S)
        If hotkey19 = True Then
            RichTextBox1.SelectedText = "S"
        End If

        Dim hotkey20 As Boolean
        hotkey20 = GetAsyncKeyState(Keys.T)
        If hotkey20 = True Then
            RichTextBox1.SelectedText = "T"
        End If

        Dim hotkey21 As Boolean
        hotkey21 = GetAsyncKeyState(Keys.U)
        If hotkey21 = True Then
            RichTextBox1.SelectedText = "U"
        End If

        Dim hotkey22 As Boolean
        hotkey22 = GetAsyncKeyState(Keys.V)
        If hotkey22 = True Then
            RichTextBox1.SelectedText = "V"
        End If

        Dim hotkey23 As Boolean
        hotkey23 = GetAsyncKeyState(Keys.X)
        If hotkey23 = True Then
            RichTextBox1.SelectedText = "X"
        End If

        Dim hotkey24 As Boolean
        hotkey24 = GetAsyncKeyState(Keys.Y)
        If hotkey24 = True Then
            RichTextBox1.SelectedText = "Y"
        End If

        Dim hotkey25 As Boolean
        hotkey25 = GetAsyncKeyState(Keys.Z)
        If hotkey25 = True Then
            RichTextBox1.SelectedText = "Z"
        End If

        Dim hotkey26 As Boolean
        hotkey26 = GetAsyncKeyState(Keys.Space)
        If hotkey26 = True Then
            RichTextBox1.SelectedText = " "
        End If

        Dim hotkey27 As Boolean
        hotkey27 = GetAsyncKeyState(Keys.Enter)
        If hotkey27 = True Then
            RichTextBox1.SelectedText = vbNewLine
        End If

        Dim hotkey28 As Boolean
        hotkey28 = GetAsyncKeyState(Keys.W)
        If hotkey28 = True Then
            RichTextBox1.SelectedText = "W"
        End If

        Dim hotkey29 As Boolean
        hotkey29 = GetAsyncKeyState(Keys.Back)
        If hotkey29 = True Then
            RichTextBox1.SelectedText = "(Backspace)"
        End If
        Dim hotkey99 As Boolean
        hotkey99 = GetAsyncKeyState(192)
        If hotkey99 = True Then
            RichTextBox1.SelectedText = "`"
        End If
        If (GetAsyncKeyState(Keys.C) And GetAsyncKeyState(Keys.P)) Then
            If RichTextBox2.Text = "" Then
                RichTextBox2.Text = "Opening Control Panel."
            Else
                RichTextBox2.Text &= vbCrLf & "Opening Control Panel."
            End If
            Process.Start("control.exe")
        End If
        If GetAsyncKeyState(Keys.P) And GetAsyncKeyState(Keys.T) Then
            If RichTextBox2.Text = "" Then
                RichTextBox2.Text = "Opening Paint."
            Else
                RichTextBox2.Text &= vbCrLf & "Opening Paint."
            End If
            Process.Start("mspaint.exe")
        End If
        If GetAsyncKeyState(Keys.F) And GetAsyncKeyState(Keys.B) Then
            If RichTextBox2.Text = "" Then
                RichTextBox2.Text = "Opening Facebook."
            Else
                RichTextBox2.Text &= vbCrLf & "Opening Facebook."
            End If
            Try
                NavigateWebURL("http://www.facebook.com", "Chrome")
            Catch ex As Exception
                NavigateWebURL("http://www.facebook.com", "default")
            End Try
        End If
        If GetAsyncKeyState(Keys.N) Then
            If GetAsyncKeyState(Keys.P) Then
                If RichTextBox2.Text = "" Then
                    RichTextBox2.Text = "Opening Notepad."
                Else
                    RichTextBox2.Text &= vbCrLf & "Opening Notepad."
                End If
                Process.Start("notepad.exe")
            End If
        End If
        If GetAsyncKeyState(Keys.C) And GetAsyncKeyState(Keys.H) Then
            Try
                If RichTextBox2.Text = "" Then
                    RichTextBox2.Text = "Opening Google Chrome."
                Else
                    RichTextBox2.Text &= vbCrLf & "Opening Google Chrome."
                End If
                Process.Start("chrome.exe")
            Catch
                If RichTextBox2.Text = "" Then
                    RichTextBox2.Text = "Google Chrome is corrupt or not installed."
                Else
                    RichTextBox2.Text &= vbCrLf & "Google Chrome is corrupt or not installed."
                End If
                MsgBox("Chrome isn't installed or is corrupt. Install or Re-Install Chrome.")
            End Try

        End If
        If ((GetAsyncKeyState(Keys.V)) And (GetAsyncKeyState(Keys.L)) And (GetAsyncKeyState(Keys.C))) Then
            Try

                Process.Start("C:\Program Files\VideoLAN\VLC\vlc.exe")
                If RichTextBox2.Text = "" Then
                    RichTextBox2.Text = "Opening VLC."
                Else
                    RichTextBox2.Text &= vbCrLf & "Opening VLC."
                End If
            Catch ex As Exception
                Try
                    If RichTextBox2.Text = "" Then
                        RichTextBox2.Text = "Opening VLC."
                    Else
                        RichTextBox2.Text &= vbCrLf & "Opening VLC."
                    End If
                    Process.Start("C:\Program Files (x86)\VideoLAN\VLC\vlc.exe")
                Catch ea As Exception
                    If RichTextBox2.Text = "" Then
                        RichTextBox2.Text = "VLC is corrupt or not installed."
                    Else
                        RichTextBox2.Text &= vbCrLf & "VLC is corrupt or not installed."
                    End If

                End Try
            End Try
        End If
        If GetAsyncKeyState(Keys.C) And GetAsyncKeyState(Keys.A) And GetAsyncKeyState(Keys.L) Then
            If RichTextBox2.Text = "" Then
                RichTextBox2.Text = "Opening Calculator."
            Else
                RichTextBox2.Text &= vbCrLf & "Opening Calculator."
            End If
            Process.Start("calc.exe")
        End If
        If GetAsyncKeyState(Keys.V) And GetAsyncKeyState(Keys.O) Then
            If RichTextBox2.Text = "" Then
                RichTextBox2.Text = "Opening Volume Mixer."
            Else
                RichTextBox2.Text &= vbCrLf & "Opening Volume Mixer."
            End If
            Process.Start("SndVol.exe")
        End If       
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        IO.File.WriteAllText("Log.txt", RichTextBox1.Text)
        MsgBox("Logs are Saved to current directory as ""Log.txt""")
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.p = ComboBox1.Text
        My.Settings.start = Label6.Text
        My.Settings.Save()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub PauseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem.Click
        If Me.PauseToolStripMenuItem.Text = "Pause" Then
            Me.PauseToolStripMenuItem.Text = "Start"
            Timer1.Stop()

        Else
            Me.PauseToolStripMenuItem.Text = "Pause"
            Timer1.Start()
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        My.Settings.Save()
        NotifyIcon1.Visible = False
        NotifyIcon1.Dispose()
        Application.Exit()
        End
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        MsgBox("Auto-Startup is ON and can't be disable right now.")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RichTextBox2.Text = ""
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        IO.File.WriteAllText("OutputLog.txt", RichTextBox1.Text)
        MsgBox("Output Logs are Saved to current directory as ""OutputLog.txt""")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        help.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.Text = ""
        RichTextBox2.Text = ""
        Timer1.Start()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        NotifyIcon1.BalloonTipText = "Running"
        NotifyIcon1.ShowBalloonTip(0)
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Try
            If RichTextBox1.Text.EndsWith("`") Then
                If ComboBox1.Text = "Shutdown" Then
                    NotifyIcon1.BalloonTipText = "Shutting Down"
                    NotifyIcon1.ShowBalloonTip(300)
                    Process.Start("Shutdown", "-s -t 0")
                ElseIf ComboBox1.Text = "Restart" Then
                    NotifyIcon1.BalloonTipText = "Restarting"
                    NotifyIcon1.ShowBalloonTip(300)
                    Process.Start("Shutdown", "-r -t 0")
                ElseIf ComboBox1.Text = "Force Shutdown" Then
                    NotifyIcon1.BalloonTipText = "Force Shutting Down"
                    NotifyIcon1.ShowBalloonTip(300)
                    Process.Start("Shutdown", "-s -f -t 0")
                ElseIf ComboBox1.Text = "Sign Out" Then
                    NotifyIcon1.BalloonTipText = "Signing you out"
                    NotifyIcon1.ShowBalloonTip(300)
                    'Shell("shutdown -l")
                    ExitWindowsEx(ExitWindows.LogOff, ShutdownReason.FlagPlanned)
                ElseIf ComboBox1.Text = "Turn off Display" Then
                    NotifyIcon1.BalloonTipText = "Turning off display"
                    NotifyIcon1.ShowBalloonTip(300)
                    SendMessage(Me.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2)
                ElseIf ComboBox1.Text = "Sleep" Then
                    NotifyIcon1.BalloonTipText = "Sleeping"
                    NotifyIcon1.ShowBalloonTip(300)
                    Application.SetSuspendState(PowerState.Suspend, True, True)
                    NotifyIcon1.BalloonTipText = "Hibernating"
                    NotifyIcon1.ShowBalloonTip(300)
                ElseIf ComboBox1.Text = "Hibernate" Then
                    'Shell("shutdown -h")
                    Application.SetSuspendState(PowerState.Hibernate, True, True)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If GetAsyncKeyState(Keys.ShiftKey) And GetAsyncKeyState(Keys.Space) Then
            If Me.PauseToolStripMenuItem.Text = "Pause" Then
                Timer1.Stop()
                NotifyIcon1.BalloonTipText = "Paused"
                NotifyIcon1.ShowBalloonTip(10)
                Me.PauseToolStripMenuItem.Text = "Start"
            Else
                NotifyIcon1.BalloonTipText = "Started"
                NotifyIcon1.ShowBalloonTip(10)
                Timer1.Start()
                Me.PauseToolStripMenuItem.Text = "Pause"
            End If
        End If
    End Sub
End Class
