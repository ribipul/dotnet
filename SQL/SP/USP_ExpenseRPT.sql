 ----=====================================================
 ----Author:				Bipul
 ----Create date: 			20.03.2014
 ----Description:			Monthly Expence
 ----=====================================================
CREATE PROCEDURE [dbo].[USP_ExpenseRPT]
(
	@StartDate varchar(11),
	@EndDate varchar(11)
)
AS
BEGIN

	DECLARE @StartDt as smalldatetime
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
	SET @CurI=month(@StartDt)
	SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when month(j.jdate)=' + @CurI + ' then (j.debt-j.credit) else 0 end) AS M' + @CurI + ', '
	SET @i=@i+1
	SET @StartDt = DATEADD(month,1,@StartDt)
	END

	if @Query <> '' set @Query = left(@Query,len(@Query)-1)

	SET @STR = 'SELECT l1.sbname as Name1, l2.sbname as Name2,' + @Query  + ' ' + CHAR(13)
	SET @STR = @STR + 'FROM ledger AS l1, ledger as l2, journal AS j ' + CHAR(13)
	SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and l2.id=j.sid and l2.MGroup=''Expense'' and (l2.under like ''%,''+cast(l1.id as varchar)+'',%'' or l2.under like ''%,''+cast(l1.id as varchar)) and l1.levelNo=1 and l1.sbname<>''Sales Tax'' and j.ApprovedBy>0 ' + CHAR(13)
	SET @STR = @STR + 'GROUP BY l1.sbname, l2.sbname' + CHAR(13)
	SET @STR = @STR + 'ORDER BY name1, name2'

	EXEC (@STR)
END