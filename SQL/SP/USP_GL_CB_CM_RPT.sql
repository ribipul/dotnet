-- =============================================
-- Author:		Bipul
-- Create date: January 08, 2014
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[USP_GL_CB_CM_RPT]
(
	@StartDate1 varchar(11),
	@EndDate1 varchar(11),
	@LedgerID1 varchar(10),
	@CompID1 varchar(10)
)
AS
BEGIN
	
	--DECLARE @GL TABLE(
	--	Id int IDENTITY(2,1),
	--	Name1 varchar(200) NULL,
	--	Name2 varchar(200) NULL,
	--	Name3 varchar(200) NULL,
	--	M1 float NULL,
	--	M2 float NULL,
	--	DateS1 smalldatetime NULL,
	--	DateS2 smalldatetime NULL
	--)
	DECLARE @DR_GL TABLE(
		Id int IDENTITY(2,1),
		Name2 varchar(200) NULL,
		--Name3 varchar(200) NULL,
		M2 float NULL,
		DateS2 smalldatetime NULL
	)
	DECLARE @CR_GL TABLE(
		Id int IDENTITY(2,1),
		Name1 varchar(200) NULL,
		--Name3 varchar(200) NULL,
		M1 float NULL,
		DateS1 smalldatetime NULL
	)	
	DECLARE	@GLCrRow int = 0,
			@GLDrRow int = 0,
			@TotalCr int = 0,
			@TotalDr int = 0,
			@Name3 varchar(100) = ''
	DECLARE 	@StartDate varchar(11),
				@EndDate varchar(11),
				@LedgerID varchar(10),
				@CompID varchar(10)
	
	SET @StartDate = @StartDate1
	SET @EndDate = @EndDate1
	SET @LedgerID = @LedgerID1	
	SET @CompID = @CompID1
	
	SET @Name3 = (SELECT Name FROM Company WHERE id = @CompID)
	
	SET NOCOUNT ON
--------------------------- Insert Debt ----------------------------------

	INSERT @DR_GL
	SELECT l.SBName+'('+c.Name+')' AS Name1, j.Debt AS M2, j.jdate AS DateS 
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0 And s.cid = @CompID
	Union All
	SELECT l.SBName AS Name1, j.Debt AS M2, j.jdate AS DateS 
	FROM Ledger l, Journal j, sales AS s 
	WHERE l.id = j.sid and s.TNO = j.TNO and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0 And s.cid = @CompID
 ------Assets General Ledger
	----Union All
	----SELECT l.SBName AS Name1, (SELECT Name FROM Company WHERE id= @CompID) AS Name3, j.Debt AS M2, j.jdate AS DateS 
	----FROM Ledger l, FixedAsset f, Journal j 
	----WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
	----j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	ORDER BY Name1, DateS

--------------------------- Insert Credit --------------------------------

	INSERT @CR_GL
	SELECT l.SBName+'('+c.Name+')' AS Name1, j.Credit AS M1, j.jdate AS DateS 
	FROM ledger AS l, journal AS j, sales AS s, Company AS c 
	WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID and 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0 And s.cid = @CompID
	Union All
	SELECT l.SBName AS Name1, j.Credit AS M1, j.jdate AS DateS 
	FROM Ledger l, Journal j, sales AS s  
	WHERE l.id = j.sid and s.TNO = j.TNO and j.jdate between @StartDate and @EndDate and j.sid <> @LedgerID And 
	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0 And s.cid = @CompID
------ Assets General Ledger
----	Union All
----	SELECT l.SBName AS Name1, (SELECT Name FROM Company WHERE id= @CompID) AS Name3, j.Credit AS M1, j.jdate AS DateS 
----	FROM Ledger l, FixedAsset f, Journal j 
----	WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate between @StartDate and @EndDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
----	j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	ORDER BY Name1, DateS 

----------------------- Count Total Debt and Credit ----------------------

	SELECT @GLDrRow = COUNT(*) OVER() FROM @DR_GL
	SELECT @GLCrRow = COUNT(*) OVER() FROM @CR_GL

---------------------- Insert and Update Final Table ----------------------
	--IF @GLDrRow >= @GLCrRow
	--	BEGIN
	--		IF @GLDrRow > 0
	--			BEGIN
	--				INSERT INTO @GL(Name2, Name3, M2, DateS2)
	--				SELECT Name2, Name3, M2, DateS2 FROM @DR_GL
	--				ORDER BY Name2
					
	--				UPDATE @GL
	--				SET Name1 = gc.Name1,
	--				Name3 = gc.Name3,
	--				M1 = gc.M1,
	--				DateS1 = gc.DateS1
	--				FROM @GL g INNER JOIN @CR_GL gc ON g.Id = gc.Id
	--			END
	--	END
	--ELSE
	--	BEGIN
	--		INSERT INTO @GL(Name1, Name3, M1, DateS1)
	--		SELECT Name1, Name3, M1, DateS1 FROM @CR_GL
	--		ORDER BY Name1
			
	--		UPDATE @GL
	--		SET Name2 = gd.Name2,
	--		Name3 = gd.Name3,
	--		M2 = gd.M2,
	--		DateS2 = gd.DateS2
	--		FROM @GL g INNER JOIN @DR_GL gd ON g.Id = gd.Id
	--	END

------------------------ Opening Balance of Debt ---------------------------
	;WITH TDR_CTE AS(	
		SELECT j.Debt AS M2
		FROM ledger AS l, journal AS j, sales AS s, Company AS c 
		WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0 And s.cid = @CompID
		Union All
		SELECT j.Debt AS M2
		FROM Ledger l, Journal j, sales AS s 
		WHERE l.id = j.sid and s.TNO = j.TNO and j.jdate < @StartDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0 And s.cid = @CompID
------ Assets
----		Union All
----		SELECT j.Debt AS M2
----		FROM Ledger l, FixedAsset f, Journal j 
----		WHERE l.id = j.sid AND f.ID = j.Tno and j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
----		j.jid in(select jid from journal where sid = @LedgerID) and j.Debt>0 and j.ApprovedBy>0
	)
--- Opening Sum of Debt
	SELECT @TotalDr = SUM(M2) FROM TDR_CTE

------------------------ Opening Balance of Credit -------------------------
	;WITH TCR_CTE AS(
		SELECT j.Credit AS M1
		FROM ledger AS l, journal AS j, sales AS s, Company AS c 
		WHERE s.PCode = l.id and s.cid = c.id and s.TNO = j.TNO and j.Notify = 'AR' and j.jdate < @StartDate and j.sid <> @LedgerID and 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0 And s.cid = @CompID
		Union All
		SELECT j.Credit AS M1
		FROM Ledger l, Journal j, sales AS s 
		WHERE l.id = j.sid and s.TNO = j.TNO and j.jdate < @StartDate and j.sid <> @LedgerID And 
		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0 And s.cid = @CompID
------ Assets
----		Union All
----		SELECT j.Credit AS M1
----		FROM Ledger l, FixedAsset f, Journal j 
----		WHERE l.id = j.sid AND f.ID = j.Tno AND  j.jdate < @StartDate and j.Notify = 'FixedAsset' and j.sid <> @LedgerID and 
----		j.jid in(select jid from journal where sid = @LedgerID) and j.Credit>0 and j.ApprovedBy>0
	)
--- Opening Sum of Credit
	SELECT @TotalCr = SUM(M1) FROM TCR_CTE

------------------------------ Final Output --------------------------------
	IF @GLDrRow >= @GLCrRow
		BEGIN
			select d.Id,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS1,d.DateS2 from @DR_GL d left join @CR_GL c on d.Id = c.Id
			UNION
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
		END
	ELSE
		BEGIN
			SELECT c.Id,c.Name1,d.Name2,@Name3 As Name3,c.M1,d.M2,c.DateS1,d.DateS2 FROM @CR_GL C left join @DR_GL D on C.Id = D.Id
			UNION
			SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, @Name3 As Name3, @TotalCr As M1,
			@TotalDr As M2, NULL As DateS1, NULL As DateS2
		END
	--SELECT * FROM @GL
	--UNION
	--SELECT 1 As ID, 'Opening Balance' As Name1, 'Opening Balance' As Name2, (SELECT Name FROM Company WHERE id= @CompID) As Name3, @TotalCr As M1,
	--@TotalDr As M2, NULL As DateS1, NULL As DateS2
	
	SET NOCOUNT OFF
END