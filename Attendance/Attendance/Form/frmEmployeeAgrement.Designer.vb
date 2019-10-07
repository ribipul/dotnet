Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmEmployeeAgreement
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeAgreement))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.gbDepartment = New System.Windows.Forms.GroupBox()
            Me.lbEmployee = New System.Windows.Forms.ListBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.lblEmployee = New System.Windows.Forms.Label()
            Me.gbAgrement = New System.Windows.Forms.GroupBox()
            Me.cbEmployeeType = New System.Windows.Forms.ComboBox()
            Me.cmdNew = New System.Windows.Forms.Button()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.cmdInsert = New System.Windows.Forms.Button()
            Me.cmdUpdate = New System.Windows.Forms.Button()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.txtWorkHour = New System.Windows.Forms.TextBox()
            Me.txtStartTime = New System.Windows.Forms.TextBox()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PersonalAgreementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.dtgAgreement = New System.Windows.Forms.DataGridView()
            Me.SN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.empType = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.sDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.startHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.workHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            Me.tolEmployee.SuspendLayout()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.gbDepartment.SuspendLayout()
            Me.gbAgrement.SuspendLayout()
            CType(Me.PersonalAgreementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dtgAgreement, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel1.Controls.Add(Me.tolEmployee)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(667, 27)
            Me.Panel1.TabIndex = 7
            '
            'tolEmployee
            '
            Me.tolEmployee.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.tolEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuAddNew, Me.mnuEdit, Me.mnuCancel, Me.mnuSave, Me.mnuDelete, Me.ToolStripSeparator1, Me.mnuMoveFirst, Me.mnuMovePrevious, Me.mnuMoveNext, Me.mnuMoveLast, Me.ToolStripSeparator3})
            Me.tolEmployee.Location = New System.Drawing.Point(0, 0)
            Me.tolEmployee.Name = "tolEmployee"
            Me.tolEmployee.Size = New System.Drawing.Size(667, 25)
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
            Me.mnuAddNew.Text = "New"
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
            Me.mnuEdit.Text = "Edit/Update"
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
            Me.mnuCancel.Text = "Cancel"
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
            Me.mnuSave.Text = "Save"
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
            Me.mnuDelete.Text = "Delete"
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
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(667, 40)
            Me.gbTitleBar.TabIndex = 6
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(223, 4)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(264, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Employee Agreement"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 364)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(667, 42)
            Me.Panel3.TabIndex = 8
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(546, 7)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'gbDepartment
            '
            Me.gbDepartment.Controls.Add(Me.lbEmployee)
            Me.gbDepartment.Controls.Add(Me.Label6)
            Me.gbDepartment.Controls.Add(Me.cbDepartment)
            Me.gbDepartment.Controls.Add(Me.lblEmployee)
            Me.gbDepartment.Location = New System.Drawing.Point(13, 73)
            Me.gbDepartment.Name = "gbDepartment"
            Me.gbDepartment.Size = New System.Drawing.Size(297, 279)
            Me.gbDepartment.TabIndex = 9
            Me.gbDepartment.TabStop = False
            '
            'lbEmployee
            '
            Me.lbEmployee.FormattingEnabled = True
            Me.lbEmployee.Location = New System.Drawing.Point(19, 87)
            Me.lbEmployee.Name = "lbEmployee"
            Me.lbEmployee.Size = New System.Drawing.Size(258, 186)
            Me.lbEmployee.TabIndex = 8
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(16, 71)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(85, 13)
            Me.Label6.TabIndex = 7
            Me.Label6.Text = "Employee List"
            '
            'cbDepartment
            '
            Me.cbDepartment.DropDownHeight = 100
            Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDepartment.FormattingEnabled = True
            Me.cbDepartment.IntegralHeight = False
            Me.cbDepartment.ItemHeight = 13
            Me.cbDepartment.Location = New System.Drawing.Point(19, 41)
            Me.cbDepartment.Name = "cbDepartment"
            Me.cbDepartment.Size = New System.Drawing.Size(258, 21)
            Me.cbDepartment.TabIndex = 5
            '
            'lblEmployee
            '
            Me.lblEmployee.AutoSize = True
            Me.lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.Black
            Me.lblEmployee.Location = New System.Drawing.Point(15, 16)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(96, 13)
            Me.lblEmployee.TabIndex = 4
            Me.lblEmployee.Text = "Department List"
            '
            'gbAgrement
            '
            Me.gbAgrement.Controls.Add(Me.cbEmployeeType)
            Me.gbAgrement.Controls.Add(Me.cmdNew)
            Me.gbAgrement.Controls.Add(Me.cmdDelete)
            Me.gbAgrement.Controls.Add(Me.cmdInsert)
            Me.gbAgrement.Controls.Add(Me.cmdUpdate)
            Me.gbAgrement.Controls.Add(Me.dtpStartDate)
            Me.gbAgrement.Controls.Add(Me.txtWorkHour)
            Me.gbAgrement.Controls.Add(Me.txtStartTime)
            Me.gbAgrement.Controls.Add(Me.txtSN)
            Me.gbAgrement.Controls.Add(Me.Label5)
            Me.gbAgrement.Controls.Add(Me.Label3)
            Me.gbAgrement.Controls.Add(Me.Label4)
            Me.gbAgrement.Controls.Add(Me.Label2)
            Me.gbAgrement.Controls.Add(Me.Label1)
            Me.gbAgrement.Location = New System.Drawing.Point(321, 182)
            Me.gbAgrement.Name = "gbAgrement"
            Me.gbAgrement.Size = New System.Drawing.Size(330, 169)
            Me.gbAgrement.TabIndex = 10
            Me.gbAgrement.TabStop = False
            '
            'cbEmployeeType
            '
            Me.cbEmployeeType.DropDownHeight = 100
            Me.cbEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEmployeeType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbEmployeeType.FormattingEnabled = True
            Me.cbEmployeeType.IntegralHeight = False
            Me.cbEmployeeType.ItemHeight = 13
            Me.cbEmployeeType.Location = New System.Drawing.Point(140, 36)
            Me.cbEmployeeType.Name = "cbEmployeeType"
            Me.cbEmployeeType.Size = New System.Drawing.Size(169, 21)
            Me.cbEmployeeType.TabIndex = 108
            '
            'cmdNew
            '
            Me.cmdNew.Location = New System.Drawing.Point(37, 137)
            Me.cmdNew.Name = "cmdNew"
            Me.cmdNew.Size = New System.Drawing.Size(56, 25)
            Me.cmdNew.TabIndex = 107
            Me.cmdNew.Text = "New"
            Me.cmdNew.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Enabled = False
            Me.cmdDelete.Location = New System.Drawing.Point(240, 137)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
            Me.cmdDelete.TabIndex = 106
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdInsert
            '
            Me.cmdInsert.Enabled = False
            Me.cmdInsert.Location = New System.Drawing.Point(105, 137)
            Me.cmdInsert.Name = "cmdInsert"
            Me.cmdInsert.Size = New System.Drawing.Size(56, 25)
            Me.cmdInsert.TabIndex = 105
            Me.cmdInsert.Text = "Insert"
            Me.cmdInsert.UseVisualStyleBackColor = True
            '
            'cmdUpdate
            '
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.Location = New System.Drawing.Point(172, 137)
            Me.cmdUpdate.Name = "cmdUpdate"
            Me.cmdUpdate.Size = New System.Drawing.Size(56, 25)
            Me.cmdUpdate.TabIndex = 104
            Me.cmdUpdate.Text = "Update"
            Me.cmdUpdate.UseVisualStyleBackColor = True
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(140, 61)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(169, 20)
            Me.dtpStartDate.TabIndex = 11
            '
            'txtWorkHour
            '
            Me.txtWorkHour.Location = New System.Drawing.Point(140, 109)
            Me.txtWorkHour.MaxLength = 2
            Me.txtWorkHour.Name = "txtWorkHour"
            Me.txtWorkHour.Size = New System.Drawing.Size(169, 20)
            Me.txtWorkHour.TabIndex = 9
            '
            'txtStartTime
            '
            Me.txtStartTime.Location = New System.Drawing.Point(140, 85)
            Me.txtStartTime.Name = "txtStartTime"
            Me.txtStartTime.Size = New System.Drawing.Size(169, 20)
            Me.txtStartTime.TabIndex = 8
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.txtSN.Enabled = False
            Me.txtSN.Location = New System.Drawing.Point(140, 12)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.ReadOnly = True
            Me.txtSN.Size = New System.Drawing.Size(169, 20)
            Me.txtSN.TabIndex = 5
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(14, 110)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(68, 13)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "Work Hour"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(14, 89)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(65, 13)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Start Hour"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(14, 65)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(65, 13)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Start Date"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(14, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(93, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Employee Type"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(14, 17)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(24, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "SN"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.dtgAgreement)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(320, 73)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(331, 109)
            Me.GroupBox1.TabIndex = 11
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Employee Detail:"
            '
            'dtgAgreement
            '
            Me.dtgAgreement.AllowUserToAddRows = False
            Me.dtgAgreement.AllowUserToDeleteRows = False
            Me.dtgAgreement.AllowUserToResizeColumns = False
            Me.dtgAgreement.AllowUserToResizeRows = False
            Me.dtgAgreement.AutoGenerateColumns = False
            Me.dtgAgreement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dtgAgreement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SN, Me.EID, Me.empType, Me.sDate, Me.startHour, Me.workHour})
            Me.dtgAgreement.DataSource = Me.lbEmployee.CustomTabOffsets
            Me.dtgAgreement.Location = New System.Drawing.Point(4, 17)
            Me.dtgAgreement.Name = "dtgAgreement"
            Me.dtgAgreement.RowHeadersVisible = False
            Me.dtgAgreement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dtgAgreement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dtgAgreement.Size = New System.Drawing.Size(323, 86)
            Me.dtgAgreement.TabIndex = 0
            '
            'SN
            '
            Me.SN.HeaderText = "SL."
            Me.SN.Name = "SN"
            Me.SN.Visible = False
            '
            'EID
            '
            Me.EID.HeaderText = "EmpID"
            Me.EID.Name = "EID"
            Me.EID.Visible = False
            '
            'empType
            '
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.empType.DefaultCellStyle = DataGridViewCellStyle1
            Me.empType.HeaderText = "EmployeeType"
            Me.empType.Name = "empType"
            Me.empType.ReadOnly = True
            Me.empType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.empType.Width = 80
            '
            'sDate
            '
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.sDate.DefaultCellStyle = DataGridViewCellStyle2
            Me.sDate.HeaderText = "StartDate"
            Me.sDate.Name = "sDate"
            Me.sDate.ReadOnly = True
            Me.sDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.sDate.Width = 80
            '
            'startHour
            '
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.startHour.DefaultCellStyle = DataGridViewCellStyle3
            Me.startHour.HeaderText = "StartTime"
            Me.startHour.Name = "startHour"
            Me.startHour.ReadOnly = True
            Me.startHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.startHour.Width = 80
            '
            'workHour
            '
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.workHour.DefaultCellStyle = DataGridViewCellStyle4
            Me.workHour.HeaderText = "WorkHour"
            Me.workHour.Name = "workHour"
            Me.workHour.ReadOnly = True
            Me.workHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.workHour.Width = 80
            '
            'frmEmployeeAgreement
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(667, 406)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.gbAgrement)
            Me.Controls.Add(Me.gbDepartment)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmEmployeeAgreement"
            Me.Text = "Employee Agreement"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.tolEmployee.ResumeLayout(False)
            Me.tolEmployee.PerformLayout()
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.gbDepartment.ResumeLayout(False)
            Me.gbDepartment.PerformLayout()
            Me.gbAgrement.ResumeLayout(False)
            Me.gbAgrement.PerformLayout()
            CType(Me.PersonalAgreementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dtgAgreement, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
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
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents gbDepartment As System.Windows.Forms.GroupBox
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Friend WithEvents gbAgrement As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtWorkHour As System.Windows.Forms.TextBox
        Friend WithEvents txtStartTime As System.Windows.Forms.TextBox
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents PersonalAgreementBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents lbEmployee As System.Windows.Forms.ListBox
        Friend WithEvents cmdNew As System.Windows.Forms.Button
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents cmdInsert As System.Windows.Forms.Button
        Friend WithEvents cmdUpdate As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents dtgAgreement As System.Windows.Forms.DataGridView
        Friend WithEvents cbEmployeeType As System.Windows.Forms.ComboBox
        Friend WithEvents SN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents empType As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents sDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents startHour As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents workHour As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace