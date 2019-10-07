Namespace Form
    Public Class frmCompensatoryLeave
        Private objDateTime As New System.DateTime

        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub frmCompensatoryLeave_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim strSQL As String
            Dim mCount As Integer
            Dim dtComboList As New DataTable("Department")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            Try
                strSQL = "SELECT E.PID, E.Name, E.Designation, E.empContactNo, (SELECT P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID And D.ID = E.DeptID) As Supervisor, D2.DeptName, (SELECT P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID And D.ID = 6) As HeadHR FROM Personal E, Department D2 WHERE D2.ID = E.DeptID And E.empActive = 1 And E.PID = " & gUserID.ToString()

                Call LoadDataTable(strSQL, dtComboList)

                If dtComboList.Rows.Count > 0 Then
                    tbName.Text = dtComboList.Rows(mCount).Item("Name")
                    If IsDBNull(dtComboList.Rows(mCount).Item("empContactNo")) Then
                        tbContactNo.Text = ""
                    Else
                        tbContactNo.Text = dtComboList.Rows(mCount).Item("empContactNo")
                    End If
                    tbName.Tag = dtComboList.Rows(mCount).Item("PID")
                    tbDesignation.Text = dtComboList.Rows(mCount).Item("Designation")
                    tbDepartment.Text = dtComboList.Rows(mCount).Item("DeptName")
                    If IsDBNull(dtComboList.Rows(mCount).Item("Supervisor")) Then
                        tbSupervisor.Text = ""
                    Else
                        tbSupervisor.Text = dtComboList.Rows(mCount).Item("Supervisor")
                    End If
                    tbHeadHR.Text = dtComboList.Rows(mCount).Item("HeadHR")
                Else
                    tbName.Text = ""
                    tbName.Tag = ""
                    tbDesignation.Text = ""
                    tbDepartment.Text = ""
                    tbSupervisor.Text = ""
                    tbHeadHR.Text = ""
                End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try
        End Sub

        Private Sub cmdShow_Click(sender As System.Object, e As System.EventArgs) Handles cmdShow.Click
            Dim strFDE1, strFDE2, strFDE3, strFDE4 As String
            Dim strTDE1, strTDE2, strTDE3, strTDE4 As String

            Dim strFDA1, strFDA2, strFDA3, strFDA4 As String
            Dim strTDA1, strTDA2, strTDA3, strTDA4 As String

            Dim strNDE1, strNDE2, strNDE3, strNDE4 As Integer
            Dim strNDA1, strNDA2, strNDA3, strNDA4 As Integer

            If Convert.ToInt32(tbNoOfDaysE1.Text) <> 0 Then
                strFDE1 = txtFromDateE1.Text
                strTDE1 = txtToDateE1.Text
                strNDE1 = Convert.ToInt32(tbNoOfDaysE1.Text)
            Else
                strFDE1 = ""
                strTDE1 = ""
                strNDE1 = 0
            End If
            If Convert.ToInt32(tbNoOfDaysE2.Text) <> 0 Then
                strFDE2 = txtFromDateE2.Text
                strTDE2 = txtToDateE2.Text
                strNDE2 = Convert.ToInt32(tbNoOfDaysE2.Text)
            Else
                strFDE2 = ""
                strTDE2 = ""
                strNDE2 = 0
            End If
            If Convert.ToInt32(tbNoOfDaysE3.Text) <> 0 Then
                strFDE3 = txtFromDateE3.Text
                strTDE3 = txtToDateE3.Text
                strNDE3 = Convert.ToInt32(tbNoOfDaysE3.Text)
            Else
                strFDE3 = ""
                strTDE3 = ""
                strNDE3 = 0
            End If
            If Convert.ToInt32(tbNoOfDaysE4.Text) <> 0 Then
                strFDE4 = txtFromDateE4.Text
                strTDE4 = txtToDateE4.Text
                strNDE4 = Convert.ToInt32(tbNoOfDaysE4.Text)
            Else
                strFDE4 = ""
                strTDE4 = ""
                strNDE4 = 0
            End If

            If Convert.ToInt32(tbNoOfDaysA1.Text) <> 0 Then
                strFDA1 = txtFromDateA1.Text
                strTDA1 = txtToDateA1.Text
                strNDA1 = Convert.ToInt32(tbNoOfDaysA1.Text)
            Else
                strFDA1 = ""
                strTDA1 = ""
                strNDA1 = 0
            End If
            If Convert.ToInt32(tbNoOfDaysA2.Text) <> 0 Then
                strFDA2 = txtFromDateA2.Text
                strTDA2 = txtToDateA2.Text
                strNDA2 = Convert.ToInt32(tbNoOfDaysA2.Text)
            Else
                strFDA2 = ""
                strTDA2 = ""
                strNDA2 = 0
            End If
            If Convert.ToInt32(tbNoOfDaysA3.Text) <> 0 Then
                strFDA3 = txtFromDateA3.Text
                strTDA3 = txtToDateA3.Text
                strNDA3 = Convert.ToInt32(tbNoOfDaysA3.Text)
            Else
                strFDA3 = ""
                strTDA3 = ""
                strNDA3 = 0
            End If
            If Convert.ToInt32(tbNoOfDaysA4.Text) <> 0 Then
                strFDA4 = txtFromDateA4.Text
                strTDA4 = txtToDateA4.Text
                strNDA4 = Convert.ToInt32(tbNoOfDaysA4.Text)
            Else
                strFDA4 = ""
                strTDA4 = ""
                strNDA4 = 0
            End If
            'If tbNoOfDaysE1.Text <> "" Then
            '    If Convert.ToInt32(tbNoOfDaysE1.Text) <= 0 Then
            '        MsgBox("From date must less then the To Date.", vbOKOnly + vbInformation, Me.Text)
            '        dtToDateE1.Focus()
            '        Exit Sub
            '    End If
            'End If
            'If tbNoOfDaysA1.Text <> "" Then
            '    If Convert.ToInt32(tbNoOfDaysA1.Text) <= 0 Then
            '        MsgBox("From date must less then the To Date.", vbOKOnly + vbInformation, Me.Text)
            '        dtToDateA1.Focus()
            '        Exit Sub
            '    End If
            'End If

            GstrRpt = ""
            GReportType = "CompensatoryLeave"
            'GstrRpt = "SELECT '" & dtSubmission.Value.ToString("dd-MMM-yyyy") & "' As SubmissionDate, '" & tbName.Text & "' As EmployeeName, '" & tbContactNo.Text & "' As ContactNo, '" & tbDesignation.Text & "' As EmpDesignation, '" & tbDepartment.Text & "' As EmpDepartment, '" &
            '          tbSupervisor.Text & "' As DeptHead, '" & dtFromDateE1.Value.ToString("dd-MMM-yyyy") & "' As EarnedDateF, '" & dtToDateE1.Value.ToString("dd-MMM-yyyy") & "' As EarnedDateT, " & tbNoOfDaysE1.Text & " As DayEarned, '" &
            '          tbTraining.Text & "' As Training, '" & tbITFair.Text & "' As ITFair, '" & tbAttendingToClient.Text & "' As AttendingClient, '" & tbAttendingOffice.Text & "' As AttendingOffice, '" & tbOther.Text & "' As Others, '" & dtFromDateA1.Value.ToString("dd-MMM-yyyy") & "' As AvailedDateF, '" &
            '          dtToDateA1.Value.ToString("dd-MMM-yyyy") & "' As AvailedDateT, " & tbNoOfDaysA1.Text & " As DayAvailed, '" & tbHeadHR.Text & "' As HeadHR"
            GstrRpt = "SELECT '" & dtSubmission.Value.ToString("dd-MMM-yyyy") & "' As SubmissionDate, '" & tbName.Text & "' As EmployeeName, '" & tbContactNo.Text & "' As ContactNo, '" & tbDesignation.Text & "' As EmpDesignation, '" & tbDepartment.Text & "' As EmpDepartment, '" &
                      tbSupervisor.Text & "' As DeptHead, '" & strFDE1 & "' As EarnedDateF, '" & strTDE1 & "' As EarnedDateT, " & strNDE1 & " As DayEarned, '" & strFDE2 & "' As EarnedDateF2, '" & strTDE2 & "' As EarnedDateT2, " & strNDE2 & " As DayEarned2, '" &
                      strFDE3 & "' As EarnedDateF3, '" & strTDE3 & "' As EarnedDateT3, " & strNDE3 & " As DayEarned3, '" & strFDE4 & "' As EarnedDateF4, '" & strTDE4 & "' As EarnedDateT4, " & strNDE4 & " As DayEarned4, '" &
                      tbTraining.Text & "' As Training, '" & tbITFair.Text & "' As ITFair, '" & tbAttendingToClient.Text & "' As AttendingClient, '" & tbAttendingOffice.Text & "' As AttendingOffice, '" & tbOther.Text & "' As Others, '" &
                      strFDA1 & "' As AvailedDateF, '" & strTDA1 & "' As AvailedDateT, " & strNDA1 & " As DayAvailed, '" & strFDA2 & "' As AvailedDateF2, '" & strTDA2 & "' As AvailedDateT2, " & strNDA2 & " As DayAvailed2, '" &
                      strFDA3 & "' As AvailedDateF3, '" & strTDA3 & "' As AvailedDateT3, " & strNDA3 & " As DayAvailed3, '" & strFDA4 & "' As AvailedDateF4, '" & strTDA4 & "' As AvailedDateT4, " & strNDA4 & " As DayAvailed4, '" & tbHeadHR.Text & "' As HeadHR"


            frmReportViewer.Show()
        End Sub

        Private Sub tbTraining_LostFocus(sender As Object, e As System.EventArgs) Handles tbTraining.LostFocus
            If tbTraining.Text <> "" Then
                chkPurpose1.Checked = True
            Else
                chkPurpose1.Checked = False
            End If
        End Sub

        Private Sub tbITFair_LostFocus(sender As Object, e As System.EventArgs) Handles tbITFair.LostFocus
            If tbITFair.Text <> "" Then
                chkPurpose2.Checked = True
            Else
                chkPurpose2.Checked = False
            End If
        End Sub

        Private Sub tbAttendingToClient_LostFocus(sender As Object, e As System.EventArgs) Handles tbAttendingToClient.LostFocus
            If tbAttendingToClient.Text <> "" Then
                chkPurpose3.Checked = True
            Else
                chkPurpose3.Checked = False
            End If
        End Sub

        Private Sub tbAttendingOffice_LostFocus(sender As Object, e As System.EventArgs) Handles tbAttendingOffice.LostFocus
            If tbAttendingOffice.Text <> "" Then
                chkPurpose4.Checked = True
            Else
                chkPurpose4.Checked = False
            End If
        End Sub

        Private Sub tbOther_LostFocus(sender As Object, e As System.EventArgs) Handles tbOther.LostFocus
            If tbOther.Text <> "" Then
                chkPurpose5.Checked = True
            Else
                chkPurpose5.Checked = False
            End If
        End Sub

        Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
            frmUpdateContactNo.tbContactNo.Text = Me.tbContactNo.Text
            frmUpdateContactNo.ShowDialog(Me)
        End Sub

        Private Sub txtFromDateE1_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateE1.GotFocus
            If txtFromDateE1.Text = "MM/DD/YYYY" Then
                txtFromDateE1.Text = ""
            End If
        End Sub

        Private Sub txtFromDateE1_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateE1.Leave
            Call TextBoxValidation(txtFromDateE1, txtToDateE1, tbNoOfDaysE1, sender, "From")
        End Sub

        Private Sub txtToDateE1_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateE1.GotFocus
            If txtToDateE1.Text = "MM/DD/YYYY" Then
                txtToDateE1.Text = ""
            End If
        End Sub

        Private Sub txtToDateE1_Leave(sender As Object, e As System.EventArgs) Handles txtToDateE1.Leave
            Call TextBoxValidation(txtToDateE1, txtFromDateE1, tbNoOfDaysE1, sender, "To")
        End Sub

        Private Sub txtFromDateE2_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateE2.GotFocus
            If txtFromDateE2.Text = "MM/DD/YYYY" Then
                txtFromDateE2.Text = ""
            End If
        End Sub

        Private Sub txtFromDateE2_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateE2.Leave
            Call TextBoxValidation(txtFromDateE2, txtToDateE2, tbNoOfDaysE2, sender, "From")
        End Sub

        Private Sub txtToDateE2_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateE2.GotFocus
            If txtToDateE2.Text = "MM/DD/YYYY" Then
                txtToDateE2.Text = ""
            End If
        End Sub

        Private Sub txtToDateE2_Leave(sender As Object, e As System.EventArgs) Handles txtToDateE2.Leave
            Call TextBoxValidation(txtToDateE2, txtFromDateE2, tbNoOfDaysE2, sender, "To")
        End Sub

        Private Sub txtFromDateE3_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateE3.GotFocus
            If txtFromDateE3.Text = "MM/DD/YYYY" Then
                txtFromDateE3.Text = ""
            End If
        End Sub

        Private Sub txtFromDateE3_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateE3.Leave
            Call TextBoxValidation(txtFromDateE3, txtToDateE3, tbNoOfDaysE3, sender, "From")
        End Sub

        Private Sub txtToDateE3_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateE3.GotFocus
            If txtToDateE3.Text = "MM/DD/YYYY" Then
                txtToDateE3.Text = ""
            End If
        End Sub

        Private Sub txtToDateE3_Leave(sender As Object, e As System.EventArgs) Handles txtToDateE3.Leave
            Call TextBoxValidation(txtToDateE3, txtFromDateE3, tbNoOfDaysE3, sender, "To")
        End Sub

        Private Sub txtFromDateE4_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateE4.GotFocus
            If txtFromDateE4.Text = "MM/DD/YYYY" Then
                txtFromDateE4.Text = ""
            End If
        End Sub

        Private Sub txtFromDateE4_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateE4.Leave
            Call TextBoxValidation(txtFromDateE4, txtToDateE4, tbNoOfDaysE4, sender, "From")
        End Sub

        Private Sub txtToDateE4_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateE4.GotFocus
            If txtToDateE4.Text = "MM/DD/YYYY" Then
                txtToDateE4.Text = ""
            End If
        End Sub

        Private Sub txtToDateE4_Leave(sender As Object, e As System.EventArgs) Handles txtToDateE4.Leave
            Call TextBoxValidation(txtToDateE4, txtFromDateE4, tbNoOfDaysE4, sender, "To")
        End Sub

        Private Sub txtFromDateA1_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateA1.GotFocus
            If txtFromDateA1.Text = "MM/DD/YYYY" Then
                txtFromDateA1.Text = ""
            End If
        End Sub

        Private Sub txtFromDateA1_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateA1.Leave
            Call TextBoxValidation(txtFromDateA1, txtToDateA1, tbNoOfDaysA1, sender, "From")
        End Sub

        Private Sub txtFromDateA2_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateA2.GotFocus
            If txtFromDateA2.Text = "MM/DD/YYYY" Then
                txtFromDateA2.Text = ""
            End If
        End Sub

        Private Sub txtFromDateA2_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateA2.Leave
            Call TextBoxValidation(txtFromDateA2, txtToDateA2, tbNoOfDaysA2, sender, "From")
        End Sub

        Private Sub txtFromDateA3_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateA3.GotFocus
            If txtFromDateA3.Text = "MM/DD/YYYY" Then
                txtFromDateA3.Text = ""
            End If
        End Sub

        Private Sub txtFromDateA3_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateA3.Leave
            Call TextBoxValidation(txtFromDateA3, txtToDateA3, tbNoOfDaysA3, sender, "From")
        End Sub

        Private Sub txtFromDateA4_GotFocus(sender As Object, e As System.EventArgs) Handles txtFromDateA4.GotFocus
            If txtFromDateA4.Text = "MM/DD/YYYY" Then
                txtFromDateA4.Text = ""
            End If
        End Sub

        Private Sub txtFromDateA4_Leave(sender As Object, e As System.EventArgs) Handles txtFromDateA4.Leave
            Call TextBoxValidation(txtFromDateA4, txtToDateA4, tbNoOfDaysA4, sender, "From")
        End Sub

        Private Sub txtToDateA1_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateA1.GotFocus
            If txtToDateA1.Text = "MM/DD/YYYY" Then
                txtToDateA1.Text = ""
            End If
        End Sub

        Private Sub txtToDateA1_Leave(sender As Object, e As System.EventArgs) Handles txtToDateA1.Leave
            Call TextBoxValidation(txtToDateA1, txtFromDateA1, tbNoOfDaysA1, sender, "To")
        End Sub

        Private Sub txtToDateA2_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateA2.GotFocus
            If txtToDateA2.Text = "MM/DD/YYYY" Then
                txtToDateA2.Text = ""
            End If
        End Sub

        Private Sub txtToDateA2_Leave(sender As Object, e As System.EventArgs) Handles txtToDateA2.Leave
            Call TextBoxValidation(txtToDateA2, txtFromDateA2, tbNoOfDaysA2, sender, "To")
        End Sub

        Private Sub txtToDateA3_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateA3.GotFocus
            If txtToDateA3.Text = "MM/DD/YYYY" Then
                txtToDateA3.Text = ""
            End If
        End Sub

        Private Sub txtToDateA3_Leave(sender As Object, e As System.EventArgs) Handles txtToDateA3.Leave
            Call TextBoxValidation(txtToDateA3, txtFromDateA3, tbNoOfDaysA3, sender, "To")
        End Sub

        Private Sub txtToDateA4_GotFocus(sender As Object, e As System.EventArgs) Handles txtToDateA4.GotFocus
            If txtToDateA4.Text = "MM/DD/YYYY" Then
                txtToDateA4.Text = ""
            End If
        End Sub

        Private Sub txtToDateA4_Leave(sender As Object, e As System.EventArgs) Handles txtToDateA4.Leave
            Call TextBoxValidation(txtToDateA4, txtFromDateA4, tbNoOfDaysA4, sender, "To")
        End Sub
    End Class
End NameSpace