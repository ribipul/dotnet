USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_INVOICE_DETAIL]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_GET_INVOICE_DETAIL]
** Name  :   dbo.USP_GET_INVOICE_DETAIL
** Desc  :   
** Author:   Bipul
** Date  :   April 11, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_GET_INVOICE_DETAIL]
(
	@InvoiceID As int = 422	--37
)
AS 
BEGIN
	SET NOCOUNT ON
	
	SELECT cp.Name + CHAR(13) + cp.Designation + CHAR(13) + c.name + CHAR(13) + c.address As Label
		, i1.Invoice_No, i1.InvSendDt, i1.TAmount As TotalAmount, i.id, i.Comments, i.Amount As SchAmount
	FROM sales s
		INNER JOIN company c ON s.cid=c.id 
		INNER JOIN InvoiceSceduler i ON i.tno=s.tno
		INNER JOIN ContactPersons cp ON s.BillContactId=cp.id
		LEFT JOIN invoiceList i1 ON i.Invoice_Id = i1.Id
	WHERE  i.Invoice_Id = @InvoiceID
	
	SET NOCOUNT OFF
END
GO
