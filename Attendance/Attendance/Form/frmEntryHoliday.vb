Namespace Form
    Public Class frmEntryHoliday

        Dim mCount As Integer
        Dim mCurrent As Integer
        Dim mSuccess As String

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
            Call ControlStatus()
        End Sub

        Private Sub ControlStatus()
            If cmdNew.Text = "New" Then
                mnuAddNew.Enabled = False
                mnuCancel.Enabled = True
                mnuSave.Enabled = True
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False

                cmdInsert.Enabled = True
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False
                cmdNew.Text = "Cancel"

                tbHolidayName.Text = ""
                tbDescription.Text = ""
                lbHolodayList.SelectedIndex = -1
            Else
                mnuAddNew.Enabled = True
                mnuCancel.Enabled = False
                mnuSave.Enabled = False
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False

                cmdInsert.Enabled = False
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False
                cmdNew.Text = "New"
            End If
        End Sub

        Private Sub frmEntryHoliday_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            Call LoadListBox(lbHolodayList, "select Id, holidayName from Holiday order by holidayName asc", "Holiday", "holidayName", "Id")
            If lbHolodayList.Items.Count > 0 Then
                lbHolodayList.SelectedIndex = 0
            End If
        End Sub

        Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
            Call cmdNew_Click(sender, e)
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            Call cmdUpdate_Click(sender, e)
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

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Dim strSQL As String
            Dim m As Integer, mHolidayID As Integer

            If tbHolidayName.Text = "" Then
                'Validate Leave Name
                MsgBox("Please give Holiday Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                tbHolidayName.Focus()
                Exit Sub
            ElseIf tbDescription.Text = "" Then
                'Validate No of Leave Days
                MsgBox("Give the Holiday Description.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                tbDescription.Focus()
                Exit Sub
            End If

            m = MsgBox("Do you realy want to save this information" & vbCrLf & _
                       "Holiday Name: " & tbHolidayName.Text & vbCrLf & "Holiday Description: " & tbDescription.Text, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                mHolidayID = GetMaxID("SELECT (MAX(ID)+1) HolidayID FROM Holiday", "HolidayID")
                strSQL = "INSERT INTO Holiday(ID, holidayName, Description) " & _
                         "VALUES (" & mHolidayID & ", '" & tbHolidayName.Text & "', '" & tbDescription.Text & "')"

                mSuccess = ExecuteSQLQuery(strSQL, "Insert")
                If mSuccess = "" Then
                    lbHolodayList.Items.Add(New clsList(tbHolidayName.Text, mHolidayID))
                    lbHolodayList.SelectedIndex = lbHolodayList.Items.Count - 1
                End If
            End If
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Dim strSQL As String
            Dim m As Integer

            If lbHolodayList.SelectedIndex = -1 Then
                MsgBox("Please select Holiday from Holiday List for Update.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            m = MsgBox("Do you realy want to update this information" & vbCrLf & _
                       "Holiday Name: " & tbHolidayName.Text & vbCrLf & "Holiday Description: " & tbDescription.Text, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                strSQL = "UPDATE Holiday SET holidayName = '" & tbHolidayName.Text & "', Description = " & tbDescription.Text & "' WHERE ID = " & lbHolodayList.Items(lbHolodayList.SelectedIndex).ItemData.ToString

                ExecuteSQLQuery(strSQL, "Update")
            End If
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim strSQL As String
            Dim m As Integer
            Dim mMatch As Integer

            If lbHolodayList.SelectedIndex = -1 Then
                MsgBox("Please select Holiday from Holiday List for Delete.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            m = MsgBox("Do you realy want to Delete this information" & vbCrLf & _
                       "Holiday Name: " & tbHolidayName.Text & vbCrLf & "Holiday Description: " & tbDescription.Text, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                strSQL = "DELETE FROM Holiday WHERE ID = " & lbHolodayList.Items(lbHolodayList.SelectedIndex).ItemData.ToString

                mSuccess = ExecuteSQLQuery(strSQL, "Delete")

                If mSuccess = "" Then
                    mMatch = lbHolodayList.SelectedIndex
                    If mMatch >= 0 Then
                        lbHolodayList.SelectedIndex = mMatch
                        lbHolodayList.Items.Remove(lbHolodayList.SelectedItem)
                    End If
                End If
            End If

        End Sub

        Private Sub lbHolodayList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbHolodayList.SelectedIndexChanged
            Dim mCount As Integer
            Dim strSQL As String
            Dim dtHoliday As New DataTable("setLeave")

            If lbHolodayList.SelectedIndex <> -1 Then
                strSQL = "SELECT TOP 1 ID, HolidayName, Description FROM Holiday WHERE Id = " + lbHolodayList.Items(lbHolodayList.SelectedIndex).ItemData.ToString
                Call LoadDataTable(strSQL, dtHoliday)

                If dtHoliday.Rows.Count > 0 Then
                    tbHolidayName.Text = dtHoliday.Rows(mCount).Item("HolidayName")
                    tbDescription.Text = dtHoliday.Rows(mCount).Item("Description")

                    cmdUpdate.Enabled = True
                    cmdDelete.Enabled = True
                    cmdNew.Text = "New"
                    cmdInsert.Enabled = False

                    mnuEdit.Enabled = True
                    mnuDelete.Enabled = True
                    mnuAddNew.Enabled = True
                    mnuCancel.Enabled = False
                    mnuSave.Enabled = False
                End If
            End If
        End Sub

        Private Sub mnuMoveNext_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveNext.Click
            mCurrent = lbHolodayList.SelectedIndex
            If lbHolodayList.SelectedIndex <> -1 Then
                mCount = lbHolodayList.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbHolodayList.SelectedIndex = mCurrent + 1
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(sender As System.Object, e As System.EventArgs) Handles mnuMovePrevious.Click
            mCurrent = lbHolodayList.SelectedIndex
            If lbHolodayList.SelectedIndex <> -1 Then
                mCount = lbHolodayList.Items.Count - 1
                If (mCurrent - 1) < 0 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbHolodayList.SelectedIndex = mCurrent - 1
                End If
            End If
        End Sub

        Private Sub mnuMoveFirst_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveFirst.Click
            mCurrent = lbHolodayList.SelectedIndex
            If lbHolodayList.SelectedIndex <> -1 Then
                mCount = lbHolodayList.Items.Count - 1
                If (mCurrent - 1) < 0 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbHolodayList.SelectedIndex = 0
                End If
            End If
        End Sub

        Private Sub mnuMoveLast_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveLast.Click
            mCurrent = lbHolodayList.SelectedIndex
            If lbHolodayList.SelectedIndex <> -1 Then
                mCount = lbHolodayList.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    lbHolodayList.SelectedIndex = mCount
                End If
            End If
        End Sub
    End Class
End NameSpace