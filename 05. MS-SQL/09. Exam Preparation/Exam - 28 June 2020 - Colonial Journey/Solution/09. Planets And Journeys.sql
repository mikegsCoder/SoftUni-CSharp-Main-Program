SELECT
	p.[Name] AS PlanetName,
	COUNT(*) AS JourneysCount
FROM
Planets AS p
JOIN Spaceports AS s ON s.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]
ORDER BY COUNT(*) DESC, p.[Name] 