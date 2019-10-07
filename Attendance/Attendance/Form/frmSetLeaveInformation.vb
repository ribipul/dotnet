Namespace Form
    Public Class frmSetLeaveInformation
        Dim mCurrent As Integer
        Dim mCount As Integer

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
            Call ControlStatus()
        End Sub

        Private Sub ControlStatus()
            dtActiveDate.Visible = False
            tbActiveDate.Visible = True

            If cmdNew.Text = "New" Then
                mnuAddNew.Enabled = False
                mnuCancel.Enabled = True
                mnuSave.Enabled = True
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False

                cmdInsert.Enabled = True
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False

                txtLeaveName.Visible = True
                cbLeaveName.Visible = False

                If cbLeaveName.Items.Count > 0 Then
                    cbLeaveName.SelectedIndex = 0
                End If

                tbActiveDate.Enabled = True
                txtSN.Text = ""
                txtLeaveName.Text = ""
                txtNODay.Text = ""
                dtActiveDate.Value = Date.Today

                txtNODay.Enabled = True
                dtActiveDate.Enabled = True
                cmdNew.Text = "Cancel"
            Else
                mnuAddNew.Enabled = True
                mnuCancel.Enabled = False
                mnuSave.Enabled = False
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False

                cmdInsert.Enabled = False
                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False

                tbActiveDate.Enabled = False
                txtLeaveName.Visible = False
                cbLeaveName.Visible = True

                txtNODay.Enabled = False
                dtActiveDate.Enabled = False
                cmdNew.Text = "New"
            End If
        End Sub

        Private Sub frmSetLeaveInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            Call LoadComboList(cbLeaveName, "SELECT ID, leaveType FROM leaveType", "leaveType", "leaveType", "ID")
        End Sub

        Private Sub cbLeaveName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLeaveName.SelectedIndexChanged
            Dim mCount As Integer
            Dim strSQL As String
            Dim dtLeaveType As New DataTable("leaveType")

            mCurrent = cbLeaveName.SelectedIndex

            If cbLeaveName.SelectedIndex > 0 Then
                strSQL = "SELECT ID, leaveType, Noofday, ActivateDate FROM leaveType WHERE ID = " + cbLeaveName.Items(cbLeaveName.SelectedIndex).ItemData.ToString
                Call LoadDataTable(strSQL, dtLeaveType)

                If dtLeaveType.Rows.Count > 0 Then
                    txtSN.Text = dtLeaveType.Rows(mCount).Item("ID")
                    txtLeaveName.Text = dtLeaveType.Rows(mCount).Item("leaveType")
                    txtNODay.Text = dtLeaveType.Rows(mCount).Item("Noofday")
                    If dtLeaveType.Rows(mCount).Item("ActivateDate").ToString() <> "" Then
                        dtActiveDate.Value = dtLeaveType.Rows(mCount).Item("ActivateDate")
                        dtActiveDate.Enabled = True
                        dtActiveDate.Visible = True
                        tbActiveDate.Visible = False
                    Else
                        dtActiveDate.Value = Date.Today
                        dtActiveDate.Visible = False
                        tbActiveDate.Visible = True
                        tbActiveDate.Enabled = True
                    End If

                    txtLeaveName.Visible = False
                    cbLeaveName.Visible = True

                    txtNODay.Enabled = True
                    dtActiveDate.Enabled = True

                    cmdUpdate.Enabled = True
                    cmdDelete.Enabled = True
                    cmdInsert.Enabled = False

                    mnuEdit.Enabled = True
                    mnuDelete.Enabled = True
                    mnuAddNew.Enabled = True
                    mnuCancel.Enabled = False
                    mnuSave.Enabled = False
                    
                    cmdNew.Text = "New"
                End If
            Else
                txtSN.Text = ""
                txtLeaveName.Text = ""
                txtNODay.Text = ""
                dtActiveDate.Value = Date.Today
                
                txtNODay.Enabled = False
                dtActiveDate.Enabled = False

                dtActiveDate.Visible = False
                tbActiveDate.Visible = True

                cmdUpdate.Enabled = False
                cmdDelete.Enabled = False
                cmdNew.Text = "New"
                cmdInsert.Enabled = False

                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
                mnuAddNew.Enabled = True
                mnuCancel.Enabled = False
                mnuSave.Enabled = False
            End If
        End Sub

        Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
            Dim strSQL As String
            Dim m As Integer

            If txtLeaveName.Text = "" Then
                'Validate Leave Name
                MsgBox("Please give Leave Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtLeaveName.Focus()
                Exit Sub
            ElseIf txtNODay.Text = "" Then
                'Validate No of Leave Days
                MsgBox("Give the No of Leave Days per Year.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNODay.Focus()
                Exit Sub
            End If

            m = MsgBox("Do you realy want to save this information" & vbCrLf & _
                       "Leave Type: " & txtLeaveName.Text & vbCrLf & "No of Days: " & txtNODay.Text & vbCrLf & _
                       "Active Date: " & dtActiveDate.Value & vbCrLf, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                strSQL = "INSERT INTO leaveType(leaveType, Noofday, ActivateDate) " & _
                         "VALUES ( '" & txtLeaveName.Text & "', " & txtNODay.Text & ", '" & CDate(dtActiveDate.Value.ToString("MM/dd/yyyy")) & "')"

                ExecuteSQLQuery(strSQL, "Insert")
                Call ControlStatus()
                Call LoadComboList(cbLeaveName, "SELECT ID, leaveType FROM leaveType", "leaveType", "leaveType", "ID")
            End If
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Dim strSQL As String
            Dim m As Integer

            m = MsgBox("Do you realy want to update this information" & vbCrLf & _
                       "Leave Name: " & txtLeaveName.Text & vbCrLf & "No of Days: " & txtNODay.Text & vbCrLf & _
                       "Active Date: " & dtActiveDate.Value & vbCrLf, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                strSQL = "UPDATE leaveType SET leaveType = '" & cbLeaveName.Text & "', Noofday = " & txtNODay.Text & ", ActivateDate = '" & CDate(dtActiveDate.Value.ToString("MM/dd/yyyy")) & "' WHERE sn = " & txtSN.Text

                ExecuteSQLQuery(strSQL, "Update")
            End If
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim strSQL As String
            Dim m As Integer

            m = MsgBox("Do you realy want to delete this information" & vbCrLf & _
                       "Leave Name: " & txtLeaveName.Text & vbCrLf & "No of Days: " & txtNODay.Text & vbCrLf & _
                       "Active Date: " & dtActiveDate.Value & vbCrLf, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If m = vbYes Then
                strSQL = "DELETE FROM leaveType WHERE ID = " & txtSN.Text

                ExecuteSQLQuery(strSQL, "Delete")

                Call LoadComboList(cbLeaveName, "SELECT ID, leaveType FROM leaveType", "leaveType", "leaveType", "ID")
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

        Private Sub mnuMoveLast_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveLast.Click
            mCurrent = cbLeaveName.SelectedIndex
            If cbLeaveName.SelectedIndex <> -1 Then
                mCount = cbLeaveName.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbLeaveName.SelectedIndex = mCount
                End If
            End If
        End Sub

        Private Sub mnuMoveNext_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveNext.Click
            mCurrent = cbLeaveName.SelectedIndex
            If cbLeaveName.SelectedIndex <> -1 Then
                mCount = cbLeaveName.Items.Count - 1
                If (mCurrent + 1) > mCount Then
                    MsgBox("You are End of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbLeaveName.SelectedIndex = mCurrent + 1
                End If
            End If
        End Sub

        Private Sub mnuMovePrevious_Click(sender As System.Object, e As System.EventArgs) Handles mnuMovePrevious.Click
            mCurrent = cbLeaveName.SelectedIndex
            If cbLeaveName.SelectedIndex <> -1 Then
                mCount = cbLeaveName.Items.Count - 1
                If (mCurrent - 1) < 1 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbLeaveName.SelectedIndex = mCurrent - 1
                End If
            End If
        End Sub

        Private Sub mnuMoveFirst_Click(sender As System.Object, e As System.EventArgs) Handles mnuMoveFirst.Click
            mCurrent = cbLeaveName.SelectedIndex
            If cbLeaveName.SelectedIndex <> -1 Then
                mCount = cbLeaveName.Items.Count - 1
                If (mCurrent - 1) < 1 Then
                    MsgBox("You are Begining of the File", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Else
                    cbLeaveName.SelectedIndex = 1
                End If
            End If
        End Sub

        Private Sub tbActiveDate_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbActiveDate.MouseClick
            dtActiveDate.Visible = True
            tbActiveDate.Visible = False
        End Sub
    End Class
End NameSpace