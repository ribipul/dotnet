Imports System.Data.OleDb

Namespace Form
    Public Class frmLeaveCalendar

        Private WithEvents lblDayz As Label
        Dim y As Int32 = 0
        Dim x As Int32
        Dim ndayz As Int32
        Dim Dayofweek, CurrentCulture As String
        Dim currentColor As Color

        Function CheckDay() As Int32
            'Dim time As DateTime = Convert.ToDateTime(comboBoxMonth.Text + "/01/" + textBoxYear.Text)
            Dim time As DateTime = Convert.ToDateTime(cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString + "/01/" + cbYear.Text.ToString)
            'get the start day of the week for the entered date and month
            Dayofweek = Application.CurrentCulture.Calendar.GetDayOfWeek(time).ToString()

            If Dayofweek = "Sunday" Then
                x = 0
            ElseIf Dayofweek = "Monday" Then
                x = 0 + 38
                ndayz = 1
            ElseIf Dayofweek = "Tuesday" Then
                x = 0 + 76
                ndayz = 2
            ElseIf Dayofweek = "Wednesday" Then
                x = 0 + 76 + 38
                ndayz = 3
            ElseIf Dayofweek = "Thursday" Then
                x = 0 + 76 + 76
                ndayz = 4
            ElseIf Dayofweek = "Friday" Then
                x = 0 + 76 + 76 + 38
                ndayz = 5
            ElseIf Dayofweek = "Saturday" Then
                x = 0 + 76 + 76 + 76
                ndayz = 6
            End If
            Return x
        End Function

        Private Sub cbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMonth.SelectedIndexChanged
            Dim mCount As Integer
            Dim dtRecord As New DataTable("Records")

            Dim mSQL As String, mDept As Int32

            mSQL = ""

            mSQL = "select DAY(C.calDate) AS HolidayDay, MONTH(C.calDate) AS HolidayMonth, YEAR(C.calDate) AS HolidayYear, C.HolidayID, H.holidayName, C.ImplementedOn from offCalender As C, Holiday As H where C.holidayId = H.Id And MONTH(calDate) = " + cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString + " and YEAR(calDate) = " + cbYear.Text.ToString
            If lbEmployee.SelectedIndex >= 0 Then
                mSQL = mSQL + vbCrLf + "UNION ALL"
                mSQL = mSQL + vbCrLf + "SELECT DAY(LD.leaveDate) AS HolidayDay, MONTH(LD.leaveDate) AS HolidayMonth, YEAR(LD.leaveDate) AS HolidayYear, LR.LeaveID, LR.LeaveType, P.empGroup FROM LeaveReason AS LR, LeaveDetails AS LD, Personal AS P WHERE LR.EId = P.pId And LR.LeaveId = LD.LeaveId And MONTH(LD.leaveDate) = " + cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString + " and YEAR(LD.leaveDate) = " + cbYear.Text.ToString + " And P.pId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
                mSQL = mSQL + vbCrLf + "ORDER BY HolidayDay"
            End If

            If cbDepartment.Items.Count <> 0 Then
                mDept = cbDepartment.Items(cbDepartment.SelectedIndex).ItemData
            Else
                mDept = -1
            End If

            Call LoadDataTable(mSQL, dtRecord)

            Try
                Dim currentmonth, currentyear As Int32
                currentyear = Convert.ToInt32(cbYear.Text)
                currentmonth = Convert.ToInt32(cbMonth.Items(cbMonth.SelectedIndex).ItemData)

                'remove all the controls in the panel
                panel1.Controls.Clear()

                Dim Dayz As Int32 = DateTime.DaysInMonth(Convert.ToInt32(cbYear.Text), Convert.ToInt32(currentmonth))
                CheckDay()
                For i As Int32 = 1 To Dayz
                    ndayz += 1
                    lblDayz = New Label()
                    With lblDayz
                        .Text = i.ToString()
                        .BorderStyle = BorderStyle.Fixed3D
                        .TextAlign = ContentAlignment.MiddleCenter
                    End With

                    Dim mon As Int32 = Convert.ToInt32(currentmonth)
                    Dim years As Int32 = Convert.ToInt32(cbYear.Text)
                    If ((i = DateTime.Now.Day) And (mon = DateTime.Now.Month) And (years = DateTime.Now.Year)) Then
                        'the current day must be highlighted differently
                        lblDayz.BackColor = Color.SeaGreen
                        ttHelp.SetToolTip(lblDayz, DateTime.Now)
                    ElseIf ndayz = 6 Then
                        If dtRecord.Rows.Count > 0 Then
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL" And dtRecord.Rows(mCount).Item("HolidayID") = 1 Then
                                    lblDayz.BackColor = Color.Red
                                    ttHelp.SetToolTip(lblDayz, "Weekly Holiday")
                                    Exit For
                                ElseIf ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 1 And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL") Then
                                    lblDayz.BackColor = Color.IndianRed
                                    ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    Exit For
                                End If
                            Next
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("HolidayID") <> 1 Then
                                    If dtRecord.Rows(mCount).Item("HolidayName") = "Casual Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Sick Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Compensatory Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Special Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Leave Without Pay" Then
                                        lblDayz.BackColor = Color.MediumPurple
                                        ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    ElseIf ndayz = 5 Or ndayz = 7 Then
                        If dtRecord.Rows.Count > 0 Then
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("ImplementedOn") <> "All" And dtRecord.Rows(mCount).Item("HolidayID") = 2 And mDept <> 9 Then   'And cbDepartment.Items(cbDepartment.SelectedIndex).ItemData <> 9 Then
                                    If Convert.ToInt32(Asc(dtRecord.Rows(mCount).Item("ImplementedOn"))) Mod 2 <> 0 Then
                                        lblDayz.BackColor = Color.CadetBlue
                                        ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn"))
                                        'mToolTip = "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn")
                                    Else
                                        lblDayz.BackColor = Color.SteelBlue
                                        ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn"))
                                        'mToolTip = "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn")
                                    End If
                                    'lblDayz.BackColor = Color.DeepSkyBlue
                                    'ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group A")
                                    Exit For
                                    'ElseIf i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("ImplementedOn") = "B" And dtRecord.Rows(mCount).Item("HolidayID") = 2 Then
                                    '    lblDayz.BackColor = Color.SkyBlue
                                    '    ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group B")
                                    '    Exit For
                                ElseIf ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 2 And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL") Then
                                    lblDayz.BackColor = Color.IndianRed
                                    ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    Exit For
                                End If
                            Next
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("HolidayID") <> 2 Then
                                    If dtRecord.Rows(mCount).Item("HolidayName") = "Casual Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Sick Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Compensatory Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Special Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Leave Without Pay" Then
                                        lblDayz.BackColor = Color.MediumPurple
                                        ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    Else
                        If dtRecord.Rows.Count > 0 Then
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear"))) Then
                                    If dtRecord.Rows(mCount).Item("HolidayName") = "Casual Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Sick Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Compensatory Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Special Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Leave Without Pay" Then
                                        lblDayz.BackColor = Color.MediumPurple
                                    ElseIf ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 1 And dtRecord.Rows(mCount).Item("HolidayID") <> 2) Then
                                        lblDayz.BackColor = Color.IndianRed
                                    Else
                                        'lblDayz.BackColor = Color.DarkRed
                                    End If
                                    ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    Exit For
                                End If
                            Next
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("HolidayID") <> 1 And dtRecord.Rows(mCount).Item("HolidayID") <> 2 Then
                                    If dtRecord.Rows(mCount).Item("HolidayName") = "Casual Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Sick Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Compensatory Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Special Leave" Or dtRecord.Rows(mCount).Item("HolidayName") = "Leave Without Pay" Then
                                        lblDayz.BackColor = Color.MediumPurple
                                        ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                        Exit For
                                    End If
                                End If
                            Next
                        Else
                            'set this color for other days in the selected month
                            lblDayz.BackColor = Color.Silver
                        End If
                    End If
                    lblDayz.Font = label31.Font
                    lblDayz.SetBounds(x, y, 37, 29)
                    x += 38
                    If (ndayz = 7) Then
                        x = 0
                        ndayz = 0
                        y += 29
                    End If
                    AddHandler lblDayz.Click, AddressOf Me.Label_Click   ' Me.lblDayz_Click
                    panel1.Controls.Add(lblDayz)
                Next
                x = 0
                ndayz = 0
                y = 0
            Catch et As FormatException
                MessageBox.Show("Invalid date has been entered")
            Catch ex As NullReferenceException
                MessageBox.Show("Invalid date has been entered")
            End Try

            lbLeaveDay.Items.Clear()
            tbComments.Text = ""
            cbLeaveType.SelectedIndex = -1
            If cbSoledYear.Items.Count > 0 Then
                cbSoledYear.SelectedIndex = (cbSoledYear.Items.Count - 1)
            End If
        End Sub

        Private Sub LoadMontName()
            With cbMonth
                .Items.Add(New clsList("January", 1))
                .Items.Add(New clsList("February", 2))
                .Items.Add(New clsList("March", 3))
                .Items.Add(New clsList("April", 4))
                .Items.Add(New clsList("May", 5))
                .Items.Add(New clsList("June", 6))
                .Items.Add(New clsList("July", 7))
                .Items.Add(New clsList("August", 8))
                .Items.Add(New clsList("September", 9))
                .Items.Add(New clsList("October", 10))
                .Items.Add(New clsList("November", 11))
                .Items.Add(New clsList("December", 12))
                .SelectedIndex = DateTime.Now.Month - 1 'Set first item as selected item.
            End With
        End Sub

        Private Sub Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
            Dim mMatch As Integer
            Dim mSQL As String
            Dim dtLeaveDetail As New DataTable("LeaveDetail")
            mSQL = ""

            If ttHelp.GetToolTip(sender) = "Casual Leave" Or ttHelp.GetToolTip(sender) = "Sick Leave" Or ttHelp.GetToolTip(sender) = "Compensatory Leave" Or ttHelp.GetToolTip(sender) = "Special Leave" Or ttHelp.GetToolTip(sender) = "Leave Without Pay" Then
                mSQL = "SELECT d.LeaveDate, l.LeaveType, l.Comments FROM LeaveReason l, LeaveDetails d, Personal p"
                mSQL = mSQL & vbCrLf & "WHERE l.eid = p.PId and l.LeaveId = d.LeaveId and Day(d.leaveDate) = " & sender.text & " and Month(d.leaveDate) = " & cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString() & " and Year(d.leaveDate) = " & cbYear.Text & " And p.PId = " & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString()

                Call LoadDataTable(mSQL, dtLeaveDetail)
                If dtLeaveDetail.Rows.Count > 0 And sender.backcolor = Color.MediumPurple Then
                    tbComments.Text = dtLeaveDetail.Rows(0).Item("Comments")
                    cbLeaveType.Text = dtLeaveDetail.Rows(0).Item("LeaveType")
                Else
                    tbComments.Text = ""
                    cbLeaveType.Text = ""
                End If
            End If
            If btnDelete.Enabled = True And sender.backcolor <> Color.LemonChiffon Then
                MsgBox("Please Delete this date.", vbOKOnly + vbInformation, Me.Text)
                btnAdd.Enabled = False
                btnDelete.Enabled = True
                btnUpdate.Enabled = True
                Exit Sub
            End If

            mMatch = lbLeaveDay.FindString(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString)

            If mMatch >= 0 Then
                If sender.backcolor = Color.LemonChiffon Then
                    sender.backcolor = Color.MediumPurple
                    btnAdd.Enabled = True
                    btnDelete.Enabled = False
                    btnUpdate.Enabled = False
                Else
                    If ttHelp.GetToolTip(sender) = "Alternate Holiday for Group A" Then
                        sender.backcolor = Color.CadetBlue
                    ElseIf ttHelp.GetToolTip(sender) = "Alternate Holiday for Group B" Then
                        sender.backcolor = Color.SteelBlue
                    ElseIf ttHelp.GetToolTip(sender) = "Alternate Holiday for Group C" Then
                        sender.backcolor = Color.CadetBlue
                    ElseIf ttHelp.GetToolTip(sender) = "Alternate Holiday for Group D" Then
                        sender.backcolor = Color.SteelBlue
                    ElseIf ttHelp.GetToolTip(sender) = "Weekly Holiday" Then
                        sender.backcolor = Color.Red
                    ElseIf sender.text = DateTime.Now.Day.ToString() Then
                        sender.BackColor = Color.SeaGreen
                    ElseIf ttHelp.GetToolTip(sender) <> "" Then
                        sender.backcolor = Color.IndianRed
                    Else
                        sender.backcolor = Color.Silver
                    End If
                End If
                lbLeaveDay.SelectedIndex = mMatch
                lbLeaveDay.Items.Remove(lbLeaveDay.SelectedItem)
            Else
                'If cbLeaveType.SelectedIndex <> -1 Then
                If sender.backcolor = Color.MediumPurple Then
                    lbLeaveDay.Items.Add(New clsList(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString, ((lbLeaveDay.Items.Count - 1) + 1)))
                    sender.backcolor = Color.LemonChiffon
                    btnAdd.Enabled = False
                    btnDelete.Enabled = True
                    btnUpdate.Enabled = True
                Else
                    lbLeaveDay.Items.Add(New clsList(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString, ((lbLeaveDay.Items.Count - 1) + 1)))
                    sender.backcolor = Color.SlateGray
                    btnAdd.Enabled = True
                    btnDelete.Enabled = False
                    btnUpdate.Enabled = False
                End If
                '    Else
                '    MsgBox("Please select Leave Type from Leave Type List.")
                'End If
            End If
        End Sub

        Private Sub frmLeaveCalender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer, i As Integer
            Dim dtHoliday As New DataTable("Holiday")
            Dim mSQL As String

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            Label5.Top = 175
            cbLeaveType.Top = 172
            btnAddNew.Top = 170

            mSQL = "SELECT YEAR(calDate) AS HolidayDate FROM offCalender GROUP BY YEAR(calDate) ORDER BY YEAR(calDate)"
            Call LoadDataTable(mSQL, dtHoliday)
            cbYear.Items.Clear()
            cbSoledYear.Items.Clear()

            If dtHoliday.Rows.Count > 0 Then
                For mCount = 0 To dtHoliday.Rows.Count - 1
                    cbYear.Items.Add(New clsList(dtHoliday.Rows(mCount).Item("HolidayDate"), mCount + 1))
                    cbSoledYear.Items.Add(New clsList(dtHoliday.Rows(mCount).Item("HolidayDate"), mCount + 1))
                Next
                cbYear.SelectedIndex = mCount - 1
                cbSoledYear.SelectedIndex = mCount - 1
            End If

            Call LoadMontName()
            
            mSQL = "SELECT ID, LeaveType FROM LeaveType"
            Call LoadComboList(cbLeaveType, mSQL, "LeaveType", "LeaveType", "ID", False)

            mSQL = "SELECT ID, DeptName FROM Department ORDER BY DeptName"

            Call LoadComboList(cbDepartment, mSQL, "Department", "DeptName", "ID", True)

            If cbDepartment.Text = "All" Then
                mSQL = "SELECT pId As EmployeeID, Name As EmployeeName FROM Personal WHERE empActive = 1 ORDER BY EmployeeName"
            Else
                mSQL = "SELECT pId As EmployeeID, Name As EmployeeName FROM Personal WHERE empActive = 1 And DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " ORDER BY EmployeeName"
            End If
            Call LoadListBox(lbEmployee, mSQL, "Personal", "EmployeeName", "EmployeeID")
            If lbEmployee.Items.Count > 0 Then
                lbEmployee.SelectedIndex = 0
            End If

            cbMonth.SelectedIndex = DateTime.Now.Month - 1

            For i = 0 To lbEmployee.Items.Count - 1
                If lbEmployee.Items(i).ItemData = gUserID Then
                    lbEmployee.SetSelected(i, True)
                    Exit For
                End If
            Next i
        End Sub

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub cbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepartment.SelectedIndexChanged
            Dim strSQL As String

            If cbDepartment.SelectedIndex = 0 Then
                strSQL = "SELECT pId, Name FROM Personal WHERE empActive = 1 ORDER BY Name"
            Else
                strSQL = "SELECT pId, Name FROM Personal WHERE DeptId = " + cbDepartment.Items(cbDepartment.SelectedIndex).ItemData.ToString + " And empActive = 1 ORDER BY Name"
            End If

            Call LoadListBox(lbEmployee, strSQL, "Personal", "Name", "pId")
            If lbEmployee.Items.Count > 0 Then
                lbEmployee.SelectedIndex = 0
            End If
        End Sub

        Private Sub lbEmployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEmployee.SelectedIndexChanged
            'Dim mCount As Integer
            Dim dtPersonal As New DataTable("LeaveInfo")
            Dim mSQL As String
            Dim confDtCL As Date, confDtSL As Date
            Dim CL As Integer, SL As Integer, confYear As Integer
            Dim Datedif As Integer

            btnAdd.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False

            mSQL = ""
            lblEntitle.Text = "Annual Entitlement " + cbYear.Text
            If lbEmployee.SelectedIndex >= 0 Then
                'mSQL = "SELECT p.pid As EmployeeID, p.name As EmployeeName, p.empGroup As EmployeeGroup, p.joindate As JoiningDate, p.empConDate As ConfirmationDate, p.DeptID, "
                'mSQL = mSQL + vbCrLf + "(select count(d.LeaveId) as N from LeaveReason l, LeaveDetails d  where l.eid=p.PId and l.LeaveId=d.LeaveId and  (d.leaveDate between '" + "1/1/" + DateAndTime.Today.Year.ToString() + "' and GETDATE()) and  l.LeaveType = 'Sick Leave') AS AvailSickLeave, "
                'mSQL = mSQL + vbCrLf + "(select count(d.LeaveId) as N from LeaveReason l, LeaveDetails d  where l.eid=p.PId and l.LeaveId=d.LeaveId and  (d.leaveDate between '" + "1/1/" + DateAndTime.Today.Year.ToString() + "' and GETDATE()) and  l.LeaveType = 'Casual Leave') AS AvailCasualLeave,"
                'mSQL = mSQL + vbCrLf + "(select count(d.LeaveId) as N from LeaveReason l, LeaveDetails d  where l.eid=p.PId and l.LeaveId=d.LeaveId  and  l.LeaveType = 'Compensatory Leave') AS AvailCompensatoryLeave, "
                'mSQL = mSQL + vbCrLf + "(select top 1 noofday from LeaveType where LeaveType = 'Sick Leave' order by noofday) AS TotalSickLeave, "
                'mSQL = mSQL + vbCrLf + "(select top 1 noofday from LeaveType where LeaveType = 'Casual Leave' order by noofday) AS TotalCasualLeave, "
                'mSQL = mSQL + vbCrLf + "(select count(o.caldate) as ED from offCalender o where exists(select i.edate from Information i where (o.CalDate=i.eDate and i.Id=p.PID) and (p.empGroup='NA' or ((p.empCondate is not null or o.ImplementedOn='All') AND i.edate >= p.empcondate )) and (p.empGroup=o.ImplementedOn or o.ImplementedOn='All'))) AS TotalCompensatoryLeave, "
                'mSQL = mSQL + vbCrLf + "(select top 1 ActivateDate from LeaveType where  LeaveType = 'Casual Leave' order by ActivateDate desc) AS CasualLeaveActivateDate, "
                'mSQL = mSQL + vbCrLf + "(select top 1 ActivateDate from LeaveType where LeaveType = 'Sick Leave' order by ActivateDate desc) AS SickLeaveActivateDate, "
                'mSQL = mSQL + vbCrLf + "CAST('" + ("12/31/" + cbYear.Text) + "' As smalldatetime) AS LastDateOfReportYear"
                'mSQL = mSQL + vbCrLf + "FROM personal AS p Where p.pid = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + " GROUP BY p.PId, p.name, p.joindate, p.empConDate,p.empGroup,p.DeptID"
                mSQL = "USP_EMP_LEAVE_CALENDER " + cbYear.Text + ", " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
            End If
            Call cbMonth_SelectedIndexChanged(sender, e)

            If mSQL <> "" Then
                Call LoadDataTable(mSQL, dtPersonal)

                If IsDBNull(dtPersonal.Rows(0).Item("ConfirmationDate")) Then
                    confYear = 0
                    confDtCL = dtPersonal.Rows(0).Item("CasualLeaveActivateDate")
                    confDtSL = dtPersonal.Rows(0).Item("SickLeaveActivateDate")
                Else
                    confYear = Year(dtPersonal.Rows(0).Item("ConfirmationDate"))
                    'FIND CASUAL LEAVE & SICK LEAVE
                    Datedif = DateDiff("d", dtPersonal.Rows(0).Item("ConfirmationDate"), dtPersonal.Rows(0).Item("CasualLeaveActivateDate"))
                    If Datedif >= 0 Then
                        confDtCL = dtPersonal.Rows(0).Item("CasualLeaveActivateDate")
                    Else
                        confDtCL = dtPersonal.Rows(0).Item("ConfirmationDate")
                    End If

                    Datedif = DateDiff("d", dtPersonal.Rows(0).Item("ConfirmationDate"), dtPersonal.Rows(0).Item("SickLeaveActivateDate"))
                    If Datedif >= 0 Then
                        confDtSL = dtPersonal.Rows(0).Item("SickLeaveActivateDate")
                    Else
                        confDtSL = dtPersonal.Rows(0).Item("ConfirmationDate")
                    End If
                End If
                
                If dtPersonal.Rows.Count > 0 Then
                    lblGroup.Text = dtPersonal.Rows(0).Item("EmployeeGroup")
                    If confYear = DateAndTime.Now.Year Then
                        'Entitlement
                        'CL = DateDiff("d", CDate(confDtCL), CDate("12/31/" & DateAndTime.Now.Year)) / (365 / dtPersonal.Rows(0).Item("TotalCasualLeave"))
                        'CL = Round(CL)
                        CL = dtPersonal.Rows(0).Item("TotalCasualLeave2")

                        'SL = DateDiff("d", CDate(confDtSL), CDate("12/31/" & DateAndTime.Now.Year)) / (365 / dtPersonal.Rows(0).Item("TotalSickLeave2"))
                        'SL = Round(SL)
                        SL = dtPersonal.Rows(0).Item("TotalSickLeave2")

                        'Annual Entitlement
                        Label43.Text = CL.ToString("0.00")
                        Label49.Text = SL.ToString("0.00")
                        Label53.Text = Convert.ToDouble(0).ToString("0.00")
                        If dtPersonal.Rows(0).Item("DeptID") = 5 Then
                            Label59.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("TotalCompensatoryLeave")).ToString("0.00")
                        Else
                            Label59.Text = "0.00"
                        End If
                        Label64.Text = (Convert.ToDouble(Label43.Text) + Convert.ToDouble(Label49.Text) + Convert.ToDouble(Label53.Text) + Convert.ToDouble(Label59.Text)).ToString("0.00")

                        'Availed during the current year
                        Label42.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("AvailCasualLeave")).ToString("0.00")
                        Label48.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("AvailSickLeave")).ToString("0.00")
                        Label54.Text = Convert.ToDouble(0).ToString("0.00")
                        If dtPersonal.Rows(0).Item("DeptID") = 5 Then
                            Label58.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("AvailCompensatoryLeave")).ToString("0.00")
                        Else
                            Label58.Text = "0.00"
                        End If
                        Label63.Text = (Convert.ToDouble(Label42.Text) + Convert.ToDouble(Label48.Text) + Convert.ToDouble(Label54.Text) + Convert.ToDouble(Label58.Text)).ToString("0.00")

                        'Balance to remain
                        Label41.Text = (Convert.ToDouble(Label43.Text) - Convert.ToDouble(Label42.Text)).ToString("0.00")
                        Label47.Text = (Convert.ToDouble(Label49.Text) - Convert.ToDouble(Label48.Text)).ToString("0.00")
                        Label52.Text = (Convert.ToDouble(Label53.Text) - Convert.ToDouble(Label54.Text)).ToString("0.00")
                        If dtPersonal.Rows(0).Item("DeptID") = 5 Then
                            Label57.Text = (Convert.ToDouble(Label59.Text) - Convert.ToDouble(Label58.Text)).ToString("0.00")
                        Else
                            Label57.Text = "0.00"
                        End If
                        Label62.Text = (Convert.ToDouble(Label64.Text) - Convert.ToDouble(Label63.Text)).ToString("0.00")
                    Else
                        'Annual Entitlement
                        Label43.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("TotalCasualLeave")).ToString("0.00")
                        Label49.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("TotalSickLeave")).ToString("0.00")
                        Label53.Text = Convert.ToDouble(0).ToString("0.00")
                        If dtPersonal.Rows(0).Item("DeptID") = 5 Then
                            Label59.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("TotalCompensatoryLeave")).ToString("0.00")
                        Else
                            Label59.Text = "0.00"
                        End If
                        Label64.Text = (Convert.ToDouble(Label43.Text) + Convert.ToDouble(Label49.Text) + Convert.ToDouble(Label53.Text) + Convert.ToDouble(Label59.Text)).ToString("0.00")
                        
                        'Availed during the current year
                        Label42.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("AvailCasualLeave")).ToString("0.00")
                        Label48.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("AvailSickLeave")).ToString("0.00")
                        Label54.Text = Convert.ToDouble(0).ToString("0.00")
                        If dtPersonal.Rows(0).Item("DeptID") = 5 Then
                            Label58.Text = Convert.ToDouble(dtPersonal.Rows(0).Item("AvailCompensatoryLeave")).ToString("0.00")
                        Else
                            Label58.Text = "0.00"
                        End If
                        Label63.Text = (Convert.ToDouble(Label42.Text) + Convert.ToDouble(Label48.Text) + Convert.ToDouble(Label54.Text) + Convert.ToDouble(Label58.Text)).ToString("0.00")
                        
                        'Balance to remain
                        Label41.Text = (Convert.ToDouble(Label43.Text) - Convert.ToDouble(Label42.Text)).ToString("0.00")
                        Label47.Text = (Convert.ToDouble(Label49.Text) - Convert.ToDouble(Label48.Text)).ToString("0.00")
                        Label52.Text = (Convert.ToDouble(Label53.Text) - Convert.ToDouble(Label54.Text)).ToString("0.00")
                        If dtPersonal.Rows(0).Item("DeptID") = 5 Then
                            Label57.Text = (Convert.ToDouble(Label59.Text) - Convert.ToDouble(Label58.Text)).ToString("0.00")
                        Else
                            Label57.Text = "0.00"
                        End If
                        Label62.Text = (Convert.ToDouble(Label64.Text) - Convert.ToDouble(Label63.Text)).ToString("0.00")
                    End If

                    If dtPersonal.Rows(0).Item("ConfirmationDate").ToString() = "" Then
                        lblStatus.Text = "Confirm Date of " + dtPersonal.Rows(0).Item("EmployeeName") + " is : "
                    Else
                        lblStatus.Text = "Confirm Date of " + dtPersonal.Rows(0).Item("EmployeeName") + " is : " + CDate(dtPersonal.Rows(0).Item("ConfirmationDate").ToString).ToString("MM/dd/yyyy")
                    End If

                End If
            End If
        End Sub

        Private Sub LoadLeaveType()
            Dim mCount As Integer
            Dim dtLeaveType As New DataTable("LeaveType")
            Dim mSQL As String

            mSQL = "SELECT ID, LeaveType FROM LeaveType"

            Call LoadDataTable(mSQL, dtLeaveType)
            cbLeaveType.Items.Clear()

            If dtLeaveType.Rows.Count > 0 Then
                For mCount = 0 To dtLeaveType.Rows.Count - 1
                    cbLeaveType.Items.Add(New clsList(dtLeaveType.Rows(mCount).Item("LeaveType"), dtLeaveType.Rows(mCount).Item("ID")))
                Next
                cbLeaveType.SelectedIndex = -1
            End If
        End Sub

        Private Sub cbYear_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbYear.DropDownClosed
            If cbYear.Items.Count >= 0 Then
                Call cbMonth_SelectedIndexChanged(sender, e)
            End If
        End Sub

        Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            frmSetLeaveInformation.ShowDialog(Me)
        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            'Dim mCount As Integer
            'Dim dDiff As Integer
            Dim mDate As Date
            Dim dtPersonal As New DataTable("Personal")
            Dim dtLeaveDetail As New DataTable("LeaveDetail")
            Dim dtComments As New DataTable("Comments")
            Dim mSQL As String, mDateCount As String
            Dim i As Integer, mLeaveID As Integer

            If lbEmployee.SelectedIndex <> -1 Then
                If lbLeaveDay.Items.Count <= 0 Then
                    MsgBox("Please select a date for Insert", vbOKOnly + vbInformation, Me.Text)
                    Exit Sub
                End If

                If tbComments.Text = "" Then
                    MsgBox("Please Write down the leave reasons in comments field", vbOKOnly + vbInformation, "Information Missing")
                    tbComments.Focus()
                    Exit Sub
                End If

                If cbLeaveType.SelectedIndex = -1 Then
                    MsgBox("Please Select a Leave Type", vbOKOnly + vbInformation, "Information Missing")
                    cbLeaveType.Focus()
                    Exit Sub
                End If

                mDate = Date.Today
                For i = 0 To lbLeaveDay.Items.Count - 1
                    If DateDiff(DateInterval.Day, mDate, CDate(lbLeaveDay.Items(i).ToString())) > 0 Then
                        MsgBox("You cann't grant a date which is greater than today.", vbOKOnly + vbInformation, "Invalid Input")
                        Exit Sub
                    End If
                Next

                mSQL = "SELECT TOP 1 empConDate, JoinDate FROM Personal WHERE empActive = 1 And PId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
                Call LoadDataTable(mSQL, dtPersonal)
                If cbLeaveType.Text = "Casual Leave" Or cbLeaveType.Text = "Sick Leave" Or cbLeaveType.Text = "Earned Leave" Then

                    mDate = dtPersonal.Rows(0).Item("empConDate")
                    If IsDBNull(mDate) Then
                        MsgBox("Employee is not confirmed yet.", vbOKOnly + vbInformation, "System Manager")
                        Exit Sub
                    Else
                        For i = 0 To lbLeaveDay.Items.Count - 1
                            If DateDiff(DateInterval.Day, mDate, CDate(lbLeaveDay.Items(i).ToString())) < 0 Then
                                MsgBox("Invaid date. Leave date cannot be less than employee confirm date", vbOKOnly + vbInformation, "System Manager")
                                Exit Sub
                            End If
                        Next
                    End If
                Else
                    If cbLeaveType.Text = "Compensatory Leave" Or cbLeaveType.Text = "Leave Without Pay" Or cbLeaveType.Text = "Special Leave" Then
                        'mSQL = "SELECT TOP 1 JoinDate FROM Personal WHERE empActive = 1 And PId = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
                        'Call LoadDataTable(mSQL, dtPersonal)

                        mDate = dtPersonal.Rows(0).Item("JoinDate")
                        If IsDBNull(mDate) = False Then
                            For i = 0 To lbLeaveDay.Items.Count - 1
                                If DateDiff(DateInterval.Day, mDate, CDate(lbLeaveDay.Items(i).ToString())) < 0 Then
                                    MsgBox("Invaid date. Leave date cannot be less than employee join date", vbOKOnly + vbInformation, "System Manager")
                                    Exit Sub
                                End If
                            Next
                        End If
                    End If
                End If

                mDateCount = ""
                If lbLeaveDay.Items.Count > 0 Then
                    For i = 0 To lbLeaveDay.Items.Count - 1
                        mDateCount = mDateCount + ",'" + lbLeaveDay.Items(i).ToString() + "'"
                    Next
                    mDateCount = mDateCount.Substring(1, mDateCount.Length - 1) 'Microsoft.VisualBasic.Right(mDateCount, mDateCount.Length - 1)
                Else
                    mDateCount = "'" + lbLeaveDay.Items(0).ToString() + "'"
                End If
                mSQL = "select LD.LeaveDate, LR.LeaveId, P.Name from (LeaveReason AS LR INNER JOIN LeaveDetails AS LD ON LR.LeaveID = LD.LeaveID) INNER JOIN Personal AS P ON LR.EId = P.pId WHERE LR.EID = " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + " AND LD.LeaveDate IN(" + mDateCount + ")"
                Call LoadDataTable(mSQL, dtLeaveDetail)
                If dtLeaveDetail.Rows.Count > 0 Then
                    MsgBox("You can not add a leave at the same date", vbOKOnly + vbInformation, "System Manager")
                    Exit Sub
                End If
                
                If lbLeaveDay.Items.Count > 0 Then
                    For i = 0 To lbLeaveDay.Items.Count - 1
                        mLeaveID = GetMaxID("SELECT (MAX(LeaveId)+1) LeaveId FROM LeaveReason", "LeaveId")

                        mSQL = "INSERT INTO LeaveReason(leaveId, EId, NoOfDay, comments, LeaveType) VALUES(" + mLeaveID.ToString() + ", " + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + ", " + lbLeaveDay.Items.Count.ToString() + ", '" + tbComments.Text + "', '" + cbLeaveType.Items(cbLeaveType.SelectedIndex).ToString() + "')"
                        Call ExecuteSQLQuery(mSQL)

                        mSQL = "INSERT INTO leaveDetails(LeaveId,leaveDate) VALUES(" + mLeaveID.ToString() + ", '" + lbLeaveDay.Items(i).ToString() + "')"
                        Call ExecuteQuery(mSQL)

                        mSQL = "SELECT Comments FROM Comments WHERE cId=" + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + " And attDate='" + lbLeaveDay.Items(0).ToString() + "' And Status = 'Leave'"
                        Call LoadDataTable(mSQL, dtComments)
                        If dtComments.Rows.Count = 0 Then
                            mSQL = "INSERT INTO Comments(cId, attDate, Comments, status) VALUES(" + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + ",'" + lbLeaveDay.Items(i).ToString() + "','" & tbComments.Text & "','Leave')" 'Status: leave. Since it is fixed here. Because employee calendar is only used to persue leave
                            Call ExecuteQuery(mSQL)
                        End If
                    Next
                End If

                lbEmployee.SetSelected(lbEmployee.SelectedIndex, True)

                MsgBox("Successfully Inserted.", vbOKOnly + vbInformation, "System Manager")
            Else
                MsgBox("Please select an Employee from Employee List.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            End If
        End Sub

        Private Sub lbLeaveDay_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbLeaveDay.MouseDoubleClick
            'Dim mMatch As Integer

            'mMatch = lbLeaveDay.SelectedIndex
            'If mMatch >= 0 Then
            '    lbLeaveDay.SelectedIndex = mMatch
            '    lbLeaveDay.Items.Remove(lbLeaveDay.SelectedItem)
            'Else
            '    If cbLeaveType.SelectedIndex <> -1 Then
            '        lbLeaveDay.Items.Add(New clsList(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbLeaveType.Text, cbLeaveType.Items(cbLeaveType.SelectedIndex).ItemData))
            '    Else
            '        MsgBox("Please select Leave Type from Leave Type List.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            '    End If
            'End If
        End Sub

        Private Sub LeaveStatus()
            If cbLeaveType.Text = "Earned Leave" Then
                Label5.Top = 147
                cbLeaveType.Top = 144
                btnAddNew.Top = 142

                rbAvailed.Visible = True
                rbSoled.Visible = True
                rbAvailed.Checked = True
            Else
                Label5.Top = 175
                cbLeaveType.Top = 172
                btnAddNew.Top = 170

                rbAvailed.Visible = False
                rbSoled.Visible = False
                tbSoldAmount.Visible = False
                tbNoOfDay.Visible = False
                lbTk.Visible = False
                lbNoOfDay.Visible = False
                lbDate.Visible = False
                dtSoledDate.Visible = False
                lbYear.Visible = False
                cbSoledYear.Visible = False
            End If
        End Sub

        Private Sub EarnedLeave(ByVal bEarned As Boolean)
            tbSoldAmount.Visible = bEarned
            tbNoOfDay.Visible = bEarned
            lbTk.Visible = bEarned
            lbNoOfDay.Visible = bEarned
            lbDate.Visible = bEarned
            dtSoledDate.Visible = bEarned
            lbYear.Visible = bEarned
            cbSoledYear.Visible = bEarned
        End Sub

        Private Sub cbLeaveType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLeaveType.SelectedIndexChanged
            Call LeaveStatus()
        End Sub

        Private Sub rbAvailed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAvailed.CheckedChanged
            Call EarnedLeave(False)
        End Sub

        Private Sub rbSoled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoled.CheckedChanged
            Call EarnedLeave(True)
        End Sub

        Private Sub ExecuteQuery(ByVal SQLQuery As String)
            Try
                Call CreateConnection()

                gdadbConSTR = New OleDbDataAdapter(SQLQuery, gConEmp)
                gcbACS = New OleDbCommandBuilder(gdadbConSTR)
                gdtConSTR = New DataTable

                gdtConSTR.Reset() ' refresh 
                gdadbConSTR.Fill(gdtConSTR)
            Catch ex As Exception
                MsgBox(ex.Message, vbOKOnly + vbInformation, "System Manager")
            End Try
        End Sub

        Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
            Dim mDateCount As String
            Dim mSQL As String, mLeaveId As String
            Dim dtLeaveDetail As New DataTable("LDetail")
            Dim msg As Integer

            If lbLeaveDay.Items.Count <= 0 Then
                MsgBox("Please select a date for Delete", vbOKOnly + vbInformation, Me.Text)
                Exit Sub
            End If

            msg = MsgBox("Do you want to really delete these data", vbYesNo + vbQuestion, "Delete???")

            If msg = vbNo Then
                Exit Sub
            End If

            mDateCount = ""
            'If lbLeaveDay.Items.Count > 0 Then
            '    For i = 0 To lbLeaveDay.Items.Count - 1
            '        mDateCount = mDateCount + ",'" + lbLeaveDay.Items(i).ToString() + "'"
            '    Next
            '    mDateCount = mDateCount.Substring(1, mDateCount.Length - 1)
            'Else
            '    mDateCount = "'" + lbLeaveDay.Items(0).ToString() + "'"
            'End If
            'mSQL = "SELECT LeaveId FROM LeaveDetails WHERE LeaveDate IN(" + mDateCount + ")"
            'Call LoadDataTable(mSQL, dtLeaveDetail)
            'If dtLeaveDetail.Rows.Count > 0 Then
            '    For i = 0 To dtLeaveDetail.Rows.Count - 1
            '        mLeaveId = mLeaveId + "," + dtLeaveDetail.Rows(i).Item("LeaveId").ToString()
            '    Next
            '    mLeaveId = mLeaveId.Substring(1, mLeaveId.Length - 1)
            'End If
            mDateCount = "'" + lbLeaveDay.Items(0).ToString() + "'"
            mSQL = "SELECT ld.LeaveId FROM LeaveDetails ld, LeaveReason lr, Personal p WHERE ld.LeaveId = lr.LeaveId And lr.EId = p.pId And LeaveDate = " & mDateCount & " And p.pId = " & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
            Call LoadDataTable(mSQL, dtLeaveDetail)

            If dtLeaveDetail.Rows.Count > 0 Then
                mLeaveId = dtLeaveDetail.Rows(0).Item("LeaveId").ToString()
            End If

            mSQL = "DELETE LeaveDetails WHERE LeaveID = " + mLeaveId + vbCrLf + "DELETE LeaveReason WHERE LeaveID = " + mLeaveId + vbCrLf + "DELETE Comments WHERE attDate = " + mDateCount + " And Purpose IS NULL And CID = " & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString

            Call ExecuteSQLQuery(mSQL, "Delete")
            lbEmployee.SetSelected(lbEmployee.SelectedIndex, True)
            btnAdd.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        End Sub

        Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
            'Dim mDateCount As String
            Dim mSQL As String, mLeaveId As String
            Dim dtLeaveDetail As New DataTable("LDetail")
            'Dim dtComments As New DataTable("Comments")
            Dim msg As Integer

            If lbLeaveDay.Items.Count <= 0 Then
                MsgBox("Please select a date for Insert", vbOKOnly + vbInformation, Me.Text)
                Exit Sub
            End If

            msg = MsgBox("Are you sure to update this information", vbYesNo + vbQuestion, "Update???")

            If msg = vbNo Then
                Exit Sub
            End If

            'mDateCount = ""
            'If lbLeaveDay.Items.Count > 0 Then
            '    For i = 0 To lbLeaveDay.Items.Count - 1
            '        mDateCount = mDateCount + ",'" + lbLeaveDay.Items(i).ToString() + "'"
            '    Next
            '    mDateCount = mDateCount.Substring(1, mDateCount.Length - 1)
            'Else
            '    mDateCount = "'" + lbLeaveDay.Items(0).ToString() + "'"
            'End If
            mSQL = "select lr.LeaveId from LeaveReason lr, leaveDetails ld where lr.LeaveId = ld.LeaveId And ld.LeaveDate = '" & lbLeaveDay.Items(0).ToString() & "' And lr.EId = " & lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
            Call LoadDataTable(mSQL, dtLeaveDetail)
            If dtLeaveDetail.Rows.Count > 0 Then
                For i = 0 To dtLeaveDetail.Rows.Count - 1
                    mLeaveId = mLeaveId + "," + dtLeaveDetail.Rows(i).Item("LeaveId").ToString()
                Next
                mLeaveId = mLeaveId.Substring(1, mLeaveId.Length - 1)
            End If
            'mSQL = "DELETE LeaveDetails WHERE LeaveID IN(" + mLeaveId + ")" + vbCrLf + "DELETE LeaveReason WHERE LeaveID IN(" + mLeaveId + ")" + vbCrLf + "DELETE Comments WHERE attDate IN(" + mDateCount + ") And status = 'Leave'"
            'mSQL = "SELECT Id FROM Comments WHERE cId=" + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString + " And attDate='" + lbLeaveDay.Items(0).ToString() + "' And Status = 'Leave'"
            'Call LoadDataTable(mSQL, dtComments)

            mSQL = "UPDATE LeaveReason SET Comments = '" & tbComments.Text & "', LeaveType = '" & cbLeaveType.Items(cbLeaveType.SelectedIndex).ToString() & "' WHERE LeaveId = " + mLeaveId + " And EId=" + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
            Call ExecuteSQLQuery(mSQL, "Update")

            mSQL = "UPDATE Comments SET Comments = '" & tbComments.Text & "' WHERE attDate='" + lbLeaveDay.Items(0).ToString() + "' And Status = 'Leave' And cId=" + lbEmployee.Items(lbEmployee.SelectedIndex).ItemData.ToString
            Call ExecuteSQLQuery(mSQL, "Update")

            lbEmployee.SetSelected(lbEmployee.SelectedIndex, True)

            lbLeaveDay.Items.Clear()
            tbComments.Text = ""
            cbLeaveType.SelectedIndex = -1

            btnAdd.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        End Sub
    End Class
End Namespace