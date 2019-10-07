Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConveyanceBill
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.dtConveyanceDate = New System.Windows.Forms.DateTimePicker()
            Me.cmdDelete = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.dtgConveyance = New System.Windows.Forms.DataGridView()
            Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SubmissionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ConveyanceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FromPlace = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ToPlace = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ModeOfTransport = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ConvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mnsConveyance = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmdSearch = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdSave = New System.Windows.Forms.Button()
            Me.cmdShow = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dtFrom = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.tbDesignation = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.dtTo = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.gbTitleBar.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dtgConveyance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mnsConveyance.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(690, 40)
            Me.gbTitleBar.TabIndex = 123
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(186, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(300, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Manage Conveyance Bill"
            '
            'dtConveyanceDate
            '
            Me.dtConveyanceDate.CustomFormat = "MM/dd/yyyy"
            Me.dtConveyanceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtConveyanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtConveyanceDate.Location = New System.Drawing.Point(33, 39)
            Me.dtConveyanceDate.Name = "dtConveyanceDate"
            Me.dtConveyanceDate.Size = New System.Drawing.Size(89, 20)
            Me.dtConveyanceDate.TabIndex = 122
            Me.dtConveyanceDate.Visible = False
            '
            'cmdDelete
            '
            Me.cmdDelete.Location = New System.Drawing.Point(272, 9)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New System.Drawing.Size(70, 28)
            Me.cmdDelete.TabIndex = 122
            Me.cmdDelete.Text = "Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.dtConveyanceDate)
            Me.GroupBox2.Controls.Add(Me.dtgConveyance)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(7, 147)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(678, 383)
            Me.GroupBox2.TabIndex = 124
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Employee Detail:"
            '
            'dtgConveyance
            '
            Me.dtgConveyance.AllowUserToResizeColumns = False
            Me.dtgConveyance.AllowUserToResizeRows = False
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dtgConveyance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dtgConveyance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dtgConveyance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpID, Me.SubmissionDate, Me.ConveyanceDate, Me.FromPlace, Me.ToPlace, Me.Purpose, Me.ModeOfTransport, Me.Amount, Me.ConvID})
            Me.dtgConveyance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
            Me.dtgConveyance.Location = New System.Drawing.Point(7, 17)
            Me.dtgConveyance.MultiSelect = False
            Me.dtgConveyance.Name = "dtgConveyance"
            Me.dtgConveyance.RowHeadersWidth = 25
            Me.dtgConveyance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
            Me.dtgConveyance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dtgConveyance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dtgConveyance.Size = New System.Drawing.Size(663, 360)
            Me.dtgConveyance.TabIndex = 0
            '
            'EmpID
            '
            Me.EmpID.HeaderText = "Employee ID"
            Me.EmpID.Name = "EmpID"
            Me.EmpID.ReadOnly = True
            Me.EmpID.Visible = False
            '
            'SubmissionDate
            '
            Me.SubmissionDate.HeaderText = "Submission Date"
            Me.SubmissionDate.Name = "SubmissionDate"
            Me.SubmissionDate.ReadOnly = True
            Me.SubmissionDate.Visible = False
            '
            'ConveyanceDate
            '
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.Format = "MM/dd/yyyy"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.ConveyanceDate.DefaultCellStyle = DataGridViewCellStyle2
            Me.ConveyanceDate.HeaderText = "Con. Date"
            Me.ConveyanceDate.Name = "ConveyanceDate"
            Me.ConveyanceDate.ReadOnly = True
            Me.ConveyanceDate.Width = 90
            '
            'FromPlace
            '
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FromPlace.DefaultCellStyle = DataGridViewCellStyle3
            Me.FromPlace.HeaderText = "From"
            Me.FromPlace.Name = "FromPlace"
            Me.FromPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.FromPlace.Width = 80
            '
            'ToPlace
            '
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ToPlace.DefaultCellStyle = DataGridViewCellStyle4
            Me.ToPlace.HeaderText = "To"
            Me.ToPlace.Name = "ToPlace"
            Me.ToPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.ToPlace.Width = 80
            '
            'Purpose
            '
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Purpose.DefaultCellStyle = DataGridViewCellStyle5
            Me.Purpose.HeaderText = "Purpose of Visit"
            Me.Purpose.Name = "Purpose"
            Me.Purpose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.Purpose.Width = 180
            '
            'ModeOfTransport
            '
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ModeOfTransport.DefaultCellStyle = DataGridViewCellStyle6
            Me.ModeOfTransport.HeaderText = "Mode of Transport"
            Me.ModeOfTransport.Name = "ModeOfTransport"
            Me.ModeOfTransport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.ModeOfTransport.Width = 135
            '
            'Amount
            '
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Amount.DefaultCellStyle = DataGridViewCellStyle7
            Me.Amount.HeaderText = "Amount"
            Me.Amount.Name = "Amount"
            Me.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.Amount.Width = 70
            '
            'ConvID
            '
            Me.ConvID.HeaderText = "Bill ID"
            Me.ConvID.Name = "ConvID"
            Me.ConvID.ReadOnly = True
            Me.ConvID.Visible = False
            '
            'mnsConveyance
            '
            Me.mnsConveyance.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsDelete})
            Me.mnsConveyance.Name = "ContextMenuStrip1"
            Me.mnsConveyance.Size = New System.Drawing.Size(145, 26)
            '
            'mnsDelete
            '
            Me.mnsDelete.Name = "mnsDelete"
            Me.mnsDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
            Me.mnsDelete.Size = New System.Drawing.Size(144, 22)
            Me.mnsDelete.Text = "&Delete"
            '
            'cmdSearch
            '
            Me.cmdSearch.Location = New System.Drawing.Point(592, 14)
            Me.cmdSearch.Name = "cmdSearch"
            Me.cmdSearch.Size = New System.Drawing.Size(78, 25)
            Me.cmdSearch.TabIndex = 134
            Me.cmdSearch.Text = "Search"
            Me.cmdSearch.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(123, 20)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(38, 13)
            Me.Label4.TabIndex = 133
            Me.Label4.Text = "From:"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdDelete)
            Me.Panel3.Controls.Add(Me.cmdSave)
            Me.Panel3.Controls.Add(Me.cmdShow)
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 530)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(690, 46)
            Me.Panel3.TabIndex = 121
            '
            'cmdSave
            '
            Me.cmdSave.Location = New System.Drawing.Point(194, 9)
            Me.cmdSave.Name = "cmdSave"
            Me.cmdSave.Size = New System.Drawing.Size(70, 28)
            Me.cmdSave.TabIndex = 115
            Me.cmdSave.Text = "Save"
            Me.cmdSave.UseVisualStyleBackColor = True
            '
            'cmdShow
            '
            Me.cmdShow.Location = New System.Drawing.Point(350, 9)
            Me.cmdShow.Name = "cmdShow"
            Me.cmdShow.Size = New System.Drawing.Size(82, 28)
            Me.cmdShow.TabIndex = 114
            Me.cmdShow.Text = "Print Preview"
            Me.cmdShow.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(440, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(70, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(333, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(26, 13)
            Me.Label3.TabIndex = 132
            Me.Label3.Text = "To:"
            '
            'dtFrom
            '
            Me.dtFrom.CustomFormat = "dd/MM/yyyy"
            Me.dtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtFrom.Location = New System.Drawing.Point(171, 17)
            Me.dtFrom.Name = "dtFrom"
            Me.dtFrom.Size = New System.Drawing.Size(148, 20)
            Me.dtFrom.TabIndex = 131
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(30, 19)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(59, 13)
            Me.Label2.TabIndex = 129
            Me.Label2.Text = "Bill Date:"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cmdSearch)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.dtFrom)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.tbDesignation)
            Me.GroupBox1.Controls.Add(Me.Label21)
            Me.GroupBox1.Controls.Add(Me.tbName)
            Me.GroupBox1.Controls.Add(Me.dtTo)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Location = New System.Drawing.Point(7, 44)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(677, 97)
            Me.GroupBox1.TabIndex = 122
            Me.GroupBox1.TabStop = False
            '
            'tbDesignation
            '
            Me.tbDesignation.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbDesignation.Location = New System.Drawing.Point(126, 71)
            Me.tbDesignation.Name = "tbDesignation"
            Me.tbDesignation.ReadOnly = True
            Me.tbDesignation.Size = New System.Drawing.Size(235, 13)
            Me.tbDesignation.TabIndex = 128
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Black
            Me.Label21.Location = New System.Drawing.Point(30, 69)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(78, 13)
            Me.Label21.TabIndex = 127
            Me.Label21.Text = "Designation:"
            '
            'tbName
            '
            Me.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.tbName.Location = New System.Drawing.Point(126, 46)
            Me.tbName.Name = "tbName"
            Me.tbName.ReadOnly = True
            Me.tbName.Size = New System.Drawing.Size(235, 13)
            Me.tbName.TabIndex = 122
            '
            'dtTo
            '
            Me.dtTo.CustomFormat = "dd/MM/yyyy"
            Me.dtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtTo.Location = New System.Drawing.Point(370, 17)
            Me.dtTo.Name = "dtTo"
            Me.dtTo.Size = New System.Drawing.Size(148, 20)
            Me.dtTo.TabIndex = 121
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Blue
            Me.Label1.Location = New System.Drawing.Point(30, 45)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Name:"
            '
            'frmConveyanceBill
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(690, 576)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.GroupBox1)
            Me.MaximizeBox = False
            Me.Name = "frmConveyanceBill"
            Me.Text = "Manage Conveyance Bill"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dtgConveyance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mnsConveyance.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents dtConveyanceDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents cmdDelete As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents dtgConveyance As System.Windows.Forms.DataGridView
        Friend WithEvents mnsConveyance As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents cmdSearch As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdSave As System.Windows.Forms.Button
        Friend WithEvents cmdShow As System.Windows.Forms.Button
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents tbDesignation As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SubmissionDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ConveyanceDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FromPlace As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ToPlace As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Purpose As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ModeOfTransport As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ConvID As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace