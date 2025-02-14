-- =============================================
-- Author:				Bipul
-- Create date: 		29.04.2014
-- Description:			Revenue Report
-- =============================================
CREATE PROCEDURE [dbo].[USP_RevenueRPT]
(
	@StartDate varchar(11),
	@EndDate varchar(11),
	@Type varchar(10) = null
)
AS

DECLARE @StartDt as smalldatetime
DECLARE @TotalMonth int
DECLARE @i int
DECLARE @CurI varchar(10)
DECLARE @STR varchar(5000)
DECLARE @Query varchar(1000)

SET @TotalMonth=DATEDIFF(month,cast(@StartDate as smalldatetime),cast(@EndDate as smalldatetime))+1
SET @StartDt = cast(@StartDate as smalldatetime)

SET @STR = ''
SET @Query = ''
SET @i=1
	WHILE (@i<=@TotalMonth) 
		BEGIN
			SET @CurI=month(@StartDt)
			SET @Query = @Query + CHAR(13) + 'sum(case when month(j.jdate)=' + @CurI + ' then (j.credit-j.debt) else 0 end) AS M' + @CurI + ', '
			SET @i=@i+1
			SET @StartDt = DATEADD(month,1,@StartDt)
		END

	IF @Query <> '' set @Query = LEFT(@Query,LEN(@Query)-1)

IF @Type = 'PRO'
	BEGIN
		SET @STR = 'SELECT l.sbname as name1, c.name as name2,' + @Query  + ' ' + CHAR(13) + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
		SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id '+ CHAR(13)
		SET @STR = @STR + 'GROUP BY j.jdate, l.sbname, c.name --HAVING SUM(j.credit-j.debt)<>0' + CHAR(13)
		SET @STR = @STR + 'ORDER BY name1, name2'
	END
ELSE
	BEGIN
		SET @STR = 'SELECT c.name as name1, l.sbname as name2,' + @Query  + ' ' + CHAR(13) + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
		SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id '+ CHAR(13)
		SET @STR = @STR + 'GROUP BY c.name, l.sbname --HAVING SUM(j.credit-j.debt)<>0' + CHAR(13)
		SET @STR = @STR + 'ORDER BY name1, name2'
	END
--PRINT @STR
EXEC (@STR)