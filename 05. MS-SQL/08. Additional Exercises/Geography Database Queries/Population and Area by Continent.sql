SELECT
	ContinentName,
	SUM(CAST(c.[AreaInSqKm] AS BIGINT)) AS [CountriesArea],
	SUM(CAST(c.[Population] AS BIGINT)) AS [CountriesPopulation]
FROM Countries AS c
	JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
	GROUP BY co.ContinentName
	ORDER BY [CountriesPopulation] DESC
