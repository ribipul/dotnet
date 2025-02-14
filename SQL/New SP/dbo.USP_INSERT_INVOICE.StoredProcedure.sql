USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_INVOICE]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_INVOICE]
** Name  :   dbo.USP_INSERT_INVOICE
** Desc  :   
** Author:   Bipul
** Date  :   April 13, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_INVOICE]
(
	@ActionType As varchar(4) = 'Make'
	, @CompanyID As int = 37
	, @Invoice_No As varchar(25) = '1504-00037-001-82606'
	, @InvSendDt As varchar(10) = '04/13/2015'
	, @InvAmount As float = 13200
	, @InvSchdIDs As varchar(100) = '150758,150759'
	, @Invoice_ID As int = 0
)
AS 
BEGIN
	DECLARE @STRQuery As varchar(3000) = ''
	
	SET @STRQuery = @STRQuery + 'DECLARE @CheckID As int = 0' + CHAR(13)
	SET @STRQuery = @STRQuery + 'DECLARE @InvoiceID As int = 0' + CHAR(13)
	SET @STRQuery = @STRQuery + 'DECLARE @Action As varchar(4) = ''' + @ActionType + '''' + CHAR(13) + CHAR(13)

	SET @STRQuery = @STRQuery + 'SET NOCOUNT ON' + CHAR(13) + CHAR(13)

	SET @STRQuery = @STRQuery + 'IF @Action = ''Make''' + CHAR(13)
	SET @STRQuery = @STRQuery + '	BEGIN' + CHAR(13)
	SET @STRQuery = @STRQuery + '		SELECT @CheckID = COUNT(invoice_no) FROM InvoiceList WHERE invoice_no = ''' + @Invoice_No + '''' + CHAR(13)

	SET @STRQuery = @STRQuery + '		IF @CheckID > 0' + CHAR(13)
	SET @STRQuery = @STRQuery + '			BEGIN' + CHAR(13)
	SET @STRQuery = @STRQuery + '				UPDATE InvoiceList' + CHAR(13)
	SET @STRQuery = @STRQuery + '					SET TAmount = ' + CAST(@InvAmount As varchar(10)) + CHAR(13)
	SET @STRQuery = @STRQuery + '				WHERE Invoice_No = ''' + @Invoice_No + '''' + CHAR(13)
	SET @STRQuery = @STRQuery + '			END' + CHAR(13)
	SET @STRQuery = @STRQuery + '		ELSE' + CHAR(13)
	SET @STRQuery = @STRQuery + '			BEGIN' + CHAR(13)
	SET @STRQuery = @STRQuery + '				INSERT INTO InvoiceList(Cid,Invoice_No,TAmount,InvSendDt) ' + CHAR(13)
	SET @STRQuery = @STRQuery + '				VALUES(' + CAST(@CompanyID As varchar(6)) + ', ''' + @Invoice_No + ''', ' + CAST(@InvAmount As varchar(10)) + ', ''' + @InvSendDt  + ''')' + CHAR(13)
	SET @STRQuery = @STRQuery + '			END' + CHAR(13)

	SET @STRQuery = @STRQuery + '		SELECT @InvoiceID=id from InvoiceList where Invoice_No = ''' + @Invoice_No + '''' + CHAR(13)

	SET @STRQuery = @STRQuery + '		IF @InvoiceID > 0' + CHAR(13)
	SET @STRQuery = @STRQuery + '			BEGIN' + CHAR(13)
	SET @STRQuery = @STRQuery + '				UPDATE invoiceSceduler ' + CHAR(13)
	SET @STRQuery = @STRQuery + '					SET invoice_id = @InvoiceID' + CHAR(13)
	SET @STRQuery = @STRQuery + '				WHERE id IN (' + @InvSchdIDs + ')' + CHAR(13)
					
	SET @STRQuery = @STRQuery + '				UPDATE tmpJobs ' + CHAR(13)
	SET @STRQuery = @STRQuery + '					SET Invoice_no = ''' + @Invoice_No + '''' + CHAR(13)
	SET @STRQuery = @STRQuery + '				WHERE TNO IN (SELECT tno FROM invoiceSceduler WHERE id IN (' + @InvSchdIDs + '))' + CHAR(13)
	SET @STRQuery = @STRQuery + '			END' + CHAR(13)
	SET @STRQuery = @STRQuery + '	END' + CHAR(13)
	SET @STRQuery = @STRQuery + '	BEGIN' + CHAR(13)
	SET @STRQuery = @STRQuery + '		SET @InvoiceID = ' + CAST(@Invoice_ID As varchar(10)) + CHAR(13)
	SET @STRQuery = @STRQuery + '		IF @InvoiceID > 0' + CHAR(13)
	SET @STRQuery = @STRQuery + '			BEGIN' + CHAR(13)
	SET @STRQuery = @STRQuery + '				UPDATE InvoiceList ' + CHAR(13)
	SET @STRQuery = @STRQuery + '					SET Invoice_No = ''' + @Invoice_No + ''',' + CHAR(13)
	SET @STRQuery = @STRQuery + '					InvSendDt = ''' + @InvSendDt  + '''' + CHAR(13)
	SET @STRQuery = @STRQuery + '				WHERE id = @InvoiceID' + CHAR(13)
	SET @STRQuery = @STRQuery + '			END' + CHAR(13)
	SET @STRQuery = @STRQuery + '	END' + CHAR(13) + CHAR(13)

	SET @STRQuery = @STRQuery + 'SET NOCOUNT OFF'

	--PRINT @STRQuery
	EXEC (@STRQuery)
END
GO
