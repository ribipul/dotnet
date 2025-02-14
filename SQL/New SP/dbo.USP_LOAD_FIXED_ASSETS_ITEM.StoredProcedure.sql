USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_LOAD_FIXED_ASSETS_ITEM]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LOAD_FIXED_ASSETS_ITEM]
** Name  :   dbo.USP_LOAD_FIXED_ASSETS_ITEM
** Desc  :   
** Author:   Bipul
** Date  :   April 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LOAD_FIXED_ASSETS_ITEM]
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT l.id As ItemID, l.sbname As ItemName
	, (SELECT FORMAT(id,'0000')
		FROM ledger 
		WHERE id = (
			SELECT REVERSE(LEFT(REVERSE(under), charindex(',', REVERSE(under)) - 1))
			FROM ledger 
			WHERE id = l.id)) As AssetType
	, (SELECT sbname
		FROM ledger 
		WHERE id = (
			SELECT REVERSE(LEFT(REVERSE(under), charindex(',', REVERSE(under)) - 1))
			FROM ledger 
			WHERE id = l.id)) As AssetName
	FROM ledger l
	WHERE l.under LIKE '%,30,%' OR l.under LIKE '%,30' And l.LedgerAcc=1 And l.id NOT IN(99,100) -- Except 'Depreciation' & 'Accumulated Depreciation'
	ORDER BY sbname
	
	SET NOCOUNT OFF
END
GO
