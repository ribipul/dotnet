CREATE PROCEDURE [dbo].[USP_GL_CB_RPT_V2]
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
		SELECT j.Debt AS M2
		FROM ledger AS l, journal AS j, sales AS s, Company AS c 
		WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
		Union All
		SELECT j.Debt AS M2
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	-- Assets
		Union All
		SELECT j.Debt AS M2
		FROM Ledger l, FixedAsset f, Journal j 
		WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	)
	,TCR_CTE AS(
		SELECT j.Credit AS M1
		FROM ledger AS l, journal AS j, sales AS s, Company AS c 
		WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
		Union All
		SELECT j.Credit AS M1
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	-- Assets
		Union All
		SELECT j.Credit AS M1
		FROM Ledger l, FixedAsset f, Journal j 
		WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	)
	SELECT @TotalDr = (SELECT SUM(M2) FROM TDR_CTE), @TotalCr = (SELECT SUM(M1) FROM TCR_CTE)
	
	;WITH DR_GL AS(
		SELECT j.Id, l.SBName+'('+c.Name+')' AS Name2, j.Debt AS M2, j.jdate AS DateS 
		FROM ledger AS l, journal AS j, sales AS s, Company AS c 
		WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
		Union All
		SELECT j.Id, l.SBName AS Name2, j.Debt AS M2, j.jdate AS DateS 
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
		--Assets General Ledger
		Union All
		SELECT j.Id, l.SBName AS Name2, j.Debt AS M2, j.jdate AS DateS 
		FROM Ledger l, FixedAsset f, Journal j 
		WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
		--ORDER BY DateS, Name2
	)
	,DR_GL_ID AS(
		SELECT ROW_NUMBER() OVER (ORDER BY Id) AS DID, Name2, M2, DateS FROM DR_GL
	)
	,CR_GL AS(
		SELECT j.Id, l.SBName+'('+c.Name+')' AS Name1, j.Credit AS M1, j.jdate AS DateS 
		FROM ledger AS l, journal AS j, sales AS s, Company AS c 
		WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
		Union All
		SELECT j.Id, l.SBName AS Name1, j.Credit AS M1, j.jdate AS DateS 
		FROM Ledger l, Journal j 
		WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
		-- Assets General Ledger
		Union All
		SELECT j.Id, l.SBName AS Name1, j.Credit AS M1, j.jdate AS DateS 
		FROM Ledger l, FixedAsset f, Journal j 
		WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
		--ORDER BY DateS , Name1
	)
	,CR_GL_ID AS(
		SELECT ROW_NUMBER() OVER (ORDER BY Id) AS CID, Name1, M1, DateS FROM CR_GL
	)
	SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
	@TotalDr As M2, NULL As DateS1, NULL As DateS2
	UNION
	SELECT d.DId,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS,d.DateS 
	FROM DR_GL_ID d LEFT JOIN CR_GL_ID c ON d.DId = c.CId
	
	SET NOCOUNT OFF
END