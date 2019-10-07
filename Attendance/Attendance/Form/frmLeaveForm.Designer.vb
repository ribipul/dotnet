Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLeaveForm
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
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdShow = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cmdAdd = New System.Windows.Forms.Button()
            Me.tbSupervisor = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.dtSubmission = New System.Windows.Forms.DateTimePicker()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.tbContactNo = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.tbPurpose = New System.Windows.Forms.TextBox()
            Me.tbNoOfDays = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cbLeaveType = New System.Windows.Forms.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dtResumption = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel3.SuspendLayout()
            Me.gbTitleBar.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdShow)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 417)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(555, 46)
            Me.Panel3.TabIndex = 10
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
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(555, 40)
            Me.gbTitleBar.TabIndex = 9
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(131, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(305, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Create Leave Application"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cmdAdd)
            Me.GroupBox1.Controls.Add(Me.tbSupervisor)
            Me.GroupBox1.Controls.Add(Me.Label12)
            Me.GroupBox1.Controls.Add(Me.tbName)
            Me.GroupBox1.Controls.Add(Me.dtSubmission)
            Me.GroupBox1.Controls.Add(Me.Label11)
            Me.GroupBox1.Controls.Add(Me.tbContactNo)
            Me.GroupBox1.Controls.Add(Me.Label10)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Location = New System.Drawing.Point(15, 48)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(524, 120)
            Me.GroupBox1.TabIndex = 113
            Me.GroupBox1.TabStop = False
            '
            'cmdAdd
            '
            Me.cmdAdd.Location = New System.Drawing.Point(445, 37)
            Me.cmdAdd.Name = "cmdAdd"
            Me.cmdAdd.Size = New System.Drawing.Size(70, 22)
            Me.cmdAdd.TabIndex = 125
            Me.cmdAdd.Text = "Add/Modify"
            Me.cmdAdd.UseVisualStyleBackColor = True
            '
            'tbSupervisor
            '
            Me.tbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbSupervisor.ForeColor = System.Drawing.Color.Black
            Me.tbSupervisor.Location = New System.Drawing.Point(203, 91)
            Me.tbSupervisor.Name = "tbSupervisor"
            Me.tbSupervisor.Size = New System.Drawing.Size(235, 20)
            Me.tbSupervisor.TabIndex = 124
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.HotPink
            Me.Label12.Location = New System.Drawing.Point(30, 94)
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
            Me.tbName.Location = New System.Drawing.Point(203, 15)
            Me.tbName.Name = "tbName"
            Me.tbName.ReadOnly = True
            Me.tbName.Size = New System.Drawing.Size(235, 13)
            Me.tbName.TabIndex = 122
            '
            'dtSubmission
            '
            Me.dtSubmission.CustomFormat = ""
            Me.dtSubmission.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtSubmission.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtSubmission.Location = New System.Drawing.Point(203, 65)
            Me.dtSubmission.Name = "dtSubmission"
            Me.dtSubmission.Size = New System.Drawing.Size(234, 20)
            Me.dtSubmission.TabIndex = 121
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(30, 68)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(120, 13)
            Me.Label11.TabIndex = 21
            Me.Label11.Text = "Date of Submission:"
            '
            'tbContactNo
            '
            Me.tbContactNo.BackColor = System.Drawing.Color.White
            Me.tbContactNo.Enabled = False
            Me.tbContactNo.Location = New System.Drawing.Point(203, 39)
            Me.tbContactNo.Name = "tbContactNo"
            Me.tbContactNo.ReadOnly = True
            Me.tbContactNo.Size = New System.Drawing.Size(235, 20)
            Me.tbContactNo.TabIndex = 20
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(30, 42)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(79, 13)
            Me.Label10.TabIndex = 19
            Me.Label10.Text = "Contact No.:"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Blue
            Me.Label1.Location = New System.Drawing.Point(30, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Name:"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.GroupBox3)
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Location = New System.Drawing.Point(15, 168)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(524, 243)
            Me.GroupBox2.TabIndex = 114
            Me.GroupBox2.TabStop = False
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.tbPurpose)
            Me.GroupBox3.Controls.Add(Me.tbNoOfDays)
            Me.GroupBox3.Controls.Add(Me.Label8)
            Me.GroupBox3.Controls.Add(Me.cbLeaveType)
            Me.GroupBox3.Controls.Add(Me.Label7)
            Me.GroupBox3.Controls.Add(Me.dtResumption)
            Me.GroupBox3.Controls.Add(Me.Label6)
            Me.GroupBox3.Controls.Add(Me.Label5)
            Me.GroupBox3.Controls.Add(Me.dtToDate)
            Me.GroupBox3.Controls.Add(Me.dtFromDate)
            Me.GroupBox3.Controls.Add(Me.Label4)
            Me.GroupBox3.Controls.Add(Me.Label3)
            Me.GroupBox3.Location = New System.Drawing.Point(205, 13)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(311, 222)
            Me.GroupBox3.TabIndex = 118
            Me.GroupBox3.TabStop = False
            '
            'tbPurpose
            '
            Me.tbPurpose.Location = New System.Drawing.Point(12, 168)
            Me.tbPurpose.Multiline = True
            Me.tbPurpose.Name = "tbPurpose"
            Me.tbPurpose.Size = New System.Drawing.Size(289, 45)
            Me.tbPurpose.TabIndex = 137
            '
            'tbNoOfDays
            '
            Me.tbNoOfDays.Location = New System.Drawing.Point(207, 49)
            Me.tbNoOfDays.Name = "tbNoOfDays"
            Me.tbNoOfDays.Size = New System.Drawing.Size(91, 20)
            Me.tbNoOfDays.TabIndex = 136
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(9, 140)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(147, 15)
            Me.Label8.TabIndex = 135
            Me.Label8.Text = "Purpose for the leave:"
            '
            'cbLeaveType
            '
            Me.cbLeaveType.FormattingEnabled = True
            Me.cbLeaveType.Location = New System.Drawing.Point(172, 110)
            Me.cbLeaveType.Name = "cbLeaveType"
            Me.cbLeaveType.Size = New System.Drawing.Size(126, 21)
            Me.cbLeaveType.TabIndex = 134
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(9, 110)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 15)
            Me.Label7.TabIndex = 133
            Me.Label7.Text = "Nature of  leave:"
            '
            'dtResumption
            '
            Me.dtResumption.CustomFormat = ""
            Me.dtResumption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtResumption.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtResumption.Location = New System.Drawing.Point(207, 78)
            Me.dtResumption.Name = "dtResumption"
            Me.dtResumption.Size = New System.Drawing.Size(91, 20)
            Me.dtResumption.TabIndex = 132
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(9, 80)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(196, 15)
            Me.Label6.TabIndex = 131
            Me.Label6.Text = "Date of  resumption of duties:"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(9, 51)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(151, 15)
            Me.Label5.TabIndex = 130
            Me.Label5.Text = "Duration (No. of days):"
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = ""
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtToDate.Location = New System.Drawing.Point(207, 19)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(91, 20)
            Me.dtToDate.TabIndex = 129
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = ""
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtFromDate.Location = New System.Drawing.Point(62, 19)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(91, 20)
            Me.dtFromDate.TabIndex = 128
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(169, 21)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(27, 15)
            Me.Label4.TabIndex = 127
            Me.Label4.Text = "To:"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(9, 21)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(44, 15)
            Me.Label3.TabIndex = 126
            Me.Label3.Text = "From:"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(28, 13)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(164, 13)
            Me.Label2.TabIndex = 117
            Me.Label2.Text = "Details of leave applied for:"
            '
            'frmLeaveForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(555, 463)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmLeaveForm"
            Me.Text = "Create Leave Application"
            Me.Panel3.ResumeLayout(False)
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cmdShow As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents tbContactNo As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents dtSubmission As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents tbSupervisor As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents tbPurpose As System.Windows.Forms.TextBox
        Friend WithEvents tbNoOfDays As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cbLeaveType As System.Windows.Forms.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents dtResumption As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cmdAdd As System.Windows.Forms.Button
    End Class
End NameSpace