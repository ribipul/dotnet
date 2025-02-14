-- =============================================
-- Author:				Bipul
-- Create date: 		30.04.2014
-- Description:			Cash Collection Report
-- =============================================
CREATE PROCEDURE [dbo].[USP_CashCollectionRPT]
(
	@StartDate varchar(11), 
	@EndDate varchar(11), 
	@Name1 varchar(20), 
	@Name2 varchar(20)
)
AS

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
			SET @CurI=MONTH(@StartDt)
			SET @Query = @Query + CHAR(13) + 'sum(case when month(ca.ReceivedDate)=' + @CurI + ' then ca.Cash else 0 end) AS M' + @CurI + ', '
			SET @StartDt = DATEADD(month,1,@StartDt)
			SET @i=@i+1
	END

if @Query <> '' set @Query = left(@Query,len(@Query)-1)

SET @STR = @STR + 'SELECT ' + @Name1 + ' as name1, ' + @Name2 + ' as name2, ' + @Query  + ' ' + CHAR(13)
SET @STR = @STR + 'FROM ledger AS l, Cash_Collection AS ca, sales AS s, Company AS c ' + CHAR(13)
SET @STR = @STR + 'WHERE ca.ReceivedDate between ''' + CONVERT(varchar, @StartDate, 101) + ''' and ''' + CONVERT(varchar, @EndDate, 101) + ''' and ca.tno=s.tno and s.pcode=l.id and s.cid=c.id ' + CHAR(13)
SET @STR = @STR + 'GROUP BY  ' + @Name1 +', ' + @Name2  + CHAR(13)
SET @STR = @STR + 'ORDER BY name1, name2'

EXEC (@STR)