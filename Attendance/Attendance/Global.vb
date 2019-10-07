Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Module [Global]

    Public gConEmp As OleDbConnection
    Public cnEmp As SqlConnection
    Public gdadbConSTR As OleDbDataAdapter
    Public gdaConSTR As SqlDataAdapter
    Public dsSTRDataSet As DataSet
    Public gcbACS As OleDbCommandBuilder
    Public drSQL As SqlDataReader
    Public cmdOleDb As OleDbCommand
    Public gcmdEmp As SqlCommand
    Public gdtConSTR As DataTable

    Public gsqlSTR As String
    Public gConSTR As String
    Public gSTRCon As String
    Public gUserName, gPassword As String, gUserFullName As String
    Public gUserID As Integer
    Public gEmpID As String
    Public GstrRpt As String
    Public GUserType As String
    Public GDepartmentID As Integer
    Public GReportType As String
    Public LogOff As String

    Private Const GServerName As String = "SERVER2"
    'Private Const GServerName As String = "ROUTER"
    'Private Const GServerName As String = "SERVERBDJ"

    Private objDateTime As New System.DateTime
    
    Public Function ExecuteSQLQuery(ByVal SQLQuery As String, Optional ByVal msgText As String = "") As String
        Dim strErr As String
        strErr = ""
        Try
            Call CreateConnection()

            gdadbConSTR = New OleDbDataAdapter(SQLQuery, gConEmp)
            gcbACS = New OleDbCommandBuilder(gdadbConSTR)
            gdtConSTR = New DataTable

            gdtConSTR.Reset() ' refresh 
            gdadbConSTR.Fill(gdtConSTR)
        Catch ex As Exception
            strErr = ex.Message
        Finally
            If strErr = "" Then
                If msgText = "Update" Then
                    MsgBox("Update data Successfully...", MsgBoxStyle.OkOnly, msgText)
                ElseIf msgText = "Insert" Then
                    MsgBox("Insert data Successfully...", MsgBoxStyle.OkOnly, msgText)
                ElseIf msgText = "Delete" Then
                    MsgBox("Delete data Successfully...", MsgBoxStyle.OkOnly, msgText)
                End If
            Else
                MsgBox("Error Description: " & strErr, MsgBoxStyle.OkOnly, "Error...")
            End If
        End Try
        Return strErr
    End Function

    Public Function LoadDataTable(ByVal strSQL As String, ByRef dtTable As DataTable) As Integer
        Call CreateConnection()
        Dim rsPath As OleDbDataAdapter

        Try
            Dim objCMD As OleDbCommand = New OleDbCommand(strSQL, gConEmp)
            objCMD.CommandTimeout = 120 '// set timeout to something more then 30 
            rsPath = New OleDbDataAdapter(objCMD)

            Return rsPath.Fill(dtTable)
        Catch exLoad As Exception
            MessageBox.Show(exLoad.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            rsPath.Dispose()
        End Try
    End Function
    Public Sub ConnectToDatabase()
        'gSTRCon = "Data Source=" & GServerName & ";Persist Security Info=True;Password=bdj_attendance_01;User ID=Attendance;Initial Catalog=Attendance"
        gSTRCon = "Data Source=" & GServerName & ";Persist Security Info=True;Password=bipul;User ID=rafique;Initial Catalog=Attendance"
        Try
            cnEmp = New SqlConnection
            With cnEmp
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = gSTRCon
                .Open()
            End With
        Catch ex As Exception
            MessageBox.Show("Error Connection to Database", "Err", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try
    End Sub

    Public Sub CreateConnection()
        gConEmp = New OleDbConnection
        'gConSTR = "Provider=SQLOLEDB;Data Source=" & GServerName & ";Persist Security Info=True;Password=bdj_attendance_01;User ID=Attendance;Initial Catalog=Attendance"
        'gConSTR = "Provider=SQLOLEDB;Data Source=" & GServerName & ";Persist Security Info=True;Password=rafique;User ID=bipul;Initial Catalog=Attendance"
        gConSTR = "Provider=SQLOLEDB;Data Source=" & GServerName & ";Persist Security Info=True;Password=bipul;User ID=rafique;Initial Catalog=Attendance"
        
        gConEmp.ConnectionString = gConSTR
        If gConEmp.State = ConnectionState.Open Then
            gConEmp.Close()
        End If
        gConEmp.Open()
    End Sub

    Public Function GetMaxID(ByVal SQLQuery As String, ByVal IDField As String) As Integer
        Dim drMaxID As SqlDataReader
        Dim cdMaxId As New SqlCommand

        Call ConnectToDatabase()

        With cdMaxId
            .Connection = cnEmp
            .CommandText = SQLQuery
        End With
        drMaxID = cdMaxId.ExecuteReader
        drMaxID.Read()
        Return drMaxID(IDField)
        drMaxID.Close()
    End Function

    Public Function GetCardNo(ByVal SQLQuery As String, ByVal IDField As String) As String
        Dim drMaxID As SqlDataReader
        Dim cdMaxId As New SqlCommand

        Call ConnectToDatabase()

        With cdMaxId
            .Connection = cnEmp
            .CommandText = SQLQuery
        End With
        drMaxID = cdMaxId.ExecuteReader
        drMaxID.Read()
        Return drMaxID(IDField)
        drMaxID.Close()
    End Function

    Public Sub FILLComboBox(ByVal sql As String, ByVal cb As ComboBox, Optional ByVal hlpString As String = "")
        Dim conn As OleDbConnection = New OleDbConnection(gConSTR)
        'cb.Items.Clear()
        Try
            conn.Open()
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader
            If hlpString <> "" Then
                cb.Items.Add("---Select One---")
            End If
            While rdr.Read
                'cb.Items = (rdr(0))
                cb.Items.Add(rdr(1).ToString)
            End While
            cb.SelectedIndex = 0
            rdr.Close()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub FillComboBox2(ByVal sqlSTR As String, ByVal cb As ComboBox, Optional ByVal hlpString As String = "")
        Dim dt As New DataTable
        Dim rsCombo As OleDbDataAdapter
        Dim i As Integer

        CreateConnection()
        rsCombo = New OleDbDataAdapter(sqlSTR, gConEmp)
        rsCombo.Fill(dt)

        cb.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cb.ValueMember = dt.Rows(i).Item(0)
            cb.Items.Add(dt.Rows(i).Item(1))
        Next
        rsCombo.Dispose()
    End Sub

    Public Sub FillListBox(ByVal lbBox As ListBox, ByVal sSQL As String)
        CreateConnection()
        lbBox.Items.Clear()
        Try
            Dim cmd As OleDbCommand = New OleDbCommand(sSQL, gConEmp)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader

            While rdr.Read
                'cb.Items = (rdr(0))
                lbBox.Items.Add(rdr(1).ToString)
            End While
            lbBox.SelectedIndex = 0
            rdr.Close()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            gConEmp.Close()
        End Try
    End Sub

    Public Function IsEmpty(ByVal mControl As Control) As Boolean
        If mControl.Text = "" Then
            IsEmpty = True
        Else
            IsEmpty = False
        End If
    End Function

    Public Sub StoreUserInfo(ByVal strUserName As String, ByVal strPassword As String, ByVal userId As Integer)
        gUserName = strUserName
        gPassword = strPassword
        gUserID = userId
    End Sub

    Public Sub LoadComboList(ByVal ctrlComboBox As ComboBox, ByVal strSQL As String, ByVal strTableName As String, ByVal strDisplay As String, ByVal strID As String, Optional ByVal bolAll As Boolean = vbFalse)
        Dim mCount As Integer
        Dim dtComboList As New DataTable(strTableName)

        Call LoadDataTable(strSQL, dtComboList)
        ctrlComboBox.Items.Clear()

        If dtComboList.Rows.Count > 0 Then
            If bolAll = True Then
                ctrlComboBox.Items.Add(New clsList("All", -1))
            ElseIf bolAll = False Then
                ctrlComboBox.Items.Add(New clsList("Select", -1))
            End If
            For mCount = 0 To dtComboList.Rows.Count - 1
                ctrlComboBox.Items.Add(New clsList(dtComboList.Rows(mCount).Item(strDisplay), dtComboList.Rows(mCount).Item(strID)))
            Next
            ctrlComboBox.SelectedIndex = 0
        Else
            ctrlComboBox.SelectedIndex = -1
        End If

    End Sub

    Public Sub LoadListBox(ByVal ctrlListBox As ListBox, ByVal strSQL As String, ByVal strTableName As String, ByVal strDisplay As String, ByVal strID As String)
        Dim mCount As Integer
        Dim dtComboList As New DataTable(strTableName)

        Call LoadDataTable(strSQL, dtComboList)
        ctrlListBox.Items.Clear()

        If dtComboList.Rows.Count > 0 Then
            For mCount = 0 To dtComboList.Rows.Count - 1
                ctrlListBox.Items.Add(New clsList(dtComboList.Rows(mCount).Item(strDisplay), dtComboList.Rows(mCount).Item(strID)))
            Next
        End If
        ctrlListBox.SelectedIndex = -1
    End Sub

    Public Function GetFirstDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtFrom As DateTime = dtDate
        dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1))
        Return dtFrom
    End Function

    Public Function GetLastDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtTo As New DateTime(dtDate.Year, dtDate.Month, 1)
        dtTo = dtTo.AddMonths(1)
        dtTo = dtTo.AddDays(-(dtTo.Day))
        Return dtTo
    End Function

    Public Sub TextBoxValidation(txtBox1 As TextBox, txtBox2 As TextBox, txtBox3 As TextBox, sender As Object, type As String)
        Try
            If txtBox1.Text = "" Then
                txtBox1.Text = "MM/DD/YYYY"
            Else
                If txtBox1.Text <> "MM/DD/YYYY" Then
                    objDateTime = DateTime.Parse(DirectCast(sender, System.Windows.Forms.TextBox).Text)
                    txtBox1.Text = objDateTime.ToString("MM/dd/yyyy")
                End If
            End If
        Catch ex As Exception
            MsgBox("Not valid date. Date Format: 'MM/DD/YYYY'")
            txtBox1.Focus()
            Exit Sub
        End Try
        If txtBox1.Text <> "MM/DD/YYYY" And txtBox2.Text <> "MM/DD/YYYY" Then
            If type = "From" Then
                txtBox3.Text = (DateDiff("d", txtBox1.Text, txtBox2.Text) + 1).ToString()
            Else
                txtBox3.Text = (DateDiff("d", txtBox2.Text, txtBox1.Text) + 1).ToString()
            End If
        Else
            txtBox3.Text = 0
        End If
    End Sub
End Module
