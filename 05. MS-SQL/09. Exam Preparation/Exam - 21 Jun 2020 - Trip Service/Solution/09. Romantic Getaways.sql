SELECT 
	AT.AccountId, 
	A.Email, 
	C.[Name], 
	COUNT(AT.AccountId) AS Trips
	FROM AccountsTrips AT
	JOIN Accounts A ON A.Id = AT.AccountId
	JOIN Trips T ON T.Id = AT.TripId
	JOIN Rooms R ON R.Id = T.RoomId
	JOIN Hotels H ON H.Id = R.HotelId
	JOIN Cities C ON C.Id = H.CityId AND C.Id = A.CityId
	GROUP BY AT.AccountId, A.Email, C.[Name]
	ORDER BY COUNT(AT.AccountId) DESC, AT.AccountId