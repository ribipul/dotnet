USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INVOICE_REMARKS_RPT]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INVOICE_REMARKS_RPT]
** Name  :   dbo.USP_INVOICE_REMARKS_RPT
** Desc  :   
** Author:   Bipul
** Date  :   April 09, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INVOICE_REMARKS_RPT]
(
	@InvoiceType As int = 3
	, @PreviewType As int = 2
	, @IncComID As int = 469
)
AS
BEGIN
	DECLARE @STRQuery As varchar (1000) = ''
	DECLARE @FullPayment As varchar(50) = ''
	DECLARE @InvoiceCom As varchar(50) = ''

	IF (@InvoiceType = 1) OR (@InvoiceType = 3)
		SET @InvoiceCom = @InvoiceCom + 'WHERE c.Id = ' + CAST(@IncComID As varchar(10))
	ELSE
		SET @InvoiceCom = @InvoiceCom + 'WHERE r.invoiceid = ' + CAST(@IncComID As varchar(10))

	IF @PreviewType = 1
		SET @FullPayment = @FullPayment + ' And i.FullPayment = 1'
	ELSE IF @PreviewType = 2
		SET @FullPayment = @FullPayment + ' And i.FullPayment = 0'
	ELSE
		SET @FullPayment = ''

	IF (@InvoiceType = 1) OR (@InvoiceType = 2)
		BEGIN
			SET @STRQuery = @STRQuery + 'SELECT Distinct i.id,i.invoice_no, i.TAmount, r.RemarkDate, r.Remarks, u.name As UName, c.name As CName, b.name As BCName' + CHAR(13)
			SET @STRQuery = @STRQuery + '	, b.designation, c.address, c.city, c.phone, c.Email ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'FROM invoiceRemarks r' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN invoiceList i ON r.invoiceid = i.Id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN InvoiceSceduler i1 ON i.Id = i1.invoice_id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN Sales s ON i1.tno = s.tno' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN Company c ON s.CID = c.Id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN ContactPersons b ON s.BillContactID = b.Id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN Users u ON r.UserId = u.UserId' + CHAR(13)
			SET @STRQuery = @STRQuery + @InvoiceCom + @FullPayment
		END
	ELSE
		BEGIN
			SET @STRQuery = @STRQuery + 'SELECT DISTINCT i.id, i.invoice_no,l.sbname, i1.Amount, c.name, c.address, c.city, c.phone, c.Email ' + CHAR(13)
			SET @STRQuery = @STRQuery + '	FROM  invoiceList i' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN InvoiceSceduler i1 ON i.Id = i1.invoice_id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN sales s ON i1.tno = s.tno' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN Company c ON s.CID = c.Id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN ContactPersons b ON s.BillContactID = b.Id' + CHAR(13)
			SET @STRQuery = @STRQuery + '	INNER JOIN ledger l ON s.pcode = l.Id' + CHAR(13)
			SET @STRQuery = @STRQuery + @InvoiceCom + @FullPayment + CHAR(13)
			SET @STRQuery = @STRQuery + 'ORDER BY i.invoice_no,l.sbname' + CHAR(13)
		END

	--PRINT @STRQuery
	EXEC(@STRQuery)
END
GO
