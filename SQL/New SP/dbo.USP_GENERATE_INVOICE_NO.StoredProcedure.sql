USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_GENERATE_INVOICE_NO]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:				Bipul
-- Create date: 		June 05, 2014
-- Description:			Generate Invoice Number
-- =============================================
CREATE PROCEDURE [dbo].[USP_GENERATE_INVOICE_NO]
(
		@CID int,
		@IssueDate varchar(12)
)
AS
BEGIN
	DECLARE @Part3 As nvarchar(10) = ''
	DECLARE @Part4 As nvarchar(10) = ''
	DECLARE @Length1 INT = 3
	DECLARE @Length2 INT = 5
	DECLARE @CompanyID varchar(5) = ''


	DECLARE @Month varchar(2) = ''
	DECLARE @Year varchar(2) = ''

	SET @IssueDate =  CONVERT(VARCHAR(10),@IssueDate,110)	--'06/04/2014'

	select @Part3 = CASE WHEN (max(case when Substring(invoice_no,11,1)='-' then Substring(invoice_no,12,3) else Substring(invoice_no,11,3) end)) IS NULL THEN '000' ELSE (max(case when Substring(invoice_no,11,1)='-' then Substring(invoice_no,12,3) else Substring(invoice_no,11,3) end)) END
	from InvoiceList where cid=@CID 
	IF @Part3 = '000'
		SET @Part3 = '001'
	ELSE
		SET @Part3 = CAST(@Part3 As int) + 1

	select @Part4 = CASE WHEN (max(case when Substring(invoice_no,15,1)='-' then Substring(invoice_no,16,5) else Substring(invoice_no,15,5) end)) IS NULL THEN '00000' ELSE (max(case when Substring(invoice_no,15,1)='-' then Substring(invoice_no,16,5) else Substring(invoice_no,15,5) end)) END
	from InvoiceList
	IF @Part4 = '00000'
		SET @Part4 = '00001'
	ELSE
		SET @Part4 = CAST(@Part4 As int) + 1

	SET @Month = (SELECT RIGHT(Replicate('0', 2) + CAST(MONTH(@IssueDate) AS varchar(2)), 2))
	SET @Year = (SELECT RIGHT(Replicate('0', 2) + CAST(YEAR(@IssueDate) AS varchar(4)), 2))

	SET @Part3 = (SELECT RIGHT(Replicate('0', @Length1) + @Part3, @Length1))
	SET @Part4 = (SELECT RIGHT(Replicate('0', @Length2) + @Part4, @Length2))
	SET @CompanyID = (SELECT RIGHT(Replicate('0', 5) + CAST(@CID As varchar(5)), 5))
	--PRINT @Part3
	--PRINT @Part4
	
	--PRINT @Month
	SELECT (@Year+@Month+'-'+@CompanyID+'-'+@Part3+'-'+@Part4) As InvoiceNo
END
GO
