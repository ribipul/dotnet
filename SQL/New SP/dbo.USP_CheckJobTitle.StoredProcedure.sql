USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckJobTitle]    Script Date: 08/04/2015 14:54:13 ******/
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
