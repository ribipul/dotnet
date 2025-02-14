-- =============================================
-- Author:				Bipul
-- Create date: 		14.05.2014
-- Description:			Update Sales Journal
-- =============================================
CREATE PROCEDURE [dbo].[USP_SALES_JOURNAL_UPDATE_D]
(
	@SID					As int,
	@VATID					As int,
	@TNO					As int,
	@ODuration				As int,
	@CDuration				As int,
	@OAmount				As float,
	@CAmount				As float,
	@OAmountVAT				As float,
	@CAmountVAT				As float,
	@JDate					As varchar(10),
	@Description			As varchar(200),
	@UserID					int
)
AS
BEGIN
	DECLARE @ARId As int = 35
	DECLARE @Duration	As int
	DECLARE @CMAmount	As float
	DECLARE @OMAmount	As float
	DECLARE @ADEM		As float
	DECLARE @Description1	As varchar(200)
	DECLARE @Description2	As varchar(200)
	DECLARE @CMAmountVAT	As float
	DECLARE @OMAmountVAT	As float
	DECLARE @ADEMVAT		As float
	DECLARE @RJDate As varchar(10) = ''
	
	SET @CMAmount = CAST(ROUND((@CAmount/@CDuration), 2, 1) AS DECIMAL(10,2))
	SET @OMAmount = CAST(ROUND((@OAmount/@ODuration), 2, 1) AS DECIMAL(10,2))
	SET @ADEM = @CMAmount - @OMAmount

	SET @CMAmountVAT = CAST(ROUND((@CAmountVAT/@CDuration), 2, 1) AS DECIMAL(10,2))
	SET @OMAmountVAT = CAST(ROUND((@OAmountVAT/@ODuration), 2, 1) AS DECIMAL(10,2))
	SET @ADEMVAT = @CMAmountVAT - @OMAmountVAT

	SET @Duration = @CDuration - @ODuration
	--PRINT @CMAmount 
	--PRINT @OMAmount
	--PRINT @ADEM
	--PRINT @CMAmountVAT 
	--PRINT @OMAmountVAT
	--PRINT @ADEMVAT
	--PRINT @Duration
	--PRINT @Description
	
	IF @Duration = 0
		BEGIN
			IF @ADEM > 0
				BEGIN
					--Adjust journal entry
					SET @Description1 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @CDuration, @TNO, @Description1, @UserID
				END
			ELSE IF @ADEM < 0
				BEGIN
					--Adjust journal entry
					SET @ADEM = (SELECT ABS(@ADEM))
					SET @Description1 = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @ADEM, @JDate, @CDuration, @TNO, @Description1, @UserID
				END
	-- For VAT
			IF @ADEMVAT > 0
				BEGIN
					--Adjust journal entry
					SET @Description2 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @CDuration, @TNO, @Description2, @UserID
				END
			ELSE IF @ADEMVAT < 0
				BEGIN
					--Adjust journal entry
					SET @ADEMVAT = (SELECT ABS(@ADEMVAT))
					SET @Description2 = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @ADEMVAT, @JDate, @CDuration, @TNO, @Description2, @UserID
				END
		END
	ELSE IF @Duration > 0
		BEGIN
			IF @ADEM = 0
				BEGIN
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @RJDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM > 0
				BEGIN
					--Adjust journal entry
					SET @Description1 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @ODuration, @TNO, @Description1, @UserID
					--Add journal entry
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @RJDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM < 0
				BEGIN
					--Adjust journal entry
					SET @ADEM = (SELECT ABS(@ADEM))
					SET @Description1 = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @ADEM, @JDate, @ODuration, @TNO, @Description1, @UserID
					--Add journal entry
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @RJDate, @Duration, @TNO, @Description, @UserID
				END
	-- For VAT
			IF @ADEMVAT = 0
				BEGIN
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @CMAmountVAT, @RJDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEMVAT > 0
				BEGIN
					--Adjust journal entry
					SET @Description2 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @ODuration, @TNO, @Description2, @UserID
					--Add journal entry
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @CMAmountVAT, @RJDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEMVAT < 0
				BEGIN
					--Adjust journal entry
					SET @ADEMVAT = (SELECT ABS(@ADEMVAT))
					SET @Description2 = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @ADEMVAT, @JDate, @ODuration, @TNO, @Description2, @UserID
					--Add journal entry
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
					SET @Duration = (SELECT ABS(@Duration))
					EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @CMAmountVAT, @RJDate, @Duration, @TNO, @Description, @UserID
				END
		END
	ELSE IF @Duration < 0
		BEGIN
			IF @ADEM = 0
				BEGIN
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @CDuration, @JDate),111)
					SET @Duration = (SELECT ABS(@Duration))
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @RJDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM > 0
				BEGIN
					--Adjust journal entry
					SET @Description1 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @CDuration, @TNO, @Description1, @UserID
					--Add journal entry
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @CDuration, @JDate),111)
					SET @Duration = (SELECT ABS(@Duration))
					SET @Description1 = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @RJDate, @Duration, @TNO, @Description1, @UserID
				END
			ELSE IF @ADEM < 0
				BEGIN
					--Adjust journal entry
					SET @Duration = (SELECT ABS(@Duration))
					SET @ADEM = (SELECT ABS(@ADEM))
					SET @Description1 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @ADEM, @JDate, @CDuration, @TNO, @Description1, @UserID
					
					--Add journal entry
					SET @Description1 = 'Reverse entry. ' + @Description
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @Duration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @RJDate, @Duration, @TNO, @Description1, @UserID
				END
	-- For VAT		
			IF @ADEMVAT = 0
				BEGIN
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @CDuration, @JDate),111)
					SET @Duration = (SELECT ABS(@Duration))
					EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @OMAmountVAT, @RJDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEMVAT > 0
				BEGIN
					--Adjust journal entry
					SET @Description2 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @CDuration, @TNO, @Description2, @UserID
					
					--Add journal entry
					SET @Duration = (SELECT ABS(@Duration))
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @CDuration, @JDate),111)	
					SET @Description2 = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @OMAmountVAT, @RJDate, @Duration, @TNO, @Description2, @UserID
				END
			ELSE IF @ADEMVAT < 0
				BEGIN
					--Adjust journal entry
					SET @Duration = (SELECT ABS(@Duration))
					SET @ADEMVAT = (SELECT ABS(@ADEMVAT))
					SET @Description2 = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @ADEMVAT, @JDate, @CDuration, @TNO, @Description2, @UserID
					--Add journal entry
					SET @Description2 = 'Reverse entry. ' + @Description
					SET @RJDate = CONVERT(VARCHAR(10),DATEADD(MONTH, @Duration, @JDate),111)
					EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @OMAmountVAT, @RJDate, @Duration, @TNO, @Description2, @UserID
				END
		END
END