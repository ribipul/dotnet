USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_JOURNAL_VOUCHER]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_GET_JOURNAL_VOUCHER]
** Name  :   dbo.USP_GET_JOURNAL_VOUCHER
** Desc  :   
** Author:   Bipul
** Date  :   April 22, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_GET_JOURNAL_VOUCHER]
(
	@Year As int = 2000
	, @MonthNo As tinyint = 12
)
AS 
BEGIN
	SET NOCOUNT ON
	
	;WITH JVoucher_CTE As (
		SELECT distinct v.JID, v.VoucherNo 
		FROM JournalVoucher v INNER JOIN Journal j ON j.jid=v.jid 
		WHERE year(j.jdate) = @Year and month(j.jdate) = @MonthNo
	)
	SELECT JID, (FORMAT(ROW_NUMBER() over (ORDER BY jid),'0000.') + '. ' + VoucherNo) As VoucherNo FROM JVoucher_CTE
	ORDER BY VoucherNo
	
	SET NOCOUNT OFF
END
GO
