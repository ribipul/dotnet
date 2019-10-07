Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmEmployeeAttendence
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeAttendence))
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnComments = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.gbDepartment = New System.Windows.Forms.GroupBox()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.lblEmployee = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lbEmployee = New System.Windows.Forms.ListBox()
            Me.gbAgrement = New System.Windows.Forms.GroupBox()
            Me.dtgInformation = New System.Windows.Forms.DataGridView()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.lblTime = New System.Windows.Forms.Label()
            Me.cmdNew = New System.Windows.Forms.Button()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.cmdInsert = New System.Windows.Forms.Button()
            Me.rbOut = New System.Windows.Forms.RadioButton()
            Me.rbIn = New System.Windows.Forms.RadioButton()
            Me.cmdUpdate = New System.Windows.Forms.Button()
            Me.dtEntryTime = New System.Windows.Forms.DateTimePicker()
            Me.dtEntryDate = New System.Windows.Forms.DateTimePicker()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.lblOut = New System.Windows.Forms.Label()
            Me.lblIn = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.cmdFind = New System.Windows.Forms.Button()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblEmployeeName = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.tolEmployee = New System.Windows.Forms.ToolStrip()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuAddNew = New System.Windows.Forms.ToolStripButton()
            Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
            Me.mnuCancel = New System.Windows.Forms.ToolStripButton()
            Me.mnuSave = New System.Windows.Forms.ToolStripButton()
            Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuMoveFirst = New System.Windows.Forms.ToolStripButton()
            Me.mnuMovePrevious = New System.Windows.Forms.ToolStripButton()
            Me.mnuMoveNext = New System.Windows.Forms.ToolStripButton()
            Me.mnuMoveLast = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.SN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EntryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EntryTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Records = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.gbDepartment.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.gbAgrement.SuspendLayout()
            CType(Me.dtgInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.tolEmployee.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(865, 40)
            Me.gbTitleBar.TabIndex = 5
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(255, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(349, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Employee Inform Notification"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.btnComments)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 513)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(865, 48)
            Me.Panel3.TabIndex = 8
            '
            'btnComments
            '
            Me.btnComments.Location = New System.Drawing.Point(381, 10)
            Me.btnComments.Name = "btnComments"
            Me.btnComments.Size = New System.Drawing.Size(103, 28)
            Me.btnComments.TabIndex = 21
            Me.btnComments.Text = "Comments"
            Me.btnComments.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(745, 10)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'gbDepartment
            '
            Me.gbDepartment.Controls.Add(Me.Panel5)
            Me.gbDepartment.Controls.Add(Me.Label6)
            Me.gbDepartment.Controls.Add(Me.lbEmployee)
            Me.gbDepartment.Location = New System.Drawing.Point(12, 73)
            Me.gbDepartment.Name = "gbDepartment"
            Me.gbDepartment.Size = New System.Drawing.Size(243, 434)
            Me.gbDepartment.TabIndex = 10
            Me.gbDepartment.TabStop = False
            '
            'Panel5
            '
            Me.Panel5.BackColor = System.Drawing.Color.DimGray
            Me.Panel5.Controls.Add(Me.cbDepartment)
            Me.Panel5.Controls.Add(Me.lblEmployee)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel5.Location = New System.Drawing.Point(3, 16)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(237, 65)
            Me.Panel5.TabIndex = 8
            '
            'cbDepartment
            '
            Me.cbDepartment.DisplayMember = "Id"
            Me.cbDepartment.DropDownHeight = 100
            Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDepartment.FormattingEnabled = True
            Me.cbDepartment.IntegralHeight = False
            Me.cbDepartment.ItemHeight = 13
            Me.cbDepartment.Location = New System.Drawing.Point(10, 32)
            Me.cbDepartment.Name = "cbDepartment"
            Me.cbDepartment.Size = New System.Drawing.Size(220, 21)
            Me.cbDepartment.TabIndex = 7
            Me.cbDepartment.ValueMember = "Id"
            '
            'lblEmployee
            '
            Me.lblEmployee.AutoSize = True
            Me.lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.White
            Me.lblEmployee.Location = New System.Drawing.Point(6, 9)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(109, 15)
            Me.lblEmployee.TabIndex = 6
            Me.lblEmployee.Text = "Department List"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(8, 85)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(85, 13)
            Me.Label6.TabIndex = 7
            Me.Label6.Text = "Employee List"
            '
            'lbEmployee
            '
            Me.lbEmployee.FormattingEnabled = True
            Me.lbEmployee.Location = New System.Drawing.Point(11, 106)
            Me.lbEmployee.Name = "lbEmployee"
            Me.lbEmployee.Size = New System.Drawing.Size(220, 316)
            Me.lbEmployee.TabIndex = 6
            '
            'gbAgrement
            '
            Me.gbAgrement.Controls.Add(Me.dtgInformation)
            Me.gbAgrement.Controls.Add(Me.Panel4)
            Me.gbAgrement.Controls.Add(Me.Panel2)
            Me.gbAgrement.Location = New System.Drawing.Point(271, 73)
            Me.gbAgrement.Name = "gbAgrement"
            Me.gbAgrement.Size = New System.Drawing.Size(581, 434)
            Me.gbAgrement.TabIndex = 11
            Me.gbAgrement.TabStop = False
            '
            'dtgInformation
            '
            Me.dtgInformation.AllowUserToAddRows = False
            Me.dtgInformation.AllowUserToDeleteRows = False
            Me.dtgInformation.AllowUserToResizeColumns = False
            Me.dtgInformation.AllowUserToResizeRows = False
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dtgInformation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dtgInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dtgInformation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SN, Me.EntryDate, Me.EntryTime, Me.Purpose, Me.Records})
            Me.dtgInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dtgInformation.Location = New System.Drawing.Point(3, 78)
            Me.dtgInformation.MultiSelect = False
            Me.dtgInformation.Name = "dtgInformation"
            Me.dtgInformation.RowHeadersWidth = 25
            Me.dtgInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dtgInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dtgInformation.Size = New System.Drawing.Size(575, 287)
            Me.dtgInformation.TabIndex = 3
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.DimGray
            Me.Panel4.Controls.Add(Me.lblTime)
            Me.Panel4.Controls.Add(Me.cmdNew)
            Me.Panel4.Controls.Add(Me.cmdDelete)
            Me.Panel4.Controls.Add(Me.cmdInsert)
            Me.Panel4.Controls.Add(Me.rbOut)
            Me.Panel4.Controls.Add(Me.rbIn)
            Me.Panel4.Controls.Add(Me.cmdUpdate)
            Me.Panel4.Controls.Add(Me.dtEntryTime)
            Me.Panel4.Controls.Add(Me.dtEntryDate)
            Me.Panel4.Controls.Add(Me.lblDate)
            Me.Panel4.Controls.Add(Me.lblOut)
            Me.Panel4.Controls.Add(Me.lblIn)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel4.Location = New System.Drawing.Point(3, 365)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(575, 66)
            Me.Panel4.TabIndex = 1
            '
            'lblTime
            '
            Me.lblTime.AutoSize = True
            Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTime.ForeColor = System.Drawing.Color.White
            Me.lblTime.Location = New System.Drawing.Point(284, 23)
            Me.lblTime.Name = "lblTime"
            Me.lblTime.Size = New System.Drawing.Size(39, 15)
            Me.lblTime.TabIndex = 109
            Me.lblTime.Text = "Time"
            '
            'cmdNew
            '
            Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdNew.Location = New System.Drawing.Point(448, 4)
            Me.cmdNew.Name = "cmdNew"
            Me.cmdNew.Size = New System.Drawing.Size(56, 25)
            Me.cmdNew.TabIndex = 108
            Me.cmdNew.Text = "New"
            Me.cmdNew.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Enabled = False
            Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDelete.Location = New System.Drawing.Point(507, 34)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
            Me.cmdDelete.TabIndex = 20
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdInsert
            '
            Me.cmdInsert.Enabled = False
            Me.cmdInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdInsert.Location = New System.Drawing.Point(507, 4)
            Me.cmdInsert.Name = "cmdInsert"
            Me.cmdInsert.Size = New System.Drawing.Size(56, 25)
            Me.cmdInsert.TabIndex = 19
            Me.cmdInsert.Text = "Insert"
            Me.cmdInsert.UseVisualStyleBackColor = True
            '
            'rbOut
            '
            Me.rbOut.AutoSize = True
            Me.rbOut.Location = New System.Drawing.Point(223, 26)
            Me.rbOut.Name = "rbOut"
            Me.rbOut.Size = New System.Drawing.Size(14, 13)
            Me.rbOut.TabIndex = 18
            Me.rbOut.TabStop = True
            Me.rbOut.UseVisualStyleBackColor = True
            '
            'rbIn
            '
            Me.rbIn.AutoSize = True
            Me.rbIn.Location = New System.Drawing.Point(181, 26)
            Me.rbIn.Name = "rbIn"
            Me.rbIn.Size = New System.Drawing.Size(14, 13)
            Me.rbIn.TabIndex = 17
            Me.rbIn.TabStop = True
            Me.rbIn.UseVisualStyleBackColor = True
            '
            'cmdUpdate
            '
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdUpdate.Location = New System.Drawing.Point(448, 34)
            Me.cmdUpdate.Name = "cmdUpdate"
            Me.cmdUpdate.Size = New System.Drawing.Size(56, 25)
            Me.cmdUpdate.TabIndex = 16
            Me.cmdUpdate.Text = "Update"
            Me.cmdUpdate.UseVisualStyleBackColor = True
            '
            'dtEntryTime
            '
            Me.dtEntryTime.CustomFormat = ""
            Me.dtEntryTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtEntryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtEntryTime.Location = New System.Drawing.Point(331, 23)
            Me.dtEntryTime.Name = "dtEntryTime"
            Me.dtEntryTime.ShowUpDown = True
            Me.dtEntryTime.Size = New System.Drawing.Size(102, 20)
            Me.dtEntryTime.TabIndex = 15
            '
            'dtEntryDate
            '
            Me.dtEntryDate.CustomFormat = ""
            Me.dtEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtEntryDate.Location = New System.Drawing.Point(66, 23)
            Me.dtEntryDate.Name = "dtEntryDate"
            Me.dtEntryDate.Size = New System.Drawing.Size(96, 20)
            Me.dtEntryDate.TabIndex = 14
            '
            'lblDate
            '
            Me.lblDate.AutoSize = True
            Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDate.ForeColor = System.Drawing.Color.White
            Me.lblDate.Location = New System.Drawing.Point(18, 24)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(37, 15)
            Me.lblDate.TabIndex = 10
            Me.lblDate.Text = "Date"
            '
            'lblOut
            '
            Me.lblOut.AutoSize = True
            Me.lblOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOut.ForeColor = System.Drawing.Color.White
            Me.lblOut.Location = New System.Drawing.Point(240, 24)
            Me.lblOut.Name = "lblOut"
            Me.lblOut.Size = New System.Drawing.Size(29, 15)
            Me.lblOut.TabIndex = 9
            Me.lblOut.Text = "Out"
            '
            'lblIn
            '
            Me.lblIn.AutoSize = True
            Me.lblIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIn.ForeColor = System.Drawing.Color.White
            Me.lblIn.Location = New System.Drawing.Point(195, 24)
            Me.lblIn.Name = "lblIn"
            Me.lblIn.Size = New System.Drawing.Size(19, 15)
            Me.lblIn.TabIndex = 8
            Me.lblIn.Text = "In"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.DimGray
            Me.Panel2.Controls.Add(Me.cmdFind)
            Me.Panel2.Controls.Add(Me.dtToDate)
            Me.Panel2.Controls.Add(Me.dtFromDate)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.lblEmployeeName)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(3, 16)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(575, 62)
            Me.Panel2.TabIndex = 0
            '
            'cmdFind
            '
            Me.cmdFind.Location = New System.Drawing.Point(534, 18)
            Me.cmdFind.Name = "cmdFind"
            Me.cmdFind.Size = New System.Drawing.Size(37, 25)
            Me.cmdFind.TabIndex = 16
            Me.cmdFind.Text = "GO"
            Me.cmdFind.UseVisualStyleBackColor = True
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = ""
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtToDate.Location = New System.Drawing.Point(436, 21)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(84, 20)
            Me.dtToDate.TabIndex = 15
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = ""
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtFromDate.Location = New System.Drawing.Point(317, 21)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(84, 20)
            Me.dtFromDate.TabIndex = 14
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(407, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(23, 15)
            Me.Label4.TabIndex = 11
            Me.Label4.Text = "To"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(277, 24)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(37, 15)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Date"
            '
            'lblEmployeeName
            '
            Me.lblEmployeeName.AutoSize = True
            Me.lblEmployeeName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmployeeName.ForeColor = System.Drawing.Color.Pink
            Me.lblEmployeeName.Location = New System.Drawing.Point(60, 24)
            Me.lblEmployeeName.Name = "lblEmployeeName"
            Me.lblEmployeeName.Size = New System.Drawing.Size(112, 16)
            Me.lblEmployeeName.TabIndex = 9
            Me.lblEmployeeName.Text = "Employee Name"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(12, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(45, 15)
            Me.Label1.TabIndex = 8
            Me.Label1.Text = "Name"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel1.Controls.Add(Me.tolEmployee)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(865, 27)
            Me.Panel1.TabIndex = 12
            '
            'tolEmployee
            '
            Me.tolEmployee.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.tolEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuAddNew, Me.mnuEdit, Me.mnuCancel, Me.mnuSave, Me.mnuDelete, Me.ToolStripSeparator1, Me.mnuMoveFirst, Me.mnuMovePrevious, Me.mnuMoveNext, Me.mnuMoveLast, Me.ToolStripSeparator3})
            Me.tolEmployee.Location = New System.Drawing.Point(0, 0)
            Me.tolEmployee.Name = "tolEmployee"
            Me.tolEmployee.Size = New System.Drawing.Size(865, 25)
            Me.tolEmployee.TabIndex = 32
            Me.tolEmployee.Text = "Employee"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'mnuAddNew
            '
            Me.mnuAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuAddNew.Image = CType(resources.GetObject("mnuAddNew.Image"), System.Drawing.Image)
            Me.mnuAddNew.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuAddNew.Name = "mnuAddNew"
            Me.mnuAddNew.Size = New System.Drawing.Size(23, 22)
            Me.mnuAddNew.Text = "ToolStripButton5"
            Me.mnuAddNew.ToolTipText = "Add New Employee"
            '
            'mnuEdit
            '
            Me.mnuEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuEdit.Enabled = False
            Me.mnuEdit.Image = CType(resources.GetObject("mnuEdit.Image"), System.Drawing.Image)
            Me.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuEdit.Name = "mnuEdit"
            Me.mnuEdit.Size = New System.Drawing.Size(23, 22)
            Me.mnuEdit.Text = "ToolStripButton6"
            Me.mnuEdit.ToolTipText = "Edit an Employee"
            '
            'mnuCancel
            '
            Me.mnuCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuCancel.Enabled = False
            Me.mnuCancel.Image = CType(resources.GetObject("mnuCancel.Image"), System.Drawing.Image)
            Me.mnuCancel.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuCancel.Name = "mnuCancel"
            Me.mnuCancel.Size = New System.Drawing.Size(23, 22)
            Me.mnuCancel.Text = "ToolStripButton8"
            Me.mnuCancel.ToolTipText = "Cancel Edit/Add Employee"
            '
            'mnuSave
            '
            Me.mnuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuSave.Enabled = False
            Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
            Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuSave.Name = "mnuSave"
            Me.mnuSave.Size = New System.Drawing.Size(23, 22)
            Me.mnuSave.Text = "ToolStripButton9"
            Me.mnuSave.ToolTipText = "Save Employee Information"
            '
            'mnuDelete
            '
            Me.mnuDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuDelete.Enabled = False
            Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
            Me.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuDelete.Name = "mnuDelete"
            Me.mnuDelete.Size = New System.Drawing.Size(23, 22)
            Me.mnuDelete.Text = "ToolStripButton7"
            Me.mnuDelete.ToolTipText = "Delete an Employee"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'mnuMoveFirst
            '
            Me.mnuMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuMoveFirst.Image = CType(resources.GetObject("mnuMoveFirst.Image"), System.Drawing.Image)
            Me.mnuMoveFirst.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuMoveFirst.Name = "mnuMoveFirst"
            Me.mnuMoveFirst.Size = New System.Drawing.Size(23, 22)
            Me.mnuMoveFirst.Text = "Move First"
            '
            'mnuMovePrevious
            '
            Me.mnuMovePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuMovePrevious.Image = CType(resources.GetObject("mnuMovePrevious.Image"), System.Drawing.Image)
            Me.mnuMovePrevious.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuMovePrevious.Name = "mnuMovePrevious"
            Me.mnuMovePrevious.Size = New System.Drawing.Size(23, 22)
            Me.mnuMovePrevious.Text = "Move Previous"
            '
            'mnuMoveNext
            '
            Me.mnuMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuMoveNext.Image = CType(resources.GetObject("mnuMoveNext.Image"), System.Drawing.Image)
            Me.mnuMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuMoveNext.Name = "mnuMoveNext"
            Me.mnuMoveNext.Size = New System.Drawing.Size(23, 22)
            Me.mnuMoveNext.Text = "Move Next"
            '
            'mnuMoveLast
            '
            Me.mnuMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.mnuMoveLast.Image = CType(resources.GetObject("mnuMoveLast.Image"), System.Drawing.Image)
            Me.mnuMoveLast.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuMoveLast.Name = "mnuMoveLast"
            Me.mnuMoveLast.Size = New System.Drawing.Size(23, 22)
            Me.mnuMoveLast.Text = "Move Last"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'SN
            '
            Me.SN.HeaderText = "SN"
            Me.SN.Name = "SN"
            Me.SN.Visible = False
            '
            'EntryDate
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.Format = "dd/MM/yyyy"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.EntryDate.DefaultCellStyle = DataGridViewCellStyle2
            Me.EntryDate.HeaderText = "Entry Date"
            Me.EntryDate.Name = "EntryDate"
            Me.EntryDate.ReadOnly = True
            Me.EntryDate.Width = 125
            '
            'EntryTime
            '
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.EntryTime.DefaultCellStyle = DataGridViewCellStyle3
            Me.EntryTime.HeaderText = "Entry Time"
            Me.EntryTime.Name = "EntryTime"
            Me.EntryTime.ReadOnly = True
            Me.EntryTime.Width = 123
            '
            'Purpose
            '
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.Purpose.DefaultCellStyle = DataGridViewCellStyle4
            Me.Purpose.HeaderText = "Purpose"
            Me.Purpose.Name = "Purpose"
            Me.Purpose.ReadOnly = True
            '
            'Records
            '
            Me.Records.HeaderText = "Records"
            Me.Records.Name = "Records"
            Me.Records.ReadOnly = True
            Me.Records.Width = 200
            '
            'frmEmployeeAttendence
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(865, 561)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.gbAgrement)
            Me.Controls.Add(Me.gbDepartment)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmEmployeeAttendence"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Employee Attendence"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.gbDepartment.ResumeLayout(False)
            Me.gbDepartment.PerformLayout()
            Me.Panel5.ResumeLayout(False)
            Me.Panel5.PerformLayout()
            Me.gbAgrement.ResumeLayout(False)
            CType(Me.dtgInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.tolEmployee.ResumeLayout(False)
            Me.tolEmployee.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents gbDepartment As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lbEmployee As System.Windows.Forms.ListBox
        Friend WithEvents gbAgrement As System.Windows.Forms.GroupBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Private WithEvents tolEmployee As System.Windows.Forms.ToolStrip
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuAddNew As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuCancel As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuMoveFirst As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuMovePrevious As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuMoveNext As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuMoveLast As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblEmployeeName As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents cmdInsert As System.Windows.Forms.Button
        Friend WithEvents rbOut As System.Windows.Forms.RadioButton
        Friend WithEvents rbIn As System.Windows.Forms.RadioButton
        Friend WithEvents cmdUpdate As System.Windows.Forms.Button
        Friend WithEvents dtEntryTime As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtEntryDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents lblOut As System.Windows.Forms.Label
        Friend WithEvents lblIn As System.Windows.Forms.Label
        Friend WithEvents cmdFind As System.Windows.Forms.Button
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtgInformation As System.Windows.Forms.DataGridView
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents btnComments As System.Windows.Forms.Button
        Friend WithEvents cmdNew As System.Windows.Forms.Button
        Friend WithEvents lblTime As System.Windows.Forms.Label
        Friend WithEvents SN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EntryDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EntryTime As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Purpose As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Records As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace