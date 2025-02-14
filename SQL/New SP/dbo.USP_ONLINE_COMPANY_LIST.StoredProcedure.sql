USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_ONLINE_COMPANY_LIST]    Script Date: 08/04/2015 14:54:13 ******/
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
