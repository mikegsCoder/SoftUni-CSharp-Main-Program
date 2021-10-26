SELECT * FROM
(SELECT
	t.JobDuringJourney,
	c.FirstName + ' ' + c.LastName AS [FullName],
	RANK() OVER (PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) AS [JobRank]
FROM Colonists AS c
JOIN TravelCards AS t ON t.ColonistId = c.Id) AS RankedColonists
WHERE [JobRank] = 2
