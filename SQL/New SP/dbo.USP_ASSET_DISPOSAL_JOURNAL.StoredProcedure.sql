USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_ASSET_DISPOSAL_JOURNAL]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ASSET_DISPOSAL_JOURNAL]
** Name  :   dbo.USP_ASSET_DISPOSAL_JOURNAL
** Desc  :   
** Author:   Bipul
** Date  :   April 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ASSET_DISPOSAL_JOURNAL]
(
	@UserID As int = -1
	, @AssetNo1 As int = -1
	, @AssetNo2 As int = -1
	, @Amount As float = 0
	, @AssetNoId As int = -1
	, @DisposalDate As varchar(10) = ''
	, @Description As varchar(700) = ''
)
AS
BEGIN 
	
	DECLARE @JID As int = -1
	
	SET NOCOUNT ON
	
	SELECT @JID = MAX(Jid)+1 FROM Journal
	
	INSERT INTO Journal(Jid, Sid, Description, Debt, Credit, JDate, TNO, Notify, PostDate, UserID)
	VALUES(@JID, @AssetNo1, @Description, @Amount, 0, @DisposalDate, @AssetNoID, 'FixedAsset', GETDATE(), @UserID)
	
	INSERT INTO Journal(Jid, Sid, Debt, Credit, JDate, TNO, Notify, PostDate, UserID)
	VALUES(@JID, @AssetNo2, 0, @Amount, @DisposalDate, @AssetNoID, 'FixedAsset', GETDATE(), @UserID)
	
	EXEC USP_MakeJournalVoucher @JID, @DisposalDate
	
	SET NOCOUNT OFF
END
GO
