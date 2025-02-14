USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_INVOICE_RPT]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LIST_OF_INVOICE_RPT]
** Name  :   dbo.USP_LIST_OF_INVOICE_RPT
** Desc  :   
** Author:   Bipul
** Date  :   April 05, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LIST_OF_INVOICE_RPT]
(
	@PageNo int = 1,
	@PageSize int = 1000,
	@ProductID As int = 0,
	@Validity As tinyint = 0,
	@Operator As varchar(5) = '',
	@FDuration As int = 10,
	@TDuration As int = 10,
	@FullPayment As tinyint = 0,
	@BlackListed As tinyint = 0,
	@Order As char(4) = 'DESC'
)
AS 
BEGIN
	DECLARE @STRQuery As varchar(1000) = ''
	DECLARE @Select As varchar(250) = ''
	DECLARE @From As varchar(100) = ''
	DECLARE @Where As varchar(250) = ''
	DECLARE @OrderBy As varchar(100) = ''
	DECLARE @StartingIndex int = 1

	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize

	SET @Select = @Select + 'SELECT i.id,i.invoice_no,c.name,cp=(select top 1 cp.name from ContactPersons cp, invoicesceduler i2, sales s Where cp.Id = s.BillContactID And i2.TNO = s.TNO And i2.invoice_id = i.Id) ,c.phone,i.tamount,i.invsendDt,c.AccContactName ' + CHAR(13)	--, COUNT(1) OVER() As TotalInvoice ' + CHAR(13)
	SET @From = @From + 'FROM invoiceList i Inner Join company c on i.CID = c.Id ' + CHAR(13)
	SET @Where = @Where + 'WHERE'
	
	SET @Where = @Where + ' i.invalid = ' + CAST(@Validity As varchar(1)) + CHAR(13)

	IF @FullPayment = 1
		SET @Where = @Where + ' And i.FullPayment = 0' + CHAR(13)
	ELSE IF @FullPayment = 2
		SET @Where = @Where + ' And i.FullPayment = 1' + CHAR(13)

	IF @BlackListed = 0
		SET @Where = @Where + ' And c.BlackListed=0' + CHAR(13)
	
	IF @ProductID > 0
		SET @Where = @Where + ' And i.id in(select i2.invoice_id from sales s Inner Join invoiceSceduler i2 on s.tno=i2.tno where i2.invoice_id=i.id and s.pcode = ' + CAST(@ProductID As varchar(5)) + ')' + CHAR(13)
	IF @Operator <> ''
		BEGIN
			IF @Operator = 'range'
				SET @Where = @Where + ' And datediff(day,i.InvSendDt,getdate()) BETWEEN ' + CAST(@FDuration As varchar(4)) + ' And ' + CAST(@TDuration As varchar(4)) + CHAR(13)
			ELSE
				SET @Where = @Where + ' And datediff(day,i.InvSendDt,getdate()) ' + @Operator + ' ' + CAST(@FDuration As varchar(4)) + CHAR(13)
		END

	SET @OrderBy = @OrderBy + 'ORDER BY c.name,i.invsendDt ' + @Order + ' offset ' + CAST(@StartingIndex As varchar(5)) + ' rows fetch  next ' + CAST(@PageSize As varchar(5)) + ' rows only'

	SET @STRQuery = @STRQuery + @Select + @From + @Where + @OrderBy

	PRINT @STRQuery
	EXEC(@STRQuery)
END
GO
