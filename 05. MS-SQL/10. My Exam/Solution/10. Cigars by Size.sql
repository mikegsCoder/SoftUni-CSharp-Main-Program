SELECT
	c.LastName,
	CEILING(AVG(s.[Length])) AS CiagrLength,
	CEILING(AVG(s.RingRange)) AS CiagarRingRange
FROM Clients AS c
JOIN ClientsCigars AS cs ON cs.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cs.CigarId
JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY c.LastName
ORDER BY AVG(s.[Length]) DESC