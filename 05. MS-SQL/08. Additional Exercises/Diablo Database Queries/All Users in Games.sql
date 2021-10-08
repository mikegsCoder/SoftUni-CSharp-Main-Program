SELECT 
	g.[Name] AS [Game],
	gt.[Name] AS [Game Type],
	u.[Username] AS [Username],
	ug.[Level] AS [Level],
	ug.[Cash] AS [Cash],
	c.[Name] AS [Character]
FROM GAMES AS g
	JOIN UsersGames AS ug ON g.Id = ug.GameId
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Characters AS c ON c.Id = ug.CharacterId
	JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
		ORDER BY ug.[Level] DESC, u.[Username] ASC, g.[Name] ASC