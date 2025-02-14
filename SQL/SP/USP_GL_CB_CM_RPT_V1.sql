-- =============================================
-- Author:		Bipul
-- Create date: January 08, 2014
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[USP_GL_CB_CM_RPT_V1]
(
	@StartDate1 varchar(11),
	@EndDate1 varchar(11),
	@LedgerID1 varchar(10),
	@CompID1 varchar(10)
)
AS
BEGIN
	DECLARE @DR_GL TABLE(
		Id int IDENTITY(2,1),
		Name2 varchar(200) NULL,
		M2 float NULL,
		DateS2 smalldatetime NULL
	)
	DECLARE @CR_GL TABLE(
		Id int IDENTITY(2,1),
		Name1 varchar(200) NULL,
		M1 float NULL,
		DateS1 smalldatetime NULL
	)	
	DECLARE	@GLCrRow int = 0,
			@GLDrRow int = 0,
			@TotalCr int = 0,
			@TotalDr int = 0,
			@Name3 varchar(100) = '',
			@Name2 varchar(100) = ''
			
	DECLARE 	@StartDate varchar(11),
				@EndDate varchar(11),
				@LedgerID varchar(10),
				@CompID varchar(10)
	
	SET @StartDate = @StartDate1
	SET @EndDate = @EndDate1
	SET @LedgerID = @LedgerID1	
	SET @CompID = @CompID1
	
	SET @Name2 = (SELECT sbname FROM Ledger WHERE id= @LedgerID)
	SET @Name3 = (SELECT Name FROM Company WHERE id = @CompID)
	
	SET NOCOUNT ON
--------------------------- Insert Debt ----------------------------------

	INSERT @DR_GL
	SELECT (CASE WHEN j.Notify = 'AR' THEN l.SBName+'('+@Name2+')' ELSE l.SBName END) AS Name2, j.Debt AS M2, j.jdate AS DateS 
	FROM Ledger l, Journal j, sales AS s 
	WHERE l.id = j.sid and s.TNO = j.TNO and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0 And s.cid = @CompID
	ORDER BY DateS, Name2

--------------------------- Insert Credit --------------------------------

	INSERT @CR_GL
	SELECT (CASE WHEN j.Notify = 'AR' THEN l.SBName+'('+@Name2+')' ELSE l.SBName END) AS Name1, j.Credit AS M1, j.jdate AS DateS 
	FROM Ledger l, Journal j, sales AS s  
	WHERE l.id = j.sid and s.TNO = j.TNO and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0 And s.cid = @CompID
	ORDER BY DateS , Name1

----------------------- Count Total Debt and Credit ----------------------

	SELECT @GLDrRow = COUNT(*) OVER() FROM @DR_GL
	SELECT @GLCrRow = COUNT(*) OVER() FROM @CR_GL

------------------------ Opening Balance of Debt ---------------------------
	;WITH TDR_CTE AS(	
		SELECT SUM(j.Debt) AS M2
		FROM ledger AS l, journal AS j, sales AS s 
		WHERE s.PCode = l.id and s.TNO = j.TNO and j.jdate < @StartDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0 And s.cid = @CompID
	)
--- Opening Sum of Debt
	SELECT @TotalDr = M2 FROM TDR_CTE

------------------------ Opening Balance of Credit -------------------------
	;WITH TCR_CTE AS(
		SELECT SUM(j.Credit) AS M1
		FROM ledger AS l, journal AS j, sales AS s 
		WHERE s.PCode = l.id and s.TNO = j.TNO and j.jdate < @StartDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0 And s.cid = @CompID
	)
--- Opening Sum of Credit
	SELECT @TotalCr = M1 FROM TCR_CTE

------------------------------ Final Output --------------------------------
	IF @GLDrRow >= @GLCrRow
		BEGIN
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
			UNION
			SELECT d.Id,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS1,d.DateS2 
			FROM @DR_GL d LEFT JOIN @CR_GL c ON d.Id = c.Id
		END
	ELSE
		BEGIN
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
			UNION
			SELECT c.Id,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS1,d.DateS2 
			FROM @CR_GL C LEFT JOIN @DR_GL D ON C.Id = D.Id
		END
	
	SET NOCOUNT OFF
END