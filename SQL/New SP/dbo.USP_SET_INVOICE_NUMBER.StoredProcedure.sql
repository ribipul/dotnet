USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_SET_INVOICE_NUMBER]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_SET_INVOICE_NUMBER]
** Name  :   dbo.USP_SET_INVOICE_NUMBER
** Desc  :   
** Author:   Bipul
** Date  :   April 12, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_SET_INVOICE_NUMBER]
(
	@CID As int = 5647
	, @IssueDate As varchar(10) = ''
)
AS 
BEGIN
	SET NOCOUNT ON
	
	DECLARE @TSales As int
	DECLARE @Total As int
	DECLARE @Month As char(2)
	DECLARE @Year As char(2)
	DECLARE @Company As char(5)
	DECLARE @TotalSales As char(5)
	DECLARE @TotalInvoices As char(3)
	
	IF @IssueDate = ''
		SET @IssueDate = CONVERT(varchar(10), GETDATE(), 101)
	
	SET @Month = FORMAT(MONTH(@IssueDate),'00')
	SET @Year = FORMAT(CAST(RIGHT(YEAR(@IssueDate),2) As int),'00')
	SET @Company = FORMAT(@CID, '00000')


	select @TSales = (max(case when Substring(invoice_no,15,1)='-' then Substring(invoice_no,16,5) else Substring(invoice_no,15,5) end)) + 1
	from InvoiceList

	select @Total = (max(case when Substring(invoice_no,11,1)='-' then Substring(invoice_no,12,3) else Substring(invoice_no,11,3) end)) + 1
	from InvoiceList where cid=@CID 

	SET @TotalSales = FORMAT(@TSales,'00000')
	IF @Total > 0
		SET @TotalInvoices = FORMAT(@Total, '000')
	ELSE
		SET @TotalInvoices = FORMAT(1, '000')

	SELECT @Year + @Month + '-' + @Company + '-' + @TotalInvoices + '-' + @TotalSales
	
	SET NOCOUNT OFF
END
GO
