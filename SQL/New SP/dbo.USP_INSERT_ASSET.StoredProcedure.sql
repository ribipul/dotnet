USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_ASSET]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_ASSET]
** Name  :   dbo.USP_INSERT_ASSET
** Desc  :   
** Author:   Bipul
** Date  :   April 27, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_ASSET]
(
	@Action As varchar(10) = 'INSERT'
	, @UserID As int = -1
	, @NoDep As bit
	, @AssetCode As varchar(15)
	, @AssetNo As int
	, @AssetType As int
	, @PurchasedDt As varchar(10)
	, @Price As float
	, @DepStartDt As varchar(10)
	, @Supplier As varchar(100)
	, @InvoiceNo As varchar(30)
	, @LabelNo As varchar(30)
	, @Description As varchar(700)
	, @DepRate As float
	, @DepLife smallint
	, @DepEndDt As varchar(10)
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	IF @Action = 'INSERT'
		BEGIN
			IF @NoDep = 0
				BEGIN
					INSERT INTO FixedAsset(AssetCode,AssetNo,AssetType,PurchasedDt,Price,DepRate,DepStartDt,DepLife,DepEndDt,Supplier,InvoiceNo,LabelNo,Description)
					VALUES (@AssetCode, @AssetNo, @AssetType, @PurchasedDt, @Price, @DepRate, @DepStartDt, @DepLife, @DepEndDt, @Supplier, @InvoiceNo, @LabelNo, @Description)
				END
			ELSE
				BEGIN
					INSERT INTO FixedAsset(AssetCode,AssetNo,AssetType,PurchasedDt,Price,DepStartDt,Supplier,InvoiceNo,LabelNo,Description,NoDep)
					VALUES (@AssetCode, @AssetNo, @AssetType, @PurchasedDt, @Price, @DepStartDt, @Supplier, @InvoiceNo, @LabelNo, @Description, 1)
				END
		END
	ELSE
		BEGIN
			IF @NoDep = 0
				BEGIN
					UPDATE FixedAsset
						SET AssetNo = @AssetNo
						, AssetType = @AssetType
						, PurchasedDt = @PurchasedDt
						, Price = @Price
						, DepRate = @DepRate
						, DepStartDt = @DepStartDt
						, DepLife = @DepLife
						, DepEndDt = @DepEndDt
						, Supplier = @Supplier
						, InvoiceNo = @InvoiceNo
						, LabelNo = @LabelNo
						, Description = @Description
						, NoDep = 0
					WHERE AssetCode = @AssetCode
				END
			ELSE
				BEGIN
					UPDATE FixedAsset
						SET AssetNo = @AssetNo
						, AssetType = @AssetType
						, PurchasedDt = @PurchasedDt
						, Price = @Price
						, DepRate = 0
						, DepStartDt = @DepStartDt
						, DepLife = 0
						, DepEndDt = NULL
						, Supplier = @Supplier
						, InvoiceNo = @InvoiceNo
						, LabelNo = @LabelNo
						, Description = @Description
						, NoDep = 1
					WHERE AssetCode = @AssetCode
				END
		END
	SET NOCOUNT OFF
END
GO
