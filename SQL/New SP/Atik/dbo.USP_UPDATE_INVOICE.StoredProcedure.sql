USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_INVOICE]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UPDATE_INVOICE]
** Name  :   dbo.USP_UPDATE_INVOICE
** Desc  :   
** Author:   Bipul
** Date  :   April 12, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UPDATE_INVOICE]
(
	@Action As char(1) = 'D'
	, @InvSchID As int = 0
	, @InvoiceID As int = 0
	, @Amount As float = 0
	, @Comments As varchar(200) = ''
)
AS 
BEGIN
	SET NOCOUNT ON
	
	DECLARE @ChangeAmount As float = 0
	DECLARE @PreAmount As float = 0

	SELECT @PreAmount = Amount FROM InvoiceSceduler WHERE id = @InvSchID

	SET @ChangeAmount = @PreAmount - @Amount

	IF @Action = 'D'
		BEGIN
-- Update InvoiceList
			UPDATE InvoiceList 
				SET TAmount = TAmount-@Amount 
			WHERE Id = @InvoiceID

-- Update InvoiceScheduler
			UPDATE InvoiceSceduler 
				SET Invoice_Id = 0 
			WHERE id = @InvSchID
		END
	ELSE IF @Action = 'U'
		BEGIN
-- Update InvoiceScheduler
			UPDATE InvoiceSceduler 
				SET Comments = @Comments,
				Amount =  @Amount
			WHERE id = @InvSchID
		
-- Update InvoiceList
			IF @ChangeAmount <> 0
				BEGIN
					UPDATE InvoiceList 
						SET TAmount = TAmount-@ChangeAmount 
					WHERE Id = @InvoiceID
				END
		END
	ELSE
		BEGIN
-- Update InvoiceScheduler
			UPDATE InvoiceSceduler 
				SET Comments = @Comments
			WHERE id = @InvSchID
		END
	SET NOCOUNT OFF
END
GO
