Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLeaveReport
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
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.chkInactive = New System.Windows.Forms.CheckBox()
            Me.chkAll = New System.Windows.Forms.CheckBox()
            Me.rdoEarnedLeave = New System.Windows.Forms.RadioButton()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.cbSummaryYear = New System.Windows.Forms.ComboBox()
            Me.rdoLeaveDetail = New System.Windows.Forms.RadioButton()
            Me.rdoLeaveSummary = New System.Windows.Forms.RadioButton()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.lbEmployee = New System.Windows.Forms.ListBox()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.cmdShowReport = New System.Windows.Forms.Button()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.gbTitleBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.chkInactive)
            Me.GroupBox3.Controls.Add(Me.chkAll)
            Me.GroupBox3.Location = New System.Drawing.Point(253, 44)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(369, 54)
            Me.GroupBox3.TabIndex = 50
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
            'rdoEarnedLeave
            '
            Me.rdoEarnedLeave.AutoSize = True
            Me.rdoEarnedLeave.Location = New System.Drawing.Point(17, 100)
            Me.rdoEarnedLeave.Name = "rdoEarnedLeave"
            Me.rdoEarnedLeave.Size = New System.Drawing.Size(92, 17)
            Me.rdoEarnedLeave.TabIndex = 22
            Me.rdoEarnedLeave.TabStop = True
            Me.rdoEarnedLeave.Text = "Earned Leave"
            Me.rdoEarnedLeave.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.cbSummaryYear)
            Me.GroupBox2.Controls.Add(Me.rdoEarnedLeave)
            Me.GroupBox2.Controls.Add(Me.rdoLeaveDetail)
            Me.GroupBox2.Controls.Add(Me.rdoLeaveSummary)
            Me.GroupBox2.Controls.Add(Me.dtToDate)
            Me.GroupBox2.Controls.Add(Me.dtFromDate)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Location = New System.Drawing.Point(253, 108)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(370, 146)
            Me.GroupBox2.TabIndex = 49
            Me.GroupBox2.TabStop = False
            '
            'cbSummaryYear
            '
            Me.cbSummaryYear.DisplayMember = "DeptName"
            Me.cbSummaryYear.DropDownHeight = 100
            Me.cbSummaryYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbSummaryYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbSummaryYear.FormattingEnabled = True
            Me.cbSummaryYear.IntegralHeight = False
            Me.cbSummaryYear.ItemHeight = 13
            Me.cbSummaryYear.Location = New System.Drawing.Point(121, 34)
            Me.cbSummaryYear.Name = "cbSummaryYear"
            Me.cbSummaryYear.Size = New System.Drawing.Size(228, 21)
            Me.cbSummaryYear.TabIndex = 23
            Me.cbSummaryYear.ValueMember = "Id"
            '
            'rdoLeaveDetail
            '
            Me.rdoLeaveDetail.AutoSize = True
            Me.rdoLeaveDetail.Location = New System.Drawing.Point(17, 67)
            Me.rdoLeaveDetail.Name = "rdoLeaveDetail"
            Me.rdoLeaveDetail.Size = New System.Drawing.Size(90, 17)
            Me.rdoLeaveDetail.TabIndex = 21
            Me.rdoLeaveDetail.TabStop = True
            Me.rdoLeaveDetail.Text = "Leave Details"
            Me.rdoLeaveDetail.UseVisualStyleBackColor = True
            '
            'rdoLeaveSummary
            '
            Me.rdoLeaveSummary.AutoSize = True
            Me.rdoLeaveSummary.Checked = True
            Me.rdoLeaveSummary.Location = New System.Drawing.Point(17, 34)
            Me.rdoLeaveSummary.Name = "rdoLeaveSummary"
            Me.rdoLeaveSummary.Size = New System.Drawing.Size(101, 17)
            Me.rdoLeaveSummary.TabIndex = 20
            Me.rdoLeaveSummary.TabStop = True
            Me.rdoLeaveSummary.Text = "Leave Summary"
            Me.rdoLeaveSummary.UseVisualStyleBackColor = True
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = ""
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtToDate.Location = New System.Drawing.Point(251, 66)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(98, 20)
            Me.dtToDate.TabIndex = 19
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = ""
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtFromDate.Location = New System.Drawing.Point(121, 66)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(98, 20)
            Me.dtFromDate.TabIndex = 18
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Blue
            Me.Label4.Location = New System.Drawing.Point(222, 67)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(23, 15)
            Me.Label4.TabIndex = 17
            Me.Label4.Text = "To"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.lbEmployee)
            Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox4.Location = New System.Drawing.Point(11, 108)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(229, 242)
            Me.GroupBox4.TabIndex = 46
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
            Me.lbEmployee.ValueMember = "pId"
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(520, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 360)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(634, 46)
            Me.Panel3.TabIndex = 48
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cbDepartment)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(10, 44)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(231, 55)
            Me.GroupBox1.TabIndex = 45
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
            Me.cbDepartment.ValueMember = "Id"
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(634, 40)
            Me.gbTitleBar.TabIndex = 47
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(143, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(306, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Employee Leave Reports"
            '
            'cmdShowReport
            '
            Me.cmdShowReport.Location = New System.Drawing.Point(390, 287)
            Me.cmdShowReport.Name = "cmdShowReport"
            Me.cmdShowReport.Size = New System.Drawing.Size(103, 28)
            Me.cmdShowReport.TabIndex = 51
            Me.cmdShowReport.Text = "Show Report"
            Me.cmdShowReport.UseVisualStyleBackColor = True
            '
            'frmLeaveReport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(634, 406)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox4)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.cmdShowReport)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmLeaveReport"
            Me.Text = "Employee Leave Reports"
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox4.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
        Friend WithEvents chkAll As System.Windows.Forms.CheckBox
        Friend WithEvents rdoEarnedLeave As System.Windows.Forms.RadioButton
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents cbSummaryYear As System.Windows.Forms.ComboBox
        Friend WithEvents rdoLeaveDetail As System.Windows.Forms.RadioButton
        Friend WithEvents rdoLeaveSummary As System.Windows.Forms.RadioButton
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents lbEmployee As System.Windows.Forms.ListBox
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    End Class
End NameSpace