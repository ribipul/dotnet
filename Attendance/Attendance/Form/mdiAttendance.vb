Imports System.Windows.Forms

Namespace Form
    Public Class mdiAttendance
        Dim strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "ACSLM.chm")

        Private Sub mnuHolidayList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHolidayList.Click
            frmHolidayList.MdiParent = Me
            frmHolidayList.StartPosition = FormStartPosition.CenterParent
            frmHolidayList.Show()
        End Sub

        Private Sub mnuAccessControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAccessControl.Click
            frmAccessControl.MdiParent = Me
            frmAccessControl.Show()
        End Sub

        Private Sub mdiAttendance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            End
        End Sub

        Private Sub mdiAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer
            Dim dtUAccess As New DataTable("UserAccess")

            hpHelp.HelpNamespace = strHelpPath
            'Me.Text = Me.Text & " (" & gUserFullName & ")"
            sUserName.Text = gUserFullName

            Call LoadDataTable(gsqlSTR, dtUAccess)
            gsqlSTR = ""

            If dtUAccess.Rows.Count > 0 Then
                For mCount = 0 To dtUAccess.Rows.Count - 1
                    If dtUAccess.Rows(mCount).Item("modName") = "Retrieve Records" Then
                        mnuRetriveRecords.Enabled = True
                        mnuRetriveRecords2.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Employee Insert/Update" Then
                        mnuEmployee.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Select Path" Then
                        mnuRetriveRecords.Enabled = True
                        mnuSelectPath.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Inform Notification" Then
                        mnuInformNotification.Enabled = True
                        mnuManualEntry.Enabled = True
                        mnuComments.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Attendance Reports" Then
                        mnuAttendanceReports.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Access Control" Then
                        mnuAccessControl.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Bdjobs Calender" Then
                        mnuBdjobsCalender.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Attendance Data Export" Then
                        mnuAttendanceDataExport.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Earn Leave Triggering" Then
                        mnuSetEarnedLeave.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Leave Reports" Then
                        mnuLeaveReports.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Personal Agreement" Then
                        mnuPersonalAgriment.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Set Leave Info" Then
                        mnuSetLeaveInfo.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Holiday List" Then
                        mnuHolidayList.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Bdjobs Employee Calender" Then
                        mnuLeaveCalender.Enabled = True
                    ElseIf dtUAccess.Rows(mCount).Item("modName") = "Department" Then
                        mnuDepartment.Enabled = True
                    End If
                Next
            End If
        End Sub

        Private Sub mnuSelectPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectPath.Click
            frmSelectPath.Show(Me)
        End Sub

        Private Sub mnuEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmployee.Click
            frmEmployee.MdiParent = Me
            frmEmployee.StartPosition = FormStartPosition.CenterParent
            frmEmployee.Show()
        End Sub

        Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
            Me.mnuEmployee.PerformClick()
        End Sub

        Private Sub mnuDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepartment.Click
            frmDepartment.MdiParent = Me
            frmDepartment.StartPosition = FormStartPosition.CenterParent
            frmDepartment.Show()
        End Sub

        Private Sub mnuPersonalAgriment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPersonalAgriment.Click
            frmEmployeeAgreement.MdiParent = Me
            frmEmployeeAgreement.StartPosition = FormStartPosition.CenterParent
            frmEmployeeAgreement.Show()
        End Sub

        Private Sub mnuManualEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManualEntry.Click
            frmEmployeeAttendence.MdiParent = Me
            frmEmployeeAttendence.StartPosition = FormStartPosition.CenterParent
            frmEmployeeAttendence.Show()
        End Sub

        Private Sub mnuRetriveRecords2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRetriveRecords2.Click
            frmRetriveRecord.MdiParent = Me
            frmRetriveRecord.StartPosition = FormStartPosition.CenterParent
            frmRetriveRecord.Show()
        End Sub

        Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
            Me.LayoutMdi(MdiLayout.Cascade)
        End Sub

        Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticalToolStripMenuItem.Click
            Me.LayoutMdi(MdiLayout.TileVertical)
        End Sub

        Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontalToolStripMenuItem.Click
            Me.LayoutMdi(MdiLayout.TileHorizontal)
        End Sub

        Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
            ' Close all child forms of the parent.
            For Each ChildForm As System.Windows.Forms.Form In Me.MdiChildren
                ChildForm.Close()
            Next
        End Sub

        Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
            Me.LayoutMdi(MdiLayout.ArrangeIcons)
        End Sub

        Private Sub mnuHolidayCalender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHolidayCalender.Click
            frmBDJCalendar.MdiParent = Me
            frmBDJCalendar.StartPosition = FormStartPosition.CenterParent
            frmBDJCalendar.Show()
        End Sub

        Private Sub mnuLeaveCalender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeaveCalender.Click
            frmLeaveCalendar.MdiParent = Me
            frmLeaveCalendar.StartPosition = FormStartPosition.CenterParent
            frmLeaveCalendar.Show()
        End Sub

        Private Sub mnuComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComments.Click
            frmCommentsEntry.MdiParent = Me
            frmCommentsEntry.StartPosition = FormStartPosition.CenterParent
            frmCommentsEntry.Show()
        End Sub

        Private Sub mnuChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangePassword.Click
            frmChangePassword.MdiParent = Me
            frmChangePassword.StartPosition = FormStartPosition.CenterParent
            frmChangePassword.Show()
        End Sub

        Private Sub mnuSetLeaveInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetLeaveInfo.Click
            frmSetLeaveInformation.MdiParent = Me
            frmSetLeaveInformation.StartPosition = FormStartPosition.CenterParent
            frmSetLeaveInformation.Show()
        End Sub

        'Private Sub mnuEntryHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEntryHoliday.Click
        '    frmEntryHoliday.MdiParent = Me
        '    frmEntryHoliday.StartPosition = FormStartPosition.CenterParent
        '    frmEntryHoliday.Show()
        'End Sub

        Private Sub mnuAttendanceReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAttendanceReports.Click
            frmAttendanceReport.MdiParent = Me
            frmAttendanceReport.Show()
        End Sub

        Private Sub mnuLeaveReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeaveReports.Click
            frmLeaveReport.MdiParent = Me
            frmLeaveReport.StartPosition = FormStartPosition.CenterParent
            frmLeaveReport.Show()
        End Sub

        Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
            Me.Close()
        End Sub

        Private Sub mnuAttendanceDataExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuAttendanceDataExport.Click
            frmDataExport.MdiParent = Me
            frmDataExport.StartPosition = FormStartPosition.CenterParent
            frmDataExport.Show()
        End Sub

        Private Sub mnuAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuAbout.Click
            frmAboutBox.ShowDialog(Me)
        End Sub

        Private Sub mnuContents_Click(sender As System.Object, e As System.EventArgs) Handles mnuContents.Click
            Help.ShowHelp(Me, hpHelp.HelpNamespace, HelpNavigator.TableOfContents)
        End Sub

        Private Sub mnuLeaveForm_Click(sender As System.Object, e As System.EventArgs) Handles mnuLeaveForm.Click
            frmLeaveForm.MdiParent = Me
            frmLeaveForm.StartPosition = FormStartPosition.CenterParent
            frmLeaveForm.Show()
        End Sub

        Private Sub mnuLogOff_Click(sender As System.Object, e As System.EventArgs) Handles mnuLogOff.Click
            frmLogin.Show(Me)
            frmLogin.txtUsername.Text = ""
            frmLogin.txtPassword.Text = ""
            frmLogin.txtUsername.Focus()
            Me.Hide()
        End Sub

        Private Sub mnuSetHoliday_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetHoliday.Click
            frmEntryHoliday.MdiParent = Me
            frmEntryHoliday.StartPosition = FormStartPosition.CenterParent
            frmEntryHoliday.Show()
        End Sub

        Private Sub mnuSalaryAdvance_Click(sender As System.Object, e As System.EventArgs) Handles mnuSalaryAdvance.Click
            frmLoanForm.MdiParent = Me
            frmLoanForm.StartPosition = FormStartPosition.CenterParent
            frmLoanForm.Show()
        End Sub

        Private Sub mnuCompensatoryLeaveApplication_Click(sender As System.Object, e As System.EventArgs) Handles mnuCompensatoryLeaveApplication.Click
            frmCompensatoryLeave.MdiParent = Me
            frmCompensatoryLeave.StartPosition = FormStartPosition.CenterParent
            frmCompensatoryLeave.Show()
        End Sub

        Private Sub mnuConveyanceBillForm_Click(sender As System.Object, e As System.EventArgs) Handles mnuConveyanceBillForm.Click
            frmConveyanceBill.MdiParent = Me
            frmConveyanceBill.StartPosition = FormStartPosition.CenterParent
            frmConveyanceBill.Show()
        End Sub

        Private Sub mnuLeavePolicyOfBdjobs_Click(sender As System.Object, e As System.EventArgs) Handles mnuLeavePolicyOfBdjobs.Click
            System.Diagnostics.Process.Start("Leave-policy-bdjobs.pdf")
        End Sub
    End Class
End Namespace