Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
    Partial Class frmLogin
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
        Friend WithEvents UsernameLabel As System.Windows.Forms.Label
        Friend WithEvents PasswordLabel As System.Windows.Forms.Label
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents OK As System.Windows.Forms.Button
        Friend WithEvents Cancel As System.Windows.Forms.Button

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
            Me.UsernameLabel = New System.Windows.Forms.Label()
            Me.PasswordLabel = New System.Windows.Forms.Label()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.OK = New System.Windows.Forms.Button()
            Me.Cancel = New System.Windows.Forms.Button()
            Me.gbTitleBar = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.gbTitleBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'UsernameLabel
            '
            Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UsernameLabel.Location = New System.Drawing.Point(42, 61)
            Me.UsernameLabel.Name = "UsernameLabel"
            Me.UsernameLabel.Size = New System.Drawing.Size(104, 23)
            Me.UsernameLabel.TabIndex = 0
            Me.UsernameLabel.Text = "&User name"
            Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PasswordLabel
            '
            Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.PasswordLabel.Location = New System.Drawing.Point(42, 103)
            Me.PasswordLabel.Name = "PasswordLabel"
            Me.PasswordLabel.Size = New System.Drawing.Size(105, 23)
            Me.PasswordLabel.TabIndex = 2
            Me.PasswordLabel.Text = "&Password"
            Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(189, 63)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(174, 20)
            Me.txtUsername.TabIndex = 1
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(189, 105)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(174, 20)
            Me.txtPassword.TabIndex = 3
            '
            'OK
            '
            Me.OK.Location = New System.Drawing.Point(192, 134)
            Me.OK.Name = "OK"
            Me.OK.Size = New System.Drawing.Size(79, 25)
            Me.OK.TabIndex = 4
            Me.OK.Text = "&OK"
            '
            'Cancel
            '
            Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Cancel.Location = New System.Drawing.Point(284, 134)
            Me.Cancel.Name = "Cancel"
            Me.Cancel.Size = New System.Drawing.Size(79, 25)
            Me.Cancel.TabIndex = 5
            Me.Cancel.Text = "&Cancel"
            '
            'gbTitleBar
            '
            Me.gbTitleBar.BackColor = System.Drawing.Color.DarkMagenta
            Me.gbTitleBar.Controls.Add(Me.Label9)
            Me.gbTitleBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.gbTitleBar.Location = New System.Drawing.Point(0, 0)
            Me.gbTitleBar.Name = "gbTitleBar"
            Me.gbTitleBar.Size = New System.Drawing.Size(401, 40)
            Me.gbTitleBar.TabIndex = 6
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(143, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(99, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Login..."
            '
            'frmLogin
            '
            Me.AcceptButton = Me.OK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.Cancel
            Me.ClientSize = New System.Drawing.Size(401, 171)
            Me.Controls.Add(Me.gbTitleBar)
            Me.Controls.Add(Me.Cancel)
            Me.Controls.Add(Me.OK)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Controls.Add(Me.PasswordLabel)
            Me.Controls.Add(Me.UsernameLabel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmLogin"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Login..."
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label

    End Class
End NameSpace