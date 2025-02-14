CREATE PROCEDURE [dbo].[USP_GL_CB_RPT_V1]
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
--------------------------- Insert Debt ----------------------------------
	IF OBJECT_ID('DR_GL') IS NOT NULL
		DROP TABLE DR_GL
    IF OBJECT_ID('CR_GL') IS NOT NULL
		DROP TABLE CR_GL
	
	--INSERT @DR_GL
	SELECT ROW_NUMBER() OVER (Order by j.Id) AS DID, l.SBName+'('+c.Name+')' AS Name2, j.Debt AS M2, j.jdate AS DateS 
	INTO DR_GL
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	Union All
	SELECT ROW_NUMBER() OVER (Order by j.Id) AS DID, l.SBName AS Name1, j.Debt AS M2, j.jdate AS DateS 
	FROM Ledger l, Journal j 
	WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
--Assets General Ledger
	Union All
	SELECT ROW_NUMBER() OVER (Order by j.Id) AS DID, l.SBName AS Name1, j.Debt AS M2, j.jdate AS DateS 
	FROM Ledger l, FixedAsset f, Journal j 
	WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	ORDER BY DateS, Name2

--------------------------- Insert Credit --------------------------------

	--INSERT @CR_GL
	SELECT ROW_NUMBER() OVER (Order by j.Id) AS CID, l.SBName+'('+c.Name+')' AS Name1, j.Credit AS M1, j.jdate AS DateS 
	INTO CR_GL
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	Union All
	SELECT ROW_NUMBER() OVER (Order by j.Id) AS CID, l.SBName AS Name1, j.Credit AS M1, j.jdate AS DateS 
	FROM Ledger l, Journal j 
	WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
-- Assets General Ledger
	Union All
	SELECT ROW_NUMBER() OVER (Order by j.Id) AS CID, l.SBName AS Name1, j.Credit AS M1, j.jdate AS DateS 
	FROM Ledger l, FixedAsset f, Journal j 
	WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	ORDER BY DateS , Name1 

----------------------- Count Total Debt and Credit ----------------------

	SELECT @GLDrRow = COUNT(*) OVER() FROM DR_GL
	SELECT @GLCrRow = COUNT(*) OVER() FROM CR_GL

------------------------ Opening Balance of Debt ---------------------------
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
--- Opening Sum of Debt
	SELECT @TotalDr = SUM(M2) FROM TDR_CTE

------------------------ Opening Balance of Credit -------------------------
	;WITH TCR_CTE AS(
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
--- Opening Sum of Credit
	SELECT @TotalCr = SUM(M1) FROM TCR_CTE

------------------------------ Final Output --------------------------------
	IF @GLDrRow >= @GLCrRow
		BEGIN
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
			UNION
			SELECT d.DId,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS,d.DateS FROM DR_GL d left join CR_GL c on d.DId = c.CId			
		END
	ELSE
		BEGIN
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
			UNION
			SELECT c.CId,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS,d.DateS FROM CR_GL C left join DR_GL D on C.CId = D.DId			
		END
	
	DROP TABLE DR_GL
	DROP TABLE CR_GL
	
	SET NOCOUNT OFF
END