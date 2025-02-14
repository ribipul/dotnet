USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_DISPOSAL_ASSET]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_DISPOSAL_ASSET]
** Name  :   dbo.USP_INSERT_DISPOSAL_ASSET
** Desc  :   
** Author:   Bipul
** Date  :   April 30, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_DISPOSAL_ASSET]
(
	@UserID As int = -1
	, @AssetNoID As int = -1
	, @DisposalDate As varchar(10) = ''
	, @ResaleAmount As float = 0
	, @Sold As bit = 0
	, @Description As varchar(700) = ''
	, @SoldById As int = -1
)
AS
BEGIN
	
	DECLARE @AssetPrice As float
		, @Profit As float
		, @AccDep As float
		, @BookValue As float
		, @AssetId As int
		, @DepRate As float
		, @DepStartDt As varchar(10)
		, @AssetCode As varchar(15)
		, @JID As int = -1

	DECLARE @AccDepID As int = 100
	DECLARE @CapGainId As int = 401
	DECLARE @CapLossId As int = 402
	
	SET NOCOUNT ON
	
	PRINT @DepStartDt
	
	SELECT @AssetId = AssetNo, @AssetPrice = Price, @DepRate = DepRate, @DepStartDt = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, DepStartDt),111), @AssetCode = AssetCode 
	FROM FixedAsset 
	WHERE Id = @AssetNoID
	
	IF @DepRate = 0
		BEGIN
			SET @BookValue = @AssetPrice
			SET @AccDep = 0
		END
	ELSE
		BEGIN
			SET @AccDep = @DepRate * DATEDIFF(MONTH, @DepStartDt, @DisposalDate)
			SET @BookValue = @AssetPrice - @AccDep
		END

	SET @Profit = @ResaleAmount - @BookValue
	--PRINT @DepStartDt
	UPDATE FixedAsset 
		SET StopDep = 1
		, SoldAmount = @ResaleAmount
		, DisposalDate = @DisposalDate
		, Profit = @Profit
		, Sold = @Sold
		, Remarks = @Description
	WHERE Id = @AssetNoId

	IF @AccDep > 0
		EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @AccDepID, @AssetID, @AccDep, @AssetNoID, @DisposalDate, @Description

	IF @Sold = 0
		BEGIN
			IF @Profit > 0
				BEGIN
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @CapGainId, @Profit, @AssetNoId, @DisposalDate, @Description
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
				END
			ELSE IF @Profit < 0
				BEGIN
					SET @Profit = ABS(@Profit)
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @CapLossId, @AssetId, @Profit, @AssetNoId, @DisposalDate, @Description
					
					SET @BookValue = @BookValue - ABS(@Profit)
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
				END
			ELSE
				EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
		END
	ELSE
		EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @CapLossId, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
	
	SET NOCOUNT OFF
END
GO
