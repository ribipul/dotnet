-- =============================================
-- Author:		Bipul
-- Create date: 		19.12.12
-- Description:		Product wise Accounts Receivablel Report
-- =============================================
--CREATE PROCEDURE [dbo].[USP_AccountsReceivableTodayRPT]
--(
--	@Name1 varchar(20), 
--	@Name2 varchar(20), 
--	@Name3 varchar(20), 
--	@Name4 varchar(20)
--)
--AS
--BEGIN
DECLARE	@Name1 varchar(20), 
		@Name2 varchar(20), 
		@Name3 varchar(20), 
		@Name4 varchar(20),
		@Type varchar(3) = 'PRO'
		
DECLARE @STR varchar(8000)

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
SET @STR = 'SELECT ' + @Name1 + ' as Name1, ' + @Name2 + ' as Name2, (sum(debt)-sum(credit)) AS TD, s.sdate ' + CHAR(13)
SET @STR = @STR + 'FROM ledger AS l, company AS c, journal AS j, sales AS s ' + CHAR(13)
SET @STR = @STR + 'WHERE j.jdate <= GETDATE() And j.Notify = ''AR'' And s.tno = j.tno And s.pcode = L.id And s.cid = c.id And s.DealInfoID = 0 And j.ApprovedBy > 0' + CHAR(13)
SET @STR = @STR + 'GROUP BY ' + @Name1 + ', ' + @Name2 + ', s.sdate HAVING (sum(debt)-sum(credit)) >= 1 OR (sum(debt)-sum(credit)) <= -1' + CHAR(13)

----SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'SELECT ' + @Name3 + ' as name1, ' + @Name4 + ' as name2, (sum(debt)-sum(credit)) AS TD, d.DealOpenOn ' + CHAR(13) + CHAR(10) 
----SET @STR = @STR + 'FROM Company AS c, Journal AS j, DealInfo AS d ' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'WHERE d.MerchantID=c.id AND j.TNO=d.DealID AND j.Jid IN(SELECT jid FROM journal WHERE Notify = ''Deal'') AND j.jdate <= GETDATE() And j.Notify = ''AR'' AND j.ApprovedBy > 0 ' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'GROUP BY  ' + @Name3 +', ' + @Name4 + ', d.DealOpenOn HAVING (sum(debt)-sum(credit))<>0 '

----SET @STR = @STR + CHAR(13) + CHAR(10) + 'Union All' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'SELECT ' + @Name1 + ' as name1, ' + @Name2 + ' as name2, (sum(debt)-sum(credit)) AS TD, s.sdate ' + CHAR(13) + CHAR(10) 
----SET @STR = @STR + 'FROM CustomerInfo cu INNER JOIN Ledger l INNER JOIN Sales s INNER JOIN Journal j ON s.TNO = j.Tno ON l.Id = s.PCode ON cu.CustID = s.CId INNER JOIN ' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'DealProductInfo dp ON s.DealInfoID = dp.DealInfoID INNER JOIN DealInfo d ON dp.DealID = d.DealID INNER JOIN Company c ON d.MerchantID = c.Id ' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'WHERE j.JDate <= GETDATE() AND j.ApprovedBy > 0 AND j.Notify = ''AR'' ' + CHAR(13) + CHAR(10)
----SET @STR = @STR + 'GROUP BY  ' + @Name1 +', ' + @Name2 + ', s.sdate HAVING (sum(debt)-sum(credit))<>0 ' + CHAR(13) + CHAR(10)
SET @STR = @STR + 'ORDER BY ' + @Name1 + ', ' + @Name2
PRINT @STR
--EXEC (@STR)
--END

--SELECT l.sbname as product, c.name as company, sum(j.debt-j.credit) AS TD,s.sdate 
--FROM ledger AS l, company AS c, journal AS j, sales AS s 
--Where j.jdate <= GETDATE() And j.Notify = 'AR' And s.tno = j.tno And s.pcode = L.id And s.cid = c.id --And j.ApprovedBy > 0
--GROUP BY  l.sbname, c.name,s.sdate HAVING (sum(debt)-sum(credit)) >= 1 OR (sum(debt)-sum(credit)) <= -1 
--ORDER BY l.sbname, c.name

--USP_AccountsReceivableTodayRPT 'PRO'
select * from PrCoWiseRevenue