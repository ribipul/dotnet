DECLARE @IdForDebt			As int = 35,
		@IdForCredit		As int = 672,
		@Amount				As float = 750,
		@JDate				As smalldatetime = '01/01/2014',
		@SalesDuration		As int = 12,
		@TNO				As int = 98119,
		@Description		As varchar(200) = 'Company: A & A ARK DEVELOPERS LTD, Item: Home Page Bottom Banner',
		@UserID				int = 66
	
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
	
	--PRINT @JClosingDate
	IF (Month(@JDate) < Month(@JClosingDate)) AND @SalesDuration > 1
		BEGIN
			SET @iCount = DATEDIFF(MONTH,@JDate,@JClosingDate)
			
			IF @iCount >= @SalesDuration
				BEGIN
					SET @iCount = @SalesDuration
					SET @SalesDuration = 1
				END
			ELSE IF @iCount <= 0
				SET @iCount = 1
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
	SET @Temp = @Amount
	
	SET @iCount = 1
	SET @STRQuery = ''
	PRINT @SalesDuration
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
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForDebt As varchar(10)) + ', '''', ' + CAST(ABS(@Amount) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			ELSE
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForDebt As varchar(10)) + ', ''' + @Description + ''',' + CAST(ABS(@Amount) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''Sales'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
				SET @STRQuery = @STRQuery + 'EXEC USP_MakeJournalVoucher ' + CAST(@JID As varchar(10)) + ', ''' + CONVERT(VARCHAR(10),@JDate,111)  + '''' + CHAR(13)
			IF @IdForCredit <> @ARId
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForCredit As varchar(10)) + ', ''' + @Description + ''', 0,' + CAST(ABS(@Amount) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''Sales'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			ELSE
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@IdForCredit As varchar(10)) + ', '''', 0, ' + CAST(ABS(@Amount) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
				END
			SET @STRQuery = @STRQuery + 'EXEC USP_MakeJournalVoucher ' + CAST(@JID As varchar(10)) + ', ''' + CONVERT(VARCHAR(10),@JDate,111)  + '''' + CHAR(13)
			
			BEGIN TRAN
				--EXEC (@STRQuery)
				PRINT CAST(@iCount As varchar(12))+ CHAR(13)+@STRQuery
				SELECT @intErrorCode = @@ERROR
				IF (@intErrorCode <> 0)
					BEGIN
						PRINT 'Unexpected error occurred!'
						ROLLBACK TRAN
						--RETURN 1
					END
			COMMIT TRAN
			SET @JID = @JID + 1
			SET @JDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @JDate),111)
			SET @iCount = @iCount + 1
		END