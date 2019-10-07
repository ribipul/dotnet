Namespace Form
    Public Class frmRetriveRecord
        Dim mPath As String, mPhysicalPath As String, mNetworkPath As String

        Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
            Me.Close()
        End Sub

        Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
            frmSelectPath.ShowDialog(Me)
        End Sub

        Private Sub cmdRetriveRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRetriveRecords.Click
            Dim i As Integer
            Dim dtRecord As New DataTable("Records")

            Dim mSQL As String
            Dim mFileCheck As String
            Dim mNetPath As String

            If Me.lblRetriveFrom.Text = "Retrive From" Then
                MsgBox("Please select the path.", vbInformation, Me.Text)
                frmSelectPath.ShowDialog(Me)
                Exit Sub
            Else
                mFileCheck = Me.lblRetriveFrom.Text
            End If
            mNetPath = Me.lblRetriveFrom.Text.Substring(mNetworkPath.Length, Len(mFileCheck) - (Len(mNetworkPath)))
            mNetPath = Replace(mNetPath, "\", "/")

            mSQL = "USP_LOAD_RECORDS '" & mPhysicalPath & mNetPath & "'"

            Call ExecuteSQLQuery(mSQL)

            mSQL = "SELECT SN+':'+CardNo+':'+AttnDate+':'+AttnTime+':'+CAST(Status As varchar(1)) As Records FROM TMPInformation ORDER BY SN"
            Call LoadDataTable(mSQL, dtRecord)
            Me.lbRecords.Items.Clear()

            If dtRecord.Rows.Count > 0 Then
                For i = 0 To dtRecord.Rows.Count - 1
                    Me.lbRecords.Items.Add(dtRecord.Rows(i).Item("Records"))
                Next
                Me.cmdRetriveRecords.Enabled = False
                Me.cmdTransferRecords.Enabled = True
            End If

            Me.lblRetriveRecords.Text = Format(Me.lbRecords.Items.Count, "00000")
        End Sub

        Private Sub frmRetriveRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strPath As String
            Dim dtLRecord As New DataTable("StoreLastRecord")
            Dim dtPath As New DataTable("Path")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            strPath = "SELECT TOP 1 Path, PhysicalPath, NetworkPath FROM Path"

            Call LoadDataTable(strPath, dtPath)
            If dtPath.Rows.Count > 0 Then
                mPath = dtPath.Rows(0).Item("Path")
                mPhysicalPath = dtPath.Rows(0).Item("PhysicalPath")
                mNetworkPath = dtPath.Rows(0).Item("NetworkPath")
                Me.lblRetriveFrom.Text = mNetworkPath + mPath
            End If

            strPath = "SELECT TOP 1 sDate, sRecord FROM StoreLastRecord ORDER BY sId DESC"

            Call LoadDataTable(strPath, dtLRecord)
            If dtLRecord.Rows.Count > 0 Then
                Me.lblLogDate.Text = FormatDateTime(dtLRecord.Rows(0).Item("sDate"), DateFormat.LongDate)
                Me.lblPreviousTransfered.Text = dtLRecord.Rows(0).Item("sRecord")
                Me.lblLastTransfered.Text = dtLRecord.Rows(0).Item("sRecord")
            End If
        End Sub

        Private Sub cmdTransferRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferRecords.Click
            Dim mSQL As String
            Dim dtRecord As New DataTable("RecordCount")

            mSQL = "USP_TRANSFER_RECORDS"
            Call ExecuteSQLQuery(mSQL)

            mSQL = "SELECT * FROM RecordCount"
            Call LoadDataTable(mSQL, dtRecord)

            lblTransferRecords.Text = dtRecord.Rows(0).Item("TotalRow")

            Me.lbRecords.Items.Clear()
            If Me.lbRecords.Items.Count = 0 Then
                Me.cmdRetriveRecords.Enabled = True
                Me.cmdTransferRecords.Enabled = False
            End If
        End Sub
    End Class
End NameSpace