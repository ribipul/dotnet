-- =============================================
-- Author:				Bipul
-- Create date: 		29.05.2014
-- Description:			Edit Ledger
-- =============================================
CREATE PROCEDURE [dbo].[USP_EditLedger]
(
	@MGroup varchar(50)
)
AS

IF @MGroup <> ''
	select distinct l1.ID, l1.SBName, l1.Under, l1.LevelNo, l1.MGroup, l2.id As UnderID, 
	l2.SBName As UnderLedgerName, l1.LedgerAcc
	from Ledger l1, Ledger l2 
	where (l1.under=l2.under+','+cast(l2.id as varchar) OR l1.under=cast(l2.id as varchar))	 And l1.MGroup = @MGroup
	Union
	select l1.ID, l1.SBName, l1.Under, l1.LevelNo, l1.MGroup, '' As UnderID, '' As UnderLedgerName, l1.LedgerAcc 
	from Ledger l1
	where l1.levelNo IN(0) And l1.MGroup = @MGroup
	order by l1.SBName
	
ELSE
	select distinct l1.ID, l1.SBName, l1.Under, l1.LevelNo, l1.MGroup, l2.id As UnderID, 
	l2.SBName As UnderLedgerName, l1.LedgerAcc
	from Ledger l1, Ledger l2 
	where (l1.under=l2.under+','+cast(l2.id as varchar) OR l1.under=cast(l2.id as varchar))	--(l1.under=l2.under+','+cast(l2.id as varchar)) 
	Union
	select l1.ID, l1.SBName, l1.Under, l1.LevelNo, l1.MGroup, '' As UnderID, '' As UnderLedgerName, l1.LedgerAcc
	from Ledger l1 
	where l1.levelNo IN(0) 
	order by l1.SBName