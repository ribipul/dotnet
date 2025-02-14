USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_SALE_INFO]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_DELETE_SALE_INFO]
** Name  :   dbo.USP_DELETE_SALE_INFO
** Desc  :   
** Author:   Bipul
** Date  :   May 23, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_DELETE_SALE_INFO](
	@TNO As int = -1
)
AS
BEGIN
	DECLARE @SaleTotal As float
	DECLARE @InvoiceTotal As float
	DECLARE @InvoiceId As int
	DECLARE @CCollection As int
	DECLARE @JFound As int
	DECLARE @Message As int
	DECLARE @CUR_INV CURSOR

	SELECT @CCollection = COUNT(id) FROM Cash_Collection WHERE tno = @TNO
	SELECT @JFound = COUNT(tno) FROM journal WHERE ApprovedBy>0 And tno = @TNO
	
------------------------- Delete Invoice from InvoiceList ----------------------------
	
	IF @CCollection > 0
		SET @Message = 1
	ELSE IF @JFound > 0
		SET @Message = 2
	ELSE
		SET @Message = 0
	
	IF @Message = 0
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
					IF CURSOR_STATUS('local','@CUR_INV')=1
						BEGIN
							CLOSE  @CUR_INV
							DEALLOCATE @CUR_INV
						END

					SET @CUR_INV = CURSOR STATIC FOR
					SELECT Invoice_Id, Amount
					FROM invoiceSceduler 
					WHERE tno = @TNO
					OPEN @CUR_INV

					FETCH @CUR_INV INTO @InvoiceId, @SaleTotal
					WHILE @@FETCH_STATUS = 0
						BEGIN
							SELECT @InvoiceTotal = TAmount FROM InvoiceList 
							WHERE id = @InvoiceId
							IF @InvoiceTotal > @SaleTotal
								BEGIN
									UPDATE InvoiceList
									SET TAmount = @InvoiceTotal-@SaleTotal
									WHERE ID = @InvoiceId
								END
							ELSE
								BEGIN
									DELETE InvoiceList
									--SELECT * FROM InvoiceList
									WHERE ID = @InvoiceId
								END
							FETCH @CUR_INV INTO @InvoiceId, @SaleTotal
						END

------------------------------ Delete JournalVoucher --------------------------------
					DELETE JournalVoucher
					--SELECT * FROM JournalVoucher
					WHERE Jid IN (
						SELECT JID FROM Journal 
						WHERE Tno = @TNO AND (Notify='AR' or Notify='Sales' or Notify='VAT' or Notify='Tax' or Notify IS NULL))

--------------------------------- Delete Journal ------------------------------------
					DELETE Journal
					--SELECT * FROM Journal 
					WHERE Tno = @TNO AND (Notify='AR' or Notify='Sales' or Notify='VAT' or Notify='Tax' or Notify IS NULL)

----------------------------- Delete InvoiceSceduler --------------------------------
					DELETE InvoiceSceduler
					--SELECT * FROM invoiceSceduler 
					WHERE tno = @TNO

----------------------------- Delete InvoiceSceduler --------------------------------
					DELETE Sales
					--SELECT * FROM Sales 
					WHERE tno = @TNO
					
					SET @Message = 0
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
					BEGIN
						SET @Message = -1
						ROLLBACK TRANSACTION
					END
			END CATCH
		END
	
	SELECT @Message As [Message]
END
GO
