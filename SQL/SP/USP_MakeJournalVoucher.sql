CREATE PROCEDURE [dbo].[USP_MakeJournalVoucher]
(
	@JournalID int,
	@JournalDate smalldatetime
)

AS

DECLARE	@MonthName varchar(3),
	@Year varchar(2),
	@strVNo varchar(8),
	@TVoucher int,
	@VoucherNo varchar(15),
	@RecordFound int

Set Nocount ON

Select @RecordFound = jid from JournalVoucher where jid = @JournalID

If @RecordFound is null
Begin
	SET @VoucherNo = ''

	SET @MonthName = SUBSTRING(DATENAME(month, @JournalDate), 1, 3)
	SET @Year = SUBSTRING(DATENAME(year, @JournalDate), 3, 2)
	SET @strVNo = @MonthName + '/' + @Year

	--SELECT @TVoucher = (SELECT count(id) FROM JournalVoucher WHERE substring(VoucherNo,1,6)= @strVNo)
	SELECT @TVoucher = count(id) FROM JournalVoucher WHERE substring(VoucherNo,1,6)= @strVNo
	SET @TVoucher = @TVoucher + 1

	SET @VoucherNo = @strVNo + '-' + RIGHT('00000' + CAST(@TVoucher AS NVARCHAR), 5)

	INSERT INTO JournalVoucher(VoucherNo, jid) VALUES( @VoucherNo, @JournalID)
	select 0 as Found
End
Else
	select 1 as Found