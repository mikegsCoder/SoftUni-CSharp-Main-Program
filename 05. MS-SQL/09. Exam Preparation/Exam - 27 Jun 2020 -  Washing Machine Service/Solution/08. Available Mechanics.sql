SELECT
	FirstName + ' ' + LastName AS Available 
FROM Mechanics
WHERE MechanicId NOT IN
	(
		SELECT 
		m.MechanicId
		FROM Mechanics AS m
		JOIN Jobs AS j ON j.MechanicId = m.MechanicId
		WHERE j.Status != 'Finished'
	)
ORDER BY MechanicId