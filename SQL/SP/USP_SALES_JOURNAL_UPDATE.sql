-- =============================================
-- Author:				Bipul
-- Create date: 		14.05.2014
-- Description:			Update Sales Journal
-- =============================================
CREATE PROCEDURE [dbo].[USP_SALES_JOURNAL_UPDATE]
(
	@SID					As int,
	@TNO					As int,
	@ODuration				As int,
	@CDuration				As int,
	@OAmount				As float,
	@CAmount				As float,
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

	SET @CMAmount = CAST(ROUND((@CAmount/@CDuration), 2, 1) AS DECIMAL(10,2))
	SET @OMAmount = CAST(ROUND((@OAmount/@ODuration), 2, 1) AS DECIMAL(10,2))

	SET @ADEM = @CMAmount - @OMAmount

	SET @Duration = @CDuration - @ODuration
	--PRINT @CMAmount 
	--PRINT @OMAmount
	--PRINT @ADEM
	--PRINT @Duration

	IF @Duration = 0
		BEGIN
			IF @ADEM = 0
				BEGIN
					--Adjust journal entry
					SET @Description = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @CDuration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM < 0
				BEGIN
					--Adjust journal entry
					SET @ADEM = (SELECT ABS(@ADEM))
					SET @Description = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @ADEM, @JDate, @CDuration, @TNO, @Description, @UserID
				END
		END
	ELSE IF @Duration > 0
		BEGIN
			IF @ADEM = 0
				BEGIN
					SET @JDate = DateAdd(MONTH, @ODuration, @JDate)
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @JDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM > 0
				BEGIN
					--Adjust journal entry
					SET @Description = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @ODuration, @TNO, @Description, @UserID
					--Add journal entry
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @JDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM < 0
				BEGIN
					--Adjust journal entry
					SET @ADEM = (SELECT ABS(@ADEM))
					SET @Description = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @ADEM, @JDate, @ODuration, @TNO, @Description, @UserID
					--Add journal entry
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @JDate, @Duration, @TNO, @Description, @UserID
				END
		END
	ELSE IF @Duration < 0
		BEGIN
			IF @ADEM = 0
				BEGIN
					SET @Duration = (SELECT ABS(@Duration))
					SET @JDate = DateAdd(MONTH, @CDuration, @JDate)
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @JDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM > 0
				BEGIN
					--Adjust journal entry
					SET @Duration = (SELECT ABS(@Duration))
					SET @Description = 'Adjustment entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @CDuration, @TNO, @Description, @UserID
					--Add journal entry
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @JDate, @Duration, @TNO, @Description, @UserID
				END
			ELSE IF @ADEM < 0
				BEGIN
					--Adjust journal entry
					SET @Duration = (SELECT ABS(@Duration))
					SET @ADEM = (SELECT ABS(@ADEM))
					SET @Description = 'Reverse entry. ' + @Description
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @ADEM, @JDate, @ODuration, @TNO, @Description, @UserID
					--Add journal entry
					EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @JDate, @Duration, @TNO, @Description, @UserID
				END
		END
END