USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_ASSET_JOURNAL]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ASSET_JOURNAL]
** Name  :   dbo.USP_ASSET_JOURNAL
** Desc  :   
** Author:   Bipul
** Date  :   April 27, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ASSET_JOURNAL]
(
	@UserID As int = -1
	, @NoDep As bit = 0
	, @AssetCode As varchar(15) = ''
	, @AssetNo1 As int = -1
	, @AssetNo2 As int = -1
	, @Price As float = 0
	, @Description As varchar(700) = ''
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @DepStartDt As varchar(10) = ''
		, @LastPosted As varchar(10) = ''
		, @DepDate As varchar(10) = ''
		, @TNO As int = -1
		, @JID As int = -1

	SELECT @TNO = id, @DepStartDt = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, DepStartDt),111), @LastPosted = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, LastPosted),111)
	FROM FixedAsset 
	WHERE assetCode = @AssetCode

	SELECT @JID = MAX(Jid)+1 FROM Journal

	IF @LastPosted IS NULL
		BEGIN
			INSERT INTO Journal(Jid, Sid, Description, Debt, Credit, JDate, TNO, Notify, PostDate, UserID)
			VALUES(@JID, @AssetNo1, @Description, @Price, 0, @DepStartDt, @TNO, 'FixedAsset', GETDATE(), @UserID)
			
			INSERT INTO Journal(Jid, Sid, Debt, Credit, JDate, TNO, Notify, PostDate, UserID)
			VALUES(@JID, @AssetNo2, 0, @Price, @DepStartDt, @TNO, 'FixedAsset', GETDATE(), @UserID)
			
			EXEC USP_MakeJournalVoucher @JID, @DepStartDt
			
			IF @NoDep = 1
				BEGIN
					SET @DepDate = MONTH(@DepStartDt) + '/28/' + YEAR(@DepStartDt)
					UPDATE FixedAsset 
						SET LastPosted = @DepDate
					WHERE AssetCode = @AssetCode
				END
		END
	SET NOCOUNT OFF
END
GO
