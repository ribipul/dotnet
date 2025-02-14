USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_COLLECTION_NOTE]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_COLLECTION_NOTE]
** Name  :   dbo.USP_COLLECTION_NOTE
** Desc  :   
** Author:   Bipul
** Date  :   May 21, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_COLLECTION_NOTE]
(
	@InvoiceIDs As varchar(1000) = '82968,82946,81331,76918'
)
AS
BEGIN 
	DECLARE @STRQuery As varchar(1200) = ''
	DECLARE @STRUpdate As varchar(1200) = ''
	DECLARE @MoneyRNo As varchar(20) = ''
	DECLARE @MoneyRID As int = 0
	DECLARE @InvoiceID As int = 0
	DECLARE @Count As int = 0
	DECLARE @STR As varchar(20) = ''
	DECLARE @MoneyReceiptNo As varchar(20) = ''
	DECLARE @MReceipt CURSOR

	DECLARE @MoneyReceipt TABLE(
		InvoiceID int NOT NULL,
		MoneyReceiptNo varchar(20) NULL
	)

	SET @STRQuery = @STRQuery + 'SELECT id,MoneyReceiptNo FROM InvoiceList WHERE id IN (' + @InvoiceIDs + ') order by id'

	SET NOCOUNT ON

	INSERT INTO @MoneyReceipt
	--SELECT 1,null
	EXEC (@STRQuery)

	SET @MReceipt = CURSOR FAST_FORWARD FOR
	SELECT * FROM @MoneyReceipt

	OPEN @MReceipt
	FETCH NEXT FROM @MReceipt
	INTO @InvoiceID,@MoneyReceiptNo

	WHILE @@FETCH_STATUS = 0
		BEGIN
			IF (@MoneyReceiptNo IS NOT NULL) OR (@MoneyReceiptNo <> '')
				BEGIN
					SET @MoneyRNo = @MoneyReceiptNo
					SET @Count = @Count + 1
				END
			FETCH NEXT FROM @MReceipt
			INTO @InvoiceID,@MoneyReceiptNo
		END
	CLOSE @MReceipt
	DEALLOCATE @MReceipt

	IF @MoneyRNo = ''
		BEGIN
			SET @STR = @STR + LEFT(DATENAME(MONTH,GETDATE()),3) + '/'
			SET @STR = @STR + RIGHT(YEAR(GETDATE()),2) + '/'
			
			SELECT @MoneyRID = MAX(SUBSTRING(MoneyReceiptNo,8,10)) FROM InvoiceList
			IF @MoneyRID IS NULL
				SET @MoneyRNo = @MoneyRNo + '00001'
			ELSE
				SET @MoneyRNo = @STR + FORMAT(@MoneyRID+1,'00000')
			
			SET @STRUpdate = @STRUpdate + 'UPDATE InvoiceList SET MoneyReceiptNo = ''' + @MoneyRNo + ''' WHERE id IN (' + @InvoiceIDs + ')'
		END
	ELSE
		BEGIN
			IF @Count < (SELECT COUNT(1) FROM @MoneyReceipt)
				SET @STRUpdate = @STRUpdate + 'UPDATE InvoiceList SET MoneyReceiptNo = ''' + @MoneyRNo + ''' WHERE id IN (' + @InvoiceIDs + ')'
		END

	--PRINT @MoneyRNo
	--PRINT @STRUpdate

	BEGIN TRY
		BEGIN TRANSACTION
			EXEC (@STRUpdate)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH

	SET @STRQuery = ''

	SET @STRQuery = @STRQuery + 'SELECT DISTINCT i.Invoice_No,(SELECT SUM(TAmount) FROM InvoiceList WHERE id IN (' + @InvoiceIDs + ')) As TAmount,c.Name,l.sbname,i.MoneyReceiptNo ' + CHAR(13)
	SET @STRQuery = @STRQuery + 'FROM InvoiceList i,Company c,InvoiceSceduler i1,Sales s,Ledger l ' + CHAR(13)
	SET @STRQuery = @STRQuery + 'WHERE i.id=i1.Invoice_Id and i1.tno=s.tno and s.pcode=l.id and i.cid=c.id and i.id in (' + @InvoiceIDs + ') ' + CHAR(13)
	SET @STRQuery = @STRQuery + 'ORDER BY i.Invoice_No' + CHAR(13)
	
	EXEC (@STRQuery)

	SET NOCOUNT OFF
END
GO
