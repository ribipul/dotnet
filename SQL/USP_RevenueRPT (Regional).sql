--ALTER PROCEDURE [dbo].[USP_RevenueRPT]
--(
DECLARE	@StartDate varchar(11) = '7/1/2015',
	@EndDate varchar(11) = '6/30/2016',
	@City varchar(50) = 'Chittagong',
	@Type varchar(10) = 'PRO'
--)
--AS

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
		SET @STR = 'SELECT l.sbname as name1, c.name as name2, c.City,' + @Query  + ' ' + CHAR(13) + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
		IF @City = ''
			SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id '+ CHAR(13)
		ELSE
			SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id And c.City = ''' + @City + ''' ' + CHAR(13)
		SET @STR = @STR + 'GROUP BY j.jdate, l.sbname, c.name, c.City --HAVING SUM(j.credit-j.debt)<>0' + CHAR(13)
		SET @STR = @STR + 'ORDER BY name1, name2'
	END
ELSE
	BEGIN
		SET @STR = 'SELECT c.name as name1, l.sbname as name2, c.City,' + @Query  + ' ' + CHAR(13) + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
		IF @City = ''
			SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id '+ CHAR(13)
		ELSE
			SET @STR = @STR + 'WHERE j.jdate between ''' + @StartDate + ''' and ''' + @EndDate  + ''' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id And c.City = ''' + @City + ''' ' + CHAR(13)
		SET @STR = @STR + 'GROUP BY c.name, l.sbname, c.City --HAVING SUM(j.credit-j.debt)<>0' + CHAR(13)
		SET @STR = @STR + 'ORDER BY name1, name2'
	END
--PRINT @STR
EXEC (@STR)


/*

SELECT l.sbname as name1, c.name as name2, c.City,sum(case when month(j.jdate)=7 then (j.credit-j.debt) else 0 end) AS M7, sum(case when month(j.jdate)=8 then (j.credit-j.debt) else 0 end) AS M8, sum(case when month(j.jdate)=9 then (j.credit-j.debt) else 0 end) AS M9, sum(case when month(j.jdate)=10 then (j.credit-j.debt) else 0 end) AS M10, sum(case when month(j.jdate)=11 then (j.credit-j.debt) else 0 end) AS M11, sum(case when month(j.jdate)=12 then (j.credit-j.debt) else 0 end) AS M12, sum(case when month(j.jdate)=1 then (j.credit-j.debt) else 0 end) AS M1, sum(case when month(j.jdate)=2 then (j.credit-j.debt) else 0 end) AS M2, sum(case when month(j.jdate)=3 then (j.credit-j.debt) else 0 end) AS M3, sum(case when month(j.jdate)=4 then (j.credit-j.debt) else 0 end) AS M4, sum(case when month(j.jdate)=5 then (j.credit-j.debt) else 0 end) AS M5, sum(case when month(j.jdate)=6 then (j.credit-j.debt) else 0 end) AS M6 FROM ledger AS l, company AS c, journal AS j, sales AS s WHERE j.jdate between '7/1/2015' and '6/30/2016' and j.ApprovedBy>0 and s.tno=j.tno and s.pcode=j.sid and s.pcode=l.id and s.cid=c.id And c.City = 'Chittagong'GROUP BY j.jdate, l.sbname, c.name, c.City --HAVING SUM(j.credit-j.debt)<>0ORDER BY name1, name2

*/