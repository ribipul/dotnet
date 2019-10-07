Namespace Form

    Public Class frmLogin
        Dim i As Integer, j As Integer

        Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
            Dim UserName As String
            Dim Password As String
            Dim bolLogin As Boolean
            Dim dtUser As New DataTable("UserAuthentication")
            Dim mSQL As String
            Dim mCount As Integer

            mSQL = "SELECT U.uId, U.uLoginName, U.uPasswd, U.UserType, P.Name, P.DeptID FROM UserAuthentication AS U INNER JOIN Personal AS P ON P.PID = U.UID AND P.empActive = 1"
            Call LoadDataTable(mSQL, dtUser)

            If txtUsername.Text = "" Then
                MsgBox("Please enter an User Name.", MsgBoxStyle.Critical, Me.Name)
                txtUsername.Focus()
                Exit Sub
            Else
                UserName = txtUsername.Text
            End If

            If txtPassword.Text = "" Then
                MsgBox("Password never blank. Please enter a Password.", MsgBoxStyle.Critical, Me.Name)
                txtPassword.Focus()
                Exit Sub
            Else
                Password = txtPassword.Text
            End If

            bolLogin = False

            If UserName <> "" And Password <> "" And dtUser.Rows.Count > 0 Then
                For mCount = 0 To dtUser.Rows.Count - 1
                    If dtUser.Rows(mCount).Item("uLoginName") = UserName And dtUser.Rows(mCount).Item("uPasswd") = Password Then
                        gUserID = dtUser.Rows(mCount).Item("uId")
                        GUserType = dtUser.Rows(mCount).Item("UserType")
                        gUserFullName = dtUser.Rows(mCount).Item("Name")
                        GDepartmentID = dtUser.Rows(mCount).Item("DeptID")
                        bolLogin = True
                        gsqlSTR = "SELECT m.modName FROM UserHasModule um, Module m WHERE um.hasModule = m.modId And um.hasId = " & gUserID
                        Exit For
                    End If
                Next
            End If
            If bolLogin = True Then
                If gUserName = "" Then
                    StoreUserInfo(UserName, Password, gUserID)
                    Me.Hide()
                    mdiAttendance.Show()
                Else
                    If gUserName = UserName Then
                        StoreUserInfo(UserName, Password, gUserID)
                        Me.Hide()
                        mdiAttendance.Show()
                    Else
                        j += 1
                        If j >= 3 Then
                            MsgBox("Sorry, Application Canceled !", MsgBoxStyle.Critical, Me.Text)
                            Application.Exit()
                        Else
                            MsgBox("Wrong Password ! Try Again !", MsgBoxStyle.Critical, Me.Text)
                            txtUsername.Clear()
                            txtUsername.Focus()
                            txtPassword.Clear()
                        End If
                    End If
                End If
            Else
                i += 1
                If i >= 3 Then
                    MsgBox("Sorry, Application Canceled !", MsgBoxStyle.Critical, Me.Text)
                    Application.Exit()
                Else
                    MsgBox("Wrong Password ! Try Again !", MsgBoxStyle.Critical, Me.Text)
                    txtUsername.Clear()
                    txtUsername.Focus()
                    txtPassword.Clear()
                End If
            End If
        End Sub

        Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
            Me.Close()
        End Sub

        Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        End Sub
    End Class
End NameSpace