CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@minBalance MONEY)
AS
BEGIN
	SELECT FirstName AS [First Name], 
		   LastName AS [First Name]
	FROM AccountHolders AS ah
	JOIN Accounts AS ac ON ah.Id = ac.AccountHolderId
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @minBalance
	ORDER BY FirstName, LastName ASC
END