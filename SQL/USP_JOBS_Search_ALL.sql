
DECLARE @TNO As int = 98123

------------------------- Delete Invoice from InvoiceList ----------------------------

DECLARE @SaleTotal As float
DECLARE @InvoiceTotal As float
DECLARE @InvoiceId As int
DECLARE @CUR_INV CURSOR

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
				--PRINT @InvoiceTotal
				UPDATE InvoiceList
				SET TAmount = @InvoiceTotal-@SaleTotal
				WHERE ID = @InvoiceId
			END
		ELSE
			BEGIN
				--DELETE InvoiceList
				SELECT * FROM InvoiceList
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

