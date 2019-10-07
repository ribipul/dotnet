Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDataExport
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
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cmdExit = New System.Windows.Forms.Button()
            Me.chkAll = New System.Windows.Forms.CheckBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.dtToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnExport = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
            Me.gbTitleBar.SuspendLayout()
            Me.Panel3.SuspendLayout()
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
            Me.gbTitleBar.Size = New System.Drawing.Size(750, 40)
            Me.gbTitleBar.TabIndex = 34
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(274, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(178, 29)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Employee List"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
            Me.Panel3.Controls.Add(Me.cmdExit)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 524)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(750, 46)
            Me.Panel3.TabIndex = 37
            '
            'cmdExit
            '
            Me.cmdExit.Location = New System.Drawing.Point(630, 9)
            Me.cmdExit.Name = "cmdExit"
            Me.cmdExit.Size = New System.Drawing.Size(103, 28)
            Me.cmdExit.TabIndex = 19
            Me.cmdExit.Text = "Exit"
            Me.cmdExit.UseVisualStyleBackColor = True
            '
            'chkAll
            '
            Me.chkAll.Location = New System.Drawing.Point(363, 254)
            Me.chkAll.Name = "chkAll"
            Me.chkAll.Size = New System.Drawing.Size(262, 17)
            Me.chkAll.TabIndex = 39
            Me.chkAll.Tag = "0"
            Me.chkAll.Text = "All Employee"
            Me.chkAll.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.dtToDate)
            Me.GroupBox1.Controls.Add(Me.dtFromDate)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.btnExport)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(354, 46)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(317, 138)
            Me.GroupBox1.TabIndex = 41
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Date Range"
            '
            'dtToDate
            '
            Me.dtToDate.CustomFormat = ""
            Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtToDate.Location = New System.Drawing.Point(191, 27)
            Me.dtToDate.Name = "dtToDate"
            Me.dtToDate.Size = New System.Drawing.Size(108, 20)
            Me.dtToDate.TabIndex = 49
            '
            'dtFromDate
            '
            Me.dtFromDate.CustomFormat = ""
            Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtFromDate.Location = New System.Drawing.Point(52, 27)
            Me.dtFromDate.Name = "dtFromDate"
            Me.dtFromDate.Size = New System.Drawing.Size(108, 20)
            Me.dtFromDate.TabIndex = 48
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(162, 30)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(20, 13)
            Me.Label4.TabIndex = 47
            Me.Label4.Text = "To"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(6, 30)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(30, 13)
            Me.Label3.TabIndex = 46
            Me.Label3.Text = "From"
            '
            'btnExport
            '
            Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExport.Location = New System.Drawing.Point(229, 80)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(70, 28)
            Me.btnExport.TabIndex = 45
            Me.btnExport.Text = "Export"
            Me.btnExport.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.Panel1)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(23, 46)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(316, 317)
            Me.GroupBox2.TabIndex = 42
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Employee List"
            '
            'Panel1
            '
            Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Panel1.Location = New System.Drawing.Point(8, 16)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(298, 295)
            Me.Panel1.TabIndex = 41
            '
            'WebBrowser1
            '
            Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WebBrowser1.Location = New System.Drawing.Point(0, 40)
            Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
            Me.WebBrowser1.Name = "WebBrowser1"
            Me.WebBrowser1.Size = New System.Drawing.Size(750, 484)
            Me.WebBrowser1.TabIndex = 43
            Me.WebBrowser1.Url = New System.Uri("http://serverbdj/Attendance/AttnEmployeelist.asp", System.UriKind.Absolute)
            '
            'frmDataExport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(750, 570)
            Me.Controls.Add(Me.WebBrowser1)
            Me.Controls.Add(Me.chkAll)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.gbTitleBar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmDataExport"
            Me.Text = "RPCS Employee Attendance Data Export"
            Me.gbTitleBar.ResumeLayout(False)
            Me.gbTitleBar.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTitleBar As System.Windows.Forms.Panel
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmdExit As System.Windows.Forms.Button
        Friend WithEvents chkAll As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnExport As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    End Class
End NameSpace