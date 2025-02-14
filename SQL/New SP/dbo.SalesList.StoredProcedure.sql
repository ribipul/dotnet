USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[SalesList]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesList]
(
	@Search As varchar(50) = NULL
)
AS
	BEGIN
		IF @Search IS NULL
			BEGIN
				SELECT s.TNO, c.Name As CompanyName, cp.Name As BillingContactPerson, l.SBName As ProductName, 
				s.SDate As StartDate, s.EDate As EndDate, s.SalesPrice, s.Tax As VAT, s.Posted
				FROM (((Sales s LEFT JOIN Company c ON s.CId = c.Id)
					LEFT JOIN Ledger l ON s.PCode = l.Id)
					LEFT JOIN ContactPersons cp ON s.BillContactId = cp.Id)
				ORDER BY TNO DESC
			END
		ELSE
			BEGIN
				SELECT s.TNO, c.Name As CompanyName, cp.Name As BillingContactPerson, l.SBName As ProductName, 
				s.SDate As StartDate, s.EDate As EndDate, s.SalesPrice, s.Tax As VAT, s.Posted
				FROM (((Sales s LEFT JOIN Company c ON s.CId = c.Id)
					LEFT JOIN Ledger l ON s.PCode = l.Id)
					LEFT JOIN ContactPersons cp ON s.BillContactId = cp.Id)
				WHERE c.Name LIKE '%' + @Search + '%'
				OR cp.Name LIKE '%' + @Search + '%'
				OR l.SBName LIKE '%' + @Search + '%'
				ORDER BY TNO DESC
			END
	END
GO
