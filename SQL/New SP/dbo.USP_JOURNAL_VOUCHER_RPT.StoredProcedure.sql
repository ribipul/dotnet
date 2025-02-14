USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_JOURNAL_VOUCHER_RPT]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_JOURNAL_VOUCHER_RPT]
** Name  :   dbo.USP_JOURNAL_VOUCHER_RPT
** Desc  :   
** Author:   Bipul
** Date  :   April 23, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_JOURNAL_VOUCHER_RPT]
(
	@JID As int = 348377
)
AS 
BEGIN
	SET NOCOUNT ON
	
	SELECT l.sbname,j.description,j.debt,j.credit,j.jdate,u1.name as PostedBy,u1.designation as des1,j.PostDate,u2.name as ApprBy,u2.designation as des2,j.ApprovalDate,v.VoucherNo 
	FROM ledger l
		INNER JOIN journal j ON j.Sid = L.Id 
		INNER JOIN users u1 ON j.userid = u1.userid
		INNER JOIN users u2 ON j.Approvedby = u2.userid
		INNER JOIN JournalVoucher v ON j.jid=v.jid
	WHERE j.jid = @JID 
	ORDER BY j.debt desc,l.sbname
	
	SET NOCOUNT OFF
END
GO
