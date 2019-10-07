Namespace Form

    Public Class frmEmployeeAttendence
        Dim mCount As Integer
        Dim mCurrent As Integer
        Private SelectedRow As Integer
        Dim blSave As Boolean

        Private Sub frmEmployeeAttendence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strSQL As String
            Dim i As Integer
            Dim mCount As Integer

            'Me.Top = 0
            'Me.Left = 0
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            blSave = False

            Call ToolStatus(False)

            'strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                strSQL = "SELECT Id, DeptName FROM Department WHERE Id = " & GDepartmentID.ToString() & " ORDER BY DeptName"
                cbDepartment.Enabled = False
            Else
                strSQL = "SELECT Id, DeptName FROM Department ORDER BY DeptName"
            End If

            Call LoadComboList(cbDepartment, strSQL, "Department", "DeptName", "ID", True)

            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                For mCount = 0 To cbDepartment.Items.Count - 1
                    If cbDepartment.Items(mCount).ItemData = GDepartmentID Then
                        cbDepartment.SelectedIndex = mCount
                        Exit For
                    End If
                Next mCount
            End If

            If GDepartmentID = 0 Or GUserType = "" Then
                MsgBox("Access denied, User is not authorized to access this module.", MsgBoxStyle.Critical, "System Manager")
                Me.Close()
            Else
                Select Case GUserType
                    Case "Administrator"
                        If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                            strSQL = "SELECT Name, PID FROM Personal WHERE DeptID = " + GDepartmentID.ToString() + " AND EmpActive = 1 ORDER BY Name ASC"
                        Else
                            strSQL = "SELECT Name, PID FROM Personal WHERE EmpActive = 1 ORDER BY Name ASC"
                        End If
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

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
            Dim dtComboList As New DataTable("Information")
            Dim strSQL As String

            If lbEmployee.SelectedIndex < 0 Then
                MsgBox("Please Select an Employee from the Employee List.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            strSQL = "SELECT SN, edate, etime, status, record FROM Information WHERE manualEntry = 1 AND id = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString() + " And edate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' ORDER BY edate, etime"
            Call LoadDataTable(strSQL, dtComboList)

            With dtgInformation
                .Columns(0).DataPropertyName = "SN"
                .Columns(1).DataPropertyName = "edate"
                .Columns(2).DataPropertyName = "etime"
                .Columns(3).DataPropertyName = "status"
                .Columns(4).DataPropertyName = "record"
                .DataSource = dtComboList
                .Refresh()
            End With
            If dtgInformation.Rows.Count > 0 Then
                Call ToolStatus(True)
                cmdUpdate.Enabled = True
                cmdDelete.Enabled = True
                
                mnuEdit.Enabled = True
                mnuDelete.Enabled = True

                SelectedRow = 0
                'Call ShowSelectedRowValue()
            Else
                Call ToolStatus(False)
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False

                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
                cmdNew.Text = "New"
            End If
        End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            Dim strSQL As String

            Try
                If cbDepartment.SelectedIndex <> -1 Then
                    strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 1 ORDER BY Name"

                    Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")
                    If lbEmployee.Items.Count > 0 Then
                        lbEmployee.SelectedIndex = 0
                    End If
                End If
            Catch exDep As Exception
                MessageBox.Show(exDep.Message, Me.Text)
            End Try
        End Sub

        Private Sub lbEmployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEmployee.SelectedIndexChanged
            If lbEmployee.SelectedIndex >= 0 Then
                lblEmployeeName.Text = lbEmployee.Items(lbEmployee.SelectedIndex).ToString()
                Call cmdFind_Click(sender, e)
            End If
        End Sub

        Private Sub dtgInformation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgInformation.CellClick
            SelectedRow = e.RowIndex

            Call ShowSelectedRowValue()
            If dtgInformation.Rows.Count > 0 Then
                mnuAddNew.Enabled = True
                mnuCancel.Enabled = False
                mnuSave.Enabled = False
                mnuEdit.Enabled = True
                mnuDelete.Enabled = True

                cmdNew.Enabled = True
                cmdInsert.Enabled = False
                cmdUpdate.Enabled = True
                cmdDelete.Enabled = True
                cmdNew.Text = "New"
            End If
            Call ToolStatus(True)
        End Sub

        Private Sub dtgInformation_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgInformation.CellFormatting
            If dtgInformation.Columns(e.ColumnIndex).Name = "Purpose" Then
                Dim stringValue As String = e.Value
                Select Case stringValue
                    Case "True"
                        e.Value = "In"
                    Case "False"
                        e.Value = "Out"
                    Case Else
                        e.Value = ""
                End Select
            ElseIf dtgInformation.Columns(e.ColumnIndex).Name = "EntryTime" Then
                e.Value = FormatDateTime(e.Value, DateFormat.LongTime)    'FormatDateTime(e.Value, DateFormat.ShortTime)
            End If

            Dim cs As New System.Windows.Forms.DataGridViewCellStyle
            cs.BackColor = Color.Gainsboro
            dtgInformation.AlternatingRowsDefaultCellStyle = cs
        End Sub

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Call InsertUpdate("Insert")
            If blSave = True Then
                Call cmdFind_Click(sender, e)
                blSave = False
                'cmdInsert.Enabled = False
                'cmdNew.Text = "New"
                'If dtgInformation.Rows.Count > 0 Then
                '    Dim nextRow As DataGridViewRow = dtgInformation.Rows(dtgInformation.Rows.Count - 1)

                '    dtgInformation.CurrentCell = nextRow.Cells(1)
                '    dtgInformation.FirstDisplayedScrollingRowIndex = dtgInformation.Rows.Count - 1
                '    dtgInformation.Rows(dtgInformation.Rows.Count - 1).Selected = True
                '    dtgInformation.Text = dtgInformation.Rows(dtgInformation.SelectedRows(0).Index).Cells(3).Value.ToString()
                'End If
            End If
        End Sub

        Function BuildRecord() As String
            Dim mQuery As String
            Dim strRecord As String
            Dim arEntryDate() As String
            Dim arEntryTime() As String
            Dim strYr, strMn, strDt As String
            Dim strHr, strMin, strSe As String
            Dim blnStatus As Integer
            Dim crdNo As String

            mQuery = "SELECT cardNo from Personal Where pId=" & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString() & ""
            crdNo = GetCardNo(mQuery, "cardNo")

            'MsgBox(FormatDateTime(dtEntryDate.Value, DateFormat.ShortDate))

            'arEntryDate = Split(Me.dtEntryDate.Value, " ")
            'arEntryDate = Split(arEntryDate(0), Chr(47))
            arEntryDate = Split(FormatDateTime(dtEntryDate.Value, DateFormat.ShortDate), Chr(47))
            strMn = Format(CInt(arEntryDate(0)), "00")
            strDt = Format(CInt(arEntryDate(1)), "00")
            strYr = Format(CInt(arEntryDate(2)), "00")

            'arEntryTime = Split(FormatDateTime(Me.dtEntryTime.Value, DateFormat.LongTime), " ")
            'If arEntryTime(1) = "PM" Then
            '    arEntryTime = Split(arEntryTime(0), Chr(58))
            '    strHr = Format((CInt(arEntryTime(0)) + 12), "00")
            'Else
            '    arEntryTime = Split(arEntryTime(0), Chr(58))
            '    strHr = Format(CInt(arEntryTime(0)), "00")
            'End If
            arEntryTime = Split(FormatDateTime(dtEntryTime.Value, DateFormat.ShortTime), Chr(58))
            strHr = Format(CInt(arEntryTime(0)), "00")
            strMin = Format(CInt(arEntryTime(1)), "00")
            strSe = Format(CInt(0), "00")  'Format(CInt(arEntryTime(2)), "00")

            If rbIn.Checked = True Then
                blnStatus = 1
            Else
                blnStatus = 0
            End If
            strRecord = "005:" & crdNo & ":" & strYr & strMn & strDt & ":" & strHr & strMin & strSe & ":" & blnStatus
            BuildRecord = strRecord
        End Function

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim strDelete As String
            Dim m As Integer

            m = MsgBox("Are you sure to Delete this Record?", MsgBoxStyle.YesNo, Me.Text)
            If m = vbYes Then
                strDelete = "DELETE Information WHERE SN = " & dtgInformation.SelectedRows(0).Cells(0).Value.ToString
                ExecuteSQLQuery(strDelete, "Delete")
                Call cmdFind_Click(sender, e)
            End If
        End Sub

        Private Sub InsertUpdate(ByVal strType As String)
            Dim m As Integer, mSN As Long
            Dim dtCardNo As New DataTable
            Dim mSaveSTR As String
            Dim bStatus As Integer

            If lbEmployee.SelectedIndex < 0 Then
                MsgBox("Please select an Employee from the Employee List.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            If rbIn.Checked = False And rbOut.Checked = False Then
                MsgBox("Please Select In/Out.")
                Exit Sub
            End If
            If Me.rbIn.Checked = True Then
                bStatus = 1
            Else
                bStatus = 0
            End If
            If strType = "Insert" Then
                m = MsgBox("Are you sure to save this information?", MsgBoxStyle.YesNo, Me.Text)
                If m = vbYes Then
                    ' Add
                    mSN = GetMaxID("SELECT (MAX(sn)+1) SN FROM information", "SN")
                    mSaveSTR = "INSERT INTO Information(id,edate,etime,status,record,manualEntry) " & _
                               "values ( " & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString() & ", '" & Format(dtEntryDate.Value, "MM/dd/yyyy").ToString() & "', '" & FormatDateTime(dtEntryTime.Value, DateFormat.ShortTime) & "', " & bStatus & ", '" & _
                               BuildRecord() & "', 1)"
                    'MsgBox(mSaveSTR)
                    ExecuteSQLQuery(mSaveSTR, "Insert")
                Else
                    Exit Sub
                End If
            Else
                m = MsgBox("Are you sure to Change this information?", MsgBoxStyle.YesNo, Me.Text)

                ' Update
                If m = vbYes Then
                    mSaveSTR = "UPDATE Information SET edate = '" & Format(dtEntryDate.Value, "MM/dd/yyyy").ToString() & "', etime = '" & FormatDateTime(dtEntryTime.Value, DateFormat.ShortTime) & _
                               "', record = '" & BuildRecord() & "', Status = " & bStatus & " WHERE SN = " & dtgInformation.SelectedRows(0).Cells(0).Value.ToString()
                    'MsgBox(mSaveSTR)
                    ExecuteSQLQuery(mSaveSTR, "Update")
                Else
                    Exit Sub
                End If
            End If
            blSave = True
        End Sub

        Private Sub mnuMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveNext.Click
            If dtgInformation.Rows.Count > 0 Then
                Dim _rowIndex = dtgInformation.SelectedRows(0).Index + 1
                If _rowIndex <= dtgInformation.Rows.Count - 1 Then
                    Dim nextRow As DataGridViewRow = dtgInformation.Rows(_rowIndex)

                    ' Move the Glyph arrow to the next row
                    dtgInformation.CurrentCell = nextRow.Cells(1)
                    dtgInformation.Rows(_rowIndex).Selected = True
                Else
                    MsgBox("You are End of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub mnuMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveLast.Click
            If dtgInformation.Rows.Count > 0 Then
                Dim _rowIndex = dtgInformation.SelectedRows(0).Index + 1
                If _rowIndex <= dtgInformation.Rows.Count - 1 Then
                    Dim nextRow As DataGridViewRow = dtgInformation.Rows(dtgInformation.Rows.Count - 1)

                    ' Move the Glyph arrow to the next row
                    dtgInformation.CurrentCell = nextRow.Cells(1)
                    dtgInformation.FirstDisplayedScrollingRowIndex = dtgInformation.Rows.Count - 1
                    dtgInformation.Rows(dtgInformation.Rows.Count - 1).Selected = True
                Else
                    MsgBox("You are End of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovePrevious.Click
            If dtgInformation.Rows.Count > 0 Then
                Dim _rowIndex = dtgInformation.SelectedRows(0).Index - 1
                If _rowIndex >= 0 Then
                    Dim nextRow As DataGridViewRow = dtgInformation.Rows(_rowIndex)

                    ' Move the Glyph arrow to the next row
                    dtgInformation.CurrentCell = nextRow.Cells(1)
                    dtgInformation.Rows(_rowIndex).Selected = True
                Else
                    MsgBox("You are Begining of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub mnuMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoveFirst.Click
            If dtgInformation.Rows.Count > 0 Then
                Dim _rowIndex = dtgInformation.SelectedRows(0).Index - 1
                If _rowIndex >= 0 Then
                    Dim nextRow As DataGridViewRow = dtgInformation.Rows(dtgInformation.Rows.Count - 1)

                    ' Move the Glyph arrow to the next row
                    dtgInformation.CurrentCell = nextRow.Cells(1)
                    dtgInformation.FirstDisplayedScrollingRowIndex = 0
                    dtgInformation.Rows(0).Selected = True
                Else
                    MsgBox("You are Begining of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub ToolStatus(ByVal bolStatus As Boolean)
            With Me
                .dtEntryDate.Enabled = bolStatus
                .rbIn.Enabled = bolStatus
                .rbOut.Enabled = bolStatus
                .dtEntryTime.Enabled = bolStatus
                .lblDate.Enabled = bolStatus
                .lblTime.Enabled = bolStatus
                .lblIn.Enabled = bolStatus
                .lblOut.Enabled = bolStatus
            End With
        End Sub

        Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
            Call ControlStatus()
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            Call InsertUpdate("Update")
            Call cmdFind_Click(sender, e)
        End Sub

        Private Sub mnuCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancel.Click
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
            Call cmdInsert_Click(sender, e)
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            Call cmdDelete_Click(sender, e)
        End Sub

        Private Sub btnComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComments.Click
            Me.Close()
            frmCommentsEntry.MdiParent = mdiAttendance
            frmCommentsEntry.Show()
        End Sub

        Private Sub ShowSelectedRowValue()
            dtEntryDate.Value = dtgInformation.SelectedRows(0).Cells(1).Value
            dtEntryTime.Value = DateTime.Parse(dtgInformation.SelectedRows(0).Cells(2).Value)
            If dtgInformation.SelectedRows(0).Cells(3).Value = True Then
                rbIn.Checked = 1
            Else
                rbOut.Checked = 1
            End If
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Call InsertUpdate("Update")
            Call cmdFind_Click(sender, e)
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
                Call ToolStatus(True)
            Else
                If lbEmployee.SelectedIndex > 0 Then
                    cmdInsert.Enabled = False
                    mnuSave.Enabled = False
                    If dtgInformation.SelectedRows.Count > 0 Then
                        mnuEdit.Enabled = True
                        mnuDelete.Enabled = True
                        cmdUpdate.Enabled = True
                        cmdDelete.Enabled = True
                        Call ToolStatus(True)
                    Else
                        mnuEdit.Enabled = False
                        mnuDelete.Enabled = False
                        cmdUpdate.Enabled = False
                        cmdDelete.Enabled = False
                        Call ToolStatus(False)
                    End If

                    mnuCancel.Enabled = False
                Else
                    cmdInsert.Enabled = False

                    mnuSave.Enabled = False
                    mnuCancel.Enabled = False
                    mnuEdit.Enabled = False
                    mnuDelete.Enabled = False
                    Call ToolStatus(False)
                End If
                mnuAddNew.Enabled = True
                cmdNew.Enabled = True
                cmdNew.Text = "New"
            End If
        End Sub

        Private Sub cmdNew_Click(sender As System.Object, e As System.EventArgs) Handles cmdNew.Click
            Call ControlStatus()
        End Sub
    End Class
End NameSpace