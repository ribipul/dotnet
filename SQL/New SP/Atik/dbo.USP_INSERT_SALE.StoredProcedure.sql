USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_SALE]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_SALE]
** Name  :   dbo.USP_INSERT_SALE
** Desc  :   
** Author:   Bipul
** Date  :   April 21, 2015
******************************************************************************************/
CREATE PROCEDURE [dbo].[USP_INSERT_SALE](
	@UserID As int
	, @CID As int = 292
	, @PCODE As int = 52
	, @SDate As varchar(10) = '3/28/2015'
	, @EDate As varchar(10) = '6/28/2015'
	, @JDate As varchar(10) = '3/28/2015'
	, @SalesPrice As float = 12000
	, @BillingPerson As varchar(50) = 'Shorab Sabbir'
	, @Designation As varchar(50) = ''
	, @Comments varchar(1000) = 'Test'
	, @Duration int = 3
	, @NumberOfInvoices int = 3
	, @RefNo varchar(100) = '123456'
	, @TaxId int = 672
	, @Tax As float = 1200
	, @JP_ID As int = 0
	, @Title As varchar(50)
	, @WorkshopDate As varchar(10)
)
AS
BEGIN
	DECLARE @BillContactId int = -1
	DECLARE @CheckContactId int = -1
	DECLARE @AccReceivable As float
	DECLARE @TNO int = -1
	DECLARE @Counter int = 1
	DECLARE @Amount float
	DECLARE @VATAmount float

	DECLARE @Description As varchar(500)
	DECLARE @Company As varchar(300)
	DECLARE @Product As varchar(200)

	DECLARE @Workshop As varchar(20)

	SET @AccReceivable = @SalesPrice + @Tax
	
	SET NOCOUNT ON
-------------------------------- Contact Person -------------------------------------------
	-- Check Billing Person is Exist
	SELECT @CheckContactId = COUNT(ID)FROM ContactPersons WHERE CID = @CID And Name = @BillingPerson

	-- Check Workshop
	SELECT @Workshop = SBName FROM Ledger WHERE id = @PCODE

	IF @CheckContactId > 0
	-- If Billing Person is Exist
		BEGIN
			SELECT @BillContactId = ID FROM ContactPersons WHERE CID = @CID And Name = @BillingPerson
			UPDATE ContactPersons
				SET Designation = @Designation,
				CID = @CID,
				Name = @BillingPerson
			WHERE ID = @BillContactId
		END
	ELSE
	-- If Billing Person is not Exist
		BEGIN
			INSERT INTO ContactPersons(cid,name,designation,ptype) 
			VALUES (@CID, @BillingPerson,@Designation,'Billing person')
			
			SELECT @BillContactId = ID FROM ContactPersons WHERE CID = @CID And Name = @BillingPerson
		END
-------------------------------------------------------------------------------------------------
------------------------------------------- Sales -----------------------------------------------
	SELECT @TNO = (MAX(TNO)+1) FROM Sales
	IF @Duration = 1
	--IF Sales Duration is 1
		BEGIN
			INSERT INTO SALES(tno,cid,pcode,sdate,SalesPrice,CashReceived,AccReceivable,comments,duration,NumberOfInvoices,BillContactId,RefNo,TaxId,Tax)
			VALUES (@TNO, @CID, @PCODE, @SDate, @SalesPrice, 0, @AccReceivable, @Comments, @Duration, @NumberOfInvoices, @BillContactId, @RefNo, @TaxId, @Tax)
		END
	ELSE
	--IF Sales Duration is More than 1
		BEGIN
			INSERT INTO SALES(tno,cid,pcode,sdate,edate,SalesPrice,CashReceived,AccReceivable,comments,duration,NumberOfInvoices,BillContactId,RefNo,TaxId,Tax)
			VALUES (@TNO, @CID, @PCODE, @SDate, @EDate, @SalesPrice, 0, @AccReceivable, @Comments, @Duration, @NumberOfInvoices, @BillContactId, @RefNo, @TaxId, @Tax)
		END

-------------------------------- Invoice Scheduler -------------------------------------
	SET @Amount = @SalesPrice/@NumberOfInvoices
	IF @Tax > 0
		SET @VATAmount = @Tax/@NumberOfInvoices

	WHILE (@Counter <= @NumberOfInvoices)
		BEGIN
			IF @Workshop = 'Workshop'
				BEGIN
					INSERT INTO InvoiceSceduler(tno,InvShdlNo,ShdlDate,Amount,Comments)
					VALUES (@TNO, @Counter, @SDate, @Amount, 'Workshop on: ' + @Title)
				END
			ELSE
				BEGIN
					INSERT INTO InvoiceSceduler(tno,InvShdlNo,ShdlDate,Amount,Comments)
					VALUES (@TNO, @Counter, @SDate, @Amount, @Title)
				END
			IF @Tax > 0
				BEGIN
					DECLARE @TaxtType As varchar(50)
					SELECT @TaxtType = SBName FROM Ledger WHERE ID = @TaxId
					INSERT INTO InvoiceSceduler(tno,InvShdlNo,ShdlDate,Amount,Comments)
					VALUES (@TNO, @Counter, @SDate, @VATAmount, @TaxtType)
				END
			SET @Counter = @Counter + 1
		END

	-- Update tmpJobs
	IF @JP_ID > 0 And @Workshop <> 'Workshop'
		UPDATE tmpJobs SET TNO = @TNO WHERE JP_ID = @JP_ID

-------------------------------------- Journal -------------------------------------------
	SELECT @Company = Name FROM Company WHERE id = @CID
	SELECT @Product = SBName FROM Ledger WHERE id = @PCODE
	
	IF @Workshop = 'Workshop'
		SET @Description = 'Participant name: ' + @BillingPerson + ', Item: ' + @Product + CHAR(13) + 'Title: ' + @Title + ', Held on: ' + @WorkshopDate
	ELSE
		SET @Description = 'Company: ' + @Company + ', Item: ' + @Product
	
	EXEC USP_SALES_JOURNAL @PCODE, @SalesPrice, @JDate, @Duration, @TNO, @Description, @SDate, @TaxId, @Tax, @UserID
	
	SET NOCOUNT OFF
END
GO
