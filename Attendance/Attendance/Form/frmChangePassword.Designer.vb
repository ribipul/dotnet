Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmChangePassword
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
            Me.Cancel = New System.Windows.Forms.Button()
            Me.OK = New System.Windows.Forms.Button()
            Me.txtRetypePassword = New System.Windows.Forms.TextBox()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.PasswordLabel = New System.Windows.Forms.Label()
            Me.UsernameLabel = New System.Windows.Forms.Label()
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
            Me.gbTitleBar.Size = New System.Drawing.Size(392, 40)
            Me.gbTitleBar.TabIndex = 13
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(92, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(225, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Change Password"
            '
            'Cancel
            '
            Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Cancel.Location = New System.Drawing.Point(209, 148)
            Me.Cancel.Name = "Cancel"
            Me.Cancel.Size = New System.Drawing.Size(79, 25)
            Me.Cancel.TabIndex = 12
            Me.Cancel.Text = "&Exit"
            '
            'OK
            '
            Me.OK.Location = New System.Drawing.Point(117, 148)
            Me.OK.Name = "OK"
            Me.OK.Size = New System.Drawing.Size(79, 25)
            Me.OK.TabIndex = 11
            Me.OK.Text = "&OK"
            '
            'txtRetypePassword
            '
            Me.txtRetypePassword.Location = New System.Drawing.Point(181, 109)
            Me.txtRetypePassword.Name = "txtRetypePassword"
            Me.txtRetypePassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtRetypePassword.Size = New System.Drawing.Size(174, 20)
            Me.txtRetypePassword.TabIndex = 10
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(181, 67)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(174, 20)
            Me.txtPassword.TabIndex = 8
            '
            'PasswordLabel
            '
            Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.PasswordLabel.Location = New System.Drawing.Point(34, 107)
            Me.PasswordLabel.Name = "PasswordLabel"
            Me.PasswordLabel.Size = New System.Drawing.Size(141, 23)
            Me.PasswordLabel.TabIndex = 9
            Me.PasswordLabel.Text = "Retype Password"
            Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'UsernameLabel
            '
            Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UsernameLabel.Location = New System.Drawing.Point(34, 65)
            Me.UsernameLabel.Name = "UsernameLabel"
            Me.UsernameLabel.Size = New System.Drawing.Size(141, 23)
            Me.UsernameLabel.TabIndex = 7
            Me.UsernameLabel.Text = "Set Password"
            Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmChangePassword
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(392, 191)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.Cancel)
            Me.Controls.Add(Me.OK)
            Me.Controls.Add(Me.txtRetypePassword)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.PasswordLabel)
            Me.Controls.Add(Me.UsernameLabel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmChangePassword"
            Me.Text = "Change Password"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Cancel As System.Windows.Forms.Button
        Friend WithEvents OK As System.Windows.Forms.Button
        Friend WithEvents txtRetypePassword As System.Windows.Forms.TextBox
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents PasswordLabel As System.Windows.Forms.Label
        Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    End Class
End NameSpace