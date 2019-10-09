SELECT l1.id, l1.SBName 
FROM Ledger l1, Ledger l2
WHERE l1.MGroup='Expense' and l1.levelno=2 and l1.ledgerAcc=0 and l2.Id=630 and l1.under like '%,' + cast(l2.id as varchar) + '%'
order by l1.sbname


SELECT s.Id, s.SBName, sum(j.debt-j.credit) AS TD--,j.jdate 
FROM Ledger AS s, journal AS j 
WHERE s.MGroup='Expense' and (s.under like '%,453' or s.under like '%,453%') and s.ledgerAcc=1 and j.jdate BETWEEN '1/1/2013'  And '12/31/2013' and j.ApprovedBy>0 and s.id=j.sid 
GROUP BY s.Id, s.sbname 
--ORDER BY s.sbname,j.jdate
Union All
SELECT s.Id, s.SBName, sum(j.debt-j.credit) AS TD--,j.jdate 
FROM Ledger AS s, journal AS j
WHERE s.MGroup='Expense' and (s.under like '%,635' or s.under like '%,635%') and s.ledgerAcc=1 and j.jdate BETWEEN '1/1/2013'  And '12/31/2013' and j.ApprovedBy>0 and s.id=j.sid 
GROUP BY s.Id, s.sbname 
ORDER BY s.sbname--,j.jdate



--SET @STR = @STR + 'SELECT l1.SBName As Name1, s.SBName As Name2, l2.SBName As Name3, ' + @Query2  + ' ' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'FROM Ledger AS s, journal AS j, Ledger l1, Ledger l2 ' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'WHERE s.MGroup=''Expense'' and l1.levelno=2 and l1.ledgerAcc=0 and l2.Id=630 and l1.under like ''%,'' + cast(l2.id as varchar) + ''%''' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'and (s.under like ''%,''+cast(l1.id as varchar) or s.under like ''%,''+cast(l2.id as varchar)+''%'') and s.ledgerAcc=1 and j.jdate BETWEEN ''1/1/2013''  And ''12/31/2013'' and j.ApprovedBy>0 and s.id=j.sid ' + CHAR(13) + CHAR(10)
--SET @STR = @STR + 'GROUP BY l1.SBName, s.sbname, l2.SBName' + CHAR(13) + CHAR(10)

