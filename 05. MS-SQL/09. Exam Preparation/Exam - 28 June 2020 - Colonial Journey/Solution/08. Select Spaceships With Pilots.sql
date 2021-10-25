SELECT
	s.[Name],
	s.Manufacturer
FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId = s.Id
JOIN TravelCards AS t ON t.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = t.ColonistId
WHERE (t.JobDuringJourney = 'Pilot'
	AND DATEDIFF(year , c.BirthDate, '2019-01-01') < 30)
ORDER BY s.[Name]