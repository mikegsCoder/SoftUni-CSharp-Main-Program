SELECT 
	K.CountryName, 
	K.DistributorName
	FROM(
		SELECT
		C.[Name] AS CountryName,
		D.[Name] AS DistributorName,
		COUNT(I.Id) AS [Counter],
		DENSE_RANK() OVER (PARTITION BY C.[Name] ORDER BY COUNT(I.Id) DESC) AS [Rank]
		FROM Distributors D 
		LEFT JOIN Ingredients I ON I.DistributorId = D.Id 
		JOIN Countries C ON C.Id = D.CountryId
		GROUP BY C.[Name], D.[Name]
		) AS K
	WHERE k.[Rank] = 1
	ORDER BY K.CountryName, K.DistributorName