SELECT
	t.Id,
	a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name],
	(SELECT [Name] FROM Cities WHERE Id = a.CityId) AS [From],
	c.[Name] AS [To],
	--IIF(T.CancelDate IS NULL, CAST(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate) AS VARCHAR(MAX)) + ' days', 'Canceled') AS [Duration]
	CASE 
		WHEN (t.CancelDate IS NULL) 
			THEN CAST(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate) AS VARCHAR(MAX)) + ' days'
		ELSE 'Canceled'
	END AS Duration
FROM AccountsTrips AS ac 
JOIN Accounts AS a ON a.Id = ac.AccountId
JOIN Trips AS t ON t.Id = ac.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
ORDER BY [Full Name], t.Id
