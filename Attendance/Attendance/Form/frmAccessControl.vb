Namespace Form
    Public Class frmAccessControl

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub frmAccessControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Access")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            With cbUserType
                .Items.Add("Administrator")
                .Items.Add("DepartmentHead")
                .Items.Add("Individual")
            End With

            strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"

            Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", True)

            If GDepartmentID = 0 Or GUserType = "" Then
                MsgBox("Access denied, User is not authorized to access this module.", MsgBoxStyle.Critical, "System Manager")
                Me.Close()
            Else
                Select Case GUserType
                    Case "Administrator"
                        strSQL = "SELECT Name, PID FROM Personal WHERE EmpActive = 1 ORDER BY Name ASC"
                    Case "DepartmentHead"
                        strSQL = "SELECT Name, PID FROM Personal WHERE DeptID = " + GDepartmentID.ToString() + " AND EmpActive = 1 ORDER BY Name ASC"

                        cbDepartment.Enabled = False
                    Case "Individual"
                        strSQL = "SELECT Name, PID FROM Personal WHERE PID = " + gUserID.ToString()

                        cbDepartment.Enabled = False
                End Select
                Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")

                For i = 0 To lbEmployee.Items.Count - 1
                    If lbEmployee.Items(i).ItemData = gUserID Then
                        lbEmployee.SetSelected(i, True)
                        Exit For
                    End If
                Next i
            End If
        End Sub

        'Private Sub LoadComboList(ByVal ctrlListBox As ListBox, ByVal strSQL As String, ByVal strTableName As String, ByVal strDisplay As String, ByVal strID As String)
        '    Dim mCount As Integer
        '    Dim dtComboList As New DataTable(strTableName)

        '    Call LoadDataTable(strSQL, dtComboList)
        '    ctrlListBox.Items.Clear()

        '    If dtComboList.Rows.Count > 0 Then
        '        For mCount = 0 To dtComboList.Rows.Count - 1
        '            ctrlListBox.Items.Add(New clsList(dtComboList.Rows(mCount).Item(strDisplay), dtComboList.Rows(mCount).Item(strID)))
        '        Next
        '    End If
        '    ctrlListBox.SelectedIndex = -1
        'End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            'Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Access")

            If cbDepartment.SelectedIndex = 0 Then
                strSQL = "SELECT pId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
            Else
                strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 1 ORDER BY Name"
            End If

            Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")
            If lbEmployee.Items.Count > 0 Then
                lbEmployee.SelectedIndex = 0
            Else
                tbLogin.Text = ""
                tbPassword.Text = ""
                tbConPass.Text = tbPassword.Text
                cbUserType.SelectedIndex = -1

                Call ClearCheckBox(False)
            End If
        End Sub

        Private Sub lbEmployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEmployee.SelectedIndexChanged
            Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Access")
            Dim dtAccessList As New DataTable("Permission")
            
            strSQL = "SELECT TOP 1 uLoginName, uPasswd, UserType FROM UserAuthentication WHERE uId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
        
            Call LoadDataTable(strSQL, dtComboList)

            If dtComboList.Rows.Count > 0 Then
                For mCount = 0 To dtComboList.Rows.Count - 1
                    tbLogin.Text = dtComboList.Rows(mCount).Item("uLoginName")
                    tbPassword.Text = dtComboList.Rows(mCount).Item("uPasswd")
                    tbConPass.Text = tbPassword.Text
                    cbUserType.Text = dtComboList.Rows(mCount).Item("UserType")
                Next
            Else
                tbLogin.Text = ""
                tbPassword.Text = ""
                tbConPass.Text = tbPassword.Text
                cbUserType.SelectedIndex = -1
            End If

            strSQL = "SELECT hasModule FROM UserHasModule WHERE hasId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
            Call LoadDataTable(strSQL, dtAccessList)
            Call ClearCheckBox(False)

            chkAll.Checked = False

            If dtAccessList.Rows.Count > 0 Then
                For mCount = 0 To dtAccessList.Rows.Count - 1
                    If dtAccessList.Rows(mCount).Item("hasModule") = 1 Then
                        chkRetRecord.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 2 Then
                        chkEmployee.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 3 Then
                        chkSelectPath.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 4 Then
                        chkNotification.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 5 Then
                        chkAttendance.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 6 Then
                        chkSecurity.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 7 Then
                        chkDepartment.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 8 Then
                        chkCalendar.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 9 Then
                        chkEmpCalendar.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 10 Then
                        chkEarnLeave.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 11 Then
                        chkLeave.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 12 Then
                        chkSetLeave.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 13 Then
                        chkAgreement.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 14 Then
                        chkHolidays.Checked = 1
                    End If
                    If dtAccessList.Rows(mCount).Item("hasModule") = 15 Then
                        chkDataExport.Checked = 1
                    End If
                Next
            End If
        End Sub

        Private Sub ClearCheckBox(ByVal bStatus As Boolean)
            chkRetRecord.Checked = bStatus
            chkEmployee.Checked = bStatus
            chkSelectPath.Checked = bStatus
            chkNotification.Checked = bStatus
            chkAttendance.Checked = bStatus
            chkSecurity.Checked = bStatus
            chkDepartment.Checked = bStatus
            chkCalendar.Checked = bStatus
            chkEmpCalendar.Checked = bStatus
            chkEarnLeave.Checked = bStatus
            chkLeave.Checked = bStatus
            chkSetLeave.Checked = bStatus
            chkAgreement.Checked = bStatus
            chkHolidays.Checked = bStatus
            chkDataExport.Checked = bStatus
        End Sub

        Private Sub SetAuthentication()
            Dim mRules As String
            Dim strSQL As String
            Dim dtUserAuth As New DataTable("User")
            Dim msg As Integer
            Dim dtChkUser As New DataTable("ChkUser")

            mRules = ""

            If chkRetRecord.Checked = True Then
                mRules = ",1"
            End If
            If chkEmployee.Checked = True Then
                mRules = mRules + "," + "2"
            End If
            If chkSelectPath.Checked = True Then
                mRules = mRules + "," + "3"
            End If
            If chkNotification.Checked = True Then
                mRules = mRules + "," + "4"
            End If
            If chkAttendance.Checked = True Then
                mRules = mRules + "," + "5"
            End If
            If chkSecurity.Checked = True Then
                mRules = mRules + "," + "6"
            End If
            If chkDepartment.Checked = True Then
                mRules = mRules + "," + "7"
            End If
            If chkCalendar.Checked = True Then
                mRules = mRules + "," + "8"
            End If
            If chkEmpCalendar.Checked = True Then
                mRules = mRules + "," + "9"
            End If
            If chkEarnLeave.Checked = True Then
                mRules = mRules + "," + "10"
            End If
            If chkLeave.Checked = True Then
                mRules = mRules + "," + "11"
            End If
            If chkSetLeave.Checked = True Then
                mRules = mRules + "," + "12"
            End If
            If chkAgreement.Checked = True Then
                mRules = mRules + "," + "13"
            End If
            If chkHolidays.Checked = True Then
                mRules = mRules + "," + "14"
            End If
            If chkDataExport.Checked = True Then
                mRules = mRules + "," + "15"
            End If

            strSQL = "SELECT TOP 1 uLoginName FROM UserAuthentication WHERE uId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString

            Call LoadDataTable(strSQL, dtUserAuth)

            If dtUserAuth.Rows.Count > 0 Then
                If tbLogin.Text = "" And tbPassword.Text = "" And tbConPass.Text = "" Then
                    msg = MsgBox("Do you want to delete this user's authentication", vbYesNo + vbQuestion, "System Manager")
                    If msg = vbYes Then
                        strSQL = "USP_USER_AUTHENTICATION " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
                        ExecuteSQLQuery(strSQL, "Delete")
                    Else
                        lbEmployee.SetSelected(lbEmployee.SelectedIndex, True)
                    End If
                    Exit Sub
                End If
                msg = MsgBox("Do you want to update user authentication", vbYesNo + vbQuestion, "System Manager")
                If msg = vbYes Then
                    If tbLogin.Text = "" Or tbPassword.Text = "" Or tbConPass.Text = "" Or cbUserType.Text = "" Then
                        MsgBox("Set User Name, Password and User Type first.", vbExclamation, "Authentication Check")
                        tbLogin.Focus()
                        Exit Sub
                    End If
                    strSQL = "SELECT ULoginName FROM UserAuthentication WHERE ULoginName='" + tbLogin.Text + "' AND UID <> " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
                    Call LoadDataTable(strSQL, dtChkUser)
                    If dtChkUser.Rows.Count > 0 Then
                        MsgBox("You can not use this login name. Change the login name!", vbExclamation, "System Manager")
                        tbLogin.Text = ""
                        tbPassword.Text = ""
                        tbConPass.Text = ""
                        tbLogin.Focus()
                    Else
                        If tbPassword.Text = tbConPass.Text Then
                            strSQL = "USP_SET_USER_AUTHENTICATION 'Edit', '" + mRules + ",', " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + ", '" + tbLogin.Text + "', '" + tbPassword.Text + "', '" + cbUserType.Text + "'"
                            ExecuteSQLQuery(strSQL, "Update")
                        Else
                            MsgBox("Wrong password! Retype your password again.", vbExclamation, "System Manager")
                            tbPassword.Text = ""
                            tbConPass.Text = ""
                            tbConPass.Focus()
                            Exit Sub
                        End If
                    End If
                    dtChkUser.Dispose()
                Else
                    lbEmployee.SetSelected(lbEmployee.SelectedIndex, True)
                    Exit Sub
                End If
            Else
                If tbLogin.Text = "" Or tbPassword.Text = "" Or tbConPass.Text = "" Or cbUserType.Text = "" Then
                    MsgBox("Set User Name, Password and User Type first.", vbExclamation, "System Manager")
                    tbLogin.Focus()
                Else
                    strSQL = "select uLoginName from UserAuthentication where uLoginName='" + tbLogin.Text + "' and uId <> " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
                    Call LoadDataTable(strSQL, dtChkUser)
                    If dtChkUser.Rows.Count > 0 Then
                        MsgBox("You can not use this login name. Change the login name!", vbExclamation, "System Manager")
                        tbLogin.Text = ""
                        tbPassword.Text = ""
                        tbConPass.Text = ""
                        tbLogin.Focus()
                    Else
                        If tbPassword.Text = tbConPass.Text Then
                            strSQL = "USP_SET_USER_AUTHENTICATION 'Insert', '" + mRules + ",', " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + ", '" + tbLogin.Text + "', '" + tbPassword.Text + "', '" + cbUserType.Text + "'"
                            ExecuteSQLQuery(strSQL, "Insert")
                        Else
                            MsgBox("Wrong password! Retype your password again.", vbExclamation, "System Manager")
                            tbPassword.Text = ""
                            tbConPass.Text = ""
                            tbConPass.Focus()
                            Exit Sub
                        End If
                    End If
                    dtChkUser.Dispose()
                End If
            End If
        End Sub

        Private Sub btnAuthentication_Click(sender As System.Object, e As System.EventArgs) Handles btnAuthentication.Click
            Call SetAuthentication()
        End Sub

        Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
            Call ClearCheckBox(chkAll.Checked)
        End Sub
    End Class
End NameSpace