USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_DUES_INVOICE]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_DUES_INVOICE]
** Name  :   dbo.USP_DUES_INVOICE
** Desc  :   
** Author:   Bipul
** Date  :   March 31, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_DUES_INVOICE]
(
	@ShowAs As char(1) = 'O',
	@CompanyID As int = 0,
	@ShdlDate As varchar(10) = ''
)
AS
BEGIN
	IF @ShowAs = 'O'
		BEGIN
			IF @CompanyID = 0
				BEGIN
					select s.cid,c.name,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount 
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1 And i.shdldate<=@ShdlDate
					order by i.shdldate
				END
			ELSE
				BEGIN
					select s.cid,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount  
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1  And i.shdldate<=@ShdlDate And c.id=@CompanyID
					order by i.shdldate
				END
		END
	ELSE
		BEGIN
			IF @CompanyID = 0
				BEGIN
					select s.cid,c.name,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount 
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1 
					order by i.shdldate
				END
			ELSE
				BEGIN
					select s.cid,l.sbname,s.salesprice,i.id,i.invshdlno,i.shdldate,i.amount  
					from company c
						INNER JOIN sales s ON s.cid=c.id
						INNER JOIN ledger l ON s.pcode=l.id 
						INNER JOIN InvoiceSceduler i ON s.tno=i.tno
					where i.Invoice_Id =0 And s.Posted = 1 And c.id=@CompanyID
					order by i.shdldate
				END
		END
END
GO
