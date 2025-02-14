USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_LedgerList]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LedgerList]
** Name  :   dbo.USP_LedgerList
** Desc  :   
** Author:   Bipul
** Date  :   March 28, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LedgerList]
(
	@AccountsDep As bit = 0
	, @UserAdmin As bit = 0
	, @MGroup As varchar(10) = ''
	, @All As char(3) = ''
	, @InvoiceLedger As char(1) = ''
	, @Tax As tinyint = 0
)
AS 
BEGIN
	IF @Tax = 0
		BEGIN
			IF @MGroup = ''
				BEGIN
					IF @AccountsDep = 1 OR @UserAdmin = 1
						BEGIN
							;WITH Ledger_CTE AS (
								SELECT 0 As Serial, 0 As ID, 'All' As LadgerName
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Asset'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Capital'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Expense'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Liability'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Revenue'
								UNION
								SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial, id, SBName As LadgerName FROM ledger WHERE ledgerAcc=1 --And MGroup='Revenue'
							)
							SELECT ID, LadgerName FROM Ledger_CTE
							ORDER BY Serial
						END
					ELSE
						BEGIN
							;WITH Ledger_CTE AS (
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Revenue'
								UNION
								SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial, id, SBName As LadgerName 
								FROM ledger 
								WHERE ledgerAcc=1 and MGroup='Revenue'
							)
							SELECT ID, LadgerName FROM Ledger_CTE
							ORDER BY Serial
						END
				END
			ELSE
				BEGIN
					IF @All = 'All'
						BEGIN
							IF @InvoiceLedger = 'I'
								BEGIN
									;WITH Ledger_CTE AS (
										SELECT DISTINCT l.id, l.sbname 
										FROM ledger l INNER JOIN sales s ON l.id=s.pcode
										WHERE l.mgroup=@MGroup and l.LedgerAcc=1
										--SELECT 0 As Serial, 0 As ID, 'All' As LadgerName								
									)
									,SalesLesger_CTE AS (
										SELECT 0 As Serial, 0 As ID, 'All' As LadgerName
										UNION
										SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial,id, SBName As LadgerName 
										FROM Ledger_CTE 
									)
									SELECT ID, LadgerName FROM SalesLesger_CTE
									ORDER BY Serial
								END
							ELSE
								BEGIN
									;WITH Ledger_CTE AS (
										SELECT 0 As Serial, 0 As ID, 'All' As LadgerName
										UNION
										SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial,id, SBName As LadgerName 
										FROM ledger 
										WHERE ledgerAcc=1 and MGroup=@MGroup
									)
									SELECT ID, LadgerName FROM Ledger_CTE
									ORDER BY Serial
								END
						END
					ELSE
						BEGIN
							SELECT id, SBName As LadgerName 
							FROM ledger 
							WHERE ledgerAcc=1 and MGroup=@MGroup
							ORDER BY SBName
						END
				END
		END
	ELSE
		BEGIN
			DECLARE @LedgerLiabilitySalesTaxes As varchar(5) = '%,693'
			
			SELECT  id,SBName FROM Ledger WHERE ledgerAcc=1 and Under like @LedgerLiabilitySalesTaxes order by sbname
		END
END
GO
