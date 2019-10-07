Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmHolidayList
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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.dgvHoliday = New System.Windows.Forms.DataGridView()
            Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CalDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.HolidayName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ImplementedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdPrintPreview = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cbType = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cmdFind = New System.Windows.Forms.Button()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            CType(Me.dgvHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dgvHoliday
            '
            Me.dgvHoliday.AllowUserToAddRows = False
            Me.dgvHoliday.AllowUserToDeleteRows = False
            Me.dgvHoliday.AllowUserToResizeColumns = False
            Me.dgvHoliday.AllowUserToResizeRows = False
            Me.dgvHoliday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvHoliday.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvHoliday.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.CalDate, Me.HolidayName, Me.ImplementedOn})
            Me.dgvHoliday.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
            Me.dgvHoliday.Location = New System.Drawing.Point(8, 115)
            Me.dgvHoliday.MultiSelect = False
            Me.dgvHoliday.Name = "dgvHoliday"
            Me.dgvHoliday.RowHeadersWidth = 25
            Me.dgvHoliday.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
            Me.dgvHoliday.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvHoliday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvHoliday.Size = New System.Drawing.Size(547, 440)
            Me.dgvHoliday.TabIndex = 0
            '
            'ID
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.ID.DefaultCellStyle = DataGridViewCellStyle2
            Me.ID.HeaderText = "SL."
            Me.ID.Name = "ID"
            Me.ID.Width = 40
            '
            'CalDate
            '
            DataGridViewCellStyle3.Format = "D"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.CalDate.DefaultCellStyle = DataGridViewCellStyle3
            Me.CalDate.HeaderText = "Holiday"
            Me.CalDate.Name = "CalDate"
            Me.CalDate.Width = 150
            '
            'HolidayName
            '
            Me.HolidayName.HeaderText = "Holiday Name"
            Me.HolidayName.Name = "HolidayName"
            Me.HolidayName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.HolidayName.Width = 250
            '
            'ImplementedOn
            '
            Me.ImplementedOn.HeaderText = "Group"
            Me.ImplementedOn.Name = "ImplementedOn"
            Me.ImplementedOn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.ImplementedOn.Width = 80
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(564, 40)
            Me.gbTitleBar.TabIndex = 6
            '
            'Label9
            '
            Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(207, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(149, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Holiday List"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdPrintPreview)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 559)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(564, 46)
            Me.Panel3.TabIndex = 9
            '
            'cmdPrintPreview
            '
            Me.cmdPrintPreview.Location = New System.Drawing.Point(186, 9)
            Me.cmdPrintPreview.Name = "cmdPrintPreview"
            Me.cmdPrintPreview.Size = New System.Drawing.Size(97, 28)
            Me.cmdPrintPreview.TabIndex = 20
            Me.cmdPrintPreview.Text = "Print Preview"
            Me.cmdPrintPreview.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(296, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.cbType)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.cmdFind)
            Me.GroupBox1.Controls.Add(Me.dtToDate)
            Me.GroupBox1.Controls.Add(Me.dtFromDate)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(9, 43)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(546, 67)
            Me.GroupBox1.TabIndex = 10
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Search Holiday"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(368, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(46, 15)
            Me.Label1.TabIndex = 30
            Me.Label1.Text = "Group"
            '
            'cbType
            '
            Me.cbType.DisplayMember = "DeptName"
            Me.cbType.DropDownHeight = 100
            Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbType.FormattingEnabled = True
            Me.cbType.IntegralHeight = False
            Me.cbType.ItemHeight = 13
            Me.cbType.Location = New System.Drawing.Point(310, 33)
            Me.cbType.Name = "cbType"
            Me.cbType.Size = New System.Drawing.Size(163, 21)
            Me.cbType.TabIndex = 29
            Me.cbType.ValueMember = "Id"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(103, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 15)
            Me.Label2.TabIndex = 28
            Me.Label2.Text = "From"
            '
            'cmdFind
            '
            Me.cmdFind.Location = New System.Drawing.Point(486, 32)
            Me.cmdFind.Name = "cmdFind"
            Me.cmdFind.Size = New System.Drawing.Size(46, 24)
            Me.cmdFind.TabIndex = 27
            Me.cmdFind.Text = "GO"
            Me.cmdFind.UseVisualStyleBackColor = True
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = "MM/dd/yyyy"
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtToDate.Location = New System.Drawing.Point(190, 34)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(111, 20)
            Me.dtToDate.TabIndex = 26
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = "MM/dd/yyyy"
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtFromDate.Location = New System.Drawing.Point(71, 34)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(111, 20)
            Me.dtFromDate.TabIndex = 25
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(232, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(23, 15)
            Me.Label4.TabIndex = 24
            Me.Label4.Text = "To"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(9, 37)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(55, 15)
            Me.Label3.TabIndex = 23
            Me.Label3.Text = "Holiday"
            '
            'frmHolidayList
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(564, 605)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.dgvHoliday)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmHolidayList"
            Me.Text = "Holiday List"
            CType(Me.dgvHoliday, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dgvHoliday As System.Windows.Forms.DataGridView
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cmdFind As System.Windows.Forms.Button
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cbType As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CalDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents HolidayName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ImplementedOn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cmdPrintPreview As System.Windows.Forms.Button
    End Class
End NameSpace