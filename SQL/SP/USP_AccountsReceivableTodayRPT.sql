-- ==========================================================
-- Author:				Bipul
-- Create date: 		18.03.2014
-- Description:			Accounts Receivablel Report Today
-- ==========================================================
CREATE PROCEDURE [dbo].[USP_AccountsReceivableTodayRPT]
(
	@Type varchar(3) = 'COM'
)
AS
BEGIN
	DECLARE	@Name1 varchar(20) = '', 
			@Name2 varchar(20) = ''
			
	DECLARE @STR varchar(8000) = ''

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
	SET @STR = @STR + 'WHERE j.jdate <= GETDATE() And j.Notify = ''AR'' And s.tno = j.tno And s.pcode = L.id And s.cid = c.id' + CHAR(13)
	SET @STR = @STR + 'GROUP BY ' + @Name1 + ', ' + @Name2 + ', s.sdate HAVING (sum(debt)-sum(credit)) >= 1 OR (sum(debt)-sum(credit)) <= -1 ' + CHAR(13)
	SET @STR = @STR + 'ORDER BY ' + @Name1 + ', ' + @Name2

	EXEC (@STR)
END