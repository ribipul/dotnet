-- =============================================
-- Author:		Bipul
-- Create date: January 08, 2014
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[USP_GetJobTitles] 
	-- Add the parameters for the stored procedure here
	@CompanyID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT jp_id, cname, Title, 
	(CASE WHEN AddType = 1 THEN 'Advanced' 
		WHEN AddType = 2 THEN 'Premium' 
		ELSE 'Basic' END) As Type, 
	PostingDate, ValidDate, AddType 
	FROM tmpJobs 
	WHERE TNO=0 and cp_id = @CompanyID
END
