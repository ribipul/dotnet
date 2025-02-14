USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_GENERATE_ASSET_CODE]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_GENERATE_ASSET_CODE]
** Name  :   dbo.USP_GENERATE_ASSET_CODE
** Desc  :   
** Author:   Bipul
** Date  :   April 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_GENERATE_ASSET_CODE]
(
	@AssetTypeID As int = 318
	, @AssetType As varchar(3) = ''
)
AS
BEGIN
	SET NOCOUNT ON
	
	IF @AssetType = ''
		SELECT @AssetType = LEFT(SBName, 3) FROM Ledger WHERE ID = @AssetTypeID
	
	--SELECT max(Substring(AssetCode, 1, 3)) + '-' + FORMAT(max(Substring(AssetCode, 5, 3))+1, '000') + '-' + FORMAT((Select max(Substring(AssetCode, 9, 10)) As MTCode from FixedAsset)+1, '0000') As AssteNo
	SELECT @AssetType + '-' + CASE WHEN MAX(AssetCode) IS NULL THEN '001' ELSE FORMAT(max(Substring(AssetCode, 5, 3))+1, '000') END + '-' + FORMAT((Select max(Substring(AssetCode, 9, 10)) As MTCode from FixedAsset)+1, '0000') As AssteNo
	FROM FixedAsset 
	WHERE AssetType = @AssetTypeID
	
	SET NOCOUNT OFF
END
GO
