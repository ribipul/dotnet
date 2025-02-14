USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_LABEL_RPT]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LIST_OF_LABEL_RPT]
** Name  :   dbo.USP_LIST_OF_LABEL_RPT
** Desc  :   
** Author:   Bipul
** Date  :   April 07, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LIST_OF_LABEL_RPT]
(
	@LabelType As bit = 0
	, @listIds As varchar(1000) = '90,98,158,89,151,195,166,117,178,179'
)
AS 
BEGIN
	DECLARE @STRQuery As varchar(1500) = ''

	IF @LabelType = 0
		BEGIN
			SET @STRQuery = @STRQuery + ';WITH Label_CTE AS (' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT DISTINCT p.name as pname,p.designation,c.name as cname,c.address,c.city ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'FROM ContactPersons p,company c,InvoiceSceduler i,sales s ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'WHERE i.invoice_id IN (' + @listIds + ') and i.tno=s.tno and s.BillContactID=p.id and p.cid=c.id' + CHAR(13)
			--SET @STRQuery = @STRQuery + 'ORDER BY c.name' + CHAR(13)
			SET @STRQuery = @STRQuery + ')' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT ROW_NUMBER() OVER (ORDER BY pname) AS Id,pname,designation,cname,address,city ' + CHAR(13)			SET @STRQuery = @STRQuery + 'FROM Label_CTE	' + CHAR(13)
		END
	ELSE
		BEGIN
			SET @STRQuery = @STRQuery + ';WITH Label_CTE AS (' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT DISTINCT Contact_Person as pname,designation,name as cname,address,city ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'FROM Company Where Id IN (' + @listIds + ')' + CHAR(13)
			--SET @STRQuery = @STRQuery + 'ORDER BY c.name' + CHAR(13)
			SET @STRQuery = @STRQuery + ')' + CHAR(13)
			SET @STRQuery = @STRQuery + 'SELECT ROW_NUMBER() OVER (ORDER BY pname) AS Id,pname,designation,cname,address,city ' + CHAR(13)			SET @STRQuery = @STRQuery + 'FROM Label_CTE	' + CHAR(13)
		END
	
	--PRINT @STRQuery
	EXEC(@STRQuery)
END
GO
