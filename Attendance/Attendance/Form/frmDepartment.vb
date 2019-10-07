Namespace Form

    Public Class frmDepartment

        Dim mCount As Integer
        Dim mCurrent As Integer

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub frmDepartment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Department")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            'strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"

            'Call LoadDataTable(strSQL, dtComboList)
            'cbDepartment.Items.Clear()

            'If dtComboList.Rows.Count > 0 Then
            '    For mCount = 0 To dtComboList.Rows.Count - 1
            '        cbDepartment.Items.Add(New clsList(dtComboList.Rows(mCount).Item("DeptName"), dtComboList.Rows(mCount).Item("Id")))
            '    Next
            '    cbDepartment.SelectedIndex = -1
            'End If
            strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
            Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", False)

            'strSQL = "SELECT PId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
            'Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID", False)
        End Sub

        Private Sub ClearForm(ByVal blStatus As Boolean)
            With Me
                .txtDepartmentID.Text = ""
                .txtDepartmentName.Text = ""
                .txtStartingHour.Text = ""

                .txtDepartmentName.Enabled = blStatus
                .txtStartingHour.Enabled = blStatus
                .cbEmployee.Enabled = blStatus
            End With
            If cbEmployee.Items.Count > 0 Then
                cbEmployee.SelectedIndex = 0
            End If
        End Sub

        Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
            Dim mQuery As String
            Dim mMaxId As Integer

            Call ControlStatus()
            Call ClearForm(True)

            mQuery = "SELECT (MAX(Id)+1) ID FROM Department"
            mMaxId = GetMaxID(mQuery, "ID")
            Me.txtDepartmentID.Text = mMaxId
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            Call cmdUpdate_Click(sender, e)
        End Sub

        Private Sub mnuCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancel.Click
            Call ControlStatus()
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            Call cmdDelete_Click(sender, e)
        End Sub

        Private Sub mnuMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveFirst.Click
            mCurrent = cbDepartment.SelectedIndex
            If cbDepartment.SelectedIndex <> -1 Then
                mCount = cbDepartment.Items.Count - 1
                If (mCurrent - 1) < 1 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbDepartment.SelectedIndex = 1
                End If
            End If
        End Sub

        Private Sub mnuMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveLast.Click
            mCurrent = cbDepartment.SelectedIndex
            If cbDepartment.SelectedIndex <> -1 Then
                mCount = cbDepartment.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbDepartment.SelectedIndex = mCount
                End If
            End If
        End Sub

        Private Sub mnuMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveNext.Click
            mCurrent = cbDepartment.SelectedIndex
            If cbDepartment.SelectedIndex <> -1 Then
                mCount = cbDepartment.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbDepartment.SelectedIndex = mCurrent + 1
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovePrevious.Click
            mCurrent = cbDepartment.SelectedIndex
            If cbDepartment.SelectedIndex <> -1 Then
                mCount = cbDepartment.Items.Count - 1
                If (mCurrent - 1) < 1 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbDepartment.SelectedIndex = mCurrent - 1
                End If
            End If
        End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            Dim mCount As Integer, i As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Department")

            mCurrent = cbDepartment.SelectedIndex

            If cbDepartment.SelectedIndex <= 0 Then
                Call ClearForm(False)
                'If cbEmployee.Items.Count > 0 Then
                '    cbEmployee.SelectedIndex = 0
                'Else
                '    cbEmployee.Items.Clear()
                'End If

                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False
                cmdInsert.Enabled = False
                cmdNew.Text = "New"

                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
                mnuSave.Enabled = False
                mnuCancel.Enabled = False
                mnuAddNew.Enabled = True
                strSQL = "SELECT PId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
                Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID", False)
                Exit Sub
            End If
            Try
                strSQL = "SELECT TOP 1 Id, DeptName, startHour, EmpID FROM Department WHERE ID = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString

                Call LoadDataTable(strSQL, dtComboList)

                If dtComboList.Rows.Count > 0 Then
                    Call ClearForm(True)
                    txtDepartmentID.Text = dtComboList.Rows(mCount).Item("ID")
                    txtDepartmentName.Text = dtComboList.Rows(mCount).Item("DeptName")
                    txtStartingHour.Text = dtComboList.Rows(mCount).Item("startHour")

                    strSQL = "SELECT PId, Name FROM Personal WHERE empActive = 1 And DeptID = " & txtDepartmentID.Text
                    Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID")

                    If cbEmployee.Items.Count > 0 Then
                        If IsDBNull(dtComboList.Rows(mCount).Item("EmpID")) Then
                            cbEmployee.SelectedIndex = 0
                        Else
                            For i = 0 To cbEmployee.Items.Count - 1
                                If cbEmployee.Items(i).ItemData = dtComboList.Rows(mCount).Item("EmpID") Then
                                    cbEmployee.SelectedIndex = i    '.SetSelected(i, True)
                                    Exit For
                                End If
                            Next i
                        End If
                    End If
                    cmdUpdate.Enabled = True
                    cmdDelete.Enabled = True
                    cmdInsert.Enabled = False
                    cmdNew.Text = "New"

                    mnuEdit.Enabled = True
                    mnuDelete.Enabled = True
                    mnuSave.Enabled = False
                    mnuCancel.Enabled = False
                    mnuAddNew.Enabled = True
                Else
                    txtDepartmentID.Text = ""
                    txtDepartmentName.Text = ""
                    txtStartingHour.Text = ""
                    cbEmployee.SelectedIndex = 0

                    cmdUpdate.Enabled = False
                    cmdDelete.Enabled = False
                    cmdInsert.Enabled = False
                    cmdNew.Text = "New"

                    mnuEdit.Enabled = False
                    mnuDelete.Enabled = False
                    mnuSave.Enabled = False
                    mnuCancel.Enabled = False
                    mnuAddNew.Enabled = True
                    strSQL = "SELECT PId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
                    Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID", False)
                End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try
        End Sub

        Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
            Dim strSQL As String

            strSQL = "SELECT PId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
            Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID", False)

            Call ControlStatus()
            'Call ClearForm()
        End Sub

        Private Sub ControlStatus()
            If cmdNew.Text = "New" Then
                If cbDepartment.Items.Count > 0 Then
                    cbDepartment.SelectedIndex = 0
                End If
                mnuAddNew.Enabled = False
                mnuCancel.Enabled = True
                mnuSave.Enabled = True
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False

                cmdNew.Enabled = True
                cmdInsert.Enabled = True
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False
                cmdNew.Text = "Cancel"
                Call ClearForm(True)
            Else
                If cbDepartment.SelectedIndex > 0 Then
                    cmdInsert.Enabled = False
                    cmdUpdate.Enabled = True
                    cmdDelete.Enabled = True
                    mnuSave.Enabled = False
                    mnuEdit.Enabled = True
                    mnuDelete.Enabled = True

                    mnuCancel.Enabled = False
                Else
                    cmdInsert.Enabled = False

                    mnuSave.Enabled = False
                    mnuCancel.Enabled = False
                    mnuEdit.Enabled = False
                    mnuDelete.Enabled = False
                End If
                mnuAddNew.Enabled = True
                cmdNew.Enabled = True
                cmdNew.Text = "New"
                Call ClearForm(False)
            End If
        End Sub

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Dim strSQL As String, strMSG As String
            Dim m As Integer, mDeptId As Integer

            If txtDepartmentName.Text = "" Then
                'Validate Department Name
                MsgBox("Please give Department Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtDepartmentName.Focus()
                Exit Sub
            ElseIf txtStartingHour.Text = "" Then
                'Validate Work Starting Hour
                MsgBox("Give the Work Starting hour.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtStartingHour.Focus()
                Exit Sub
            End If

            If cbEmployee.SelectedIndex > 0 Then
                strMSG = cbEmployee.Items(cbEmployee.SelectedIndex).ToString()
            Else
                strMSG = "Not set yet."
            End If
            m = MsgBox("Do you realy want to save this information" & vbCrLf & _
                       "Department Name: " & txtDepartmentName.Text & vbCrLf & _
                       "No of Days: " & txtStartingHour.Text & vbCrLf & "Supervisor: " & strMSG, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                mDeptId = GetMaxID("SELECT (MAX(ID)+1) DeptID FROM Department", "DeptID")
                If cbEmployee.SelectedIndex > 0 Then
                    strSQL = "INSERT INTO Department(ID, DeptName, startHour, EmpID) VALUES (" & mDeptId & ", '" & txtDepartmentName.Text & "', '" & txtStartingHour.Text & "', " & cbEmployee.Items(cbEmployee.SelectedIndex).ItemData.ToString() & ")"
                Else
                    strSQL = "INSERT INTO Department(ID, DeptName, startHour) VALUES (" & mDeptId & ", '" & txtDepartmentName.Text & "', '" & txtStartingHour.Text & "')"
                End If

                ExecuteSQLQuery(strSQL, "Insert")
                Call ControlStatus()

                strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
                Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", False)
            End If
            
        End Sub

        Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
            Call cmdInsert_Click(sender, e)
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Dim strSQL As String, strMSG As String
            Dim m As Integer

            If txtDepartmentName.Text = "" Then
                'Validate Department Name
                MsgBox("Please give Department Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtDepartmentName.Focus()
                Exit Sub
            ElseIf txtStartingHour.Text = "" Then
                'Validate Work Starting Hour
                MsgBox("Give the Work Starting hour.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtStartingHour.Focus()
                Exit Sub
            End If

            If cbEmployee.SelectedIndex > 0 Then
                strMSG = cbEmployee.Items(cbEmployee.SelectedIndex).ToString()
            Else
                strMSG = "Not set yet."
            End If
            m = MsgBox("Do you realy want to save this information" & vbCrLf & _
                       "Department Name: " & txtDepartmentName.Text & vbCrLf & _
                       "No of Days: " & txtStartingHour.Text & vbCrLf & "Supervisor: " & strMSG, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                If cbEmployee.SelectedIndex > 0 Then
                    strSQL = "UPDATE Department SET DeptName = '" & txtDepartmentName.Text & "', startHour = '" & txtStartingHour.Text & "', EmpID = " & cbEmployee.Items(cbEmployee.SelectedIndex).ItemData.ToString() & " WHERE ID = " & txtDepartmentID.Text
                Else
                    strSQL = "UPDATE Department SET DeptName = '" & txtDepartmentName.Text & "', startHour = '" & txtStartingHour.Text & "' WHERE ID = " & txtDepartmentID.Text
                End If
                
                ExecuteSQLQuery(strSQL, "Update")
            End If
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim strSQL As String
            Dim m As Integer

            m = MsgBox("Are you sure to Delete this Department?", MsgBoxStyle.YesNo, Me.Text)

            If m = vbYes Then
                strSQL = "DELETE FROM Department WHERE ID = " & Me.txtDepartmentID.Text

                ExecuteSQLQuery(strSQL, "Delete")
                strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
                Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", False)
            End If
            
        End Sub
    End Class
End NameSpace