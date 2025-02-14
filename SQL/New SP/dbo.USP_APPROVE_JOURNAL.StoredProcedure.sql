USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_APPROVE_JOURNAL]    Script Date: 08/04/2015 14:54:13 ******/
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
