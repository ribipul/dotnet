USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_UNPAID_CASH_COLLECTION]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UNPAID_CASH_COLLECTION]
** Name  :   dbo.USP_UNPAID_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 18, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UNPAID_CASH_COLLECTION]
(
	@UserID As int
	, @LedgerID	As int
	, @TNO As int
	, @InvoiceId As int
	, @InvoiceNo As varchar(20)
	, @CollectionId As int
	, @Amount As float
	, @CompanyName As varchar(100)
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @DbtDesc As varchar(100) = 'Reverse entry'
	DECLARE @CrDesc As varchar(200) = 'Company - ' + @CompanyName + ', InvoiceNo - ' + @InvoiceNo
	DECLARE @JID As int = -1
	DECLARE @ARID As int = 35
	DECLARE @CurrentDate As varchar(10) = CONVERT(varchar(10), GETDATE(), 101)
	SELECT @JID = MAX(JID)+1 FROM Journal
	
	BEGIN TRY
		BEGIN TRANSACTION
			--Account Receivables Debt
			INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) 
			VALUES(@JID, @ARID, @DbtDesc, @Amount, 0, @CurrentDate, @TNO, 'AR', @CurrentDate, @UserID)
			--Bank/Cash Credit
			INSERT INTO Journal(jid,sid,description,debt,credit,Jdate,tno,Notify,PostDate,UserID)
			VALUES(@JID,@LedgerID, @CrDesc,0, @Amount, @CurrentDate, @TNO, 'Sales', @CurrentDate, @UserID)

			EXEC USP_MakeJournalVoucher @JID, @CurrentDate

			--Update 'InvoiceList' Table to set FullPayment=0
			UPDATE InvoiceList SET FullPayment=0 WHERE id=@InvoiceId
			--Update 'Sales' table to make due
			UPDATE Sales SET CashReceived=CashReceived-@Amount,AccReceivable=AccReceivable+@Amount WHERE tno=@TNO
			--Delete record from 'Cash_Collection' Table
			DELETE Cash_Collection WHERE id=@CollectionId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH
	
	SET NOCOUNT OFF
END
GO
