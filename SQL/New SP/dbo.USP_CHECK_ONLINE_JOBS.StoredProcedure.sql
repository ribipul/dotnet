USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_CHECK_ONLINE_JOBS]    Script Date: 08/04/2015 14:54:13 ******/
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
