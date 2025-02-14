USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_LEDGER_LIST_LR]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_LEDGER_LIST_LR]
** Name  :   dbo.USP_LEDGER_LIST_LR
** Desc  :   
** Author:   Bipul
** Date  :   May 31, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_LEDGER_LIST_LR]
(
	@MGroup As varchar(10) = ''
	, @CID As int = -1
)
AS 
BEGIN
	IF (@MGroup <> '') And (@CID <= 0)
		BEGIN
			SELECT id, SBName As LadgerName 
			FROM ledger 
			WHERE ledgerAcc=1 And MGroup=@MGroup
			ORDER BY SBName
		END
	ELSE IF (@MGroup <> '') And (@CID >= 0)
		BEGIN
			IF @CID > 0
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 And MGroup=@MGroup And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
			ELSE
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 And MGroup=@MGroup --And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
		END
	ELSE IF (@MGroup = '') And (@CID >= 0)
		BEGIN
			IF @CID > 0
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
			ELSE
				BEGIN
					SELECT l.Id, l.SBName 
					FROM ledger l
						INNER JOIN Journal j ON l.Id = j.Sid
						INNER JOIN Sales s ON j.Tno = s.TNO
					WHERE l.LedgerAcc = 1 --And s.CID = @CID 
					GROUP BY l.Id, l.SBName 
					ORDER BY l.SBName
				END
		END
END
GO
