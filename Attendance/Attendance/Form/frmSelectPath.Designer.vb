Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmSelectPath
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtFilePath = New System.Windows.Forms.TextBox()
            Me.cmdBrowse = New System.Windows.Forms.Button()
            Me.cmdOk = New System.Windows.Forms.Button()
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.gbTitleBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(12, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(136, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Select Path for retrive:"
            '
            'txtFilePath
            '
            Me.txtFilePath.BackColor = System.Drawing.SystemColors.ButtonHighlight
            Me.txtFilePath.Location = New System.Drawing.Point(11, 66)
            Me.txtFilePath.Name = "txtFilePath"
            Me.txtFilePath.ReadOnly = True
            Me.txtFilePath.Size = New System.Drawing.Size(380, 20)
            Me.txtFilePath.TabIndex = 1
            '
            'cmdBrowse
            '
            Me.cmdBrowse.Location = New System.Drawing.Point(397, 64)
            Me.cmdBrowse.Name = "cmdBrowse"
            Me.cmdBrowse.Size = New System.Drawing.Size(55, 22)
            Me.cmdBrowse.TabIndex = 2
            Me.cmdBrowse.Text = "Browse"
            Me.cmdBrowse.UseVisualStyleBackColor = True
            '
            'cmdOk
            '
            Me.cmdOk.Location = New System.Drawing.Point(175, 101)
            Me.cmdOk.Name = "cmdOk"
            Me.cmdOk.Size = New System.Drawing.Size(68, 24)
            Me.cmdOk.TabIndex = 3
            Me.cmdOk.Text = "Ok"
            Me.cmdOk.UseVisualStyleBackColor = True
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New System.Drawing.Point(249, 101)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(67, 24)
            Me.cmdCancel.TabIndex = 4
            Me.cmdCancel.Text = "Cancel"
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(481, 40)
            Me.gbTitleBar.TabIndex = 5
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(154, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(167, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Select Path..."
            '
            'frmSelectPath
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(481, 133)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.cmdOk)
            Me.Controls.Add(Me.cmdBrowse)
            Me.Controls.Add(Me.txtFilePath)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmSelectPath"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Select Path..."
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
        Friend WithEvents cmdBrowse As System.Windows.Forms.Button
        Friend WithEvents cmdOk As System.Windows.Forms.Button
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
    End Class
End NameSpace