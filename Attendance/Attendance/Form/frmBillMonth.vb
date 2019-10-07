Namespace Form
    Public Class frmBillMonth

        Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
            GstrRpt = ""
            GReportType = "ConveyanceBill"

            GstrRpt = "SELECT * FROM V_ConveyanceBill WHERE EmpID = " & gUserID.ToString() & " And Month(ConveyanceDate) = " & cbMonth.Items(cbMonth.SelectedIndex).ItemData.ToString() & " And Year(ConveyanceDate) = " & cbYear.Items(cbYear.SelectedIndex).ItemData.ToString()

            'frmReportViewer.MdiParent = mdiAttendance
            frmReportViewer.Show()
            frmReportViewer.Focus()
            Close()
        End Sub

        Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
            Close()
        End Sub

        Private Sub frmBillMonth_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim mCount As Integer

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            cbYear.Items.Clear()
            For mCount = 2000 To Date.Today.Year
                cbYear.Items.Add(New clsList(mCount, mCount))
            Next
            cbYear.SelectedIndex = cbYear.Items.Count - 1

            Call LoadMontName()
        End Sub

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
                .SelectedIndex = Date.Today.Month - 1 'Set first item as selected item.
            End With
        End Sub
    End Class
End NameSpace