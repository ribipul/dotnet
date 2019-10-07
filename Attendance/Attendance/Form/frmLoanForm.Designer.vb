Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLoanForm
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
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdShow = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cbHeadHR = New System.Windows.Forms.ComboBox()
            Me.cbHeadAF = New System.Windows.Forms.ComboBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.tbMonthlySalary = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.tbJoinDate = New System.Windows.Forms.TextBox()
            Me.tbSupervisor = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.tbDesignation = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.tbPurpose = New System.Windows.Forms.TextBox()
            Me.tbCompleted = New System.Windows.Forms.TextBox()
            Me.tbCommence = New System.Windows.Forms.TextBox()
            Me.tbDisbursement = New System.Windows.Forms.TextBox()
            Me.tbDuration = New System.Windows.Forms.TextBox()
            Me.tbRecoveryAmount = New System.Windows.Forms.TextBox()
            Me.tbLoanAmount = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(555, 40)
            Me.gbTitleBar.TabIndex = 10
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(25, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(507, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Create Advance Against Salary Application"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdShow)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 469)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(555, 46)
            Me.Panel3.TabIndex = 11
            '
            'cmdShow
            '
            Me.cmdShow.Location = New System.Drawing.Point(181, 9)
            Me.cmdShow.Name = "cmdShow"
            Me.cmdShow.Size = New System.Drawing.Size(103, 28)
            Me.cmdShow.TabIndex = 114
            Me.cmdShow.Text = "Preview"
            Me.cmdShow.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(290, 10)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cbHeadHR)
            Me.GroupBox1.Controls.Add(Me.cbHeadAF)
            Me.GroupBox1.Controls.Add(Me.Label23)
            Me.GroupBox1.Controls.Add(Me.Label22)
            Me.GroupBox1.Controls.Add(Me.tbMonthlySalary)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.tbJoinDate)
            Me.GroupBox1.Controls.Add(Me.tbSupervisor)
            Me.GroupBox1.Controls.Add(Me.Label12)
            Me.GroupBox1.Controls.Add(Me.tbName)
            Me.GroupBox1.Controls.Add(Me.Label11)
            Me.GroupBox1.Controls.Add(Me.tbDesignation)
            Me.GroupBox1.Controls.Add(Me.Label10)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(15, 48)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(524, 192)
            Me.GroupBox1.TabIndex = 114
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Employee Information"
            '
            'cbHeadHR
            '
            Me.cbHeadHR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbHeadHR.FormattingEnabled = True
            Me.cbHeadHR.Location = New System.Drawing.Point(265, 163)
            Me.cbHeadHR.Name = "cbHeadHR"
            Me.cbHeadHR.Size = New System.Drawing.Size(235, 21)
            Me.cbHeadHR.TabIndex = 136
            '
            'cbHeadAF
            '
            Me.cbHeadAF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbHeadAF.FormattingEnabled = True
            Me.cbHeadAF.Location = New System.Drawing.Point(265, 138)
            Me.cbHeadAF.Name = "cbHeadAF"
            Me.cbHeadAF.Size = New System.Drawing.Size(235, 21)
            Me.cbHeadAF.TabIndex = 135
            '
            'Label23
            '
            Me.Label23.AutoSize = True
            Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Black
            Me.Label23.Location = New System.Drawing.Point(27, 163)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(185, 13)
            Me.Label23.TabIndex = 129
            Me.Label23.Text = "Head HR && Admin. Department:"
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Black
            Me.Label22.Location = New System.Drawing.Point(27, 140)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(227, 13)
            Me.Label22.TabIndex = 128
            Me.Label22.Text = "Head Finance && Accounts Department:"
            '
            'tbMonthlySalary
            '
            Me.tbMonthlySalary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbMonthlySalary.Location = New System.Drawing.Point(265, 113)
            Me.tbMonthlySalary.MaxLength = 15
            Me.tbMonthlySalary.Name = "tbMonthlySalary"
            Me.tbMonthlySalary.Size = New System.Drawing.Size(235, 20)
            Me.tbMonthlySalary.TabIndex = 127
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(27, 116)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(94, 13)
            Me.Label2.TabIndex = 126
            Me.Label2.Text = "Monthly Salary:"
            '
            'tbJoinDate
            '
            Me.tbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbJoinDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbJoinDate.Location = New System.Drawing.Point(265, 65)
            Me.tbJoinDate.Name = "tbJoinDate"
            Me.tbJoinDate.ReadOnly = True
            Me.tbJoinDate.Size = New System.Drawing.Size(235, 13)
            Me.tbJoinDate.TabIndex = 125
            '
            'tbSupervisor
            '
            Me.tbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbSupervisor.ForeColor = System.Drawing.Color.Black
            Me.tbSupervisor.Location = New System.Drawing.Point(265, 88)
            Me.tbSupervisor.Name = "tbSupervisor"
            Me.tbSupervisor.Size = New System.Drawing.Size(235, 20)
            Me.tbSupervisor.TabIndex = 124
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.HotPink
            Me.Label12.Location = New System.Drawing.Point(27, 91)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(152, 13)
            Me.Label12.TabIndex = 123
            Me.Label12.Text = "Supervisor’s Designation:"
            '
            'tbName
            '
            Me.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.tbName.Location = New System.Drawing.Point(265, 18)
            Me.tbName.Name = "tbName"
            Me.tbName.ReadOnly = True
            Me.tbName.Size = New System.Drawing.Size(235, 13)
            Me.tbName.TabIndex = 122
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(27, 65)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(128, 13)
            Me.Label11.TabIndex = 21
            Me.Label11.Text = "At Joining in Service:"
            '
            'tbDesignation
            '
            Me.tbDesignation.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbDesignation.Location = New System.Drawing.Point(265, 39)
            Me.tbDesignation.Name = "tbDesignation"
            Me.tbDesignation.ReadOnly = True
            Me.tbDesignation.Size = New System.Drawing.Size(235, 13)
            Me.tbDesignation.TabIndex = 20
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(27, 39)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(78, 13)
            Me.Label10.TabIndex = 19
            Me.Label10.Text = "Designation:"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Blue
            Me.Label1.Location = New System.Drawing.Point(27, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Name:"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.tbPurpose)
            Me.GroupBox2.Controls.Add(Me.tbCompleted)
            Me.GroupBox2.Controls.Add(Me.tbCommence)
            Me.GroupBox2.Controls.Add(Me.tbDisbursement)
            Me.GroupBox2.Controls.Add(Me.tbDuration)
            Me.GroupBox2.Controls.Add(Me.tbRecoveryAmount)
            Me.GroupBox2.Controls.Add(Me.tbLoanAmount)
            Me.GroupBox2.Controls.Add(Me.Label21)
            Me.GroupBox2.Controls.Add(Me.Label18)
            Me.GroupBox2.Controls.Add(Me.Label19)
            Me.GroupBox2.Controls.Add(Me.Label20)
            Me.GroupBox2.Controls.Add(Me.Label17)
            Me.GroupBox2.Controls.Add(Me.Label16)
            Me.GroupBox2.Controls.Add(Me.Label15)
            Me.GroupBox2.Controls.Add(Me.Label14)
            Me.GroupBox2.Controls.Add(Me.Label13)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.Label6)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(15, 240)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(523, 220)
            Me.GroupBox2.TabIndex = 115
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Advance Required"
            '
            'tbPurpose
            '
            Me.tbPurpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbPurpose.Location = New System.Drawing.Point(275, 164)
            Me.tbPurpose.Multiline = True
            Me.tbPurpose.Name = "tbPurpose"
            Me.tbPurpose.Size = New System.Drawing.Size(235, 50)
            Me.tbPurpose.TabIndex = 132
            '
            'tbCompleted
            '
            Me.tbCompleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbCompleted.Location = New System.Drawing.Point(275, 141)
            Me.tbCompleted.MaxLength = 10
            Me.tbCompleted.Name = "tbCompleted"
            Me.tbCompleted.Size = New System.Drawing.Size(235, 20)
            Me.tbCompleted.TabIndex = 131
            '
            'tbCommence
            '
            Me.tbCommence.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbCommence.Location = New System.Drawing.Point(275, 118)
            Me.tbCommence.MaxLength = 10
            Me.tbCommence.Name = "tbCommence"
            Me.tbCommence.Size = New System.Drawing.Size(235, 20)
            Me.tbCommence.TabIndex = 130
            '
            'tbDisbursement
            '
            Me.tbDisbursement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbDisbursement.Location = New System.Drawing.Point(275, 95)
            Me.tbDisbursement.MaxLength = 10
            Me.tbDisbursement.Name = "tbDisbursement"
            Me.tbDisbursement.Size = New System.Drawing.Size(235, 20)
            Me.tbDisbursement.TabIndex = 129
            '
            'tbDuration
            '
            Me.tbDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbDuration.Location = New System.Drawing.Point(275, 72)
            Me.tbDuration.MaxLength = 2
            Me.tbDuration.Name = "tbDuration"
            Me.tbDuration.Size = New System.Drawing.Size(235, 20)
            Me.tbDuration.TabIndex = 128
            '
            'tbRecoveryAmount
            '
            Me.tbRecoveryAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbRecoveryAmount.Location = New System.Drawing.Point(275, 49)
            Me.tbRecoveryAmount.MaxLength = 15
            Me.tbRecoveryAmount.Name = "tbRecoveryAmount"
            Me.tbRecoveryAmount.Size = New System.Drawing.Size(235, 20)
            Me.tbRecoveryAmount.TabIndex = 127
            '
            'tbLoanAmount
            '
            Me.tbLoanAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbLoanAmount.Location = New System.Drawing.Point(275, 26)
            Me.tbLoanAmount.MaxLength = 15
            Me.tbLoanAmount.Name = "tbLoanAmount"
            Me.tbLoanAmount.Size = New System.Drawing.Size(235, 20)
            Me.tbLoanAmount.TabIndex = 126
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Black
            Me.Label21.Location = New System.Drawing.Point(258, 163)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(11, 13)
            Me.Label21.TabIndex = 34
            Me.Label21.Text = ":"
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.Black
            Me.Label18.Location = New System.Drawing.Point(258, 141)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(11, 13)
            Me.Label18.TabIndex = 33
            Me.Label18.Text = "-"
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label19.ForeColor = System.Drawing.Color.Black
            Me.Label19.Location = New System.Drawing.Point(258, 118)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(11, 13)
            Me.Label19.TabIndex = 32
            Me.Label19.Text = "-"
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.Black
            Me.Label20.Location = New System.Drawing.Point(258, 95)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(11, 13)
            Me.Label20.TabIndex = 31
            Me.Label20.Text = "-"
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.Black
            Me.Label17.Location = New System.Drawing.Point(258, 72)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(11, 13)
            Me.Label17.TabIndex = 30
            Me.Label17.Text = "-"
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Black
            Me.Label16.Location = New System.Drawing.Point(258, 49)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(11, 13)
            Me.Label16.TabIndex = 29
            Me.Label16.Text = "-"
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Black
            Me.Label15.Location = New System.Drawing.Point(258, 26)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(11, 13)
            Me.Label15.TabIndex = 28
            Me.Label15.Text = "-"
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Black
            Me.Label14.Location = New System.Drawing.Point(16, 177)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(154, 13)
            Me.Label14.TabIndex = 27
            Me.Label14.Text = "(Please give a brief description)"
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.Label13.Location = New System.Drawing.Point(16, 163)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(147, 13)
            Me.Label13.TabIndex = 26
            Me.Label13.Text = "Purpose for the advance"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(16, 141)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(214, 13)
            Me.Label7.TabIndex = 25
            Me.Label7.Text = "f. Recovery to be completed (month)"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(16, 118)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(201, 13)
            Me.Label8.TabIndex = 24
            Me.Label8.Text = "e. Recovery to commence (month)"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(16, 95)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(173, 13)
            Me.Label5.TabIndex = 23
            Me.Label5.Text = "d. Disbursement date (month)"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(16, 72)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(162, 13)
            Me.Label6.TabIndex = 22
            Me.Label6.Text = "c. Recovery period (Month)"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(16, 49)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(215, 13)
            Me.Label4.TabIndex = 21
            Me.Label4.Text = "b. Monthly recovery from salary (Tk.)"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(16, 26)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(163, 13)
            Me.Label3.TabIndex = 20
            Me.Label3.Text = "a. Amount of advance (Tk.)"
            '
            'frmLoanForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(555, 515)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmLoanForm"
            Me.Text = "Create Advance Against Salary Application"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdShow As System.Windows.Forms.Button
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents tbSupervisor As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents tbDesignation As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents tbMonthlySalary As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents tbJoinDate As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents tbPurpose As System.Windows.Forms.TextBox
        Friend WithEvents tbDuration As System.Windows.Forms.TextBox
        Friend WithEvents tbRecoveryAmount As System.Windows.Forms.TextBox
        Friend WithEvents tbLoanAmount As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents tbCompleted As System.Windows.Forms.TextBox
        Friend WithEvents tbCommence As System.Windows.Forms.TextBox
        Friend WithEvents tbDisbursement As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents cbHeadHR As System.Windows.Forms.ComboBox
        Friend WithEvents cbHeadAF As System.Windows.Forms.ComboBox
    End Class
End NameSpace