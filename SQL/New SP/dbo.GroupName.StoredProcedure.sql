USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[GroupName]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GroupName]
AS
	BEGIN
		select l1.ID, l1.SBName
		from Ledger l1 
		where l1.levelNo IN(0) 
		order by l1.Id
	END
GO
