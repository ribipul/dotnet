/*
SELECT TOP(1) * 
FROM CashRefund

SELECT TOP(10) * 
FROM Company

SELECT TOP(1) * 
FROM ChequeInfo

SELECT TOP(1) * 
FROM Journal


SELECT dp.DealInfoID, DP.Quantity AS DealQuantity, SUM(S.Quantity) AS SoldQuantity, dp.Price As DealPrice, 
(DP.Price-DP.Commission) AS UnitPrice, DP.Commission As Commission, (SUM(S.SalesPrice)-SUM(S.Commission)) AS TotalAmount	--(SUM(S.Quantity)*(DP.Price-DP.Commission)) AS TotalAmount 
FROM DealInfo D, DealProductInfo DP, Ledger P, Company M, Sales S 
WHERE DP.DealID = D.DealID AND P.id = DP.ProductId AND D.MerchantID = M.Id AND S.DealInfoID = DP.DealInfoID --AND dp.DealInfoID = @DealInfoID 
GROUP BY dp.DealInfoID, DP.Quantity, DP.Price, DP.Commission
*/

SELECT C.Name, CI.ChequeNo, CR.RefundDate
FROM ((((Company C INNER JOIN DealInfo D ON C.ID = D.MerchantID)
	INNER JOIN DealProductInfo DP ON D.DealID = DP.DealID)
	INNER JOIN CashRefund CR ON DP.DealInfoID = CR.DealInfoID)
	INNER JOIN ChequeInfo CI ON CR.ChequeID = CI.ChequeID)
WHERE C.OnLineMerchantID = 1159
ORDER BY CR.RefundDate DESC
