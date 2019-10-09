--select * from Ledger
--where id = 672

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
--EXEC USP_SALES_JOURNAL @SID, @Amount, @JDate, @SalesDuration, @TNO, @Description, @SalesDate, @VATID, @AmountVAT, @UserID

USP_SALES_JOURNAL 52,120000,'1/1/2014',12,98119,'Company: A & A ARK DEVELOPERS LTD, Item: Home Page Bottom Banner','1/1/2014',672,18000,66

select * from Journal
where Tno = 98119
order by id

select * from Sales
where Tno = 98119

select * from JournalVoucher
where Jid >= 348141
