USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_CASH_COLLECTION]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UPDATE_CASH_COLLECTION]
** Name  :   dbo.USP_UPDATE_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 17, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UPDATE_CASH_COLLECTION]
(
	@Type As tinyint = -1
	, @UserID As int = -1
	, @CCollectionID As int = -1
	, @Invoice_No As varchar(20) = ''
	, @Cash As float = 0
	, @ReceivedDate As varchar(10) = ''
	, @TNO As int = -1
	, @InvoiceSchedulerID As int = -1
	, @LedgerId As int = -1
	, @ChequeDetails As varchar(30) = ''
	, @CompanyName As varchar(100) = ''
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @STRPaymentType As varchar(20)
	DECLARE @STRDescription As varchar(50)
	DECLARE @Description As varchar(100)
	DECLARE @Amount As float
	DECLARE @Tax As float
	DECLARE @Payment As float
	DECLARE @AR As float
	DECLARE @AmtDiff As float
	DECLARE @LedgerName As varchar(50)
	DECLARE @TCCollect As float
	DECLARE @TIAmount As float
	DECLARE @AmountChanged As bit = 0
	DECLARE @TaxChanged As bit = 0
	DECLARE @PreviousCollection As float
	DECLARE @AccReceivable As float
	DECLARE @BadDebt As bit = 0
	
	SELECT @PreviousCollection = Cash FROM Cash_Collection WHERE ID = @CCollectionID
	
	BEGIN TRY
		BEGIN TRANSACTION
			IF @Type <> 3
				BEGIN
					IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
						BEGIN
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
				END
			ELSE
				BEGIN
					SET @STRDescription = 'Bad Debts to ' + @CompanyName
					SET @BadDebt = 1
				END
			
			IF (@Type = 0) OR (@Type = 1) OR (@Type = 3) OR (@Type = 4) OR (@Type = 5) OR (@Type = 6)
				BEGIN
					IF @Cash <> @PreviousCollection
						SET @AmountChanged = 1
				END
			ELSE IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
				BEGIN
					IF @Cash <> @PreviousCollection
						SET @TaxChanged = 1
				END
				
			IF (@AmountChanged = 1) OR (@TaxChanged = 1)
				BEGIN
					IF @AmountChanged = 1
						BEGIN
							SET @Amount = @Cash - @PreviousCollection
							SET @Tax = 0
						END
					ELSE
						BEGIN
							SET @Amount = 0
							SET @Tax = @Cash - @PreviousCollection
						END			
					
					SET @AR = @Amount + @Tax
					
					SELECT @AccReceivable = AccReceivable FROM Sales WHERE TNO= @TNO
					
					IF @AR <= @AccReceivable
						BEGIN
							UPDATE Sales
								SET CashReceived = CashReceived + @Amount
								, Tax = Tax + @Tax
								, AccReceivable = AccReceivable - @AR
							WHERE TNO = @TNO
						END
					IF @Type = 1
						BEGIN
							UPDATE Cash_Collection
								SET Cash = @Cash
								, ChequeDetails = @ChequeDetails
								, SalesTax = @Tax
								, ReceivedDate = @ReceivedDate
								, BankId = @LedgerId
								, BadDebt = @BadDebt
								, PaymentType = @STRPaymentType
							WHERE ID = @CCollectionID
						END
					ELSE
						BEGIN
							UPDATE Cash_Collection
								SET Cash = @Cash
								, ChequeDetails = @ChequeDetails
								, SalesTax = @Tax
								, ReceivedDate = ReceivedDate
								, BankId = 0
								, BadDebt = @BadDebt
								, PaymentType = @STRPaymentType
							WHERE ID = @CCollectionID
						END
		/*=========================================================================================*/
		/*==============================Update InvoiceList when FullPayment==========================*/
					SELECT @TCCollect = (SUM(Cash) + SUM(salesTax)) FROM Cash_Collection WHERE invoice_no= @Invoice_No
					SELECT @TIAmount = TAmount FROM InvoiceList WHERE invoice_no= @Invoice_No

					IF @TCCollect >= @TIAmount
						BEGIN
							UPDATE InvoiceList 
								SET fullPayment=1 
							WHERE invoice_no= @Invoice_No
						END
					ELSE 
						BEGIN
							UPDATE InvoiceList 
								SET fullPayment=0
							WHERE invoice_no= @Invoice_No
						END
				END	
			ELSE
				IF @Type = 1
					BEGIN
						UPDATE Cash_Collection
							SET ChequeDetails = @ChequeDetails
							, SalesTax = @Tax
							, ReceivedDate = ReceivedDate
							, BankId = @LedgerId
							, BadDebt = @BadDebt
							, PaymentType = @STRPaymentType
						WHERE ID = @CCollectionID
					END
				ELSE
					BEGIN
						UPDATE Cash_Collection
							SET ChequeDetails = @ChequeDetails
							, SalesTax = @Tax
							, ReceivedDate = ReceivedDate
							, BankId = 0
							, BadDebt = @BadDebt
							, PaymentType = @STRPaymentType
						WHERE ID = @CCollectionID
					END
			
/*=========================================================================================*/
		IF (@AmountChanged = 1) OR (@TaxChanged = 1)
			BEGIN
				DECLARE @SalesPrice As float
					, @CashReceived As float
					--, @AccReceivable As float
					, @SDate As varchar(10)
					, @Duration As tinyint
				
				SELECT @SalesPrice=(salesPrice+Tax),@CashReceived=CashReceived,@AccReceivable=AccReceivable,@SDate=CONVERT(varchar(10), sdate, 101),@Duration=duration 
				FROM Sales 
				WHERE tno = @TNO
				
				SET @Amount = ABS(@Cash - @PreviousCollection)
				SET @Description = @STRDescription + '; Invoice No - ' + @Invoice_No

				IF @Type = 0
					-- Cash
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 1
					-- Bank
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales', @ChequeDetails
				ELSE IF @Type = 2
					-- Tax
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
				ELSE IF @Type = 3
					-- Bad Debt
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 4
					-- Brac Bank Merchant A/C
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 5
					-- SSL Merchant A/C
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 6
					-- bKash Merchant A/C
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 7
					-- Discount
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
				ELSE
					-- Online Charge
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'

				-- Update Cash Collection
				UPDATE Cash_Collection SET Posted=1 WHERE id = (SELECT MAX(ID) FROM Cash_Collection)
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH
	
	SET NOCOUNT OFF
END
GO
