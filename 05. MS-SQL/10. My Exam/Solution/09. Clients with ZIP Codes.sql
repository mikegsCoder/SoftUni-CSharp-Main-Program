SELECT
	[FullName],
	[Country],
	[ZIP],
	[CigarPrice]
FROM
(SELECT
	c.FirstName + ' ' + c.LastName AS [FullName],
	a.Country AS [Country],
	a.ZIP AS [ZIP],
	CONCAT('$', ci.PriceForSingleCigar) AS [CigarPrice],
	DENSE_RANK() OVER (PARTITION BY c.FirstName ORDER BY ci.PriceForSingleCigar DESC) AS [Ranked]
FROM Clients AS c
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN ClientsCigars AS cs ON cs.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cs.CigarId
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP, ci.PriceForSingleCigar) AS k
WHERE [Ranked] = 1