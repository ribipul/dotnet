Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class mdiAttendance
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub


        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiAttendance))
            Me.MenuStrip = New System.Windows.Forms.MenuStrip()
            Me.mnuEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuRetriveRecords = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuRetriveRecords2 = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSelectPath = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuEmployee = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuPersonalAgriment = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuInformNotification = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuManualEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuComments = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuDepartment = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuLeaveCalender = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuLogOff = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuAdministration = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSecurity = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuAccessControl = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuChangePassword = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuSetup = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuBdjobsCalender = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuHolidayCalender = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSetHoliday = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSetEarnedLeave = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSetLeaveInfo = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuAttendanceDataExport = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuAttendanceReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuLeaveReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuHolidayList = New System.Windows.Forms.ToolStripMenuItem()
            Me.FormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuLeaveForm = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuCompensatoryLeaveApplication = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuSalaryAdvance = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuConveyanceBillForm = New System.Windows.Forms.ToolStripMenuItem()
            Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
            Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuHelpMenu = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuPolicy = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuLeavePolicyOfBdjobs = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuContents = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStrip = New System.Windows.Forms.ToolStrip()
            Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.PrintPreviewToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.StatusStrip = New System.Windows.Forms.StatusStrip()
            Me.sUserName = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.hpHelp = New System.Windows.Forms.HelpProvider()
            Me.MenuStrip.SuspendLayout()
            Me.ToolStrip.SuspendLayout()
            Me.StatusStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'MenuStrip
            '
            Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEntry, Me.mnuAdministration, Me.mnuReports, Me.FormToolStripMenuItem, Me.WindowsMenu, Me.mnuHelpMenu})
            Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
            Me.MenuStrip.Name = "MenuStrip"
            Me.MenuStrip.Size = New System.Drawing.Size(853, 24)
            Me.MenuStrip.TabIndex = 5
            Me.MenuStrip.Text = "MenuStrip"
            '
            'mnuEntry
            '
            Me.mnuEntry.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRetriveRecords, Me.mnuEmployee, Me.mnuPersonalAgriment, Me.mnuInformNotification, Me.mnuDepartment, Me.mnuLeaveCalender, Me.ToolStripSeparator5, Me.mnuLogOff, Me.mnuExit})
            Me.mnuEntry.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
            Me.mnuEntry.Name = "mnuEntry"
            Me.mnuEntry.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
            Me.mnuEntry.Size = New System.Drawing.Size(45, 20)
            Me.mnuEntry.Text = "&Entry"
            '
            'mnuRetriveRecords
            '
            Me.mnuRetriveRecords.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRetriveRecords2, Me.mnuSelectPath})
            Me.mnuRetriveRecords.Enabled = False
            Me.mnuRetriveRecords.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuRetriveRecords.Name = "mnuRetriveRecords"
            Me.mnuRetriveRecords.Size = New System.Drawing.Size(209, 22)
            Me.mnuRetriveRecords.Text = "&Retrive Records"
            '
            'mnuRetriveRecords2
            '
            Me.mnuRetriveRecords2.Enabled = False
            Me.mnuRetriveRecords2.Name = "mnuRetriveRecords2"
            Me.mnuRetriveRecords2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
            Me.mnuRetriveRecords2.Size = New System.Drawing.Size(187, 22)
            Me.mnuRetriveRecords2.Text = "R&etriveRecords"
            '
            'mnuSelectPath
            '
            Me.mnuSelectPath.Enabled = False
            Me.mnuSelectPath.Name = "mnuSelectPath"
            Me.mnuSelectPath.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
            Me.mnuSelectPath.Size = New System.Drawing.Size(187, 22)
            Me.mnuSelectPath.Text = "Select &Path"
            '
            'mnuEmployee
            '
            Me.mnuEmployee.Enabled = False
            Me.mnuEmployee.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuEmployee.Name = "mnuEmployee"
            Me.mnuEmployee.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
            Me.mnuEmployee.Size = New System.Drawing.Size(209, 22)
            Me.mnuEmployee.Text = "&Employee"
            '
            'mnuPersonalAgriment
            '
            Me.mnuPersonalAgriment.Enabled = False
            Me.mnuPersonalAgriment.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuPersonalAgriment.Name = "mnuPersonalAgriment"
            Me.mnuPersonalAgriment.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me.mnuPersonalAgriment.Size = New System.Drawing.Size(209, 22)
            Me.mnuPersonalAgriment.Text = "Personal &Agreement"
            '
            'mnuInformNotification
            '
            Me.mnuInformNotification.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManualEntry, Me.mnuComments})
            Me.mnuInformNotification.Enabled = False
            Me.mnuInformNotification.Name = "mnuInformNotification"
            Me.mnuInformNotification.Size = New System.Drawing.Size(209, 22)
            Me.mnuInformNotification.Text = "Inform &Notification"
            '
            'mnuManualEntry
            '
            Me.mnuManualEntry.Name = "mnuManualEntry"
            Me.mnuManualEntry.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
            Me.mnuManualEntry.Size = New System.Drawing.Size(173, 22)
            Me.mnuManualEntry.Text = "&Manual Entry"
            '
            'mnuComments
            '
            Me.mnuComments.Name = "mnuComments"
            Me.mnuComments.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
            Me.mnuComments.Size = New System.Drawing.Size(173, 22)
            Me.mnuComments.Text = "&Comments"
            '
            'mnuDepartment
            '
            Me.mnuDepartment.Enabled = False
            Me.mnuDepartment.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuDepartment.Name = "mnuDepartment"
            Me.mnuDepartment.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
            Me.mnuDepartment.Size = New System.Drawing.Size(209, 22)
            Me.mnuDepartment.Text = "&Department"
            '
            'mnuLeaveCalender
            '
            Me.mnuLeaveCalender.Enabled = False
            Me.mnuLeaveCalender.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuLeaveCalender.Name = "mnuLeaveCalender"
            Me.mnuLeaveCalender.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
            Me.mnuLeaveCalender.Size = New System.Drawing.Size(209, 22)
            Me.mnuLeaveCalender.Text = "&Leave Calender"
            '
            'ToolStripSeparator5
            '
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            Me.ToolStripSeparator5.Size = New System.Drawing.Size(206, 6)
            '
            'mnuLogOff
            '
            Me.mnuLogOff.Name = "mnuLogOff"
            Me.mnuLogOff.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
            Me.mnuLogOff.Size = New System.Drawing.Size(209, 22)
            Me.mnuLogOff.Text = "Lo&g Off"
            '
            'mnuExit
            '
            Me.mnuExit.Name = "mnuExit"
            Me.mnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
            Me.mnuExit.Size = New System.Drawing.Size(209, 22)
            Me.mnuExit.Text = "E&xit"
            '
            'mnuAdministration
            '
            Me.mnuAdministration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSecurity, Me.ToolStripSeparator3, Me.mnuSetup})
            Me.mnuAdministration.Name = "mnuAdministration"
            Me.mnuAdministration.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me.mnuAdministration.Size = New System.Drawing.Size(87, 20)
            Me.mnuAdministration.Text = "&Administration"
            '
            'mnuSecurity
            '
            Me.mnuSecurity.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAccessControl, Me.mnuChangePassword})
            Me.mnuSecurity.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuSecurity.Name = "mnuSecurity"
            Me.mnuSecurity.Size = New System.Drawing.Size(152, 22)
            Me.mnuSecurity.Text = "&Security"
            '
            'mnuAccessControl
            '
            Me.mnuAccessControl.Enabled = False
            Me.mnuAccessControl.Name = "mnuAccessControl"
            Me.mnuAccessControl.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me.mnuAccessControl.Size = New System.Drawing.Size(202, 22)
            Me.mnuAccessControl.Text = "&Access Control"
            '
            'mnuChangePassword
            '
            Me.mnuChangePassword.Name = "mnuChangePassword"
            Me.mnuChangePassword.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
            Me.mnuChangePassword.Size = New System.Drawing.Size(202, 22)
            Me.mnuChangePassword.Text = "Change Pass&word"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(149, 6)
            '
            'mnuSetup
            '
            Me.mnuSetup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBdjobsCalender, Me.mnuSetEarnedLeave, Me.mnuSetLeaveInfo, Me.mnuAttendanceDataExport})
            Me.mnuSetup.Name = "mnuSetup"
            Me.mnuSetup.Size = New System.Drawing.Size(152, 22)
            Me.mnuSetup.Text = "&Setup"
            '
            'mnuBdjobsCalender
            '
            Me.mnuBdjobsCalender.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHolidayCalender, Me.mnuSetHoliday})
            Me.mnuBdjobsCalender.Enabled = False
            Me.mnuBdjobsCalender.Name = "mnuBdjobsCalender"
            Me.mnuBdjobsCalender.Size = New System.Drawing.Size(197, 22)
            Me.mnuBdjobsCalender.Text = "&Bdjobs Calender"
            '
            'mnuHolidayCalender
            '
            Me.mnuHolidayCalender.Name = "mnuHolidayCalender"
            Me.mnuHolidayCalender.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
            Me.mnuHolidayCalender.Size = New System.Drawing.Size(194, 22)
            Me.mnuHolidayCalender.Text = "&Holiday Calender"
            '
            'mnuSetHoliday
            '
            Me.mnuSetHoliday.Name = "mnuSetHoliday"
            Me.mnuSetHoliday.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
            Me.mnuSetHoliday.Size = New System.Drawing.Size(194, 22)
            Me.mnuSetHoliday.Text = "Set &Holiday"
            '
            'mnuSetEarnedLeave
            '
            Me.mnuSetEarnedLeave.Enabled = False
            Me.mnuSetEarnedLeave.Name = "mnuSetEarnedLeave"
            Me.mnuSetEarnedLeave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
            Me.mnuSetEarnedLeave.Size = New System.Drawing.Size(197, 22)
            Me.mnuSetEarnedLeave.Text = "Set &Earned Leave"
            '
            'mnuSetLeaveInfo
            '
            Me.mnuSetLeaveInfo.Enabled = False
            Me.mnuSetLeaveInfo.Name = "mnuSetLeaveInfo"
            Me.mnuSetLeaveInfo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
            Me.mnuSetLeaveInfo.Size = New System.Drawing.Size(197, 22)
            Me.mnuSetLeaveInfo.Text = "Set Leave &Info"
            '
            'mnuAttendanceDataExport
            '
            Me.mnuAttendanceDataExport.Enabled = False
            Me.mnuAttendanceDataExport.Name = "mnuAttendanceDataExport"
            Me.mnuAttendanceDataExport.Size = New System.Drawing.Size(197, 22)
            Me.mnuAttendanceDataExport.Text = "Attendance Data Export"
            '
            'mnuReports
            '
            Me.mnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAttendanceReports, Me.ToolStripSeparator4, Me.mnuLeaveReports, Me.ToolStripSeparator6, Me.mnuHolidayList})
            Me.mnuReports.Name = "mnuReports"
            Me.mnuReports.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
            Me.mnuReports.Size = New System.Drawing.Size(57, 20)
            Me.mnuReports.Text = "&Reports"
            '
            'mnuAttendanceReports
            '
            Me.mnuAttendanceReports.Enabled = False
            Me.mnuAttendanceReports.Name = "mnuAttendanceReports"
            Me.mnuAttendanceReports.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me.mnuAttendanceReports.Size = New System.Drawing.Size(210, 22)
            Me.mnuAttendanceReports.Text = "&Attendance Reports"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(207, 6)
            '
            'mnuLeaveReports
            '
            Me.mnuLeaveReports.Enabled = False
            Me.mnuLeaveReports.Name = "mnuLeaveReports"
            Me.mnuLeaveReports.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
            Me.mnuLeaveReports.Size = New System.Drawing.Size(210, 22)
            Me.mnuLeaveReports.Text = "&Leave Reports"
            '
            'ToolStripSeparator6
            '
            Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
            Me.ToolStripSeparator6.Size = New System.Drawing.Size(207, 6)
            '
            'mnuHolidayList
            '
            Me.mnuHolidayList.Name = "mnuHolidayList"
            Me.mnuHolidayList.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
            Me.mnuHolidayList.Size = New System.Drawing.Size(210, 22)
            Me.mnuHolidayList.Text = "&Holiday List"
            '
            'FormToolStripMenuItem
            '
            Me.FormToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLeaveForm, Me.mnuCompensatoryLeaveApplication, Me.ToolStripSeparator7, Me.mnuSalaryAdvance, Me.ToolStripSeparator9, Me.mnuConveyanceBillForm})
            Me.FormToolStripMenuItem.Name = "FormToolStripMenuItem"
            Me.FormToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
            Me.FormToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
            Me.FormToolStripMenuItem.Text = "&Forms"
            '
            'mnuLeaveForm
            '
            Me.mnuLeaveForm.Name = "mnuLeaveForm"
            Me.mnuLeaveForm.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
            Me.mnuLeaveForm.Size = New System.Drawing.Size(300, 22)
            Me.mnuLeaveForm.Text = "&General Leave Application"
            '
            'mnuCompensatoryLeaveApplication
            '
            Me.mnuCompensatoryLeaveApplication.Name = "mnuCompensatoryLeaveApplication"
            Me.mnuCompensatoryLeaveApplication.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
            Me.mnuCompensatoryLeaveApplication.Size = New System.Drawing.Size(300, 22)
            Me.mnuCompensatoryLeaveApplication.Text = "&Compensatory Leave Application"
            '
            'ToolStripSeparator7
            '
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            Me.ToolStripSeparator7.Size = New System.Drawing.Size(297, 6)
            '
            'mnuSalaryAdvance
            '
            Me.mnuSalaryAdvance.Name = "mnuSalaryAdvance"
            Me.mnuSalaryAdvance.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me.mnuSalaryAdvance.Size = New System.Drawing.Size(300, 22)
            Me.mnuSalaryAdvance.Text = "&Salary Advance Application"
            '
            'ToolStripSeparator9
            '
            Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
            Me.ToolStripSeparator9.Size = New System.Drawing.Size(297, 6)
            '
            'mnuConveyanceBillForm
            '
            Me.mnuConveyanceBillForm.Name = "mnuConveyanceBillForm"
            Me.mnuConveyanceBillForm.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
            Me.mnuConveyanceBillForm.Size = New System.Drawing.Size(300, 22)
            Me.mnuConveyanceBillForm.Text = "Conveyance &Bill Form"
            '
            'WindowsMenu
            '
            Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
            Me.WindowsMenu.Name = "WindowsMenu"
            Me.WindowsMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
            Me.WindowsMenu.Size = New System.Drawing.Size(62, 20)
            Me.WindowsMenu.Text = "&Windows"
            '
            'CascadeToolStripMenuItem
            '
            Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
            Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
            Me.CascadeToolStripMenuItem.Text = "&Cascade"
            '
            'TileVerticalToolStripMenuItem
            '
            Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
            Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
            Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
            '
            'TileHorizontalToolStripMenuItem
            '
            Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
            Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
            Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
            '
            'CloseAllToolStripMenuItem
            '
            Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
            Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
            Me.CloseAllToolStripMenuItem.Text = "C&lose All"
            '
            'ArrangeIconsToolStripMenuItem
            '
            Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
            Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
            Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
            '
            'mnuHelpMenu
            '
            Me.mnuHelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPolicy, Me.ToolStripSeparator10, Me.mnuContents, Me.ToolStripSeparator8, Me.mnuAbout})
            Me.mnuHelpMenu.Name = "mnuHelpMenu"
            Me.mnuHelpMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
            Me.mnuHelpMenu.Size = New System.Drawing.Size(40, 20)
            Me.mnuHelpMenu.Text = "&Help"
            '
            'mnuPolicy
            '
            Me.mnuPolicy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLeavePolicyOfBdjobs})
            Me.mnuPolicy.Name = "mnuPolicy"
            Me.mnuPolicy.Size = New System.Drawing.Size(162, 22)
            Me.mnuPolicy.Text = "&Policy"
            '
            'mnuLeavePolicyOfBdjobs
            '
            Me.mnuLeavePolicyOfBdjobs.Name = "mnuLeavePolicyOfBdjobs"
            Me.mnuLeavePolicyOfBdjobs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
            Me.mnuLeavePolicyOfBdjobs.Size = New System.Drawing.Size(271, 22)
            Me.mnuLeavePolicyOfBdjobs.Text = "Leave Policy of Bdjobs.com"
            '
            'ToolStripSeparator10
            '
            Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
            Me.ToolStripSeparator10.Size = New System.Drawing.Size(159, 6)
            '
            'mnuContents
            '
            Me.mnuContents.Name = "mnuContents"
            Me.mnuContents.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
            Me.mnuContents.Size = New System.Drawing.Size(162, 22)
            Me.mnuContents.Text = "&Contents"
            '
            'ToolStripSeparator8
            '
            Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
            Me.ToolStripSeparator8.Size = New System.Drawing.Size(159, 6)
            '
            'mnuAbout
            '
            Me.mnuAbout.Name = "mnuAbout"
            Me.mnuAbout.Size = New System.Drawing.Size(162, 22)
            Me.mnuAbout.Text = "&About ..."
            '
            'ToolStrip
            '
            Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.PrintToolStripButton, Me.PrintPreviewToolStripButton, Me.ToolStripSeparator2, Me.HelpToolStripButton})
            Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
            Me.ToolStrip.Name = "ToolStrip"
            Me.ToolStrip.Size = New System.Drawing.Size(853, 25)
            Me.ToolStrip.TabIndex = 6
            Me.ToolStrip.Text = "ToolStrip"
            Me.ToolStrip.Visible = False
            '
            'NewToolStripButton
            '
            Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
            Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
            Me.NewToolStripButton.Name = "NewToolStripButton"
            Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.NewToolStripButton.Text = "New"
            '
            'OpenToolStripButton
            '
            Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
            Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
            Me.OpenToolStripButton.Name = "OpenToolStripButton"
            Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.OpenToolStripButton.Text = "Open"
            '
            'SaveToolStripButton
            '
            Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
            Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
            Me.SaveToolStripButton.Name = "SaveToolStripButton"
            Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.SaveToolStripButton.Text = "Save"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'PrintToolStripButton
            '
            Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
            Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
            Me.PrintToolStripButton.Name = "PrintToolStripButton"
            Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.PrintToolStripButton.Text = "Print"
            '
            'PrintPreviewToolStripButton
            '
            Me.PrintPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.PrintPreviewToolStripButton.Image = CType(resources.GetObject("PrintPreviewToolStripButton.Image"), System.Drawing.Image)
            Me.PrintPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
            Me.PrintPreviewToolStripButton.Name = "PrintPreviewToolStripButton"
            Me.PrintPreviewToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.PrintPreviewToolStripButton.Text = "Print Preview"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'HelpToolStripButton
            '
            Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
            Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
            Me.HelpToolStripButton.Name = "HelpToolStripButton"
            Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.HelpToolStripButton.Text = "Help"
            '
            'StatusStrip
            '
            Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sUserName})
            Me.StatusStrip.Location = New System.Drawing.Point(0, 466)
            Me.StatusStrip.Name = "StatusStrip"
            Me.StatusStrip.Size = New System.Drawing.Size(853, 22)
            Me.StatusStrip.TabIndex = 7
            Me.StatusStrip.Text = "StatusStrip"
            '
            'sUserName
            '
            Me.sUserName.Name = "sUserName"
            Me.sUserName.Size = New System.Drawing.Size(38, 17)
            Me.sUserName.Text = "Status"
            '
            'mdiAttendance
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(853, 488)
            Me.Controls.Add(Me.ToolStrip)
            Me.Controls.Add(Me.MenuStrip)
            Me.Controls.Add(Me.StatusStrip)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.IsMdiContainer = True
            Me.MainMenuStrip = Me.MenuStrip
            Me.Name = "mdiAttendance"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Access Control System"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.MenuStrip.ResumeLayout(False)
            Me.MenuStrip.PerformLayout()
            Me.ToolStrip.ResumeLayout(False)
            Me.ToolStrip.PerformLayout()
            Me.StatusStrip.ResumeLayout(False)
            Me.StatusStrip.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents mnuContents As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuHelpMenu As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents PrintPreviewToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents sUserName As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
        Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
        Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuLeaveCalender As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuDepartment As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuInformNotification As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuRetriveRecords As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuEntry As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuEmployee As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuPersonalAgriment As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
        Friend WithEvents mnuAdministration As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSecurity As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSetup As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuReports As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuAttendanceReports As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuLeaveReports As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuRetriveRecords2 As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSelectPath As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuManualEntry As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuComments As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuAccessControl As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuChangePassword As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuBdjobsCalender As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuHolidayCalender As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSetEarnedLeave As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSetLeaveInfo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuHolidayList As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuAttendanceDataExport As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents hpHelp As System.Windows.Forms.HelpProvider
        Friend WithEvents FormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuLeaveForm As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuLogOff As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSalaryAdvance As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSetHoliday As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuCompensatoryLeaveApplication As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuConveyanceBillForm As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuPolicy As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuLeavePolicyOfBdjobs As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator

    End Class
End NameSpace