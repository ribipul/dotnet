USE [Accounting]
GO
/****** Object:  StoredProcedure [dbo].[USP_CASH_COLLECTION]    Script Date: 08/21/2014 12:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:				Bipul
-- Create date: 		10.05.2014
-- Description:			Cash Collection Journal
-- =============================================
ALTER PROCEDURE [dbo].[USP_CASH_COLLECTION]
(
	@Cash				float,
	@JDate				smalldatetime,
	@SalesDate			smalldatetime,
	@SalesPrice			float,
	@SalesCollection	float,
	@SalesDuration		int,
	@TNO				int,
	@TypeID				int,
	@UserID				int,
	@Description		varchar(200),
	@ChequeNo			varchar(50) = null
)
AS
BEGIN
	DECLARE @AdARId As int = 96
	DECLARE @ARId As int = 35

	DECLARE @PSalesColl	As	float = 0
	DECLARE @Installment As float = 0
	DECLARE @CurrentAR As float = 0
	DECLARE @RestCash As float = 0
	DECLARE @JID As	int = 0
	DECLARE @STRQuery As varchar(1000) = ''
	DECLARE @MonthNo As int = 0
	--DECLARE @LastAdMonthNo As float(6) = 0
	DECLARE @LastAdMonthNo As int = 0
	DECLARE @Counter As int = 0
	DECLARE @PostDate As varchar(10) = ''
	DECLARE @CurrentDate As varchar(10) = ''
	
	SET @JID = (SELECT (MAX(Jid)+1) As JID FROM Journal)
	SET @PostDate = CONVERT(VARCHAR(10),GETDATE(),111)
	SET @CurrentDate = CONVERT(VARCHAR(10),@JDate,111)
	
	--PRINT @SalesDuration

	IF @SalesDuration = 1
		BEGIN
			SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
			SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
			
			IF @ChequeNo IS NULL
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
					SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
				END
			ELSE
				BEGIN
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
					SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)	--Account Receivables Credit
				END
				
			
			EXEC(@STRQuery)
			EXEC USP_MakeJournalVoucher @JID, @CurrentDate
		END
	ELSE
		BEGIN
			SET @Installment = @SalesPrice/@SalesDuration				-- Monthly Installment
			SET @PSalesColl = @SalesCollection - @Cash					-- Previous Collection
			SET @MonthNo = DATEDIFF(MONTH,@SalesDate,@CurrentDate)+1
			SET @CurrentAR = @Installment*@MonthNo
			
			IF @CurrentAR > @SalesPrice
				SET @CurrentAR = @SalesPrice
			
			SET @CurrentAR = @CurrentAR - @PSalesColl
			
			IF @CurrentAR > 0
				BEGIN
					PRINT '@CurrentAR > 0'
					IF @CurrentAR >= @Cash
						BEGIN
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
							
							IF @ChequeNo IS NULL
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)									--Account Receivables Credit
								END
							ELSE
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)									--Account Receivables Credit
								END
							EXEC(@STRQuery)
							EXEC USP_MakeJournalVoucher @JID, @CurrentDate
							--PRINT @STRQuery	+ '1'
							SET @JID = @JID + 1
						END
					ELSE
						BEGIN
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
							
							IF @ChequeNo IS NULL
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@CurrentAR As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
							
									SET @RestCash = @Cash - @CurrentAR
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Advance Income Credit
								END
							ELSE
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@CurrentAR As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
							
									SET @RestCash = @Cash - @CurrentAR
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Advance Income Credit
								END
							EXEC(@STRQuery)							
							EXEC USP_MakeJournalVoucher @JID, @CurrentDate
							--PRINT @STRQuery + '2'
							SET @JID = @JID + 1
							
							SET @MonthNo = @RestCash/@Installment
													
							IF @MonthNo = 0
								SET @MonthNo = 1
							
							SET @RestCash = @RestCash/@MonthNo
							
							IF @RestCash > @Installment
								BEGIN
									SET @RestCash = (@RestCash - @Installment)*@MonthNo
									SET @Counter = 1
									WHILE (@Counter <= @MonthNo)
										BEGIN
											SET @STRQuery = ''
											SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
											
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@Installment As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
											
											IF @ChequeNo IS NULL
												BEGIN
													SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
													SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Installment As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
												END
											ELSE
												BEGIN
													SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
													SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Installment As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
												END
											EXEC(@STRQuery)											
											EXEC USP_MakeJournalVoucher @JID, @CurrentDate
											--PRINT @STRQuery + '3'
											SET @JID = @JID + 1
											SET @Counter = @Counter + 1
										END								
								END
							SET @STRQuery = ''
							SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
							
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@RestCash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
							IF @ChequeNo IS NULL
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								END
							ELSE
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								END
								
							EXEC(@STRQuery)							
							EXEC USP_MakeJournalVoucher @JID, @CurrentDate
							--PRINT @STRQuery + '4'
							SET @JID = @JID + 1
						END
				END
			ELSE IF @CurrentAR = 0
				BEGIN
					--PRINT '@CurrentAR = 0'
					SET @STRQuery = ''
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
					SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
					IF @ChequeNo IS NULL
						BEGIN
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
						END
					ELSE
						BEGIN
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
						END
					EXEC(@STRQuery)
					EXEC USP_MakeJournalVoucher @JID, @CurrentDate
					--PRINT '1'+@STRQuery
					SET @JID = @JID + 1
					
					--SET @LastAdMonthNo = CAST(@PSalesColl/@Installment As decimal)
					--SET @CurrentDate = CAST(@LastAdMonthNo As varchar(2))+'/'+CAST(DAY(GETDATE()) As varchar(2))+'/'+CAST(YEAR(GETDATE()) As varchar(4))
					
					----SET @RestCash = (CAST(@PSalesColl As int) % CAST(@Installment AS int))
					
					SET @MonthNo = @Cash/@Installment
					
					IF @MonthNo = 0
						SET @MonthNo = 1
					
					SET @RestCash = @Cash/@MonthNo
					IF @RestCash >= @Installment
						BEGIN
							SET @RestCash = (@RestCash - @Installment) * @MonthNo
							SET @Counter = 1
							WHILE (@Counter <= @MonthNo)
								BEGIN
									SET @STRQuery = ''
									SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
									
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@Installment As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
									IF @ChequeNo IS NULL
										BEGIN
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Installment As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										END
									ELSE
										BEGIN
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Installment As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										END
									EXEC(@STRQuery)									
									EXEC USP_MakeJournalVoucher @JID, @CurrentDate
									--PRINT '2'+@STRQuery
									SET @JID = @JID + 1
									SET @Counter = @Counter + 1
								END
						END
					IF @RestCash > 0
						BEGIN
							SET @STRQuery = ''
							SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@RestCash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
							IF @ChequeNo IS NULL
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								END
							ELSE
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								END
							EXEC(@STRQuery)								
							EXEC USP_MakeJournalVoucher @JID, @CurrentDate
							--PRINT '3'+@STRQuery
						END
				END
			ELSE IF @CurrentAR < 0
				--PRINT '@CurrentAR < 0'
				BEGIN
					SET @STRQuery = ''
					SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
					SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@TypeID As varchar(10)) + ',''' + @Description + ''',' + CAST(@Cash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Cash Debt
					IF @ChequeNo IS NULL
						BEGIN
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
						END
					ELSE
						BEGIN
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Cash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)								--Account Receivables Credit
						END
					EXEC(@STRQuery)							
					EXEC USP_MakeJournalVoucher @JID, @CurrentDate
					--PRINT '1'+@STRQuery
					SET @JID = @JID + 1
					
					SET @LastAdMonthNo = @PSalesColl/@Installment	--CAST(@PSalesColl/@Installment As decimal)
					SET @RestCash = (CAST(@PSalesColl As int) % CAST(@Installment AS int))	--@LastAdMonthNo
					--PRINT @RestCash
					SET @CurrentDate = CAST(@LastAdMonthNo+1 As varchar(2))+'/'+CAST(DAY(GETDATE()) As varchar(2))+'/'+CAST(YEAR(GETDATE()) As varchar(4))
					--PRINT @CurrentDate
					IF @RestCash = 0
						SET @RestCash = @Cash
					ELSE
						BEGIN
							SET @RestCash = @Installment - @RestCash
							--PRINT @RestCash
							IF @RestCash > @Cash
								SET @RestCash = @Cash
							ELSE
								BEGIN
									SET @STRQuery = ''
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@RestCash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
									IF @ChequeNo IS NULL
										BEGIN
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										END
									ELSE
										BEGIN
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										END
									EXEC(@STRQuery)									
									EXEC USP_MakeJournalVoucher @JID, @CurrentDate
									--PRINT '2'+@STRQuery
									SET @JID = @JID + 1
									SET @RestCash = @Cash - @RestCash
									SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
								END
						END
					
					SET @MonthNo = @RestCash/@Installment
					IF @MonthNo = 0
						SET @MonthNo = 1
					
					SET @RestCash = @RestCash / @MonthNo
					
					IF @RestCash >= @Installment
						BEGIN
							SET @RestCash = (@RestCash - @Installment) * @MonthNo
							
							--SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
							SET @Counter = 1
							WHILE (@Counter <= @MonthNo)
								BEGIN
									SET @STRQuery = ''
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@Installment As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
									IF @ChequeNo IS NULL
										BEGIN
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@Installment As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										END
									ELSE
										BEGIN
											SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
											SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@Installment As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
										END
									EXEC(@STRQuery)									
									EXEC USP_MakeJournalVoucher @JID, @CurrentDate
									--PRINT '3'+@STRQuery
									SET @JID = @JID + 1
									SET @Counter = @Counter + 1
									SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
								END
						END
					IF @RestCash > 0
						BEGIN
							SET @STRQuery = ''
							--SET @CurrentDate = CONVERT(VARCHAR(10),DATEADD(MONTH, 1, @CurrentDate),111)
							SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
							SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@AdARId As varchar(10)) + ',''' + @Description + ''',' + CAST(@RestCash As varchar(10)) + ',0,''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''Sales'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)		--Advance Income Debt
							IF @ChequeNo IS NULL
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ',0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								END
							ELSE
								BEGIN
									SET @STRQuery = @STRQuery + 'INSERT INTO Journal(jid,sid,Description,debt,credit,Jdate,tno,Notify,PostDate,UserID) ' + CHAR(13)
									SET @STRQuery = @STRQuery + 'VALUES(' + CAST(@JID As varchar(10)) + ',' + CAST(@ARId As varchar(10)) + ', ''Cheque No: ' + @ChequeNo + ''', 0,' + CAST(@RestCash As varchar(10)) + ',''' + @CurrentDate + ''',' + CAST(@TNO As varchar(10)) + ',''AR'',''' + @PostDate + ''',' + CAST(@UserID As varchar(10)) + ')' + CHAR(13)										--Account Receivables Credit
								END
							EXEC(@STRQuery)								
							EXEC USP_MakeJournalVoucher @JID, @CurrentDate
							--PRINT '4'+@STRQuery
						END
				END
		END
END