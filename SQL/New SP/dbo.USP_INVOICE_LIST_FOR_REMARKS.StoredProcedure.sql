USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INVOICE_LIST_FOR_REMARKS]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INVOICE_LIST_FOR_REMARKS]
** Name  :   dbo.USP_INVOICE_LIST_FOR_REMARKS
** Desc  :   
** Author:   Bipul
** Date  :   April 02, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INVOICE_LIST_FOR_REMARKS]
(
		@CompanyID As int = 3632
		, @FullPayment As tinyint = 0
)
AS
BEGIN
	IF @FullPayment = 1		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And FullPayment = 1 And cid = @CompanyID			ORDER BY invsendDt DESC		END	ELSE IF @FullPayment = 2		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And FullPayment = 0 And cid = @CompanyID			ORDER BY invsendDt DESC		END	ELSE IF @FullPayment = 3		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And cid = @CompanyID			ORDER BY invsendDt DESC		END
	ELSE		BEGIN			SELECT id,Invoice_No,TAmount 			FROM invoiceList			WHERE invalid = 0 And cid = -1			ORDER BY invsendDt DESC		END
END
GO
