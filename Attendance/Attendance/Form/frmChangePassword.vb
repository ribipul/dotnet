Namespace Form
    Public Class frmChangePassword

        Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
            Close()
        End Sub

        Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
            Dim UserID As Integer
            Dim strSQL As String
            Dim dtUser As New DataTable("User")
            Dim dtUserAuth As New DataTable("UserAuthentication")
            Dim mCount As Integer

            strSQL = "SELECT TOP 1 uId FROM UserAuthentication WHERE uLoginName='" & gUserName & "' and uPasswd='" & gPassword & "'"
            Call LoadDataTable(strSQL, dtUser)

            If dtUser.Rows.Count > 0 Then
                If (txtPassword.Text <> "" And txtRetypePassword.Text <> "") And (txtPassword.Text = txtRetypePassword.Text) Then
                    For mCount = 0 To dtUser.Rows.Count - 1
                        UserID = dtUser.Rows(mCount).Item("uId")
                        strSQL = "UPDATE UserAuthentication SET uPasswd='" & Trim(txtPassword.Text) & "' where uId=" & UserID & ""
                        Call ExecuteSQLQuery(strSQL, "Update")
                        gPassword = txtPassword.Text
                        txtPassword.Text = ""
                        txtRetypePassword.Text = ""
                        'MsgBox("Data has been successfully updated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Update.....")
                        txtPassword.Focus()
                    Next
                Else
                    MsgBox("Please Enter a valid Password", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Validation.....")
                    txtPassword.Text = ""
                    txtRetypePassword.Text = ""
                    txtPassword.Focus()
                End If

            End If
        End Sub

        Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        End Sub
    End Class
End NameSpace