USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_UPLOAD_INVOICE_ONLINE]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UPLOAD_INVOICE_ONLINE]
** Name  :   dbo.USP_UPLOAD_INVOICE_ONLINE
** Desc  :   
** Author:   Bipul
** Date  :   April 19, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UPLOAD_INVOICE_ONLINE]
(
	@PCode As int = 44
	, @InvoiceSentDate As varchar(10) = '1/1/2010'
	, @CP_ID As int = 38156
)
AS
BEGIN
	SET NOCOUNT ON

	IF @CP_ID > 0
		BEGIN
			Select t.jp_id,t.Title,s.salesPrice,t.invoice_no,t.submitted,t.OPID, t.AddType 
			, CASE WHEN (SELECT LedgerId FROM SERVICE_LIST WHERE AddType = t.AddType) IS NULL THEN -1 ELSE (SELECT LedgerId FROM SERVICE_LIST WHERE AddType = t.AddType) END As LedgerID
			, (Select distinct BillingContact from tmpJobs where Invoice_No = t.invoice_no) As BillingContact
			, (Select TAmount from InvoiceList where invoice_no = t.invoice_no) As TAmount
			from tmpJobs t 
				INNER JOIN Sales s ON t.tno=s.tno
			where t.TNO>0 and t.cp_id=@CP_ID
			order by s.sdate
		END
	ELSE
		BEGIN
			IF @PCode = 18 or @PCode = 44
				SET @InvoiceSentDate = CONVERT(varchar(10), (DATEADD(DAY, -60, GETDATE())), 101)
			
			SELECT DISTINCT i.Invoice_No,i.TAmount, i.id, i.InvSendDt 
			FROM InvoiceList i
				INNER JOIN InvoiceSceduler i1 ON i.id=i1.invoice_id 
				INNER JOIN sales s ON i1.tno=s.tno
			WHERE i.UploadedPaymentStatus<>'Yes' and i.InvSendDt>@InvoiceSentDate and s.pcode=@PCode
			ORDER BY i.id DESC
		END

	SET NOCOUNT OFF
END
GO
