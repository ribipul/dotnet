Imports System.Data.SqlClient

Namespace Form

    Public Class frmEmployeeAgreement

        Private mCurrent As Integer
        Private mCount As Integer
        Dim objDateTime As New System.DateTime

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub frmEmployeeAgrement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Department")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            Call LoadMontName()
            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                strSQL = "SELECT Id, DeptName FROM Department WHERE Id = " & GDepartmentID.ToString() & " ORDER BY DeptName"
                cbDepartment.Enabled = False
            Else
                strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
            End If
            Try
                'strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
                Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", False)
            Catch exAgrement As Exception
                MessageBox.Show(exAgrement.Message, Me.Text)
            End Try

            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                For mCount = 0 To cbDepartment.Items.Count - 1
                    If cbDepartment.Items(mCount).ItemData = GDepartmentID Then
                        cbDepartment.SelectedIndex = mCount
                        Exit For
                    End If
                Next mCount
            End If

            For mCount = 0 To lbEmployee.Items.Count - 1
                If lbEmployee.Items(mCount).ItemData = gUserID Then
                    lbEmployee.SetSelected(mCount, True)
                    Exit For
                End If
            Next mCount

        End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            'Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("Personal")

            Try
                If cbDepartment.SelectedIndex = 0 Then
                    strSQL = "SELECT pId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
                Else
                    strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 1 ORDER BY Name"
                End If

                Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")

                If lbEmployee.Items.Count > 0 Then
                    lbEmployee.SelectedIndex = 0
                Else
                    Call ClearForm(False)
                End If
            Catch exDep As Exception
                MessageBox.Show(exDep.Message, Me.Text)
            End Try
        End Sub

        Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub ClearForm(ByVal blStatus As Boolean)
            With Me
                .txtSN.Text = ""
                .cbEmployeeType.SelectedIndex = 0
                .dtpStartDate.Value = Date.Today
                .txtStartTime.Text = "09:00:00 AM"
                .txtWorkHour.Text = ""

                '.txtSN.Enabled = blStatus
                .cbEmployeeType.Enabled = blStatus
                .dtpStartDate.Enabled = blStatus
                .txtStartTime.Enabled = blStatus
                .txtWorkHour.Enabled = blStatus
            End With
        End Sub

        Private Sub displayRecord(ByVal id As Integer, Optional ByVal mOrderBy As String = "", Optional ByVal mMove As String = "")
            Dim mSQLdr As SqlDataReader
            Dim mSQLcmd = New SqlCommand
            Dim strSQL As String

            Call ConnectToDatabase()
            If id = 0 Then
                strSQL = "SELECT TOP 1 sn, empType, sDate, startHour, workHour FROM PersonalAgreement ORDER BY sn ASC"
            ElseIf id = -1 Then
                strSQL = "SELECT TOP 1 sn, empType, sDate, startHour, workHour FROM PersonalAgreement ORDER BY sn DESC"
            Else
                If mMove = "Next" Then
                    strSQL = "SELECT TOP 1 sn, empType, sDate, startHour, workHour FROM PersonalAgreement WHERE And SN > " & id & " " & mOrderBy
                ElseIf mMove = "Prev" Then
                    strSQL = "SELECT TOP 1 sn, empType, sDate, startHour, workHour FROM PersonalAgreement WHERE And SN < " & id & " " & mOrderBy
                Else
                    strSQL = "SELECT TOP 1 sn, empType, sDate, startHour, workHour FROM PersonalAgreement WHERE sn = " & id & " " & mOrderBy
                End If
            End If

            With mSQLcmd
                .Connection = cnEmp
                .CommandText = strSQL
            End With
            mSQLdr = mSQLcmd.ExecuteReader
            If mSQLdr.HasRows = False Then
                'Call ClearForm()
                If mMove = "Next" Then
                    MsgBox("You are End of the File.", MsgBoxStyle.OkOnly, Me.Text)
                ElseIf mMove = "Prev" Then
                    MsgBox("You are Begin of the File.", MsgBoxStyle.OkOnly, Me.Text)
                End If
                Exit Sub
            End If
            Do While mSQLdr.Read
                Me.txtSN.Text = mSQLdr("SN")
                Me.cbEmployeeType.Text = mSQLdr("empType")
                Me.dtpStartDate.Value = mSQLdr("sDate")
                Me.txtStartTime.Text = mSQLdr("startHour")
                Me.txtWorkHour.Text = mSQLdr("workHour")
            Loop
            mSQLdr.Close()
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            Call InsertUpdateAgrement("Update")
        End Sub

        Private Sub mnuCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancel.Click
            'Call ControlStatus()
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
            Call InsertUpdateAgrement("Insert")
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            Call cmdDelete_Click(sender, e)
        End Sub

        Private Sub mnuMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveNext.Click
            mCurrent = lbEmployee.SelectedIndex
            If lbEmployee.SelectedIndex <> -1 Then
                mCount = lbEmployee.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbEmployee.SelectedIndex = mCurrent + 1
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovePrevious.Click
            mCurrent = lbEmployee.SelectedIndex
            If lbEmployee.SelectedIndex <> -1 Then
                mCount = lbEmployee.Items.Count - 1
                If (mCurrent - 1) < 0 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbEmployee.SelectedIndex = mCurrent - 1
                End If
            End If
        End Sub

        Private Sub mnuMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveFirst.Click
            mCurrent = lbEmployee.SelectedIndex
            If lbEmployee.SelectedIndex <> -1 Then
                mCount = lbEmployee.Items.Count - 1
                If (mCurrent - 1) < 0 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbEmployee.SelectedIndex = 0
                End If
            End If
        End Sub

        Private Sub mnuMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveLast.Click
            mCurrent = lbEmployee.SelectedIndex
            If lbEmployee.SelectedIndex <> -1 Then
                mCount = lbEmployee.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbEmployee.SelectedIndex = mCount
                End If
            End If
        End Sub

        Private Sub lbEmployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEmployee.SelectedIndexChanged
            'Dim mCount As Integer
            Dim strSQL As String
            Dim dtComboList As New DataTable("PersonalAgreement")

            If lbEmployee.SelectedIndex < 0 Then
                MsgBox("Please Select an Employee from the Employee List.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            Try
                strSQL = "SELECT sn, EID, empType, sDate, startHour, workHour FROM PersonalAgreement WHERE eId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString

                Call LoadDataTable(strSQL, dtComboList)

                With dtgAgreement
                    .Columns(0).DataPropertyName = "SN"
                    .Columns(1).DataPropertyName = "EID"
                    .Columns(2).DataPropertyName = "empType"
                    .Columns(3).DataPropertyName = "sDate"
                    .Columns(4).DataPropertyName = "startHour"
                    .Columns(5).DataPropertyName = "workHour"
                    .DataSource = dtComboList
                    .Refresh()
                End With
                If dtgAgreement.Rows.Count > 0 Then
                    Call ClearForm(True)
                    Call ShowSelectedRowValue()
                Else
                    cmdInsert.Enabled = False
                    cmdUpdate.Enabled = False
                    cmdDelete.Enabled = False
                    cmdNew.Text = "New"

                    mnuCancel.Enabled = False
                    mnuDelete.Enabled = False
                    mnuEdit.Enabled = False
                    mnuSave.Enabled = False
                    If dtgAgreement.Rows.Count = 0 Then
                        Call ClearForm(False)
                        'Else
                        'Call ClearForm(True)
                    End If
                End If
                'If dtComboList.Rows.Count > 0 Then
                '    txtSN.Text = dtComboList.Rows(mCount).Item("sn")
                '    txtEmployeeType.Text = dtComboList.Rows(mCount).Item("empType")
                '    dtpStartDate.Value = dtComboList.Rows(mCount).Item("sDate")
                '    txtStartTime.Text = dtComboList.Rows(mCount).Item("startHour")
                '    txtWorkHour.Text = dtComboList.Rows(mCount).Item("workHour")

                '    cmdUpdate.Enabled = True
                '    cmdDelete.Enabled = True
                '    cmdInsert.Enabled = False
                '    cmdNew.Text = "New"

                '    mnuEdit.Enabled = True
                '    mnuDelete.Enabled = True
                '    mnuSave.Enabled = False
                '    mnuCancel.Enabled = False
                '    mnuAddNew.Enabled = True
                'Else
                '    txtSN.Text = ""
                '    txtEmployeeType.Text = ""
                '    dtpStartDate.Value = Date.Today
                '    txtStartTime.Text = ""
                '    txtWorkHour.Text = ""
                'End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try
        End Sub

        Private Sub InsertUpdateAgrement(ByVal strType As String)
            Dim mSN As Integer, m As Integer
            Dim mSaveSTR As String

            If IsEmpty(Me.cbEmployeeType) = True Then
                MsgBox("You can not blank the Employee Type. Please give an Employee Tyoe.", MsgBoxStyle.Information, Me.Text)
                Me.cbEmployeeType.Focus()
                Exit Sub
            End If

            If IsEmpty(Me.txtStartTime) = True Then
                MsgBox("You can not blank the Start Time. Please giv a valied Time.", MsgBoxStyle.Information, Me.Text)
                Me.txtStartTime.Focus()
                Exit Sub
            Else
                Try
                    objDateTime = DateTime.Parse(DirectCast(txtStartTime, System.Windows.Forms.TextBox).Text)
                Catch ex As Exception
                    MsgBox("Not valid time. Time Format: 00:00:00 AM")
                    Exit Sub
                End Try
            End If
            If IsEmpty(Me.txtWorkHour) = True Then
                MsgBox("You can not blank the Working Hour. Please enter Working Hour.", MsgBoxStyle.Information, Me.Text)
                Me.txtWorkHour.Focus()
                Exit Sub
            ElseIf Not IsNumeric(txtWorkHour.Text) Then
                MsgBox("Please enter a valied number.", MsgBoxStyle.Information, Me.Text)
                Me.txtWorkHour.Focus()
                Exit Sub
            End If
            m = MsgBox("Are you sure to save this information?", MsgBoxStyle.YesNo, Me.Text)
            Call ExecuteSQLQuery("SELECT TOP 1 sn, empType, sDate, startHour, workHour FROM PersonalAgreement WHERE sn = " & CInt(Me.txtSN.Text))
            If m = vbYes Then
                If strType = "Update" Then
                    ' Edit

                    mSN = txtSN.Text
                    mSaveSTR = "UPDATE PersonalAgreement SET empType = '" & Me.cbEmployeeType.Text & "', sDate = '" & Me.dtpStartDate.Value & _
                               "', startHour = '" & Me.txtStartTime.Text & "', workHour = " & CInt(Me.txtWorkHour.Text) & " WHERE sn = " & Me.txtSN.Text
                    'MessageBox.Show(mSaveSTR)
                    ExecuteSQLQuery(mSaveSTR, "Update")
                    lbEmployee.SetSelected(mCurrent, True)
                Else
                    ' Add
                    'mSN = GetMaxID("SELECT (MAX(sn)+1) SN FROM PersonalAgreement", "SN")
                    mSaveSTR = "INSERT INTO PersonalAgreement(eId, empType, sDate, startHour, workHour) " & _
                               "values ( " & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString() & ", '" & Me.cbEmployeeType.Text & "', '" & Me.dtpStartDate.Value & "', '" & _
                               Me.txtStartTime.Text & "', " & CInt(Me.txtWorkHour.Text) & ")"
                    'MessageBox.Show(mSaveSTR)
                    ExecuteSQLQuery(mSaveSTR, "Insert")
                    lbEmployee.SetSelected(mCurrent, True)
                    Call ControlStatus()
                End If
            Else
                Exit Sub
            End If
        End Sub

        Private Sub ControlStatus()
            If cmdNew.Text = "New" Then
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
                If dtgAgreement.Rows.Count = 0 Then
                    Call ClearForm(False)
                Else
                    Call ClearForm(True)
                End If
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
                
            End If
        End Sub

        Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
            Dim mQuery As String
            Dim mMaxId As Integer

            If cmdNew.Text = "New" And lbEmployee.SelectedIndex >= 0 Then
                Call ControlStatus()
                Call ClearForm(True)

                mCurrent = lbEmployee.SelectedIndex

                mQuery = "SELECT (MAX(sn)+1) SN FROM PersonalAgreement"
                mMaxId = GetMaxID(mQuery, "SN")
                Me.txtSN.Text = mMaxId
            Else
                If cmdNew.Text = "New" Then
                    MessageBox.Show("Please Select an Employee from Employee List.", Me.Text)
                Else
                    Call ControlStatus()
                    lbEmployee.SetSelected(mCurrent, True)
                    If dtgAgreement.Rows.Count = 0 Then
                        Call ClearForm(False)
                    End If
                End If
            End If
        End Sub

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Call InsertUpdateAgrement("Insert")
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Call InsertUpdateAgrement("Update")
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim strSQL As String
            Dim m As Integer

            m = MsgBox("Are you sure to Delete this Employee Information?", MsgBoxStyle.YesNo, Me.Text)

            If m = vbYes Then
                strSQL = "DELETE PersonalAgreement WHERE sn = " & Me.txtSN.Text
                Try
                    ExecuteSQLQuery(strSQL, "Delete")
                    If lbEmployee.SelectedIndex <> -1 Then
                        lbEmployee.SetSelected(mCurrent, True)
                        'lbEmployee.SelectedIndex = mCurrent
                        'lbEmployee.SelectedIndex = 0
                        Call ControlStatus()
                    End If
                Catch exDelete As Exception
                    MessageBox.Show(exDelete.Message, Me.Text)
                End Try
            End If
        End Sub

        Private Sub dtgAgreement_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAgreement.CellClick
            Call ShowSelectedRowValue()
        End Sub
        Private Sub ShowSelectedRowValue()
            If dtgAgreement.Rows.Count > 0 Then
                txtSN.Text = dtgAgreement.SelectedRows(0).Cells(0).Value
                cbEmployeeType.Text = dtgAgreement.SelectedRows(0).Cells(2).Value
                dtpStartDate.Value = dtgAgreement.SelectedRows(0).Cells(3).Value
                txtStartTime.Text = dtgAgreement.SelectedRows(0).Cells(4).Value
                txtWorkHour.Text = dtgAgreement.SelectedRows(0).Cells(5).Value

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
                txtSN.Text = ""
                cbEmployeeType.SelectedIndex = 0
                dtpStartDate.Value = Date.Today
                txtStartTime.Text = ""
                txtWorkHour.Text = ""

                cmdInsert.Enabled = False
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False

                mnuCancel.Enabled = False
                mnuDelete.Enabled = False
                mnuEdit.Enabled = False
                mnuSave.Enabled = False
            End If
        End Sub

        Private Sub LoadMontName()
            With cbEmployeeType
                .Items.Add(New clsList("Full Time", 1))
                .Items.Add(New clsList("Part Time", 2))
                .SelectedIndex = 0 'Set first item as selected item.
            End With
        End Sub

        Private Sub txtStartTime_Leave(sender As Object, e As System.EventArgs) Handles txtStartTime.Leave
            Try
                objDateTime = DateTime.Parse(DirectCast(sender, System.Windows.Forms.TextBox).Text)
                txtStartTime.Text = objDateTime.ToString("hh:mm:ss tt")
            Catch ex As Exception
                MsgBox("Not valid time. Time Format: 00:00:00 AM")
            End Try
        End Sub
    End Class
End NameSpace