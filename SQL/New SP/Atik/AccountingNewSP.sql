USE [Accounting]
GO
/****** Object:  StoredProcedure [dbo].[USP_CHECK_ONLINE_JOBS]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_CHECK_ONLINE_JOBS]
** Name  :   dbo.USP_CHECK_ONLINE_JOBS
** Desc  :   
** Author:   Bipul
** Date  :   April 13, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_CHECK_ONLINE_JOBS]
(
	@C_ID As int = 13896
	, @TNO As varchar(100) = '98125,98126'
)
AS 
BEGIN
	DECLARE @STRQuery As varchar(500) = ''
	
	SET @STRQuery = @STRQuery + 'DECLARE @OnlineJobs As int = 0' + CHAR(13)
	SET @STRQuery = @STRQuery + 'DECLARE @TotalJobs As int = 0' + CHAR(13)
	
	SET @STRQuery = @STRQuery + 'SELECT @OnlineJobs = COUNT(id) FROM tmpJobs where acc_Id = ' + CAST(@C_ID As varchar(5)) + ' And TNO IN(' + @TNO + ')' + CHAR(13)
	
	SET @STRQuery = @STRQuery + 'SELECT @TotalJobs = COUNT(id) FROM tmpJobs where acc_Id = ' + CAST(@C_ID As varchar(5))+ CHAR(13)
	
	SET @STRQuery = @STRQuery + 'SELECT @OnlineJobs As OnlineJobs, @TotalJobs As TotalJobs' + CHAR(13)
	
	--PRINT @STRQuery
	EXEC(@STRQuery)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INVOICE_REMARKS_RPT]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_VIEW_JOURNAL_LIST]    Script Date: 08/06/2015 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_VIEW_JOURNAL_LIST]
** Name  :   dbo.USP_VIEW_JOURNAL_LIST
** Desc  :   
** Author:   Bipul
** Date  :   May 18, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_VIEW_JOURNAL_LIST]
(
	@PageNo int = 1
	, @PageSize int = 20
	, @Preview bit = 0
	, @DateType As varchar(20) = 'PostDate'
	, @StartDate As varchar(10) = '05/15/2015'
	, @EndDate As varchar(10) = '05/19/2015'
	, @LedgerID As int = 0--1
	, @LedgerName As varchar(100) = ''
	, @CompanyID As int = 0--105
	, @ApprovedBy As int = 0--10
	, @PostedBy As int = 0--15
	, @Approved As bit = 0
)
AS
BEGIN
	DECLARE @PostDate As varchar(10) = ''
		, @JDate As varchar(10) = ''
		, @ApprovalDate As varchar(10) = ''
		, @STRQuery As varchar(2000) = ''
		, @Select As varchar(200) = ''
		, @From As varchar(200) = ''
		, @Where As varchar(1000) = 'WHERE '
		, @StartingIndex int = 1
		, @OrderBy As varchar(100) = ''
	
	SET @EndDate = CONVERT(VARCHAR(10),DATEADD(DAY,1,@EndDate),111)
	
	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize
	
	IF @Preview = 0
		SET @OrderBy = ' ORDER BY j.jdate,j.jid,j.debt desc,j.id' + ' offset ' + CAST(@StartingIndex As varchar(5)) + ' rows fetch  next ' + CAST(@PageSize As varchar(5)) + ' rows only'
	ELSE
		SET @OrderBy = ' ORDER BY j.jdate,j.jid,j.Debt Desc,l.sbname'

	IF @Preview = 0
		SET @Select = @Select + 'SELECT j.id,l.SBName,j.Description,j.Debt,j.Credit,j.jDate,j.sid,j.jid,j.UserID,j.ApprovedBy,j.Notify,j.tno,j.ApprovalDate,j.UpdatedDate,j.UpdatedBy, COUNT(j.id) OVER() As TotalRecords' + CHAR(13)
	ELSE
		SET @Select = @Select + 'SELECT j.id,l.id as lid,l.sbname,j.Description,j.Debt,j.Credit,j.jDate,j.jid,a.Name as Approval,u.Name as Users,j.PostDate' + CHAR(13)

	IF @Preview = 0
		BEGIN
			SET @From = @From + 'FROM journal j ' + CHAR(13)
			SET @From = @From + '	INNER JOIN Ledger l ON l.id=j.sid' + CHAR(13)
		END
	ELSE
		BEGIN
			SET @From = @From + 'FROM journal j ' + CHAR(13)
			SET @From = @From + '	INNER JOIN Ledger l ON l.id=j.sid' + CHAR(13)
			SET @From = @From + '	INNER JOIN Users a ON j.ApprovedBy=a.UserID' + CHAR(13)
			SET @From = @From + '	INNER JOIN Users u ON j.UserID=u.UserID' + CHAR(13)
		END

	SET @Where = @Where + 'J.' + @DateType + ' BETWEEN ''' + @StartDate + ''' And ''' + @EndDate + '''' + CHAR(13)

	IF (@LedgerID >= 0) And (@LedgerID <= 5)
		BEGIN
			IF @LedgerID <> 0
				SET @Where = @Where + ' And j.jid in (select j.jid from journal j,ledger l where l.mgroup=''' + @LedgerName + ''' And l.ledgerAcc=1 And l.id=j.sid)' + CHAR(13)
		END
	ELSE
		SET @Where = @Where + ' And j.jid in (select j.jid from journal j,ledger l where l.ID = ' + CAST(@LedgerID As varchar(10)) + ')' + CHAR(13)

	IF @CompanyID > 0
		SET @Where = @Where + ' And j.tno in (select tno from sales where cid = ' + CAST(@CompanyID As varchar(10)) + ') And (j.notify=''Sales'' or j.notify=''AR'' or j.notify=''Tax'' or j.notify=''VAT'')' + CHAR(13)

	IF @ApprovedBy > 0
		SET @Where = @Where + ' And j.ApprovedBy = ' + CAST(@ApprovedBy As varchar(10))

	IF @PostedBy > 0
		SET @Where = @Where + ' And j.UserID = ' + CAST(@PostedBy As varchar(10))

	IF @Approved = 1
		SET @Where = @Where + ' and j.ApprovedBy <> 0' + CHAR(13)
	ELSE
		SET @Where = @Where + ' and j.ApprovedBy = 0' + CHAR(13)

	SET @STRQuery = @Select + @From + @Where + @OrderBy

	--PRINT @STRQuery

	SET NOCOUNT ON
	EXEC(@STRQuery)	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_INVOICE]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_LABEL_RPT]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LIST_OF_LABEL_RPT]
** Name  :   dbo.USP_LIST_OF_LABEL_RPT
** Desc  :   
** Author:   Bipul
** Date  :   April 07, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LIST_OF_LABEL_RPT]
(
	@LabelType As bit = 0
	, @listIds As varchar(1000) = '90,98,158,89,151,195,166,117,178,179'
)
AS 
BEGIN
	DECLARE @STRQuery As varchar(1500) = ''

	IF @LabelType = 0
		BEGIN
			SET @STRQuery = @STRQuery + ';WITH Label_CTE AS (' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT DISTINCT p.name as pname,p.designation,c.name as cname,c.address,c.city ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'FROM ContactPersons p,company c,InvoiceSceduler i,sales s ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'WHERE i.invoice_id IN (' + @listIds + ') and i.tno=s.tno and s.BillContactID=p.id and p.cid=c.id' + CHAR(13)
			--SET @STRQuery = @STRQuery + 'ORDER BY c.name' + CHAR(13)
			SET @STRQuery = @STRQuery + ')' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT ROW_NUMBER() OVER (ORDER BY pname) AS Id,pname,designation,cname,address,city ' + CHAR(13)			SET @STRQuery = @STRQuery + 'FROM Label_CTE	' + CHAR(13)
		END
	ELSE
		BEGIN
			SET @STRQuery = @STRQuery + ';WITH Label_CTE AS (' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT DISTINCT Contact_Person as pname,designation,name as cname,address,city ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'FROM Company Where Id IN (' + @listIds + ')' + CHAR(13)
			--SET @STRQuery = @STRQuery + 'ORDER BY c.name' + CHAR(13)
			SET @STRQuery = @STRQuery + ')' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT ROW_NUMBER() OVER (ORDER BY pname) AS Id,pname,designation,cname,address,city ' + CHAR(13)			SET @STRQuery = @STRQuery + 'FROM Label_CTE	' + CHAR(13)
		END
	
	--PRINT @STRQuery
	EXEC(@STRQuery)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_INVOICE_RPT]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_INVOICE]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LIST_OF_INVOICE]
** Name  :   dbo.USP_LIST_OF_INVOICE
** Desc  :   
** Author:   Bipul
** Date  :   April 02, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LIST_OF_INVOICE]
(
	@PageNo int = 1,
	@PageSize int = 10,
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
	
	SET @Select = @Select + 'SELECT i.id,i.invoice_no,c.name,i.tamount,i.invsendDt,CASE WHEN i.Sent = 0 THEN ''NO'' ELSE ''YES'' END As Sent,i.SendMode,i.Emailed,CASE WHEN i.FullPayment = 0 THEN ''NO'' ELSE ''Yes'' END As FullPayment, COUNT(1) OVER() As TotalInvoice ' + CHAR(13)
	SET @From = @From + 'FROM invoiceList i Inner Join company c on i.CID = c.Id ' + CHAR(13)
	SET @Where = @Where + 'WHERE'
	SET @Where = @Where + ' i.invalid = ' + CAST(@Validity As varchar(1)) + CHAR(13)

	IF @FullPayment = 1
		SET @Where = @Where + ' And i.FullPayment = 0' + CHAR(13)
	ELSE IF @FullPayment = 2
		SET @Where = @Where + ' And i.FullPayment = 1' + CHAR(13)

	IF @BlackListed = 0
	--	SET @Where = @Where + ' And c.BlackListed=1' + CHAR(13)
	--ELSE
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

	--PRINT @STRQuery
	EXEC(@STRQuery)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_APPROVE_JOURNAL]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_APPROVE_JOURNAL]
** Name  :   dbo.USP_APPROVE_JOURNAL
** Desc  :   
** Author:   Bipul
** Date  :   May 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_APPROVE_JOURNAL]
(
	@UserID int = 66
	, @DateType As varchar(20) = 'PostDate'
	, @StartDate As varchar(10) = '05/18/2015'
	, @EndDate As varchar(10) = '05/19/2015'
	, @LedgerID As int = 5
	, @LedgerName As varchar(20) = 'Revenue'
	, @CompanyID As int = 0--105
	, @ApprovedBy As int = 0--10
	, @PostedBy As int = 0
	, @Approved As bit = 0
)
AS
BEGIN
	DECLARE @PostDate As varchar(10) = ''
		, @Variable As varchar(200) = ''
		, @JDate As varchar(10) = ''
		, @ApprovalDate As varchar(10) = ''
		, @STRQuery As varchar(5000) = ''
		, @CountSelect As varchar(200) = ''
		, @BalanceSelect As varchar(200) = ''
		, @Select As varchar(200) = ''
		, @From As varchar(200) = ''
		, @Where As varchar(1000) = 'WHERE '
		, @StartingIndex int = 1
		, @OrderBy As varchar(100) = ''
		, @IFElse As varchar(100) = ''
		, @Update As varchar(2000) = ''

	SET @Variable = @Variable + 'DECLARE @Count As int = 0' + CHAR(13)
	SET @Variable = @Variable + 'DECLARE @Balance As float = 0' + CHAR(13)
	SET @Variable = @Variable + 'DECLARE @Result As int = 0' + CHAR(13) + CHAR(13)
		
	SET @CountSelect = @CountSelect + 'SELECT @Count=COUNT(j.id)' + CHAR(13)

	SET @BalanceSelect = @BalanceSelect + 'SELECT @Balance=(SUM(j.Debt)-SUM(j.Credit))' + CHAR(13)

	SET @Select = @Select + '		UPDATE J SET J.ApprovedBy = ' + CAST(@UserID As varchar(10)) + ', J.ApprovalDate = CONVERT(VARCHAR(10),GETDATE(),111)' + CHAR(13)

	SET @From = @From + 'FROM journal j ' + CHAR(13)
	SET @From = @From + '	INNER JOIN Ledger l ON l.id=j.sid' + CHAR(13)

	SET @Where = @Where + 'J.' + @DateType + ' BETWEEN ''' + @StartDate + ''' And ''' + @EndDate + '''' + CHAR(13)

	IF (@LedgerID >= 0) And (@LedgerID <= 5)
		BEGIN
			IF @LedgerID <> 0
				SET @Where = @Where + ' And j.jid in (select j.jid from journal j,ledger l where l.mgroup=''' + @LedgerName + ''' and l.ledgerAcc=1 And l.id=j.sid)' + CHAR(13)
		END
	ELSE
		SET @Where = @Where + ' And j.jid in (select j.jid from journal j,ledger l where l.ID = ' + CAST(@LedgerID As varchar(10)) + ')' + CHAR(13)

	IF @CompanyID > 0
		SET @Where = @Where + ' And j.tno in (select tno from sales where cid = ' + CAST(@CompanyID As varchar(10)) + ') and (j.notify=''Sales'' or j.notify=''AR'' or j.notify=''Tax'' or j.notify=''VAT'')' + CHAR(13)

	IF @ApprovedBy > 0
		SET @Where = @Where + ' And j.ApprovedBy = ' + CAST(@ApprovedBy As varchar(10))

	IF @PostedBy > 0
		SET @Where = @Where + ' And j.UserID = ' + CAST(@PostedBy As varchar(10))

	IF @Approved = 1
		SET @Where = @Where + ' and j.ApprovedBy <> 0' + CHAR(13)
	ELSE
		SET @Where = @Where + ' and j.ApprovedBy = 0' + CHAR(13)

	SET @IFElse = @IFElse + 'IF @Count > 0' + CHAR(13)	SET @IFElse = @IFElse + '	SET @Result = 1' + CHAR(13)	SET @IFElse = @IFElse + 'ELSE IF @Balance <> 0' + CHAR(13)	SET @IFElse = @IFElse + '	SET @Result = 2' + CHAR(13)	SET @IFElse = @IFElse + 'ELSE' + CHAR(13)	SET @IFElse = @IFElse + '	SET @Result = 0' + CHAR(13)
	
	SET @Update = @Update + 'IF @Result = 0' + CHAR(13)
	SET @Update = @Update + '	BEGIN' + CHAR(13)
		
	SET @Update = @Update + ('UPDATE f SET f.Approved=1' + CHAR(13) + @From + '	INNER JOIN FixedAsset f ON f.id=J.Tno And Approved=0' + CHAR(13) + @Where + 'And J.Notify = ''FixedAsset'' And J.Sid <> 99 And J.Sid <> 100') + CHAR(13)
	
	SET @Update = @Update + (@Select + @From + @Where) + CHAR(13) + CHAR(13)
	
	SET @Update = @Update + '		SELECT @Result As Result' + CHAR(13)
	SET @Update = @Update + '	END' + CHAR(13)
	SET @Update = @Update + 'ELSE' + CHAR(13)
	SET @Update = @Update + '	SELECT @Result As Result' + CHAR(13)

	SET @STRQuery = @Variable + (@CountSelect + @From + @Where + ' And j.UserID = ' + CAST(@UserID As varchar(10))) + CHAR(13) + CHAR(13) + (@BalanceSelect + @From + @Where) + CHAR(13) + @IFElse + CHAR(13) + @Update

	--PRINT @STRQuery

	SET NOCOUNT ON
	EXEC(@STRQuery)	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_UPDATE_COMPANY]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[INSERT_UPDATE_COMPANY]
** Name  :   dbo.INSERT_UPDATE_COMPANY
** Desc  :   
** Author:   Bipul
** Date  :   March 24, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[INSERT_UPDATE_COMPANY]
(
	@Name varchar(100) = '',
	@Address varchar(250) = '',
	@City varchar(50) = '',
	@Phone varchar(100) = '',
	@Email varchar(100) = '',
	@Fax varchar(100) = '',
	@Contact_Person varchar(100) = '',
	@Designation varchar(50) = '',
	@BlackListed bit = 0,
	@CP_ID int = 0,
	@AccContactName varchar(200) = '',
	@VATRegNo varchar(15) = '',
	@VATRegAdd varchar(25) = '',
	@Id int = 0
)
AS
BEGIN
	DECLARE @CID int = 0
	DECLARE @Exist int = 0
	IF @Id = 0
		BEGIN
			INSERT INTO Company(Name, Address, City, Phone, Email, Fax, Contact_Person, Designation, BlackListed, CP_ID, AccContactName, VATRegNo, VATRegAdd)
			VALUES(@Name, @Address, @City, @Phone, @Email, @Fax, @Contact_Person, @Designation, @BlackListed, @CP_ID, @AccContactName, @VATRegNo, @VATRegAdd)
			
			SELECT @CID = MAX(ID) FROM Company
			
			INSERT INTO ContactPersons(CID, Name, Designation, PType)
			VALUES(@CID, @Contact_Person, @Designation, 'Contact person')
		END
	ELSE
		BEGIN
			UPDATE Company
				SET Name = @Name,
				Address = @Address,
				City = @City,
				Phone = @Phone,
				Email = @Email,
				Fax = @Fax,
				Contact_Person = @Contact_Person,
				Designation = @Designation,
				BlackListed = @BlackListed,
				CP_ID = @CP_ID,
				AccContactName = @AccContactName,
				VATRegNo = @VATRegNo,
				VATRegAdd = @VATRegAdd
			WHERE ID = @Id
			
			SELECT @Exist=COUNT(ID) FROM ContactPersons
			WHERE CID = @Id And Name = @Contact_Person And PType = 'Contact person'
			
			IF @Exist > 0
				BEGIN
					UPDATE ContactPersons
						SET Name = @Contact_Person,
						Designation = @Designation
					WHERE ID = @Exist And CID = @Id
				END
			ELSE
				BEGIN
					INSERT INTO ContactPersons(CID, Name, Designation, PType)
					VALUES(@Id, @Contact_Person, @Designation, 'Contact person')
				END
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_TRIAL_BALANCE_RPT]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_TRIAL_BALANCE_RPT]
** Name  :   dbo.USP_TRIAL_BALANCE_RPT
** Desc  :   
** Author:   Bipul
** Date  :   May 11, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_TRIAL_BALANCE_RPT]
(
	@Type varchar(5) = 'Month',
	@StartingDate varchar(10) = '',
	@EndDate varchar(10) = ''
)
AS
BEGIN

	SET NOCOUNT ON
	
	IF @Type = 'Month'
		BEGIN
			SELECT l.sbname,l.mgroup,sum(j.debt-j.credit) as Total 
			FROM ledger l,journal j 
			WHERE MONTH(j.jdate) = CAST(@StartingDate As int) and YEAR(j.jdate) = CAST(@EndDate AS int) and j.sid=l.id 
			GROUP BY l.mgroup,l.sbname HAVING sum(j.debt-j.credit) <> 0 
			ORDER BY l.mgroup,l.sbname
		END
	ELSE
		BEGIN
			SELECT l.sbname,l.mgroup,sum(j.debt-j.credit) as Total 
			FROM ledger l,journal j 
			WHERE j.jdate>= @StartingDate and j.jdate < @EndDate and j.sid=l.id 
			GROUP BY l.mgroup,l.sbname HAVING sum(j.debt-j.credit) <> 0 
			ORDER BY l.mgroup,l.sbname
		END
	
	SET NOCOUNT OFF
	
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SET_INVOICE_NUMBER]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_PREVIEW_TRIAL_BALANCE]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_PREVIEW_TRIAL_BALANCE]
** Name  :   dbo.USP_PREVIEW_TRIAL_BALANCE
** Desc  :   
** Author:   Bipul
** Date  :   May 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_PREVIEW_TRIAL_BALANCE]
(
	--@PageNo int = 1
	--, @PageSize int = 20
	@Type As varchar(20) = 'Revenue'
	, @FromDate As varchar(10) = '05/01/2015'
	, @EndDate As varchar(10) = '05/20/2015'
)
AS
BEGIN
	--DECLARE @StartingIndex int = 1
	
	--IF @PageNo > 0
	--	SET @StartingIndex = (@PageNo -1) * @PageSize
	
	SET @EndDate = CONVERT(VARCHAR(10),DATEADD(DAY,1,@EndDate),111)
	
	SET NOCOUNT ON

	IF @Type = 'All'
		BEGIN
			SELECT j.id, j.jid, p.sbname As AccName,j.description,j.Debt,j.Credit,j.JDate, p.MGroup As [Group]--, COUNT(j.id) OVER() As TotalRecord
			FROM journal j 
				INNER JOIN Ledger p ON j.sid=p.id 
			WHERE j.Jdate >= @FromDate And j.Jdate < @EndDate
			ORDER BY j.jdate,j.jid,j.debt desc,j.id --OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY
		END
	ELSE
		BEGIN
			;WITH Journal_CTE As(
				SELECT DISTINCT j.jid,j.JDate
				FROM journal j 
					INNER JOIN Ledger l ON j.sid=l.id 
				WHERE j.Jdate between @FromDate and @EndDate and l.mgroup=@Type
			)
			SELECT j.id, j.Jid, l.sbname,j.description,j.Debt,j.Credit, J.JDate, l.MGroup As [Group]--, COUNT(j.id) OVER() As TotalRecord
			FROM journal j 
				INNER JOIN Ledger l ON j.sid=l.id
				INNER JOIN Journal_CTE j1 ON J.Jid = J1.Jid
			ORDER BY j.jdate,j.jid,j.debt desc,j.id --OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY
		END

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ONLINE_SALE_INFO]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ONLINE_SALE_INFO]
** Name  :   dbo.USP_ONLINE_SALE_INFO
** Desc  :   
** Author:   Bipul
** Date  :   April 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ONLINE_SALE_INFO]
(
	@Type As char(1) = 'T'
	, @CompanyID As int = 11092
	--, @PostingDate As varchar(10) = ''
)
AS 
BEGIN
	SET NOCOUNT ON
	
	IF @Type = 'C'
		BEGIN
			--Fill Billing Person
			SELECT id, name, Designation 
			FROM contactPersons 
			WHERE cid=@CompanyID
		END
	ELSE
		BEGIN
			--Fill Job Title
			SELECT jp_id, title, postingDate, ValidDate, BillingContact, designation--, Acc_Id 
			FROM tmpjobs 
			WHERE tno=0 And Acc_id=@CompanyID --And PostingDate = @PostingDate
			ORDER BY title
		END
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ONLINE_JOB_LIST]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ONLINE_JOB_LIST]
** Name  :   dbo.USP_ONLINE_JOB_LIST
** Desc  :   
** Author:   Bipul
** Date  :   April 15, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ONLINE_JOB_LIST]
AS 
BEGIN
	;WITH AddType_CTE AS(
		SELECT CP_ID FROM tmpJobs WHERE AddType > 0 GROUP BY CP_ID
	),
	SELECT_CTE AS(
		SELECT cp_id,acc_id,cname,count(cp_id) as JobPosted,tjobs As TotalJobPosted, OPID, AddType, PostingDate
		FROM tmpJobs
		GROUP BY cp_id,acc_id,cname,tjobs,invoice_no, OPID, AddType, PostingDate
	)
	SELECT ROW_NUMBER() OVER(ORDER BY s.PostingDate) As Serial, s.CP_ID, s.Acc_Id, s.CName, s.JobPosted, s.TotalJobPosted, s.OPID
	, s.AddType
	, CASE WHEN s.Acc_Id > 0 THEN 'Exist' ELSE 'New' END As CompanyStatus, s.PostingDate
	FROM SELECT_CTE As s LEFT JOIN AddType_CTE As a ON s.CP_ID = a.CP_ID
	ORDER BY s.PostingDate, s.cname	--s.acc_id, s.cname 	-- 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ONLINE_COMPANY_LIST]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ONLINE_COMPANY_LIST]
** Name  :   dbo.USP_ONLINE_COMPANY_LIST
** Desc  :   
** Author:   Bipul
** Date  :   April 30, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ONLINE_COMPANY_LIST]
(
	@ViewType As char(3) = 'New'
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	IF @ViewType = 'New'
		SELECT DISTINCT cp_id,cname,acc_id FROM tmpJobs WHERE acc_id=0 ORDER BY cname
	ELSE
		SELECT DISTINCT cp_id, CASE WHEN acc_id = 0 THEN cname + ' - New' ELSE cname + ' - EXIST' END As CName
		, acc_id 
		FROM tmpJobs 
		ORDER BY cname, acc_id
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LOAD_FIXED_ASSETS_ITEM]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LOAD_FIXED_ASSETS_ITEM]
** Name  :   dbo.USP_LOAD_FIXED_ASSETS_ITEM
** Desc  :   
** Author:   Bipul
** Date  :   April 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LOAD_FIXED_ASSETS_ITEM]
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT l.id As ItemID, l.sbname As ItemName
	, (SELECT FORMAT(id,'0000')
		FROM ledger 
		WHERE id = (
			SELECT REVERSE(LEFT(REVERSE(under), charindex(',', REVERSE(under)) - 1))
			FROM ledger 
			WHERE id = l.id)) As AssetType
	, (SELECT sbname
		FROM ledger 
		WHERE id = (
			SELECT REVERSE(LEFT(REVERSE(under), charindex(',', REVERSE(under)) - 1))
			FROM ledger 
			WHERE id = l.id)) As AssetName
	FROM ledger l
	WHERE l.under LIKE '%,30,%' OR l.under LIKE '%,30' And l.LedgerAcc=1 And l.id NOT IN(99,100) -- Except 'Depreciation' & 'Accumulated Depreciation'
	ORDER BY sbname
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LedgerList]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LedgerList]
** Name  :   dbo.USP_LedgerList
** Desc  :   
** Author:   Bipul
** Date  :   March 28, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LedgerList]
(
	@AccountsDep As bit = 0
	, @UserAdmin As bit = 0
	, @MGroup As varchar(10) = ''
	, @All As char(3) = ''
	, @InvoiceLedger As char(1) = ''
	, @Tax As tinyint = 0
)
AS 
BEGIN
	IF @Tax = 0
		BEGIN
			IF @MGroup = ''
				BEGIN
					IF @AccountsDep = 1 OR @UserAdmin = 1
						BEGIN
							;WITH Ledger_CTE AS (
								SELECT 0 As Serial, 0 As ID, 'All' As LadgerName
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Asset'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Capital'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Expense'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Liability'
								UNION
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Revenue'
								UNION
								SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial, id, SBName As LadgerName FROM ledger WHERE ledgerAcc=1 --And MGroup='Revenue'
							)
							SELECT ID, LadgerName FROM Ledger_CTE
							ORDER BY Serial
						END
					ELSE
						BEGIN
							;WITH Ledger_CTE AS (
								SELECT 0 As Serial, ID, SBName As LadgerName FROM ledger WHERE SBName = 'Revenue'
								UNION
								SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial, id, SBName As LadgerName 
								FROM ledger 
								WHERE ledgerAcc=1 and MGroup='Revenue'
							)
							SELECT ID, LadgerName FROM Ledger_CTE
							ORDER BY Serial
						END
				END
			ELSE
				BEGIN
					IF @All = 'All'
						BEGIN
							IF @InvoiceLedger = 'I'
								BEGIN
									;WITH Ledger_CTE AS (
										SELECT DISTINCT l.id, l.sbname 
										FROM ledger l INNER JOIN sales s ON l.id=s.pcode
										WHERE l.mgroup=@MGroup and l.LedgerAcc=1
										--SELECT 0 As Serial, 0 As ID, 'All' As LadgerName								
									)
									,SalesLesger_CTE AS (
										SELECT 0 As Serial, 0 As ID, 'All' As LadgerName
										UNION
										SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial,id, SBName As LadgerName 
										FROM Ledger_CTE 
									)
									SELECT ID, LadgerName FROM SalesLesger_CTE
									ORDER BY Serial
								END
							ELSE
								BEGIN
									;WITH Ledger_CTE AS (
										SELECT 0 As Serial, 0 As ID, 'All' As LadgerName
										UNION
										SELECT ROW_NUMBER() OVER(ORDER BY SBName) As Serial,id, SBName As LadgerName 
										FROM ledger 
										WHERE ledgerAcc=1 and MGroup=@MGroup
									)
									SELECT ID, LadgerName FROM Ledger_CTE
									ORDER BY Serial
								END
						END
					ELSE
						BEGIN
							SELECT id, SBName As LadgerName 
							FROM ledger 
							WHERE ledgerAcc=1 and MGroup=@MGroup
							ORDER BY SBName
						END
				END
		END
	ELSE
		BEGIN
			DECLARE @LedgerLiabilitySalesTaxes As varchar(5) = '%,693'
			
			SELECT  id,SBName FROM Ledger WHERE ledgerAcc=1 and Under like @LedgerLiabilitySalesTaxes order by sbname
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LEDGER_LIST_LR]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LEDGER_LIST_LR]
** Name  :   dbo.USP_LEDGER_LIST_LR
** Desc  :   
** Author:   Bipul
** Date  :   May 31, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LEDGER_LIST_LR]
(
	@MGroup As varchar(10) = ''
	, @CID As int = -1
)
AS 
BEGIN
	IF (@MGroup <> '') And (@CID <= 0)
		BEGIN
			SELECT id, SBName As LadgerName 
			FROM ledger 
			WHERE ledgerAcc=1 And MGroup=@MGroup
			ORDER BY SBName
		END
	ELSE IF (@MGroup <> '') And (@CID >= 0)
		BEGIN
			IF @CID > 0
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 And MGroup=@MGroup And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
			ELSE
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 And MGroup=@MGroup --And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
		END
	ELSE IF (@MGroup = '') And (@CID >= 0)
		BEGIN
			IF @CID > 0
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
			ELSE
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 --And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_JOURNAL_VOUCHER_RPT]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_JOURNAL_VOUCHER_RPT]
** Name  :   dbo.USP_JOURNAL_VOUCHER_RPT
** Desc  :   
** Author:   Bipul
** Date  :   April 23, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_JOURNAL_VOUCHER_RPT]
(
	@JID As int = 348377
)
AS 
BEGIN
	SET NOCOUNT ON
	
	SELECT l.sbname,j.description,j.debt,j.credit,j.jdate,u1.name as PostedBy,u1.designation as des1,j.PostDate,u2.name as ApprBy,u2.designation as des2,j.ApprovalDate,v.VoucherNo 
	FROM ledger l
		INNER JOIN journal j ON j.Sid = L.Id 
		INNER JOIN users u1 ON j.userid = u1.userid
		INNER JOIN users u2 ON j.Approvedby = u2.userid
		INNER JOIN JournalVoucher v ON j.jid=v.jid
	WHERE j.jid = @JID 
	ORDER BY j.debt desc,l.sbname
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_LABEL]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LIST_OF_LABEL]
** Name  :   dbo.USP_LIST_OF_LABEL
** Desc  :   
** Author:   Bipul
** Date  :   April 07, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LIST_OF_LABEL]
(
	@PageNo int = 1
	, @PageSize int = 10
	, @LabelType As bit = 0
	, @ProductID As int = 44
	, @FromDate As varchar(10) = ''
	, @ToDate As varchar(10) = ''
)
AS 
BEGIN
	DECLARE @StartingIndex int = 1
		
	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize

	IF @LabelType = 0
		BEGIN
			IF @ProductID = 0
				BEGIN
					----PRINT @FromDate
					--SELECT id,Invoice_No As ItemName, COUNT(id) OVER() As NoOfRow
					--FROM InvoiceList 
					----WHERE id=1 
					--ORDER BY substring(Invoice_No,15,5) DESC offset @StartingIndex  rows fetch  next @PageSize rows only
					;WITH Invoice_CTE AS(
						SELECT DISTINCT i.id,i.Invoice_No as ItemName
						FROM InvoiceList i
							INNER JOIN InvoiceSceduler i1 ON i.id=i1.Invoice_id
							INNER JOIN Sales s ON i1.TNO=s.TNO 
					)
					SELECT id, ItemName, COUNT(id) OVER() As NoOfRow
					FROM Invoice_CTE
					ORDER BY substring(ItemName,15,5) DESC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
			ELSE
				BEGIN
					;WITH Invoice_CTE AS(
						SELECT DISTINCT i.id,i.Invoice_No as ItemName
						FROM InvoiceList i
							INNER JOIN InvoiceSceduler i1 ON i.id=i1.Invoice_id
							INNER JOIN Sales s ON i1.TNO=s.TNO 
						WHERE s.PCode = @ProductId and i.InvSendDt BETWEEN @FromDate And @ToDate
					)
					SELECT id, ItemName, COUNT(id) OVER() As NoOfRow
					FROM Invoice_CTE
					ORDER BY Id DESC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
		END
	ELSE
		BEGIN
			IF @ProductID = 0
				BEGIN
					SELECT id,Name as ItemName, COUNT(id) OVER() As NoOfRow
					FROM Company 
					ORDER BY Name ASC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
			ELSE
				BEGIN
					;WITH Company_CTE AS (
						SELECT DISTINCT c.id,c.Name as ItemName
						FROM Company c
							INNER JOIN Sales s ON c.id=s.cid
							INNER JOIN InvoiceSceduler i1 ON i1.TNO=s.TNO 
							INNER JOIN InvoiceList i ON i.id=i1.Invoice_id
						WHERE s.PCode = @ProductId and i.InvSendDt BETWEEN @FromDate And @ToDate
					)
					SELECT id, ItemName, COUNT(id) OVER() As NoOfRow
					FROM Company_CTE
					ORDER BY ItemName ASC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UPLOAD_INVOICE_ONLINE]    Script Date: 08/06/2015 11:22:37 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_INVOICE]    Script Date: 08/06/2015 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UPDATE_INVOICE]
** Name  :   dbo.USP_UPDATE_INVOICE
** Desc  :   
** Author:   Bipul
** Date  :   April 12, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UPDATE_INVOICE]
(
	@Action As char(1) = 'D'
	, @InvSchID As int = 0
	, @InvoiceID As int = 0
	, @Amount As float = 0
	, @Comments As varchar(200) = ''
)
AS 
BEGIN
	SET NOCOUNT ON
	
	DECLARE @ChangeAmount As float = 0
	DECLARE @PreAmount As float = 0

	SELECT @PreAmount = Amount FROM InvoiceSceduler WHERE id = @InvSchID

	SET @ChangeAmount = @PreAmount - @Amount

	IF @Action = 'D'
		BEGIN
-- Update InvoiceList
			UPDATE InvoiceList 
				SET TAmount = TAmount-@Amount 
			WHERE Id = @InvoiceID

-- Update InvoiceScheduler
			UPDATE InvoiceSceduler 
				SET Invoice_Id = 0 
			WHERE id = @InvSchID
		END
	ELSE IF @Action = 'U'
		BEGIN
-- Update InvoiceScheduler
			UPDATE InvoiceSceduler 
				SET Comments = @Comments,
				Amount =  @Amount
			WHERE id = @InvSchID
		
-- Update InvoiceList
			IF @ChangeAmount <> 0
				BEGIN
					UPDATE InvoiceList 
						SET TAmount = TAmount-@ChangeAmount 
					WHERE Id = @InvoiceID
				END
		END
	ELSE
		BEGIN
-- Update InvoiceScheduler
			UPDATE InvoiceSceduler 
				SET Comments = @Comments
			WHERE id = @InvSchID
		END
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_VIEW_SALES]    Script Date: 08/06/2015 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_VIEW_SALES]
** Name  :   dbo.USP_VIEW_SALES
** Desc  :   
** Author:   Bipul
** Date  :   May 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_VIEW_SALES]
(
	@PageNo int = 1
	, @PageSize int = 10
	, @CID int = 0
	, @TNO int = 0
)
AS
BEGIN
	DECLARE @StartingIndex int = 1

	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize
	
	SET NOCOUNT ON
	
	IF @CID > 0
		BEGIN
			SELECT l.id, l.sbname, s.TNO, s.sdate As [From], CASE WHEN s.edate IS NULL THEN DATEADD(MONTH,1,s.sdate) ELSE s.edate END As [To]
			, s.salesPrice, s.AccReceivable, s.Duration, s.Posted, s.RefNo, s.Tax, s.TaxID, s.BillContactId 
			, SUM(s.salesPrice) OVER()+SUM(s.Tax) OVER() As TotalAmount
			, SUM(s.AccReceivable) OVER() As DuesAmount
			, COUNT(s.TNO) OVER() As TotalRecord
			FROM Sales s
				INNER JOIN Ledger l ON s.pcode=l.id
			WHERE s.cid=@CID
			ORDER BY s.sdate OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY
		END
	ELSE
		BEGIN
			IF @TNO = 0
				BEGIN
					SELECT s.tno,c.name,l.sbname,s.salesprice,s.sdate, COUNT(s.tno) OVER() As TotalRecord
					FROM sales s 
						INNER JOIN Company c ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id
					ORDER BY c.name,s.sdate,l.sbname OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY				END			ELSE
				BEGIN
					SELECT s.tno,c.name,l.sbname,s.salesprice,s.sdate, COUNT(s.tno) OVER() As TotalRecord
					FROM sales s 
						INNER JOIN Company c ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id
					WHERE s.TNO = @TNO
					ORDER BY c.name,s.sdate,l.sbname OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY				END		END	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_VIEW_SALE_WISE_JOURNAL_LIST]    Script Date: 08/06/2015 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_VIEW_SALE_WISE_JOURNAL_LIST]
** Name  :   dbo.USP_VIEW_SALE_WISE_JOURNAL_LIST
** Desc  :   
** Author:   Bipul
** Date  :   May 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_VIEW_SALE_WISE_JOURNAL_LIST]
(
	@PageNo int = 1
	, @PageSize int = 10
	, @FromDate As varchar(10) = '01/01/2015'
	, @EndDate As varchar(10) = '04/30/2015'
	, @TNO As int = 0
)
AS
BEGIN
	DECLARE @StartingIndex int = 1
	
	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize
	
	SET @EndDate = CONVERT(VARCHAR(10),DATEADD(DAY,1,@EndDate),111)
	
	SET NOCOUNT ON

	IF @TNO>0
		BEGIN
			SELECT j.id,p.sbname,j.description,j.Debt,j.Credit,j.JDate,j.sid, SUM(j.Debt) OVER() As TotalDebt, SUM(j.Credit) OVER() As TotalCredit, COUNT(j.id) OVER() As TotalRecord
			FROM Journal j INNER JOIN Ledger p ON j.sid=p.id 
			WHERE j.tno = @TNO
			ORDER BY j.jdate,j.jid,j.debt desc,j.id OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY
		END
	ELSE
		BEGIN
			SELECT j.id,p.sbname,j.description,j.Debt,j.Credit,j.JDate,j.sid, SUM(j.Debt) OVER() As TotalDebt, SUM(j.Credit) OVER() As TotalCredit, COUNT(j.id) OVER() As TotalRecord
			FROM Journal j INNER JOIN Ledger p ON j.sid=p.id 
			WHERE j.Jdate >= @FromDate And j.Jdate < @EndDate
			ORDER BY j.jdate,j.jid,j.debt desc,j.id OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY
		END

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_ASSET]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_ASSET]
** Name  :   dbo.USP_INSERT_ASSET
** Desc  :   
** Author:   Bipul
** Date  :   April 27, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_ASSET]
(
	@Action As varchar(10) = 'INSERT'
	, @UserID As int = -1
	, @NoDep As bit
	, @AssetCode As varchar(15)
	, @AssetNo As int
	, @AssetType As int
	, @PurchasedDt As varchar(10)
	, @Price As float
	, @DepStartDt As varchar(10)
	, @Supplier As varchar(100)
	, @InvoiceNo As varchar(30)
	, @LabelNo As varchar(30)
	, @Description As varchar(700)
	, @DepRate As float
	, @DepLife smallint
	, @DepEndDt As varchar(10)
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	IF @Action = 'INSERT'
		BEGIN
			IF @NoDep = 0
				BEGIN
					INSERT INTO FixedAsset(AssetCode,AssetNo,AssetType,PurchasedDt,Price,DepRate,DepStartDt,DepLife,DepEndDt,Supplier,InvoiceNo,LabelNo,Description)
					VALUES (@AssetCode, @AssetNo, @AssetType, @PurchasedDt, @Price, @DepRate, @DepStartDt, @DepLife, @DepEndDt, @Supplier, @InvoiceNo, @LabelNo, @Description)
				END
			ELSE
				BEGIN
					INSERT INTO FixedAsset(AssetCode,AssetNo,AssetType,PurchasedDt,Price,DepStartDt,Supplier,InvoiceNo,LabelNo,Description,NoDep)
					VALUES (@AssetCode, @AssetNo, @AssetType, @PurchasedDt, @Price, @DepStartDt, @Supplier, @InvoiceNo, @LabelNo, @Description, 1)
				END
		END
	ELSE
		BEGIN
			IF @NoDep = 0
				BEGIN
					UPDATE FixedAsset
						SET AssetNo = @AssetNo
						, AssetType = @AssetType
						, PurchasedDt = @PurchasedDt
						, Price = @Price
						, DepRate = @DepRate
						, DepStartDt = @DepStartDt
						, DepLife = @DepLife
						, DepEndDt = @DepEndDt
						, Supplier = @Supplier
						, InvoiceNo = @InvoiceNo
						, LabelNo = @LabelNo
						, Description = @Description
						, NoDep = 0
					WHERE AssetCode = @AssetCode
				END
			ELSE
				BEGIN
					UPDATE FixedAsset
						SET AssetNo = @AssetNo
						, AssetType = @AssetType
						, PurchasedDt = @PurchasedDt
						, Price = @Price
						, DepRate = 0
						, DepStartDt = @DepStartDt
						, DepLife = 0
						, DepEndDt = NULL
						, Supplier = @Supplier
						, InvoiceNo = @InvoiceNo
						, LabelNo = @LabelNo
						, Description = @Description
						, NoDep = 1
					WHERE AssetCode = @AssetCode
				END
		END
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_JOURNAL_VOUCHER]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_GET_JOURNAL_VOUCHER]
** Name  :   dbo.USP_GET_JOURNAL_VOUCHER
** Desc  :   
** Author:   Bipul
** Date  :   April 22, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_GET_JOURNAL_VOUCHER]
(
	@Year As int = 2000
	, @MonthNo As tinyint = 12
)
AS 
BEGIN
	SET NOCOUNT ON
	
	;WITH JVoucher_CTE As (
		SELECT distinct v.JID, v.VoucherNo 
		FROM JournalVoucher v INNER JOIN Journal j ON j.jid=v.jid 
		WHERE year(j.jdate) = @Year and month(j.jdate) = @MonthNo
	)
	SELECT JID, (FORMAT(ROW_NUMBER() over (ORDER BY jid),'0000.') + '. ' + VoucherNo) As VoucherNo FROM JVoucher_CTE
	ORDER BY VoucherNo
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_INVOICE_INVSCHEDULE]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_GET_INVOICE_DETAIL]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_GENERATE_ASSET_CODE]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_GENERATE_ASSET_CODE]
** Name  :   dbo.USP_GENERATE_ASSET_CODE
** Desc  :   
** Author:   Bipul
** Date  :   April 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_GENERATE_ASSET_CODE]
(
	@AssetTypeID As int = 318
	, @AssetType As varchar(3) = ''
)
AS
BEGIN
	SET NOCOUNT ON
	
	IF @AssetType = ''
		SELECT @AssetType = LEFT(SBName, 3) FROM Ledger WHERE ID = @AssetTypeID
	
	--SELECT max(Substring(AssetCode, 1, 3)) + '-' + FORMAT(max(Substring(AssetCode, 5, 3))+1, '000') + '-' + FORMAT((Select max(Substring(AssetCode, 9, 10)) As MTCode from FixedAsset)+1, '0000') As AssteNo
	SELECT @AssetType + '-' + CASE WHEN MAX(AssetCode) IS NULL THEN '001' ELSE FORMAT(max(Substring(AssetCode, 5, 3))+1, '000') END + '-' + FORMAT((Select max(Substring(AssetCode, 9, 10)) As MTCode from FixedAsset)+1, '0000') As AssteNo
	FROM FixedAsset 
	WHERE AssetType = @AssetTypeID
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_FIXED_ASSETS_RPT]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_FIXED_ASSETS_RPT]
** Name  :   dbo.USP_FIXED_ASSETS_RPT
** Desc  :   
** Author:   Bipul
** Date  :   May 31, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_FIXED_ASSETS_RPT]
(
	@FromDate As varchar(10) = '5/1/2012'
)
AS
BEGIN
	DECLARE @Name1 As varchar(100)
	DECLARE @Name2 As varchar(100)
	DECLARE @AssetCode As varchar(15)
	DECLARE @Price As float
	DECLARE @DepRate As float
	DECLARE @DepStartDt As varchar(10)
	DECLARE @DepEndtDt As varchar(10)
	DECLARE @DepLife As smallint
	DECLARE @NoDep As bit

	DECLARE @MNO As smallint
	DECLARE @AccDep As float
	DECLARE @Amount As float
	DECLARE @AmountYrTD As float

	DECLARE @FixedAssets TABLE(
		Name1 varchar(100) NULL
		, Name2 varchar(100) NULL
		, Name3 varchar(100) NULL
		, Price float NULL
		, AmountYrTD float NULL
		, AccDep float NULL
		, Amount float NULL
		, DepStartDt varchar(10) NULL
	)
	DECLARE @FixedAsset CURSOR

	SET NOCOUNT ON
	
	SET @FixedAsset = CURSOR FAST_FORWARD FOR
	SELECT l1.SBName,l.sbname,f.AssetCode,f.price,f.depRate,CONVERT(varchar(10),f.depStartDt,111),CONVERT(varchar(10),f.depEndDt,111),f.deplife,f.NoDep 
	FROM ledger l
		INNER JOIN FixedAsset f ON f.assetNo=l.id
		INNER JOIN ledger l1 ON f.assetType=l1.id
	WHERE  f.depStartDt<=@FromDate and StopDep=0 
	ORDER BY l1.SBName,l.sbname
	OPEN @FixedAsset

	FETCH NEXT FROM @FixedAsset
	INTO @Name1, @Name2, @AssetCode, @Price, @DepRate, @DepStartDt, @DepEndtDt, @DepLife, @NoDep

	WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @MNO = DATEDIFF(MONTH, @DepStartDt, @FromDate)
			IF DAY(@FromDate) >= 15
				SET @MNO = @MNO + 1
			IF @MNO < @DepLife		--If Depreciation life is not completed
				BEGIN
					SET @AccDep = @DepRate * @MNO
					SET @Amount = @Price - @AccDep
				END
			ELSE					--If Depreciation life is completed
				BEGIN
					SET @AccDep = @Price
					SET @Amount = 0
				END
			IF @NoDep = 1
				BEGIN
					SET @Amount = 0
					SET	@AccDep = 0
					SET @AmountYrTD = 0
				END
			ELSE
				SET @AmountYrTD = (12 * 100) / @DepLife
			
			INSERT INTO @FixedAssets (Name1,Name2,Name3,Price,AmountYrTD,AccDep,Amount,DepStartDt)
			VALUES (@Name1, @Name2, @AssetCode, @Price, @AmountYrTD, @AccDep, @Amount, @DepStartDt)
			
			FETCH NEXT FROM @FixedAsset
			INTO @Name1, @Name2, @AssetCode, @Price, @DepRate, @DepStartDt, @DepEndtDt, @DepLife, @NoDep
		END

	CLOSE @FixedAsset
	DEALLOCATE @FixedAsset
	
	SELECT Name1, Name2, Name3, Price As M1, AmountYrTD As M2, AccDep As M3, Amount As M4, DepStartDt As DateS FROM @FixedAssets	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DUES_INVOICE]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_DUES_INVOICE]
** Name  :   dbo.USP_DUES_INVOICE
** Desc  :   
** Author:   Bipul
** Date  :   March 31, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_DUES_INVOICE]
(
	@ShowAs As char(1) = 'O',
	@CompanyID As int = 0,
	@ShdlDate As varchar(10) = ''
)
AS
BEGIN
	IF @ShowAs = 'O'
		BEGIN
			IF @CompanyID = 0
				BEGIN
					select s.cid,c.name,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount 
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1 And i.shdldate<=@ShdlDate
					order by i.shdldate
				END
			ELSE
				BEGIN
					select s.cid,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount  
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1  And i.shdldate<=@ShdlDate And c.id=@CompanyID
					order by i.shdldate
				END
		END
	ELSE
		BEGIN
			IF @CompanyID = 0
				BEGIN
					select s.cid,c.name,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount 
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1 
					order by i.shdldate
				END
			ELSE
				BEGIN
					select s.cid,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount  
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1 And c.id=@CompanyID
					order by i.shdldate
				END
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_SALE_INFO]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_DELETE_SALE_INFO]
** Name  :   dbo.USP_DELETE_SALE_INFO
** Desc  :   
** Author:   Bipul
** Date  :   May 23, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_DELETE_SALE_INFO](
	@TNO As int = -1
)
AS
BEGIN
	DECLARE @SaleTotal As float
	DECLARE @InvoiceTotal As float
	DECLARE @InvoiceId As int
	DECLARE @CCollection As int
	DECLARE @JFound As int
	DECLARE @Message As int
	DECLARE @CUR_INV CURSOR

	SELECT @CCollection = COUNT(id) FROM Cash_Collection WHERE tno = @TNO
	SELECT @JFound = COUNT(tno) FROM journal WHERE ApprovedBy>0 And tno = @TNO
	
------------------------- Delete Invoice from InvoiceList ----------------------------
	
	IF @CCollection > 0
		SET @Message = 1
	ELSE IF @JFound > 0
		SET @Message = 2
	ELSE
		SET @Message = 0
	
	IF @Message = 0
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
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
									UPDATE InvoiceList
									SET TAmount = @InvoiceTotal-@SaleTotal
									WHERE ID = @InvoiceId
								END
							ELSE
								BEGIN
									DELETE InvoiceList
									--SELECT * FROM InvoiceList
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
					
					SET @Message = 0
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
					BEGIN
						SET @Message = -1
						ROLLBACK TRANSACTION
					END
			END CATCH
		END
	
	SELECT @Message As [Message]
END
GO
/****** Object:  StoredProcedure [dbo].[USP_CompanyList]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_CompanyList]
** Name  :   dbo.USP_CompanyList
** Desc  :   
** Author:   Bipul
** Date  :   March 25, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_CompanyList]
(
	@All As varchar(3) = ''
)
AS
BEGIN
	IF @All = 'All'
		BEGIN
			;WITH Company_CTE AS (
				SELECT 0 As Serial, 0 As ID, 'All' As Name, 0 As BlackListed
				UNION
				SELECT ROW_NUMBER() OVER(ORDER BY Name) As Serial, id, Name, BlackListed FROM Company
			)
			SELECT ID, Name, BlackListed FROM Company_CTE
			ORDER BY Serial
		END
	ELSE
		SELECT id, Name, BlackListed FROM Company ORDER BY Name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_COLLECTION_NOTE]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_CheckJobTitle]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_CheckJobTitle]
** Name  :   dbo.USP_CheckJobTitle
** Desc  :   
** Author:   Bipul
** Date  :   March 29, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_CheckJobTitle]
(
	@ProductID As int = 44
)
AS
BEGIN
	SELECT ID, SBName FROM Ledger 
	WHERE SBName Like 'Online Job Posting%'
	And id = @ProductID
	UNION
	SELECT ID, SBName FROM Ledger 
	WHERE SBName Like 'Hot Jobs Announcement%'
	And id = @ProductID
	UNION
	SELECT ID, SBName FROM Ledger 
	WHERE SBName = 'Workshop'
	And id = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INVOICE_LIST_FOR_REMARKS]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INVOICE_LIST_FOR_REMARKS]
** Name  :   dbo.USP_INVOICE_LIST_FOR_REMARKS
** Desc  :   
** Author:   Bipul
** Date  :   April 02, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INVOICE_LIST_FOR_REMARKS]
(
		@CompanyID As int = 3632
		, @FullPayment As tinyint = 0
)
AS
BEGIN
	IF @FullPayment = 1		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And FullPayment = 1 And cid = @CompanyID			ORDER BY invsendDt DESC		END	ELSE IF @FullPayment = 2		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And FullPayment = 0 And cid = @CompanyID			ORDER BY invsendDt DESC		END	ELSE IF @FullPayment = 3		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And cid = @CompanyID			ORDER BY invsendDt DESC		END
	ELSE		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And cid = -1			ORDER BY invsendDt DESC		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_UPDATE_ONLINE_COMPANY]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_UPDATE_ONLINE_COMPANY]
** Name  :   dbo.USP_INSERT_UPDATE_ONLINE_COMPANY
** Desc  :   
** Author:   Bipul
** Date  :   April 30, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_UPDATE_ONLINE_COMPANY]
(
	@Action As varchar(10) = ''
	, @CP_ID As int = -1
	, @CompanyName As varchar(100) = ''
	, @Address As varchar(250) = ''
	, @City As varchar(50) = ''
	, @Phone As varchar(100) = ''
	, @Email As varchar(100) = ''
	, @Contact_Person As varchar(100) = ''
	, @Designation As varchar(50) = ''
	, @CompanyID int = -1
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @DuplicateCount As tinyint = 0
	DECLARE @C_ID As int = 0

	SELECT @DuplicateCount = COUNT(1) FROM Company WHERE name = @CompanyName

	--PRINT @DuplicateCount
	IF @Action = 'INSERT'
		BEGIN
			IF @DuplicateCount = 0
				BEGIN
					-- Insert Company Information
					INSERT INTO Company (name, address, city, phone, email, contact_person, designation, cp_id)
					VALUES (@CompanyName, @Address, @City, @Phone, @Email, @Contact_Person, @Designation, @CP_ID)
					
					-- Get CompanyID
					SELECT @C_ID = id from Company WHERE Name = @CompanyName And CP_ID = @CP_ID
					
					-- Insert Contact Person
					INSERT INTO ContactPersons(cid, name, designation, ptype)
					VALUES(@C_ID, @CompanyName, @Designation, 'Contact person')
					
					-- Update Temporary Job Table
					UPDATE tmpJobs 
						SET acc_id = @C_ID 
					WHERE cp_id = @CP_ID
				END
		END
	ELSE
		BEGIN
			-- Update Company Information
			UPDATE Company 
				SET cp_id = @CP_ID
			WHERE id = @CompanyID
	        
			-- Update Temporary Job Table
			UPDATE tmpJobs 
				SET acc_id = @CompanyID
			WHERE cp_id = @CP_ID
		END
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_UPDATE_DELETE_REMARKS]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_UPDATE_DELETE_REMARKS]
** Name  :   dbo.USP_INSERT_UPDATE_DELETE_REMARKS
** Desc  :   
** Author:   Bipul
** Date  :   April 09, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_UPDATE_DELETE_REMARKS]
(
	@Action As char(1) = ''
	, @RemarksID As int = 0
	, @RemarkDate As varchar(10) = ''
	, @Remarks As varchar(2000) = ''
	, @IncoiceID As int = 0
	, @UserID As int = ''
)
AS
BEGIN
	IF @Action = 'I'
		BEGIN
			INSERT INTO InvoiceRemarks(InvoiceId,RemarkDate, Remarks, UserId) 
			VALUES(@IncoiceID, @RemarkDate, @Remarks, @UserID)
		END
	ELSE IF @Action = 'U'
		BEGIN
			UPDATE InvoiceRemarks
				SET RemarkDate = @RemarkDate,
				Remarks = @Remarks
			WHERE Id = @RemarksID
		END
	ELSE IF @Action = 'D'
		DELETE InvoiceRemarks WHERE Id = @RemarksID
	ELSE
		SELECT ID, RemarkDate, Remarks, InvoiceId FROM InvoiceRemarks WHERE InvoiceId = @IncoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_SALE]    Script Date: 08/06/2015 11:22:36 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ASSET_JOURNAL]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ASSET_JOURNAL]
** Name  :   dbo.USP_ASSET_JOURNAL
** Desc  :   
** Author:   Bipul
** Date  :   April 27, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ASSET_JOURNAL]
(
	@UserID As int = -1
	, @NoDep As bit = 0
	, @AssetCode As varchar(15) = ''
	, @AssetNo1 As int = -1
	, @AssetNo2 As int = -1
	, @Price As float = 0
	, @Description As varchar(700) = ''
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @DepStartDt As varchar(10) = ''
		, @LastPosted As varchar(10) = ''
		, @DepDate As varchar(10) = ''
		, @TNO As int = -1
		, @JID As int = -1

	SELECT @TNO = id, @DepStartDt = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, DepStartDt),111), @LastPosted = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, LastPosted),111)
	FROM FixedAsset 
	WHERE assetCode = @AssetCode

	SELECT @JID = MAX(Jid)+1 FROM Journal

	IF @LastPosted IS NULL
		BEGIN
			INSERT INTO Journal(Jid, Sid, Description, Debt, Credit, JDate, TNO, Notify, PostDate, UserID)
			VALUES(@JID, @AssetNo1, @Description, @Price, 0, @DepStartDt, @TNO, 'FixedAsset', GETDATE(), @UserID)
			
			INSERT INTO Journal(Jid, Sid, Debt, Credit, JDate, TNO, Notify, PostDate, UserID)
			VALUES(@JID, @AssetNo2, 0, @Price, @DepStartDt, @TNO, 'FixedAsset', GETDATE(), @UserID)
			
			EXEC USP_MakeJournalVoucher @JID, @DepStartDt
			
			IF @NoDep = 1
				BEGIN
					SET @DepDate = MONTH(@DepStartDt) + '/28/' + YEAR(@DepStartDt)
					UPDATE FixedAsset 
						SET LastPosted = @DepDate
					WHERE AssetCode = @AssetCode
				END
		END
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UNPAID_CASH_COLLECTION]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UNPAID_CASH_COLLECTION]
** Name  :   dbo.USP_UNPAID_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 18, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UNPAID_CASH_COLLECTION]
(
	@UserID As int
	, @LedgerID	As int
	, @TNO As int
	, @InvoiceId As int
	, @InvoiceNo As varchar(20)
	, @CollectionId As int
	, @Amount As float
	, @CompanyName As varchar(100)
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @DbtDesc As varchar(100) = 'Reverse entry'
	DECLARE @CrDesc As varchar(200) = 'Company - ' + @CompanyName + ', InvoiceNo - ' + @InvoiceNo
	DECLARE @JID As int = -1
	DECLARE @ARID As int = 35
	DECLARE @CurrentDate As varchar(10) = CONVERT(varchar(10), GETDATE(), 101)
	SELECT @JID = MAX(JID)+1 FROM Journal
	
	BEGIN TRY
		BEGIN TRANSACTION
			--Account Receivables Debt
			INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) 
			VALUES(@JID, @ARID, @DbtDesc, @Amount, 0, @CurrentDate, @TNO, 'AR', @CurrentDate, @UserID)
			--Bank/Cash Credit
			INSERT INTO Journal(jid,sid,description,debt,credit,Jdate,tno,Notify,PostDate,UserID)
			VALUES(@JID,@LedgerID, @CrDesc,0, @Amount, @CurrentDate, @TNO, 'Sales', @CurrentDate, @UserID)

			EXEC USP_MakeJournalVoucher @JID, @CurrentDate

			--Update 'InvoiceList' Table to set FullPayment=0
			UPDATE InvoiceList SET FullPayment=0 WHERE id=@InvoiceId
			--Update 'Sales' table to make due
			UPDATE Sales SET CashReceived=CashReceived-@Amount,AccReceivable=AccReceivable+@Amount WHERE tno=@TNO
			--Delete record from 'Cash_Collection' Table
			DELETE Cash_Collection WHERE id=@CollectionId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_CASH_COLLECTION]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_UPDATE_CASH_COLLECTION]
** Name  :   dbo.USP_UPDATE_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 17, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_UPDATE_CASH_COLLECTION]
(
	@Type As tinyint = -1
	, @UserID As int = -1
	, @CCollectionID As int = -1
	, @Invoice_No As varchar(20) = ''
	, @Cash As float = 0
	, @ReceivedDate As varchar(10) = ''
	, @TNO As int = -1
	, @InvoiceSchedulerID As int = -1
	, @LedgerId As int = -1
	, @ChequeDetails As varchar(30) = ''
	, @CompanyName As varchar(100) = ''
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @STRPaymentType As varchar(20)
	DECLARE @STRDescription As varchar(50)
	DECLARE @Description As varchar(100)
	DECLARE @Amount As float
	DECLARE @Tax As float
	DECLARE @Payment As float
	DECLARE @AR As float
	DECLARE @AmtDiff As float
	DECLARE @LedgerName As varchar(50)
	DECLARE @TCCollect As float
	DECLARE @TIAmount As float
	DECLARE @AmountChanged As bit = 0
	DECLARE @TaxChanged As bit = 0
	DECLARE @PreviousCollection As float
	DECLARE @AccReceivable As float
	DECLARE @BadDebt As bit = 0
	
	SELECT @PreviousCollection = Cash FROM Cash_Collection WHERE ID = @CCollectionID
	
	BEGIN TRY
		BEGIN TRANSACTION
			IF @Type <> 3
				BEGIN
					IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
						BEGIN
							IF @Type = 2
								BEGIN
									SELECT @LedgerName = SBName FROM Ledger WHERE ID = @LedgerId
									SET @STRPaymentType = @LedgerName
									SET @STRDescription = @LedgerName + ' to ' + @CompanyName
								END
							ELSE IF @Type = 7
								BEGIN
									SET @STRPaymentType = 'Discount'
									SET @STRDescription = 'Discount to ' + @CompanyName
								END
							ELSE
								BEGIN
									SET @STRPaymentType = 'OnlineCharges'
									SET @STRDescription = 'Online collection charges to ' + @CompanyName
								END
						END
					ELSE
						BEGIN
							IF @Type = 0
								BEGIN
									SET @STRPaymentType = 'Cash'
									SET @STRDescription = 'Cash ' --+ @CompanyName
								END
							ELSE IF @Type = 1
								BEGIN
									SET @STRPaymentType = 'Bank'
									SET @STRDescription = 'Cheque  ' --+ @CompanyName
								END
							ELSE IF @Type = 4
								BEGIN
									SET @STRPaymentType = 'Brac'
									SET @STRDescription = 'Online payment (by Brac) ' --+ @CompanyName
								END
							ELSE IF @Type = 5
								BEGIN
									SET @STRPaymentType = 'SSL'
									SET @STRDescription = 'Online payment (by SSL) ' --+ @CompanyName
								END
							ELSE IF @Type = 6
								BEGIN
									SET @STRPaymentType = 'bKash'
									SET @STRDescription = 'Online payment (by bKash) ' --+ @CompanyName
								END
						END
				END
			ELSE
				BEGIN
					SET @STRDescription = 'Bad Debts to ' + @CompanyName
					SET @BadDebt = 1
				END
			
			IF (@Type = 0) OR (@Type = 1) OR (@Type = 3) OR (@Type = 4) OR (@Type = 5) OR (@Type = 6)
				BEGIN
					IF @Cash <> @PreviousCollection
						SET @AmountChanged = 1
				END
			ELSE IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
				BEGIN
					IF @Cash <> @PreviousCollection
						SET @TaxChanged = 1
				END
				
			IF (@AmountChanged = 1) OR (@TaxChanged = 1)
				BEGIN
					IF @AmountChanged = 1
						BEGIN
							SET @Amount = @Cash - @PreviousCollection
							SET @Tax = 0
						END
					ELSE
						BEGIN
							SET @Amount = 0
							SET @Tax = @Cash - @PreviousCollection
						END			
					
					SET @AR = @Amount + @Tax
					
					SELECT @AccReceivable = AccReceivable FROM Sales WHERE TNO= @TNO
					
					IF @AR <= @AccReceivable
						BEGIN
							UPDATE Sales
								SET CashReceived = CashReceived + @Amount
								, Tax = Tax + @Tax
								, AccReceivable = AccReceivable - @AR
							WHERE TNO = @TNO
						END
					IF @Type = 1
						BEGIN
							UPDATE Cash_Collection
								SET Cash = @Cash
								, ChequeDetails = @ChequeDetails
								, SalesTax = @Tax
								, ReceivedDate = @ReceivedDate
								, BankId = @LedgerId
								, BadDebt = @BadDebt
								, PaymentType = @STRPaymentType
							WHERE ID = @CCollectionID
						END
					ELSE
						BEGIN
							UPDATE Cash_Collection
								SET Cash = @Cash
								, ChequeDetails = @ChequeDetails
								, SalesTax = @Tax
								, ReceivedDate = ReceivedDate
								, BankId = 0
								, BadDebt = @BadDebt
								, PaymentType = @STRPaymentType
							WHERE ID = @CCollectionID
						END
		/*=========================================================================================*/
		/*==============================Update InvoiceList when FullPayment==========================*/
					SELECT @TCCollect = (SUM(Cash) + SUM(salesTax)) FROM Cash_Collection WHERE invoice_no= @Invoice_No
					SELECT @TIAmount = TAmount FROM InvoiceList WHERE invoice_no= @Invoice_No

					IF @TCCollect >= @TIAmount
						BEGIN
							UPDATE InvoiceList 
								SET fullPayment=1 
							WHERE invoice_no= @Invoice_No
						END
					ELSE 
						BEGIN
							UPDATE InvoiceList 
								SET fullPayment=0
							WHERE invoice_no= @Invoice_No
						END
				END	
			ELSE
				IF @Type = 1
					BEGIN
						UPDATE Cash_Collection
							SET ChequeDetails = @ChequeDetails
							, SalesTax = @Tax
							, ReceivedDate = ReceivedDate
							, BankId = @LedgerId
							, BadDebt = @BadDebt
							, PaymentType = @STRPaymentType
						WHERE ID = @CCollectionID
					END
				ELSE
					BEGIN
						UPDATE Cash_Collection
							SET ChequeDetails = @ChequeDetails
							, SalesTax = @Tax
							, ReceivedDate = ReceivedDate
							, BankId = 0
							, BadDebt = @BadDebt
							, PaymentType = @STRPaymentType
						WHERE ID = @CCollectionID
					END
			
/*=========================================================================================*/
		IF (@AmountChanged = 1) OR (@TaxChanged = 1)
			BEGIN
				DECLARE @SalesPrice As float
					, @CashReceived As float
					--, @AccReceivable As float
					, @SDate As varchar(10)
					, @Duration As tinyint
				
				SELECT @SalesPrice=(salesPrice+Tax),@CashReceived=CashReceived,@AccReceivable=AccReceivable,@SDate=CONVERT(varchar(10), sdate, 101),@Duration=duration 
				FROM Sales 
				WHERE tno = @TNO
				
				SET @Amount = ABS(@Cash - @PreviousCollection)
				SET @Description = @STRDescription + '; Invoice No - ' + @Invoice_No

				IF @Type = 0
					-- Cash
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 1
					-- Bank
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales', @ChequeDetails
				ELSE IF @Type = 2
					-- Tax
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
				ELSE IF @Type = 3
					-- Bad Debt
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 4
					-- Brac Bank Merchant A/C
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 5
					-- SSL Merchant A/C
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 6
					-- bKash Merchant A/C
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
				ELSE IF @Type = 7
					-- Discount
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
				ELSE
					-- Online Charge
					EXEC USP_CASH_COLLECTION @Amount, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'

				-- Update Cash Collection
				UPDATE Cash_Collection SET Posted=1 WHERE id = (SELECT MAX(ID) FROM Cash_Collection)
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_DISPOSAL_ASSET]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_DISPOSAL_ASSET]
** Name  :   dbo.USP_INSERT_DISPOSAL_ASSET
** Desc  :   
** Author:   Bipul
** Date  :   April 30, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_DISPOSAL_ASSET]
(
	@UserID As int = -1
	, @AssetNoID As int = -1
	, @DisposalDate As varchar(10) = ''
	, @ResaleAmount As float = 0
	, @Sold As bit = 0
	, @Description As varchar(700) = ''
	, @SoldById As int = -1
)
AS
BEGIN
	
	DECLARE @AssetPrice As float
		, @Profit As float
		, @AccDep As float
		, @BookValue As float
		, @AssetId As int
		, @DepRate As float
		, @DepStartDt As varchar(10)
		, @AssetCode As varchar(15)
		, @JID As int = -1

	DECLARE @AccDepID As int = 100
	DECLARE @CapGainId As int = 401
	DECLARE @CapLossId As int = 402
	
	SET NOCOUNT ON
	
	PRINT @DepStartDt
	
	SELECT @AssetId = AssetNo, @AssetPrice = Price, @DepRate = DepRate, @DepStartDt = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, DepStartDt),111), @AssetCode = AssetCode 
	FROM FixedAsset 
	WHERE Id = @AssetNoID
	
	IF @DepRate = 0
		BEGIN
			SET @BookValue = @AssetPrice
			SET @AccDep = 0
		END
	ELSE
		BEGIN
			SET @AccDep = @DepRate * DATEDIFF(MONTH, @DepStartDt, @DisposalDate)
			SET @BookValue = @AssetPrice - @AccDep
		END

	SET @Profit = @ResaleAmount - @BookValue
	--PRINT @DepStartDt
	UPDATE FixedAsset 
		SET StopDep = 1
		, SoldAmount = @ResaleAmount
		, DisposalDate = @DisposalDate
		, Profit = @Profit
		, Sold = @Sold
		, Remarks = @Description
	WHERE Id = @AssetNoId

	IF @AccDep > 0
		EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @AccDepID, @AssetID, @AccDep, @AssetNoID, @DisposalDate, @Description

	IF @Sold = 0
		BEGIN
			IF @Profit > 0
				BEGIN
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @CapGainId, @Profit, @AssetNoId, @DisposalDate, @Description
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
				END
			ELSE IF @Profit < 0
				BEGIN
					SET @Profit = ABS(@Profit)
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @CapLossId, @AssetId, @Profit, @AssetNoId, @DisposalDate, @Description
					
					SET @BookValue = @BookValue - ABS(@Profit)
					EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
				END
			ELSE
				EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @SoldById, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
		END
	ELSE
		EXEC USP_ASSET_DISPOSAL_JOURNAL @UserID, @CapLossId, @AssetId, @BookValue, @AssetNoId, @DisposalDate, @Description
	
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_CASH_COLLECTION]    Script Date: 08/06/2015 11:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_CASH_COLLECTION]
** Name  :   dbo.USP_INSERT_CASH_COLLECTION
** Desc  :   
** Author:   Bipul
** Date  :   May 14, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_CASH_COLLECTION]
(
	@Type As tinyint
	, @UserID As int
	, @Invoice_No As varchar(20)
	, @Cash As float
	, @ReceivedDate As varchar(10)
	, @TNO As int
	, @InvoiceSchedulerID As int
	, @LedgerId As int
	, @ChequeDetails As varchar(30)
	, @CompanyName As varchar(100)
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @STRPaymentType As varchar(20)
	DECLARE @STRDescription As varchar(50)
	DECLARE @Description As varchar(100)
	DECLARE @Tax As float
	DECLARE @Payment As float
	DECLARE @AR As float
	DECLARE @AmtDiff As float
	DECLARE @LedgerName As varchar(50)
	DECLARE @TCCollect As float
	DECLARE @TIAmount As float
	
	BEGIN TRY
		BEGIN TRANSACTION
			IF @Type <> 3
				BEGIN
					IF (@Type = 2) OR (@Type = 7) OR (@Type = 8)
						BEGIN
							SET @Tax = @Cash
							SET @Payment = 0
							IF @Type = 2
								BEGIN
									SELECT @LedgerName = SBName FROM Ledger WHERE ID = @LedgerId
									SET @STRPaymentType = @LedgerName
									SET @STRDescription = @LedgerName + ' to ' + @CompanyName
								END
							ELSE IF @Type = 7
								BEGIN
									SET @STRPaymentType = 'Discount'
									SET @STRDescription = 'Discount to ' + @CompanyName
								END
							ELSE
								BEGIN
									SET @STRPaymentType = 'OnlineCharges'
									SET @STRDescription = 'Online collection charges to ' + @CompanyName
								END
						END
					ELSE
						BEGIN
							SET @Tax = 0
							SET @Payment = @Cash
							IF @Type = 0
								BEGIN
									SET @STRPaymentType = 'Cash'
									SET @STRDescription = 'Cash ' --+ @CompanyName
								END
							ELSE IF @Type = 1
								BEGIN
									SET @STRPaymentType = 'Bank'
									SET @STRDescription = 'Cheque  ' --+ @CompanyName
								END
							ELSE IF @Type = 4
								BEGIN
									SET @STRPaymentType = 'Brac'
									SET @STRDescription = 'Online payment (by Brac) ' --+ @CompanyName
								END
							ELSE IF @Type = 5
								BEGIN
									SET @STRPaymentType = 'SSL'
									SET @STRDescription = 'Online payment (by SSL) ' --+ @CompanyName
								END
							ELSE IF @Type = 6
								BEGIN
									SET @STRPaymentType = 'bKash'
									SET @STRDescription = 'Online payment (by bKash) ' --+ @CompanyName
								END
						END
					SET @AR = @Payment + @Tax
					IF @Type = 1
						BEGIN
							INSERT INTO Cash_Collection(Invoice_No,Cash,ReceivedDate,tno,salesTax,PaymentType,InvoiceSchedulerID,chequedetails,BankId) 
							VALUES(@Invoice_No, @Payment, @ReceivedDate, @TNO, @Tax, @STRPaymentType, @InvoiceSchedulerID, @ChequeDetails, @LedgerId)
						END
					ELSE
						BEGIN
							INSERT INTO Cash_Collection(Invoice_No,Cash,ReceivedDate,tno,salesTax,PaymentType,InvoiceSchedulerID) 
							VALUES(@Invoice_No, @Payment, @ReceivedDate, @TNO, @Tax, @STRPaymentType, @InvoiceSchedulerID)
						END
				END
			ELSE
				BEGIN
					SET @STRDescription = 'Bad Debts to ' + @CompanyName
					SET @Tax = 0
					SET @Payment = @Cash
					SET @AR = @Payment + @Tax
					INSERT INTO Cash_Collection(Invoice_No,Cash,ReceivedDate,tno,BadDebt,InvoiceSchedulerID) 
					VALUES(@Invoice_No, @Payment, @ReceivedDate, @TNO, 1, @InvoiceSchedulerID)
				END
		/*==============================Update Sale==========================*/
			SELECT @AmtDiff = @AR-AccReceivable FROM Sales WHERE TNO = @TNO

			IF @AmtDiff <= 1
				BEGIN
					UPDATE Sales
						SET CashReceived = CashReceived + @Payment
						, AccReceivable = AccReceivable - @AR
					WHERE TNO = @TNO
				END
			ELSE
				BEGIN
					SET @AR = @AmtDiff
					UPDATE Sales
						SET CashReceived = SalesPrice - @Tax
						, AccReceivable = 0
					WHERE TNO = @TNO
				END
		/*=========================================================================================*/
		/*==============================Update InvoiceList when FullPayment==========================*/
			SELECT @TCCollect = (SUM(Cash) + SUM(salesTax)) FROM Cash_Collection WHERE invoice_no= @Invoice_No
			SELECT @TIAmount = TAmount FROM InvoiceList WHERE invoice_no= @Invoice_No

			IF @TCCollect = @TIAmount
				BEGIN
					UPDATE InvoiceList 
						SET fullPayment=1 
					WHERE invoice_no= @Invoice_No
				END
		/*=========================================================================================*/

			DECLARE @SalesPrice As float
				, @CashReceived As float
				, @AccReceivable As float
				, @SDate As varchar(10)
				, @Duration As tinyint

			SELECT @SalesPrice=(salesPrice+Tax),@CashReceived=CashReceived,@AccReceivable=AccReceivable,@SDate=CONVERT(varchar(10), sdate, 101),@Duration=duration 
			FROM Sales 
			WHERE tno = @TNO

			SET @Description = @STRDescription + '; Invoice No - ' + @Invoice_No

			IF @Type = 0
				-- Cash
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 1
				-- Bank
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales', @ChequeDetails
			ELSE IF @Type = 2
				-- Tax
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
			ELSE IF @Type = 3
				-- Bad Debt
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 4
				-- Brac Bank Merchant A/C
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 5
				-- SSL Merchant A/C
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 6
				-- bKash Merchant A/C
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Sales'
			ELSE IF @Type = 7
				-- Discount
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'
			ELSE
				-- Online Charge
				EXEC USP_CASH_COLLECTION @Cash, @ReceivedDate, @SDate, @SalesPrice, @CashReceived, @Duration, @TNO, @LedgerId, @UserID, @Description, 'Tax'

			-- Update Cash Collection
			UPDATE Cash_Collection SET Posted=1 WHERE id = (SELECT MAX(ID) FROM Cash_Collection)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
	END CATCH
	
	SET NOCOUNT OFF
END
GO
