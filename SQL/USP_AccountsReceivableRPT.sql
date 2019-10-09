-- =====================================================
-- Author:				Bipul
-- Create date: 		18.03.2014
-- Description:			Accounts Receivablel Monthly
-- =====================================================
--CREATE PROCEDURE [dbo].[USP_AccountsReceivableRPT]
--(
--	@StartDate varchar(11), 
--	@EndDate varchar(11), 
--	@Name1 varchar(20), 
--	@Name2 varchar(20), 
--	@Name3 varchar(20), 
--	@Name4 varchar(20), 
--	@ARID varchar(5)
--)
--AS
--BEGIN
	
DECLARE	@StartDate varchar(11) = '01/01/2013', 
		@EndDate varchar(11) = '03/31/2013', 
		@Name1 varchar(20), 
		@Name2 varchar(20), 
		@ARID varchar(5) = '35',
		@Type varchar(3) = 'PRO'

	DECLARE @StartDt as smalldatetime
	DECLARE @StartDt2 as varchar(11)
	DECLARE @TotalMonth int
	DECLARE @i int
	DECLARE @CurI varchar(10)
	DECLARE @STR varchar(8000)
	DECLARE @Query varchar(5000)

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

		IF @Query <> '' set @Query = LEFT(@Query,LEN(@Query)-1)
	
	IF @Type = 'PRO'
		BEGIN
			SET @Name1 = 'l.SBname'
			SET @Name2 = 'c.Name'
		END
	ELSE
		BEGIN
			SET @Name1 = 'c.Name'
			SET @Name2 = 'l.SBname'
		END
	
	SET @STR = 'SELECT ' + @Name1 + ' as name1, ' + @Name2 + ' as name2,' + @Query  + ' ' + CHAR(13) 
	SET @STR = @STR + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
	SET @STR = @STR + 'WHERE j.jdate <= ''' + @EndDate + ''' And j.sid = ' + @ARID + ' And s.tno = j.tno And s.pcode = l.id And s.cid = c.id and j.ApprovedBy>0 ' + CHAR(13)
	SET @STR = @STR + 'GROUP BY  ' + @Name1 + ', ' + @Name2 + ' HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)' + CHAR(13)
	SET @STR = @STR + 'ORDER BY ' + @Name1 + ', ' + @Name2
	
	--SET @STR = 'SELECT ' + @Name1 + ' as name1,' + @Query  + ' ' + CHAR(13) + 'FROM ledger AS l, journal AS j, sales AS s ' + CHAR(13)
	--SET @STR = @STR + 'WHERE j.jdate <= ''' + @EndDate + ''' And j.sid = ' + @ARID + ' And s.tno = j.tno And s.pcode = l.id and j.ApprovedBy>0 ' + CHAR(13)
	--SET @STR = @STR + 'GROUP BY  ' + @Name1 + ' HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)' + CHAR(13)
	--SET @STR = @STR + 'ORDER BY ' + @Name1
	
	PRINT @STR
	--EXEC (@STR)
--END


--USP_AccountsReceivableRPT '1/1/2013', '6/30/2013', 'PRO', '35'


--SELECT l.sbname as name1, c.name as name2, sum(j.debt-j.credit) AS TD 
--FROM ledger AS l, company AS c, journal AS j, sales AS s 
--Where j.jdate <'2/1/2013' and j.ApprovedBy>0 And j.sid =35 And s.tno = j.tno And s.pcode = L.id And s.cid = c.id 
--GROUP BY  l.sbname, c.name HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1) 
--ORDER BY l.sbname, c.name
----Union
--SELECT l.sbname as name1, c.name as name2, sum(j.debt-j.credit) AS TD FROM ledger AS l, company AS c, journal AS j, sales AS s Where j.jdate <'3/1/2013' and j.ApprovedBy>0 And j.sid =35 And s.tno = j.tno And s.pcode = L.id And s.cid = c.id GROUP BY  l.sbname, c.name HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1) ORDER BY l.sbname, c.name
----Union
--SELECT l.sbname as name1, c.name as name2, sum(j.debt-j.credit) AS TD FROM ledger AS l, company AS c, journal AS j, sales AS s Where j.jdate <'4/1/2013' and j.ApprovedBy>0 And j.sid =35 And s.tno = j.tno And s.pcode = L.id And s.cid = c.id GROUP BY  l.sbname, c.name HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1) ORDER BY l.sbname, c.name


--select sum(j.debt-j.credit) as Td from ledger l1,ledger l2,ledger l3,company c,journal j,sales s where j.jdate >= '1/1/2013' and j.ApprovedBy>0 and j.jdate<'2/1/2013' and (l1.under like '%,'+cast(l2.id as varchar)+',%' or l1.under like '%,'+cast(l2.id as varchar)) and l2.sbname='Sales Tax' and l1.ledgeracc=1 and j.sid=l1.id and j.tno=s.tno and l3.sbname='Category Section Banner' and l3.id=s.pcode and c.name='Abdul Monem Limited' and c.id=s.cid
SELECT l.SBname as name1, c.Name as name2,
sum(case when j.jdate<'02/01/2013' then (j.debt-j.credit) else 0 end) AS M1,
sum(case when j.jdate<'03/01/2013' then (j.debt-j.credit) else 0 end) AS M2, 
sum(case when j.jdate<'04/01/2013' then (j.debt-j.credit) else 0 end) AS M3 FROM ledger AS l, company AS c, journal AS j, sales AS s WHERE j.jdate <= '03/31/2013' And j.sid = 35 And s.tno = j.tno And s.pcode = l.id And s.cid = c.id and j.ApprovedBy>0 And l.sbname = 'Workshop'GROUP BY  l.SBname, c.Name HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)ORDER BY l.SBname, c.NameSELECT l.sbname as name1, c.name as name2, sum(j.debt-j.credit) AS TD 
FROM ledger AS l, company AS c, journal AS j, sales AS s 
Where j.jdate <'2/1/2013' and j.ApprovedBy>0 And j.sid =35 And s.tno = j.tno And s.pcode = L.id And s.cid = c.id 
And l.sbname = 'Workshop'
GROUP BY  l.sbname, c.name HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1) 
ORDER BY l.sbname, c.name

