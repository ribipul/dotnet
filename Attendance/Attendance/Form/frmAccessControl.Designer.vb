Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAccessControl
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
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.cbUserType = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.tbConPass = New System.Windows.Forms.TextBox()
            Me.tbPassword = New System.Windows.Forms.TextBox()
            Me.tbLogin = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TextBox5 = New System.Windows.Forms.TextBox()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.chkDataExport = New System.Windows.Forms.CheckBox()
            Me.chkAgreement = New System.Windows.Forms.CheckBox()
            Me.chkSetLeave = New System.Windows.Forms.CheckBox()
            Me.chkLeave = New System.Windows.Forms.CheckBox()
            Me.chkAttendance = New System.Windows.Forms.CheckBox()
            Me.chkEarnLeave = New System.Windows.Forms.CheckBox()
            Me.chkSecurity = New System.Windows.Forms.CheckBox()
            Me.chkEmpCalendar = New System.Windows.Forms.CheckBox()
            Me.chkHolidays = New System.Windows.Forms.CheckBox()
            Me.chkCalendar = New System.Windows.Forms.CheckBox()
            Me.chkDepartment = New System.Windows.Forms.CheckBox()
            Me.chkNotification = New System.Windows.Forms.CheckBox()
            Me.chkSelectPath = New System.Windows.Forms.CheckBox()
            Me.chkEmployee = New System.Windows.Forms.CheckBox()
            Me.chkRetRecord = New System.Windows.Forms.CheckBox()
            Me.chkAll = New System.Windows.Forms.CheckBox()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnAuthentication = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.lbEmployee = New System.Windows.Forms.ListBox()
            Me.GroupBox1.SuspendLayout()
            Me.gbTitleBar.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cbDepartment)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(8, 44)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(231, 55)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Department"
            '
            'cbDepartment
            '
            Me.cbDepartment.DisplayMember = "DeptName"
            Me.cbDepartment.DropDownHeight = 100
            Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDepartment.FormattingEnabled = True
            Me.cbDepartment.IntegralHeight = False
            Me.cbDepartment.ItemHeight = 13
            Me.cbDepartment.Location = New System.Drawing.Point(8, 22)
            Me.cbDepartment.Name = "cbDepartment"
            Me.cbDepartment.Size = New System.Drawing.Size(215, 21)
            Me.cbDepartment.TabIndex = 10
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(693, 40)
            Me.gbTitleBar.TabIndex = 33
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(161, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(383, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Access Controll and Permission"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.cbUserType)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.tbConPass)
            Me.GroupBox2.Controls.Add(Me.tbPassword)
            Me.GroupBox2.Controls.Add(Me.tbLogin)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Controls.Add(Me.Label1)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(248, 43)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(437, 134)
            Me.GroupBox2.TabIndex = 34
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Login Information"
            '
            'cbUserType
            '
            Me.cbUserType.DisplayMember = "DeptName"
            Me.cbUserType.DropDownHeight = 100
            Me.cbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbUserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbUserType.FormattingEnabled = True
            Me.cbUserType.IntegralHeight = False
            Me.cbUserType.ItemHeight = 13
            Me.cbUserType.Location = New System.Drawing.Point(128, 100)
            Me.cbUserType.Name = "cbUserType"
            Me.cbUserType.Size = New System.Drawing.Size(202, 21)
            Me.cbUserType.TabIndex = 11
            Me.cbUserType.ValueMember = "Id"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label5.Location = New System.Drawing.Point(394, 27)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(36, 13)
            Me.Label5.TabIndex = 8
            Me.Label5.Text = "INFO"
            '
            'tbConPass
            '
            Me.tbConPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbConPass.Location = New System.Drawing.Point(128, 74)
            Me.tbConPass.Name = "tbConPass"
            Me.tbConPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbConPass.Size = New System.Drawing.Size(202, 20)
            Me.tbConPass.TabIndex = 6
            '
            'tbPassword
            '
            Me.tbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbPassword.Location = New System.Drawing.Point(128, 48)
            Me.tbPassword.Name = "tbPassword"
            Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbPassword.Size = New System.Drawing.Size(202, 20)
            Me.tbPassword.TabIndex = 5
            '
            'tbLogin
            '
            Me.tbLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbLogin.Location = New System.Drawing.Point(128, 22)
            Me.tbLogin.Name = "tbLogin"
            Me.tbLogin.Size = New System.Drawing.Size(202, 20)
            Me.tbLogin.TabIndex = 4
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(6, 103)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(65, 13)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "User Type"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(6, 77)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(107, 13)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Confirm Password"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 53)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(84, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Set Password"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 26)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(61, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Set Login"
            '
            'TextBox5
            '
            Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox5.Location = New System.Drawing.Point(592, 91)
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Size = New System.Drawing.Size(84, 20)
            Me.TextBox5.TabIndex = 8
            Me.TextBox5.Visible = False
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.chkDataExport)
            Me.GroupBox3.Controls.Add(Me.chkAgreement)
            Me.GroupBox3.Controls.Add(Me.chkSetLeave)
            Me.GroupBox3.Controls.Add(Me.chkLeave)
            Me.GroupBox3.Controls.Add(Me.chkAttendance)
            Me.GroupBox3.Controls.Add(Me.chkEarnLeave)
            Me.GroupBox3.Controls.Add(Me.chkSecurity)
            Me.GroupBox3.Controls.Add(Me.chkEmpCalendar)
            Me.GroupBox3.Controls.Add(Me.chkHolidays)
            Me.GroupBox3.Controls.Add(Me.chkCalendar)
            Me.GroupBox3.Controls.Add(Me.chkDepartment)
            Me.GroupBox3.Controls.Add(Me.chkNotification)
            Me.GroupBox3.Controls.Add(Me.chkSelectPath)
            Me.GroupBox3.Controls.Add(Me.chkEmployee)
            Me.GroupBox3.Controls.Add(Me.chkRetRecord)
            Me.GroupBox3.Controls.Add(Me.chkAll)
            Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox3.Location = New System.Drawing.Point(248, 180)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(436, 208)
            Me.GroupBox3.TabIndex = 35
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Access Permission"
            '
            'chkDataExport
            '
            Me.chkDataExport.AutoSize = True
            Me.chkDataExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDataExport.Location = New System.Drawing.Point(219, 183)
            Me.chkDataExport.Name = "chkDataExport"
            Me.chkDataExport.Size = New System.Drawing.Size(189, 17)
            Me.chkDataExport.TabIndex = 15
            Me.chkDataExport.Text = "Employee Attendance Data Export"
            Me.chkDataExport.UseVisualStyleBackColor = True
            '
            'chkAgreement
            '
            Me.chkAgreement.AutoSize = True
            Me.chkAgreement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAgreement.Location = New System.Drawing.Point(219, 160)
            Me.chkAgreement.Name = "chkAgreement"
            Me.chkAgreement.Size = New System.Drawing.Size(121, 17)
            Me.chkAgreement.TabIndex = 14
            Me.chkAgreement.Text = "Personal Agreement"
            Me.chkAgreement.UseVisualStyleBackColor = True
            '
            'chkSetLeave
            '
            Me.chkSetLeave.AutoSize = True
            Me.chkSetLeave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSetLeave.Location = New System.Drawing.Point(219, 137)
            Me.chkSetLeave.Name = "chkSetLeave"
            Me.chkSetLeave.Size = New System.Drawing.Size(130, 17)
            Me.chkSetLeave.TabIndex = 13
            Me.chkSetLeave.Text = "Set Leave Information"
            Me.chkSetLeave.UseVisualStyleBackColor = True
            '
            'chkLeave
            '
            Me.chkLeave.AutoSize = True
            Me.chkLeave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLeave.Location = New System.Drawing.Point(219, 114)
            Me.chkLeave.Name = "chkLeave"
            Me.chkLeave.Size = New System.Drawing.Size(156, 17)
            Me.chkLeave.TabIndex = 12
            Me.chkLeave.Text = "Leave Reports: Full Access"
            Me.chkLeave.UseVisualStyleBackColor = True
            '
            'chkAttendance
            '
            Me.chkAttendance.AutoSize = True
            Me.chkAttendance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAttendance.Location = New System.Drawing.Point(219, 91)
            Me.chkAttendance.Name = "chkAttendance"
            Me.chkAttendance.Size = New System.Drawing.Size(121, 17)
            Me.chkAttendance.TabIndex = 11
            Me.chkAttendance.Text = "Attendance Reports"
            Me.chkAttendance.UseVisualStyleBackColor = True
            '
            'chkEarnLeave
            '
            Me.chkEarnLeave.AutoSize = True
            Me.chkEarnLeave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEarnLeave.Location = New System.Drawing.Point(219, 68)
            Me.chkEarnLeave.Name = "chkEarnLeave"
            Me.chkEarnLeave.Size = New System.Drawing.Size(192, 17)
            Me.chkEarnLeave.TabIndex = 10
            Me.chkEarnLeave.Text = "Earn Leave Triggaring (Processing)"
            Me.chkEarnLeave.UseVisualStyleBackColor = True
            '
            'chkSecurity
            '
            Me.chkSecurity.AutoSize = True
            Me.chkSecurity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSecurity.Location = New System.Drawing.Point(219, 45)
            Me.chkSecurity.Name = "chkSecurity"
            Me.chkSecurity.Size = New System.Drawing.Size(144, 17)
            Me.chkSecurity.TabIndex = 9
            Me.chkSecurity.Text = "Security (Access Control)"
            Me.chkSecurity.UseVisualStyleBackColor = True
            '
            'chkEmpCalendar
            '
            Me.chkEmpCalendar.AutoSize = True
            Me.chkEmpCalendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEmpCalendar.Location = New System.Drawing.Point(219, 22)
            Me.chkEmpCalendar.Name = "chkEmpCalendar"
            Me.chkEmpCalendar.Size = New System.Drawing.Size(177, 17)
            Me.chkEmpCalendar.TabIndex = 8
            Me.chkEmpCalendar.Text = "Employee Calendar: Full Access"
            Me.chkEmpCalendar.UseVisualStyleBackColor = True
            '
            'chkHolidays
            '
            Me.chkHolidays.AutoSize = True
            Me.chkHolidays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkHolidays.Location = New System.Drawing.Point(14, 183)
            Me.chkHolidays.Name = "chkHolidays"
            Me.chkHolidays.Size = New System.Drawing.Size(101, 17)
            Me.chkHolidays.TabIndex = 7
            Me.chkHolidays.Text = "Bdjobs Holidays"
            Me.chkHolidays.UseVisualStyleBackColor = True
            '
            'chkCalendar
            '
            Me.chkCalendar.AutoSize = True
            Me.chkCalendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCalendar.Location = New System.Drawing.Point(14, 160)
            Me.chkCalendar.Name = "chkCalendar"
            Me.chkCalendar.Size = New System.Drawing.Size(103, 17)
            Me.chkCalendar.TabIndex = 6
            Me.chkCalendar.Text = "Bdjobs Calendar"
            Me.chkCalendar.UseVisualStyleBackColor = True
            '
            'chkDepartment
            '
            Me.chkDepartment.AutoSize = True
            Me.chkDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDepartment.Location = New System.Drawing.Point(14, 137)
            Me.chkDepartment.Name = "chkDepartment"
            Me.chkDepartment.Size = New System.Drawing.Size(81, 17)
            Me.chkDepartment.TabIndex = 5
            Me.chkDepartment.Text = "Department"
            Me.chkDepartment.UseVisualStyleBackColor = True
            '
            'chkNotification
            '
            Me.chkNotification.AutoSize = True
            Me.chkNotification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNotification.Location = New System.Drawing.Point(14, 114)
            Me.chkNotification.Name = "chkNotification"
            Me.chkNotification.Size = New System.Drawing.Size(111, 17)
            Me.chkNotification.TabIndex = 4
            Me.chkNotification.Text = "Inform Notification"
            Me.chkNotification.UseVisualStyleBackColor = True
            '
            'chkSelectPath
            '
            Me.chkSelectPath.AutoSize = True
            Me.chkSelectPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSelectPath.Location = New System.Drawing.Point(14, 91)
            Me.chkSelectPath.Name = "chkSelectPath"
            Me.chkSelectPath.Size = New System.Drawing.Size(81, 17)
            Me.chkSelectPath.TabIndex = 3
            Me.chkSelectPath.Text = "Select Path"
            Me.chkSelectPath.UseVisualStyleBackColor = True
            '
            'chkEmployee
            '
            Me.chkEmployee.AutoSize = True
            Me.chkEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEmployee.Location = New System.Drawing.Point(14, 68)
            Me.chkEmployee.Name = "chkEmployee"
            Me.chkEmployee.Size = New System.Drawing.Size(141, 17)
            Me.chkEmployee.TabIndex = 2
            Me.chkEmployee.Text = "Employee Insert/Update"
            Me.chkEmployee.UseVisualStyleBackColor = True
            '
            'chkRetRecord
            '
            Me.chkRetRecord.AutoSize = True
            Me.chkRetRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRetRecord.Location = New System.Drawing.Point(14, 45)
            Me.chkRetRecord.Name = "chkRetRecord"
            Me.chkRetRecord.Size = New System.Drawing.Size(109, 17)
            Me.chkRetRecord.TabIndex = 1
            Me.chkRetRecord.Text = "Retrieve Records"
            Me.chkRetRecord.UseVisualStyleBackColor = True
            '
            'chkAll
            '
            Me.chkAll.AutoSize = True
            Me.chkAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAll.Location = New System.Drawing.Point(14, 22)
            Me.chkAll.Name = "chkAll"
            Me.chkAll.Size = New System.Drawing.Size(90, 17)
            Me.chkAll.TabIndex = 0
            Me.chkAll.Text = "All Permission"
            Me.chkAll.UseVisualStyleBackColor = True
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.btnAuthentication)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 398)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(693, 46)
            Me.Panel3.TabIndex = 36
            '
            'btnAuthentication
            '
            Me.btnAuthentication.Location = New System.Drawing.Point(466, 9)
            Me.btnAuthentication.Name = "btnAuthentication"
            Me.btnAuthentication.Size = New System.Drawing.Size(110, 28)
            Me.btnAuthentication.TabIndex = 20
            Me.btnAuthentication.Text = "Set Authentication"
            Me.btnAuthentication.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(582, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.lbEmployee)
            Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox4.Location = New System.Drawing.Point(9, 108)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(229, 279)
            Me.GroupBox4.TabIndex = 37
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Employee List"
            '
            'lbEmployee
            '
            Me.lbEmployee.DisplayMember = "Name"
            Me.lbEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbEmployee.FormattingEnabled = True
            Me.lbEmployee.Location = New System.Drawing.Point(9, 19)
            Me.lbEmployee.Name = "lbEmployee"
            Me.lbEmployee.Size = New System.Drawing.Size(211, 251)
            Me.lbEmployee.TabIndex = 9
            '
            'frmAccessControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(693, 444)
            Me.Controls.Add(Me.GroupBox4)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.TextBox5)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmAccessControl"
            Me.Text = "Access Control and Permission"
            Me.GroupBox1.ResumeLayout(False)
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents tbConPass As System.Windows.Forms.TextBox
        Friend WithEvents tbPassword As System.Windows.Forms.TextBox
        Friend WithEvents tbLogin As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents chkDataExport As System.Windows.Forms.CheckBox
        Friend WithEvents chkAgreement As System.Windows.Forms.CheckBox
        Friend WithEvents chkSetLeave As System.Windows.Forms.CheckBox
        Friend WithEvents chkLeave As System.Windows.Forms.CheckBox
        Friend WithEvents chkAttendance As System.Windows.Forms.CheckBox
        Friend WithEvents chkEarnLeave As System.Windows.Forms.CheckBox
        Friend WithEvents chkSecurity As System.Windows.Forms.CheckBox
        Friend WithEvents chkEmpCalendar As System.Windows.Forms.CheckBox
        Friend WithEvents chkHolidays As System.Windows.Forms.CheckBox
        Friend WithEvents chkCalendar As System.Windows.Forms.CheckBox
        Friend WithEvents chkDepartment As System.Windows.Forms.CheckBox
        Friend WithEvents chkNotification As System.Windows.Forms.CheckBox
        Friend WithEvents chkSelectPath As System.Windows.Forms.CheckBox
        Friend WithEvents chkEmployee As System.Windows.Forms.CheckBox
        Friend WithEvents chkRetRecord As System.Windows.Forms.CheckBox
        Friend WithEvents chkAll As System.Windows.Forms.CheckBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents lbEmployee As System.Windows.Forms.ListBox
        Friend WithEvents btnAuthentication As System.Windows.Forms.Button
        Friend WithEvents cbUserType As System.Windows.Forms.ComboBox
    End Class
End NameSpace