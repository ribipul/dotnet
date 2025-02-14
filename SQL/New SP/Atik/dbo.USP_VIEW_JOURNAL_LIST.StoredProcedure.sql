USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_VIEW_JOURNAL_LIST]    Script Date: 08/06/2015 11:23:06 ******/
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
