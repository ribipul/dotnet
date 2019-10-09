DECLARE @SID					As int = 672,
		@TNO					As int = 98119,
		@ODuration				As int = 12,
		@CDuration				As int = 12,
		@OAmount				As float = 120000,
		@CAmount				As float = 60000,
		@JDate					As varchar(10) = '01/01/2014',
		@Description			As varchar(200) = 'Des',
		@UserID					int = 66

DECLARE @ARId As int = 35
DECLARE @Duration	As int
--DECLARE @Amount		As float
DECLARE @CMAmount	As float
DECLARE @OMAmount	As float
DECLARE @ADEM		As float

SET @CMAmount = CAST(ROUND((@CAmount/@CDuration), 2, 1) AS DECIMAL(10,2))
SET @OMAmount = CAST(ROUND((@OAmount/@ODuration), 2, 1) AS DECIMAL(10,2))

SET @ADEM = @CMAmount - @OMAmount

SET @Duration = @CDuration - @ODuration
PRINT @CMAmount 
PRINT @OMAmount
PRINT @ADEM
PRINT @Duration

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
                EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @CDuration, @TNO, @Description, @UserID
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
