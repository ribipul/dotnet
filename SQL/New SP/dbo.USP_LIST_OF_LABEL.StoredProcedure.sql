USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_LIST_OF_LABEL]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LIST_OF_LABEL]
** Name  :   dbo.USP_LIST_OF_LABEL
** Desc  :   
** Author:   Bipul
** Date  :   April 07, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LIST_OF_LABEL]
(
	@PageNo int = 1
	, @PageSize int = 10
	, @LabelType As bit = 0
	, @ProductID As int = 44
	, @FromDate As varchar(10) = ''
	, @ToDate As varchar(10) = ''
)
AS 
BEGIN
	DECLARE @StartingIndex int = 1
		
	IF @PageNo > 0
		SET @StartingIndex = (@PageNo -1) * @PageSize

	IF @LabelType = 0
		BEGIN
			IF @ProductID = 0
				BEGIN
					----PRINT @FromDate
					--SELECT id,Invoice_No As ItemName, COUNT(id) OVER() As NoOfRow
					--FROM InvoiceList 
					----WHERE id=1 
					--ORDER BY substring(Invoice_No,15,5) DESC offset @StartingIndex  rows fetch  next @PageSize rows only
					;WITH Invoice_CTE AS(
						SELECT DISTINCT i.id,i.Invoice_No as ItemName
						FROM InvoiceList i
							INNER JOIN InvoiceSceduler i1 ON i.id=i1.Invoice_id
							INNER JOIN Sales s ON i1.TNO=s.TNO 
					)
					SELECT id, ItemName, COUNT(id) OVER() As NoOfRow
					FROM Invoice_CTE
					ORDER BY substring(ItemName,15,5) DESC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
			ELSE
				BEGIN
					;WITH Invoice_CTE AS(
						SELECT DISTINCT i.id,i.Invoice_No as ItemName
						FROM InvoiceList i
							INNER JOIN InvoiceSceduler i1 ON i.id=i1.Invoice_id
							INNER JOIN Sales s ON i1.TNO=s.TNO 
						WHERE s.PCode = @ProductId and i.InvSendDt BETWEEN @FromDate And @ToDate
					)
					SELECT id, ItemName, COUNT(id) OVER() As NoOfRow
					FROM Invoice_CTE
					ORDER BY Id DESC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
		END
	ELSE
		BEGIN
			IF @ProductID = 0
				BEGIN
					SELECT id,Name as ItemName, COUNT(id) OVER() As NoOfRow
					FROM Company 
					ORDER BY Name ASC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
			ELSE
				BEGIN
					;WITH Company_CTE AS (
						SELECT DISTINCT c.id,c.Name as ItemName
						FROM Company c
							INNER JOIN Sales s ON c.id=s.cid
							INNER JOIN InvoiceSceduler i1 ON i1.TNO=s.TNO 
							INNER JOIN InvoiceList i ON i.id=i1.Invoice_id
						WHERE s.PCode = @ProductId and i.InvSendDt BETWEEN @FromDate And @ToDate
					)
					SELECT id, ItemName, COUNT(id) OVER() As NoOfRow
					FROM Company_CTE
					ORDER BY ItemName ASC offset @StartingIndex  rows fetch  next @PageSize rows only
				END
		END
END
GO
