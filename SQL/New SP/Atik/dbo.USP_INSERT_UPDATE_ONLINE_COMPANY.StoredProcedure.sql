USE [Accounting_Web]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_UPDATE_ONLINE_COMPANY]    Script Date: 08/06/2015 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************************************************
** File  :   StoredProcedure [dbo].[USP_INSERT_UPDATE_ONLINE_COMPANY]
** Name  :   dbo.USP_INSERT_UPDATE_ONLINE_COMPANY
** Desc  :   
** Author:   Bipul
** Date  :   April 30, 2015
******************************************************************************************/

CREATE PROCEDURE [dbo].[USP_INSERT_UPDATE_ONLINE_COMPANY]
(
	@Action As varchar(10) = ''
	, @CP_ID As int = -1
	, @CompanyName As varchar(100) = ''
	, @Address As varchar(250) = ''
	, @City As varchar(50) = ''
	, @Phone As varchar(100) = ''
	, @Email As varchar(100) = ''
	, @Contact_Person As varchar(100) = ''
	, @Designation As varchar(50) = ''
	, @CompanyID int = -1
)
AS
BEGIN 
	
	SET NOCOUNT ON
	
	DECLARE @DuplicateCount As tinyint = 0
	DECLARE @C_ID As int = 0

	SELECT @DuplicateCount = COUNT(1) FROM Company WHERE name = @CompanyName

	--PRINT @DuplicateCount
	IF @Action = 'INSERT'
		BEGIN
			IF @DuplicateCount = 0
				BEGIN
					-- Insert Company Information
					INSERT INTO Company (name, address, city, phone, email, contact_person, designation, cp_id)
					VALUES (@CompanyName, @Address, @City, @Phone, @Email, @Contact_Person, @Designation, @CP_ID)
					
					-- Get CompanyID
					SELECT @C_ID = id from Company WHERE Name = @CompanyName And CP_ID = @CP_ID
					
					-- Insert Contact Person
					INSERT INTO ContactPersons(cid, name, designation, ptype)
					VALUES(@C_ID, @CompanyName, @Designation, 'Contact person')
					
					-- Update Temporary Job Table
					UPDATE tmpJobs 
						SET acc_id = @C_ID 
					WHERE cp_id = @CP_ID
				END
		END
	ELSE
		BEGIN
			-- Update Company Information
			UPDATE Company 
				SET cp_id = @CP_ID
			WHERE id = @CompanyID
	        
			-- Update Temporary Job Table
			UPDATE tmpJobs 
				SET acc_id = @CompanyID
			WHERE cp_id = @CP_ID
		END
	
	SET NOCOUNT OFF
END
GO
