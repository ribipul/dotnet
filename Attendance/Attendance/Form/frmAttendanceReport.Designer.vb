Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAttendanceReport
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
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.lbEmployee = New System.Windows.Forms.ListBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.rdoAttendanceSummary = New System.Windows.Forms.RadioButton()
            Me.rdoAttendanceDetail = New System.Windows.Forms.RadioButton()
            Me.rdoInOutDetail = New System.Windows.Forms.RadioButton()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.chkInactive = New System.Windows.Forms.CheckBox()
            Me.chkAll = New System.Windows.Forms.CheckBox()
            Me.cmdShowReport = New System.Windows.Forms.Button()
            Me.GroupBox4.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.lbEmployee)
            Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox4.Location = New System.Drawing.Point(11, 108)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(229, 242)
            Me.GroupBox4.TabIndex = 39
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
            Me.lbEmployee.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lbEmployee.Size = New System.Drawing.Size(211, 212)
            Me.lbEmployee.TabIndex = 9
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cbDepartment)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(10, 44)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(231, 55)
            Me.GroupBox1.TabIndex = 38
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
            Me.gbTitleBar.Size = New System.Drawing.Size(621, 40)
            Me.gbTitleBar.TabIndex = 40
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(143, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(366, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Employee Attendance Reports"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 360)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(621, 46)
            Me.Panel3.TabIndex = 41
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(506, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.rdoAttendanceSummary)
            Me.GroupBox2.Controls.Add(Me.rdoAttendanceDetail)
            Me.GroupBox2.Controls.Add(Me.rdoInOutDetail)
            Me.GroupBox2.Controls.Add(Me.dtToDate)
            Me.GroupBox2.Controls.Add(Me.dtFromDate)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Location = New System.Drawing.Point(253, 108)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(356, 146)
            Me.GroupBox2.TabIndex = 42
            Me.GroupBox2.TabStop = False
            '
            'rdoAttendanceSummary
            '
            Me.rdoAttendanceSummary.AutoSize = True
            Me.rdoAttendanceSummary.Location = New System.Drawing.Point(71, 109)
            Me.rdoAttendanceSummary.Name = "rdoAttendanceSummary"
            Me.rdoAttendanceSummary.Size = New System.Drawing.Size(161, 17)
            Me.rdoAttendanceSummary.TabIndex = 22
            Me.rdoAttendanceSummary.Text = "Attendance Summary Report"
            Me.rdoAttendanceSummary.UseVisualStyleBackColor = True
            '
            'rdoAttendanceDetail
            '
            Me.rdoAttendanceDetail.AutoSize = True
            Me.rdoAttendanceDetail.Checked = True
            Me.rdoAttendanceDetail.Location = New System.Drawing.Point(71, 86)
            Me.rdoAttendanceDetail.Name = "rdoAttendanceDetail"
            Me.rdoAttendanceDetail.Size = New System.Drawing.Size(145, 17)
            Me.rdoAttendanceDetail.TabIndex = 21
            Me.rdoAttendanceDetail.TabStop = True
            Me.rdoAttendanceDetail.Text = "Attendance Detail Report"
            Me.rdoAttendanceDetail.UseVisualStyleBackColor = True
            '
            'rdoInOutDetail
            '
            Me.rdoInOutDetail.AutoSize = True
            Me.rdoInOutDetail.Location = New System.Drawing.Point(71, 63)
            Me.rdoInOutDetail.Name = "rdoInOutDetail"
            Me.rdoInOutDetail.Size = New System.Drawing.Size(179, 17)
            Me.rdoInOutDetail.TabIndex = 20
            Me.rdoInOutDetail.Text = "Attendance In/Out Detail Report"
            Me.rdoInOutDetail.UseVisualStyleBackColor = True
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = ""
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtToDate.Location = New System.Drawing.Point(216, 20)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(115, 20)
            Me.dtToDate.TabIndex = 19
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = ""
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtFromDate.Location = New System.Drawing.Point(71, 20)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(115, 20)
            Me.dtFromDate.TabIndex = 18
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Blue
            Me.Label4.Location = New System.Drawing.Point(189, 21)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(23, 15)
            Me.Label4.TabIndex = 17
            Me.Label4.Text = "To"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Blue
            Me.Label3.Location = New System.Drawing.Point(29, 21)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 15)
            Me.Label3.TabIndex = 16
            Me.Label3.Text = "From"
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.chkInactive)
            Me.GroupBox3.Controls.Add(Me.chkAll)
            Me.GroupBox3.Location = New System.Drawing.Point(253, 44)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(355, 54)
            Me.GroupBox3.TabIndex = 43
            Me.GroupBox3.TabStop = False
            '
            'chkInactive
            '
            Me.chkInactive.AutoSize = True
            Me.chkInactive.Location = New System.Drawing.Point(215, 22)
            Me.chkInactive.Name = "chkInactive"
            Me.chkInactive.Size = New System.Drawing.Size(118, 17)
            Me.chkInactive.TabIndex = 1
            Me.chkInactive.Text = "Inactive Employees"
            Me.chkInactive.UseVisualStyleBackColor = True
            '
            'chkAll
            '
            Me.chkAll.AutoSize = True
            Me.chkAll.Location = New System.Drawing.Point(18, 24)
            Me.chkAll.Name = "chkAll"
            Me.chkAll.Size = New System.Drawing.Size(119, 17)
            Me.chkAll.TabIndex = 0
            Me.chkAll.Text = "Select All Employee"
            Me.chkAll.UseVisualStyleBackColor = True
            '
            'cmdShowReport
            '
            Me.cmdShowReport.Location = New System.Drawing.Point(382, 287)
            Me.cmdShowReport.Name = "cmdShowReport"
            Me.cmdShowReport.Size = New System.Drawing.Size(103, 28)
            Me.cmdShowReport.TabIndex = 44
            Me.cmdShowReport.Text = "Show Report"
            Me.cmdShowReport.UseVisualStyleBackColor = True
            '
            'frmAttendanceReport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(621, 406)
            Me.Controls.Add(Me.cmdShowReport)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.GroupBox4)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmAttendanceReport"
            Me.Text = "Employee Attendance Reports"
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents lbEmployee As System.Windows.Forms.ListBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents rdoAttendanceSummary As System.Windows.Forms.RadioButton
        Friend WithEvents rdoAttendanceDetail As System.Windows.Forms.RadioButton
        Friend WithEvents rdoInOutDetail As System.Windows.Forms.RadioButton
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
        Friend WithEvents chkAll As System.Windows.Forms.CheckBox
        Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    End Class
End NameSpace