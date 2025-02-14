USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_PREVIEW_TRIAL_BALANCE]    Script Date: 08/06/2015 11:23:06 ******/
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
