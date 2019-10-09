DECLARE @Cash				As	float
DECLARE @CurrentDate		As	smalldatetime
DECLARE @SalesDate			As	smalldatetime
DECLARE @SalesPrice			As	float
DECLARE @SalesCollection	As	float
DECLARE @SalesDuration		As	int
DECLARE @TNO				As	int
DECLARE @TypeID				As	int
DECLARE @UserID				As	int
DECLARE @Description		As	varchar(200)

SET @Cash = 30000
SET @CurrentDate = '5/10/2014'
SET @SalesDate = '1/1/2014'
SET @SalesPrice = 138000
SET @SalesCollection = 30000
SET @SalesDuration = 12
SET @TNO = 98119
SET @TypeID = 46
SET @UserID = 66
SET @Description = 'Cash collected from B & B GROUP; Invoice No - 1405-05148-004-82603.'

DECLARE @AdARId As int = 96
DECLARE @ARId As int = 35

DECLARE @PSalesColl	As	float = 0
DECLARE @Installment As float = 0
DECLARE @CurrentAR As float = 0
DECLARE @RestCash As float = 0
DECLARE @JID As	int = 0
DECLARE @STRQuery As varchar(1000) = ''
DECLARE @MonthNo As int = 0
DECLARE @LastAdMonthNo As float(6) = 0
DECLARE @Counter As int = 0

SET @JID = (SELECT (MAX(Jid)+1) As JID FROM Journal)
--PRINT @SalesDuration

IF @SalesDuration = 1
	BEGIN
		SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
		SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
		SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
		SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Cash As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)									--Account Receivables Credit
		
		--USP_MakeJournalVoucher @JID, @CurrentDate						
		SET @JID = @JID + 1
		PRINT @Cash
	END
ELSE
	BEGIN
		SET @Installment = @SalesPrice/@SalesDuration				-- Monthly Installment
		SET @PSalesColl = @SalesCollection - @Cash					-- Previous Collection
		SET @MonthNo = DATEDIFF(MONTH,@SalesDate,@CurrentDate)+1
		SET @CurrentAR = @Installment*@MonthNo
		--PRINT @CurrentAR
		IF @CurrentAR > @SalesPrice
			SET @CurrentAR = @SalesPrice
		
		SET @CurrentAR = @CurrentAR - @PSalesColl
		--PRINT @CurrentAR
		IF @CurrentAR > 0
			BEGIN
				IF @CurrentAR >= @Cash
					BEGIN
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Cash As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
						
						--EXEC(@STRQuery)
						PRINT @STRQuery
						--EXEC USP_MakeJournalVoucher @JID, @CurrentDate						
						SET @JID = @JID + 1
						--PRINT @Cash
					END
				ELSE
					BEGIN
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@CurrentAR As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
						--PRINT @CurrentAR
						SET @RestCash = @Cash - @CurrentAR
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Advance Income Credit
						
						--USP_MakeJournalVoucher @JID, @CurrentDate						
						SET @JID = @JID + 1
						
						PRINT @STRQuery
						
						SET @MonthNo = @RestCash/@Installment
												
						IF @MonthNo = 0
							SET @MonthNo = 1
						
						SET @RestCash = @RestCash/@MonthNo						
						PRINT @RestCash
						
						IF @RestCash > @Installment
							BEGIN
								SET @RestCash = (@RestCash - @Installment)*@MonthNo
								SET @Counter = 1
								WHILE (@Counter <= @MonthNo)
									BEGIN
										SET @CurrentDate = DATEADD(MONTH, 1, @CurrentDate)
										
										SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
										SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@Installment As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
										SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
										SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Installment As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										
										--USP_MakeJournalVoucher @JID, @CurrentDate						
										SET @JID = @JID + 1
										SET @Counter = @Counter + 1
										PRINT @CurrentDate
									END								
							END
						SET @CurrentDate = DATEADD(MONTH, 1, @CurrentDate)
						
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@RestCash As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
						SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
						SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
						
						--USP_MakeJournalVoucher @JID, @CurrentDate						
						SET @JID = @JID + 1
						PRINT @CurrentDate
					END
			END
		ELSE IF @CurrentAR = 0
			BEGIN
				PRINT '@CurrentAR = 0'	--@CurrentAR
			END
		ELSE IF @CurrentAR < 0
			BEGIN
				PRINT '@CurrentAR < 0'	--@CurrentAR
				PRINT @PSalesColl
				SET @LastAdMonthNo = CAST(@PSalesColl/@Installment As decimal)
				PRINT @LastAdMonthNo
				SET @RestCash = (CAST(@PSalesColl As int) % CAST(@Installment AS int))	--@LastAdMonthNo
				PRINT @PSalesColl
				
				IF @RestCash = 0
					BEGIN
						SET @RestCash = @Cash
						SET @CurrentDate = CAST(@LastAdMonthNo As varchar(2))+'/'+CAST(DAY(GETDATE()) As varchar(2))+'/'+CAST(YEAR(GETDATE()) As varchar(4))
					END
				ELSE
					BEGIN
						SET @CurrentDate = CAST((@LastAdMonthNo-1) As varchar(2))+'/'+CAST(DAY(GETDATE()) As varchar(2))+'/'+CAST(YEAR(GETDATE()) As varchar(4))
						SET @RestCash = @Installment - @RestCash
						PRINT @RestCash
						IF @RestCash >= @Cash
							SET @RestCash = @RestCash
						ELSE
							BEGIN
								SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
								SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@RestCash As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
								SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
								SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								
								--USP_MakeJournalVoucher @JID, @CurrentDate						
								SET @JID = @JID + 1
								SET @RestCash = @Installment - @RestCash
								PRINT @CurrentDate
							END
					END
				
				SET @MonthNo = @RestCash/@Installment
				IF @MonthNo = 0
					SET @MonthNo = 1
				--PRINT @MonthNo
				SET @RestCash = @RestCash / @MonthNo
				
				IF @RestCash > @Installment
					BEGIN
						SET @RestCash = (@RestCash - @Installment) * @MonthNo
						
						SET @Counter = 1
						WHILE (@Counter <= @MonthNo)
							BEGIN
								SET @CurrentDate = DATEADD(MONTH, 1, @CurrentDate)
								
								SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
								SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@Installment As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
								SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
								SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Installment As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								
								--USP_MakeJournalVoucher @JID, @CurrentDate
								SET @JID = @JID + 1
								SET @Counter = @Counter + 1
								PRINT @CurrentDate
							END
					END
					IF @RestCash > 0
						BEGIN
							SET @CurrentDate = DATEADD(MONTH, 1, @CurrentDate)
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@Installment As varchar(10)) + ',0,''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Installment As varchar(10)) + ',''' + CONVERT(VARCHAR(10),@CurrentDate,111) + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + CAST(GETDATE() As varchar(20)) + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
							
							--USP_MakeJournalVoucher @JID, @CurrentDate
							PRINT @CurrentDate
						END
			END
	END
