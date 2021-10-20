SELECT
	COUNT(*) AS count
FROM Colonists AS c
JOIN TravelCards AS t ON t.ColonistId = c.Id
JOIN Journeys AS j ON j.Id = t.JourneyId
WHERE j.Purpose = 'Technical'
GROUP BY j.Purpose
