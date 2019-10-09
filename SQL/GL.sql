DECLARE 	@StartDate varchar(11) = '1/1/2013',
			@EndDate varchar(11) = '12/31/2013',
			@LedgerID varchar(10) = 35

DECLARE @DR_GL TABLE(
	DId int IDENTITY(2,1),
	Name2 varchar(200) NULL,
	M2 float NULL,
	DateS2 smalldatetime NULL
)
DECLARE @CR_GL TABLE(
	CId int IDENTITY(2,1),
	Name1 varchar(200) NULL,
	M1 float NULL,
	DateS1 smalldatetime NULL
)	
DECLARE	@GLCrRow int = 0,
		@GLDrRow int = 0,
		@TotalCr int = 0,
		@TotalDr int = 0,
		@Name3 varchar(100) = ''

SET @Name3 = (SELECT sbname FROM Ledger WHERE id= @LedgerID)

SET NOCOUNT ON
--------------------------- Insert Debt ----------------------------------

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

--SELECT * FROM DR_GL
--SELECT * FROM CR_GL
SELECT d.DId,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS,d.DateS 
--INTO TEMPTABLE
FROM DR_GL d LEFT JOIN CR_GL c ON d.DId = c.CId
DROP TABLE DR_GL
DROP TABLE CR_GL
--SELECT * FROM TEMPTABLE
--DROP TABLE TEMPTABLE
------------------------- Count Total Debt and Credit ----------------------

--SELECT @GLDrRow = COUNT(*) OVER() FROM @DR_GL
--SELECT @GLCrRow = COUNT(*) OVER() FROM @CR_GL

---------------------------- Opening Balance of Debt ---------------------------
--;WITH TDR_CTE AS(	
--	SELECT j.Debt AS M2
--	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
--	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
--	Union All
--	SELECT j.Debt AS M2
--	FROM Ledger l, Journal j 
--	WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID And 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
---- Assets
--	Union All
--	SELECT j.Debt AS M2
--	FROM Ledger l, FixedAsset f, Journal j 
--	WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
--)
----- Opening Sum of Debt
--SELECT @TotalDr = SUM(M2) FROM TDR_CTE

-------------------------- Opening Balance of Credit -------------------------
--;WITH TCR_CTE AS(
--	SELECT j.Credit AS M1
--	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
--	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
--	Union All
--	SELECT j.Credit AS M1
--	FROM Ledger l, Journal j 
--	WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID And 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
---- Assets
--	Union All
--	SELECT j.Credit AS M1
--	FROM Ledger l, FixedAsset f, Journal j 
--	WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
--)
----- Opening Sum of Credit
--SELECT @TotalCr = SUM(M1) FROM TCR_CTE

---------------------------------- Final Output --------------------------------

--IF @GLDrRow >= @GLCrRow
--	BEGIN
--		SELECT d.Id,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS1,d.DateS2 FROM @DR_GL d left join @CR_GL c on d.DId = c.CId
--		UNION
--		SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
--		@TotalDr As M2, NULL As DateS1, NULL As DateS2
--	END
--ELSE
--	BEGIN
--		SELECT c.Id,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS1,d.DateS2 FROM @CR_GL C left join @DR_GL D on C.CId = D.DId
--		UNION
--		SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
--		@TotalDr As M2, NULL As DateS1, NULL As DateS2
--	END
SET NOCOUNT OFF