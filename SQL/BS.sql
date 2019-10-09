SELECT l3.SBName As N1, l2.SBName As N2, l3.MGroup As N3, 
sum(case when j.jdate<'02/01/2013' then (j.debt-j.credit) else 0 end) AS M1, 
sum(case when j.jdate<'03/01/2013' then (j.debt-j.credit) else 0 end) AS M2, 
sum(case when j.jdate<'04/01/2013' then (j.debt-j.credit) else 0 end) AS M3, 
sum(case when j.jdate<'05/01/2013' then (j.debt-j.credit) else 0 end) AS M4, 
sum(case when j.jdate<'06/01/2013' then (j.debt-j.credit) else 0 end) AS M5, 
sum(case when j.jdate<'07/01/2013' then (j.debt-j.credit) else 0 end) AS M6, 
sum(case when j.jdate<'08/01/2013' then (j.debt-j.credit) else 0 end) AS M7, 
sum(case when j.jdate<'09/01/2013' then (j.debt-j.credit) else 0 end) AS M8, 
sum(case when j.jdate<'10/01/2013' then (j.debt-j.credit) else 0 end) AS M9, 
sum(case when j.jdate<'11/01/2013' then (j.debt-j.credit) else 0 end) AS M10, 
sum(case when j.jdate<'12/01/2013' then (j.debt-j.credit) else 0 end) AS M11, 
sum(case when j.jdate<'01/01/2014' then (j.debt-j.credit) else 0 end) AS M12 
FROM Ledger l1, Ledger l2, Ledger l3, Journal j 
WHERE (l1.under=l2.under+','+cast(l2.id as varchar) OR l1.under Like '' + l2.under+','+cast(l2.id as varchar) + '%') 
And (l1.under like '%,'+cast(l2.id as varchar)+',%' or l1.under like '%,'+cast(l2.id as varchar)) And l2.Under = l3.Under+','+cast(l3.id as varchar)
And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= '12/31/2013' and j.ApprovedBy>0 
--And (l2.under='1,12')
And l3.SBName <> 'Prepaid Loan & Advance' 
And l3.MGroup = 'Asset' 
GROUP BY l2.SBName, l3.SBName, l3.MGroup HAVING sum(j.debt-j.credit)<>0
--Union All
--SELECT 'Fixed Assets' As N1, (Select 'Less Accumulated Depreciation') As N2, 'Asset' As N3, 
--sum(case when j.jdate<'02/01/2013' then (j.credit-j.debt) else 0 end) AS M1, 
--sum(case when j.jdate<'03/01/2013' then (j.credit-j.debt) else 0 end) AS M2, 
--sum(case when j.jdate<'04/01/2013' then (j.credit-j.debt) else 0 end) AS M3, 
--sum(case when j.jdate<'05/01/2013' then (j.credit-j.debt) else 0 end) AS M4, 
--sum(case when j.jdate<'06/01/2013' then (j.credit-j.debt) else 0 end) AS M5, 
--sum(case when j.jdate<'07/01/2013' then (j.credit-j.debt) else 0 end) AS M6, 
--sum(case when j.jdate<'08/01/2013' then (j.credit-j.debt) else 0 end) AS M7, 
--sum(case when j.jdate<'09/01/2013' then (j.credit-j.debt) else 0 end) AS M8, 
--sum(case when j.jdate<'10/01/2013' then (j.credit-j.debt) else 0 end) AS M9, 
--sum(case when j.jdate<'11/01/2013' then (j.credit-j.debt) else 0 end) AS M10, 
--sum(case when j.jdate<'12/01/2013' then (j.credit-j.debt) else 0 end) AS M11, 
--sum(case when j.jdate<'01/01/2014' then (j.credit-j.debt) else 0 end) AS M12 
--FROM journal AS j, ledger AS l 
--WHERE l.under like '3,1075%' and l.id=j.sid and j.jdate >= '4/1/2000' and j.jdate< '12/31/2013' and j.ApprovedBy>0 
--GROUP BY l.MGroup HAVING sum(j.debt-j.credit)<>0
--Union All
--SELECT l2.SBName As N1, l1.SBName As N2, l2.MGroup As N3, 
--sum(case when j.jdate<'02/01/2013' then (j.debt-j.credit) else 0 end) AS M1, 
--sum(case when j.jdate<'03/01/2013' then (j.debt-j.credit) else 0 end) AS M2, 
--sum(case when j.jdate<'04/01/2013' then (j.debt-j.credit) else 0 end) AS M3, 
--sum(case when j.jdate<'05/01/2013' then (j.debt-j.credit) else 0 end) AS M4, 
--sum(case when j.jdate<'06/01/2013' then (j.debt-j.credit) else 0 end) AS M5, 
--sum(case when j.jdate<'07/01/2013' then (j.debt-j.credit) else 0 end) AS M6, 
--sum(case when j.jdate<'08/01/2013' then (j.debt-j.credit) else 0 end) AS M7, 
--sum(case when j.jdate<'09/01/2013' then (j.debt-j.credit) else 0 end) AS M8, 
--sum(case when j.jdate<'10/01/2013' then (j.debt-j.credit) else 0 end) AS M9, 
--sum(case when j.jdate<'11/01/2013' then (j.debt-j.credit) else 0 end) AS M10, 
--sum(case when j.jdate<'12/01/2013' then (j.debt-j.credit) else 0 end) AS M11, 
--sum(case when j.jdate<'01/01/2014' then (j.debt-j.credit) else 0 end) AS M12 
--FROM Ledger l1, Ledger l2, Journal j 
--WHERE (l1.under='1,12') And (l1.under=l2.under+','+cast(l2.id as varchar)) 
--And l1.id=j.sid and l1.LedgerAcc=1 And j.jdate <= '12/31/2013' and j.ApprovedBy>0 
--GROUP BY l1.SBName, l2.SBName, l2.MGroup HAVING sum(j.debt-j.credit)<>0


--SELECT distinct l2.id,l2.sbname FROM  ledger as l2,ledger as l3 Where (l2.under like '%,'+cast(l3.id as varchar)+',%' or l2.under like '%,'+cast(l3.id as varchar)) and l2.LedgerAcc=0 and l3.sbname='Fixed Assets' order by l2.sbname

----SELECT Sum(j.debt-j.credit) AS TD FROM journal AS j, ledger AS l1,ledger as l2 Where (l1.under like '%,'+cast(l2.id as varchar)+',%' or l1.under like '%,'+cast(l2.id as varchar)) and l1.LedgerAcc=1 and l1.id=j.sid and j.jdate >= '4/1/2000' and j.jdate < '1/1/2013' and l2.sbname = 'Computer & Accessories' and j.ApprovedBy>0

----SELECT Sum(j.debt-j.credit) AS TD, month(j.jdate) AS M,year(j.jdate) as Y FROM journal AS j, ledger AS l1,ledger as l2 Where (l1.under like '%,'+cast(l2.id as varchar)+',%' or l1.under like '%,'+cast(l2.id as varchar)) and l1.LedgerAcc=1 and l1.id=j.sid and j.jdate between '1/1/2013' and '12/31/2013' and l2.sbname = 'Computer & Accessories' and j.ApprovedBy>0 GROUP BY month(j.jdate),year(j.jdate) ORDER BY year(j.jdate),month(j.jdate)


--SELECT distinct l1.id,l1.sbname FROM journal AS j, ledger AS l1,ledger as l2 Where (l1.under like '%,'+cast(l2.id as varchar)+',%' or l1.under like '%,'+cast(l2.id as varchar)) and l1.LedgerAcc=1 and l1.id=j.sid and j.jdate >= '4/1/2000' and j.jdate <= '6/30/2013' and j.ApprovedBy>0 and l2.sbname = 'Other Assets' order by l1.sbname

--SELECT sum(debt-credit) AS TD FROM journal Where  jdate >= '4/1/2000' and jdate < '1/1/2013' and ApprovedBy>0 and sid=129


--USP_BalanceSheetRPT_V1 '1/1/2013', '12/31/2013', 63227448.1000001, 69079816.6100001, 74242400.4700001, 82003250.5400001, 88520881.9000001, 86127671.6100001, 91636419.41, 96019710.28, 61473670.6800002, 67480924.3500002, 74636573.4900001, 74768573.4900001

USP_RevenueExpense '1/1/2013', '4/30/2013', 'Expense'
GO
USP_RevenueExpense '12/1/2013', '4/30/2013', 'Revenue'



USP_BalanceSheetRPT '1/1/2012', '12/31/2012', 63227448.1000001, 69079816.6100001, 74242400.4700001, 82003250.5400001, 88520881.9000001, 86127671.6100001, 91636419.41, 96019710.28, 61473670.6800002, 67480924.3500002, 74636573.4900001, 74768573.4900001

USP_BalanceSheetRPT '1/1/2012', '12/31/2012', 45379664.6400001, 49750644.0200001, 55021641.3500001, 61209067.1800001, 66882129.2100001, 27529974.4100001, 32430406.8800001, 34357917.8500001, 41490445.8000001, 45383956.4300001, 51337009.3200002, 57273199.2200001

