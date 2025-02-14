-- =============================================
-- Author:				Bipul
-- Create date: 		28.05.2014
-- Description:			Cash/Bank List
-- =============================================
CREATE PROCEDURE [dbo].[USP_CASH_BANK_LIST]
(
	@Type	VARCHAR(5)
)
AS
BEGIN
	DECLARE @STRQuery	VARCHAR(1000) = ''
	
	IF @Type = 'Asset'
		SET @STRQuery = @STRQuery + 'SELECT ID, SBName As Name FROM Ledger WHERE id IN (411,46)'
	ELSE
		BEGIN
			SET @STRQuery = @STRQuery + 'SELECT ID, SBName As Name FROM Ledger WHERE id IN (SELECT id FROM Ledger WHERE Under LIKE ''1,12,410%'') ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'UNION' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT ID, SBName As Name FROM Ledger WHERE id = 46' + CHAR(13)
			SET @STRQuery = @STRQuery + 'UNION' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT ID, SBName As Name FROM Ledger WHERE Under LIKE ''1,12,370%'' AND ID <> 272' + CHAR(13)
		END
	SET @STRQuery = @STRQuery + 'ORDER BY ID, SBName'
	
	EXEC (@STRQuery)
END