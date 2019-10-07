
Namespace Form
    Public Class frmLoanForm

        Private Sub frmLoanForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim strSQL As String
            Dim mCount As Integer
            Dim dtComboList As New DataTable("Department")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            Try
                strSQL = "SELECT E.PID, E.Name, E.Designation, E.JoinDate, (SELECT P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID And D.ID = E.DeptID) As Supervisor FROM Personal E WHERE E.empActive = 1 And E.PID = " & gUserID.ToString()

                Call LoadDataTable(strSQL, dtComboList)

                If dtComboList.Rows.Count > 0 Then
                    tbName.Text = dtComboList.Rows(mCount).Item("Name")
                    tbName.Tag = dtComboList.Rows(mCount).Item("PID")
                    tbDesignation.Text = dtComboList.Rows(mCount).Item("Designation")
                    tbJoinDate.Text = FormatDateTime(dtComboList.Rows(mCount).Item("JoinDate"), DateFormat.ShortDate)
                    If IsDBNull(dtComboList.Rows(mCount).Item("Supervisor")) Then
                        tbSupervisor.Text = ""
                    Else
                        tbSupervisor.Text = dtComboList.Rows(mCount).Item("Supervisor")
                    End If
                Else
                    tbName.Text = ""
                    tbName.Tag = ""
                    tbDesignation.Text = ""
                    tbJoinDate.Text = ""
                    tbSupervisor.Text = ""
                End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try

            strSQL = "SELECT P.PID, P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID"
            Call LoadComboList(cbHeadAF, strSQL, "HeadAF", "Designation", "PID", False)
            Call LoadComboList(cbHeadHR, strSQL, "HeadHR", "Designation", "PID", False)
        End Sub

        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub cmdShow_Click(sender As System.Object, e As System.EventArgs) Handles cmdShow.Click
            Dim strHeadAF As String, strHeadHR As String
            'If tbNoOfDays.Text <> "" Then
            '    If Convert.ToInt32(tbNoOfDays.Text) <= 0 Then
            '        MsgBox("From date must less then the To Date.", vbOKOnly + vbInformation, Me.Text)
            '        dtFromDate.Focus()
            '        Exit Sub
            '    End If
            'End If
            If cbHeadAF.SelectedIndex > 0 Then
                strHeadAF = cbHeadAF.Items(cbHeadAF.SelectedIndex).ToString()
            Else
                strHeadAF = ""
            End If

            If cbHeadHR.SelectedIndex > 0 Then
                strHeadHR = cbHeadHR.Items(cbHeadHR.SelectedIndex).ToString()
            Else
                strHeadHR = ""
            End If

            GstrRpt = ""
            GReportType = "LoanApplication"

            GstrRpt = "SELECT '" & tbName.Text & "' As EmployeeName, '" & tbDesignation.Text & "' As Designation, '" & tbJoinDate.Text & "' As JoinDate, '" & strHeadAF & "' As HeadAF, '" &
            strHeadHR & "' As HeadHR, '" & tbSupervisor.Text & "' As Supervisor, '" & tbMonthlySalary.Text & "' As MonthlySalary, '" & tbLoanAmount.Text & "' As LoanAmount, '" & tbRecoveryAmount.Text & "' As RecoveryAmount, '" &
            tbDuration.Text & "' As Duration, '" & tbDisbursement.Text & "' As Disbursement, '" & tbCommence.Text & "' As Commence, '" & tbCompleted.Text & "' As Completed, '" & tbPurpose.Text & "' As Purpose"

            'frmReportViewer.MdiParent = mdiAttendance
            frmReportViewer.Show()
        End Sub

        Private Sub tbMonthlySalary_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbMonthlySalary.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbLoanAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbLoanAmount.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbRecoveryAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbRecoveryAmount.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbDuration_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbDuration.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbMonthlySalary_LostFocus(sender As Object, e As System.EventArgs) Handles tbMonthlySalary.LostFocus
            If tbMonthlySalary.Text <> "" Then
                tbMonthlySalary.Text = CDbl(tbMonthlySalary.Text).ToString("0,0.00/-")
            End If
        End Sub

        Private Sub tbLoanAmount_LostFocus(sender As Object, e As System.EventArgs) Handles tbLoanAmount.LostFocus
            If tbLoanAmount.Text <> "" Then
                tbLoanAmount.Text = CDbl(tbLoanAmount.Text).ToString("0,0.00/-")
            End If
        End Sub

        Private Sub tbRecoveryAmount_LostFocus(sender As Object, e As System.EventArgs) Handles tbRecoveryAmount.LostFocus
            If tbRecoveryAmount.Text <> "" Then
                tbRecoveryAmount.Text = CDbl(tbRecoveryAmount.Text).ToString("0,0.00/-")
            End If
        End Sub

        Private Sub tbDisbursement_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbDisbursement.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 47) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbDisbursement_LostFocus(sender As Object, e As System.EventArgs) Handles tbDisbursement.LostFocus
            If tbDisbursement.Text <> "" Then
                Call CheckValidMonthAndDay(tbDisbursement)
            End If
        End Sub

        Private Sub CheckValidMonthAndDay(tbObject As TextBox)
            Dim mDate As String() = tbObject.Text.Split("/")
            Dim mMonth As String = mDate(0)
            Dim mDay As String = mDate(1)
            Dim mYear As String = mDate(2)

            If Convert.ToInt32(mMonth) > 12 Or Convert.ToInt32(mMonth) < 0 Or Convert.ToInt32(mDay) > 31 Or Convert.ToInt32(mDay) < 0 Or Convert.ToInt64(mYear) > 9999 Or Convert.ToInt64(mYear) < 1752 Then
                MsgBox("Please enter a valid date. Date Format 'MM/DD/YYYY'.", vbOKOnly + vbInformation, Me.Text)
                tbObject.Focus()
            Else
                Try
                    tbObject.Text = FormatDateTime(CDate(tbObject.Text), DateFormat.ShortDate).ToString()
                Catch e1 As FormatException
                    MsgBox("'" & tbObject.Text & "' - is Invalid date.", vbOKOnly + vbInformation, Me.Text)
                    tbObject.Focus()
                End Try
            End If
        End Sub

        Private Sub tbCommence_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbCommence.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 47) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbCommence_LostFocus(sender As Object, e As System.EventArgs) Handles tbCommence.LostFocus
            If tbCommence.Text <> "" Then
                Call CheckValidMonthAndDay(tbCommence)
            End If
        End Sub

        Private Sub tbCompleted_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbCompleted.KeyPress
            If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 47) Then
                e.Handled = False
            End If
        End Sub

        Private Sub tbCompleted_LostFocus(sender As Object, e As System.EventArgs) Handles tbCompleted.LostFocus
            If tbCompleted.Text <> "" Then
                Call CheckValidMonthAndDay(tbCompleted)
            End If
        End Sub

        Private Sub tbDuration_LostFocus(sender As Object, e As System.EventArgs) Handles tbDuration.LostFocus
            If tbDuration.Text <> "" Then
                tbDuration.Text = CInt(tbDuration.Text).ToString("00")
            End If
        End Sub
    End Class
End Namespace