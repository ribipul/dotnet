Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDepartment
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartment))
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdExit = New System.Windows.Forms.Button()
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
            Me.cbDepartment = New System.Windows.Forms.ComboBox()
            Me.lblEmployee = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtDepartmentID = New System.Windows.Forms.TextBox()
            Me.txtDepartmentName = New System.Windows.Forms.TextBox()
            Me.txtStartingHour = New System.Windows.Forms.TextBox()
            Me.cmdNew = New System.Windows.Forms.Button()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.cmdInsert = New System.Windows.Forms.Button()
            Me.cmdUpdate = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cbEmployee = New System.Windows.Forms.ComboBox()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
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
            Me.gbTitleBar.Size = New System.Drawing.Size(546, 40)
            Me.gbTitleBar.TabIndex = 5
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(188, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(148, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Department"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 307)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(546, 46)
            Me.Panel3.TabIndex = 8
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(434, 10)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel1.Controls.Add(Me.tolEmployee)
            Me.Panel1.Controls.Add(Me.cbDepartment)
            Me.Panel1.Controls.Add(Me.lblEmployee)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(546, 77)
            Me.Panel1.TabIndex = 9
            '
            'tolEmployee
            '
            Me.tolEmployee.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.tolEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuAddNew, Me.mnuEdit, Me.mnuCancel, Me.mnuSave, Me.mnuDelete, Me.ToolStripSeparator1, Me.mnuMoveFirst, Me.mnuMovePrevious, Me.mnuMoveNext, Me.mnuMoveLast, Me.ToolStripSeparator3})
            Me.tolEmployee.Location = New System.Drawing.Point(0, 0)
            Me.tolEmployee.Name = "tolEmployee"
            Me.tolEmployee.Size = New System.Drawing.Size(546, 25)
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
            'cbDepartment
            '
            Me.cbDepartment.DisplayMember = "Id"
            Me.cbDepartment.DropDownHeight = 100
            Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDepartment.FormattingEnabled = True
            Me.cbDepartment.IntegralHeight = False
            Me.cbDepartment.ItemHeight = 13
            Me.cbDepartment.Location = New System.Drawing.Point(194, 40)
            Me.cbDepartment.Name = "cbDepartment"
            Me.cbDepartment.Size = New System.Drawing.Size(269, 21)
            Me.cbDepartment.TabIndex = 3
            '
            'lblEmployee
            '
            Me.lblEmployee.AutoSize = True
            Me.lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.Black
            Me.lblEmployee.Location = New System.Drawing.Point(63, 42)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(96, 13)
            Me.lblEmployee.TabIndex = 2
            Me.lblEmployee.Text = "Department List"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(61, 139)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(89, 13)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Department ID"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(61, 171)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(108, 13)
            Me.Label2.TabIndex = 11
            Me.Label2.Text = "Department Name"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(60, 203)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(82, 13)
            Me.Label3.TabIndex = 12
            Me.Label3.Text = "Starting Hour"
            '
            'txtDepartmentID
            '
            Me.txtDepartmentID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.txtDepartmentID.Enabled = False
            Me.txtDepartmentID.Location = New System.Drawing.Point(199, 139)
            Me.txtDepartmentID.Name = "txtDepartmentID"
            Me.txtDepartmentID.ReadOnly = True
            Me.txtDepartmentID.Size = New System.Drawing.Size(259, 20)
            Me.txtDepartmentID.TabIndex = 13
            '
            'txtDepartmentName
            '
            Me.txtDepartmentName.Location = New System.Drawing.Point(199, 171)
            Me.txtDepartmentName.Name = "txtDepartmentName"
            Me.txtDepartmentName.Size = New System.Drawing.Size(259, 20)
            Me.txtDepartmentName.TabIndex = 14
            '
            'txtStartingHour
            '
            Me.txtStartingHour.Location = New System.Drawing.Point(199, 200)
            Me.txtStartingHour.Name = "txtStartingHour"
            Me.txtStartingHour.Size = New System.Drawing.Size(259, 20)
            Me.txtStartingHour.TabIndex = 15
            '
            'cmdNew
            '
            Me.cmdNew.Location = New System.Drawing.Point(155, 267)
            Me.cmdNew.Name = "cmdNew"
            Me.cmdNew.Size = New System.Drawing.Size(56, 25)
            Me.cmdNew.TabIndex = 103
            Me.cmdNew.Text = "New"
            Me.cmdNew.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Enabled = False
            Me.cmdDelete.Location = New System.Drawing.Point(358, 267)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
            Me.cmdDelete.TabIndex = 102
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdInsert
            '
            Me.cmdInsert.Enabled = False
            Me.cmdInsert.Location = New System.Drawing.Point(223, 267)
            Me.cmdInsert.Name = "cmdInsert"
            Me.cmdInsert.Size = New System.Drawing.Size(56, 25)
            Me.cmdInsert.TabIndex = 101
            Me.cmdInsert.Text = "Insert"
            Me.cmdInsert.UseVisualStyleBackColor = True
            '
            'cmdUpdate
            '
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.Location = New System.Drawing.Point(290, 267)
            Me.cmdUpdate.Name = "cmdUpdate"
            Me.cmdUpdate.Size = New System.Drawing.Size(56, 25)
            Me.cmdUpdate.TabIndex = 100
            Me.cmdUpdate.Text = "Update"
            Me.cmdUpdate.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(60, 235)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(138, 13)
            Me.Label4.TabIndex = 104
            Me.Label4.Text = "Dept. Head/Supervisor"
            '
            'cbEmployee
            '
            Me.cbEmployee.DropDownHeight = 100
            Me.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbEmployee.FormattingEnabled = True
            Me.cbEmployee.IntegralHeight = False
            Me.cbEmployee.ItemHeight = 13
            Me.cbEmployee.Location = New System.Drawing.Point(199, 232)
            Me.cbEmployee.Name = "cbEmployee"
            Me.cbEmployee.Size = New System.Drawing.Size(259, 21)
            Me.cbEmployee.TabIndex = 105
            '
            'frmDepartment
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(546, 353)
            Me.Controls.Add(Me.cbEmployee)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.cmdNew)
            Me.Controls.Add(Me.cmdDelete)
            Me.Controls.Add(Me.cmdInsert)
            Me.Controls.Add(Me.cmdUpdate)
            Me.Controls.Add(Me.txtStartingHour)
            Me.Controls.Add(Me.txtDepartmentName)
            Me.Controls.Add(Me.txtDepartmentID)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmDepartment"
            Me.Text = "Department"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.tolEmployee.ResumeLayout(False)
            Me.tolEmployee.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
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
        Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtDepartmentID As System.Windows.Forms.TextBox
        Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
        Friend WithEvents txtStartingHour As System.Windows.Forms.TextBox
        Friend WithEvents cmdNew As System.Windows.Forms.Button
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents cmdInsert As System.Windows.Forms.Button
        Friend WithEvents cmdUpdate As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cbEmployee As System.Windows.Forms.ComboBox
    End Class
End NameSpace