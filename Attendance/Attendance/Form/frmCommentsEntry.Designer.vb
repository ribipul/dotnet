Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCommentsEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCommentsEntry))
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnManualEntry = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cmdFind = New System.Windows.Forms.Button()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cbEmployee = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.lblEmployee = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.dgvComments = New System.Windows.Forms.DataGridView()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.cmdNew = New System.Windows.Forms.Button()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.cmdInsert = New System.Windows.Forms.Button()
            Me.cmdUpdate = New System.Windows.Forms.Button()
            Me.tbComments = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.dtpComments = New System.Windows.Forms.DateTimePicker()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cbType = New System.Windows.Forms.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cbPurpose = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.tbInTime = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.tbOutTime = New System.Windows.Forms.TextBox()
            Me.CommentsID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CommentsDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tolEmployee.SuspendLayout()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dgvComments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'tolEmployee
            '
            Me.tolEmployee.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.tolEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuAddNew, Me.mnuEdit, Me.mnuCancel, Me.mnuSave, Me.mnuDelete, Me.ToolStripSeparator1, Me.mnuMoveFirst, Me.mnuMovePrevious, Me.mnuMoveNext, Me.mnuMoveLast, Me.ToolStripSeparator3})
            Me.tolEmployee.Location = New System.Drawing.Point(0, 41)
            Me.tolEmployee.Name = "tolEmployee"
            Me.tolEmployee.Size = New System.Drawing.Size(822, 25)
            Me.tolEmployee.TabIndex = 34
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
            Me.mnuAddNew.ToolTipText = "New"
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
            Me.mnuEdit.ToolTipText = "Edit/Update"
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
            Me.mnuCancel.ToolTipText = "Cancel"
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
            Me.mnuSave.ToolTipText = "Save"
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
            Me.mnuDelete.ToolTipText = "Delete"
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
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(822, 41)
            Me.gbTitleBar.TabIndex = 33
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(314, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(225, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Comments Viewer"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.btnManualEntry)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 581)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(822, 48)
            Me.Panel3.TabIndex = 35
            '
            'btnManualEntry
            '
            Me.btnManualEntry.Location = New System.Drawing.Point(350, 10)
            Me.btnManualEntry.Name = "btnManualEntry"
            Me.btnManualEntry.Size = New System.Drawing.Size(103, 28)
            Me.btnManualEntry.TabIndex = 20
            Me.btnManualEntry.Text = "Manual Entry"
            Me.btnManualEntry.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(710, 10)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.cmdFind)
            Me.GroupBox1.Controls.Add(Me.dtToDate)
            Me.GroupBox1.Controls.Add(Me.dtFromDate)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.cbEmployee)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.cbDepartment)
            Me.GroupBox1.Controls.Add(Me.lblEmployee)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(6, 69)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(810, 68)
            Me.GroupBox1.TabIndex = 36
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Selection Panel"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(487, 18)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 15)
            Me.Label2.TabIndex = 22
            Me.Label2.Text = "From"
            '
            'cmdFind
            '
            Me.cmdFind.Location = New System.Drawing.Point(741, 34)
            Me.cmdFind.Name = "cmdFind"
            Me.cmdFind.Size = New System.Drawing.Size(37, 25)
            Me.cmdFind.TabIndex = 21
            Me.cmdFind.Text = "GO"
            Me.cmdFind.UseVisualStyleBackColor = True
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = ""
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtToDate.Location = New System.Drawing.Point(608, 37)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(127, 20)
            Me.dtToDate.TabIndex = 20
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = ""
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtFromDate.Location = New System.Drawing.Point(450, 37)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(127, 20)
            Me.dtFromDate.TabIndex = 19
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(656, 19)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(23, 15)
            Me.Label4.TabIndex = 18
            Me.Label4.Text = "To"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(410, 40)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(37, 15)
            Me.Label3.TabIndex = 17
            Me.Label3.Text = "Date"
            '
            'cbEmployee
            '
            Me.cbEmployee.DisplayMember = "DeptName"
            Me.cbEmployee.DropDownHeight = 100
            Me.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbEmployee.FormattingEnabled = True
            Me.cbEmployee.IntegralHeight = False
            Me.cbEmployee.ItemHeight = 13
            Me.cbEmployee.Location = New System.Drawing.Point(204, 38)
            Me.cbEmployee.Name = "cbEmployee"
            Me.cbEmployee.Size = New System.Drawing.Size(193, 21)
            Me.cbEmployee.TabIndex = 11
            Me.cbEmployee.ValueMember = "Id"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(200, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(70, 15)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Employee"
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
            Me.cbDepartment.Location = New System.Drawing.Point(30, 38)
            Me.cbDepartment.Name = "cbDepartment"
            Me.cbDepartment.Size = New System.Drawing.Size(153, 21)
            Me.cbDepartment.TabIndex = 9
            Me.cbDepartment.ValueMember = "Id"
            '
            'lblEmployee
            '
            Me.lblEmployee.AutoSize = True
            Me.lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.Black
            Me.lblEmployee.Location = New System.Drawing.Point(26, 15)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(82, 15)
            Me.lblEmployee.TabIndex = 8
            Me.lblEmployee.Text = "Department"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.dgvComments)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(6, 143)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(809, 243)
            Me.GroupBox2.TabIndex = 37
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Comments Viewer"
            '
            'dgvComments
            '
            Me.dgvComments.AllowUserToAddRows = False
            Me.dgvComments.AllowUserToDeleteRows = False
            Me.dgvComments.AllowUserToResizeColumns = False
            Me.dgvComments.AllowUserToResizeRows = False
            Me.dgvComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvComments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CommentsID, Me.CommentsDate, Me.Duration, Me.Comments, Me.Purpose})
            Me.dgvComments.Location = New System.Drawing.Point(6, 19)
            Me.dgvComments.MultiSelect = False
            Me.dgvComments.Name = "dgvComments"
            Me.dgvComments.RowHeadersWidth = 25
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgvComments.RowsDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvComments.Size = New System.Drawing.Size(797, 218)
            Me.dgvComments.TabIndex = 0
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.cmdNew)
            Me.GroupBox3.Controls.Add(Me.cmdDelete)
            Me.GroupBox3.Controls.Add(Me.cmdInsert)
            Me.GroupBox3.Controls.Add(Me.cmdUpdate)
            Me.GroupBox3.Controls.Add(Me.tbComments)
            Me.GroupBox3.Controls.Add(Me.Label10)
            Me.GroupBox3.Controls.Add(Me.dtpComments)
            Me.GroupBox3.Controls.Add(Me.Label8)
            Me.GroupBox3.Controls.Add(Me.cbType)
            Me.GroupBox3.Controls.Add(Me.Label7)
            Me.GroupBox3.Controls.Add(Me.cbPurpose)
            Me.GroupBox3.Controls.Add(Me.Label6)
            Me.GroupBox3.Controls.Add(Me.tbInTime)
            Me.GroupBox3.Controls.Add(Me.Label5)
            Me.GroupBox3.Controls.Add(Me.tbOutTime)
            Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox3.Location = New System.Drawing.Point(6, 392)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(809, 183)
            Me.GroupBox3.TabIndex = 38
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "New Comments"
            '
            'cmdNew
            '
            Me.cmdNew.Location = New System.Drawing.Point(670, 70)
            Me.cmdNew.Name = "cmdNew"
            Me.cmdNew.Size = New System.Drawing.Size(56, 25)
            Me.cmdNew.TabIndex = 27
            Me.cmdNew.Text = "New"
            Me.cmdNew.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Enabled = False
            Me.cmdDelete.Location = New System.Drawing.Point(738, 106)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
            Me.cmdDelete.TabIndex = 26
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdInsert
            '
            Me.cmdInsert.Enabled = False
            Me.cmdInsert.Location = New System.Drawing.Point(738, 70)
            Me.cmdInsert.Name = "cmdInsert"
            Me.cmdInsert.Size = New System.Drawing.Size(56, 25)
            Me.cmdInsert.TabIndex = 25
            Me.cmdInsert.Text = "Insert"
            Me.cmdInsert.UseVisualStyleBackColor = True
            '
            'cmdUpdate
            '
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.Location = New System.Drawing.Point(670, 106)
            Me.cmdUpdate.Name = "cmdUpdate"
            Me.cmdUpdate.Size = New System.Drawing.Size(56, 25)
            Me.cmdUpdate.TabIndex = 24
            Me.cmdUpdate.Text = "Update"
            Me.cmdUpdate.UseVisualStyleBackColor = True
            '
            'tbComments
            '
            Me.tbComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbComments.Location = New System.Drawing.Point(8, 62)
            Me.tbComments.Multiline = True
            Me.tbComments.Name = "tbComments"
            Me.tbComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.tbComments.Size = New System.Drawing.Size(648, 112)
            Me.tbComments.TabIndex = 23
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(532, 21)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(34, 13)
            Me.Label10.TabIndex = 22
            Me.Label10.Text = "Date"
            '
            'dtpComments
            '
            Me.dtpComments.CustomFormat = ""
            Me.dtpComments.Enabled = False
            Me.dtpComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpComments.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpComments.Location = New System.Drawing.Point(535, 39)
            Me.dtpComments.Name = "dtpComments"
            Me.dtpComments.Size = New System.Drawing.Size(121, 20)
            Me.dtpComments.TabIndex = 21
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(389, 21)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(35, 13)
            Me.Label8.TabIndex = 13
            Me.Label8.Text = "Type"
            '
            'cbType
            '
            Me.cbType.DisplayMember = "DeptName"
            Me.cbType.DropDownHeight = 100
            Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbType.Enabled = False
            Me.cbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbType.FormattingEnabled = True
            Me.cbType.IntegralHeight = False
            Me.cbType.ItemHeight = 13
            Me.cbType.Location = New System.Drawing.Point(392, 38)
            Me.cbType.Name = "cbType"
            Me.cbType.Size = New System.Drawing.Size(121, 21)
            Me.cbType.TabIndex = 12
            Me.cbType.ValueMember = "Id"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(248, 21)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(53, 13)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "Purpose"
            '
            'cbPurpose
            '
            Me.cbPurpose.DisplayMember = "DeptName"
            Me.cbPurpose.DropDownHeight = 100
            Me.cbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbPurpose.Enabled = False
            Me.cbPurpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbPurpose.FormattingEnabled = True
            Me.cbPurpose.IntegralHeight = False
            Me.cbPurpose.ItemHeight = 13
            Me.cbPurpose.Location = New System.Drawing.Point(251, 38)
            Me.cbPurpose.Name = "cbPurpose"
            Me.cbPurpose.Size = New System.Drawing.Size(121, 21)
            Me.cbPurpose.TabIndex = 10
            Me.cbPurpose.ValueMember = "Id"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(125, 21)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(49, 13)
            Me.Label6.TabIndex = 3
            Me.Label6.Text = "In Time"
            '
            'tbInTime
            '
            Me.tbInTime.Enabled = False
            Me.tbInTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbInTime.Location = New System.Drawing.Point(127, 39)
            Me.tbInTime.Name = "tbInTime"
            Me.tbInTime.Size = New System.Drawing.Size(104, 20)
            Me.tbInTime.TabIndex = 2
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(6, 21)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(58, 13)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "Out Time"
            '
            'tbOutTime
            '
            Me.tbOutTime.Enabled = False
            Me.tbOutTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbOutTime.Location = New System.Drawing.Point(8, 39)
            Me.tbOutTime.Name = "tbOutTime"
            Me.tbOutTime.Size = New System.Drawing.Size(104, 20)
            Me.tbOutTime.TabIndex = 0
            '
            'CommentsID
            '
            Me.CommentsID.HeaderText = "Comments ID"
            Me.CommentsID.Name = "CommentsID"
            Me.CommentsID.ReadOnly = True
            Me.CommentsID.Visible = False
            '
            'CommentsDate
            '
            DataGridViewCellStyle1.Format = "dd/MM/yyyy"
            DataGridViewCellStyle1.NullValue = Nothing
            Me.CommentsDate.DefaultCellStyle = DataGridViewCellStyle1
            Me.CommentsDate.HeaderText = "Comments Date"
            Me.CommentsDate.Name = "CommentsDate"
            Me.CommentsDate.ReadOnly = True
            Me.CommentsDate.Width = 120
            '
            'Duration
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.Format = "N2"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.Duration.DefaultCellStyle = DataGridViewCellStyle2
            Me.Duration.HeaderText = "Duration"
            Me.Duration.Name = "Duration"
            Me.Duration.ReadOnly = True
            '
            'Comments
            '
            Me.Comments.HeaderText = "Comments"
            Me.Comments.Name = "Comments"
            Me.Comments.ReadOnly = True
            Me.Comments.Width = 400
            '
            'Purpose
            '
            Me.Purpose.HeaderText = "Purpose"
            Me.Purpose.Name = "Purpose"
            Me.Purpose.ReadOnly = True
            Me.Purpose.Width = 150
            '
            'frmCommentsEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(822, 629)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.tolEmployee)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmCommentsEntry"
            Me.Text = "Comments Viewer"
            Me.tolEmployee.ResumeLayout(False)
            Me.tolEmployee.PerformLayout()
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dgvComments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
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
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cbEmployee As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cmdFind As System.Windows.Forms.Button
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents dgvComments As System.Windows.Forms.DataGridView
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents tbComments As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents dtpComments As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cbType As System.Windows.Forms.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cbPurpose As System.Windows.Forms.ComboBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents tbInTime As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents tbOutTime As System.Windows.Forms.TextBox
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents cmdInsert As System.Windows.Forms.Button
        Friend WithEvents cmdUpdate As System.Windows.Forms.Button
        Friend WithEvents cmdNew As System.Windows.Forms.Button
        Friend WithEvents btnManualEntry As System.Windows.Forms.Button
        Friend WithEvents CommentsID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CommentsDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Comments As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Purpose As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace