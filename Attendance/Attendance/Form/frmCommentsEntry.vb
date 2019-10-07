Namespace Form

    Public Class frmCommentsEntry
        Dim strComments As String
        Dim SelectedRow As Integer

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub frmCommentsEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Me.Top = 0
            'Me.Left = 0
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
            If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                Call LoadComboList(cbDepartment, "SELECT Id, DeptName FROM Department WHERE Id = " & GDepartmentID.ToString() & " ORDER BY DeptName", "Department", "DeptName", "Id", False)
                cbDepartment.SelectedIndex = 1
                cbDepartment.Enabled = False
                Call LoadComboList(cbEmployee, "SELECT pId, Name FROM Personal WHERE DeptID = " + GDepartmentID.ToString() + " And empActive = 1 ORDER BY Name", "Personal", "Name", "pId", False)
            Else
                Call LoadComboList(cbDepartment, "SELECT Id, DeptName FROM Department ORDER BY DeptName", "Department", "DeptName", "Id", False)
                Call LoadComboList(cbEmployee, "SELECT pId, Name FROM Personal WHERE empActive = 1 ORDER BY Name", "Personal", "Name", "pId", False)
            End If

            With cbPurpose
                .Items.Clear()
                .Items.Add(New clsList("Official", 1))
                .Items.Add(New clsList("Note", 2))
                .Items.Add(New clsList("Info. Late", 3))
                .SelectedIndex = 0 'Set first item as selected item.
            End With

            With cbType
                .Items.Clear()
                .Items.Add(New clsList("Leave", 1))
                .Items.Add(New clsList("Inclusive Office", 2))
                .Items.Add(New clsList("Exclusive Office", 3))
                .SelectedIndex = 0 'Set first item as selected item.
            End With
        End Sub

        'Private Sub LoadComboList(ByVal ctrlComboBox As ComboBox, ByVal strSQL As String, ByVal strTableName As String, ByVal strDisplay As String, ByVal strID As String)
        '    Dim mCount As Integer
        '    Dim dtComboList As New DataTable(strTableName)

        '    Call LoadDataTable(strSQL, dtComboList)
        '    ctrlComboBox.Items.Clear()

        '    If dtComboList.Rows.Count > 0 Then
        '        For mCount = 0 To dtComboList.Rows.Count - 1
        '            ctrlComboBox.Items.Add(New clsList(dtComboList.Rows(mCount).Item(strDisplay), dtComboList.Rows(mCount).Item(strID)))
        '        Next
        '    End If
        '    ctrlComboBox.SelectedIndex = -1
        'End Sub

        Private Sub PopulateGrid()
            Dim dtComboList As New DataTable("Comments")

            Call LoadDataTable("SELECT C.ID AS CommentsID, C.AttDate AS CommentsDate, C.Duration AS Duration, C.Comments AS Comments, C.Purpose AS Purpose FROM Comments As C INNER JOIN Personal As P ON C.CID = P.PID WHERE C.AttDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' And C.CID = " + cbEmployee.Items(cbEmployee.SelectedIndex).ItemData.ToString(), dtComboList)

            With dgvComments
                .Columns(0).DataPropertyName = "CommentsID"
                .Columns(1).DataPropertyName = "CommentsDate"
                .Columns(2).DataPropertyName = "Duration"
                .Columns(3).DataPropertyName = "Comments"
                .Columns(4).DataPropertyName = "Purpose"
                .DataSource = dtComboList
                .Refresh()
            End With
        End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            Call LoadComboList(cbEmployee, "SELECT pId, Name FROM Personal WHERE empActive = 1 And DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " ORDER BY Name", "Personal", "Name", "pId", False)
        End Sub

        Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
            If cbEmployee.SelectedIndex < 0 Then
                'Validate Employee
                MsgBox("No Employee Selected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                cbEmployee.Focus()
                Exit Sub
            End If
            Call PopulateGrid()
            If dgvComments.RowCount = 0 Then
                tbComments.Text = ""
            Else
                'dgvComments.Rows(0).Selected = True
                'tbComments.Text = dgvComments.Rows(0).Cells(3).Value
            End If
            If dgvComments.Rows.Count > 0 Then
                'Call ToolStatus(True)
                cmdUpdate.Enabled = True
                cmdDelete.Enabled = True

                mnuEdit.Enabled = True
                mnuDelete.Enabled = True
            Else
                'Call ToolStatus(False)
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False

                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
            End If
        End Sub

        Private Sub dgvComments_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComments.CellClick
            If e.RowIndex <> -1 Then
                strComments = dgvComments.Rows(e.RowIndex).Cells(3).Value.ToString
            End If
            tbComments.Text = strComments

            cmdInsert.Enabled = False
            cmdUpdate.Enabled = True
            cmdDelete.Enabled = True
            cmdNew.Text = "New"

            tbOutTime.Enabled = False
            tbInTime.Enabled = False
            cbPurpose.Enabled = False
            cbType.Enabled = False
            dtpComments.Enabled = False

            If strComments <> "" Then
                tbComments.Text = strComments
            Else
                tbComments.Text = ""
            End If

            SelectedRow = e.RowIndex
        End Sub

        Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
            Call ControlStatus()
        End Sub

        Private Sub ControlStatus()
            'If cmdNew.Text = "New" Then
            '    cmdInsert.Enabled = True
            '    cmdUpdate.Enabled = False
            '    cmdDelete.Enabled = False
            '    cmdNew.Text = "Cancel"
            '    tbComments.Text = ""

            '    tbOutTime.Enabled = True
            '    tbInTime.Enabled = True
            '    cbPurpose.Enabled = True
            '    cbType.Enabled = True
            '    dtpComments.Enabled = True
            'Else
            '    cmdInsert.Enabled = False
            '    cmdUpdate.Enabled = False
            '    cmdDelete.Enabled = False
            '    cmdNew.Text = "New"

            '    tbOutTime.Text = ""
            '    tbInTime.Text = ""
            '    cbPurpose.SelectedIndex = -1
            '    cbType.SelectedIndex = -1
            '    dtpComments.Value = Date.Today

            '    tbOutTime.Enabled = False
            '    tbInTime.Enabled = False
            '    cbPurpose.Enabled = False
            '    cbType.Enabled = False
            '    dtpComments.Enabled = False

            '    tbComments.Text = ""
            'End If
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

                tbComments.Text = ""

                tbOutTime.Enabled = True
                tbInTime.Enabled = True
                cbPurpose.Enabled = True
                cbType.Enabled = True
                dtpComments.Enabled = True
            Else
                If cbEmployee.SelectedIndex > 0 Then
                    cmdInsert.Enabled = False
                    mnuSave.Enabled = False
                    If dgvComments.SelectedRows.Count > 0 Then
                        mnuEdit.Enabled = True
                        mnuDelete.Enabled = True
                        cmdUpdate.Enabled = True
                        cmdDelete.Enabled = True
                        'Call ToolStatus(True)
                    Else
                        mnuEdit.Enabled = False
                        mnuDelete.Enabled = False
                        cmdUpdate.Enabled = False
                        cmdDelete.Enabled = False
                        'Call ToolStatus(False)
                    End If

                    mnuCancel.Enabled = False
                Else
                    cmdInsert.Enabled = False

                    mnuSave.Enabled = False
                    mnuCancel.Enabled = False
                    mnuEdit.Enabled = False
                    mnuDelete.Enabled = False
                    'Call ToolStatus(False)
                End If
                tbOutTime.Text = ""
                tbInTime.Text = ""
                cbPurpose.SelectedIndex = 0
                cbType.SelectedIndex = 0
                dtpComments.Value = Date.Today

                tbOutTime.Enabled = False
                tbInTime.Enabled = False
                cbPurpose.Enabled = False
                cbType.Enabled = False
                dtpComments.Enabled = False

                tbComments.Text = ""
                mnuAddNew.Enabled = True
                cmdNew.Enabled = True
                cmdNew.Text = "New"
                If dgvComments.Rows.Count > 0 Then
                    tbComments.Text = dgvComments.Rows(dgvComments.SelectedRows(0).Index).Cells(3).Value.ToString()
                End If
                End If
        End Sub

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Dim dblDuration As Double
            Dim strSQL As String
            Dim m As Integer

            If cbDepartment.SelectedIndex <= 0 Then
                'Validate Department
                MsgBox("No Department Selected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                cbDepartment.Focus()
                Exit Sub
            ElseIf cbEmployee.SelectedIndex <= 0 Then
                'Validate Employee
                MsgBox("No Employee Selected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                cbEmployee.Focus()
                Exit Sub
            ElseIf cbPurpose.Text = "" Then
                'Validate Purpose
                MsgBox("Purpose of entry is not selected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                cbEmployee.Focus()
                Exit Sub
            ElseIf cbType.Text = "" Then
                'Validate Type
                MsgBox("Types of entry is not selected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                cbEmployee.Focus()
                Exit Sub
            End If

            If cbPurpose.Text = "Official" Then
                'Validate Out Time
                If tbOutTime.Text = "" Then
                    MsgBox("Out Time field is blank! Please type Out Time properly.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    tbOutTime.Focus()
                    Exit Sub
                ElseIf IsNumeric(tbOutTime.Text) <> True Then
                    MsgBox("Invalid In Time value! It should be numeric.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    tbOutTime.Focus()
                    Exit Sub
                End If

                'Validate In Time
                If tbInTime.Text = "" Then
                    MsgBox("In Time field is blank! Please type Out Time properly.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    tbInTime.Focus()
                    Exit Sub
                ElseIf IsNumeric(tbInTime.Text) <> True Then
                    MsgBox("Invalid In Time value! It should be numeric.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    tbInTime.Focus()
                    Exit Sub
                End If

                'Validate Out Time In Time Range
                If tbOutTime.Text <> "" And tbInTime.Text <> "" Then
                    If IsNumeric(tbOutTime.Text) = True And IsNumeric(tbInTime.Text) = True Then
                        If CDbl(tbOutTime.Text) > CDbl(tbInTime.Text) Then
                            MsgBox("Invalid time range! In Time should be greater than Out Time value.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                            tbOutTime.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            'Validate Comments
            If tbComments.Text = "" And cbPurpose.Text <> "Info. Late" Then
                MsgBox("Comments field is blank! Please type your comments.", vbExclamation, "Access Control System")
                tbComments.Focus()
                Exit Sub
            Else
                If cbPurpose.Text = "Info. Late" Then
                    If tbComments.Text <> "" Then
                        strComments = cbPurpose.Text & ", " & tbComments.Text
                    Else
                        strComments = cbPurpose.Text
                    End If
                ElseIf cbPurpose.Text = "Note" Then
                    If tbOutTime.Text = "" And tbInTime.Text = "" Then
                        strComments = tbComments.Text
                    Else
                        strComments = tbComments.Text
                        strComments = strComments & vbCrLf & " Out Office Visit: " & (CDbl(tbInTime.Text) - CDbl(tbOutTime.Text)) & " hours"
                    End If
                Else
                    strComments = tbComments.Text
                End If
            End If

            If cbPurpose.Text = "Info. Late" Or cbPurpose.Text = "Note" Then
                dblDuration = 0
            Else
                dblDuration = CDbl(tbInTime.Text) - CDbl(tbOutTime.Text)
            End If

            m = MsgBox("Do you realy want to save this information" & vbCrLf & _
                       "Department: " & cbDepartment.Text & vbCrLf & "Employee Name: " & cbEmployee.Text & vbCrLf & _
                       "Comments Date: " & dtpComments.Value & vbCrLf & "Out Time: " & tbOutTime.Text & vbCrLf & _
                       "In Time: " & tbInTime.Text & vbCrLf & "Comments: " & strComments, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                Dim strTempComments As String
                Dim dblTempDuration As Double
                Dim dtComments As New DataTable("Comments")

                strSQL = "SELECT ID, CID, AttDate, Comments, Status, Duration, Purpose FROM Comments WHERE CID = " & cbEmployee.Items(cbEmployee.SelectedIndex).ItemData.ToString & " And AttDate = '" & CDate(dtpComments.Value.ToString("MM/dd/yyyy")) & "'"
                Call LoadDataTable(strSQL, dtComments)
                If dtComments.Rows.Count > 0 Then
                    strTempComments = dtComments.Rows(0).Item("Comments") & ", " & strComments
                    dblTempDuration = CDbl(dtComments.Rows(0).Item("Duration")) + dblDuration

                    strSQL = "UPDATE Comments SET Comments = '" & strTempComments & "', Duration = " & dblTempDuration & " WHERE ID = " & dtComments.Rows(0).Item("ID")

                    ExecuteSQLQuery(strSQL, "Update")
                Else
                    strTempComments = strComments
                    dblTempDuration = dblDuration

                    strSQL = "INSERT INTO Comments(CID, attDate, Comments, status, Duration, Purpose) " & _
                         "VALUES ( " & cbEmployee.Items(cbEmployee.SelectedIndex).ItemData.ToString & ", '" & CDate(dtpComments.Value.ToString("MM/dd/yyyy")) & "', '" & strTempComments & "', '" & cbType.Text & "', " & _
                         dblTempDuration & ", '" & cbPurpose.Text & "')"

                    ExecuteSQLQuery(strSQL, "Insert")
                End If
                tbOutTime.Text = ""
                tbInTime.Text = ""
                tbComments.Text = ""
                cbPurpose.SelectedIndex = 0
                cbType.SelectedIndex = 0
                dtpComments.Value = Date.Today

                Call cmdFind_Click(sender, e)
            Else
                Exit Sub
            End If
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Dim strSQL As String

            strSQL = "UPDATE Comments SET Comments='" & tbComments.Text & "' WHERE ID = " & dgvComments.Rows(SelectedRow).Cells(0).Value.ToString
            ExecuteSQLQuery(strSQL, "Update")
            dgvComments.Rows(SelectedRow).Cells(3).Value = tbComments.Text
            'tbComments.Text = ""
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim strSQL As String
            Dim msg As Integer

            msg = MsgBox("Do you want to really delete these data?", vbYesNo + vbQuestion, "Delete???")

            If msg = vbNo Then
                Exit Sub
            End If

            strSQL = "DELETE Comments WHERE ID=" & dgvComments.Rows(SelectedRow).Cells(0).Value.ToString
            ExecuteSQLQuery(strSQL, "Delete")

            If Not dgvComments.CurrentRow.IsNewRow Then
                dgvComments.Rows.Remove(dgvComments.CurrentRow)
                tbComments.Text = ""
            End If
        End Sub

        Private Sub btnManualEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualEntry.Click
            Me.Close()
            frmEmployeeAttendence.MdiParent = mdiAttendance
            frmEmployeeAttendence.Show()
        End Sub

        Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub mnuCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancel.Click
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            Call cmdUpdate_Click(sender, e)
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            Call cmdDelete_Click(sender, e)
        End Sub

        Private Sub mnuMoveLast_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveLast.Click
            If dgvComments.Rows.Count > 0 Then
                Dim rowIndex = dgvComments.SelectedRows(0).Index + 1
                If rowIndex <= dgvComments.Rows.Count - 1 Then
                    Dim nextRow As DataGridViewRow = dgvComments.Rows(dgvComments.Rows.Count - 1)

                    ' Move the Glyph arrow to the next row
                    dgvComments.CurrentCell = nextRow.Cells(1)
                    dgvComments.FirstDisplayedScrollingRowIndex = dgvComments.Rows.Count - 1
                    dgvComments.Rows(dgvComments.Rows.Count - 1).Selected = True
                    tbComments.Text = dgvComments.Rows(dgvComments.SelectedRows(0).Index).Cells(3).Value.ToString()
                Else
                    MsgBox("You are End of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
            Call cmdInsert_Click(sender, e)
        End Sub

        Private Sub mnuMoveNext_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveNext.Click
            If dgvComments.Rows.Count > 0 Then
                Dim rowIndex = dgvComments.SelectedRows(0).Index + 1
                If rowIndex <= dgvComments.Rows.Count - 1 Then
                    Dim nextRow As DataGridViewRow = dgvComments.Rows(rowIndex)

                    ' Move the Glyph arrow to the next row
                    dgvComments.CurrentCell = nextRow.Cells(1)
                    dgvComments.Rows(rowIndex).Selected = True
                    tbComments.Text = dgvComments.Rows(dgvComments.SelectedRows(0).Index).Cells(3).Value.ToString()
                Else
                    MsgBox("You are End of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(sender As System.Object, e As System.EventArgs) Handles mnuMovePrevious.Click
            If dgvComments.Rows.Count > 0 Then
                Dim rowIndex = dgvComments.SelectedRows(0).Index - 1
                If rowIndex >= 0 Then
                    Dim nextRow As DataGridViewRow = dgvComments.Rows(rowIndex)

                    ' Move the Glyph arrow to the next row
                    dgvComments.CurrentCell = nextRow.Cells(1)
                    dgvComments.Rows(rowIndex).Selected = True
                    tbComments.Text = dgvComments.Rows(dgvComments.SelectedRows(0).Index).Cells(3).Value.ToString()
                Else
                    MsgBox("You are Begining of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub mnuMoveFirst_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveFirst.Click
            If dgvComments.Rows.Count > 0 Then
                Dim rowIndex = dgvComments.SelectedRows(0).Index - 1
                If rowIndex >= 0 Then
                    Dim nextRow As DataGridViewRow = dgvComments.Rows(dgvComments.Rows.Count - 1)

                    ' Move the Glyph arrow to the next row
                    dgvComments.CurrentCell = nextRow.Cells(1)
                    dgvComments.FirstDisplayedScrollingRowIndex = 0
                    dgvComments.Rows(0).Selected = True
                    tbComments.Text = dgvComments.Rows(dgvComments.SelectedRows(0).Index).Cells(3).Value.ToString()
                Else
                    MsgBox("You are Begining of the File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End Sub

        Private Sub cbEmployee_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbEmployee.SelectedIndexChanged
            Call cmdFind_Click(sender, e)
        End Sub

        Private Sub dgvComments_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvComments.CellFormatting
            Dim cs As New System.Windows.Forms.DataGridViewCellStyle
            cs.BackColor = Color.Gainsboro
            dgvComments.AlternatingRowsDefaultCellStyle = cs
        End Sub
    End Class
End NameSpace