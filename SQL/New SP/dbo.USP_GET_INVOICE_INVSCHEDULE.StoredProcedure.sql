USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_INVOICE_INVSCHEDULE]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_GET_INVOICE_INVSCHEDULE]
** Name  :   dbo.USP_GET_INVOICE_INVSCHEDULE
** Desc  :   
** Author:   Bipul
** Date  :   April 11, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_GET_INVOICE_INVSCHEDULE]
(
	@MakeView As int = 0
	, @CID As int = 37
)
AS 
BEGIN
	SET NOCOUNT ON

	IF @MakeView = 0
		BEGIN
-- getInvoiceShcedules
			;WITH InvoiceShcedules_CTE As (
				SELECT ROW_NUMBER() OVER(ORDER BY i.id) As Serial, i.id,p.sbname,i.Comments,i.InvShdlNo,s.sdate, CASE WHEN s.edate IS NULL THEN s.sdate ELSE s.edate END As EDate, p.id As LedgerID, S.TNO, i.Amount
				FROM sales s
					INNER JOIN Ledger p ON s.pcode=p.id
					INNER JOIN InvoiceSceduler i ON s.tno=i.tno
				WHERE i.invoice_Id=0 And s.Posted = 1 And s.cid=@CID 
			)
			SELECT id, CAST(FORMAT(Serial, '00') As varchar(2)) + '. ' + CASE WHEN Comments IS NULL OR Comments = '' THEN sbname ELSE Comments END + ' (' + CAST(InvShdlNo As varchar(2)) + ') ' + CONVERT(varchar(10), sdate, 101) As ListItem
			, CASE WHEN Comments IS NULL OR Comments = '' THEN sbname ELSE Comments END As Product, LedgerID, SBName, SDate, EDate, Comments, Amount,TNO
			FROM InvoiceShcedules_CTE
			ORDER BY tno, sbname
		END
	ELSE
		BEGIN
-- getInvoices
			;WITH Invoices_CTE As (
				SELECT ROW_NUMBER() OVER(ORDER BY id DESC) As Serial, id, InvSendDt, invoice_no 
				, TAmount
				FROM InvoiceList 
				WHERE cid=@CID and Invalid=0
			)
			SELECT id, CAST(FORMAT(Serial, '00') As varchar(2)) + '. ' + invoice_no + ' (' + CONVERT(varchar(10), InvSendDt, 101) + ')' As ListItem
			, InvSendDt, TAmount, invoice_no
			FROM Invoices_CTE
			ORDER BY id DESC
		END

	SET NOCOUNT OFF
END
GO
