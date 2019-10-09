DECLARE @BankID As smallint = 0
SELECT @BankID = (CASE WHEN MAX(BankID) IS NULL THEN 0 ELSE MAX(BankID) END) + 1 FROM BankInformation

PRINT @BankID

--INSERT INTO BankInformation(BankID, AccountTitle, BankName, BranchName, BankACNo, BankRoutingNo, SwiftCode, Email)
--VALUES(@BankID, 'BDJOBS.COM LIMITED', '001513100000131', 'Southeast Bank Limited', 'Kawran Bazar, Branch', '205262535', 'SEBDBDDH', 'accounts@bdjobs.com')
--VALUES(@BankID, 'BDJOBS.COM LIMITED', '0001536942801', 'Standard Chartered Bank', 'Kawran Bazar Branch', '215262538', 'SCBLBDDX', 'accounts@bdjobs.com')
--VALUES(@BankID, 'BDJOBS.COM LIMITED', 'BRAC Bank Limited', 'Gulshan Branch', '1540201980246001', '060261726', 'BRAKBDDH', 'accounts@bdjobs.com')
--VALUES(@BankID, 'BDJOBS.COM LIMITED', 'Mutual Trust Bank Limited', 'Bashundhara City Branch', '00160320000415', '145260589', '', 'accounts@bdjobs.com')

SELECT * FROM BankInformation

--UPDATE BankInformation
--SET BankName = 'Standard Chartered Bank'
--, BranchName = 'Kawran Bazar Branch'
--, BankACNo = '0001536942801'
--WHERE BankID = 2

 
--select * from Company where Name like '%Bdjobs%'

--select i1.Invoice_No,i1.InvSendDt,c.name as CName,l.sbname,i2.amount,i2.comments,b.name as bname,b.designation,s.RefNo, c.VATRegNo 
--, bi.AccountTitle, bi.BankACNo, bi.BankName, bi.BranchName, bi.BankRoutingNo, bi.SwiftCode, bi.Email
--from InvoiceList i1,Company c,Ledger l,InvoiceSceduler i2,ContactPersons b,sales s, BankInformation bi
--where i1.id=i2.Invoice_Id and s.tno=i2.tno and s.pcode=l.id and s.cid=c.id and s.BillContactId=b.id And c.BankID = bi.BankID and i1.Invoice_No= '1703-000523-064-141804'
