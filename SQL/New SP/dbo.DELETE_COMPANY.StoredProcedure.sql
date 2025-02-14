USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_COMPANY]    Script Date: 08/04/2015 14:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_COMPANY]
(
	@CID int
)
As
BEGIN TRY
    BEGIN TRAN
        -- Delete Compay
        DELETE FROM Company
        WHERE id = @CID
        
        -- Delete Contact Person
        DELETE FROM ContactPersons
        WHERE CID = @CID        
    COMMIT TRAN
END TRY
BEGIN CATCH
  ROLLBACK TRAN
END CATCH
GO
