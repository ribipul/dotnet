DECLARE @SID					As int = 52,
		@VATID					As int = 672,
		@TNO					As int = 98119,
		@ODuration				As int = 12,
		@CDuration				As int = 6,
		@OAmount				As float = 120000,
		@CAmount				As float = 120000,
		@OAmountVAT				As float = 18000,
		@CAmountVAT				As float = 18000,
		@JDate					As varchar(10) = '01/01/2014',
		@Description			As varchar(200) = 'Company: A & A ARK DEVELOPERS LTD, Item: Home Page Bottom Banner',
		@UserID					int = 66

DECLARE @ARId As int = 35
DECLARE @Duration	As int
DECLARE @CMAmount	As float
DECLARE @OMAmount	As float
DECLARE @ADEM		As float

DECLARE @CMAmountVAT	As float
DECLARE @OMAmountVAT	As float
DECLARE @ADEMVAT		As float

SET @CMAmount = CAST(ROUND((@CAmount/@CDuration), 2, 1) AS DECIMAL(10,2))
SET @OMAmount = CAST(ROUND((@OAmount/@ODuration), 2, 1) AS DECIMAL(10,2))
SET @ADEM = @CMAmount - @OMAmount

SET @CMAmountVAT = CAST(ROUND((@CAmountVAT/@CDuration), 2, 1) AS DECIMAL(10,2))
SET @OMAmountVAT = CAST(ROUND((@OAmountVAT/@ODuration), 2, 1) AS DECIMAL(10,2))
SET @ADEMVAT = @CMAmountVAT - @OMAmountVAT

SET @Duration = @CDuration - @ODuration
PRINT @CMAmount 
PRINT @OMAmount
PRINT @ADEM
PRINT @ADEMVAT
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
-- For VAT
		IF @ADEMVAT = 0
			BEGIN
				--Adjust journal entry
                SET @Description = 'Adjustment entry. ' + @Description
                EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @CDuration, @TNO, @Description, @UserID
			END
		ELSE IF @ADEMVAT < 0
			BEGIN
				--Adjust journal entry
				SET @ADEMVAT = (SELECT ABS(@ADEMVAT))
                SET @Description = 'Reverse entry. ' + @Description
                EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @CDuration, @TNO, @Description, @UserID
			END
	END
ELSE IF @Duration > 0
	BEGIN
		IF @ADEM = 0
			BEGIN
				DECLARE @dt1 As varchar(10)
				SET @dt1 = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
				EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @CMAmount, @dt1, @Duration, @TNO, @Description, @UserID
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
-- For VAT
		IF @ADEMVAT = 0
			BEGIN
				DECLARE @dt2 As varchar(10)
				SET @dt2 = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
				EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @CMAmountVAT, @dt2, @Duration, @TNO, @Description, @UserID
			END
		ELSE IF @ADEMVAT > 0
			BEGIN
				--Adjust journal entry
				SET @Description = 'Adjustment entry. ' + @Description
                EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @ODuration, @TNO, @Description, @UserID
                --Add journal entry
                EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @CMAmountVAT, @JDate, @Duration, @TNO, @Description, @UserID
			END
		ELSE IF @ADEMVAT < 0
			BEGIN
				--Adjust journal entry
				SET @ADEMVAT = (SELECT ABS(@ADEMVAT))
				SET @Description = 'Reverse entry. ' + @Description
                EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @ADEMVAT, @JDate, @ODuration, @TNO, @Description, @UserID
                --Add journal entry
                EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @CMAmountVAT, @JDate, @Duration, @TNO, @Description, @UserID
			END
	END
ELSE IF @Duration < 0
	BEGIN
		IF @ADEM = 0
			BEGIN
				DECLARE @dt3 As varchar(10)
				SET @dt3 = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
				SET @Duration = (SELECT ABS(@Duration))
				EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @dt3, @Duration, @TNO, @Description, @UserID
			END
		ELSE IF @ADEM > 0
			BEGIN
				--Adjust journal entry
				SET @Duration = (SELECT ABS(@Duration))
				SET @Description = 'Adjustment entry. ' + @Description
                --EXEC USP_REST_SALES_JOURNAL @ARId, @SID, @ADEM, @JDate, @CDuration, @TNO, @Description, @UserID
                ----Add journal entry
                --EXEC USP_REST_SALES_JOURNAL @SID, @ARId, @OMAmount, @JDate, @Duration, @TNO, @Description, @UserID
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
-- For VAT		
		IF @ADEMVAT = 0
			BEGIN
				DECLARE @dt4 As varchar(10)
				SET @dt4 = CONVERT(VARCHAR(10),DATEADD(MONTH, @ODuration, @JDate),111)
				SET @Duration = (SELECT ABS(@Duration))
				EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @OMAmountVAT, @dt4, @Duration, @TNO, @Description, @UserID
			END
		ELSE IF @ADEMVAT > 0
			BEGIN
				--Adjust journal entry
				SET @Duration = (SELECT ABS(@Duration))
				SET @Description = 'Adjustment entry. ' + @Description
                EXEC USP_REST_SALES_JOURNAL @ARId, @VATID, @ADEMVAT, @JDate, @CDuration, @TNO, @Description, @UserID
                --Add journal entry
                EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @OMAmountVAT, @JDate, @Duration, @TNO, @Description, @UserID
			END
		ELSE IF @ADEMVAT < 0
			BEGIN
				--Adjust journal entry
				SET @Duration = (SELECT ABS(@Duration))
				SET @ADEM = (SELECT ABS(@ADEMVAT))
				SET @Description = 'Reverse entry. ' + @Description
                EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @ADEMVAT, @JDate, @ODuration, @TNO, @Description, @UserID
                --Add journal entry
                EXEC USP_REST_SALES_JOURNAL @VATID, @ARId, @OMAmountVAT, @JDate, @Duration, @TNO, @Description, @UserID
			END
	END


--EXEC USP_SALES_JOURNAL_UPDATE_D 672,52,98119,12,6,1200000,1200000,18000,18000,'1/1/2014','Company: A & A ARK DEVELOPERS LTD, Item: Home Page Bottom Banner',66

EXEC USP_SALES_JOURNAL_UPDATE 52,98119,12,12,120000,60000,'1/1/2014','Company: A & A ARK DEVELOPERS LTD, Item: Home Page Bottom Banner',66
