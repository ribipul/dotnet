CREATE PROCEDURE [dbo].[USP_MonthlyAssetsRPT] 
(
	@StartDate varchar(15), 
	@EndDate varchar(15),
	@Type varchar(12)
)
AS

DECLARE @StartDt as smalldatetime
DECLARE @StartDt2 as varchar(15)
DECLARE @TotalMonth int
DECLARE @i int
DECLARE @CurI varchar(10)
DECLARE @STR varchar(8000)
DECLARE @Query varchar(1000)

SET @TotalMonth=DATEDIFF(month,cast(@StartDate as smalldatetime),cast(@EndDate as smalldatetime))+1
SET @StartDt = cast(@StartDate as smalldatetime)

SET @STR = ''
SET @Query = ''
SET @i=1
	WHILE (@i<=@TotalMonth) 
		BEGIN
			SET @CurI=MONTH(@StartDt)
			SET @StartDt = DATEADD(month,1,@StartDt)
			SET @StartDt2 = CONVERT(varchar, @StartDt, 101)
			SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when j.jdate<''' + @StartDt2 + ''' then (j.debt-j.credit) else 0 end) AS M' + @CurI + ', '
			SET @i=@i+1
		END

	IF @Query <> '' 
		SET @Query = LEFT(@Query,LEN(@Query)-1)

--Asset (Bank, AR, Sundry Debtors etc)
SET @STR = 'SELECT l2.SBName As Name1, l1.SBName As Name2, l3.SBName As Name3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'WHERE (l1.under=l2.under+'',''+cast(l2.id as varchar)) And (l2.under=l3.under+'',''+cast(l3.id as varchar)) And (l2.under like ''1,12%'' OR l2.under like ''1,30%'')' + CHAR(13) + CHAR(10)
IF @Type = 'Current'
	SET @STR = @STR + 'And l1.id=j.sid and l1.LedgerAcc=1 And l3.SBName = ''Current Asset'' And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
ELSE
	SET @STR = @STR + 'And l1.id=j.sid and l1.LedgerAcc=1 And l3.SBName = ''Fixed Assets'' And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l1.SBName, l2.SBName, l3.SBName --HAVING sum(j.debt-j.credit)<>0'
--Asset (Cash)
SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT ''Cash in Hand'' As Name1, l1.SBName As Name2,  l2.SBName As Name3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Journal j ' + CHAR(13) + CHAR(10)
IF @Type = 'Current'
	SET @STR = @STR + 'WHERE (l1.under=''1,12'') And (l1.under=l2.under+'',''+cast(l2.id as varchar)) And l1.id=j.sid and l1.LedgerAcc=1 And l2.SBName = ''Current Asset'' And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
ELSE
	SET @STR = @STR + 'WHERE (l1.under=''1,12'') And (l1.under=l2.under+'',''+cast(l2.id as varchar)) And l1.id=j.sid and l1.LedgerAcc=1 And l2.SBName = ''Fixed Asset'' And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName --HAVING sum(j.debt-j.credit)<>0' + CHAR(13)
SET @STR = @STR + ' ORDER BY Name1'
EXEC (@STR)