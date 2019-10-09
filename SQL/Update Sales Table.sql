SELECT TNO, Tax, TaxId FROM Sales
WHERE NOT(Tax = 0 And TaxId = 0) And TaxId = 0
ORDER BY TNO

SELECT TNO, Tax, TaxId FROM Sales
WHERE (Tax > 0 And TaxId > 0)	-- NOT(Tax = 0 And TaxId = 0) And TaxId > 0
ORDER BY TNO

--select * from Ledger
--where id in (672,662)

DECLARE @VAT TABLE
(
	TNO int null,
	TaxId int null,
	Tax float null
)

INSERT INTO @VAT
SELECT s.Tno, s.TaxId, s.Tax 
FROM Sales s, Ledger l
WHERE l.Id=s.Tax and l.SBName like 'VAT%' and s.TaxId>0

SELECT * FROM @VAT

/*
UPDATE s
	SET s.Tax = t.TaxId,
	s.TaxId = t.Tax
FROM Sales s INNER JOIN @VAT t ON s.TNO = t.TNO
*/