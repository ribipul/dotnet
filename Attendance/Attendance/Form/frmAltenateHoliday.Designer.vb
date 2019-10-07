Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAltenateHoliday
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
            Me.cbDayName = New System.Windows.Forms.ComboBox()
            Me.cbGroup = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.cmdOk = New System.Windows.Forms.Button()
            Me.cbYear = New System.Windows.Forms.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.gbTitleBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'cbDayName
            '
            Me.cbDayName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDayName.FormattingEnabled = True
            Me.cbDayName.Location = New System.Drawing.Point(191, 81)
            Me.cbDayName.Name = "cbDayName"
            Me.cbDayName.Size = New System.Drawing.Size(137, 21)
            Me.cbDayName.TabIndex = 0
            '
            'cbGroup
            '
            Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbGroup.FormattingEnabled = True
            Me.cbGroup.Location = New System.Drawing.Point(32, 81)
            Me.cbGroup.Name = "cbGroup"
            Me.cbGroup.Size = New System.Drawing.Size(137, 21)
            Me.cbGroup.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(60, 57)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(81, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Select Group"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(208, 57)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(105, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Select Day Name"
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(529, 40)
            Me.gbTitleBar.TabIndex = 6
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(119, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(301, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Alternate Holiday Setting"
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New System.Drawing.Point(285, 126)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(67, 24)
            Me.cmdCancel.TabIndex = 8
            Me.cmdCancel.Text = "Cancel"
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'cmdOk
            '
            Me.cmdOk.Location = New System.Drawing.Point(191, 126)
            Me.cmdOk.Name = "cmdOk"
            Me.cmdOk.Size = New System.Drawing.Size(68, 24)
            Me.cmdOk.TabIndex = 7
            Me.cmdOk.Text = "Ok"
            Me.cmdOk.UseVisualStyleBackColor = True
            '
            'cbYear
            '
            Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbYear.FormattingEnabled = True
            Me.cbYear.ItemHeight = 13
            Me.cbYear.Location = New System.Drawing.Point(348, 81)
            Me.cbYear.Name = "cbYear"
            Me.cbYear.Size = New System.Drawing.Size(137, 21)
            Me.cbYear.TabIndex = 90
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(375, 57)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(73, 13)
            Me.Label3.TabIndex = 91
            Me.Label3.Text = "Select Year"
            '
            'frmAltenateHoliday
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(529, 172)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.cbYear)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.cmdOk)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.cbGroup)
            Me.Controls.Add(Me.cbDayName)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmAltenateHoliday"
            Me.Text = "Alternate Holiday Setting"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents cbDayName As System.Windows.Forms.ComboBox
        Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents cmdOk As System.Windows.Forms.Button
        Private WithEvents cbYear As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
    End Class
End NameSpace