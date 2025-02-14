----=====================================================
----Author:					Bipul
----Create date: 			28.04.2014
----Description:			Monthly Current Asset, Monthly Fixed Assets
----						Monthly Other Assets, Monthly Current Liabilities
----						Monthly Other Liabilities
----=====================================================
CREATE PROCEDURE [dbo].[USP_BalanceSheet] 
(
	@StartDate1 varchar(11), 
	@EndDate1 varchar(11),
	@Type1 varchar(12),
	@M_1 int = 0,
	@M_2 int = 0,
	@M_3 int = 0,
	@M_4 int = 0,
	@M_5 int = 0,
	@M_6 int = 0,
	@M_7 int = 0,
	@M_8 int = 0,
	@M_9 int = 0,
	@M_10 int = 0,
	@M_11 int = 0,
	@M_12 int = 0
)
AS

DECLARE @StartDate varchar(11)
DECLARE @EndDate varchar(11)
DECLARE @Type varchar(12)
DECLARE @M1 int
DECLARE @M2 int
DECLARE	@M3 int
DECLARE	@M4 int
DECLARE	@M5 int
DECLARE	@M6 int
DECLARE	@M7 int
DECLARE	@M8 int
DECLARE	@M9 int
DECLARE	@M10 int
DECLARE	@M11 int
DECLARE	@M12 int

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

SET @StartDate = @StartDate1
SET @EndDate = @EndDate1
SET @Type = @Type1
SET @M1 = @M_1
SET @M2 = @M_2
SET	@M3 = @M_3
SET	@M4 = @M_4
SET	@M5 = @M_5
SET	@M6 = @M_6
SET	@M7 = @M_7
SET	@M8 = @M_8
SET	@M9 = @M_9
SET	@M10 = @M_10
SET	@M11 = @M_11
SET	@M12 = @M_12

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


IF @Type = 'CA'
--Current Asset
	BEGIN
		SET @STR = 'SELECT (CASE WHEN l2.SBName = ''Bank'' THEN ''Cash At Bank'' ELSE l2.SBName END) As N1, l1.SBName As N2, l3.SBName As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'WHERE l3.MGroup = ''Asset'' And (l1.under=l2.under+'',''+cast(l2.id as varchar) OR l1.under Like '''' + l2.under+'',''+cast(l2.id as varchar) + ''%'') And l2.Under = l3.Under+'',''+cast(l3.id as varchar)' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'And l3.SBName = ''Current Asset'' And (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) And l3.SBName <> ''Prepaid Loan & Advance'' And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName, l3.SBName --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'
		--Asset (Cash)
		SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT ''Cash In Hand'' As N1, l1.SBName As N2, l2.SBName As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Journal j ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'WHERE (l1.under=''1,12'') And (l1.under=l2.under+'',''+cast(l2.id as varchar)) And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l1.SBName, l2.SBName --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)' + CHAR(13)
		SET @STR = @STR + 'ORDER BY N1, N2'
	END
ELSE IF @Type = 'FA'
	BEGIN
		SET @STR = 'SELECT l2.SBName As N1, l1.SBName As N2, l3.SBName As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'WHERE l3.MGroup = ''Asset'' And (l1.under=l2.under+'',''+cast(l2.id as varchar) OR l1.under Like '''' + l2.under+'',''+cast(l2.id as varchar) + ''%'') And l2.Under = l3.Under+'',''+cast(l3.id as varchar)' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'And l3.SBName = ''Fixed Assets'' And (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) And l3.SBName <> ''Prepaid Loan & Advance'' And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName, l3.SBName --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'
		--Get total Less Accumulated Depreciation
		SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10) + 'SELECT ''Less Accumulated Depreciation'' As N1, l.SBName As N2, ''Fixed Assets'' As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) + 'FROM journal AS j, ledger AS l ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'WHERE l.under like ''' + @DEP_UNDER + '%''' + ' and l.id=j.sid and j.jdate >= ''' + @FirstDayOfCompany + ''' and j.jdate<= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l.SBName --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)' + CHAR(13)
		SET @STR = @STR + 'ORDER BY N1, N2'
	END
ELSE IF @Type = 'OA'
--Other Assets
	BEGIN
		SET @STR = @STR + 'SELECT l2.SBName As N1, l1.SBName As N2, l2.SBName As N3, ' + @Query  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Journal j ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and l1.LedgerAcc=1' + ' and l1.id=j.sid and j.jdate >= ''' + @FirstDayOfCompany + ''' and j.jdate<= ''' + @EndDate + ''' and j.ApprovedBy>0 and l2.sbname = ''Other Assets''' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l1.SBName, l2.SBName --HAVING (sum(j.debt-j.credit)>1 or sum(j.debt-j.credit)<-1)'
	END
ELSE IF @Type = 'CL'
--Current Liabilities
	BEGIN
		SET @STR = @STR + 'SELECT l2.SBName As N1, l1.SBName As N2, l3.SBName As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) + 'FROM Ledger l1, Ledger l2, Ledger l3, Journal j ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'WHERE (l1.under=l2.under+'',''+cast(l2.id as varchar)) And (l2.under=l3.under+'',''+cast(l3.id as varchar)) And l2.under like ''4,13%'''  + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'And l3.SBName = ''Current Liability'' And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= ''' + @EndDate + ''' and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName, l3.SBName --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'ORDER BY l2.SBName, l1.SBName, l3.SBName'
	END
ELSE IF @Type = 'OL'
--Other Liabilities
	BEGIN
--Long Term Liabilities
		SET @STR = @STR + 'SELECT ''Long Term Liabilities'' As N1, l1.SBName As N2, ''Equity & Liabilities'' As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
		SET @STR = @STR + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under not like ''%,''+cast(l2.id as varchar)+'',%'' and l1.under not like ''%,''+cast(l2.id as varchar)) and ' 
		SET @STR = @STR + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.sbname=''Current Liability'' and l1.sbname<>''Accumulated Depreciation'' and l1.mgroup=''Liability'' and l1.LedgerAcc=1 and j.ApprovedBy>0 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l1.SBName --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)'
--Equity/Capital (Paid-up Capital, Share Premium, Share Deposite etc)
		SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10) + 'SELECT ''Equity'' As N1, l2.SBName As N2, ''Equity & Liabilities'' As N3,  ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
		SET @STR = @STR + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and  ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.MGroup = ''Capital'' and l2.SBName <> ''Capital'' and j.ApprovedBy>0  ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)'
--Equity/Capital (Retained Earnings)
		SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)+ 'SELECT ''Equity'' N1, ''Retained Earnings'' N2, ''Equity & Liabilities'' N3, ' + @Query3 + ' ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'ORDER BY N3, N1, N2'
	END
ELSE IF @Type = 'PC'
	BEGIN
--Equity/Capital Paid-up Capital
		SET @STR = @STR + 'SELECT l2.SBName As N1, l1.SBName As N2, l2.SBName As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
		SET @STR = @STR + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and  ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.MGroup = ''Capital'' and l2.SBName <> ''Capital'' and j.ApprovedBy>0 And l2.SBName = ''Paid-up Capital''' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName --HAVING (sum(j.credit-j.debt)>1 or sum(j.credit-j.debt)<-1)' + CHAR(13)
		SET @STR = @STR + 'ORDER BY l2.SBName, l1.SBName'
	END
ELSE IF @Type = 'SD'
	BEGIN
--Equity/Capital Share deposit money
		SET @STR = @STR + 'SELECT l2.SBName As N1, l1.SBName As N2, l2.SBName As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
		SET @STR = @STR + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and  ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.MGroup = ''Capital'' and l2.SBName <> ''Capital'' and j.ApprovedBy>0 And l2.SBName = ''Share deposit money''' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName ' + CHAR(13)
		SET @STR = @STR + 'ORDER BY l2.SBName, l1.SBName'
	END
ELSE
	BEGIN
--Equity/Capital Paid-up Capital
		SET @STR = @STR + 'SELECT l2.SBName As N1, l1.SBName As N2, ''Total Share Money'' As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
		SET @STR = @STR + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and  ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.MGroup = ''Capital'' and l2.SBName <> ''Capital'' and j.ApprovedBy>0 And l2.SBName = ''Paid-up Capital''' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName ' + CHAR(13)
--Equity/Capital Share deposit money
		SET @STR = @STR + CHAR(13) + 'Union All' + CHAR(13) + 'SELECT l2.SBName As N1, l1.SBName As N2, ''Total Share Money'' As N3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10) 
		SET @STR = @STR + 'FROM journal AS j, ledger AS l1, ledger as l2 ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'Where (l1.under like ''%,''+cast(l2.id as varchar)+'',%'' or l1.under like ''%,''+cast(l2.id as varchar)) and  ' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'l1.LedgerAcc=1 and l1.id=j.sid and j.jdate <= ''' + @EndDate + ''' and l2.MGroup = ''Capital'' and l2.SBName <> ''Capital'' and j.ApprovedBy>0 And l2.SBName = ''Share deposit money''' + CHAR(13) + CHAR(10)
		SET @STR = @STR + 'GROUP BY l2.SBName, l1.SBName ' + CHAR(13)
		SET @STR = @STR + 'ORDER BY l2.SBName, l1.SBName'
	END
--PRINT @STR
EXEC (@STR)
