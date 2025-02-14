USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_TRIAL_BALANCE_RPT]    Script Date: 08/06/2015 11:23:06 ******/
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
