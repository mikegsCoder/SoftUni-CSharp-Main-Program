DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = 'Alex')
DECLARE @gameId INT = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

UPDATE UsersGames SET Cash -= (SELECT SUM(Price) FROM Items 
WHERE [Name] IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 
'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))
WHERE Id = @userGameId

INSERT INTO UserGameItems(UserGameId, ItemId)
SELECT @userGameId, Id FROM Items WHERE [Name] IN ('Blackguard', 'Bottomless Potion of Amplification', 
'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')


SELECT 
	u.Username,
	g.[Name],
	ug.Cash,
	i.[Name]
FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.[Name] = 'Edinburgh'
ORDER BY i.[Name]