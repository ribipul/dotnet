Imports System.Data.SqlClient
Imports System.Data.OleDb

Namespace Form
    Public Class frmConveyanceBill1
        Dim bolUpdate As Boolean
        Dim mSelectedRow As Integer
        Dim rowClicked As Integer
        Dim bolCellChange As Boolean

        Private Sub frmConveyanceBill1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            bolUpdate = False
            bolCellChange = False

            Call DisplayRecord("", "")
        End Sub

        Private Sub frmConveyanceBill1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            Dim mClose As Integer

            If bolCellChange = True Then
                ' Display a MsgBox asking the user to save changes or abort. 
                mClose = MessageBox.Show("Do you want to save changes the Information?", Me.Text, MessageBoxButtons.YesNoCancel)
                If mClose = DialogResult.Yes Then
                    ' Cancel the Closing event from closing the form.
                    Call cmdSave_Click(sender, e)
                    e.Cancel = False
                ElseIf mClose = DialogResult.No Then
                    e.Cancel = False
                    bolCellChange = False
                Else
                    e.Cancel = True
                End If ' Call method to save file...
            End If
        End Sub

        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
            Close()
        End Sub

        Private Sub cmdShow_Click(sender As System.Object, e As System.EventArgs) Handles cmdShow.Click
            If bolCellChange = True Then
                MessageBox.Show("Please save the change. Then see the Print Preview.", Me.Text, MessageBoxButtons.OK)
                Exit Sub
            End If
            GstrRpt = ""
            GReportType = "ConveyanceBill"

            GstrRpt = "SELECT * FROM V_ConveyanceBill WHERE EmpID = " & gUserID.ToString() & " And ConveyanceDate BETWEEN '" & dtFrom.Value.ToString("MM/dd/yyyy") & "' And '" & dtTo.Value.ToString("MM/dd/yyyy") & "'"

            'frmReportViewer.MdiParent = mdiAttendance
            frmReportViewer.Show()
            frmReportViewer.Focus()

            'frmBillMonth.ShowDialog(Me)
        End Sub

        Private Function ExecuteSQLQuery(ByVal SQLQuery As String)
            Try
                Call CreateConnection()

                gdadbConSTR = New OleDbDataAdapter(SQLQuery, gConEmp)
                gcbACS = New OleDbCommandBuilder(gdadbConSTR)
                gdtConSTR = New DataTable

                gdtConSTR.Reset() ' refresh 
                gdadbConSTR.Fill(gdtConSTR)
            Catch ex As Exception
                MsgBox("Error Message: " & ex.Message)
            End Try
        End Function

        Private Sub dtgConveyance_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConveyance.CellClick
            Dim objPoint As Point
            Dim objPoint1 As Point
            Dim objPoint2 As Point

            mSelectedRow = e.RowIndex
            If e.RowIndex = -1 Then
                dtConveyanceDate.Visible = False
                Exit Sub
            End If
            If e.ColumnIndex = 2 Then
                objPoint1 = dtgConveyance.Location
                objPoint2 = dtgConveyance.GetCellDisplayRectangle(2, dtgConveyance.CurrentCellAddress.Y, True).Location
                objPoint.X = objPoint1.X + objPoint2.X
                objPoint.Y = objPoint1.Y + objPoint2.Y
                dtConveyanceDate.Location = objPoint

                dtConveyanceDate.Size = dtgConveyance.CurrentCell.Size
                dtConveyanceDate.Visible = True
                If IsDBNull(dtgConveyance.CurrentCell.Value) Then
                    dtConveyanceDate.Value = Date.Today.ToString("MM/dd/yyyy")
                    dtConveyanceDate.Focus()
                Else
                    'dtConveyanceDate.Value = CDate(dtgConveyance.CurrentCell.Value).ToString("MM/dd/yyyy")
                    'dtConveyanceDate.Focus()
                End If
            Else
                dtConveyanceDate.Visible = False
            End If
        End Sub

        'Private Sub dtgConveyance_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgConveyance.CellFormatting
        '    If dtgConveyance.Columns(e.ColumnIndex).Name = "ConveyanceDate" Then
        '        e.Value = CDate(e.Value).ToString("dd/MM/yyyy")
        '    End If
        'End Sub

        Private Sub dtgConveyance_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConveyance.CellValueChanged
            bolCellChange = True
        End Sub

        Private Sub dtgConveyance_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgConveyance.DefaultValuesNeeded
            e.Row.Cells("EmpID").Value = gUserID.ToString()
            e.Row.Cells("SubmissionDate").Value = Date.Today.ToString("dd/MMM/yyyy")
            e.Row.Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("dd/MMM/yyyy")
        End Sub

        Private Sub DisplayRecord(ByVal mFromDate As String, ByVal mToDate As String)
            Dim strSQL As String
            Dim mCount As Integer
            Dim dtComboList As New DataTable("Personal")
            Dim dtTMPConveyance As New DataTable("TMPConveyance")

            Call LoadDataTable("SELECT EmpID, SubmissionDate, ConveyanceDate, FromPlace, ToPlace, Purpose, ModeOfTransport, Amount FROM TMPConveyance WHERE EmpID = " & gUserID.ToString() & " And ConveyanceDate BETWEEN '" & mFromDate & "' And '" & mToDate & "' ORDER BY ConveyanceDate", dtTMPConveyance)
            With dtgConveyance
                .Columns(0).DataPropertyName = "EmpID"
                .Columns(1).DataPropertyName = "SubmissionDate"
                .Columns(2).DataPropertyName = "ConveyanceDate"
                .Columns(3).DataPropertyName = "FromPlace"
                .Columns(4).DataPropertyName = "ToPlace"
                .Columns(5).DataPropertyName = "Purpose"
                .Columns(6).DataPropertyName = "ModeOfTransport"
                .Columns(7).DataPropertyName = "Amount"
                .DataSource = dtTMPConveyance
                .Refresh()
            End With

            Try
                'If mFromDate <> "" Then
                '    strSQL = "SELECT P.PID, P.Name, P.Designation, C.SubmissionDate FROM Personal P, TMPConveyance C WHERE P.PID = C.EmpID And P.empActive = 1 And P.PID = " & gUserID.ToString() & " And C.SubmissionDate = '" & mFromDate & "' GROUP BY P.PID, P.Name, P.Designation, C.SubmissionDate"
                'Else
                '    strSQL = "SELECT PID, Name, Designation FROM Personal WHERE empActive = 1 And PID = " & gUserID.ToString()
                'End If
                strSQL = "SELECT PID, Name, Designation FROM Personal WHERE empActive = 1 And PID = " & gUserID.ToString()
                Call LoadDataTable(strSQL, dtComboList)

                If dtComboList.Rows.Count > 0 Then
                    tbName.Text = dtComboList.Rows(mCount).Item("Name")
                    tbName.Tag = dtComboList.Rows(mCount).Item("PID")
                    tbDesignation.Text = dtComboList.Rows(mCount).Item("Designation")
                    'If mFromDate <> "" Then
                    '    dtSubmission.Value = dtComboList.Rows(mCount).Item("SubmissionDate")
                    'Else
                    '    dtSubmission.Value = Date.Today.ToString("dd/MMM/yyyy")
                    'End If
                Else
                    tbName.Text = ""
                    tbName.Tag = ""
                    tbDesignation.Text = ""
                End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try
            If dtTMPConveyance.Rows.Count > 0 Then
                bolUpdate = True
            Else
                bolUpdate = False
            End If
        End Sub

        Private Sub dtConveyance_CloseUp(sender As Object, e As System.EventArgs) Handles dtConveyanceDate.CloseUp
            'Dim data As DataGridViewCellCancelEventArgs
            Dim row As DataGridViewRow = dtgConveyance.Rows(mSelectedRow)
            If row.IsNewRow = True Then
                dtgConveyance.Rows(row.Index).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            Else
                dtgConveyance.Rows(dtgConveyance.CurrentCell.RowIndex).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            End If
        End Sub

        Private Sub dtConveyance_LostFocus(sender As Object, e As System.EventArgs) Handles dtConveyanceDate.LostFocus
            dtConveyanceDate.Visible = False
        End Sub

        Private Sub dtConveyance_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtConveyanceDate.ValueChanged
            'Dim data As DataGridViewCellCancelEventArgs
            Dim row As DataGridViewRow = dtgConveyance.Rows(mSelectedRow)
            If row.IsNewRow = True Then
                dtgConveyance.Rows(row.Index).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            Else
                dtgConveyance.Rows(dtgConveyance.CurrentCell.RowIndex).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            End If
        End Sub

        Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
            Dim dtConveyanceBill As New DataTable
            Dim TableName As String = "TMPConveyance"
            Dim strErrorMessage As String = ""
            Dim msg As String, iMSG As Integer

            'If bolUpdate = True Then
            '    Call ExecuteSQLQuery("DELETE TMPConveyance WHERE EmpID = " & gUserID.ToString() & " And SubmissionDate BETWEEN '" & dtFrom.Value.ToString("dd/MMM/yyyy") & "' And '" & dtTo.Value.ToString("dd/MMM/yyyy") & "'")
            'End If
            If dtgConveyance.Rows.Count = 1 Then
                MsgBox("Sorry! There is no data to save. Please enter data first.", MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            If bolUpdate = True Then
                msg = "Are you sure to update this data?"
            Else
                msg = "Are you sure to insert this data?"
            End If

            iMSG = MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If iMSG = vbNo Then
                Exit Sub
            Else
                If bolUpdate = True Then
                    Call ExecuteSQLQuery("DELETE TMPConveyance WHERE EmpID = " & gUserID.ToString() & " And ConveyanceDate BETWEEN '" & dtFrom.Value.ToString("dd/MMM/yyyy") & "' And '" & dtTo.Value.ToString("dd/MMM/yyyy") & "'")
                End If
            End If
            dtConveyanceBill = dtgConveyance.DataSource

            Try
                Call ConnectToDatabase()

                Try
                    'To Perform Bulk Copy for copy data from DataTable to SQL Table
                    If dtConveyanceBill.Rows.Count > 0 Then
                        Using Sqlbcp As SqlBulkCopy = New SqlBulkCopy(cnEmp)
                            Sqlbcp.DestinationTableName = "[dbo].[" & TableName & "]"
                            Sqlbcp.WriteToServer(dtConveyanceBill)
                        End Using
                    End If
                    If bolUpdate = True Then
                        msg = "Update data Successfully..."
                    Else
                        msg = "Insert data Successfully..."
                    End If
                    MsgBox(msg, MsgBoxStyle.OkOnly, Me.Text)
                Catch sqlEx As SqlException
                    strErrorMessage = "SqlException: " & sqlEx.Message & Environment.NewLine & "Error Code: " & sqlEx.ErrorCode
                Catch ex As Exception
                    strErrorMessage = ex.Message
                End Try
                MsgBox(strErrorMessage, MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            Catch ex As Exception
                strErrorMessage = "Open SQL connection failed" & ex.Message
                MsgBox(strErrorMessage, MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End Try
            bolUpdate = True
            bolCellChange = False
        End Sub

        Private Sub cmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearch.Click
            If bolCellChange = True Then
                MessageBox.Show("Please save the change. Then see the Print Preview.", Me.Text, MessageBoxButtons.OK)
                Exit Sub
            End If
            Call DisplayRecord(dtFrom.Value.ToString("MM/dd/yyyy"), dtTo.Value.ToString("MM/dd/yyyy"))
        End Sub

        Private Sub cmdDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelete.Click
            'Dim data As DataGridViewCellCancelEventArgs
            'Dim row As DataGridViewRow = dtgConveyance.Rows(mSelectedRow)
            Dim iMSG As Integer

            If dtgConveyance.Rows.Count = 1 Then
                MsgBox("Sorry! There is no record to delete.", MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            iMSG = MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If iMSG = vbNo Then
                Exit Sub
            Else
                If dtgConveyance.Rows(mSelectedRow).IsNewRow = True Then
                    Exit Sub
                Else
                    'Call ExecuteSQLQuery("DELETE TMPConveyance WHERE EmpID = " & gUserID.ToString() & " And ConveyanceDate BETWEEN '" & dtFrom.Value.ToString("dd/MMM/yyyy") & "' And '" & dtTo.Value.ToString("dd/MMM/yyyy") & "'")
                    dtgConveyance.Rows.Remove(dtgConveyance.Rows(mSelectedRow))
                    Call cmdSave_Click(sender, e)
                End If
            End If

        End Sub

        Private Function IsDateGood(ByRef cell As DataGridViewCell) As Boolean
            If cell.Value Is Nothing Then
                cell.ErrorText = "Missing date"
                dtgConveyance.Rows(cell.RowIndex).ErrorText = "Missing date"
                Return False
            Else
                Try
                    DateTime.Parse(cell.Value.ToString())
                Catch ex As FormatException
                    cell.ErrorText = "Invalid format"
                    dtgConveyance.Rows(cell.RowIndex).ErrorText = "Invalid format"
                    Return False
                End Try
            End If
            cell.ErrorText = ""
            dtgConveyance.Rows(cell.RowIndex).ErrorText = ""
            Return True
        End Function

        Private Function IsTrackGood(ByRef cell As DataGridViewCell) As Boolean
            If cell.Value.ToString().Length = 0 Then
                cell.ErrorText = "Please enter Amount"
                dtgConveyance.Rows(cell.RowIndex).ErrorText = "Please enter a track"
                Return False
            ElseIf cell.Value.ToString().Equals("0") Then
                cell.ErrorText = "Zero is not a valid Amount"
                dtgConveyance.Rows(cell.RowIndex).ErrorText = "Zero is not a valid Amount"
                Return False
            ElseIf Not Double.TryParse(cell.Value.ToString(), New Double()) Then
                cell.ErrorText = "Amount must be a number"
                dtgConveyance.Rows(cell.RowIndex).ErrorText = "Amount must be a number"
                Return False
            End If
            cell.ErrorText = ""
            dtgConveyance.Rows(cell.RowIndex).ErrorText = ""
            Return True
        End Function

        Private Sub dtgConveyance_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dtgConveyance.MouseClick
            If e.Button = Windows.Forms.MouseButtons.Right Then
                rowClicked = dtgConveyance.HitTest(e.Location.X, e.Location.Y).RowIndex
                mnsConveyance.Show(dtgConveyance, e.Location)
            End If
        End Sub

        Private Sub ValidateByRow(ByVal sender As Object, ByVal data As DataGridViewCellCancelEventArgs) Handles dtgConveyance.RowValidating
            Dim row As DataGridViewRow = dtgConveyance.Rows(data.RowIndex)

            If row.IsNewRow = True Then
                Exit Sub
            Else
                Dim trackCell As DataGridViewCell = row.Cells(dtgConveyance.Columns("Amount").Index)
                Dim dateCell As DataGridViewCell = row.Cells(dtgConveyance.Columns("ConveyanceDate").Index)
                data.Cancel = Not (IsTrackGood(trackCell) AndAlso IsDateGood(dateCell))
            End If
        End Sub

        Private Sub mnsDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnsDelete.Click
            'Dim row As DataGridViewRow = dtgConveyance.Rows(rowClicked)
            Dim iMSG As Integer

            If dtgConveyance.Rows.Count = 1 Then
                MsgBox("Sorry! There is no record to delete.", MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            iMSG = MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If iMSG = vbNo Then
                Exit Sub
            Else
                If dtgConveyance.Rows(rowClicked).IsNewRow = True Then
                    Exit Sub
                Else
                    'Call ExecuteSQLQuery("DELETE TMPConveyance WHERE EmpID = " & gUserID.ToString() & " And ConveyanceDate BETWEEN '" & dtFrom.Value.ToString("dd/MMM/yyyy") & "' And '" & dtTo.Value.ToString("dd/MMM/yyyy") & "'")
                    dtgConveyance.Rows.Remove(dtgConveyance.Rows(rowClicked))
                End If
            End If

            Call cmdSave_Click(sender, e)
        End Sub

        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            frmConveyanceBill.Show()
        End Sub
    End Class
End Namespace