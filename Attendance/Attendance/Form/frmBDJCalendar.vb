Imports System.Data.OleDb

Namespace Form
    Public Class frmBDJCalendar
        Private WithEvents lblDayz As Label
        Dim y As Int32 = 0
        Dim x As Int32
        Dim ndayz As Int32
        Dim Dayofweek, CurrentCulture As String

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub frmBDJCalender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer
            Dim dtRecord As New DataTable("Records")
            Dim dtHoliday As New DataTable("Holiday")
            Dim mSQL As String

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            mSQL = "SELECT YEAR(calDate) AS HolidayDate FROM offCalender GROUP BY YEAR(calDate) ORDER BY YEAR(calDate)"
            Call LoadDataTable(mSQL, dtRecord)
            cbYear.Items.Clear()

            If dtRecord.Rows.Count > 0 Then
                For mCount = 0 To dtRecord.Rows.Count - 1
                    cbYear.Items.Add(New clsList(dtRecord.Rows(mCount).Item("HolidayDate"), mCount + 1))
                Next
                cbYear.SelectedIndex = mCount - 1
            End If

            Call LoadMontName()

            'display the current month
            cbMonth.SelectedIndex = DateTime.Now.Month - 1

            mSQL = "SELECT ID, HolidayName FROM Holiday WHERE ID NOT IN(1,2) ORDER BY HolidayName"
            Call LoadComboList(cbGovtHDay, mSQL, "Holiday", "HolidayName", "ID", False)
            'Call LoadDataTable(mSQL, dtHoliday)

            'If dtHoliday.Rows.Count > 0 Then
            '    For mCount = 0 To dtHoliday.Rows.Count - 1
            '        cbGovtHDay.Items.Add(New clsList(dtHoliday.Rows(mCount).Item("HolidayName"), dtHoliday.Rows(mCount).Item("ID")))
            '    Next
            'End If
        End Sub

        Function CheckDay() As Int32
            'Dim time As DateTime = Convert.ToDateTime(comboBoxMonth.Text + "/01/" + textBoxYear.Text)
            Dim time As DateTime = Convert.ToDateTime(cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString + "/01/" + cbYear.Text.ToString)
            'get the start day of the week for the entered date and month
            Dayofweek = Application.CurrentCulture.Calendar.GetDayOfWeek(time).ToString()
            If Dayofweek = "Sunday" Then
                x = 0
            ElseIf Dayofweek = "Monday" Then
                x = 0 + 54
                ndayz = 1
            ElseIf Dayofweek = "Tuesday" Then
                x = 0 + 108
                ndayz = 2
            ElseIf Dayofweek = "Wednesday" Then
                x = 0 + 108 + 54
                ndayz = 3
            ElseIf Dayofweek = "Thursday" Then
                x = 0 + 108 + 108
                ndayz = 4
            ElseIf Dayofweek = "Friday" Then
                x = 0 + 108 + 108 + 54
                ndayz = 5
            ElseIf Dayofweek = "Saturday" Then
                x = 0 + 108 + 108 + 108
                ndayz = 6
            End If
            Return x
        End Function

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
                '.SelectedIndex = 0 'Set first item as selected item.
            End With
        End Sub

        Private Sub cbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMonth.SelectedIndexChanged
            Dim mCount As Integer
            Dim dtRecord As New DataTable("Records")

            Dim mSQL As String, mToolTip As String

            mSQL = "select DAY(C.calDate) AS HolidayDay, MONTH(C.calDate) AS HolidayMonth, YEAR(C.calDate) AS HolidayYear, C.HolidayID, H.holidayName, C.ImplementedOn from offCalender As C, Holiday As H where C.holidayId = H.Id And MONTH(calDate) = " + cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString + " and YEAR(calDate) = " + cbYear.Text.ToString & " ORDER BY HolidayDay"

            Call LoadDataTable(mSQL, dtRecord)

            Try
                Dim currentmonth, currentyear As Int32
                currentyear = Convert.ToInt32(cbYear.Text)
                currentmonth = Convert.ToInt32(cbMonth.Items(cbMonth.SelectedIndex).ItemData)

                'remove all the controls in the panel
                panel1.Controls.Clear()

                'Get there windows culture
                CurrentCulture = Globalization.CultureInfo.CurrentCulture.Name

                'Display the month's name in the windows culture
                My.Application.ChangeCulture(CurrentCulture)

                'This project was created in a computer using en-za
                My.Application.ChangeCulture("en-za")
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
                                    'ElseIf ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 1 And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL") Then
                                    '    lblDayz.BackColor = Color.DarkRed
                                    '    ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    '    Exit For
                                End If
                            Next
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 1 And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL") Then
                                    lblDayz.BackColor = Color.IndianRed
                                    ttHelp.SetToolTip(lblDayz, "Weekly Holiday" & vbCrLf & " & " & vbCrLf & dtRecord.Rows(mCount).Item("HolidayName"))
                                    Exit For
                                End If
                                'If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("HolidayID") <> 1 Then
                                '    lblDayz.BackColor = Color.DarkRed
                                '    ttHelp.SetToolTip(lblDayz, "Weekly Holiday" & vbCrLf & " & " & vbCrLf & dtRecord.Rows(mCount).Item("HolidayName"))
                                '    Exit For
                                'End If
                            Next
                        End If
                    ElseIf ndayz = 5 Or ndayz = 7 Then
                        If dtRecord.Rows.Count > 0 Then
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                mToolTip = ""
                                If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("ImplementedOn") <> "All" And dtRecord.Rows(mCount).Item("HolidayID") = 2 Then
                                    If Convert.ToInt32(Asc(dtRecord.Rows(mCount).Item("ImplementedOn"))) Mod 2 <> 0 Then
                                        lblDayz.BackColor = Color.CadetBlue
                                        ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn"))
                                        mToolTip = "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn")
                                    Else
                                        lblDayz.BackColor = Color.SteelBlue
                                        ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn"))
                                        mToolTip = "Alternate Holiday for Group " & dtRecord.Rows(mCount).Item("ImplementedOn")
                                    End If

                                    Exit For
                                    'ElseIf i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("ImplementedOn") = "B" And dtRecord.Rows(mCount).Item("HolidayID") = 2 Then
                                    '    lblDayz.BackColor = Color.SkyBlue
                                    '    ttHelp.SetToolTip(lblDayz, "Alternate Holiday for Group B")
                                    '    mToolTip = "Alternate Holiday for Group B"
                                    '    Exit For
                                    'ElseIf ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 2 And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL") Then
                                    '    lblDayz.BackColor = Color.DarkRed
                                    '    ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    '    Exit For
                                End If
                            Next
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 2 And dtRecord.Rows(mCount).Item("ImplementedOn") = "ALL") Then
                                    lblDayz.BackColor = Color.IndianRed
                                    If mToolTip <> "" Then
                                        ttHelp.SetToolTip(lblDayz, mToolTip & vbCrLf & " & " & vbCrLf & dtRecord.Rows(mCount).Item("HolidayName"))
                                    Else
                                        ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    End If
                                    Exit For
                                End If
                                'If i = dtRecord.Rows(mCount).Item("HolidayDay") And dtRecord.Rows(mCount).Item("HolidayID") <> 2 Then
                                '    lblDayz.BackColor = Color.DarkRed
                                '    ttHelp.SetToolTip(lblDayz, mToolTip & vbCrLf & " & " & vbCrLf & dtRecord.Rows(mCount).Item("HolidayName"))
                                '    Exit For
                                'End If
                            Next
                        End If
                    Else
                        If dtRecord.Rows.Count > 0 Then
                            For mCount = 0 To dtRecord.Rows.Count - 1
                                If ((i = dtRecord.Rows(mCount).Item("HolidayDay")) And (mon = dtRecord.Rows(mCount).Item("HolidayMonth")) And (years = dtRecord.Rows(mCount).Item("HolidayYear")) And dtRecord.Rows(mCount).Item("HolidayID") <> 1 And dtRecord.Rows(mCount).Item("HolidayID") <> 2) Then
                                    lblDayz.BackColor = Color.IndianRed
                                    ttHelp.SetToolTip(lblDayz, dtRecord.Rows(mCount).Item("HolidayName"))
                                    Exit For
                                End If
                            Next
                        Else
                            'set this color for other days in the selected month
                            lblDayz.BackColor = Color.Silver
                        End If
                    End If
                    lblDayz.Font = label31.Font
                    lblDayz.SetBounds(x, y, 47, 37)
                    x += 54
                    If (ndayz = 7) Then
                        x = 0
                        ndayz = 0
                        y += 39
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
        End Sub

        Private Sub Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
            Dim mMatch As Integer, i As Integer
            Dim mSQL As String
            'Dim mDateCount As String
            'Dim mHolidayId As String
            Dim dtLeaveDetail As New DataTable("Holiday")

            mSQL = ""

            'If ttHelp.GetToolTip(sender) <> "" Or ttHelp.GetToolTip(sender) <> "Weekly Holiday" Or ttHelp.GetToolTip(sender) <> "Alternate Holiday for Group A" Or ttHelp.GetToolTip(sender) <> "Alternate Holiday for Group B" Or ttHelp.GetToolTip(sender) <> "Alternate Holiday for Group C" Or ttHelp.GetToolTip(sender) <> "Alternate Holiday for Group D" Then
            mSQL = "SELECT C.ID As CalID, CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.ID As HolidayId, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H "
            mSQL = mSQL & vbCrLf & "WHERE C.holidayId = H.Id And Day(C.calDate) = " & sender.text & " and Month(C.calDate) = " & cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString() & " and Year(C.calDate) = " & cbYear.Text & " And C.ImplementedOn = 'ALL' And H.Id <> 1 ORDER BY CalDate"

            Call LoadDataTable(mSQL, dtLeaveDetail)
            If dtLeaveDetail.Rows.Count > 0 And sender.backcolor = Color.IndianRed Then
                sender.tag = dtLeaveDetail.Rows(0).Item("CalID")
                For i = 0 To cbGovtHDay.Items.Count - 1
                    If cbGovtHDay.Items(i).ItemData.ToString() = dtLeaveDetail.Rows(0).Item("holidayId").ToString() Then
                        cbGovtHDay.SelectedIndex = i
                        Exit For
                    End If
                Next i
            Else        'If dtLeaveDetail.Rows.Count > 0 And sender.backcolor = Color.LemonChiffon Then
                'sender.tag = ((lbGovtHDay.Items.Count - 1) + 1).ToString()
                cbGovtHDay.SelectedIndex = 0
            End If
            'End If

            If btnDelete.Enabled = True And sender.backcolor <> Color.LemonChiffon Then
                MsgBox("Please Delete this date.", vbOKOnly + vbInformation, Me.Text)
                btnGovtHoliday.Enabled = False
                btnDelete.Enabled = True
                Exit Sub
            End If

            mMatch = lbGovtHDay.FindString(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString)

            If mMatch >= 0 Then
                If sender.backcolor = Color.LemonChiffon Then
                    sender.backcolor = Color.IndianRed
                    btnGovtHoliday.Enabled = True
                    btnDelete.Enabled = False
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
                lbGovtHDay.SelectedIndex = mMatch
                lbGovtHDay.Items.Remove(lbGovtHDay.SelectedItem)
            Else
                If sender.backcolor = Color.IndianRed Then
                    lbGovtHDay.Items.Add(New clsList(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString, sender.tag))        '((lbGovtHDay.Items.Count - 1) + 1)))
                    sender.backcolor = Color.LemonChiffon
                    btnGovtHoliday.Enabled = False
                    btnDelete.Enabled = True
                Else
                    lbGovtHDay.Items.Add(New clsList(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString, sender.tag))        '((lbGovtHDay.Items.Count - 1) + 1)))
                    sender.backcolor = Color.SlateGray
                    btnGovtHoliday.Enabled = True
                    btnDelete.Enabled = False
                End If
            End If
        End Sub

        Private Sub btnGovtHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGovtHoliday.Click
            Dim mCount As Integer
            Dim mSQL As String
            Dim mDateCount As String
            Dim mHolidayId As String

            If lbGovtHDay.Items.Count <= 0 Then
                MsgBox("Please select a date for Insert", vbOKOnly + vbInformation, "Information Missing")
                Exit Sub
            End If

            If cbGovtHDay.SelectedIndex <= 0 Then
                MsgBox("Please Select a Holiday Type", vbOKOnly + vbInformation, "Information Missing")
                cbGovtHDay.Focus()
                Exit Sub
            End If

            mCount = MsgBox("Do you want to insert this date?", vbYesNo + vbQuestion, Me.Text)

            If mCount = vbYes Then
                mDateCount = ""
                If lbGovtHDay.Items.Count > 0 Then
                    For i = 0 To lbGovtHDay.Items.Count - 1
                        mDateCount = mDateCount + "," + lbGovtHDay.Items(i).ToString        ' Mid(lbGovtHDay.Items(i).ToString, 1, 10)
                    Next
                    mDateCount = mDateCount.Substring(1, mDateCount.Length - 1)
                Else
                    mDateCount = "," + lbGovtHDay.Items(0).ToString() + ","
                End If

                mHolidayId = ""
                If lbGovtHDay.Items.Count > 0 Then
                    For i = 0 To lbGovtHDay.Items.Count - 1
                        mHolidayId = mHolidayId + "," + cbGovtHDay.Items(cbGovtHDay.SelectedIndex).ItemData.ToString()      ' lbGovtHDay.Items(i).ItemData.ToString()
                    Next
                    mHolidayId = mHolidayId.Substring(1, mHolidayId.Length - 1)
                Else
                    mHolidayId = "," + lbGovtHDay.Items(0).ToString() + ","
                End If

                mSQL = "USP_SET_GOVT_HOLIDAY '" & mDateCount & "', '" & mHolidayId & "', ','"
                Call ExecuteSQLQuery(mSQL, "Insert")
                Call btnClear_Click(sender, e)
            Else
                Exit Sub
            End If
        End Sub

        Private Sub btnAlternateHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlternateHoliday.Click
            'Dim dtAHoliday As New DataTable("Holiday")
            'Dim mAltHDay As String
            'Dim m As Integer

            frmAltenateHoliday.ShowDialog(Me)
            Exit Sub

            'm = MsgBox("Are you sure to set the Alternate Holiday of the year of " + cbYear.Text + "?", MsgBoxStyle.YesNo, Me.Text)
            'If m = vbYes Then
            '    mAltHDay = "SELECT CalDate FROM offCalender WHERE YEAR(CalDate) = " + cbYear.Text + " And ImplementedOn <> 'ALL' And HolidayID = (SELECT ID FROM Holiday WHERE holidayName = 'Alternate Holiday')"
            '    Call LoadDataTable(mAltHDay, dtAHoliday)
            '    If dtAHoliday.Rows.Count > 0 Then
            '        m = MsgBox("There are already set the Alternate Holiday." + vbCrLf + "Do you want to update Alternate Holiday?", MsgBoxStyle.YesNo, Me.Text)
            '        If m = vbYes Then
            '            mAltHDay = "SET_ALTENATE_HOLIDAY " + cbYear.Text
            '            ExecuteSQLQuery(mAltHDay, "Insert")
            '        Else
            '            Exit Sub
            '        End If
            '    Else
            '        mAltHDay = "SET_ALTENATE_HOLIDAY " + cbYear.Text
            '        ExecuteSQLQuery(mAltHDay, "Insert")
            '    End If
            '    Call btnClear_Click(sender, e)
            'End If
        End Sub

        Private Sub btnWeeklyHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeeklyHoliday.Click
            Dim dtWHoliday As New DataTable("Holiday")
            Dim mWkHDay As String
            Dim m As Integer

            m = MsgBox("Are you sure to set the Weekly Holiday of the year of " + Year(Now).ToString() + "?", MsgBoxStyle.YesNo, Me.Text)
            If m = vbYes Then
                mWkHDay = "SELECT CalDate FROM offCalender WHERE YEAR(CalDate) = " + Year(Now).ToString() + " And ImplementedOn = 'ALL' AND HolidayID = (SELECT ID FROM Holiday WHERE holidayName = 'Weekly Holiday')"
                Call LoadDataTable(mWkHDay, dtWHoliday)
                If dtWHoliday.Rows.Count > 0 Then
                    m = MsgBox("There are already set the Weekly Holiday." + vbCrLf + "Do you want to update Weekly Holiday?", MsgBoxStyle.YesNo, Me.Text)
                    If m = vbYes Then
                        mWkHDay = "SET_WEEKLY_HOLIDAY " + Year(Now).ToString()
                        ExecuteSQLQuery(mWkHDay, "Insert")
                    Else
                        Exit Sub
                    End If
                Else
                    mWkHDay = "SET_WEEKLY_HOLIDAY " + Year(Now).ToString()
                    ExecuteSQLQuery(mWkHDay, "Insert")
                End If
                Call btnClear_Click(sender, e)
            End If
        End Sub

        Private Sub cbGovtHDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGovtHDay.SelectedIndexChanged
            'Dim mCount As Integer
            'Dim dtRecord As New DataTable("Calender")
            'Dim mSQL As String

            'If cbGovtHDay.Items.Count > 0 Then
            '    lbGovtHDay.Items.Clear()

            '    mSQL = "SELECT CONVERT(VARCHAR(20), calDate, 101) As calDate, holidayId, ImplementedOn FROM offCalender WHERE holidayId = " + cbGovtHDay.Items(cbGovtHDay.SelectedIndex).ItemData.ToString + " And MONTH(calDate) = " + cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString + " And YEAR(calDate) = " + cbYear.Text.ToString + " ORDER BY calDate"
            '    Call LoadDataTable(mSQL, dtRecord)
            '    For mCount = 0 To dtRecord.Rows.Count - 1
            '        lbGovtHDay.Items.Add(New clsList(dtRecord.Rows(mCount).Item("calDate").ToString + ", " + cbGovtHDay.Text, dtRecord.Rows(mCount).Item("holidayId")))
            '        'MsgBox(dtRecord.Rows(mCount).Item("calDate").ToString + "---" + dtRecord.Rows(mCount).Item("holidayId").ToString)
            '    Next
            'End If
        End Sub

        Private Sub lbGovtHDay_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbGovtHDay.MouseDoubleClick
            'Dim mMatch As Integer

            'mMatch = lbGovtHDay.SelectedIndex    ' lbGovtHDay.FindString(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString + ", " + cbGovtHDay.Text)
            'If mMatch >= 0 Then
            '    lbGovtHDay.SelectedIndex = mMatch
            '    lbGovtHDay.Items.Remove(lbGovtHDay.SelectedItem)
            'Else
            '    If cbGovtHDay.SelectedIndex <> -1 Then
            '        lbGovtHDay.Items.Add(New clsList(Format(cbMonth.Items(cbMonth.SelectedIndex).ItemData, "00").ToString + "/" + Format(Convert.ToInt16(sender.text), "00").ToString + "/" + cbYear.Text.ToString + ", " + cbGovtHDay.Text, cbGovtHDay.Items(cbGovtHDay.SelectedIndex).ItemData))
            '    Else
            '        MsgBox("Please select Holiday Type from Holiday Type List.")
            '    End If
            'End If
        End Sub

        Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
            lbGovtHDay.Items.Clear()
            cbGovtHDay.SelectedIndex = 0
            Call cbMonth_SelectedIndexChanged(sender, e)
            btnGovtHoliday.Enabled = True
            btnDelete.Enabled = False
        End Sub

        Private Sub btnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNew.Click
            frmEntryHoliday.ShowDialog(Me)
        End Sub

        Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
            'Dim mDateCount As String
            Dim mSQL As String, mCalID As String
            'Dim dtLeaveDetail As New DataTable("LDetail")
            Dim msg As Integer

            msg = MsgBox("Do you want to really delete these data?", vbYesNo + vbQuestion, "Delete???")

            If msg = vbNo Then
                Exit Sub
            End If

            mCalID = ""
            If lbGovtHDay.Items.Count > 0 Then
                For i = 0 To lbGovtHDay.Items.Count - 1
                    mCalID = mCalID + "," + lbGovtHDay.Items(i).ItemData.ToString()
                Next
                mCalID = mCalID.Substring(1, mCalID.Length - 1)
            Else
                mCalID = "'" + lbGovtHDay.Items(0).ToString() + "'"
            End If

            mSQL = "DELETE offCalender WHERE ID IN(" + mCalID + ")"

            Call ExecuteSQLQuery(mSQL, "Delete")
            Call btnClear_Click(sender, e)
            btnGovtHoliday.Enabled = True
            btnDelete.Enabled = False
        End Sub
    End Class
End Namespace