Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRetriveRecord
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
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cmdFind = New System.Windows.Forms.Button()
            Me.lblRetriveRecords = New System.Windows.Forms.Label()
            Me.lblRetriveFrom = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lbRecords = New System.Windows.Forms.ListBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.lblTransferRecords = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblLastTransfered = New System.Windows.Forms.Label()
            Me.lblLastTransfered1 = New System.Windows.Forms.Label()
            Me.lblPreviousTransfered = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblLogDate = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cmdRetriveRecords = New System.Windows.Forms.Button()
            Me.cmdTransferRecords = New System.Windows.Forms.Button()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.gbTitleBar.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(677, 40)
            Me.gbTitleBar.TabIndex = 5
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(231, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(201, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Retrive Records"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.cmdFind)
            Me.GroupBox1.Controls.Add(Me.lblRetriveRecords)
            Me.GroupBox1.Controls.Add(Me.lblRetriveFrom)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBox1.Location = New System.Drawing.Point(0, 40)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(677, 63)
            Me.GroupBox1.TabIndex = 6
            Me.GroupBox1.TabStop = False
            '
            'cmdFind
            '
            Me.cmdFind.Location = New System.Drawing.Point(603, 21)
            Me.cmdFind.Name = "cmdFind"
            Me.cmdFind.Size = New System.Drawing.Size(63, 25)
            Me.cmdFind.TabIndex = 17
            Me.cmdFind.Text = "Browse"
            Me.cmdFind.UseVisualStyleBackColor = True
            '
            'lblRetriveRecords
            '
            Me.lblRetriveRecords.AutoSize = True
            Me.lblRetriveRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRetriveRecords.Location = New System.Drawing.Point(138, 39)
            Me.lblRetriveRecords.Name = "lblRetriveRecords"
            Me.lblRetriveRecords.Size = New System.Drawing.Size(47, 15)
            Me.lblRetriveRecords.TabIndex = 3
            Me.lblRetriveRecords.Text = "00000"
            '
            'lblRetriveFrom
            '
            Me.lblRetriveFrom.AutoSize = True
            Me.lblRetriveFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRetriveFrom.Location = New System.Drawing.Point(138, 16)
            Me.lblRetriveFrom.Name = "lblRetriveFrom"
            Me.lblRetriveFrom.Size = New System.Drawing.Size(89, 15)
            Me.lblRetriveFrom.TabIndex = 2
            Me.lblRetriveFrom.Text = "Retrive From"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.Label2.Location = New System.Drawing.Point(10, 39)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(109, 15)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Retrive Records"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.Label1.Location = New System.Drawing.Point(10, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(89, 15)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Retrive From"
            '
            'lbRecords
            '
            Me.lbRecords.FormattingEnabled = True
            Me.lbRecords.Location = New System.Drawing.Point(8, 114)
            Me.lbRecords.Name = "lbRecords"
            Me.lbRecords.Size = New System.Drawing.Size(401, 225)
            Me.lbRecords.TabIndex = 7
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.lblTransferRecords)
            Me.GroupBox2.Controls.Add(Me.Label12)
            Me.GroupBox2.Controls.Add(Me.Label6)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.lblLastTransfered)
            Me.GroupBox2.Controls.Add(Me.lblLastTransfered1)
            Me.GroupBox2.Controls.Add(Me.lblPreviousTransfered)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.lblLogDate)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.Green
            Me.GroupBox2.Location = New System.Drawing.Point(417, 109)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(250, 230)
            Me.GroupBox2.TabIndex = 8
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Log Info"
            '
            'lblTransferRecords
            '
            Me.lblTransferRecords.AutoSize = True
            Me.lblTransferRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTransferRecords.ForeColor = System.Drawing.Color.Black
            Me.lblTransferRecords.Location = New System.Drawing.Point(130, 207)
            Me.lblTransferRecords.Name = "lblTransferRecords"
            Me.lblTransferRecords.Size = New System.Drawing.Size(15, 15)
            Me.lblTransferRecords.TabIndex = 9
            Me.lblTransferRecords.Text = "0"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(130, 190)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(69, 15)
            Me.Label12.TabIndex = 8
            Me.Label12.Text = "hh/mm/ss"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(10, 207)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(121, 15)
            Me.Label6.TabIndex = 7
            Me.Label6.Text = "Transfer Records:"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(10, 190)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(99, 15)
            Me.Label7.TabIndex = 6
            Me.Label7.Text = "Elapsed Time:"
            '
            'lblLastTransfered
            '
            Me.lblLastTransfered.AutoSize = True
            Me.lblLastTransfered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLastTransfered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblLastTransfered.Location = New System.Drawing.Point(9, 155)
            Me.lblLastTransfered.Name = "lblLastTransfered"
            Me.lblLastTransfered.Size = New System.Drawing.Size(81, 13)
            Me.lblLastTransfered.TabIndex = 5
            Me.lblLastTransfered.Text = "Last Transfered"
            '
            'lblLastTransfered1
            '
            Me.lblLastTransfered1.AutoSize = True
            Me.lblLastTransfered1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLastTransfered1.ForeColor = System.Drawing.Color.Green
            Me.lblLastTransfered1.Location = New System.Drawing.Point(9, 138)
            Me.lblLastTransfered1.Name = "lblLastTransfered1"
            Me.lblLastTransfered1.Size = New System.Drawing.Size(96, 13)
            Me.lblLastTransfered1.TabIndex = 4
            Me.lblLastTransfered1.Text = "Last Transfered"
            '
            'lblPreviousTransfered
            '
            Me.lblPreviousTransfered.AutoSize = True
            Me.lblPreviousTransfered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPreviousTransfered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblPreviousTransfered.Location = New System.Drawing.Point(9, 96)
            Me.lblPreviousTransfered.Name = "lblPreviousTransfered"
            Me.lblPreviousTransfered.Size = New System.Drawing.Size(102, 13)
            Me.lblPreviousTransfered.TabIndex = 3
            Me.lblPreviousTransfered.Text = "Previous Transfered"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Green
            Me.Label8.Location = New System.Drawing.Point(9, 79)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(121, 13)
            Me.Label8.TabIndex = 2
            Me.Label8.Text = "Previous Transfered"
            '
            'lblLogDate
            '
            Me.lblLogDate.AutoSize = True
            Me.lblLogDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLogDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblLogDate.Location = New System.Drawing.Point(9, 37)
            Me.lblLogDate.Name = "lblLogDate"
            Me.lblLogDate.Size = New System.Drawing.Size(87, 13)
            Me.lblLogDate.TabIndex = 1
            Me.lblLogDate.Text = "Last Log Date"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Green
            Me.Label5.Location = New System.Drawing.Point(9, 20)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(87, 13)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Last Log Date"
            '
            'cmdRetriveRecords
            '
            Me.cmdRetriveRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRetriveRecords.Location = New System.Drawing.Point(101, 353)
            Me.cmdRetriveRecords.Name = "cmdRetriveRecords"
            Me.cmdRetriveRecords.Size = New System.Drawing.Size(129, 27)
            Me.cmdRetriveRecords.TabIndex = 18
            Me.cmdRetriveRecords.Text = "Retrive Records"
            Me.cmdRetriveRecords.UseVisualStyleBackColor = True
            '
            'cmdTransferRecords
            '
            Me.cmdTransferRecords.Enabled = False
            Me.cmdTransferRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdTransferRecords.Location = New System.Drawing.Point(236, 353)
            Me.cmdTransferRecords.Name = "cmdTransferRecords"
            Me.cmdTransferRecords.Size = New System.Drawing.Size(129, 27)
            Me.cmdTransferRecords.TabIndex = 19
            Me.cmdTransferRecords.Text = "Transfer Records"
            Me.cmdTransferRecords.UseVisualStyleBackColor = True
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(544, 353)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(124, 27)
            Me.cmdExit.TabIndex = 20
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'frmRetriveRecord
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(677, 394)
            Me.Controls.Add(Me.lbRecords)
            Me.Controls.Add(Me.cmdExit)
            Me.Controls.Add(Me.cmdTransferRecords)
            Me.Controls.Add(Me.cmdRetriveRecords)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmRetriveRecord"
            Me.Text = "Retrive Records"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lblRetriveRecords As System.Windows.Forms.Label
        Friend WithEvents lblRetriveFrom As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmdFind As System.Windows.Forms.Button
        Friend WithEvents lbRecords As System.Windows.Forms.ListBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents lblTransferRecords As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblLastTransfered As System.Windows.Forms.Label
        Friend WithEvents lblLastTransfered1 As System.Windows.Forms.Label
        Friend WithEvents lblPreviousTransfered As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblLogDate As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cmdRetriveRecords As System.Windows.Forms.Button
        Friend WithEvents cmdTransferRecords As System.Windows.Forms.Button
        Friend WithEvents cmdExit As System.Windows.Forms.Button
    End Class
End NameSpace