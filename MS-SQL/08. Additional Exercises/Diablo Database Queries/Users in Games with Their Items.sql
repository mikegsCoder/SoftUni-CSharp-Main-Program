SELECT 
	u.[Username] AS [Username],
	g.[Name] AS [Game],
	COUNT(ugi.ItemId) AS [Items Count],
	SUM(i.Price) AS [Items Price]	
FROM GAMES AS g
	JOIN UsersGames AS ug ON g.Id = ug.GameId
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS I ON I.Id = ugi.ItemId
		GROUP BY g.[Name], u.[Username]
		HAVING COUNT(ugi.ItemId) >= 10
		ORDER BY [Items Count] DESC, [Items Price] DESC, u.[Username] ASC