USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_ONLINE_JOB_LIST]    Script Date: 08/06/2015 11:23:06 ******/
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
