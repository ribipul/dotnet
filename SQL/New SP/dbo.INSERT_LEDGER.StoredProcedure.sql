USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[INSERT_LEDGER]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_LEDGER]
(
	@SBName AS varchar(50),
	@MGroup AS varchar(20),
	@SubGroupID AS int,
	@LedgerAcc AS bit = 0,
	@LedgerId As int = 0
)
AS
BEGIN
	DECLARE @LevelNo AS smallint
	DECLARE @Under AS varchar(50)


	SELECT @Under=Under, @LevelNo=LevelNo 
	FROM Ledger
	WHERE id = @SubGroupID

	SET @Under = @Under+','+CAST(@SubGroupID As varchar(10))
	SET @LevelNo = @LevelNo+1
	IF @LedgerId = 0
		BEGIN
			INSERT INTO Ledger(SBName,Under,MGroup,LevelNo,LedgerAcc)
			VALUES(@SBName, @Under, @MGroup, @LevelNo, @LedgerAcc)
		END
	ELSE
		BEGIN
			UPDATE Ledger
				SET SBName = @SBName,
				Under = @Under,
				MGroup = @MGroup,
				LevelNo = @LevelNo,
				LedgerAcc = @LedgerAcc
			WHERE Id = @LedgerId
		END
END
GO
