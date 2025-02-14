USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_DISPOSAL_RESALE]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_DISPOSAL_RESALE]
** Name  :   dbo.USP_DISPOSAL_RESALE
** Desc  :   
** Author:   Bipul
** Date  :   April 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_DISPOSAL_RESALE]
(
	@UserID As int = -1
	, @AssetNoID As int = -1
	, @DisposalDate As varchar(10) = ''
	, @ResaleAmount As float = 0
	, @Sold As bit = 0
	, @Description As varchar(700) = ''
	, @SoldById As int = -1
	, @Resel As smallint = 1
)
AS
BEGIN
	
	SET NOCOUNT ON
	
	DECLARE @AssetPrice As float
		, @Profit As float
		, @AccDep As float
		, @BookValue As float
		, @AssetId As int
		, @DepRate As float
		, @DepStartDt As varchar(10)

	DECLARE @AccDepID As int = 100
	DECLARE @CapGainId As int = 401
	DECLARE @CapLossId As int = 402

	SELECT @AssetId = AssetNo, @AssetPrice = Price, @DepRate = DepRate, @DepStartDt = DepStartDt
	FROM FixedAsset 
	WHERE Id = @AssetNoID
	PRINT @DepRate
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

	IF @Resel = 1
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
