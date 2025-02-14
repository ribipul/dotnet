----=====================================================
----Author:				Bipul
----Create date: 			18.03.2014
----Description:			Accounts Receivablel Monthly
----=====================================================
CREATE PROCEDURE [dbo].[USP_AccountsReceivableRPT]
(
		@StartDate varchar(11), 
		@EndDate varchar(11),
		@Type varchar(3) = 'PRO',
		@ARID varchar(5)
)
AS
BEGIN

	DECLARE @StartDt as smalldatetime
	DECLARE @StartDt2 as varchar(11)
	DECLARE	@Name1 varchar(20) = ''
	DECLARE	@Name2 varchar(20) = ''
	DECLARE @TotalMonth int
	DECLARE @i int
	DECLARE @CurI varchar(10) = ''
	DECLARE @STR varchar(8000) = ''
	DECLARE @Query varchar(5000) = ''

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
	
	SET @STR = 'SELECT ' + @Name1 + ' as name1, ' + @Name2 + ' as name2,' + @Query  + ' ' + CHAR(13) + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
	SET @STR = @STR + 'WHERE j.jdate <= ''' + @EndDate + ''' And j.sid = ' + @ARID + ' And s.tno = j.tno And s.pcode = l.id And s.cid = c.id and j.ApprovedBy>0 ' + CHAR(13)
	SET @STR = @STR + 'GROUP BY  ' + @Name1 + ', ' + @Name2 + ' --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)' + CHAR(13)
	SET @STR = @STR + 'ORDER BY ' + @Name1 + ', ' + @Name2
	--SET @STR = 'SELECT l3.SBName As N1, l2.SBName As N2, l3.MGroup As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
	--SET @STR = @STR + 'WHERE l3.MGroup <> ''Expense'' And l3.MGroup <> ''Liability'' And (l1.under=l2.under+'',''+cast(l2.id as varchar) OR l1.under Like '''' + l2.under+'',''+cast(l2.id as varchar) + ''%'') And l2.Under = l3.Under+'',''+cast(l3.id as varchar)' + CHAR(13) + CHAR(10)
	--SET @STR = @STR + 'And (l3.SBName = ''Current Asset'' OR l3.SBName = ''Fixed Assets'') And (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) And l3.SBName <> ''Prepaid Loan & Advance'' And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
	--SET @STR = @STR + 'GROUP BY l2.SBName, l3.SBName, l3.MGroup HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'

	--PRINT @STR
	EXEC (@STR)
END
