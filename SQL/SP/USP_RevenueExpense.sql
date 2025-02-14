 ----=====================================================
 ----Author:				Bipul
 ----Create date: 			20.03.2014
 ----Description:			Monthly Revenue/Expense for Balance Sheet
 ----=====================================================
CREATE PROCEDURE [dbo].[USP_RevenueExpense]
(
	@StartDate varchar(11),
	@EndDate varchar(11),
	@Type varchar(8)
)
 AS
DECLARE @StartDt as smalldatetime
DECLARE @StartDt2 as varchar(11)
DECLARE @TotalMonth int
DECLARE @i int
DECLARE @CurI varchar(10)
DECLARE @STR varchar(5000)
DECLARE @Query varchar(1000)
DECLARE @DEP_UNDER varchar(50) = '3,1075'

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
			IF @Type = 'Revenue'
				SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when j.jdate<''' + @StartDt2 + ''' then (j.credit-j.debt) else 0 end) AS M' + @CurI + ', '
			ELSE IF @Type = 'Expense'
				SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when j.jdate<''' + @StartDt2 + ''' then (j.debt-j.credit) else 0 end) AS M' + @CurI + ', '
			SET @i=@i+1
		END

	IF @Query <> '' 
		SET @Query = LEFT(@Query,LEN(@Query)-1)

SET @STR = 'SELECT ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM journal AS j, ledger AS l ' + CHAR(13) + CHAR(10)
IF @Type = 'Revenue'
	SET @STR = @STR + 'WHERE l.mgroup=''Revenue'' and l.LedgerAcc=1 and l.id=j.sid And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
ELSE IF @Type = 'Expense'
	SET @STR = @STR + 'WHERE l.mgroup=''Expense'' and (l.LedgerAcc=1 or l.under like ''' + @DEP_UNDER + '%'')' + ' and l.id=j.sid And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
--PRINT @STR
EXEC (@STR)