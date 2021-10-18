SELECT
	p.PartId,
	p.[Description],
	SUM(pn.Quantity) AS [Required],
	AVG(p.StockQty) AS [In Stock],
	ISNULL(SUM(op.Quantity), 0) AS [Ordered]
FROM Jobs AS j
JOIN PartsNeeded AS pn ON pn.JobId = j.JobId
JOIN Parts AS p ON p.PartId = pn.PartId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.Status != 'Finished'
GROUP BY p.PartId, p.[Description]
HAVING AVG(p.StockQty) + ISNULL(SUM(op.Quantity), 0) < SUM(pn.Quantity)
ORDER BY p.PartId