Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmEmployee
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployee))
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.cbSearchDepartment = New System.Windows.Forms.ComboBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.cbEmployee = New System.Windows.Forms.ComboBox()
            Me.lblEmployee = New System.Windows.Forms.Label()
            Me.txtContactNo = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cmdNew = New System.Windows.Forms.Button()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.cmdInsert = New System.Windows.Forms.Button()
            Me.cmdUpdate = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dtConfirmedDate = New System.Windows.Forms.DateTimePicker()
            Me.rbOnProbition = New System.Windows.Forms.RadioButton()
            Me.rbConfirmed = New System.Windows.Forms.RadioButton()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
            Me.rbInactive = New System.Windows.Forms.RadioButton()
            Me.rbActive = New System.Windows.Forms.RadioButton()
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.dtJoiningDate = New System.Windows.Forms.DateTimePicker()
            Me.txtDesignation = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.txtCardNo = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cbGroup = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblEmpDetail = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.tolEmployee = New System.Windows.Forms.ToolStrip()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuAddNew = New System.Windows.Forms.ToolStripButton()
            Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
            Me.mnuCancel = New System.Windows.Forms.ToolStripButton()
            Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
            Me.mnuSave = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuMoveFirst = New System.Windows.Forms.ToolStripButton()
            Me.mnuMovePrevious = New System.Windows.Forms.ToolStripButton()
            Me.mnuMoveNext = New System.Windows.Forms.ToolStripButton()
            Me.mnuMoveLast = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.tolEmployee.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(719, 40)
            Me.gbTitleBar.TabIndex = 4
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(227, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(294, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Employee Insert/Update"
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.cbSearchDepartment)
            Me.Panel2.Controls.Add(Me.Label11)
            Me.Panel2.Controls.Add(Me.cbEmployee)
            Me.Panel2.Controls.Add(Me.lblEmployee)
            Me.Panel2.Controls.Add(Me.txtContactNo)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.cmdNew)
            Me.Panel2.Controls.Add(Me.cmdDelete)
            Me.Panel2.Controls.Add(Me.cmdInsert)
            Me.Panel2.Controls.Add(Me.cmdUpdate)
            Me.Panel2.Controls.Add(Me.GroupBox2)
            Me.Panel2.Controls.Add(Me.GroupBox1)
            Me.Panel2.Controls.Add(Me.cbDepartment)
            Me.Panel2.Controls.Add(Me.dtJoiningDate)
            Me.Panel2.Controls.Add(Me.txtDesignation)
            Me.Panel2.Controls.Add(Me.txtName)
            Me.Panel2.Controls.Add(Me.txtCardNo)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.cbGroup)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtSerial)
            Me.Panel2.Controls.Add(Me.lblEmpDetail)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 65)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(719, 365)
            Me.Panel2.TabIndex = 6
            '
            'cbSearchDepartment
            '
            Me.cbSearchDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbSearchDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbSearchDepartment.FormattingEnabled = True
            Me.cbSearchDepartment.Location = New System.Drawing.Point(137, 11)
            Me.cbSearchDepartment.Name = "cbSearchDepartment"
            Me.cbSearchDepartment.Size = New System.Drawing.Size(269, 21)
            Me.cbSearchDepartment.TabIndex = 113
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(13, 11)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(100, 13)
            Me.Label11.TabIndex = 112
            Me.Label11.Text = "Department List:"
            '
            'cbEmployee
            '
            Me.cbEmployee.DropDownHeight = 100
            Me.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbEmployee.FormattingEnabled = True
            Me.cbEmployee.IntegralHeight = False
            Me.cbEmployee.ItemHeight = 13
            Me.cbEmployee.Location = New System.Drawing.Point(136, 38)
            Me.cbEmployee.Name = "cbEmployee"
            Me.cbEmployee.Size = New System.Drawing.Size(269, 21)
            Me.cbEmployee.TabIndex = 111
            '
            'lblEmployee
            '
            Me.lblEmployee.AutoSize = True
            Me.lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.Black
            Me.lblEmployee.Location = New System.Drawing.Point(12, 40)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(89, 13)
            Me.lblEmployee.TabIndex = 110
            Me.lblEmployee.Text = "Employee List:"
            '
            'txtContactNo
            '
            Me.txtContactNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtContactNo.Location = New System.Drawing.Point(136, 162)
            Me.txtContactNo.Name = "txtContactNo"
            Me.txtContactNo.Size = New System.Drawing.Size(269, 20)
            Me.txtContactNo.TabIndex = 109
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(12, 162)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(67, 13)
            Me.Label10.TabIndex = 108
            Me.Label10.Text = "Contact No.:"
            '
            'cmdNew
            '
            Me.cmdNew.Location = New System.Drawing.Point(247, 287)
            Me.cmdNew.Name = "cmdNew"
            Me.cmdNew.Size = New System.Drawing.Size(56, 25)
            Me.cmdNew.TabIndex = 107
            Me.cmdNew.Text = "New"
            Me.cmdNew.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Enabled = False
            Me.cmdDelete.Location = New System.Drawing.Point(450, 287)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
            Me.cmdDelete.TabIndex = 106
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdInsert
            '
            Me.cmdInsert.Enabled = False
            Me.cmdInsert.Location = New System.Drawing.Point(315, 287)
            Me.cmdInsert.Name = "cmdInsert"
            Me.cmdInsert.Size = New System.Drawing.Size(56, 25)
            Me.cmdInsert.TabIndex = 105
            Me.cmdInsert.Text = "Insert"
            Me.cmdInsert.UseVisualStyleBackColor = True
            '
            'cmdUpdate
            '
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.Location = New System.Drawing.Point(382, 287)
            Me.cmdUpdate.Name = "cmdUpdate"
            Me.cmdUpdate.Size = New System.Drawing.Size(56, 25)
            Me.cmdUpdate.TabIndex = 104
            Me.cmdUpdate.Text = "Update"
            Me.cmdUpdate.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.dtConfirmedDate)
            Me.GroupBox2.Controls.Add(Me.rbOnProbition)
            Me.GroupBox2.Controls.Add(Me.rbConfirmed)
            Me.GroupBox2.ForeColor = System.Drawing.Color.MediumVioletRed
            Me.GroupBox2.Location = New System.Drawing.Point(422, 128)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(286, 94)
            Me.GroupBox2.TabIndex = 31
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Employee Status"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(115, 26)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(106, 13)
            Me.Label8.TabIndex = 15
            Me.Label8.Text = "Date of Confirmation:"
            Me.Label8.Visible = False
            '
            'dtConfirmedDate
            '
            Me.dtConfirmedDate.CustomFormat = "MM/dd/yyyy"
            Me.dtConfirmedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtConfirmedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtConfirmedDate.Location = New System.Drawing.Point(118, 52)
            Me.dtConfirmedDate.Name = "dtConfirmedDate"
            Me.dtConfirmedDate.Size = New System.Drawing.Size(162, 20)
            Me.dtConfirmedDate.TabIndex = 14
            Me.dtConfirmedDate.Visible = False
            '
            'rbOnProbition
            '
            Me.rbOnProbition.AutoSize = True
            Me.rbOnProbition.ForeColor = System.Drawing.Color.Black
            Me.rbOnProbition.Location = New System.Drawing.Point(13, 55)
            Me.rbOnProbition.Name = "rbOnProbition"
            Me.rbOnProbition.Size = New System.Drawing.Size(83, 17)
            Me.rbOnProbition.TabIndex = 3
            Me.rbOnProbition.TabStop = True
            Me.rbOnProbition.Text = "On Probition"
            Me.rbOnProbition.UseVisualStyleBackColor = True
            '
            'rbConfirmed
            '
            Me.rbConfirmed.AutoSize = True
            Me.rbConfirmed.ForeColor = System.Drawing.Color.Black
            Me.rbConfirmed.Location = New System.Drawing.Point(13, 24)
            Me.rbConfirmed.Name = "rbConfirmed"
            Me.rbConfirmed.Size = New System.Drawing.Size(72, 17)
            Me.rbConfirmed.TabIndex = 2
            Me.rbConfirmed.TabStop = True
            Me.rbConfirmed.Text = "Confirmed"
            Me.rbConfirmed.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Label7)
            Me.GroupBox1.Controls.Add(Me.dtEndDate)
            Me.GroupBox1.Controls.Add(Me.rbInactive)
            Me.GroupBox1.Controls.Add(Me.rbActive)
            Me.GroupBox1.ForeColor = System.Drawing.Color.MediumVioletRed
            Me.GroupBox1.Location = New System.Drawing.Point(422, 10)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(286, 93)
            Me.GroupBox1.TabIndex = 30
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Employee Activity Status"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(115, 28)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(55, 13)
            Me.Label7.TabIndex = 14
            Me.Label7.Text = "End Date:"
            Me.Label7.Visible = False
            '
            'dtEndDate
            '
            Me.dtEndDate.CustomFormat = "MM/dd/yyyy"
            Me.dtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtEndDate.Location = New System.Drawing.Point(118, 50)
            Me.dtEndDate.Name = "dtEndDate"
            Me.dtEndDate.Size = New System.Drawing.Size(162, 20)
            Me.dtEndDate.TabIndex = 13
            Me.dtEndDate.Visible = False
            '
            'rbInactive
            '
            Me.rbInactive.AutoSize = True
            Me.rbInactive.ForeColor = System.Drawing.Color.Black
            Me.rbInactive.Location = New System.Drawing.Point(13, 54)
            Me.rbInactive.Name = "rbInactive"
            Me.rbInactive.Size = New System.Drawing.Size(63, 17)
            Me.rbInactive.TabIndex = 1
            Me.rbInactive.TabStop = True
            Me.rbInactive.Text = "Inactive"
            Me.rbInactive.UseVisualStyleBackColor = True
            '
            'rbActive
            '
            Me.rbActive.ForeColor = System.Drawing.Color.Black
            Me.rbActive.Location = New System.Drawing.Point(13, 28)
            Me.rbActive.Name = "rbActive"
            Me.rbActive.Size = New System.Drawing.Size(71, 17)
            Me.rbActive.TabIndex = 0
            Me.rbActive.TabStop = True
            Me.rbActive.Text = "Active"
            Me.rbActive.UseVisualStyleBackColor = True
            '
            'cbDepartment
            '
            Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDepartment.FormattingEnabled = True
            Me.cbDepartment.Location = New System.Drawing.Point(136, 255)
            Me.cbDepartment.Name = "cbDepartment"
            Me.cbDepartment.Size = New System.Drawing.Size(269, 21)
            Me.cbDepartment.TabIndex = 29
            '
            'dtJoiningDate
            '
            Me.dtJoiningDate.CustomFormat = "MM/dd/yyyy"
            Me.dtJoiningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtJoiningDate.Location = New System.Drawing.Point(136, 223)
            Me.dtJoiningDate.Name = "dtJoiningDate"
            Me.dtJoiningDate.Size = New System.Drawing.Size(270, 20)
            Me.dtJoiningDate.TabIndex = 28
            '
            'txtDesignation
            '
            Me.txtDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDesignation.Location = New System.Drawing.Point(136, 192)
            Me.txtDesignation.Name = "txtDesignation"
            Me.txtDesignation.Size = New System.Drawing.Size(269, 20)
            Me.txtDesignation.TabIndex = 27
            '
            'txtName
            '
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtName.Location = New System.Drawing.Point(136, 132)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(269, 20)
            Me.txtName.TabIndex = 26
            '
            'txtCardNo
            '
            Me.txtCardNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCardNo.Location = New System.Drawing.Point(136, 102)
            Me.txtCardNo.Name = "txtCardNo"
            Me.txtCardNo.Size = New System.Drawing.Size(269, 20)
            Me.txtCardNo.TabIndex = 25
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(12, 255)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(65, 13)
            Me.Label6.TabIndex = 24
            Me.Label6.Text = "Department:"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(12, 223)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(69, 13)
            Me.Label5.TabIndex = 23
            Me.Label5.Text = "Joining Date:"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(12, 192)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(66, 13)
            Me.Label4.TabIndex = 22
            Me.Label4.Text = "Designation:"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(12, 135)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(38, 13)
            Me.Label3.TabIndex = 21
            Me.Label3.Text = "Name:"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(12, 105)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(49, 13)
            Me.Label2.TabIndex = 20
            Me.Label2.Text = "Card No:"
            '
            'cbGroup
            '
            Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbGroup.FormattingEnabled = True
            Me.cbGroup.Items.AddRange(New Object() {"NA", "A", "B"})
            Me.cbGroup.Location = New System.Drawing.Point(278, 69)
            Me.cbGroup.Name = "cbGroup"
            Me.cbGroup.Size = New System.Drawing.Size(128, 21)
            Me.cbGroup.TabIndex = 19
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(226, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(39, 13)
            Me.Label1.TabIndex = 18
            Me.Label1.Text = "Group:"
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.txtSerial.Enabled = False
            Me.txtSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSerial.Location = New System.Drawing.Point(136, 71)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.ReadOnly = True
            Me.txtSerial.Size = New System.Drawing.Size(72, 20)
            Me.txtSerial.TabIndex = 17
            '
            'lblEmpDetail
            '
            Me.lblEmpDetail.AutoSize = True
            Me.lblEmpDetail.ForeColor = System.Drawing.Color.Black
            Me.lblEmpDetail.Location = New System.Drawing.Point(12, 73)
            Me.lblEmpDetail.Name = "lblEmpDetail"
            Me.lblEmpDetail.Size = New System.Drawing.Size(53, 13)
            Me.lblEmpDetail.TabIndex = 16
            Me.lblEmpDetail.Text = "Serial No:"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 384)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(719, 46)
            Me.Panel3.TabIndex = 7
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(599, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'tolEmployee
            '
            Me.tolEmployee.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.tolEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuAddNew, Me.mnuEdit, Me.mnuCancel, Me.mnuDelete, Me.mnuSave, Me.ToolStripSeparator1, Me.mnuMoveFirst, Me.mnuMovePrevious, Me.mnuMoveNext, Me.mnuMoveLast, Me.ToolStripSeparator3})
            Me.tolEmployee.Location = New System.Drawing.Point(0, 0)
            Me.tolEmployee.Name = "tolEmployee"
            Me.tolEmployee.Size = New System.Drawing.Size(719, 25)
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
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel1.Controls.Add(Me.tolEmployee)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(719, 25)
            Me.Panel1.TabIndex = 5
            '
            'frmEmployee
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(719, 430)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.Name = "frmEmployee"
            Me.Text = "Employee Insert/Update"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.tolEmployee.ResumeLayout(False)
            Me.tolEmployee.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents dtConfirmedDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents rbOnProbition As System.Windows.Forms.RadioButton
        Friend WithEvents rbConfirmed As System.Windows.Forms.RadioButton
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents rbInactive As System.Windows.Forms.RadioButton
        Friend WithEvents rbActive As System.Windows.Forms.RadioButton
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents dtJoiningDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents lblEmpDetail As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents cmdNew As System.Windows.Forms.Button
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents cmdInsert As System.Windows.Forms.Button
        Friend WithEvents cmdUpdate As System.Windows.Forms.Button
        Friend WithEvents txtContactNo As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cbSearchDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents cbEmployee As System.Windows.Forms.ComboBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Private WithEvents tolEmployee As System.Windows.Forms.ToolStrip
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuAddNew As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuCancel As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuMoveFirst As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuMovePrevious As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuMoveNext As System.Windows.Forms.ToolStripButton
        Friend WithEvents mnuMoveLast As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
    End Class
End NameSpace