Namespace Form
    Public Class frmLeaveReport

        Private Sub frmLeaveReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strSQL As String
            Dim i As Integer
            Dim mCount As Integer

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

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
                        'strSQL = "SELECT Name, PID FROM Personal WHERE EmpActive = 1 ORDER BY Name ASC"
                        If (GDepartmentID = 8) Or (GDepartmentID = 9) Then
                            strSQL = "SELECT Name, PID FROM Personal WHERE DeptID = " + GDepartmentID.ToString() + " AND EmpActive = 1 ORDER BY Name ASC"
                        Else
                            strSQL = "SELECT Name, PID FROM Personal WHERE EmpActive = 1 ORDER BY Name ASC"
                        End If
                    Case "DepartmentHead"
                        strSQL = "SELECT Name, PID FROM Personal WHERE DeptID = " + GDepartmentID.ToString() + " AND EmpActive = 1 ORDER BY Name ASC"

                        cbDepartment.Enabled = False
                        chkInactive.Enabled = False
                    Case "Individual"
                        strSQL = "SELECT Name, PID FROM Personal WHERE PID = " + gUserID.ToString()

                        cbDepartment.Enabled = False
                        chkInactive.Enabled = False
                        chkAll.Enabled = False
                End Select
                Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")

                For i = 0 To lbEmployee.Items.Count - 1
                    If lbEmployee.Items(i).ItemData = gUserID Then
                        lbEmployee.SetSelected(i, True)
                        Exit For
                    End If
                Next i
            End If

            i = Year(Date.Today)
            While i >= 1997
                With cbSummaryYear
                    .Items.Add(New clsList(i.ToString(), i))
                    .SelectedIndex = 0 'Set first item as selected item.
                End With
                i -= 1
            End While

            dtFromDate.Value = GetFirstDayOfMonth(DateTime.Today)
            dtToDate.Value = GetLastDayOfMonth(DateTime.Today)
        End Sub

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
            Dim i As Integer

            If chkAll.Checked = True Then
                If lbEmployee.Items.Count > 0 Then
                    For i = 0 To Me.lbEmployee.Items.Count - 1
                        Me.lbEmployee.SetSelected(i, True)
                    Next i
                End If
            ElseIf chkAll.Checked = False Then
                If lbEmployee.Items.Count > 0 Then
                    For i = 0 To Me.lbEmployee.Items.Count - 1
                        Me.lbEmployee.SetSelected(i, False)
                    Next i
                    Me.lbEmployee.SetSelected(0, True)
                End If
            End If
        End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            Dim strSQL As String

            If cbDepartment.SelectedIndex = 0 Then
                strSQL = "SELECT pId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
            Else
                strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 1 ORDER BY Name"
            End If

            Call LoadListBox(lbEmployee, strSQL, "Access", "Name", "pId")
            chkAll.Checked = False
            chkInactive.Checked = False
        End Sub

        Private Sub chkInactive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInactive.CheckedChanged
            Dim strSQL As String

            If chkInactive.Checked = True Then
                If cbDepartment.SelectedIndex <= 0 Then
                    strSQL = "SELECT pId, Name FROM Personal WHERE empActive = 0 ORDER BY Name"
                Else
                    strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 0 ORDER BY Name"
                End If
            Else
                If cbDepartment.SelectedIndex <= 0 Then
                    strSQL = "SELECT pId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
                Else
                    strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 1 ORDER BY Name"
                End If
            End If

            Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")
            chkAll.Checked = False
        End Sub

        Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
            If lbEmployee.SelectedIndex < 0 Then
                MsgBox("Please select an Employee from the Employee List", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            If dtToDate.Value < dtFromDate.Value Then
                MsgBox("From date could not greater then the To date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            GReportType = "Leave"
            GstrRpt = ""
            gEmpID = ""
            For i = 0 To lbEmployee.SelectedItems.Count - 1
                gEmpID = gEmpID & "," & lbEmployee.SelectedItems.Item(i).ItemData.ToString()
            Next

            gEmpID = Microsoft.VisualBasic.Right(gEmpID, gEmpID.Length - 1)
            If rdoLeaveSummary.Checked = True Then
                GstrRpt = "USP_LEAVESUMMARY_RPT " + cbSummaryYear.Text + ", '" + gEmpID + "'"
                'GstrRpt = "USP_LEAVE_SUMMARY_RPT " + cbSummaryYear.Text + ", '" + gEmpID + "'"
            ElseIf rdoLeaveDetail.Checked = True Then
                GstrRpt = "select r.eId,r.LeaveType,r.NoOfDay,d.leaveDate,p.Name from LeaveReason as r,LeaveDetails as d,personal as p where (r.LeaveId=d.LeaveId) and (r.eId=p.pId) and (r.eId in(" & gEmpID & ")) and (d.leaveDate between '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' and '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "') order by r.eId,d.LeaveDate asc"
            Else
                'GstrRpt = "SELECT AttendanceDate, EmployeeName, EmployeeGroup, InTime, Late, OutTime, TotalWork, AtOffice, OfficeStartHour, WorkingHour, OutOfficeVisit, Comments, Purpose, OverTime, OutOffice, TotalWorkingDay, IndividualWorkingDay " + vbCrLf + "FROM FN_AttendanceCTE_RPT('" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "', '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "', " + "'," + gEmpID + ",') ORDER BY EmployeeName, AttendanceDate"
                Exit Sub
            End If
            'frmReportViewer.MdiParent = mdiAttendance
            frmReportViewer.Show()
        End Sub

        Private Sub lbEmployee_Click(sender As Object, e As System.EventArgs) Handles lbEmployee.Click
            chkAll.Checked = False
            'chkInactive.Checked = False
        End Sub
    End Class
End NameSpace