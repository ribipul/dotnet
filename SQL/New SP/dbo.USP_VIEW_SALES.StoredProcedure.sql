USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_VIEW_SALES]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_VIEW_SALES]
** Name  :   dbo.USP_VIEW_SALES
** Desc  :   
** Author:   Bipul
** Date  :   May 20, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_VIEW_SALES]
(
	@PageNo int = 1
	, @PageSize int = 10
	, @CID int = 0
	, @TNO int = 0
)
AS
BEGIN
	DECLARE @StartingIndex int = 1

	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize
	
	SET NOCOUNT ON
	
	IF @CID > 0
		BEGIN
			SELECT l.id, l.sbname, s.TNO, s.sdate As [From], CASE WHEN s.edate IS NULL THEN DATEADD(MONTH,1,s.sdate) ELSE s.edate END As [To]
			, s.salesPrice, s.AccReceivable, s.Duration, s.Posted, s.RefNo, s.Tax, s.TaxID, s.BillContactId 
			, SUM(s.salesPrice) OVER()+SUM(s.Tax) OVER() As TotalAmount
			, SUM(s.AccReceivable) OVER() As DuesAmount
			, COUNT(s.TNO) OVER() As TotalRecord
			FROM Sales s
				INNER JOIN Ledger l ON s.pcode=l.id
			WHERE s.cid=@CID
			ORDER BY s.sdate OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY
		END
	ELSE
		BEGIN
			IF @TNO = 0
				BEGIN
					SELECT s.tno,c.name,l.sbname,s.salesprice,s.sdate, COUNT(s.tno) OVER() As TotalRecord
					FROM sales s 
						INNER JOIN Company c ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id
					ORDER BY c.name,s.sdate,l.sbname OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY				END			ELSE
				BEGIN
					SELECT s.tno,c.name,l.sbname,s.salesprice,s.sdate, COUNT(s.tno) OVER() As TotalRecord
					FROM sales s 
						INNER JOIN Company c ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id
					WHERE s.TNO = @TNO
					ORDER BY c.name,s.sdate,l.sbname OFFSET @StartingIndex ROWS FETCH NEXT @PageSize ROWS ONLY				END		END	
	SET NOCOUNT OFF
END
GO
