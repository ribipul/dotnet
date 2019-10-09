--CREATE PROCEDURE [dbo].[USP_IncomeStatementRPT]
--(
--	@StartDate varchar(11),
--	@EndDate varchar(11),
--	@Type varchar(20)
--)
--AS
--BEGIN
DECLARE @StartDate varchar(11) = '1/1/2013',
		@EndDate varchar(11) = '12/31/2013',
		@Type varchar(20) = 'IS'

	DECLARE @StartDt as smalldatetime
	DECLARE @StartDt2 as varchar(11)
	DECLARE @TotalMonth int
	DECLARE @i int
	DECLARE @CurI varchar(10)
	DECLARE @STR varchar(8000)
	DECLARE @STR2 varchar(8000)
	DECLARE @Query varchar(3000)
	DECLARE @Query2 varchar(1000)

	SET @TotalMonth=DATEDIFF(month,cast(@StartDate as smalldatetime),cast(@EndDate as smalldatetime))+1
	SET @StartDt = cast(@StartDate as smalldatetime)

	SET @STR = ''
	SET @STR2 = ''
	SET @Query = ''
	SET @Query2 = ''
	SET @i=1
		WHILE (@i<=@TotalMonth) 
		BEGIN
			SET @CurI=month(@StartDt)
			SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when month(j.jdate)=' + @CurI + ' then (j.credit-j.debt) else 0 end) AS M' + @CurI + ', '
			SET @Query2 = @Query2 + CHAR(13) + CHAR(10) + 'sum(case when month(j.jdate)=' + @CurI + ' then (j.debt-j.credit) else 0 end) AS M' + @CurI + ', '
			SET @i=@i+1
			SET @StartDt = DATEADD(month,1,@StartDt)
		END

		IF @Query <> '' 
			SET @Query = LEFT(@Query,LEN(@Query)-1)
		IF @Query2 <> '' 
			SET @Query2 = LEFT(@Query2,LEN(@Query2)-1)

	-- Revenue
	SET @STR = @STR + 'SELECT s1.SBName AS Name1, s2.SBName AS Name2, s1.MGroup AS Name3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) 
	SET @STR = @STR + 'FROM Ledger AS s1, Ledger AS s2, journal AS j ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'WHERE s1.MGroup=''Revenue'' and s1.levelno=1 and (s2.under like ''%,''+cast(s1.id as varchar) or s2.under like ''%,''+cast(s1.id as varchar)+'',%'') ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'and s1.ledgerAcc=0 and j.jdate BETWEEN ''' + @StartDate + '''  And ''' + @EndDate + ''' and j.ApprovedBy>0 and s2.id=j.sid ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'GROUP BY s1.MGroup, s1.sbname, s2.SBName ' + CHAR(13) + CHAR(10)
	-- Expense
	SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT s1.SBName AS Name1, s2.SBName AS Name2, s1.MGroup AS Name3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
	SET @STR = @STR + 'FROM Ledger AS s1, Ledger AS s2, journal AS j ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'WHERE s1.MGroup=''Expense'' and s1.id<>630 and s1.levelno=1 and (s2.under like ''%,''+cast(s1.id as varchar) or s2.under ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'like ''%,''+cast(s1.id as varchar)+'',%'') and s1.ledgerAcc=0 and s1.sbname not in(''Sales Tax'', ''P & L Appropreation A/C'') and j.jdate BETWEEN ''' + @StartDate + '''  And ''' + @EndDate + ''' and j.ApprovedBy>0 and s2.id=j.sid ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'GROUP BY s1.MGroup, s1.sbname, s2.SBName ' + CHAR(13) + CHAR(10) 
	-- Sales Tax
	IF @Type = 'IS'
		BEGIN
			SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT s2.SBName AS Name1, s1.SBName AS Name2, ''Less Sales Tax'' AS Name3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
			SET @STR = @STR + 'FROM Ledger AS s1, Ledger AS s2, journal AS j ' + CHAR(13) + CHAR(10)
			SET @STR = @STR + 'WHERE s1.MGroup=''Expense'' and s1.id<>630 and s1.levelno=1 and (s2.under like ''%,''+cast(s1.id as varchar) or s2.under ' + CHAR(13) + CHAR(10)
			SET @STR = @STR + 'like ''%,''+cast(s1.id as varchar)+'',%'') and s1.ledgerAcc=0 and s1.sbname=''Sales Tax'' and j.jdate BETWEEN ''' + @StartDate + '''  And ''' + @EndDate + ''' and j.ApprovedBy>0 and s2.id=j.sid ' + CHAR(13) + CHAR(10)
			SET @STR = @STR + 'GROUP BY s1.MGroup, s1.sbname, s2.SBName ' + CHAR(13) + CHAR(10)
		END
	--P & L Appropreation A/C
	SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT l1.SBName As Name1, s.SBName As Name2, l2.SBName As Name3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'FROM Ledger AS s, journal AS j, Ledger l1, Ledger l2 ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'WHERE s.MGroup=''Expense'' and l1.levelno=2 and l1.ledgerAcc=0 and l2.Id=630 and l1.under like ''%,'' + cast(l2.id as varchar) + ''%''' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'and (s.under like ''%,''+cast(l1.id as varchar) or s.under like ''%,''+cast(l1.id as varchar)+''%'') and s.ledgerAcc=1 and j.jdate BETWEEN ''1/1/2013''  And ''12/31/2013'' and j.ApprovedBy>0 and s.id=j.sid ' + CHAR(13) + CHAR(10)
	SET @STR = @STR + 'GROUP BY l2.SBName, s.sbname, l1.SBName' + CHAR(13) + CHAR(10)
	
	SET @STR = @STR + 'ORDER BY Name3 DESC, Name1, Name2'
	
	--PRINT @STR
	EXEC (@STR)
--END



--USP_IncomeStatementRPT '1/1/2013', '12/31/2013', 'IS'
