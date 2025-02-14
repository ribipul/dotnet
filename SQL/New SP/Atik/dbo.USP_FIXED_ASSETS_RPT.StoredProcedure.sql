USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_FIXED_ASSETS_RPT]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_FIXED_ASSETS_RPT]
** Name  :   dbo.USP_FIXED_ASSETS_RPT
** Desc  :   
** Author:   Bipul
** Date  :   May 31, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_FIXED_ASSETS_RPT]
(
	@FromDate As varchar(10) = '5/1/2012'
)
AS
BEGIN
	DECLARE @Name1 As varchar(100)
	DECLARE @Name2 As varchar(100)
	DECLARE @AssetCode As varchar(15)
	DECLARE @Price As float
	DECLARE @DepRate As float
	DECLARE @DepStartDt As varchar(10)
	DECLARE @DepEndtDt As varchar(10)
	DECLARE @DepLife As smallint
	DECLARE @NoDep As bit

	DECLARE @MNO As smallint
	DECLARE @AccDep As float
	DECLARE @Amount As float
	DECLARE @AmountYrTD As float

	DECLARE @FixedAssets TABLE(
		Name1 varchar(100) NULL
		, Name2 varchar(100) NULL
		, Name3 varchar(100) NULL
		, Price float NULL
		, AmountYrTD float NULL
		, AccDep float NULL
		, Amount float NULL
		, DepStartDt varchar(10) NULL
	)
	DECLARE @FixedAsset CURSOR

	SET NOCOUNT ON
	
	SET @FixedAsset = CURSOR FAST_FORWARD FOR
	SELECT l1.SBName,l.sbname,f.AssetCode,f.price,f.depRate,CONVERT(varchar(10),f.depStartDt,111),CONVERT(varchar(10),f.depEndDt,111),f.deplife,f.NoDep 
	FROM ledger l
		INNER JOIN FixedAsset f ON f.assetNo=l.id
		INNER JOIN ledger l1 ON f.assetType=l1.id
	WHERE  f.depStartDt<=@FromDate and StopDep=0 
	ORDER BY l1.SBName,l.sbname
	OPEN @FixedAsset

	FETCH NEXT FROM @FixedAsset
	INTO @Name1, @Name2, @AssetCode, @Price, @DepRate, @DepStartDt, @DepEndtDt, @DepLife, @NoDep

	WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @MNO = DATEDIFF(MONTH, @DepStartDt, @FromDate)
			IF DAY(@FromDate) >= 15
				SET @MNO = @MNO + 1
			IF @MNO < @DepLife		--If Depreciation life is not completed
				BEGIN
					SET @AccDep = @DepRate * @MNO
					SET @Amount = @Price - @AccDep
				END
			ELSE					--If Depreciation life is completed
				BEGIN
					SET @AccDep = @Price
					SET @Amount = 0
				END
			IF @NoDep = 1
				BEGIN
					SET @Amount = 0
					SET	@AccDep = 0
					SET @AmountYrTD = 0
				END
			ELSE
				SET @AmountYrTD = (12 * 100) / @DepLife
			
			INSERT INTO @FixedAssets (Name1,Name2,Name3,Price,AmountYrTD,AccDep,Amount,DepStartDt)
			VALUES (@Name1, @Name2, @AssetCode, @Price, @AmountYrTD, @AccDep, @Amount, @DepStartDt)
			
			FETCH NEXT FROM @FixedAsset
			INTO @Name1, @Name2, @AssetCode, @Price, @DepRate, @DepStartDt, @DepEndtDt, @DepLife, @NoDep
		END

	CLOSE @FixedAsset
	DEALLOCATE @FixedAsset
	
	SELECT Name1, Name2, Name3, Price As M1, AmountYrTD As M2, AccDep As M3, Amount As M4, DepStartDt As DateS FROM @FixedAssets	
	SET NOCOUNT OFF
END
GO
