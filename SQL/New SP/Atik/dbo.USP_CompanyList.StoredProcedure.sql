USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_CompanyList]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_CompanyList]
** Name  :   dbo.USP_CompanyList
** Desc  :   
** Author:   Bipul
** Date  :   March 25, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_CompanyList]
(
	@All As varchar(3) = ''
)
AS
BEGIN
	IF @All = 'All'
		BEGIN
			;WITH Company_CTE AS (
				SELECT 0 As Serial, 0 As ID, 'All' As Name, 0 As BlackListed
				UNION
				SELECT ROW_NUMBER() OVER(ORDER BY Name) As Serial, id, Name, BlackListed FROM Company
			)
			SELECT ID, Name, BlackListed FROM Company_CTE
			ORDER BY Serial
		END
	ELSE
		SELECT id, Name, BlackListed FROM Company ORDER BY Name
END
GO
