Imports DotRas
Imports System.IO


Public Class frmVPN
    Dim candrag As Boolean = True 'Used in dragging the borderless form, True mean we can drag the form anywhere
    Dim phonebook As RasPhoneBook = New RasPhoneBook 'This phonebook holds the entires to connect. From details host/server, username, password, pre-shared key a phonebook entry is formed which is dialed for connection.
    Dim rasdialer As RasDialer = New RasDialer 'This dialer dials the entries of phonebook
    Dim rashandler As RasHandle 'This controls the behaviour of dialer, like dial completed events or events while connection is being established.
    Dim rasConWatcher As RasConnectionWatcher = New RasConnectionWatcher 'This monitors the established connection
    Dim conup As Boolean = False 'If True then it indcates that a connection is established, used at closing of application to check whether a connection is alive or not, if an alive connection is found then it is first diconnected.
    Dim tempProtocolName As String 'It holds the name of protocol selected for connection, used to write log file.
    Dim tempPSKEY As String 'It holds the pre-shared key, used to write log file.
    Dim intDisconnected As Boolean = False 'If false then indicates that connection is disconnected by exteral factors like internet connection lost.
    Dim status_con As Boolean = False

    '// การนับเวลา
    Private TimeCounter As Integer

    Private Sub FlatComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProtocal.SelectedIndexChanged
        'If the user selects L2TP protocol then a text field becomes visible where user can write pre-shared key.
        If cmbProtocal.SelectedIndex = 2 Then
            FlatLabel2.Visible = True
            txtPresharedKey.Visible = True
        Else
            FlatLabel2.Visible = False
            txtPresharedKey.Visible = False
        End If
    End Sub


    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        'User must fill the empty fields.
        If txtHost.Text = String.Empty Or txtUserName.Text = String.Empty Or txtPassword.Text = String.Empty Then
            MsgBox("All fields are required", MsgBoxStyle.Exclamation, "Empty Fields")
            Exit Sub
        End If

        'Check if computer is connected to internet and have internet access.
        If (CheckInternetConnection() = True) Then
            Try
                AddHandler rasdialer.DialCompleted, AddressOf dialcomplete 'Attach a sub to handler to control dialer complete events.
                AddHandler rasdialer.StateChanged, AddressOf dialstatechanged 'Attach a sub to handler to control dialer state change events.
                AddHandler rasConWatcher.Disconnected, AddressOf connectionInterrupted 'Attach a sub to handler to control connection watcher disconnected event.

                phonebook.Open() 'Phonebook must be opened before making connections.

                Dim rasstrategy As RasVpnStrategy 'The Strategy defines the protocol being used for making connections. i.e. PPTP, SSTP, L2TP
                If cmbProtocal.SelectedIndex = 0 Then
                    tempProtocolName = "PPTP"
                    rasstrategy = RasVpnStrategy.PptpOnly
                ElseIf cmbProtocal.SelectedIndex = 1 Then
                    tempProtocolName = "SSTP"
                    rasstrategy = RasVpnStrategy.SstpOnly
                ElseIf cmbProtocal.SelectedIndex = 2 Then
                    tempProtocolName = "L2TP"
                    rasstrategy = RasVpnStrategy.L2tpOnly
                End If

                'Create a phonebook entry.
                Dim vpn As RasEntry = RasEntry.CreateVpnEntry("VPN CW (" + txtHost.Text + ")", txtHost.Text, rasstrategy, RasDevice.Create("VPN CW", RasDeviceType.Vpn))

                'Allow the entry to use credentials like username and password.
                vpn.Options.UseLogOnCredentials = True
                'Set IPV4 Default Gateway
                vpn.Options.RemoteDefaultGateway = False
                'Set IPV6 Default Gateway
                vpn.Options.IPv6RemoteDefaultGateway = False

                'If the user selected L2TP protocol then we must allow and proivde pre-shared key for this entry.
                If rasstrategy = RasVpnStrategy.L2tpOnly Then
                    vpn.Options.UsePreSharedKey = True
                    tempPSKEY = txtPresharedKey.Text
                Else
                    tempPSKEY = "None"
                End If

                'If Not (phonebook.Entries.Contains("VPN CW (" + txtHost.Text + ")")) Then
                phonebook.Entries.Clear() 'ลบตัวเชื่อมต่อเดิม 'Clear phonebook for old entries, if you want to retain old entries then comment or delete this line, but be sure no duplicate entries.
                phonebook.Entries.Add(vpn) 'เพิ่มตัวเชื่อมต่อ
                'End If

                'If the user selected L2TP protocol then we must allow and proivde pre-shared key for this entry.
                'If Not (phonebook.Entries.Contains("VPN CW (" + txtHost.Text + ")")) Then
                If rasstrategy = RasVpnStrategy.L2tpOnly Then
                    vpn.UpdateCredentials(RasPreSharedKey.Client, txtPresharedKey.Text)
                End If


                'ส่วนการเชื่อมต่อ
                rasdialer.EntryName = "VPN CW (" + txtHost.Text + ")" 'Defines name of newly created entry.
                rasdialer.PhoneBookPath = phonebook.Path.ToString 'We must have to provide the path of our phonebook to the dialer.

                rasdialer.Credentials = New System.Net.NetworkCredential(txtUserName.Text, txtPassword.Text) 'Sets the credentials for current connection.

                rashandler = rasdialer.DialAsync() 'Dials connection


            Catch exc As Exception
                IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  " + exc.Message)

                'MsgBox(exc.Message, MsgBoxStyle.Critical, "Connection Error")
            End Try
        Else
            IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  Either your internet Or server (http: //www.google.com) used to check internet connectivity is down.")

            'MsgBox("Either your internet Or server (http: //www.google.com) used to check internet connectivity is down.", MsgBoxStyle.Critical, "Connection Error")
        End If

        Dim regKey As Microsoft.Win32.RegistryKey
        Dim KeyName As String = "CW_VPN"
        Dim KeyPath As String = My.Application.Info.DirectoryPath
        Dim exeName As String = Path.GetFileName(Application.ExecutablePath)

        regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim OnWindowsStart As Boolean = My.Settings.Startup
        If OnWindowsStart Then
            If (regKey.GetValue(KeyName) = Nothing) Then
                regKey.SetValue(KeyName, KeyPath + "\" + exeName, Microsoft.Win32.RegistryValueKind.String)
            End If
        ElseIf (OnWindowsStart = False) Then
            If regKey.GetValue(KeyName) IsNot Nothing Then
                regKey.DeleteValue(KeyName)
            End If
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Last time saved values of connection, with which a successful connection was established, are resotred back to fields,
        txtHost.Text = My.Settings.Host
        txtUserName.Text = My.Settings.User
        txtPassword.Text = My.Settings.Pass
        txtPresharedKey.Text = My.Settings.Key
        cmbProtocal.SelectedIndex = My.Settings.Protocal
        cmbTimer.SelectedIndex = My.Settings.Time
        chkProgramStart.Checked = My.Settings.OnProgramStart
        chkStartup.Checked = My.Settings.Startup
        rasConWatcher.EnableRaisingEvents = True
        lblCounterTimer.Text = "00:00"
        btnDisconnect.Enabled = False
        lblStatus.Text = "VPN Offline"
        lblStatus.BackColor = Color.Red

        'Generates a log file if not present
        If (Not IO.File.Exists(My.Application.Info.DirectoryPath + "\logs.txt")) Then
            IO.File.WriteAllText(My.Application.Info.DirectoryPath + "\logs.txt", "<----- SurfOpenly Logging ---->" + vbNewLine + "< To Clear log file, delete all text below this line. >")
        End If
        IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  SurfOpenly Application Initialized")
        Dim OnProgramStart As Boolean = My.Settings.OnProgramStart
        If OnProgramStart Then
            Call btnConnect_Click(sender, e)
            If Not status_con Then
                '// 1000 ms = 1 Sec. (ตอนทดสอบตั้งค่าไว้สัก 50 จะทำให้เร็วขึ้น)
                Timer1.Interval = 1000
                '// นำค่า 2 หลักแรกใน ComboBox มาคูณ 60 
                TimeCounter = Val(Microsoft.VisualBasic.Left(cmbTimer.Text, 2)) * 60
                Timer1.Start()
                cmbTimer.Enabled = False
            End If
        End If
    End Sub

    Public Function CheckInternetConnection() As Boolean
        'Sub to test internet connection
        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function

    Private Sub connectionInterrupted(sender As System.Object, e As RasConnectionEventArgs)
        'Sub which is executed when connection watcher indicates that connection is disconnected by an interrupt.
        conup = False
        If (intDisconnected = False) Then 'Check whether connection is disconnected by the application or by external factors.     
            Me.BeginInvoke(Sub() ResetUiElements())
            IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  Connection  interrupted and disconnected externally")
        End If
    End Sub
    Private Sub ResetUiElements()
        lblStatus.Text = "VPN Offline"
        lblStatus.BackColor = Color.Red
        intDisconnected = True
        status_con = False
    End Sub

    Private Sub dialstatechanged(sender As System.Object, e As StateChangedEventArgs)
        'Sub which is executed on the dialer state change event.
        IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  " + e.State.ToString)

    End Sub

    Private Sub dialcomplete(sender As System.Object, e As DialCompletedEventArgs)
        'Sub which is executed on the dialer complete event.

        'If connection is succesffully established then execute if statement.
        If (e.Connected) Then
            intDisconnected = False
            conup = True
            status_con = True
            IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  Connection Established to a " + tempProtocolName + " Server: (" + txtHost.Text + ") with Username: (" + txtUserName.Text + ") and Password: (" + txtPassword.Text + ") and Pre-Shared Key: (" + tempPSKEY + ")")

            'Save the current details for reuse.
            My.Settings.Host = txtHost.Text
            My.Settings.User = txtUserName.Text
            My.Settings.Pass = txtPassword.Text
            My.Settings.Key = txtPresharedKey.Text
            My.Settings.Protocal = cmbProtocal.SelectedIndex
            My.Settings.Time = cmbTimer.SelectedIndex
            My.Settings.Startup = chkStartup.Checked
            My.Settings.OnProgramStart = chkProgramStart.Checked
            My.Settings.Save()
            '//ปิดช่องใส่ข้อมูลการเชื่อมต่อและปุ่มเชื่อมต่อ หลังจากเชื่อมต่อเสร็จสมบูรณ์
            txtHost.Enabled = False
            txtPresharedKey.Enabled = False
            txtUserName.Enabled = False
            txtPassword.Enabled = False
            cmbProtocal.Enabled = False
            cmbTimer.Enabled = False
            btnConnect.Enabled = False
            chkStartup.Enabled = False
            chkProgramStart.Enabled = False
            btnDisconnect.Enabled = True
            lblStatus.Text = "VPN Online"
            lblStatus.BackColor = Color.Green


            '// TEST
            'Timer1.Interval = 50    '<-- ไว้ทดสอบเพราะจะนับเร็วมาก
            'TimeCounter = 60 '<-- 60 วินาทีไว้ทดสอบ

            '// 1000 ms = 1 Sec. (ตอนทดสอบตั้งค่าไว้สัก 50 จะทำให้เร็วขึ้น)
            Timer1.Interval = 1000
            '// นำค่า 2 หลักแรกใน ComboBox มาคูณ 60 
            TimeCounter = Val(Microsoft.VisualBasic.Left(cmbTimer.Text, 2)) * 60
            Timer1.Start()
            cmbTimer.Enabled = False

            'If there is any type of connection error occurs while connection is being established.
        ElseIf (e.Error IsNot Nothing) Then
            'MsgBox(e.Error.ToString(), MsgBoxStyle.Critical, "Connection Error")
            IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  " + e.Error.ToString())
            'If connction timed out while connection is being established.
        ElseIf (e.TimedOut) Then

            'MsgBox("Connection attempt timed out.", MsgBoxStyle.Critical, "Timed Out")
            IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  Connection attempt timed out.")

        End If

    End Sub
    '// การนับถอยหลังโดยคำนวณค่าเวลาแบบชั่วโมง นาที และ วินาที
    Private Function CountDownTime() As String
        'Dim HH As String    '<< ชั่วโมง
        Dim MM As String    '<< นาที
        Dim SS As String    '<< วินาที
        '// 1 ชั่วโมง = 3600 วินาที
        'HH = TimeCount \ 3600

        '// การ Mod ด้วย 3600 ก็คือ 60 นาทีมีค่าเท่ากับ 3600 วินาที (การนับรวมชั่วโมง)
        '// การหารตัดเศษ \ ด้วย 60 คือต้องการแสดงผลในรูปแบบนาที
        MM = (TimeCounter Mod 3600) \ 60

        '// การ Mod ด้วย 60 (ค่าวินาที) จะทำให้ค่าสูงสุดอยู่ที่ 59 วินาที
        SS = (TimeCounter Mod 60)
        '// แสดงผล
        'HH = Microsoft.VisualBasic.Right("00" & HH, 2)
        MM = Microsoft.VisualBasic.Right("00" & MM, 2)
        SS = Microsoft.VisualBasic.Right("00" & SS, 2)
        'Return HH & ":" & MM & ":" & SS
        '// เอาเฉพาะนาที-วินาที
        Return MM & ":" & SS
    End Function
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TimeCounter > 0 Then
            TimeCounter -= 1
            lblCounterTimer.Text = CountDownTime()
        Else
            Timer1.Enabled = False
            '// TEST
            'TimeCounter = 60 '<-- 60 วินาทีไว้ทดสอบ
            TimeCounter = Val(Microsoft.VisualBasic.Left(cmbTimer.Text, 2)) * 60
            Timer1.Start()
            lblCounterTimer.Text = "00:00"
            '// กลับไปสั่งให้ Re-Connect อีกรอบ
            If Not status_con Then
                Call btnConnect_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        intDisconnected = True
        IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  Trying to disconnect a connection")

        If (rasdialer.IsBusy) Then
            rasdialer.DialAsyncCancel() 'Disconnect connection if it is being established
        Else
            Dim con As RasConnection = RasConnection.GetActiveConnectionByHandle(rashandler) 'First get whether an alive connection is in use or not.

            If (con IsNot Nothing) Then
                con.HangUp() 'Disconnects a live connection
            End If

        End If
        conup = False

        IO.File.AppendAllText(My.Application.Info.DirectoryPath + "\logs.txt", vbNewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  >>  Successfully diconnected live connection")
        txtHost.Enabled = True
        txtPresharedKey.Enabled = True
        txtUserName.Enabled = True
        txtPassword.Enabled = True
        cmbProtocal.Enabled = True
        cmbTimer.Enabled = True
        btnConnect.Enabled = True
        chkStartup.Enabled = True
        chkProgramStart.Enabled = True
        btnDisconnect.Enabled = False
        Timer1.Enabled = False
        lblCounterTimer.Text = "00:00"
        lblStatus.Text = "VPN Offline"
        lblStatus.BackColor = Color.Red
    End Sub

    Private Sub FlatClose1_Click(sender As Object, e As EventArgs) Handles FlatClose1.Click
        'Dim message As String =
        '"Are you sure that you would like to close the form?"
        'Dim caption As String = "Form Closing"
        'Dim result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '' If the no button was pressed ...
        'If (result = DialogResult.Yes) Then
        '    Application.Exit()
        'End If

        Me.Hide()
        Me.WindowState = FormWindowState.Minimized
        NotifyIcon1.ContextMenuStrip = Me.ctxMenuSystray
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(1000)
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Show()
        NotifyIcon1.Visible = False
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Close()
        End If
    End Sub
End Class
