Imports System.Data.SqlClient

Namespace Form

    Public Class frmEmployee
        Dim mCount As Integer
        Dim mCurrent As Integer
        Dim mSave As String
        Dim strSQL As String

        Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                strSQL = "SELECT Id, DeptName FROM Department WHERE Id = " & GDepartmentID & " ORDER BY DeptName"
                cbSearchDepartment.Enabled = False
            Else
                strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
            End If
            Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", False)

            'strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
            Call LoadComboList(cbSearchDepartment, strSQL, "Department", "DeptName", "ID", False)

            strSQL = "SELECT * FROM FN_Alternate_Holiday_Group('Single')"
            Call LoadComboList(cbGroup, strSQL, "Alphabate", "EmpGroup", "ID", False)

            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                For mCount = 0 To cbSearchDepartment.Items.Count - 1
                    If cbSearchDepartment.Items(mCount).ItemData = GDepartmentID Then
                        cbSearchDepartment.SelectedIndex = mCount
                        Exit For
                    End If
                Next mCount
            End If
            If cbSearchDepartment.SelectedIndex > 0 Then
                strSQL = "SELECT PId, Name FROM Personal WHERE DeptId = " & cbSearchDepartment.Items(cbSearchDepartment.SelectedIndex).ItemData & " ORDER BY Name"
            Else
                strSQL = "SELECT PId, Name FROM Personal ORDER BY Name"
            End If

            Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID", False)

            'If cbEmployee.SelectedIndex = 0 Then
            '    Call InsertUpdateStatus(False)
            'Else
            '    Call InsertUpdateStatus(True)
            'End If
        End Sub

        Private Sub displayRecord(ByVal id As Integer, Optional ByVal mOrderBy As String = "", Optional ByVal mMove As String = "")
            Dim dtPersonal As New DataTable("Personal")

            strSQL = "SELECT TOP 1 p.pid, p.name, p.empContactNo, p.designation, p.joinDate, p.CardNO, d.deptName, p.empGroup, p.empActive, p.empActDate, p.empConfirm, empConDate FROM personal p, department d WHERE p.deptid = d.id AND pId = " & id.ToString

            Call LoadDataTable(strSQL, dtPersonal)

            If dtPersonal.Rows.Count > 0 Then
                Me.txtSerial.Text = dtPersonal.Rows(0).Item("pId")
                Me.txtCardNo.Text = dtPersonal.Rows(0).Item("CardNO")
                Me.txtName.Text = dtPersonal.Rows(0).Item("Name")
                If IsDBNull(dtPersonal.Rows(0).Item("empContactNo")) Then
                    Me.txtContactNo.Text = ""
                Else
                    Me.txtContactNo.Text = dtPersonal.Rows(0).Item("empContactNo")
                End If
                Me.txtDesignation.Text = dtPersonal.Rows(0).Item("Designation")
                Me.cbGroup.Text = dtPersonal.Rows(0).Item("EmpGroup")
                Me.cbDepartment.Text = dtPersonal.Rows(0).Item("DeptName")
                Me.dtJoiningDate.Value = dtPersonal.Rows(0).Item("JoinDate")
                If dtPersonal.Rows(0).Item("empActive") = True Then
                    Me.rbActive.Checked = True
                    Me.dtEndDate.Visible = False
                    Me.Label7.Visible = False
                Else
                    Me.rbInactive.Checked = True
                    Me.dtEndDate.Visible = True
                    If IsDate(dtPersonal.Rows(0).Item("empActDate")) = True Then
                        Me.dtEndDate.Value = dtPersonal.Rows(0).Item("empActDate")
                    End If
                    Me.Label7.Visible = True
                End If
                If dtPersonal.Rows(0).Item("empConfirm") = True Then
                    Me.rbConfirmed.Checked = True
                    Me.Label8.Visible = True
                    Me.dtConfirmedDate.Visible = True
                    If IsDate(dtPersonal.Rows(0).Item("empConDate")) = True Then
                        Me.dtConfirmedDate.Value = dtPersonal.Rows(0).Item("empConDate")
                    End If
                Else
                    Me.rbOnProbition.Checked = True
                    Me.Label8.Visible = False
                    Me.dtConfirmedDate.Visible = False
                End If
            End If
        End Sub

        Private Sub ClearForm()
            With Me
                .txtSerial.Text = ""
                .txtCardNo.Text = ""
                .txtName.Text = ""
                .txtContactNo.Text = ""
                .txtDesignation.Text = ""
                .cbGroup.Text = ""
                .cbDepartment.Text = ""
                .dtJoiningDate.Visible = True
                .dtJoiningDate.Value = Now
                .rbActive.Checked = True
                .dtEndDate.Visible = False
                .Label7.Visible = False
                .rbInactive.Checked = False
                .rbConfirmed.Checked = False
                .Label8.Visible = False
                .dtConfirmedDate.Visible = False
                .dtConfirmedDate.Value = DateAdd(DateInterval.Month, 3, Now)
                .rbOnProbition.Checked = True
                .cbGroup.SelectedIndex = 0
                .cbDepartment.SelectedIndex = 0
            End With
        End Sub

        Private Sub ToolStatus()
            If cbEmployee.SelectedIndex <= 0 Then
                cmdNew.Text = "Cancel"
                cmdNew.Enabled = False
                cmdInsert.Enabled = False
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False

                mnuAddNew.Enabled = False
                mnuCancel.Enabled = True
                mnuSave.Enabled = False
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
            Else
                cmdNew.Text = "New"
                cmdNew.Enabled = True
                cmdInsert.Enabled = False
                cmdUpdate.Enabled = True
                cmdDelete.Enabled = True

                mnuAddNew.Enabled = True
                mnuCancel.Enabled = False
                mnuSave.Enabled = True
                mnuEdit.Enabled = False
                mnuDelete.Enabled = True
            End If
        End Sub

        Private Sub mnuMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveNext.Click
            mCurrent = cbEmployee.SelectedIndex
            If cbEmployee.SelectedIndex <> -1 Then
                mCount = cbEmployee.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbEmployee.SelectedIndex = mCurrent + 1
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovePrevious.Click
            mCurrent = cbEmployee.SelectedIndex
            If cbEmployee.SelectedIndex <> -1 Then
                mCount = cbEmployee.Items.Count - 1
                If (mCurrent - 1) < 1 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbEmployee.SelectedIndex = mCurrent - 1
                End If
            End If
        End Sub

        Private Sub mnuMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveFirst.Click
            mCurrent = cbEmployee.SelectedIndex
            If cbEmployee.SelectedIndex <> -1 Then
                mCount = cbEmployee.Items.Count - 1
                If (mCurrent - 1) < 1 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbEmployee.SelectedIndex = 1
                End If
            End If
        End Sub

        Private Sub mnuMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveLast.Click
            mCurrent = cbEmployee.SelectedIndex
            If cbEmployee.SelectedIndex <> -1 Then
                mCount = cbEmployee.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbEmployee.SelectedIndex = mCount
                End If
            End If
        End Sub

        Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
            Call EmployeeInsertUpdate("Insert")
        End Sub

        Private Sub mnuCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancel.Click
            Call ControlStatus()
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            Call EmployeeInsertUpdate("Update")
        End Sub

        Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub rbActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActive.CheckedChanged
            If rbActive.Checked = True Then
                Me.dtEndDate.Visible = False
                Me.Label7.Visible = False
            Else
                Me.dtEndDate.Visible = True
                Me.Label7.Visible = True
            End If
        End Sub

        Private Sub rbConfirmed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConfirmed.CheckedChanged
            If rbConfirmed.Checked = True Then
                Me.dtConfirmedDate.Visible = True
                Me.Label8.Visible = True
            Else
                Me.dtConfirmedDate.Visible = False
                Me.Label8.Visible = False
            End If
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            Call cmdDelete_Click(sender, e)
        End Sub

        Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
            Call ControlStatus()
            If cmdNew.Text = "Cancel" Then
                txtSerial.Text = GetMaxID("SELECT (MAX(pId)+1) EmpId FROM Personal", "EmpId").ToString()
            Else
                txtSerial.Text = ""
            End If
        End Sub

        Private Sub ControlStatus()
            If cmdNew.Text = "New" Then
                If cbEmployee.Items.Count > 0 Then
                    cbEmployee.SelectedIndex = 0
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
                Call ClearForm()
                Call InsertUpdateStatus(True)
            Else
                If cbEmployee.SelectedIndex > 0 Then
                    cmdInsert.Enabled = False
                    cmdUpdate.Enabled = True
                    cmdDelete.Enabled = True
                    mnuSave.Enabled = False
                    mnuEdit.Enabled = True
                    mnuDelete.Enabled = True

                    mnuCancel.Enabled = False
                Else
                    cmdInsert.Enabled = False
                    cmdUpdate.Enabled = False
                    cmdDelete.Enabled = False

                    mnuSave.Enabled = False
                    mnuCancel.Enabled = False
                    mnuEdit.Enabled = False
                    mnuDelete.Enabled = False
                End If
                mnuAddNew.Enabled = True
                cmdNew.Enabled = True
                cmdNew.Text = "New"
                Call ClearForm()
                Call InsertUpdateStatus(False)
            End If
        End Sub

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Call EmployeeInsertUpdate("Insert")
        End Sub

        Private Sub EmployeeInsertUpdate(ByVal strMode As String)
            Dim mOnActive As Integer, mOnConfirm As Integer
            Dim mEmpID As Integer, m As Integer
            Dim mSaveSTR As String, mActive As String, mConfirm As String
            Dim strErrorMessage As String = ""

            If IsEmpty(Me.txtCardNo) = True Then
                MsgBox("You can not blank the Card No. Please enter the Card No.", MsgBoxStyle.Information, Me.Text)
                Me.txtCardNo.Focus()
                Exit Sub
            End If

            If IsEmpty(Me.txtName) = True Then
                MsgBox("You can not blank the Employee Name. Please a desire Name in the Name field.", MsgBoxStyle.Information, Me.Text)
                Me.txtName.Focus()
                Exit Sub
            End If

            If IsEmpty(Me.txtDesignation) = True Then
                MsgBox("You can not blank the Employee Designation. Please specify an Employee Designation into the Designation field.", MsgBoxStyle.Information, Me.Text)
                Me.txtDesignation.Focus()
                Exit Sub
            End If

            If cbDepartment.Items(cbDepartment.SelectedIndex).ItemData <= 0 Then
                MsgBox("You can not blank the Department. Please select a Department from the Department List.", MsgBoxStyle.Information, Me.Text)
                Me.cbDepartment.Focus()
                Exit Sub
            End If

            If cbGroup.Items(cbGroup.SelectedIndex).ItemData <= 0 Then
                MsgBox("Please select Group from Group List.", MsgBoxStyle.Information, Me.Text)
                Me.cbGroup.Focus()
                Exit Sub
            End If

            If rbActive.Checked = False And rbInactive.Checked = False Then
                MsgBox("You must select the Employee Active Status. Please select Employee Active or Inactive Status.", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            If rbConfirmed.Checked = False And rbOnProbition.Checked = False Then
                MsgBox("You must select the Employee Status. Please select Confirm/On Probition Status.", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            If rbActive.Checked = True Then
                mOnActive = 1
                mActive = ""
            ElseIf rbInactive.Checked = True Then
                mOnActive = 0
                mActive = dtEndDate.Value.ToString()
            End If

            If rbConfirmed.Checked = True Then
                mOnConfirm = 1
                mConfirm = dtConfirmedDate.Value.ToString()
            ElseIf rbOnProbition.Checked = True Then
                mOnConfirm = 0
                mConfirm = ""
            End If
            If strMode = "Insert" Then
                mEmpID = GetMaxID("SELECT (MAX(pId)+1) EmpId FROM Personal", "EmpId")
            End If
            m = MsgBox("Are you sure to save this information?", MsgBoxStyle.YesNo, Me.Text)
            If m = vbYes Then
                If strMode = "Update" Then
                    ' Edit
                    If mOnActive = 1 Then
                        If mOnConfirm = 1 Then
                            mSaveSTR = "UPDATE Personal SET Name = '" & txtName.Text & "', empContactNo = '" & txtContactNo.Text & "', Designation = '" & txtDesignation.Text & "', JoinDate = '" & dtJoiningDate.Value & _
                                       "', CardNo = '" & txtCardNo.Text & "', DeptId = " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", empGroup = '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & _
                                       "empActive =" & mOnActive & ", empActDate = NULL, empConfirm = " & mOnConfirm & ", empConDate = '" & mConfirm & "' WHERE PId = " & txtSerial.Text
                        Else
                            mSaveSTR = "UPDATE Personal SET Name = '" & txtName.Text & "', empContactNo = '" & txtContactNo.Text & "', Designation = '" & txtDesignation.Text & "', JoinDate = '" & dtJoiningDate.Value & _
                                       "', CardNo = '" & txtCardNo.Text & "', DeptId = " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", empGroup = '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & _
                                       "empActive =" & mOnActive & ", empActDate = NULL, empConfirm = " & mOnConfirm & ", empConDate = NULL WHERE PId = " & txtSerial.Text
                        End If
                    Else
                        If mOnConfirm = 1 Then
                            mSaveSTR = "UPDATE Personal SET Name = '" & txtName.Text & "', empContactNo = '" & txtContactNo.Text & "', Designation = '" & txtDesignation.Text & "', JoinDate = '" & dtJoiningDate.Value & _
                                       "', CardNo = '" & txtCardNo.Text & "', DeptId = " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", empGroup = '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & _
                                       "empActive =" & mOnActive & ", empActDate = '" & mActive & "', empConfirm = " & mOnConfirm & ", empConDate = '" & mConfirm & "' WHERE PId = " & txtSerial.Text
                        Else
                            mSaveSTR = "UPDATE Personal SET Name = '" & txtName.Text & "', empContactNo = '" & txtContactNo.Text & "', Designation = '" & txtDesignation.Text & "', JoinDate = '" & dtJoiningDate.Value & _
                                       "', CardNo = '" & txtCardNo.Text & "', DeptId = " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", empGroup = '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & _
                                       "empActive =" & mOnActive & ", empActDate = '" & mActive & "', empConfirm = " & mOnConfirm & ", empConDate = NULL WHERE PId = " & txtSerial.Text
                        End If
                    End If
                    mSave = ExecuteSQLQuery(mSaveSTR, "Update")
                Else
                    ' Add
                    If mOnActive = 1 Then
                        If mOnConfirm = 1 Then
                            mSaveSTR = "insert into personal(pId,Name,empContactNo,Designation,JoinDate,CardNo,DeptId,empGroup,empActive,empConfirm,empConDate) " & _
                                       "values (" & mEmpID & ", '" & txtName.Text & "', '" & txtContactNo.Text & "', '" & txtDesignation.Text & "', '" & dtJoiningDate.Value & "', '" & _
                                       txtCardNo.Text & "', " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & mOnActive & ", " & _
                                       mOnConfirm & ", '" & mConfirm & "')"
                        Else
                            mSaveSTR = "insert into personal(pId,Name,empContactNo,Designation,JoinDate,CardNo,DeptId,empGroup,empActive,empConfirm) " & _
                                       "values (" & mEmpID & ", '" & txtName.Text & "', '" & txtContactNo.Text & "', '" & txtDesignation.Text & "', '" & dtJoiningDate.Value & "', '" & _
                                       txtCardNo.Text & "', " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & mOnActive & ", " & _
                                       mOnConfirm & ")"
                        End If
                    Else
                        If mOnConfirm = 1 Then
                            mSaveSTR = "insert into personal(pId,Name,empContactNo,Designation,JoinDate,CardNo,DeptId,empGroup,empActive,empActDate,empConfirm,empConDate) " & _
                                       "values (" & mEmpID & ", '" & txtName.Text & "', '" & txtContactNo.Text & "', '" & txtDesignation.Text & "', '" & dtJoiningDate.Value & "', '" & _
                                       txtCardNo.Text & "', " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & mOnActive & ", '" & _
                                       mActive & "', " & mOnConfirm & ", '" & mConfirm & "')"
                        Else
                            mSaveSTR = "insert into personal(pId,Name,empContactNo,Designation,JoinDate,CardNo,DeptId,empGroup,empActive,empActDate,empConfirm) " & _
                                       "values (" & mEmpID & ", '" & txtName.Text & "', '" & txtContactNo.Text & "', '" & txtDesignation.Text & "', '" & dtJoiningDate.Value & "', '" & _
                                       txtCardNo.Text & "', " & cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString() & ", '" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & "', " & mOnActive & ", '" & _
                                       mActive & "', " & mOnConfirm & ")"
                        End If
                    End If
                    mSave = ExecuteSQLQuery(mSaveSTR, "Insert")

                    If mSave = "" Then
                        Call ControlStatus()
                        strSQL = "SELECT PId, Name FROM Personal ORDER BY Name"
                        Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID")
                    Else
                        Exit Sub
                    End If
                End If
            Else
                Exit Sub
            End If
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Call EmployeeInsertUpdate("Update")
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim m As Integer

            m = MsgBox("Are you sure to Delete this Employee Information?", MsgBoxStyle.YesNo, Me.Text)

            If m = vbYes Then
                strSQL = "DELETE FROM Personal WHERE pID = " & Me.txtSerial.Text

                mSave = ExecuteSQLQuery(strSQL, "Delete")
                If mSave = "" Then
                    Call ControlStatus()
                    strSQL = "SELECT PId, Name FROM Personal ORDER BY Name"
                    Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID")
                End If
            End If
        End Sub

        Private Sub InsertUpdateStatus(ByVal bolStatus As Boolean)
            cbGroup.Enabled = bolStatus
            txtCardNo.Enabled = bolStatus
            txtName.Enabled = bolStatus
            txtContactNo.Enabled = bolStatus
            txtDesignation.Enabled = bolStatus
            dtJoiningDate.Enabled = bolStatus
            cbDepartment.Enabled = bolStatus
            rbActive.Enabled = bolStatus
            rbInactive.Enabled = bolStatus
            dtEndDate.Enabled = bolStatus
            rbConfirmed.Enabled = bolStatus
            rbOnProbition.Enabled = bolStatus
            dtConfirmedDate.Enabled = bolStatus
        End Sub

        Private Sub cbSearchDepartment_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSearchDepartment.SelectedIndexChanged
            If cbSearchDepartment.SelectedIndex > 0 Then
                strSQL = "SELECT PId, Name FROM Personal WHERE DeptId = " & cbSearchDepartment.Items(cbSearchDepartment.SelectedIndex).ItemData & " ORDER BY Name"
            Else
                strSQL = "SELECT PId, Name FROM Personal ORDER BY Name"
            End If

            Call LoadComboList(cbEmployee, strSQL, "Employee", "Name", "PID", False)
        End Sub

        Private Sub cbEmployee_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbEmployee.SelectedIndexChanged
            If cbEmployee.SelectedIndex > 0 Then
                Call displayRecord(cbEmployee.Items(cbEmployee.SelectedIndex).ItemData)

                cmdUpdate.Enabled = True
                cmdDelete.Enabled = True
                cmdInsert.Enabled = False
                cmdNew.Text = "New"

                mnuEdit.Enabled = True
                mnuDelete.Enabled = True
                mnuSave.Enabled = False
                mnuCancel.Enabled = False
                mnuAddNew.Enabled = True

                Call InsertUpdateStatus(True)
                mCurrent = cbEmployee.SelectedIndex
            Else
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False
                cmdInsert.Enabled = False
                cmdNew.Text = "New"

                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
                mnuSave.Enabled = False
                mnuCancel.Enabled = False
                mnuAddNew.Enabled = True

                mCurrent = 0
                Call ClearForm()
                Call InsertUpdateStatus(False)
            End If
        End Sub
    End Class
End Namespace