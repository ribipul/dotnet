Namespace Form
    Public Class frmAltenateHoliday

        Private Sub frmAltenateHoliday_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer
            Dim dtRecord As New DataTable("Records")
            Dim mDay As Integer
            Dim strSQL As String

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            strSQL = "SELECT YEAR(calDate) AS HolidayDate FROM offCalender GROUP BY YEAR(calDate) ORDER BY YEAR(calDate)"
            Call LoadDataTable(strSQL, dtRecord)
            cbYear.Items.Clear()

            If dtRecord.Rows.Count > 0 Then
                For mCount = 0 To dtRecord.Rows.Count - 1
                    cbYear.Items.Add(New clsList(dtRecord.Rows(mCount).Item("HolidayDate"), mCount + 1))
                Next
                cbYear.SelectedIndex = cbYear.Items.Count - 1
            End If

            cbDayName.Items.Clear()

            For mDay = 0 To 7
                If mDay = 0 Then
                    cbDayName.Items.Add(New clsList("Select", mDay))
                Else
                    cbDayName.Items.Add(New clsList(WeekdayName(mDay).ToString(), mDay))
                End If
            Next
            cbDayName.SelectedIndex = 0

            strSQL = "SELECT * FROM FN_Alternate_Holiday_Group('Double')"
            Call LoadComboList(cbGroup, strSQL, "Alphabate", "EmpGroup", "ID", False)
        End Sub

        Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
            Close()
        End Sub

        Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
            Dim dtAHoliday As New DataTable("Holiday")
            Dim mAltHDay As String
            Dim m As Integer

            If cbGroup.SelectedIndex <= 0 Then
                MsgBox("Please select a group.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                cbGroup.Focus()
                Exit Sub
            End If
            If cbDayName.SelectedIndex <= 0 Then
                MsgBox("Please select a Day Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                cbDayName.Focus()
                Exit Sub
            End If

            m = MsgBox("Are you sure to set the Alternate Holiday of the year of " + cbYear.Text + "?", MsgBoxStyle.YesNo, Me.Text)
            If m = vbYes Then
                mAltHDay = "SELECT CalDate FROM offCalender WHERE YEAR(CalDate) = " + cbYear.Text + " And ImplementedOn <> 'ALL' And ImplementedOn IN(" & cbGroup.Items(cbGroup.SelectedIndex).ToString() & ") And HolidayID = (SELECT ID FROM Holiday WHERE holidayName = 'Alternate Holiday')"
                Call LoadDataTable(mAltHDay, dtAHoliday)
                If dtAHoliday.Rows.Count > 0 Then
                    m = MsgBox("There are already set the Alternate Holiday." + vbCrLf + "Do you want to update Alternate Holiday?", MsgBoxStyle.YesNo, Me.Text)
                    If m = vbYes Then
                        mAltHDay = "SET_ALTENATE_HOLIDAY_ANY_D_G " & cbYear.Text & ", " & cbGroup.Items(cbGroup.SelectedIndex).ItemData.ToString() & ", " & cbDayName.Items(cbDayName.SelectedIndex).ToString()
                        ExecuteSQLQuery(mAltHDay, "Update")
                    Else
                        Exit Sub
                    End If
                Else
                    mAltHDay = "SET_ALTENATE_HOLIDAY_ANY_D_G " & cbYear.Text & ", " & cbGroup.Items(cbGroup.SelectedIndex).ToString() & ", '" & cbDayName.Items(cbDayName.SelectedIndex).ToString() & "'"
                    ExecuteSQLQuery(mAltHDay, "Insert")
                End If
            End If
        End Sub
    End Class
End NameSpace