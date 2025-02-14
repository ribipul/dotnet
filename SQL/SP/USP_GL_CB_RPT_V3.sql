CREATE PROCEDURE [dbo].[USP_GL_CB_RPT_V3]
(
	@StartDate1 varchar(11),
	@EndDate1 varchar(11),
	@LedgerID1 varchar(10)
)
AS
BEGIN
	DECLARE 	@StartDate varchar(11),
				@EndDate varchar(11),
				@LedgerID varchar(10)
	
	DECLARE	@GLCrRow int = 0,
			@GLDrRow int = 0,
			@TotalCr int = 0,
			@TotalDr int = 0,
			@Name3 varchar(100) = ''
	
	SET @StartDate = @StartDate1
	SET @EndDate = @EndDate1
	SET @LedgerID = @LedgerID1	
	SET @Name3 = (SELECT sbname FROM Ledger WHERE id= @LedgerID)
	
	SET NOCOUNT ON

-------------------------- Opening Balance ---------------------------
	;WITH TDR_CTE AS(	
		SELECT SUM(j.Debt) AS M2
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	)
	,TCR_CTE AS(
		SELECT SUM(j.Credit) AS M1
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	)
	SELECT @TotalDr = (SELECT M2 FROM TDR_CTE), @TotalCr = (SELECT M1 FROM TCR_CTE)
	
	;WITH DR_GL_COUNT AS(
		SELECT COUNT(j.Id) AS DR
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	)
	,CR_GL_COUNT AS(
		SELECT COUNT(j.Id) AS CR
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	)
	SELECT @GLCrRow = (SELECT DR FROM DR_GL_COUNT), @GLDrRow = (SELECT CR FROM CR_GL_COUNT)
	--PRINT @GLCrRow
	--PRINT @GLDrRow
	IF @GLCrRow>=@GLDrRow
		BEGIN
			;WITH DR_GL AS(
				SELECT (CASE WHEN j.Notify = 'AR' THEN (SELECT @Name3+'('+c.Name+')' FROM sales AS s, Company AS c WHERE s.cid = c.id and s.TNO = j.TNO) ELSE l.SBName END) AS Name2, j.Debt AS M2, j.jdate AS DateS 
				FROM Ledger l, Journal j 
				WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
				j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
			)
			,DR_GL_ID AS(
				SELECT ROW_NUMBER() OVER (ORDER BY DateS) AS DID, Name2, M2, DateS FROM DR_GL
			)
			,CR_GL AS(
				SELECT (CASE WHEN j.Notify = 'AR' THEN (SELECT @Name3+'('+c.Name+')' FROM sales AS s, Company AS c WHERE s.cid = c.id and s.TNO = j.TNO) ELSE l.SBName END) AS Name1, j.Credit AS M1, j.jdate AS DateS 
				FROM Ledger l, Journal j 
				WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
				j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
			)
			,CR_GL_ID AS(
				SELECT ROW_NUMBER() OVER (ORDER BY DateS) AS CID, Name1, M1, DateS FROM CR_GL
			)
			--SELECT * FROM DR_GL_ID
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
			UNION ALL
			SELECT d.DId As ID,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS,d.DateS 
			FROM DR_GL_ID d LEFT JOIN CR_GL_ID c ON d.DId = c.CId
			--ORDER BY ID
		END
	ELSE
		BEGIN
			;WITH DR_GL AS(
				SELECT (CASE WHEN j.Notify = 'AR' THEN (SELECT @Name3+'('+c.Name+')' FROM sales AS s, Company AS c WHERE s.cid = c.id and s.TNO = j.TNO) ELSE l.SBName END) AS Name2, j.Debt AS M2, j.jdate AS DateS 
				FROM Ledger l, Journal j 
				WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
				j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
			)
			,DR_GL_ID AS(
				SELECT ROW_NUMBER() OVER (ORDER BY DateS) AS DID, Name2, M2, DateS FROM DR_GL
			)
			,CR_GL AS(
				SELECT (CASE WHEN j.Notify = 'AR' THEN (SELECT @Name3+'('+c.Name+')' FROM sales AS s, Company AS c WHERE s.cid = c.id and s.TNO = j.TNO) ELSE l.SBName END) AS Name1, j.Credit AS M1, j.jdate AS DateS 
				FROM Ledger l, Journal j 
				WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
				j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
			)
			,CR_GL_ID AS(
				SELECT ROW_NUMBER() OVER (ORDER BY DateS) AS CID, Name1, M1, DateS FROM CR_GL
			)
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
			UNION ALL
			SELECT c.CID,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS,d.DateS
			FROM CR_GL_ID c LEFT JOIN DR_GL_ID d ON c.CId = d.DId
			--ORDER BY ID
		END
	SET NOCOUNT OFF
END
