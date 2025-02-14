USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_SHOW_JOURNAL]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_SHOW_JOURNAL]
** Name  :   dbo.USP_SHOW_JOURNAL
** Desc  :   
** Author:   Bipul
** Date  :   July 8, 2014
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_SHOW_JOURNAL]
(
	@Approved bit = 0,
	@DateType char = 'P',
	@FDate varchar(10) = '',
	@TDate varchar(10) = '',
	@Ledger varchar(15) = '',
	@CompanyId int = 0,
	@ApprovedBy int = 0,
	@PostedBy int = 0
)
AS
BEGIN
	DECLARE @DateRange varchar(100) = ''
	DECLARE @AddLedger varchar(200) = ''
	DECLARE @Company varchar(200) = ''
	DECLARE @Notify varchar(100) = ''
	DECLARE @Approved1 varchar(50) = ''
	DECLARE @ApprovedBy1 varchar(50) = ''
	DECLARE @PostedBy1 varchar(50) = ''
	DECLARE @OrderBy varchar(200) = 'ORDER BY j.jdate,j.jid,j.debt desc,j.id'
	DECLARE @STRQuery varchar(2000) = ''
	DECLARE @CheckNumeric varchar(20) = ''
	
	DECLARE @ShowLedger TABLE
	(
		Id int null,
		Sid int null,
		SBName varchar(50) null,
		Description varchar(200) null,
		Debt float null,
		Credit float null,
		JDate smalldatetime null,
		Jid int null,
		UserId int null,
		ApprovedBy int null,
		Notify varchar(10) null,
		Tno int null,
		ApprovalDate smalldatetime null,
		UpdatedDate smalldatetime null,
		UpdatedBy int
	)
	IF @FDate = ''
		SET @FDate = CONVERT(VARCHAR(10),GETDATE(),101)
	IF @TDate = ''
		SET @TDate = CONVERT(VARCHAR(10),GETDATE(),101)
	
	IF @DateType = 'P'
		SET @DateRange = ' And j.PostDate BETWEEN ' + '''' + @FDate + ''' And ' + '''' + @TDate + ''''
	ELSE IF @DateType = 'V'
		SET @DateRange = ' And j.JDate BETWEEN ' + '''' + @FDate + ''' And ' + '''' + @TDate + ''''
	ELSE
		SET @DateRange = ' And j.ApprovalDate BETWEEN ' + '''' + @FDate + ''' And ' + '''' + @TDate + ''''
	
	IF @Ledger <> ''
		BEGIN
			SELECT @CheckNumeric = (SELECT CASE WHEN @Ledger not like '%[^0-9]%' THEN 'Number' ELSE 'Not a Number' END)

			IF @CheckNumeric = 'Number'
				BEGIN
					SET @AddLedger = 'And j.jid IN (' + CHAR(13)
					SET @AddLedger = @AddLedger + '	SELECT j.jid' + CHAR(13)
					SET @AddLedger = @AddLedger + '	FROM journal j,ledger l' + CHAR(13)
					SET @AddLedger = @AddLedger + '	WHERE l.Id = ' + CAST(@Ledger As varchar(5)) + ' And l.id=j.sid)' + CHAR(13)
				END
			ELSE
				BEGIN
					IF @Ledger <> '-1'
						BEGIN
							SET @AddLedger = 'And j.jid IN (' + CHAR(13)
							SET @AddLedger = @AddLedger + '	SELECT j.jid' + CHAR(13)
							SET @AddLedger = @AddLedger + '	FROM journal j,ledger l' + CHAR(13)
							SET @AddLedger = @AddLedger + '	WHERE l.MGroup = ''' + @Ledger + ''' And l.id=j.sid)' + CHAR(13)
						END
				END
		END

	IF @CompanyId > 0
		BEGIN
			SET @Company = 'and j.tno in (select tno from sales where cid = ' + CAST(@CompanyId As varchar(5)) + ')' + CHAR(13)
			SET @Notify = 'and (j.notify=''Sales'' or j.notify=''AR'' or j.notify=''Tax'' or j.notify=''VAT'')' + CHAR(13)
		END

	IF @ApprovedBy > 0
		SET @ApprovedBy1 = 'and j.ApprovedBy = ' + CAST(@ApprovedBy As varchar(5)) + CHAR(32)

	IF @PostedBy > 0
		SET @PostedBy1 = 'and j.UserID = ' + CAST(@PostedBy As varchar(5)) + CHAR(13)

	IF @Approved = 0
		SET @Approved1 = ' and j.ApprovedBy = 0'
	ELSE
		SET @Approved1 = ' and j.ApprovedBy <> 0'
	SET @STRQuery = 'SELECT j.Id,j.Sid,l.SBName,j.Description,j.Debt,j.Credit,j.JDate,j.Jid,j.UserID,j.ApprovedBy,j.Notify,j.Tno,j.ApprovalDate,j.UpdatedDate,j.UpdatedBy' + CHAR(13)
	SET @STRQuery = @STRQuery + 'FROM journal j,Ledger l' + CHAR(13)
	SET @STRQuery = @STRQuery + 'WHERE l.id = j.sid' + @Approved1 + @DateRange + CHAR(13)
	SET @STRQuery = @STRQuery + @AddLedger + @Company + @Notify 
	SET @STRQuery = @STRQuery + @ApprovedBy1 + @PostedBy1
	SET @STRQuery = @STRQuery + @OrderBy

	--PRINT @STRQuery
	
	INSERT INTO @ShowLedger
	EXEC(@STRQuery)
	
	SELECT * FROM @ShowLedger
END

--USP_SHOW_JOURNAL 0,'P','05/01/2014','','',-1,-1,-1
GO
