Namespace Form
    Public Class frmReportViewer
        Dim mRptInOutDetail As New rptInOutDetail
        Dim mRptAttendanceDetail As New rptAttendanceDetail
        Dim mRptAttendanceSummary As New rptAttendanceSummary

        Dim mRptLeaveDetail As New rptLeaveDetail
        Dim mRptLeaveSummary As New rptLeaveSummary
        Dim mRptLeaveApplication As New rptLeaveApplication
        Dim mRptLoanApplication As New rptLoanApplication
        Dim mRptCompensatoryLeave As New rptCompensatoryLeave
        Dim mRptConveyanceBill As New rptConveyanceBill
        Dim mRptHolidayList As New rptHolidayList


        Private Sub frmReportViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim dtReport As New DataTable("Information")

            Call LoadDataTable(GstrRpt, dtReport)
            If GReportType = "Attendance" Then
                If frmAttendanceReport.rdoInOutDetail.Checked = True Then
                    mRptInOutDetail.SetDataSource(dtReport)
                    mRptInOutDetail.SummaryInfo.ReportTitle = Format(frmAttendanceReport.dtFromDate.Value, "MMMM d, yyyy").ToString() + " To " + Format(frmAttendanceReport.dtToDate.Value, "MMMM d, yyyy")
                    crvReport.ReportSource = mRptInOutDetail
                ElseIf frmAttendanceReport.rdoAttendanceDetail.Checked = True Then
                    mRptAttendanceDetail.SetDataSource(dtReport)
                    mRptAttendanceDetail.SummaryInfo.ReportTitle = Format(frmAttendanceReport.dtFromDate.Value, "MMMM d, yyyy").ToString() + " To " + Format(frmAttendanceReport.dtToDate.Value, "MMMM d, yyyy")
                    crvReport.ReportSource = mRptAttendanceDetail
                Else
                    mRptAttendanceSummary.SetDataSource(dtReport)
                    mRptAttendanceSummary.Section3.SectionFormat.EnableSuppress = True
                    mRptAttendanceSummary.SummaryInfo.ReportTitle = Format(frmAttendanceReport.dtFromDate.Value, "MMMM d, yyyy").ToString() + " To " + Format(frmAttendanceReport.dtToDate.Value, "MMMM d, yyyy")
                    crvReport.ReportSource = mRptAttendanceSummary
                End If
            ElseIf GReportType = "Leave" Then
                If frmLeaveReport.rdoLeaveSummary.Checked = True Then
                    mRptLeaveSummary.SetDataSource(dtReport)
                    mRptLeaveSummary.SummaryInfo.ReportTitle = "REPORTS OF YEAR " + frmLeaveReport.cbSummaryYear.Text
                    crvReport.ReportSource = mRptLeaveSummary
                ElseIf frmLeaveReport.rdoLeaveDetail.Checked = True Then
                    mRptLeaveDetail.SetDataSource(dtReport)
                    mRptLeaveDetail.SummaryInfo.ReportTitle = Format(frmLeaveReport.dtFromDate.Value, "MMMM d, yyyy").ToString() + " To " + Format(frmLeaveReport.dtToDate.Value, "MMMM d, yyyy")
                    crvReport.ReportSource = mRptLeaveDetail
                End If
            ElseIf GReportType = "LeaveApplication" Then
                mRptLeaveApplication.SetDataSource(dtReport)
                crvReport.ReportSource = mRptLeaveApplication
            ElseIf GReportType = "LoanApplication" Then
                mRptLoanApplication.SetDataSource(dtReport)
                crvReport.ReportSource = mRptLoanApplication
            ElseIf GReportType = "CompensatoryLeave" Then
                mRptCompensatoryLeave.SetDataSource(dtReport)
                crvReport.ReportSource = mRptCompensatoryLeave
            ElseIf GReportType = "ConveyanceBill" Then
                mRptConveyanceBill.SetDataSource(dtReport)
                crvReport.ReportSource = mRptConveyanceBill
            ElseIf GReportType = "HolidayList" Then
                mRptHolidayList.SetDataSource(dtReport)
                mRptHolidayList.SummaryInfo.ReportTitle = frmHolidayList.cbType.Items(frmHolidayList.cbType.SelectedIndex).ToString()
                crvReport.ReportSource = mRptHolidayList
            End If

            If GReportType = "Attendance" Or GReportType = "Leave" Then
                If frmAttendanceReport.lbEmployee.SelectedItems.Count > 1 Or frmLeaveReport.lbEmployee.SelectedItems.Count > 1 Then
                    crvReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                Else
                    crvReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                End If
            ElseIf GReportType = "LeaveApplication" Or GReportType = "LoanApplication" Or GReportType = "CompensatoryLeave" Or GReportType = "ConveyanceBill" Or GReportType = "HolidayList" Then
                crvReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            End If

            crvReport.Zoom(100)
            crvReport.Show()

            dtReport.Dispose()
            Me.WindowState = FormWindowState.Maximized
        End Sub
    End Class
End NameSpace