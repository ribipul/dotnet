Namespace Form
    Public Class frmHolidayList
        Dim mSQL As String

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub frmGovtHolidaySetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer
            Dim dtComboList As New DataTable("Group")

            If GroupBox1.Visible = True Then
                Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
                Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

                'With cbType
                '    .Items.Clear()
                '    .Items.Add(New clsList("General Holiday", 1))
                '    .Items.Add(New clsList("Group 'A' Holiday", 2))
                '    .Items.Add(New clsList("Group 'B' Holiday", 3))
                '    .SelectedIndex = -1 'Set first item as selected item.
                'End With

                Call LoadDataTable("SELECT * FROM FN_Alternate_Holiday_Group('Single')", dtComboList)
                cbType.Items.Clear()

                If dtComboList.Rows.Count > 0 Then
                    cbType.Items.Add(New clsList("General Holiday", 1))
                    For mCount = 1 To dtComboList.Rows.Count - 1
                        cbType.Items.Add(New clsList("Group '" & dtComboList.Rows(mCount).Item("EmpGroup") & "' Holiday", dtComboList.Rows(mCount).Item("ID")))
                    Next
                    For mCount = 1 To dtComboList.Rows.Count - 1
                        cbType.Items.Add(New clsList("Group '" & dtComboList.Rows(mCount).Item("EmpGroup") & "' Alternate Holiday", dtComboList.Rows(mCount).Item("ID")))
                    Next
                    cbType.SelectedIndex = 0
                Else
                    cbType.SelectedIndex = -1
                End If

                dtFromDate.Value = CDate("01/01/" & Date.Today.Year.ToString())       'GetFirstDayOfMonth(DateTime.Today)
                dtToDate.Value = CDate("12/31/" & Date.Today.Year.ToString())
            Else
                Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
                Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

                Call PopulateGrid("All")
            End If
        End Sub

        Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
            If cbType.SelectedIndex = -1 Then
                MsgBox("Please Select a Group.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                cbType.Focus()
                Exit Sub
            End If
            If cbType.Items(cbType.SelectedIndex).ItemData = 1 Then
                Call PopulateGrid("All")
            Else
                Call PopulateGrid(cbType.Items(cbType.SelectedIndex).ToString().Substring(7, 1))
            End If
        End Sub

        Private Sub PopulateGrid(ByVal mImplement As String)
            Dim dtComboList As New DataTable("Calendar")

            mSQL = ""

            If GroupBox1.Visible = True Then
                mSQL = ";WITH HolidayCal AS(" & vbCrLf
                'mSQL = mSQL & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "'" & vbCrLf
                'If mImplement = "All" Then
                '    mSQL = mSQL & " And C.ImplementedOn = '" + mImplement + "' And C.holidayId NOT IN(1,2)" & vbCrLf
                'Else
                '    mSQL = mSQL & " And C.ImplementedOn = 'All'" & vbCrLf
                '    mSQL = mSQL & vbCrLf & "UNION ALL" & vbCrLf
                '    mSQL = mSQL & vbCrLf & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' And C.ImplementedOn = '" + mImplement + "'" & vbCrLf
                'End If
                If cbType.Items(cbType.SelectedIndex).ToString().Substring(10, cbType.Items(cbType.SelectedIndex).ToString().Length - 10).ToString() <> "Alternate Holiday" Then
                    mSQL = mSQL & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "'" & vbCrLf
                End If
                If cbType.Items(cbType.SelectedIndex).ItemData = 1 Then
                    mSQL = mSQL & " And C.ImplementedOn = 'All' And C.holidayId NOT IN(1,2)" & vbCrLf
                Else
                    If cbType.Items(cbType.SelectedIndex).ToString().Substring(10, cbType.Items(cbType.SelectedIndex).ToString().Length - 10).ToString() = "Alternate Holiday" Then
                        'mSQL = mSQL & " And C.ImplementedOn = 'All'" & vbCrLf
                        'mSQL = mSQL & vbCrLf & "UNION ALL" & vbCrLf
                        mSQL = mSQL & vbCrLf & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' And C.ImplementedOn = '" + cbType.Items(cbType.SelectedIndex).ToString().Substring(7, 1) + "'" & vbCrLf
                    Else
                        mSQL = mSQL & " And C.ImplementedOn = 'All'" & vbCrLf
                        mSQL = mSQL & vbCrLf & "UNION ALL" & vbCrLf
                        mSQL = mSQL & vbCrLf & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' And C.ImplementedOn = '" + cbType.Items(cbType.SelectedIndex).ToString().Substring(7, 1) + "'" & vbCrLf
                    End If
                End If
            Else
                mSQL = ";WITH HolidayCal AS("
                mSQL = "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + "1/1/" + Year(DateAndTime.Today).ToString() + "' And '" + "12/31/" + Year(DateAndTime.Today).ToString() + "'" & vbCrLf
                mSQL = mSQL & " And C.ImplementedOn = '" + mImplement + "' And C.holidayId NOT IN(1,2)" & vbCrLf
            End If
            mSQL = mSQL & ")" & vbCrLf & "SELECT ROW_NUMBER() OVER(ORDER BY CalDate ASC) AS ID, * FROM HolidayCal" & vbCrLf
            mSQL = mSQL & " ORDER BY CalDate"

            Call LoadDataTable(mSQL, dtComboList)

            With dgvHoliday
                .Columns(0).DataPropertyName = "ID"
                .Columns(1).DataPropertyName = "calDate"
                .Columns(2).DataPropertyName = "HolidayName"
                .Columns(3).DataPropertyName = "ImplementedOn"
                .DataSource = dtComboList
                .Refresh()
            End With
        End Sub

        Private Sub dgvHoliday_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvHoliday.CellFormatting
            If dgvHoliday.Columns(e.ColumnIndex).Name = "CalDate" Then
                e.Value = CDate(e.Value).ToString("MMMM dd yyyy dddd")
            End If
            Dim cs As New System.Windows.Forms.DataGridViewCellStyle
            cs.BackColor = Color.Gainsboro
            dgvHoliday.AlternatingRowsDefaultCellStyle = cs
        End Sub

        Private Sub cmdPrintPreview_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintPreview.Click
            GReportType = "HolidayList"
            GstrRpt = ""

            mSQL = ";WITH HolidayCal AS(" & vbCrLf

            If cbType.Items(cbType.SelectedIndex).ToString().Substring(10, cbType.Items(cbType.SelectedIndex).ToString().Length - 10).ToString() <> "Alternate Holiday" Then
                mSQL = mSQL & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "'" & vbCrLf
            End If
            
            If cbType.Items(cbType.SelectedIndex).ItemData = 1 Then
                mSQL = mSQL & " And C.ImplementedOn = 'All' And C.holidayId NOT IN(1,2)" & vbCrLf
            Else
                If cbType.Items(cbType.SelectedIndex).ToString().Substring(10, cbType.Items(cbType.SelectedIndex).ToString().Length - 10).ToString() = "Alternate Holiday" Then
                    'mSQL = mSQL & " And C.ImplementedOn = 'All'" & vbCrLf
                    'mSQL = mSQL & vbCrLf & "UNION ALL" & vbCrLf
                    mSQL = mSQL & vbCrLf & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' And C.ImplementedOn = '" + cbType.Items(cbType.SelectedIndex).ToString().Substring(7, 1) + "'" & vbCrLf
                Else
                    mSQL = mSQL & " And C.ImplementedOn = 'All'" & vbCrLf
                    mSQL = mSQL & vbCrLf & "UNION ALL" & vbCrLf
                    mSQL = mSQL & vbCrLf & "SELECT CONVERT(VARCHAR(20), C.calDate, 101) As CalDate, H.HolidayName, C.ImplementedOn FROM offCalender As C, Holiday As H WHERE C.holidayId = H.Id And C.calDate BETWEEN '" + CDate(dtFromDate.Value.ToString("MM/dd/yyyy")) + "' And '" + CDate(dtToDate.Value.ToString("MM/dd/yyyy")) + "' And C.ImplementedOn = '" + cbType.Items(cbType.SelectedIndex).ToString().Substring(7, 1) + "'" & vbCrLf
                End If
            End If
            mSQL = mSQL & ")" & vbCrLf & "SELECT ROW_NUMBER() OVER(ORDER BY CalDate ASC) AS ID, * FROM HolidayCal" & vbCrLf
            mSQL = mSQL & " ORDER BY CalDate"

            GstrRpt = mSQL
            frmReportViewer.Show()
        End Sub
    End Class
End NameSpace