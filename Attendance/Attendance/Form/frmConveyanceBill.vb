Imports System.Data.OleDb

Namespace Form
    Public Class frmConveyanceBill

        Dim mSelectedRow As Integer
        Dim rowClicked As Integer
        Dim bolCellChange As Boolean
        Dim bolDelete As Boolean

        Private Sub DisplayRecord(ByVal mFromDate As String, ByVal mToDate As String)
            Dim strSQL As String
            Dim mCount As Integer
            Dim dtComboList As New DataTable("Personal")

            Call CreateConnection()
            ' Fill the data grid viewer
            cmdOleDb = New OleDbCommand("SELECT EmpID, SubmissionDate, ConveyanceDate, FromPlace, ToPlace, Purpose, ModeOfTransport, Amount, ConvID FROM TMPConveyance WHERE EmpID = " & gUserID.ToString() & " And ConveyanceDate BETWEEN '" & mFromDate & "' And '" & mToDate & "' ORDER BY ConveyanceDate", gConEmp)
            gdadbConSTR = New OleDbDataAdapter(cmdOleDb)
            dsSTRDataSet = New DataSet()
            gdadbConSTR.Fill(dsSTRDataSet, "TMPConveyance")

            With dtgConveyance
                .Columns(0).DataPropertyName = "EmpID"
                .Columns(1).DataPropertyName = "SubmissionDate"
                .Columns(2).DataPropertyName = "ConveyanceDate"
                .Columns(3).DataPropertyName = "FromPlace"
                .Columns(4).DataPropertyName = "ToPlace"
                .Columns(5).DataPropertyName = "Purpose"
                .Columns(6).DataPropertyName = "ModeOfTransport"
                .Columns(7).DataPropertyName = "Amount"
                .Columns(8).DataPropertyName = "ConvID"
                .DataSource = dsSTRDataSet.Tables("TMPConveyance").DefaultView
                .Refresh()
            End With

            Try
                strSQL = "SELECT PID, Name, Designation FROM Personal WHERE empActive = 1 And PID = " & gUserID.ToString()
                Call LoadDataTable(strSQL, dtComboList)

                If dtComboList.Rows.Count > 0 Then
                    tbName.Text = dtComboList.Rows(mCount).Item("Name")
                    tbName.Tag = dtComboList.Rows(mCount).Item("PID")
                    tbDesignation.Text = dtComboList.Rows(mCount).Item("Designation")
                Else
                    tbName.Text = ""
                    tbName.Tag = ""
                    tbDesignation.Text = ""
                End If
            Catch exEmployee As Exception
                MessageBox.Show(exEmployee.Message, Me.Text)
            End Try
        End Sub

        Private Sub frmConveyanceBill_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 1.5
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            bolCellChange = False
            bolDelete = False

            Call DisplayRecord("", "")
        End Sub

        Private Sub frmConveyanceBill_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

                Dim row As DataGridViewRow = dtgConveyance.Rows(mSelectedRow)
                If row.IsNewRow = False Then
                    If IsDBNull(dtgConveyance.CurrentCell.Value) Then
                        dtConveyanceDate.Value = Date.Today.ToString("MM/dd/yyyy")
                    Else
                        dtConveyanceDate.Value = CDate(dtgConveyance.Item("ConveyanceDate", e.RowIndex).Value.ToString()).ToString("MM/dd/yyyy")
                    End If
                End If
                dtConveyanceDate.Visible = True
                dtConveyanceDate.Focus()
            Else
                dtConveyanceDate.Visible = False
            End If
        End Sub

        Private Sub dtgConveyance_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgConveyance.CellFormatting
            Dim cs As New System.Windows.Forms.DataGridViewCellStyle
            cs.BackColor = Color.Gainsboro
            dtgConveyance.AlternatingRowsDefaultCellStyle = cs
        End Sub

        Private Sub dtgConveyance_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConveyance.CellValueChanged
            'If e.ColumnIndex <> 2 Then
            bolCellChange = True
            'End If
        End Sub

        Private Sub dtgConveyance_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgConveyance.DefaultValuesNeeded
            e.Row.Cells("EmpID").Value = gUserID.ToString()
            e.Row.Cells("SubmissionDate").Value = Date.Today.ToString("MM/dd/yyyy")
            e.Row.Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
        End Sub

        Private Sub dtConveyanceDate_CloseUp(sender As Object, e As System.EventArgs) Handles dtConveyanceDate.CloseUp
            'Dim data As DataGridViewCellCancelEventArgs
            Dim row As DataGridViewRow = dtgConveyance.Rows(mSelectedRow)
            If row.IsNewRow = True Then
                dtgConveyance.Rows(row.Index).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            Else
                dtgConveyance.Rows(dtgConveyance.CurrentCell.RowIndex).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            End If
            dtConveyanceDate.Visible = False
            dtgConveyance.CurrentCell = dtgConveyance.Item("ConveyanceDate", row.Index)
        End Sub

        Private Sub dtConveyanceDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtConveyanceDate.ValueChanged
            'Dim data As DataGridViewCellCancelEventArgs
            Dim row As DataGridViewRow = dtgConveyance.Rows(mSelectedRow)
            If row.IsNewRow = True Then
                dtgConveyance.Rows(row.Index).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            Else
                dtgConveyance.Rows(dtgConveyance.CurrentCell.RowIndex).Cells("ConveyanceDate").Value = dtConveyanceDate.Value.ToString("MM/dd/yyyy")
            End If
            dtConveyanceDate.Visible = False
            dtgConveyance.CurrentCell = dtgConveyance.Item("ConveyanceDate", row.Index)
        End Sub

        Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
            Dim iMSG As Integer

            If dtgConveyance.Rows.Count = 1 Then
                MsgBox("Sorry! There is no record to delete.", MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            iMSG = MsgBox("Are you sure to save this information?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If iMSG = vbYes Then
                Call InsertUpdateDelete("Information save successfully.", "Save")
            Else
                Exit Sub
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
            rowClicked = dtgConveyance.HitTest(e.Location.X, e.Location.Y).RowIndex
            If e.Button = Windows.Forms.MouseButtons.Right Then
                mnsConveyance.Show(dtgConveyance, e.Location)
            End If
        End Sub

        Private Sub ValidateByRow(ByVal sender As Object, ByVal data As DataGridViewCellCancelEventArgs) Handles dtgConveyance.RowValidating
            Dim row As DataGridViewRow = dtgConveyance.Rows(data.RowIndex)

            If row.IsNewRow = True Then
                Exit Sub
            Else
                If bolDelete = False Then
                    Dim trackCell As DataGridViewCell = row.Cells(dtgConveyance.Columns("Amount").Index)
                    Dim dateCell As DataGridViewCell = row.Cells(dtgConveyance.Columns("ConveyanceDate").Index)
                    data.Cancel = Not (IsTrackGood(trackCell) AndAlso IsDateGood(dateCell))
                Else
                    bolDelete = False
                End If
            End If
        End Sub

        Private Sub cmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearch.Click
            Call DisplayRecord(dtFrom.Value.ToString("MM/dd/yyyy"), dtTo.Value.ToString("MM/dd/yyyy"))
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

            frmReportViewer.Show()
            frmReportViewer.Focus()
        End Sub

        Private Sub cmdDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelete.Click
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
                    bolDelete = True
                    dtgConveyance.Rows.Remove(dtgConveyance.Rows(rowClicked))

                    Dim row As DataGridViewRow = dtgConveyance.Rows(rowClicked)
                    If dtgConveyance.Item("ConvID", row.Index).Value <> Nothing Then
                        Call InsertUpdateDelete("Delete record successfully.", "Delete")
                    Else
                        MsgBox("Delete record successfully.", MsgBoxStyle.OkOnly, "Delete")
                        bolCellChange = False
                    End If
                End If
            End If
        End Sub

        Private Sub mnsDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnsDelete.Click
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
                    bolDelete = True
                    dtgConveyance.Rows.Remove(dtgConveyance.Rows(rowClicked))

                    Dim row As DataGridViewRow = dtgConveyance.Rows(rowClicked)
                    If Not IsDBNull(dtgConveyance.Item("ConvID", row.Index).Value) Then
                        Call InsertUpdateDelete("Delete record successfully.", "Delete")
                    Else
                        MsgBox("Delete record successfully.", MsgBoxStyle.OkOnly, "Delete")
                        bolCellChange = False
                    End If
                End If
            End If
        End Sub

        Private Sub InsertUpdateDelete(ByVal msg As String, ByVal strTitle As String)
            'Update records using a Command Builder
            'The variable i gives the number of records updated
            'Dim i As Integer
            gcbACS = New OleDbCommandBuilder(gdadbConSTR)
            Try
                'i = gdadbConSTR.Update(dsSTRDataSet, "TMPConveyance")
                gdadbConSTR.Update(dsSTRDataSet.Tables("TMPConveyance"))
                dsSTRDataSet.AcceptChanges()

                MsgBox(msg, vbOKOnly + vbInformation, strTitle)
                bolCellChange = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace