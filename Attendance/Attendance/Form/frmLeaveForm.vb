Namespace Form
    Public Class frmLeaveForm

        Private Sub frmLeaveForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim strSQL As String
            Dim mCount As Integer
            Dim dtComboList As New DataTable("Department")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            tbNoOfDays.Text = (DateDiff(DateInterval.Day, dtFromDate.Value, dtToDate.Value) + 1).ToString()
            
            Try
                'strSQL = "SELECT PId, Name FROM Personal WHERE empActive = 1 And PID = " & gUserID.ToString()
                'strSQL = "SELECT p.PID, p.Name, (SELECT p1.Designation FROM Personal p1, Head h WHERE p1.PID = h.EmpID And p1.DeptID = p.DeptID) As Supervisor FROM Personal p, Department d WHERE p.DeptID = d.ID And p.empActive = 1 And p.PID = " & gUserID.ToString()
                strSQL = "SELECT E.PID, E.Name, E.empContactNo, (SELECT P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID And D.ID = E.DeptID) As Supervisor FROM Personal E WHERE E.empActive = 1 And E.PID = " & gUserID.ToString()

                Call LoadDataTable(strSQL, dtComboList)

                If dtComboList.Rows.Count > 0 Then
                    tbName.Text = dtComboList.Rows(mCount).Item("Name")
                    If IsDBNull(dtComboList.Rows(mCount).Item("empContactNo")) Then
                        tbContactNo.Text = ""
                    Else
                        tbContactNo.Text = dtComboList.Rows(mCount).Item("empContactNo")
                    End If
                    tbName.Tag = dtComboList.Rows(mCount).Item("PID")
                    If IsDBNull(dtComboList.Rows(mCount).Item("Supervisor")) Then
                        tbSupervisor.Text = ""
                    Else
                        tbSupervisor.Text = dtComboList.Rows(mCount).Item("Supervisor")
                    End If
                Else
                    tbName.Text = ""
                    tbName.Tag = ""
                    tbSupervisor.Text = ""
                End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try

            strSQL = "SELECT ID, LeaveType FROM LeaveType WHERE ID NOT IN(4)"
            Call LoadComboList(cbLeaveType, strSQL, "LeaveType", "LeaveType", "ID", False)
        End Sub
        
        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub cmdShow_Click(sender As System.Object, e As System.EventArgs) Handles cmdShow.Click
            If tbNoOfDays.Text <> "" Then
                If Convert.ToInt32(tbNoOfDays.Text) <= 0 Then
                    MsgBox("From date must less then the To Date.", vbOKOnly + vbInformation, Me.Text)
                    dtFromDate.Focus()
                    Exit Sub
                End If
            End If
            GstrRpt = ""
            GReportType = "LeaveApplication"
            GstrRpt = "SELECT * FROM FN_Leave_Application(" & tbName.Tag.ToString() & ", '" & tbContactNo.Text & "', '" & tbSupervisor.Text & "', '" & CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) & "', '" & dtToDate.Value.ToString("MM/dd/yyyy") & "', " & tbNoOfDays.Text & ", '" & dtSubmission.Value.ToString("MM/dd/yyyy") & "', '" & dtResumption.Value.ToString("MM/dd/yyyy") & "', '" & cbLeaveType.Text & "', '" & tbPurpose.Text & "')"
            'GstrRpt = "SELECT '" & tbName.Text & "' As EmployeeName, '" & tbContactNo.Text & "' As ContactNo, '" & tbSupervisor.Text & "' As , '" & CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) & "', '" & CDate(dtToDate.Value.ToString("MM/dd/yyyy")) & "', " & tbNoOfDays.Text & ", '" & CDate(dtSubmission.Value.ToString("MM/dd/yyyy")) & "', '" & CDate(dtResumption.Value.ToString("MM/dd/yyyy")) & "', '" & cbLeaveType.Text & "', '" & tbPurpose.Text & "')"
            'frmReportViewer.MdiParent = mdiAttendance
            frmReportViewer.Show()
        End Sub

        Private Sub dtFromDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtFromDate.ValueChanged
            tbNoOfDays.Text = (DateDiff("d", dtFromDate.Value.ToString("dd-MMM-yyyy"), dtToDate.Value.ToString("dd-MMM-yyyy")) + 1).ToString()
        End Sub

        Private Sub dtToDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtToDate.ValueChanged
            tbNoOfDays.Text = (DateDiff("d", dtFromDate.Value.ToString("dd-MMM-yyyy"), dtToDate.Value.ToString("dd-MMM-yyyy")) + 1).ToString()
        End Sub

        Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
            frmUpdateContactNo.tbContactNo.Text = Me.tbContactNo.Text
            frmUpdateContactNo.ShowDialog(Me)
        End Sub
    End Class
End NameSpace