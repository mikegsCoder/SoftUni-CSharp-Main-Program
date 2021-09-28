CREATE PROCEDURE usp_GetTownsStartingWith(@TownString NVARCHAR(20))
AS
BEGIN
	SELECT [Name] 
	FROM Towns
	WHERE SUBSTRING([Name], 1, LEN(@TownString)) = @TownString
END