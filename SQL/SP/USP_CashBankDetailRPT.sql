 ----=====================================================
 ----Author:				Bipul
 ----Create date: 			04.05.2014
 ----Description:			Monthly Current Asset, Monthly Fixed Assets
 ----						Monthly Other Assets, Monthly Current Liabilities
 ----						Cash & Bank Detail Report
 ----=====================================================
CREATE PROCEDURE [dbo].[USP_CashBankDetailRPT]
(
	@StartDate varchar(15),
	@EndDate varchar(15),
	@CashBankID varchar(500)
)
AS

DECLARE @StartDt as smalldatetime
DECLARE @StartDt2 as varchar(11)
DECLARE @TotalMonth int
DECLARE @i int
DECLARE @CurI varchar(10)
DECLARE @STR varchar(5000)
DECLARE @Query varchar(2000)

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
			SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when j.jdate< ''' + @StartDt2 + ''' then (j.debt-j.credit) else 0 end) AS M' + @CurI + ', '
			SET @i=@i+1
		END

	IF @Query <> '' 
		SET @Query = LEFT(@Query,LEN(@Query)-1)

SET @STR = 'SELECT '''' As Name1, l.SBName Name2,' + @Query  + CHAR(13) + CHAR(10) 
SET @STR = @STR + 'FROM Journal As j, Ledger As l ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'WHERE l.id=j.sid and sid IN(Select id from ledger where id in(' + @CashBankID + ')) and j.jdate < ''' + @EndDate  + ''' and approvedby>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l.SBName '  + CHAR(13) + CHAR(10)
SET @STR = @STR + 'ORDER BY l.SBName'

EXEC (@STR)