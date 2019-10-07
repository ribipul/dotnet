Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmUpdateContactNo
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
            Me.tbContactNo = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.cmdOk = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'tbContactNo
            '
            Me.tbContactNo.Location = New System.Drawing.Point(147, 22)
            Me.tbContactNo.Name = "tbContactNo"
            Me.tbContactNo.Size = New System.Drawing.Size(235, 20)
            Me.tbContactNo.TabIndex = 22
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(22, 25)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(79, 13)
            Me.Label10.TabIndex = 21
            Me.Label10.Text = "Contact No.:"
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New System.Drawing.Point(224, 69)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(67, 24)
            Me.cmdCancel.TabIndex = 24
            Me.cmdCancel.Text = "Cancel"
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'cmdOk
            '
            Me.cmdOk.Location = New System.Drawing.Point(142, 69)
            Me.cmdOk.Name = "cmdOk"
            Me.cmdOk.Size = New System.Drawing.Size(68, 24)
            Me.cmdOk.TabIndex = 23
            Me.cmdOk.Text = "Ok"
            Me.cmdOk.UseVisualStyleBackColor = True
            '
            'frmUpdateContactNo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(416, 113)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.cmdOk)
            Me.Controls.Add(Me.tbContactNo)
            Me.Controls.Add(Me.Label10)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmUpdateContactNo"
            Me.Text = "Update Contact No"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tbContactNo As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents cmdOk As System.Windows.Forms.Button
    End Class
End NameSpace