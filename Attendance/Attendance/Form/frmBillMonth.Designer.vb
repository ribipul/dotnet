Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBillMonth
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
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.cmdOk = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cbYear = New System.Windows.Forms.ComboBox()
            Me.cbMonth = New System.Windows.Forms.ComboBox()
            Me.gbTitleBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(434, 40)
            Me.gbTitleBar.TabIndex = 6
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(131, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(210, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Select Bill Month"
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New System.Drawing.Point(225, 106)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(67, 24)
            Me.cmdCancel.TabIndex = 8
            Me.cmdCancel.Text = "Cancel"
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'cmdOk
            '
            Me.cmdOk.Location = New System.Drawing.Point(151, 106)
            Me.cmdOk.Name = "cmdOk"
            Me.cmdOk.Size = New System.Drawing.Size(68, 24)
            Me.cmdOk.TabIndex = 7
            Me.cmdOk.Text = "Ok"
            Me.cmdOk.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(295, 51)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(33, 13)
            Me.Label2.TabIndex = 112
            Me.Label2.Text = "Year"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(101, 52)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(42, 13)
            Me.Label1.TabIndex = 111
            Me.Label1.Text = "Month"
            '
            'cbYear
            '
            Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbYear.FormattingEnabled = True
            Me.cbYear.ItemHeight = 13
            Me.cbYear.Location = New System.Drawing.Point(247, 70)
            Me.cbYear.Name = "cbYear"
            Me.cbYear.Size = New System.Drawing.Size(132, 21)
            Me.cbYear.TabIndex = 110
            '
            'cbMonth
            '
            Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbMonth.FormattingEnabled = True
            Me.cbMonth.ItemHeight = 13
            Me.cbMonth.Location = New System.Drawing.Point(57, 70)
            Me.cbMonth.Name = "cbMonth"
            Me.cbMonth.Size = New System.Drawing.Size(132, 21)
            Me.cbMonth.TabIndex = 109
            '
            'frmBillMonth
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(434, 142)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.cbYear)
            Me.Controls.Add(Me.cbMonth)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.cmdOk)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmBillMonth"
            Me.Text = "Select Bill Month"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents cmdOk As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Private WithEvents cbYear As System.Windows.Forms.ComboBox
        Private WithEvents cbMonth As System.Windows.Forms.ComboBox
    End Class
End NameSpace