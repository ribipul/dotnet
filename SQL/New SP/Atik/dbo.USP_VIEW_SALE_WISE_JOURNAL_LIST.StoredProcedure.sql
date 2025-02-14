USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_VIEW_SALE_WISE_JOURNAL_LIST]    Script Date: 08/06/2015 11:23:06 ******/
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
