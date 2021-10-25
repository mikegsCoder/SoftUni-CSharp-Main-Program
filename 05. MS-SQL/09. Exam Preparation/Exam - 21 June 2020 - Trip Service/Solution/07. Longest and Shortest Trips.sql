SELECT 
	AT.AccountId, 
	A.FirstName + ' ' + A.LastName AS [FullName], 
	MAX(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS LongestTrip, 
	MIN(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS ShortestTrip
	FROM AccountsTrips AT
	LEFT JOIN Accounts A ON A.Id = AT.AccountId
	LEFT JOIN Trips T ON T.Id = AT.TripId
	WHERE A.MiddleName IS NULL AND T.CancelDate IS NULL
	GROUP BY AT.AccountId, A.FirstName, A.LastName
	ORDER BY LongestTrip desc, ShortestTrip