<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVPN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVPN))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.frmVPNConnector = New VPN_2.FormSkin()
        Me.lblStatus = New VPN_2.FlatLabel()
        Me.chkProgramStart = New VPN_2.FlatCheckBox()
        Me.FlatMini1 = New VPN_2.FlatMini()
        Me.chkStartup = New VPN_2.FlatCheckBox()
        Me.cmbTimer = New VPN_2.FlatComboBox()
        Me.cmbProtocal = New VPN_2.FlatComboBox()
        Me.txtPassword = New VPN_2.FlatTextBox()
        Me.txtUserName = New VPN_2.FlatTextBox()
        Me.txtPresharedKey = New VPN_2.FlatTextBox()
        Me.txtHost = New VPN_2.FlatTextBox()
        Me.lblCounterTimer = New VPN_2.FlatLabel()
        Me.FlatLabel6 = New VPN_2.FlatLabel()
        Me.FlatLabel5 = New VPN_2.FlatLabel()
        Me.FlatLabel4 = New VPN_2.FlatLabel()
        Me.FlatLabel3 = New VPN_2.FlatLabel()
        Me.FlatLabel2 = New VPN_2.FlatLabel()
        Me.FlatLabel1 = New VPN_2.FlatLabel()
        Me.btnDisconnect = New VPN_2.FlatButton()
        Me.btnConnect = New VPN_2.FlatButton()
        Me.frmVPNConnector.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'frmVPNConnector
        '
        Me.frmVPNConnector.BackColor = System.Drawing.Color.White
        Me.frmVPNConnector.BaseColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.frmVPNConnector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.frmVPNConnector.Controls.Add(Me.lblStatus)
        Me.frmVPNConnector.Controls.Add(Me.chkProgramStart)
        Me.frmVPNConnector.Controls.Add(Me.FlatMini1)
        Me.frmVPNConnector.Controls.Add(Me.chkStartup)
        Me.frmVPNConnector.Controls.Add(Me.cmbTimer)
        Me.frmVPNConnector.Controls.Add(Me.cmbProtocal)
        Me.frmVPNConnector.Controls.Add(Me.txtPassword)
        Me.frmVPNConnector.Controls.Add(Me.txtUserName)
        Me.frmVPNConnector.Controls.Add(Me.txtPresharedKey)
        Me.frmVPNConnector.Controls.Add(Me.txtHost)
        Me.frmVPNConnector.Controls.Add(Me.lblCounterTimer)
        Me.frmVPNConnector.Controls.Add(Me.FlatLabel6)
        Me.frmVPNConnector.Controls.Add(Me.FlatLabel5)
        Me.frmVPNConnector.Controls.Add(Me.FlatLabel4)
        Me.frmVPNConnector.Controls.Add(Me.FlatLabel3)
        Me.frmVPNConnector.Controls.Add(Me.FlatLabel2)
        Me.frmVPNConnector.Controls.Add(Me.FlatLabel1)
        Me.frmVPNConnector.Controls.Add(Me.btnDisconnect)
        Me.frmVPNConnector.Controls.Add(Me.btnConnect)
        Me.frmVPNConnector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmVPNConnector.FlatColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.frmVPNConnector.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.frmVPNConnector.HeaderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.frmVPNConnector.HeaderMaximize = False
        Me.frmVPNConnector.Location = New System.Drawing.Point(0, 0)
        Me.frmVPNConnector.Name = "frmVPNConnector"
        Me.frmVPNConnector.Size = New System.Drawing.Size(514, 383)
        Me.frmVPNConnector.TabIndex = 0
        Me.frmVPNConnector.Text = "VPN CONNECT"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(401, 353)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(69, 21)
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.Text = "lblStatus"
        '
        'chkProgramStart
        '
        Me.chkProgramStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkProgramStart.BaseColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.chkProgramStart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.chkProgramStart.Checked = False
        Me.chkProgramStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkProgramStart.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkProgramStart.Location = New System.Drawing.Point(33, 273)
        Me.chkProgramStart.Name = "chkProgramStart"
        Me.chkProgramStart.Options = VPN_2.FlatCheckBox._Options.Style1
        Me.chkProgramStart.Size = New System.Drawing.Size(165, 22)
        Me.chkProgramStart.TabIndex = 18
        Me.chkProgramStart.Text = "Run On Program Startup"
        '
        'FlatMini1
        '
        Me.FlatMini1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatMini1.BackColor = System.Drawing.Color.White
        Me.FlatMini1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FlatMini1.Font = New System.Drawing.Font("Marlett", 12.0!)
        Me.FlatMini1.Location = New System.Drawing.Point(469, 2)
        Me.FlatMini1.Name = "FlatMini1"
        Me.FlatMini1.Size = New System.Drawing.Size(18, 18)
        Me.FlatMini1.TabIndex = 17
        Me.FlatMini1.Text = "FlatMini1"
        Me.FlatMini1.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'chkStartup
        '
        Me.chkStartup.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkStartup.BaseColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.chkStartup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.chkStartup.Checked = False
        Me.chkStartup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkStartup.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkStartup.Location = New System.Drawing.Point(33, 245)
        Me.chkStartup.Name = "chkStartup"
        Me.chkStartup.Options = VPN_2.FlatCheckBox._Options.Style1
        Me.chkStartup.Size = New System.Drawing.Size(174, 22)
        Me.chkStartup.TabIndex = 15
        Me.chkStartup.Text = "Run On Windows Startup"
        '
        'cmbTimer
        '
        Me.cmbTimer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbTimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbTimer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTimer.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cmbTimer.ForeColor = System.Drawing.Color.White
        Me.cmbTimer.FormattingEnabled = True
        Me.cmbTimer.HoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cmbTimer.ItemHeight = 18
        Me.cmbTimer.Items.AddRange(New Object() {"1 min", "10 min", "20 min", "30 min", "40 min", "50 min", "60 min"})
        Me.cmbTimer.Location = New System.Drawing.Point(275, 202)
        Me.cmbTimer.Name = "cmbTimer"
        Me.cmbTimer.Size = New System.Drawing.Size(121, 24)
        Me.cmbTimer.TabIndex = 14
        '
        'cmbProtocal
        '
        Me.cmbProtocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbProtocal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbProtocal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbProtocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProtocal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cmbProtocal.ForeColor = System.Drawing.Color.White
        Me.cmbProtocal.FormattingEnabled = True
        Me.cmbProtocal.HoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cmbProtocal.ItemHeight = 18
        Me.cmbProtocal.Items.AddRange(New Object() {"PPTP", "SSTP", "L2TP"})
        Me.cmbProtocal.Location = New System.Drawing.Point(33, 202)
        Me.cmbProtocal.Name = "cmbProtocal"
        Me.cmbProtocal.Size = New System.Drawing.Size(121, 24)
        Me.cmbProtocal.TabIndex = 13
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtPassword.Location = New System.Drawing.Point(275, 139)
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.Multiline = False
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.ReadOnly = False
        Me.txtPassword.Size = New System.Drawing.Size(210, 29)
        Me.txtPassword.TabIndex = 12
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPassword.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.Transparent
        Me.txtUserName.Location = New System.Drawing.Point(33, 139)
        Me.txtUserName.MaxLength = 32767
        Me.txtUserName.Multiline = False
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = False
        Me.txtUserName.Size = New System.Drawing.Size(210, 29)
        Me.txtUserName.TabIndex = 11
        Me.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUserName.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUserName.UseSystemPasswordChar = False
        '
        'txtPresharedKey
        '
        Me.txtPresharedKey.BackColor = System.Drawing.Color.Transparent
        Me.txtPresharedKey.Location = New System.Drawing.Point(275, 78)
        Me.txtPresharedKey.MaxLength = 32767
        Me.txtPresharedKey.Multiline = False
        Me.txtPresharedKey.Name = "txtPresharedKey"
        Me.txtPresharedKey.ReadOnly = False
        Me.txtPresharedKey.Size = New System.Drawing.Size(210, 29)
        Me.txtPresharedKey.TabIndex = 10
        Me.txtPresharedKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPresharedKey.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPresharedKey.UseSystemPasswordChar = False
        '
        'txtHost
        '
        Me.txtHost.BackColor = System.Drawing.Color.Transparent
        Me.txtHost.Location = New System.Drawing.Point(33, 78)
        Me.txtHost.MaxLength = 32767
        Me.txtHost.Multiline = False
        Me.txtHost.Name = "txtHost"
        Me.txtHost.ReadOnly = False
        Me.txtHost.Size = New System.Drawing.Size(210, 29)
        Me.txtHost.TabIndex = 9
        Me.txtHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtHost.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtHost.UseSystemPasswordChar = False
        '
        'lblCounterTimer
        '
        Me.lblCounterTimer.AutoSize = True
        Me.lblCounterTimer.BackColor = System.Drawing.Color.Transparent
        Me.lblCounterTimer.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblCounterTimer.ForeColor = System.Drawing.Color.White
        Me.lblCounterTimer.Location = New System.Drawing.Point(402, 213)
        Me.lblCounterTimer.Name = "lblCounterTimer"
        Me.lblCounterTimer.Size = New System.Drawing.Size(90, 13)
        Me.lblCounterTimer.TabIndex = 8
        Me.lblCounterTimer.Text = "lblCounterTimer"
        '
        'FlatLabel6
        '
        Me.FlatLabel6.AutoSize = True
        Me.FlatLabel6.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel6.ForeColor = System.Drawing.Color.White
        Me.FlatLabel6.Location = New System.Drawing.Point(272, 186)
        Me.FlatLabel6.Name = "FlatLabel6"
        Me.FlatLabel6.Size = New System.Drawing.Size(46, 13)
        Me.FlatLabel6.TabIndex = 7
        Me.FlatLabel6.Text = "Refresh"
        '
        'FlatLabel5
        '
        Me.FlatLabel5.AutoSize = True
        Me.FlatLabel5.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel5.ForeColor = System.Drawing.Color.White
        Me.FlatLabel5.Location = New System.Drawing.Point(30, 186)
        Me.FlatLabel5.Name = "FlatLabel5"
        Me.FlatLabel5.Size = New System.Drawing.Size(49, 13)
        Me.FlatLabel5.TabIndex = 6
        Me.FlatLabel5.Text = "Protocal"
        '
        'FlatLabel4
        '
        Me.FlatLabel4.AutoSize = True
        Me.FlatLabel4.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel4.ForeColor = System.Drawing.Color.White
        Me.FlatLabel4.Location = New System.Drawing.Point(272, 123)
        Me.FlatLabel4.Name = "FlatLabel4"
        Me.FlatLabel4.Size = New System.Drawing.Size(56, 13)
        Me.FlatLabel4.TabIndex = 5
        Me.FlatLabel4.Text = "Password"
        '
        'FlatLabel3
        '
        Me.FlatLabel3.AutoSize = True
        Me.FlatLabel3.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel3.ForeColor = System.Drawing.Color.White
        Me.FlatLabel3.Location = New System.Drawing.Point(30, 123)
        Me.FlatLabel3.Name = "FlatLabel3"
        Me.FlatLabel3.Size = New System.Drawing.Size(58, 13)
        Me.FlatLabel3.TabIndex = 4
        Me.FlatLabel3.Text = "Username"
        '
        'FlatLabel2
        '
        Me.FlatLabel2.AutoSize = True
        Me.FlatLabel2.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel2.ForeColor = System.Drawing.Color.White
        Me.FlatLabel2.Location = New System.Drawing.Point(272, 62)
        Me.FlatLabel2.Name = "FlatLabel2"
        Me.FlatLabel2.Size = New System.Drawing.Size(78, 13)
        Me.FlatLabel2.TabIndex = 3
        Me.FlatLabel2.Text = "Preshared key"
        '
        'FlatLabel1
        '
        Me.FlatLabel1.AutoSize = True
        Me.FlatLabel1.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel1.ForeColor = System.Drawing.Color.White
        Me.FlatLabel1.Location = New System.Drawing.Point(30, 62)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Size = New System.Drawing.Size(31, 13)
        Me.FlatLabel1.TabIndex = 2
        Me.FlatLabel1.Text = "Host"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.BackColor = System.Drawing.Color.Transparent
        Me.btnDisconnect.BaseColor = System.Drawing.Color.PaleVioletRed
        Me.btnDisconnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDisconnect.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisconnect.Location = New System.Drawing.Point(275, 321)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Rounded = False
        Me.btnDisconnect.Size = New System.Drawing.Size(106, 32)
        Me.btnDisconnect.TabIndex = 1
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'btnConnect
        '
        Me.btnConnect.BackColor = System.Drawing.Color.Transparent
        Me.btnConnect.BaseColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnect.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Location = New System.Drawing.Point(137, 321)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Rounded = False
        Me.btnConnect.Size = New System.Drawing.Size(106, 32)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'frmVPN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 383)
        Me.Controls.Add(Me.frmVPNConnector)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVPN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VPN"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.frmVPNConnector.ResumeLayout(False)
        Me.frmVPNConnector.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents frmVPNConnector As FormSkin
    Friend WithEvents lblCounterTimer As FlatLabel
    Friend WithEvents FlatLabel6 As FlatLabel
    Friend WithEvents FlatLabel5 As FlatLabel
    Friend WithEvents FlatLabel4 As FlatLabel
    Friend WithEvents FlatLabel3 As FlatLabel
    Friend WithEvents FlatLabel2 As FlatLabel
    Friend WithEvents FlatLabel1 As FlatLabel
    Friend WithEvents btnDisconnect As FlatButton
    Friend WithEvents btnConnect As FlatButton
    Friend WithEvents cmbTimer As FlatComboBox
    Friend WithEvents cmbProtocal As FlatComboBox
    Friend WithEvents txtPassword As FlatTextBox
    Friend WithEvents txtUserName As FlatTextBox
    Friend WithEvents txtPresharedKey As FlatTextBox
    Friend WithEvents txtHost As FlatTextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents chkStartup As FlatCheckBox
    Friend WithEvents FlatMini1 As FlatMini
    Friend WithEvents chkProgramStart As FlatCheckBox
    Friend WithEvents lblStatus As FlatLabel
End Class
