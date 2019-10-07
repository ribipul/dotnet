Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmEntryHoliday
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntryHoliday))
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cmdNew = New System.Windows.Forms.Button()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.cmdInsert = New System.Windows.Forms.Button()
            Me.cmdUpdate = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.tbDescription = New System.Windows.Forms.TextBox()
            Me.tbHolidayName = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lbHolodayList = New System.Windows.Forms.ListBox()
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
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
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
            Me.gbTitleBar.Size = New System.Drawing.Size(662, 41)
            Me.gbTitleBar.TabIndex = 34
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(259, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(147, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Set Holiday"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 328)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(662, 48)
            Me.Panel3.TabIndex = 36
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(547, 10)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cmdNew)
            Me.GroupBox1.Controls.Add(Me.cmdDelete)
            Me.GroupBox1.Controls.Add(Me.cmdInsert)
            Me.GroupBox1.Controls.Add(Me.cmdUpdate)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.tbDescription)
            Me.GroupBox1.Controls.Add(Me.tbHolidayName)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.lbHolodayList)
            Me.GroupBox1.Location = New System.Drawing.Point(11, 68)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(639, 250)
            Me.GroupBox1.TabIndex = 37
            Me.GroupBox1.TabStop = False
            '
            'cmdNew
            '
            Me.cmdNew.Location = New System.Drawing.Point(329, 206)
            Me.cmdNew.Name = "cmdNew"
            Me.cmdNew.Size = New System.Drawing.Size(56, 25)
            Me.cmdNew.TabIndex = 31
            Me.cmdNew.Text = "New"
            Me.cmdNew.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Enabled = False
            Me.cmdDelete.Location = New System.Drawing.Point(535, 206)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
            Me.cmdDelete.TabIndex = 30
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdInsert
            '
            Me.cmdInsert.Enabled = False
            Me.cmdInsert.Location = New System.Drawing.Point(397, 206)
            Me.cmdInsert.Name = "cmdInsert"
            Me.cmdInsert.Size = New System.Drawing.Size(56, 25)
            Me.cmdInsert.TabIndex = 29
            Me.cmdInsert.Text = "Insert"
            Me.cmdInsert.UseVisualStyleBackColor = True
            '
            'cmdUpdate
            '
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.Location = New System.Drawing.Point(467, 206)
            Me.cmdUpdate.Name = "cmdUpdate"
            Me.cmdUpdate.Size = New System.Drawing.Size(56, 25)
            Me.cmdUpdate.TabIndex = 28
            Me.cmdUpdate.Text = "Update"
            Me.cmdUpdate.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Green
            Me.Label3.Location = New System.Drawing.Point(283, 95)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(117, 13)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "Holiday Description"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Green
            Me.Label2.Location = New System.Drawing.Point(283, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(209, 13)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Holiday Name To Update  or Delete"
            '
            'tbDescription
            '
            Me.tbDescription.Location = New System.Drawing.Point(286, 117)
            Me.tbDescription.Multiline = True
            Me.tbDescription.Name = "tbDescription"
            Me.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.tbDescription.Size = New System.Drawing.Size(341, 67)
            Me.tbDescription.TabIndex = 3
            '
            'tbHolidayName
            '
            Me.tbHolidayName.Location = New System.Drawing.Point(286, 62)
            Me.tbHolidayName.Name = "tbHolidayName"
            Me.tbHolidayName.Size = New System.Drawing.Size(341, 20)
            Me.tbHolidayName.TabIndex = 2
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Green
            Me.Label1.Location = New System.Drawing.Point(10, 17)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(118, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Current Holiday List"
            '
            'lbHolodayList
            '
            Me.lbHolodayList.FormattingEnabled = True
            Me.lbHolodayList.Location = New System.Drawing.Point(13, 40)
            Me.lbHolodayList.Name = "lbHolodayList"
            Me.lbHolodayList.Size = New System.Drawing.Size(263, 199)
            Me.lbHolodayList.TabIndex = 0
            '
            'tolEmployee
            '
            Me.tolEmployee.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.tolEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuAddNew, Me.mnuEdit, Me.mnuCancel, Me.mnuSave, Me.mnuDelete, Me.ToolStripSeparator1, Me.mnuMoveFirst, Me.mnuMovePrevious, Me.mnuMoveNext, Me.mnuMoveLast, Me.ToolStripSeparator3})
            Me.tolEmployee.Location = New System.Drawing.Point(0, 41)
            Me.tolEmployee.Name = "tolEmployee"
            Me.tolEmployee.Size = New System.Drawing.Size(662, 25)
            Me.tolEmployee.TabIndex = 38
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
            'frmEntryHoliday
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(662, 376)
            Me.Controls.Add(Me.tolEmployee)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmEntryHoliday"
            Me.Text = "Entry Holiday"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.tolEmployee.ResumeLayout(False)
            Me.tolEmployee.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents tbDescription As System.Windows.Forms.TextBox
        Friend WithEvents tbHolidayName As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lbHolodayList As System.Windows.Forms.ListBox
        Friend WithEvents cmdNew As System.Windows.Forms.Button
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents cmdInsert As System.Windows.Forms.Button
        Friend WithEvents cmdUpdate As System.Windows.Forms.Button
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
    End Class
End NameSpace