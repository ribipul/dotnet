 ----=====================================================
 ----Author:				Bipul
 ----Create date: 			28.04.2014
 ----Description:			Monthly Balance Sheet
 ----=====================================================
CREATE PROCEDURE [dbo].[USP_BalanceSheetRPT] 
(
	@StartDate varchar(11), 
	@EndDate varchar(11),
	@M1 int = 0,
	@M2 int = 0,
	@M3 int = 0,
	@M4 int = 0,
	@M5 int = 0,
	@M6 int = 0,
	@M7 int = 0,
	@M8 int = 0,
	@M9 int = 0,
	@M10 int = 0,
	@M11 int = 0,
	@M12 int = 0
)
AS

DECLARE @StartDt as smalldatetime
DECLARE @StartDt2 as varchar(11)
DECLARE @TotalMonth int
DECLARE @i int
DECLARE @CurI varchar(10)
DECLARE @STR varchar(8000)
DECLARE @STR2 varchar(8000)
DECLARE @Query varchar(2000)
DECLARE @Query2 varchar(2000)
DECLARE @Query3 varchar(2000)

DECLARE @FirstDayOfCompany varchar(11) = '4/1/2000'
DECLARE @DEP_UNDER varchar(50) = '3,1075'

SET @TotalMonth=DATEDIFF(month,cast(@StartDate as smalldatetime),cast(@EndDate as smalldatetime))+1
SET @StartDt = cast(@StartDate as smalldatetime)

SET @STR = ''
SET @STR2 = ''
SET @Query = ''
SET @Query2 = ''
SET @Query3 = ''
SET @i=1
	WHILE (@i<=@TotalMonth) 
		BEGIN
			SET @CurI=MONTH(@StartDt)
			SET @StartDt = DATEADD(month,1,@StartDt)
			SET @StartDt2 = CONVERT(varchar, @StartDt, 101)
			SET @Query = @Query + CHAR(13) + CHAR(10) + 'sum(case when j.jdate<''' + @StartDt2 + ''' then (j.debt-j.credit) else 0 end) AS M' + @CurI + ', '
			SET @Query2 = @Query2 + CHAR(13) + CHAR(10) + 'sum(case when j.jdate<''' + @StartDt2 + ''' then (j.credit-j.debt) else 0 end) AS M' + @CurI + ', '
			IF @i = 1
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M1 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 2
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M2 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 3
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M3 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 4
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M4 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 5
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M5 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 6
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M6 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 7
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M7 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 8
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M8 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 9
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M9 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 10
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M10 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 11
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M11 as varchar(100)) +' AS M' + @CurI + ', '
			ELSE IF @i = 12
				SET @Query3 = @Query3 + CHAR(13) + CHAR(10) + CAST(@M12 as varchar(100)) +' AS M' + @CurI + ', '
			SET @i=@i+1
		END

	IF @Query <> '' 
		SET @Query = LEFT(@Query,LEN(@Query)-1)
	IF @Query2 <> ''
		SET @Query2 = LEFT(@Query2,LEN(@Query2)-1)
	IF @Query3 <> ''
		SET @Query3 = LEFT(@Query3,LEN(@Query3)-1)

--Asset (Bank, AR, Sundry Debtors etc)
--SET @STR = 'SELECT l3.SBName As N1, l2.SBName As N2, l3.MGroup As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'WHERE (l1.under=l2.under+'',''+cast(l2.id as varchar)) And (l2.under=l3.under+'',''+cast(l3.id as varchar)) And (l2.under like ''1,12%'' OR l2.under like ''1,30%'')' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'GROUP BY l2.SBName, l3.SBName, l3.MGroup HAVING sum(j.debt-j.credit)<>0'
SET @STR = 'SELECT l3.SBName As N1, l2.SBName As N2, l3.MGroup As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'WHERE l3.MGroup <> ''Expense'' And l3.MGroup <> ''Liability'' And (l1.under=l2.under+'',''+cast(l2.id as varchar) OR l1.under Like '''' + l2.under+'',''+cast(l2.id as varchar) + ''%'') And l2.Under = l3.Under+'',''+cast(l3.id as varchar)' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'And (l3.SBName = ''Current Asset'' OR l3.SBName = ''Fixed Assets'') And (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) And l3.SBName <> ''Prepaid Loan & Advance'' And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l2.SBName, l3.SBName, l3.MGroup --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'
--Asset (Cash)
SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10) + 'SELECT l2.SBName As N1,  l1.SBName As N2, l2.MGroup As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Journal j ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'WHERE (l1.under=''1,12'') And (l1.under=l2.under+'',''+cast(l2.id as varchar)) And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l1.SBName, l2.SBName, l2.MGroup --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'
--Get total Less Accumulated Depreciation
SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10) + 'SELECT ''Fixed Assets'' As N1, (Select ''Less Accumulated Depreciation'') As N2, ''Asset'' As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) + 'FROM journal AS j, ledger AS l ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'WHERE l.under like ''' + @DEP_UNDER + '%''' + ' and l.id=j.sid and j.jdate >= ''' + @FirstDayOfCompany + ''' and j.jdate<= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l.MGroup --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)'
--Other Assets
SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10) + 'SELECT l2.SBName As N1, l1.SBName As N2, l2.MGroup As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Journal j ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and l1.LedgerAcc=1' + ' and l1.id=j.sid and j.jdate >= ''' + @FirstDayOfCompany + ''' and j.jdate<= ''' + @EndDate + ''' and j.ApprovedBy>0 and l2.sbname = ''Other Assets''' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l1.SBName, l2.SBName, l2.MGroup --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'
--Current Liabilities
SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10) + 'SELECT l3.SBName As N1, l2.SBName As N2, l3.MGroup As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'WHERE (l1.under=l2.under+'',''+cast(l2.id as varchar)) And (l2.under=l3.under+'',''+cast(l3.id as varchar)) And l2.under like ''4,13%'''  + CHAR(13) + CHAR(10)
SET @STR = @STR + 'And l3.SBName = ''Current Liability'' And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'GROUP BY l2.SBName, l3.SBName, l3.MGroup --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)' + CHAR(13) + CHAR(10)
--Long Term Liabilities
SET @STR2 = @STR2 + CHAR(13) + CHAR(10) +'SELECT (Select ''Long Term Liabilities'') As N1, l1.SBName As N2, l2.MGroup As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
SET @STR2 = @STR2 + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
SET @STR2 = @STR2 + 'Where (l1.under not like ''%,''+cast(l2.id as varchar)+'',%'' and l1.under not like ''%,''+cast(l2.id as varchar)) and ' 
SET @STR2 = @STR2 + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.sbname=''Current Liability'' and l1.sbname<>''Accumulated Depreciation'' and l1.mgroup=''Liability'' and l1.LedgerAcc=1 and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
SET @STR2 = @STR2 + 'GROUP BY l1.SBName, l2.SBName, l2.MGroup --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)'
--Equity/Capital (Paid-up Capital, Share Premium, Share Deposite etc)
SET @STR2 = @STR2 + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT ''Equity'' As N1, l2.SBName As N2, ''Equity'' As N3,  ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
SET @STR2 = @STR2 + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
SET @STR2 = @STR2 + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and  ' + CHAR(13) + CHAR(10)
SET @STR2 = @STR2 + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.MGroup = ''Capital'' and l2.SBName <> ''Capital'' and j.ApprovedBy>0  ' + CHAR(13) + CHAR(10)
SET @STR2 = @STR2 + 'GROUP BY l2.SBName --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)'	--, l2.SBName, l2.MGroup '	--HAVING sum(j.credit-j.debt)<>0' + CHAR(13) + CHAR(10)
--Equity/Capital (Retained Earnings)
SET @STR2 = @STR2 + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT ''Equity'' N1, ''Retained Earnings'' N2, ''Equity'' N3, ' + @Query3 + ' ' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'GROUP BY Name3, Name2, Name1' + CHAR(13) + CHAR(10) 
SET @STR2 = @STR2 + 'ORDER BY N3, N1, N2'

--PRINT @STR	--(@STR + 'Union All ' + @STR2)
EXEC (@STR + 'Union All ' + @STR2)