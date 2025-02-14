USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_CASH_COLLECTION]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_CASH_COLLECTION]
** Name  :   dbo.USP_INSERT_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 14, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_CASH_COLLECTION]
(
	@Type As tinyint
	, @UserID As int
	, @Invoice_No As varchar(20)
	, @Cash As float
	, @ReceivedDate As varchar(10)
	, @TNO As int
	, @InvoiceSchedulerID As int
	, @LedgerId As int
	, @ChequeDetails As varchar(30)
	, @CompanyName As varchar(100)
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @STRPaymentType As varchar(20)
	DECLARE @STRDescription As varchar(50)
	DECLARE @Description As varchar(100)
	DECLARE @Tax As float
	DECLARE @Payment As float
	DECLARE @AR As float
	DECLARE @AmtDiff As float
	DECLARE @LedgerName As varchar(50)
	DECLARE @TCCollect As float
	DECLARE @TIAmount As float
	
	BEGIN TRY
		BEGIN TRANSACTION
			IF @Type <> 3
				BEGIN
					IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
						BEGIN
							SET @Tax = @Cash
							SET @Payment = 0
							IF @Type = 2
								BEGIN
									SELECT @LedgerName = SBName FROM Ledger WHERE ID = @LedgerId
									SET @STRPaymentType = @LedgerName
									SET @STRDescription = @LedgerName + ' to ' + @CompanyName
								END
							ELSE IF @Type = 7
								BEGIN
									SET @STRPaymentType = 'Discount'
									SET @STRDescription = 'Discount to ' + @CompanyName
								END
							ELSE
								BEGIN
									SET @STRPaymentType = 'OnlineCharges'
									SET @STRDescription = 'Online collection charges to ' + @CompanyName
								END
						END
					ELSE
						BEGIN
							SET @Tax = 0
							SET @Payment = @Cash
							IF @Type = 0
								BEGIN
									SET @STRPaymentType = 'Cash'
									SET @STRDescription = 'Cash ' --+ @CompanyName
								END
							ELSE IF @Type = 1
								BEGIN
									SET @STRPaymentType = 'Bank'
									SET @STRDescription = 'Cheque  ' --+ @CompanyName
								END
							ELSE IF @Type = 4
								BEGIN
									SET @STRPaymentType = 'Brac'
									SET @STRDescription = 'Online payment (by Brac) ' --+ @CompanyName
								END
							ELSE IF @Type = 5
								BEGIN
									SET @STRPaymentType = 'SSL'
									SET @STRDescription = 'Online payment (by SSL) ' --+ @CompanyName
								END
							ELSE IF @Type = 6
								BEGIN
									SET @STRPaymentType = 'bKash'
									SET @STRDescription = 'Online payment (by bKash) ' --+ @CompanyName
								END
						END
					SET @AR = @Payment + @Tax
					IF @Type = 1
						BEGIN
							INSERT INTO Cash_Collection(Invoice_No,Cash,ReceivedDate,tno,salesTax,PaymentType,InvoiceSchedulerID,chequedetails,BankId) 
							VALUES(@Invoice_No, @Payment, @ReceivedDate, @TNO, @Tax, @STRPaymentType, @InvoiceSchedulerID, @ChequeDetails, @LedgerId)
						END
					ELSE
						BEGIN
							INSERT INTO Cash_Collection(Invoice_No,Cash,ReceivedDate,tno,salesTax,PaymentType,InvoiceSchedulerID) 
							VALUES(@Invoice_No, @Payment, @ReceivedDate, @TNO, @Tax, @STRPaymentType, @InvoiceSchedulerID)
						END
				END
			ELSE
				BEGIN
					SET @STRDescription = 'Bad Debts to ' + @CompanyName
					SET @Tax = 0
					SET @Payment = @Cash
					SET @AR = @Payment + @Tax
					INSERT INTO Cash_Collection(Invoice_No,Cash,ReceivedDate,tno,BadDebt,InvoiceSchedulerID) 
					VALUES(@Invoice_No, @Payment, @ReceivedDate, @TNO, 1, @InvoiceSchedulerID)
				END
		/*==============================Update Sale==========================*/
			SELECT @AmtDiff = @AR-AccReceivable FROM Sales WHERE TNO = @TNO

			IF @AmtDiff <= 1
				BEGIN
					UPDATE Sales
						SET CashReceived = CashReceived + @Payment
						, AccReceivable = AccReceivable - @AR
					WHERE TNO = @TNO
				END
			ELSE
				BEGIN
					SET @AR = @AmtDiff
					UPDATE Sales
						SET CashReceived = SalesPrice - @Tax
						, AccReceivable = 0
					WHERE TNO = @TNO
				END
		/*=========================================================================================*/
		/*==============================Update InvoiceList when FullPayment==========================*/
			SELECT @TCCollect = (SUM(Cash) + SUM(salesTax)) FROM Cash_Collection WHERE invoice_no= @Invoice_No
			SELECT @TIAmount = TAmount FROM InvoiceList WHERE invoice_no= @Invoice_No

			IF @TCCollect = @TIAmount
				BEGIN
					UPDATE InvoiceList 
						SET fullPayment=1 
					WHERE invoice_no= @Invoice_No
				END
		/*=========================================================================================*/

			DECLARE @SalesPrice As float
				, @CashReceived As float
				, @AccReceivable As float
				, @SDate As varchar(10)
				, @Duration As tinyint

			SELECT @SalesPrice=(salesPrice+Tax),@CashReceived=CashReceived,@AccReceivable=AccReceivable,@SDate=CONVERT(varchar(10), sdate, 101),@Duration=duration 
			FROM Sales 
			WHERE tno = @TNO

			SET @Description = @STRDescription + '; Invoice No - ' + @Invoice_No

			IF @Type = 0
				-- Cash
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 1
				-- Bank
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales', @ChequeDetails
			ELSE IF @Type = 2
				-- Tax
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
			ELSE IF @Type = 3
				-- Bad Debt
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 4
				-- Brac Bank Merchant A/C
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 5
				-- SSL Merchant A/C
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 6
				-- bKash Merchant A/C
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 7
				-- Discount
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
			ELSE
				-- Online Charge
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'

			-- Update Cash Collection
			UPDATE Cash_Collection SET Posted=1 WHERE id = (SELECT MAX(ID) FROM Cash_Collection)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH
	
	SET NOCOUNT OFF
END
GO
