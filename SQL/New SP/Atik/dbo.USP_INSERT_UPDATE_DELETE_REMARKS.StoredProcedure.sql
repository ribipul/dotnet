USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_UPDATE_DELETE_REMARKS]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_UPDATE_DELETE_REMARKS]
** Name  :   dbo.USP_INSERT_UPDATE_DELETE_REMARKS
** Desc  :   
** Author:   Bipul
** Date  :   April 09, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_UPDATE_DELETE_REMARKS]
(
	@Action As char(1) = ''
	, @RemarksID As int = 0
	, @RemarkDate As varchar(10) = ''
	, @Remarks As varchar(2000) = ''
	, @IncoiceID As int = 0
	, @UserID As int = ''
)
AS
BEGIN
	IF @Action = 'I'
		BEGIN
			INSERT INTO InvoiceRemarks(InvoiceId,RemarkDate, Remarks, UserId) 
			VALUES(@IncoiceID, @RemarkDate, @Remarks, @UserID)
		END
	ELSE IF @Action = 'U'
		BEGIN
			UPDATE InvoiceRemarks
				SET RemarkDate = @RemarkDate,
				Remarks = @Remarks
			WHERE Id = @RemarksID
		END
	ELSE IF @Action = 'D'
		DELETE InvoiceRemarks WHERE Id = @RemarksID
	ELSE
		SELECT ID, RemarkDate, Remarks, InvoiceId FROM InvoiceRemarks WHERE InvoiceId = @IncoiceID
END
GO
