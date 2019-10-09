/*

SELECT AttendanceDate, EmployeeName, EmployeeGroup, InTime, Late, OutTime, TotalWork, AtOffice, OfficeStartHour, WorkingHour, OutOfficeVisit, Comments, Purpose, OverTime, OutOffice, TotalWorkingDay, IndividualWorkingDay 
FROM FN_AttendanceCTE('9/1/2014', '9/29/2014', 135)

*/


--select * from Personal
--where Name like '%rumman%'

DECLARE	@StartDate varchar(20) = '9/1/2014',
		@EndDate varchar(20) = '9/29/2014',
		@EmployeeID int = 135

DECLARE	@Attendance	TABLE(
	Att_Id int PRIMARY KEY IDENTITY,
	AttendanceDate smalldatetime null,
	EmployeeName varchar(50) null,
	EmployeeGroup varchar(2) null,
	InTime varchar(50) null,
	Late varchar(50) null,
	OutTime varchar(50) null,
	TotalWork varchar(50) null,
	AtOffice VARCHAR(50) null,
	OfficeStartHour varchar(15) null,
	WorkingHour int null,
	OutOfficeVisit float null,
	Comments varchar(5000) null,
	Purpose varchar(1000) null,
	TotalWorkingDay int null,
	IndividualWorkingDay int null,
	OutOffice varchar(50) null,
	OverTime varchar(50) null
)

;WITH ATTEND_CTE AS (
	SELECT I.EDate As AttendanceDate, p.Name, p.empGroup, '00:00:00.0000000' As InTime, '00:00:00.0000000' As OutTime,
	NULL As TotalWork, NULL As AtOffice,
	(SELECT TOP 1 PD.StartHour FROM PersonalAgreement PD, Information AS i WHERE PD.EID = i.ID AND i.id = @EmployeeID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As OfficeStartHour, 
	(SELECT TOP 1 PD.Workhour FROM PersonalAgreement PD, Information AS i WHERE PD.EID=i.ID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As WorkingHour,
	IsNull(C.Duration, NULL) As OutOfficeVisit,
	(CASE WHEN (C.Comments IS not null and H.holidayName IS not null) THEN (C.Comments + ', ' + H.HolidayName) ELSE (case when H.HolidayName IS null then C.Comments else H.HolidayName end) END) As Comments, C.Purpose
	FROM Information As I Inner Join Personal p on p.pId=i.id LEFT JOIN Comments As C ON I.ID = C.cId And I.edate = C.attDate 
	LEFT JOIN (offCalender AS OC INNER JOIN Holiday AS H ON OC.HolidayID = H.ID) ON I.edate = OC.calDate 
	And (OC.ImplementedOn = (SELECT empGroup FROM Personal WHERE pId = @EmployeeID) OR OC.ImplementedOn = 'All')
	WHERE I.ID = @EmployeeID AND I.EDate BETWEEN @StartDate and @EndDate 
	GROUP BY p.Name, p.empGroup,I.EDate, C.Comments, C.Purpose, H.HolidayName, C.Duration
	UNION All
	SELECT LD.LeaveDate, P.Name, P.empGroup, '00:00:00.0000000' As InTime, '00:00:00.0000000' As OutTime, NULL As TotalWork, NULL As AtOffice,
	(SELECT TOP 1 PD.StartHour FROM PersonalAgreement PD, Information AS i WHERE PD.EID = i.ID AND i.id = @EmployeeID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As OfficeStartHour,
	(SELECT TOP 1 PD.Workhour FROM PersonalAgreement PD, Information AS i WHERE PD.EID=i.ID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As WorkingHour, 
	NULL As OutOfficeVisit,
	(CASE WHEN (LR.Comments IS not null and H.holidayName IS not null) THEN (LR.Comments + ', ' + H.HolidayName) ELSE (case when H.HolidayName IS null then LR.Comments else H.HolidayName end) END) As Comments,
	NULL As Purpose
	FROM ((LeaveReason AS LR INNER JOIN LeaveDetails AS LD ON LR.LeaveID = LD.LeaveID) INNER JOIN Personal AS P ON LR.EId = P.pId) Left Join Information I on I.Edate = LD.LeaveDate and I.id=LR.EId
	LEFT JOIN (offCalender AS OC INNER JOIN Holiday AS H ON OC.HolidayID = H.ID AND OC.ImplementedOn = (SELECT empGroup FROM Personal WHERE pId = @EmployeeID)) ON LD.LeaveDate = OC.calDate
	WHERE LR.EID = @EmployeeID AND I.Sn is null AND LD.LeaveDate BETWEEN @StartDate and @EndDate
	)
	INSERT @Attendance (AttendanceDate, EmployeeName, EmployeeGroup, InTime, OutTime, TotalWork, AtOffice, OfficeStartHour, WorkingHour, OutOfficeVisit, Comments, Purpose)
	SELECT * FROM ATTEND_CTE
	--OPTION (MaxRecursion 10000)
	
----------------------- Delete Duplicate Attendance Date From Temporary Attendance Table ---------------------
/*
	;WITH Duplicates AS 
	(
	SELECT
		 AttendanceDate, ROW_NUMBER() OVER(PARTITION BY AttendanceDate ORDER BY AttendanceDate DESC) AS DuplicateID
	FROM @Attendance
	)
	DELETE Duplicates
	WHERE DuplicateID > 1
	
--------------------------------- Insert Weekly Holiday ------------------------------------------------

	;WITH WKLYHDAY_IN_CTE AS (
	SELECT OC.calDate As WeeklyHoliday, (SELECT Name FROM Personal WHERE pId = @EmployeeID) As EmployeeName,
	(SELECT empGroup FROM Personal WHERE pId = @EmployeeID) As EmployeeGroup, '' As InTime, '' As OutTime, 
	(SELECT TOP 1 PD.Workhour FROM PersonalAgreement PD, Information AS i WHERE PD.EID=i.ID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As WorkingHour,
	H.HolidayName, (SELECT TOP 1 PD.StartHour FROM PersonalAgreement PD, Information AS i WHERE PD.EID = i.ID AND i.id = @EmployeeID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As OfficeStartHour 
	FROM (offCalender AS OC INNER JOIN Holiday AS H ON OC.HolidayID = H.ID) 
	LEFT JOIN @Attendance AS A ON OC.calDate = A.AttendanceDate
	WHERE OC.calDate BETWEEN @StartDate and @EndDate And ImplementedOn = 'ALL' AND A.AttendanceDate IS NULL AND
	HolidayID = (SELECT ID FROM Holiday WHERE holidayName = 'Weekly Holiday')
	)
	INSERT @Attendance (AttendanceDate, EmployeeName, EmployeeGroup, InTime, OutTime, WorkingHour, Comments, OfficeStartHour)
	SELECT * FROM WKLYHDAY_IN_CTE
	--OPTION (MaxRecursion 1000)
	
---------------------------------- Insert Alternate Holiday --------------------------------------------

	;WITH ALTERHDAY_CTE AS (
	SELECT OC.calDate As WeeklyHoliday, (SELECT Name FROM Personal WHERE pId = @EmployeeID) As EmployeeName,
	(SELECT empGroup FROM Personal WHERE pId = @EmployeeID) As EmployeeGroup, '' As InTime, '' As OutTime, 
	(SELECT TOP 1 PD.Workhour FROM PersonalAgreement PD, Information AS i WHERE PD.EID=i.ID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As WorkingHour,
	H.HolidayName, (SELECT TOP 1 PD.StartHour FROM PersonalAgreement PD, Information AS i WHERE PD.EID = i.ID AND i.id = @EmployeeID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As OfficeStartHour 
	FROM (offCalender AS OC INNER JOIN Holiday AS H ON OC.HolidayID = H.ID) 
	LEFT JOIN @Attendance AS A ON OC.calDate = A.AttendanceDate 
	WHERE OC.HolidayID = H.ID And OC.calDate BETWEEN @StartDate and @EndDate And ImplementedOn = (SELECT empGroup FROM Personal WHERE pId = @EmployeeID) AND 
	HolidayID = (SELECT ID FROM Holiday WHERE holidayName = 'Alternate Holiday') AND A.AttendanceDate IS NULL 
	)
	INSERT @Attendance (AttendanceDate, EmployeeName, EmployeeGroup, InTime, OutTime, WorkingHour, Comments, OfficeStartHour)
	SELECT * FROM ALTERHDAY_CTE
	--OPTION (MaxRecursion 1000)

---------------------------------- Update With Government Holiday -------------------------------------------
		
	;WITH UGOVTHDAY_CTE AS (
	SELECT OC.calDate As WeeklyHoliday, (SELECT Name FROM Personal WHERE pId = @EmployeeID) As EmployeeName,
	(SELECT empGroup FROM Personal WHERE pId = @EmployeeID) As EmployeeGroup, '' As InTime, '' As OutTime, 
	(SELECT TOP 1 PD.Workhour FROM PersonalAgreement PD, Information AS i WHERE PD.EID=i.ID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As WorkingHour,
	H.HolidayName, (SELECT TOP 1 PD.StartHour FROM PersonalAgreement PD, Information AS i WHERE PD.EID = i.ID AND i.id = @EmployeeID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As OfficeStartHour 
	FROM (offCalender AS OC INNER JOIN Holiday AS H ON OC.HolidayID = H.ID) 
	INNER JOIN @Attendance AS A ON OC.calDate = A.AttendanceDate 
	WHERE OC.HolidayID = H.ID And OC.calDate BETWEEN @StartDate and @EndDate --And ImplementedOn = 'ALL' 
	AND HolidayID IN (SELECT ID FROM Holiday WHERE holidayName NOT IN ('Special Holiday', 'Weekly Holiday', 'Alternate Holiday')) 
	--AND A.AttendanceDate IS NULL
	)
	UPDATE A
			SET 
			A.Comments = A.Comments + ', ' + UA.HolidayName
	FROM @Attendance As A INNER JOIN UGOVTHDAY_CTE As UA ON A.AttendanceDate = UA.WeeklyHoliday
	WHERE A.AttendanceDate = UA.WeeklyHoliday
	
---------------------------------- Insert Government Holiday -------------------------------------------
	
	;WITH GOVTHDAY_CTE AS (
	SELECT OC.calDate As WeeklyHoliday, (SELECT Name FROM Personal WHERE pId = @EmployeeID) As EmployeeName,
	(SELECT empGroup FROM Personal WHERE pId = @EmployeeID) As EmployeeGroup, '' As InTime, '' As OutTime, 
	(SELECT TOP 1 PD.Workhour FROM PersonalAgreement PD, Information AS i WHERE PD.EID=i.ID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As WorkingHour,
	H.HolidayName, (SELECT TOP 1 PD.StartHour FROM PersonalAgreement PD, Information AS i WHERE PD.EID = i.ID AND i.id = @EmployeeID AND PD.SDate <= EDate ORDER BY PD.SDate DESC) As OfficeStartHour 
	FROM (offCalender AS OC INNER JOIN Holiday AS H ON OC.HolidayID = H.ID) 
	LEFT JOIN @Attendance AS A ON OC.calDate = A.AttendanceDate 
	WHERE OC.HolidayID = H.ID And OC.calDate BETWEEN @StartDate and @EndDate And ImplementedOn = 'ALL' 
	AND HolidayID IN (SELECT ID FROM Holiday WHERE holidayName NOT IN ('Special Holiday', 'Weekly Holiday', 'Alternate Holiday')) 
	AND A.AttendanceDate IS NULL
	)
	INSERT @Attendance (AttendanceDate, EmployeeName, EmployeeGroup, InTime, OutTime, WorkingHour, Comments, OfficeStartHour)
	SELECT * FROM GOVTHDAY_CTE
	--OPTION (MaxRecursion 1000)
	
---------------------------------------- Insert Absent Date --------------------------------------------
	;WITH CTE AS (
	SELECT CAST(@StartDate As smalldatetime) AS FromDate
	UNION ALL
	SELECT DATEADD(day, 1 ,cte.FromDate) AS FromDate
	FROM cte
	WHERE DATEADD(day,1,cte.FromDate) <= CAST(@EndDate As smalldatetime)
	)
	INSERT @Attendance(AttendanceDate, EmployeeName, EmployeeGroup, InTime, Late, OutTime, TotalWork, AtOffice, OfficeStartHour, WorkingHour, OutOfficeVisit, Comments, Purpose)
	SELECT c.FromDate, (SELECT TOP(1) EmployeeName FROM @Attendance) As EmployeeName, (SELECT TOP(1) EmployeeGroup FROM @Attendance) As EmployeeGroup, '', '', '', '', '', (SELECT TOP(1) OfficeStartHour FROM @Attendance) As OfficeStartHour, (SELECT TOP(1) WorkingHour FROM @Attendance) As WorkingHour, '', 'Absent', ''
	FROM CTE c LEFT JOIN @Attendance a ON c.FromDate = a.AttendanceDate And a.AttendanceDate BETWEEN CAST(@StartDate As smalldatetime) AND CAST(@EndDate As smalldatetime)
	WHERE a.AttendanceDate IS NULL
	OPTION (MaxRecursion 10000)

--------------------------------------- Insert Total Working Day ---------------------------------------

	;WITH TWDC_CTE AS (
	SELECT COUNT(DISTINCT WorkingDay) As TWorkingDay, CAST((CAST(MONTH(WorkingDay) As varchar(2)) + '/1/' + CAST(YEAR(WorkingDay) As varchar(4))) As DATE) As WorkingMonth
	FROM TotalWorkingDay WHERE WorkingDay BETWEEN @StartDate And @EndDate
	GROUP BY MONTH(WorkingDay), YEAR(WorkingDay)
	)
	UPDATE A
	SET A.TotalWorkingDay = UA.TWorkingDay
	FROM @Attendance As A INNER JOIN TWDC_CTE As UA ON MONTH(A.AttendanceDate) = MONTH(UA.WorkingMonth)
	
	
	;WITH INOUTTIME_CTE AS (
	SELECT AttnDate, MIN(InTime) As InTime, MAX(OutTime) As OutTime, (CAST((SUM(CAST(TotalStayTime As int)))/60 as varchar) + '.' + REPLICATE('0', 2 - Len(((SUM(CAST(TotalStayTime As int)))%60)*100/60)) + cast (((SUM(CAST(TotalStayTime As int)))%60)*100/60 as varchar)) As AtOffice
	FROM FN_ARRIVAL_DEPARTURE (@StartDate, @EndDate, @EmployeeID) 
	WHERE AttnDate BETWEEN @StartDate And @EndDate
	GROUP BY AttnDate
	)
	UPDATE A
			SET 
			A.InTime = UA.InTime,
			A.OutTime = UA.OutTime,
			A.Late = IsNull(CAST((DATEDIFF(MINUTE, LEFT(A.OfficeStartHour, 8), LEFT(UA.InTime, 8))/60) as varchar) + '.' + REPLICATE('0', 2 - Len(((CAST(DATEDIFF(MINUTE, LEFT(A.OfficeStartHour, 8), LEFT(UA.InTime, 8)) As int))%60)*100/60)) + CAST(((CAST(DATEDIFF(MINUTE, LEFT(A.OfficeStartHour, 8), LEFT(UA.InTime, 8)) As int)%60)*100/60) as varchar), NULL),
			A.AtOffice = CASE ISNUMERIC(UA.AtOffice) WHEN 1 THEN CAST(UA.AtOffice AS float) ELSE 0.00 END,
			A.TotalWork = (CASE ISNUMERIC(UA.AtOffice) WHEN 1 THEN CAST(UA.AtOffice AS float) ELSE 0.00 END) + (CASE ISNUMERIC(A.OutOfficeVisit) WHEN 1 THEN CAST(A.OutOfficeVisit AS float) ELSE 0 END),
			A.OverTime = (((CASE ISNUMERIC(UA.AtOffice) WHEN 1 THEN CAST(UA.AtOffice AS float) ELSE 0.00 END) + (CASE ISNUMERIC(A.OutOfficeVisit) WHEN 1 THEN CAST(A.OutOfficeVisit AS float) ELSE 0 END)) - 8.00),
			A.OutOffice = (CAST(DATEDIFF(MINUTE, LEFT(UA.InTime, 8), LEFT(UA.OutTime, 8))/60 as varchar) + '.' + REPLICATE('0', 2 - Len(((CAST(DATEDIFF(MINUTE, LEFT(UA.InTime, 8), LEFT(UA.OutTime, 8)) As int))%60)*100/60)) + CAST(((CAST(DATEDIFF(MINUTE, LEFT(UA.InTime, 8), LEFT(UA.OutTime, 8)) As int)%60)*100/60) as varchar))
	FROM @Attendance As A INNER JOIN INOUTTIME_CTE As UA ON A.AttendanceDate = UA.AttnDate

----------------------------------- Insert Individual Working Day --------------------------------------

	;WITH TIWDC_CTE AS (
	SELECT (SELECT Name FROM Personal WHERE pId = @EmployeeID) As EmpName, COUNT(DISTINCT A.WorkingDay) As IndividualWorkingDay, CAST((CAST(MONTH(A.WorkingDay) As varchar(2)) + '/1/' + CAST(YEAR(A.WorkingDay) As varchar(4))) As DATE) As WorkingMonth
	FROM TotalWorkingDay AS A LEFT JOIN 
	(SELECT DISTINCT LD.LeaveDate AS LeaveDate 
	FROM LeaveDetails AS LD, LeaveReason AS LR 
	WHERE LD.LeaveID = LR.LeaveID And LR.eId = @EmployeeID AND LD.LeaveDate BETWEEN @StartDate And @EndDate 
	UNION ALL
	SELECT CalDate AS LeaveDate FROM OffCalender 
	WHERE CalDate BETWEEN @StartDate And @EndDate 
	AND ImplementedOn = (SELECT empGroup FROM Personal WHERE pId = @EmployeeID)) AS B ON A.WorkingDay=B.LeaveDate 
	WHERE B.LeaveDate Is Null AND A.WorkingDay BETWEEN @StartDate And @EndDate
	GROUP BY MONTH(A.WorkingDay), YEAR(A.WorkingDay)
	)
	UPDATE A
	SET A.IndividualWorkingDay = UA.IndividualWorkingDay
	FROM @Attendance As A INNER JOIN TIWDC_CTE As UA ON MONTH(A.AttendanceDate) = MONTH(UA.WorkingMonth)
	WHERE A.EmployeeName = UA.EmpName
		
	UPDATE @Attendance SET Late = '' WHERE Comments = 'Alternate Holiday' OR Comments = 'Weekly Holiday'
*/

SELECT * FROM @Attendance
ORDER BY AttendanceDate ASC

