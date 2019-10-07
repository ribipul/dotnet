Namespace Form

    Public Class frmSelectPath
        Dim mPath As String, mPhysicalPath As String, mNetworkPath As String

        'Private con As New OleDbConnection("Provider=SQLOLEDB;Data Source=BIPUL-PC;Initial Catalog=Attendance;Integrated Security='SSPI';")

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Me.Close()
        End Sub

        Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.InitialDirectory = mNetworkPath
            OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|Dat Files(*.dat)|*.dat|All Files (*.*)|*.*"
            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                txtFilePath.Text = OpenFileDialog.FileName
            End If
        End Sub

        Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
            Dim tmpPath As String
            Dim mResult As String
            Dim mSQL As String

            tmpPath = txtFilePath.Text
            mResult = tmpPath.Substring(mNetworkPath.Length, tmpPath.Length - mNetworkPath.Length)
            mSQL = "UPDATE Path SET path = '" & mResult & "' WHERE id = 1"
            ExecuteSQLQuery(mSQL, "Update")
            If frmRetriveRecord.Visible = True Then
                frmRetriveRecord.lblRetriveFrom.Text = Me.txtFilePath.Text
            End If
            mPath = mResult
            Me.Close()
        End Sub

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub frmSelectPath_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strPath As String
            Dim dtPath As New DataTable("Path")

            Me.Top = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2
            Me.Left = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2

            strPath = "SELECT TOP 1 Path, PhysicalPath, NetworkPath FROM Path"

            Call LoadDataTable(strPath, dtPath)
            If dtPath.Rows.Count > 0 Then
                mPath = dtPath.Rows(0).Item("Path")
                mPhysicalPath = dtPath.Rows(0).Item("PhysicalPath")
                mNetworkPath = dtPath.Rows(0).Item("NetworkPath")
                Me.txtFilePath.Text = mNetworkPath + mPath
            End If
        End Sub
    End Class
End NameSpace