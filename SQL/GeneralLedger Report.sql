	DECLARE @StartDate varchar(11) = '1/1/2012'
	DECLARE	@EndDate varchar(11) = '6/30/2012'
	DECLARE	@LedgerID varchar(50) = 301--720

DECLARE @GL TABLE(
	Id int IDENTITY(2,1),
	Name1 varchar(500) NULL,
	Name2 varchar(500) NULL,
	Name3 varchar(500) NULL,
	M1 float NULL,	-- varchar(255) NULL,
	M2 float NULL,	-- varchar(255) NULL,
	DateS1 smalldatetime NULL,	--varchar(255) NULL,
	DateS2 smalldatetime NULL	--varchar(255) NULL
)
DECLARE @DR_GL TABLE(
	Id int IDENTITY(2,1),
	Name2 varchar(500) NULL,
	Name3 varchar(500) NULL,
	M2 float NULL,	-- varchar(255) NULL,
	DateS2 smalldatetime NULL	--varchar(255) NULL
)
DECLARE @CR_GL TABLE(
	Id int IDENTITY(2,1),
	Name1 varchar(500) NULL,
	Name3 varchar(500) NULL,
	M1 float NULL,	-- varchar(255) NULL,
	DateS1 smalldatetime NULL	--varchar(255) NULL
)
	--DECLARE	@Name1 VARCHAR(255),
	--		@Name2 VARCHAR(255),
	--		@Name3 VARCHAR(255),
	--		@M1 VARCHAR(255),
	--		@M2 VARCHAR(255),
	--		@DateS1 VARCHAR(255),
	--		@DateS2 VARCHAR(255),
	DECLARE	@GLCrRow int = 0,
			@GLDrRow int = 0,
			@TotalCr int = 0,
			@TotalDr int = 0
	
--;WITH DR_CTE AS(
	INSERT @DR_GL
	SELECT l.SBName+'('+c.Name+')' AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
-- Assets General Ledger
--	Union All
--	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
--	FROM Ledger l, FixedAsset f, Journal j 
--	WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
---- Expense General Ledger
	Union All
	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
	FROM Ledger l, Journal j 
	WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and j.TNO = 0 And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	ORDER BY Name1, DateS
--)
--INSERT @DR_GL
--SELECT Name2, Name3, M2, DateS FROM DR_CTE

--;WITH CR_CTE AS(
	INSERT @CR_GL
	SELECT l.SBName+'('+c.Name+')' AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
-- Assets General Ledger
--	Union All
--	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
--	FROM Ledger l, FixedAsset f, Journal j 
--	WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
---- Expense General Ledger
	Union All
	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
	FROM Ledger l, Journal j 
	WHERE l.id = j.sid and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and j.TNO = 0 And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	ORDER BY Name1, DateS 
--)
--INSERT @CR_GL
--SELECT Name1, Name3, M1, DateS FROM CR_CTE

SELECT @GLDrRow = COUNT(*) OVER() FROM @DR_GL
SELECT @GLCrRow = COUNT(*) OVER() FROM @CR_GL

IF @GLDrRow >= @GLCrRow
	BEGIN
		IF @GLDrRow > 0
			BEGIN
				INSERT INTO @GL(Name2, Name3, M2, DateS2)
				SELECT Name2, Name3, M2, DateS2 FROM @DR_GL
				ORDER BY Name2
				
				UPDATE @GL
				SET Name1 = gc.Name1,
				Name3 = gc.Name3,
				M1 = gc.M1,
				DateS1 = gc.DateS1
				FROM @GL g INNER JOIN @CR_GL gc ON g.Id = gc.Id
			END
	END
ELSE
	BEGIN
		INSERT INTO @GL(Name1, Name3, M1, DateS1)
		SELECT Name1, Name3, M1, DateS1 FROM @CR_GL
		ORDER BY Name1
		
		UPDATE @GL
		SET Name2 = gd.Name2,
		Name3 = gd.Name3,
		M2 = gd.M2,
		DateS2 = gd.DateS2
		FROM @GL g INNER JOIN @DR_GL gd ON g.Id = gd.Id
	END

;WITH TDR_CTE AS(	
	SELECT l.SBName+'('+c.Name+')' AS Name2, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
---- Assets General Ledger
--	Union All
--	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
--	FROM Ledger l, FixedAsset f, Journal j 
--	WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
-- Expense General Ledger
	Union All
	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
	FROM Ledger l, Journal j 
	WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID and j.TNO = 0 And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	--ORDER BY Name2, DateS
)
--- Opening Sum of Debt
SELECT @TotalDr = SUM(M2) FROM TDR_CTE

;WITH TCR_CTE AS(
	SELECT l.SBName+'('+c.Name+')' AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
---- Assets General Ledger
--	Union All
--	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
--	FROM Ledger l, FixedAsset f, Journal j 
--	WHERE l.id = j.sid AND f.ID = j.Tno AND j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
--	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
-- Expense General Ledger
	Union All
	SELECT l.SBName AS Name1, (SELECT sbname FROM Ledger WHERE id= @LedgerID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
	FROM Ledger l, Journal j 
	WHERE l.id = j.sid and j.jdate < @StartDate and j.sid <> @LedgerID and j.TNO = 0 And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
--	--ORDER BY Name1, DateS 
)
--- Opening Sum of Credit
SELECT @TotalCr = SUM(M1) FROM TCR_CTE

IF (@TotalDr > 0) OR (@TotalDr > 0)
	BEGIN
		--SELECT DateS1, Name1 As ItemName, M1 As Debt, DateS2, Name2 As ItemName, M2 As Credit FROM @GL
		--UNION
		--SELECT NULL As DateS1, 'Opening Balance' As ItemName, CAST(@TotalCr AS varchar(20)) As Debt, NULL As DateS2,'Opening Balance' As ItemName, CAST(@TotalDr AS varchar(20)) As Credit
		
		SELECT * FROM @GL
		UNION
		SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, (SELECT SBName FROM Ledger WHERE ID = @LedgerID) As Name3, @TotalCr As M1,
		@TotalDr As M2, NULL As DateS1, NULL As DateS2
	END
ELSE
	SELECT * FROM @GL

--SELECT * FROM @DR_GL
--SELECT * FROM @CR_GL
