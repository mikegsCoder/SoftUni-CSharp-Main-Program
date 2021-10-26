SELECT
	J.JobId,
	ISNULL(SUM(P.Price * OP.Quantity), 0) AS Total
	FROM Jobs J
	LEFT JOIN Orders O ON O.JobId = J.JobId
	LEFT JOIN OrderParts OP ON OP.OrderId = O.OrderId
	LEFT JOIN Parts P ON P.PartId = OP.PartId
	WHERE J.[Status] = 'Finished'
	GROUP BY J.JobId
	ORDER BY Total DESC, J.JobId