DECLARE @SID				As int = 52,
		@Amount				As float = 120000,
		@JDate				As smalldatetime = '01/01/2014',
		@SalesDuration		As int = 12,
		@TNO				As int = 98119,
		@Description		As varchar(200) = 'Company: A & A ARK DEVELOPERS LTD, Item: Home Page Bottom Banner',
		@SalesDate			As smalldatetime = '01/01/2014',
		@VATID				As int = 672,
		@AmountVAT			As float = 18000,
		@UserID				As int = 66
		
	DECLARE @ARId As int = 35
	DECLARE @Installment				As float = 0
	DECLARE @InstallmentVAT				As float = 0
	DECLARE @FirstMonthAmount			As float = 0
	DECLARE @FirstMonthAmountVAT		As float = 0
	DECLARE @JClosingDate				As varchar(10)
	DECLARE @iCount As int
	DECLARE @JID As	int = 0
	DECLARE @STRQuery As varchar(8000) = ''
	DECLARE @PostDate As varchar(10) = ''
	DECLARE @intErrorCode INT
	
	SET @JID = (SELECT (MAX(Jid)+1) As JID FROM Journal)
	SET @PostDate = CONVERT(VARCHAR(10),GETDATE(),111)
	SET @JDate = CONVERT(VARCHAR(10),@JDate,111)
	SET @SalesDate = CONVERT(VARCHAR(10),@SalesDate,111)
	
--if Sales occured before Journal Closing date	
	SET @JClosingDate = (Select CONVERT(VARCHAR(10),ClosingDate,111) from CloseingDateInfo)

	IF @SalesDuration = 0
		SET @SalesDuration = 1
	
	SET @Installment = CAST(ROUND((@Amount / @SalesDuration), 2, 1) AS DECIMAL(10,2))
	
	IF @VATID > 0
		SET @InstallmentVAT = CAST(ROUND((@AmountVAT / @SalesDuration), 2, 1) AS DECIMAL(10,2))
	--PRINT @JClosingDate
	IF (Month(@SalesDate) < Month(@JClosingDate)) AND @SalesDuration > 1
		BEGIN
			SET @iCount = DATEDIFF(MONTH,@SalesDate,@JDate)
			
			IF @iCount >= @SalesDuration
				BEGIN
					SET @iCount = @SalesDuration
					SET @SalesDuration = 1
				END
			ELSE
				SET @iCount = @iCount + 1
			
			SET @Description = @Description + 'Added ' + CAST(@iCount As varchar(2)) + ' month(s).'
			
			SET @FirstMonthAmount = @Installment * @iCount
			SET @FirstMonthAmountVAT = @InstallmentVAT * @iCount
			
			SET @SalesDuration = @SalesDuration - @iCount + 1
			IF @SalesDuration = 0
				SET @SalesDuration = 1
		END
	ELSE
		BEGIN
			SET @FirstMonthAmount = @Installment
			SET @FirstMonthAmountVAT = @InstallmentVAT
		END
	
	SET @iCount = 1
	SET @STRQuery = ''
	--PRINT @SalesDuration
	WHILE (@iCount <= @SalesDuration)
		BEGIN
			SET @STRQuery = ''
			IF @iCount = 1
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@ARID As varchar(10)) + ', '''', ' + CAST(ABS(@FirstMonthAmount) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@SID As varchar(10)) + ', ''' + @Description + ''', 0, ' + CAST(ABS(@FirstMonthAmount) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''Sales'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
					IF @VATID > 0
						BEGIN
							SET @JID = @JID + 1
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
							SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@ARID As varchar(10)) + ', '''', ' + CAST(ABS(@FirstMonthAmountVAT) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
							SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@VATID As varchar(10)) + ', ''' + @Description + ''', 0, ' + CAST(ABS(@FirstMonthAmountVAT) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''VAT'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)					
						END
				END
			ELSE
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@ARID As varchar(10)) + ', '''', ' + CAST(ABS(@Installment) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
					SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@SID As varchar(10)) + ', ''' + @Description + ''', 0, ' + CAST(ABS(@Installment) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''Sales'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
					IF @VATID > 0
						BEGIN
							SET @JID = @JID + 1
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
							SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@ARID As varchar(10)) + ', '''', ' + CAST(ABS(@InstallmentVAT) As varchar(20)) + ', 0, ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''AR'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid, sid, Description, debt, credit, Jdate, tno, Notify, PostDate, UserID) values(' + CHAR(13)
							SET @STRQuery = @STRQuery + CAST(@JID As varchar(10)) + ',' + CAST(@VATID As varchar(10)) + ', ''' + @Description + ''', 0, ' + CAST(ABS(@InstallmentVAT) As varchar(20)) + ', ''' + CAST(@JDate As varchar(20)) + ''', ' + Cast(@TNO As varchar(10)) + ', ''VAT'', ''' + @PostDate + ''', ' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)					
						END
				END
			SET @STRQuery = @STRQuery + 'EXEC USP_MakeJournalVoucher ' + CAST(@JID As varchar(10)) + ', ''' + CAST(@JDate As varchar(20))  + '''' + CHAR(13)
			
			BEGIN TRAN
				--EXEC @STRQuery
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
			SET @iCount = @iCount + 1
		END
	SET @STRQuery = ''
	SET @STRQuery = @STRQuery + 'UPDATE SALES SET posted=1 WHERE TNO = ' + CAST(@TNO As varchar(10)) + CHAR(13)
	
	BEGIN TRAN
		--EXEC @STRQuery
		PRINT @STRQuery
		SELECT @intErrorCode = @@ERROR
		IF (@intErrorCode <> 0)
			BEGIN
				PRINT 'Unexpected error occurred!'
				ROLLBACK TRAN
				--RETURN 1
			END
	COMMIT TRAN
	
	--RETURN 0