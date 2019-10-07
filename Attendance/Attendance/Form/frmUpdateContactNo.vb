Namespace Form
    Public Class frmUpdateContactNo

        Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
            Close()
        End Sub

        Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
            ExecuteSQLQuery("UPDATE Personal SET empContactNo = '" & tbContactNo.Text & "' WHERE pId = " & gUserID, "Update")
            If frmLeaveForm.Visible = True Then
                frmLeaveForm.tbContactNo.Text = Me.tbContactNo.Text
                Close()
            ElseIf frmCompensatoryLeave.Visible = True Then
                frmCompensatoryLeave.tbContactNo.Text = Me.tbContactNo.Text
                Close()
            Else
                Close()
            End If
        End Sub

        Private Sub frmUpdateContactNo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        End Sub
    End Class
End NameSpace