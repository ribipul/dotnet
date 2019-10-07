Namespace Form
    Public Class frmDataExport
        Private WithEvents chkCheckBox As CheckBox
        Private Sub frmDataExport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer
            Dim dtRecord As New DataTable("Records")

            Dim mSQL As String

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            mSQL = ""
            mSQL = "SELECT PID, Name FROM Personal WHERE empActive = 1 And DeptId = 8"
            
            Call LoadDataTable(mSQL, dtRecord)
            Panel1.Controls.Clear()
            If dtRecord.Rows.Count > 0 Then
                For mCount = 0 To dtRecord.Rows.Count - 1
                    chkCheckBox = New CheckBox()
                    With chkCheckBox
                        .Name = mCount.ToString()   ' "CheckBox_" & mCount.ToString()
                        .Text = dtRecord.Rows(mCount).Item("Name").ToString()
                        .Tag = dtRecord.Rows(mCount).Item("PID").ToString()
                        .SetBounds(20, (mCount + 1) * 23, 262, 17)
                        .AutoSize = False
                    End With
                    AddHandler chkCheckBox.CheckedChanged, AddressOf Me.CheckBox_CheckedChanged
                    Panel1.Controls.Add(chkCheckBox)
                Next
            End If
        End Sub

        Private Sub CheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
            Dim i As Integer

            'If Panel1.Controls(0).Name = Convert.ToInt16(sender.name) Then
            '    MsgBox(Panel1.Controls(Convert.ToInt16(sender.name)).Name)
            'End If
            If sender.text = "All Employee" Then
                For i = 0 To Panel1.Controls.Count
                    'Panel1.Controls(i) = True
                Next i
            End If
        End Sub

        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub
    End Class
End NameSpace