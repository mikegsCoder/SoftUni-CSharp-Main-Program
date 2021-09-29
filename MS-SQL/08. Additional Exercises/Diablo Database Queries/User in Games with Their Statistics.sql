SELECT
	u.Username,
	g.[Name] AS [Game],
	MAX(c.[Name]) AS [Character],
	SUM(itemStat.Strength) + MAX(gs.Strength) + MAX(cs.Strength) AS Sterngth,
	SUM(itemStat.Defence) + MAX(gs.Defence) + MAX(cs.Defence) AS Defence,
	SUM(itemStat.Speed) + MAX(gs.Speed) + MAX(cs.Speed) AS Speed,
	SUM(itemStat.Mind) + MAX(gs.Mind) + MAX(cs.Mind) AS Mind,
	SUM(itemStat.Luck) + MAX(gs.Luck) + MAX(cs.Luck) AS Luck
FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
	JOIN [Statistics] AS gs ON gs.Id = gt.BonusStatsId
	JOIN Characters AS c ON c.Id = ug.CharacterId
	JOIN [Statistics] AS cs ON cs.Id = c.StatisticId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS i ON i.Id = ugi.ItemId
	JOIN [Statistics] AS itemStat ON itemStat.Id = I.StatisticId
GROUP BY u.Username, g.[Name]
ORDER BY Sterngth DESC, Defence DESC,Speed DESC, Mind DESC, Luck DESC