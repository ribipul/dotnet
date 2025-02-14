USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_ONLINE_SALE_INFO]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_ONLINE_SALE_INFO]
** Name  :   dbo.USP_ONLINE_SALE_INFO
** Desc  :   
** Author:   Bipul
** Date  :   April 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_ONLINE_SALE_INFO]
(
	@Type As char(1) = 'T'
	, @CompanyID As int = 11092
	--, @PostingDate As varchar(10) = ''
)
AS 
BEGIN
	SET NOCOUNT ON
	
	IF @Type = 'C'
		BEGIN
			--Fill Billing Person
			SELECT id, name, Designation 
			FROM contactPersons 
			WHERE cid=@CompanyID
		END
	ELSE
		BEGIN
			--Fill Job Title
			SELECT jp_id, title, postingDate, ValidDate, BillingContact, designation--, Acc_Id 
			FROM tmpjobs 
			WHERE tno=0 And Acc_id=@CompanyID --And PostingDate = @PostingDate
			ORDER BY title
		END
	
	SET NOCOUNT OFF
END
GO
