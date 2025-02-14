-- =============================================
-- Author:				Bipul
-- Create date: 		14.05.2014
-- Description:			Update Rest Sales Journal
-- =============================================
CREATE PROCEDURE [dbo].[USP_REST_SALES_JOURNAL]
(
	@IdForDebt			As int,
	@IdForCredit		As int,
	@Amount				As float,
	@JDate				As smalldatetime,
	@SalesDuration		As int,
	@TNO				As int,
	@Description		As varchar(200),
	@UserID				int
)
AS
BEGIN
	DECLARE @ARId As int = 35
	DECLARE @Temp						As float = 0
	DECLARE @FirstMonthAmount			As float = 0
	DECLARE @JClosingDate				As varchar(10)
	DECLARE @iCount As int = 0
	DECLARE @JID As	int = 0
	DECLARE @STRQuery As varchar(8000) = ''
	DECLARE @PostDate As varchar(10) = ''
	DECLARE @intErrorCode INT
	
	SET @JID = (SELECT (MAX(Jid)+1) As JID FROM Journal)
	SET @PostDate = CONVERT(VARCHAR(10),GETDATE(),111)
	SET @JDate = CONVERT(VARCHAR(10),@JDate,111)
	
--if Sales occured before Journal Closing date	
	SET @JClosingDate = (Select CONVERT(VARCHAR(10),ClosingDate,111) from CloseingDateInfo)

	IF @SalesDuration = 0
		SET @SalesDuration = 1
	
	IF @JDate < @JClosingDate
		BEGIN
			--PRINT @JClosingDate
			IF (MONTH(@JDate) < MONTH(@JClosingDate)) AND @SalesDuration > 1
				BEGIN
					SET @iCount = DATEDIFF(MONTH,@JDate,@JClosingDate)
					
					IF @iCount >= @SalesDuration
						BEGIN
							SET @iCount = @SalesDuration
							SET @SalesDuration = 1
						END
					ELSE
						SET @iCount = @iCount + 1
					
					SET @JDate = CONVERT(VARCHAR(10),DATEADD(DAY, 1, @JClosingDate),111)
					SET @FirstMonthAmount = @Amount * @iCount
					
					SET @SalesDuration = @SalesDuration - @iCount + 1
					IF @SalesDuration = 0
						SET @SalesDuration = 1
				END
			ELSE
				SET @FirstMonthAmount = @Amount
		END
	ELSE
		SET @FirstMonthAmount = @Amount
	
	SET @Temp = @Amount
	
	SET @iCount = 1
	SET @STRQuery = ''
	--PRINT @SalesDuration
	WHILE (@iCount <= @SalesDuration)
		BEGIN
			IF @iCount = 1
                SET @Amount = @FirstMonthAmount
            ELSE
                SET @Amount = @Temp
            
			SET @STRQuery = ''
			IF @IdForDebt = @ARId
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForDebt As varchar(10)) + ', '''', ' + CAST(ABS(@Amount) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + CAST(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			ELSE
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForDebt As varchar(10)) + ', ''' + @Description + ''',' + CAST(ABS(@Amount) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + CAST(@TNO As varchar(10)) + ', ''Sales'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			IF @IdForCredit <> @ARId
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForCredit As varchar(10)) + ', ''' + @Description + ''', 0,' + CAST(ABS(@Amount) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + CAST(@TNO As varchar(10)) + ', ''Sales'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			ELSE
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForCredit As varchar(10)) + ', '''', 0, ' + CAST(ABS(@Amount) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + CAST(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			SET @STRQuery = @STRQuery + 'EXEC USP_MakeJournalVoucher ' + CAST(@JID As varchar(10)) + ', ''' + CONVERT(VARCHAR(10),@JDate,111)  + '''' + CHAR(13)
			
			BEGIN TRAN
				EXEC (@STRQuery)
				--PRINT CAST(@iCount As varchar(12))+ CHAR(13)+@STRQuery
				SELECT @intErrorCode = @@ERROR
				IF (@intErrorCode <> 0)
					BEGIN
						PRINT 'Unexpected error occurred!'
						ROLLBACK TRAN
						RETURN 1
					END
			COMMIT TRAN
			SET @JID = @JID + 1
			SET @JDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @JDate),111)
			SET @iCount = @iCount + 1
		END
	
	RETURN 0
END