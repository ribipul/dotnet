USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[INSERT_UPDATE_COMPANY]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[INSERT_UPDATE_COMPANY]
** Name  :   dbo.INSERT_UPDATE_COMPANY
** Desc  :   
** Author:   Bipul
** Date  :   March 24, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[INSERT_UPDATE_COMPANY]
(
	@Name varchar(100) = '',
	@Address varchar(250) = '',
	@City varchar(50) = '',
	@Phone varchar(100) = '',
	@Email varchar(100) = '',
	@Fax varchar(100) = '',
	@Contact_Person varchar(100) = '',
	@Designation varchar(50) = '',
	@BlackListed bit = 0,
	@CP_ID int = 0,
	@AccContactName varchar(200) = '',
	@VATRegNo varchar(15) = '',
	@VATRegAdd varchar(25) = '',
	@Id int = 0
)
AS
BEGIN
	DECLARE @CID int = 0
	DECLARE @Exist int = 0
	IF @Id = 0
		BEGIN
			INSERT INTO Company(Name, Address, City, Phone, Email, Fax, Contact_Person, Designation, BlackListed, CP_ID, AccContactName, VATRegNo, VATRegAdd)
			VALUES(@Name, @Address, @City, @Phone, @Email, @Fax, @Contact_Person, @Designation, @BlackListed, @CP_ID, @AccContactName, @VATRegNo, @VATRegAdd)
			
			SELECT @CID = MAX(ID) FROM Company
			
			INSERT INTO ContactPersons(CID, Name, Designation, PType)
			VALUES(@CID, @Contact_Person, @Designation, 'Contact person')
		END
	ELSE
		BEGIN
			UPDATE Company
				SET Name = @Name,
				Address = @Address,
				City = @City,
				Phone = @Phone,
				Email = @Email,
				Fax = @Fax,
				Contact_Person = @Contact_Person,
				Designation = @Designation,
				BlackListed = @BlackListed,
				CP_ID = @CP_ID,
				AccContactName = @AccContactName,
				VATRegNo = @VATRegNo,
				VATRegAdd = @VATRegAdd
			WHERE ID = @Id
			
			SELECT @Exist=COUNT(ID) FROM ContactPersons
			WHERE CID = @Id And Name = @Contact_Person And PType = 'Contact person'
			
			IF @Exist > 0
				BEGIN
					UPDATE ContactPersons
						SET Name = @Contact_Person,
						Designation = @Designation
					WHERE ID = @Exist And CID = @Id
				END
			ELSE
				BEGIN
					INSERT INTO ContactPersons(CID, Name, Designation, PType)
					VALUES(@Id, @Contact_Person, @Designation, 'Contact person')
				END
		END
END
GO
