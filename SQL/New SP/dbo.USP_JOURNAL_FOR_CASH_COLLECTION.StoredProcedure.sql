USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_JOURNAL_FOR_CASH_COLLECTION]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_JOURNAL_FOR_CASH_COLLECTION]
** Name  :   dbo.USP_JOURNAL_FOR_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 18, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_JOURNAL_FOR_CASH_COLLECTION]
(
	@Type As tinyint
	, @UserID As int
	, @Invoice_No As varchar(20)
	, @Cash As float
	, @ReceivedDate As varchar(10)
	, @TNO As int
	, @LedgerId As int
	, @ChequeDetails As varchar(30)
	, @CompanyName As varchar(100)
)
AS
BEGIN
	
	DECLARE @STRPaymentType As varchar(20)
	DECLARE @STRDescription As varchar(50)
	DECLARE @Description As varchar(100)
	DECLARE @LedgerName As varchar(50)
	
	SET NOCOUNT ON
		
	BEGIN TRY
		BEGIN TRANSACTION
			IF @Type <> 3
				BEGIN
					IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
						BEGIN
							IF @Type = 2
								BEGIN
									-- VAT/AIT
									SELECT @LedgerName = SBName FROM Ledger WHERE ID = @LedgerId
									SET @STRPaymentType = @LedgerName
									SET @STRDescription = @LedgerName + ' to ' + @CompanyName
								END
							ELSE IF @Type = 7
								BEGIN
									-- Discount on Sale
									SET @STRPaymentType = 'Discount'
									SET @STRDescription = 'Discount to ' + @CompanyName
								END
							ELSE
								BEGIN
									-- Online Charges
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
				SET @STRDescription = 'Bad Debts to ' + @CompanyName

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
				-- VAT/AIT
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
