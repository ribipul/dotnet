DECLARE @StartDate smalldatetime,
		@EndDate smalldatetime,
		@EmpID int
		
SET @StartDate = '3/19/2010'
SET @EndDate = '3/19/2013'
SET @EmpID = 96

SELECT sn, id, edate, CONVERT(nvarchar(30), etime, 108) AS ETime, status, record, manualEntry 
FROM Information
WHERE manualEntry = 1 AND id = @EmpId And edate BETWEEN @StartDate And @EndDate

