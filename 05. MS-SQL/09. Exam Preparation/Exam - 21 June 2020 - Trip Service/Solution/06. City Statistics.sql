SELECT
	c.[Name],
	COUNT(*) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY COUNT(*) DESC, c.[Name]